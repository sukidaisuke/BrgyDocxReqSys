#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class DocumentRequest : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";
        private int currentSelectedRequestId = -1;

        public DocumentRequest()
        {
            InitializeComponent();

            // Approve now means "open the document, edit, sign and release it"
            btnApprove.HeaderText = "Prepare";
            btnApprove.Text = "📝";
            btnModalApprove.Text = "📝 Prepare Document";

            // Processing / ready / rejected / finished requests now have their own pages in the sidebar
            btnRequestHistory.Visible = false;
            pendingReqLBL.Text = "Pending Requests";

            this.Load += DocumentRequest_Load;
            this.VisibleChanged += DocumentRequest_VisibleChanged;
        }

        private void DocumentRequest_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                UpdateHeaderDate();
                LoadPendingRequests();

                if (cmbHistoryStatusFilter != null && cmbHistoryStatusFilter.SelectedIndex < 0)
                {
                    cmbHistoryStatusFilter.SelectedIndex = 0; // Default to "All"
                }
            }
        }

        private void DocumentRequest_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !this.DesignMode)
            {
                LoadPendingRequests();
            }
        }

        private void UpdateHeaderDate()
        {
            if (lblDate != null)
            {
                lblDate.Text = $"📅 {DateTime.Now:MMMM d, yyyy | dddd}";
            }
        }

        // --- 1. Load Pending Requests from MySQL ---
        public void LoadPendingRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            r.request_id, 
                            r.document_type, 
                            r.request_at, 
                            r.status, 
                            COALESCE(NULLIF(TRIM(CONCAT(u.first_name, ' ', u.last_name)), ''), r.username, 'Resident') AS resident_name,
                            DATE_FORMAT(r.request_at, '%M %d, %Y • %h:%i %p') AS formatted_date
                        FROM documentrequests r 
                        LEFT JOIN users u ON r.user_id = u.user_id 
                        WHERE (r.status IS NULL OR TRIM(r.status) = '' OR LOWER(r.status) = 'pending')
                        ORDER BY r.request_at DESC, r.request_id DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvRequests.DataSource = dt;

                            if (lblTotalRequests != null)
                            {
                                lblTotalRequests.Text = $"Total: {dt.Rows.Count} Request(s)";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading pending requests: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- 2. Action Buttons Click Events (Decline ❌, View 👁️, Approve ✔) ---
        private void DgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int requestId = Convert.ToInt32(dgvRequests.Rows[e.RowIndex].Cells["request_id"].Value);
            string colName = dgvRequests.Columns[e.ColumnIndex].Name;

            if (colName == "btnReject")
            {
                DialogResult dialogResult = MessageBox.Show(
                    $"Are you sure you want to DECLINE request #{requestId}?",
                    "Confirm Rejection",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    UpdateRequestStatus(requestId, "Rejected");
                }
            }
            else if (colName == "btnView")
            {
                ShowRequestDetailsModal(requestId);
            }
            else if (colName == "btnApprove")
            {
                OpenDocumentEditor(requestId);
            }
        }

        // --- 3. Open Request Details Floating Modal ---
        private void ShowRequestDetailsModal(int requestId)
        {
            using (RequestDetailsForm details = new RequestDetailsForm(requestId, true))
            {
                details.ShowDialog(this.FindForm());

                if (details.Action == RequestDetailsForm.ChosenAction.Prepare)
                {
                    OpenDocumentEditor(requestId);
                }
                else if (details.Action == RequestDetailsForm.ChosenAction.Decline)
                {
                    DialogResult dr = MessageBox.Show(
                        $"Are you sure you want to DECLINE request #{requestId}?",
                        "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes) UpdateRequestStatus(requestId, "Rejected");
                }
            }
        }

        // --- 4. Request Details Modal Events ---
        private void BtnModalClose_Click(object sender, EventArgs e)
        {
            pnlModalOverlay.Visible = false;
            if (picAttachment.Image != null)
            {
                picAttachment.Image.Dispose();
                picAttachment.Image = null;
            }
            currentSelectedRequestId = -1;
        }

        private void BtnModalApprove_Click(object sender, EventArgs e)
        {
            if (currentSelectedRequestId > 0)
            {
                int id = currentSelectedRequestId;
                BtnModalClose_Click(sender, e);
                OpenDocumentEditor(id);
            }
        }

        private void BtnModalDecline_Click(object sender, EventArgs e)
        {
            if (currentSelectedRequestId > 0)
            {
                UpdateRequestStatus(currentSelectedRequestId, "Rejected");
                BtnModalClose_Click(sender, e);
            }
        }

        // --- Open the document editor (edit, sign, print, release) ---
        private void OpenDocumentEditor(int requestId)
        {
            using (DocumentEditorForm editor = new DocumentEditorForm(requestId))
            {
                editor.ShowDialog(this.FindForm());
            }
            LoadPendingRequests();
            Db.RaiseRequestsChanged();
        }

        // --- 5. Update Request Status ---
        private void UpdateRequestStatus(int requestId, string newStatus)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE documentrequests SET status = @status WHERE request_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@id", requestId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Request #{requestId} updated to '{newStatus}'.", "Status Updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadPendingRequests();
                    Db.RaiseRequestsChanged();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update status: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- 6. HISTORY MODAL EVENT HANDLERS & LOGIC ---
        private void BtnRequestHistory_Click(object sender, EventArgs e)
        {
            LoadHistoryRequests();
            pnlHistoryModalOverlay.BringToFront();
            pnlHistoryModalOverlay.Visible = true;
        }

        private void BtnHistoryClose_Click(object sender, EventArgs e)
        {
            pnlHistoryModalOverlay.Visible = false;
        }

        private void CmbHistoryStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHistoryRequests();
        }

        public void LoadHistoryRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string filter = cmbHistoryStatusFilter.SelectedItem != null
                        ? cmbHistoryStatusFilter.SelectedItem.ToString()
                        : "All";

                    StringBuilder query = new StringBuilder(@"
                        SELECT 
                            r.request_id, 
                            r.document_type, 
                            r.status, 
                            COALESCE(NULLIF(TRIM(CONCAT(u.first_name, ' ', u.last_name)), ''), r.username, 'Resident') AS resident_name,
                            DATE_FORMAT(r.request_at, '%b %d, %Y • %h:%i %p') AS formatted_date
                        FROM documentrequests r 
                        LEFT JOIN users u ON r.user_id = u.user_id 
                        WHERE LOWER(r.status) NOT IN ('pending', 'in process', 'ready for pickup')");

                    if (!filter.Equals("All", StringComparison.OrdinalIgnoreCase))
                    {
                        if (filter.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                        {
                            query.Append(" AND (LOWER(r.status) = 'approved' OR LOWER(r.status) = 'completed')");
                        }
                        else
                        {
                            query.Append(" AND LOWER(r.status) = @status");
                        }
                    }

                    query.Append(" ORDER BY r.request_at DESC, r.request_id DESC");

                    using (MySqlCommand cmd = new MySqlCommand(query.ToString(), conn))
                    {
                        if (!filter.Equals("All", StringComparison.OrdinalIgnoreCase) &&
                            !filter.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                        {
                            cmd.Parameters.AddWithValue("@status", filter.ToLower());
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvHistoryRequests.DataSource = dt;

                            if (lblHistoryTotal != null)
                            {
                                lblHistoryTotal.Text = $"Total History Records: {dt.Rows.Count}";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading history records: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvHistoryRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHistoryRequests.Columns[e.ColumnIndex].DataPropertyName == "status" && e.Value != null)
            {
                string statusStr = e.Value.ToString();
                if (statusStr.Equals("Approved", StringComparison.OrdinalIgnoreCase) ||
                    statusStr.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); // Soft green
                    e.CellStyle.ForeColor = Color.FromArgb(22, 128, 61);   // Dark green
                }
                else if (statusStr.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); // Soft red
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);   // Dark red
                }
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        #region Custom Border Paint Events
        /// <summary>
        /// Custom Paint event to draw a subtle 1px grey border on modal card panels,
        /// replacing default WinForms FixedSingle dark outline.
        /// </summary>
        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            }
        }

        /// <summary>
        /// Custom Paint event to replace default system GroupBox dark border
        /// with a clean, light grey outline.
        /// </summary>
        private void BodyGroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            if (box == null) return;

            // Clear default background fill
            e.Graphics.Clear(box.BackColor);

            // Measure title text size so top border line doesn't strike through it
            SizeF textSize = e.Graphics.MeasureString(box.Text, box.Font);
            int textHeight = (int)textSize.Height;

            // Rectangle boundary for custom border
            Rectangle borderRect = new Rectangle(0, textHeight / 2, box.Width - 1, box.Height - (textHeight / 2) - 1);

            // Draw custom grey border
            using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
            {
                e.Graphics.DrawRectangle(pen, borderRect);
            }

            // Redraw group box header text
            using (SolidBrush textBrush = new SolidBrush(box.ForeColor))
            using (SolidBrush bgBrush = new SolidBrush(box.BackColor))
            {
                e.Graphics.FillRectangle(bgBrush, 10, 0, textSize.Width, textHeight);
                e.Graphics.DrawString(box.Text, box.Font, textBrush, 10, 0);
            }
        }
        #endregion
    }
}