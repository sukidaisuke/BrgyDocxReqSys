#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// Admin list of requests in ONE status group. Used by the sidebar pages:
    /// Currently Processing, Ready for Pickup, Rejected Requests and Finished Documents.
    /// A request only ever appears in the group that matches its current status.
    /// </summary>
    public class RequestListControl : UserControl
    {
        public enum ListMode { Processing, ReadyForPickup, Rejected, Finished }

        private readonly ListMode mode;
        private Label lblTitle, lblSub, lblDate, lblTotal;
        private DataGridView dgv;

        public RequestListControl(ListMode mode)
        {
            this.mode = mode;
            BuildUi();
            Load += (s, e) => LoadRequests();
            VisibleChanged += (s, e) => { if (Visible && !DesignMode) LoadRequests(); };
        }

        private string StatusFilterSql()
        {
            switch (mode)
            {
                case ListMode.Processing: return "LOWER(r.status) = 'in process'";
                case ListMode.ReadyForPickup: return "LOWER(r.status) = 'ready for pickup'";
                case ListMode.Rejected: return "LOWER(r.status) IN ('rejected', 'disapproved')";
                default: return "LOWER(r.status) IN ('completed', 'approved')";
            }
        }

        private void BuildUi()
        {
            BackColor = Color.White;
            Dock = DockStyle.Fill;

            string title, sub;
            switch (mode)
            {
                case ListMode.Processing:
                    title = "Currently Processing"; sub = "Requests being prepared by the barangay office"; break;
                case ListMode.ReadyForPickup:
                    title = "Ready for Pickup"; sub = "Prepared documents waiting for the resident to pick them up"; break;
                case ListMode.Rejected:
                    title = "Rejected Requests"; sub = "Requests that were declined"; break;
                default:
                    title = "Finished Documents"; sub = "Documents that were picked up by the resident"; break;
            }

            Panel header = new Panel { Dock = DockStyle.Top, Height = 84, BackColor = Color.White };
            lblTitle = new Label
            {
                Text = title,
                AutoSize = true,
                Font = new Font("Impact", 18F),
                ForeColor = Color.FromArgb(12, 45, 93),
                Location = new Point(24, 14)
            };
            lblSub = new Label
            {
                Text = sub,
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.DimGray,
                Location = new Point(26, 52)
            };
            lblDate = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.DimGray,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Text = $"📅 {DateTime.Now:MMMM d, yyyy | dddd}"
            };
            header.Controls.AddRange(new Control[] { lblTitle, lblSub, lblDate });
            header.Resize += (s, e) => lblDate.Location = new Point(header.Width - lblDate.Width - 24, 18);

            Panel footer = new Panel { Dock = DockStyle.Bottom, Height = 40, BackColor = Color.White };
            lblTotal = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 65, 81),
                Location = new Point(24, 11)
            };
            footer.Controls.Add(lblTotal);

            dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 34,
                RowTemplate = { Height = 34 },
                Font = new Font("Segoe UI", 9.5F)
            };
            Color headerBg = Color.FromArgb(186, 218, 231);
            Color headerFg = Color.FromArgb(30, 41, 59);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = headerFg;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBg;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = headerFg;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            AddTextColumn("request_id", "request_id", 0, false);
            AddTextColumn("reference_no", "Ref. No.", 90, true);
            AddTextColumn("resident_name", "Resident", 150, true);
            AddTextColumn("document_type", "Document", 160, true);
            AddTextColumn("formatted_date", "Requested", 120, true);
            AddTextColumn("status", "Status", 90, true);

            AddButtonColumn("btnView", "👁 View", "Details");
            if (mode == ListMode.Processing || mode == ListMode.ReadyForPickup)
                AddButtonColumn("btnOpen", "📝 Open", "Document");
            if (mode == ListMode.ReadyForPickup)
                AddButtonColumn("btnPickedUp", "✔ Picked Up", "Release");
            if (mode == ListMode.Finished)
                AddButtonColumn("btnOpen", "🖨 Document", "Document");

            dgv.CellContentClick += Dgv_CellContentClick;
            dgv.CellFormatting += Dgv_CellFormatting;

            Controls.Add(dgv);
            Controls.Add(footer);
            Controls.Add(header);
            dgv.BringToFront();
        }

        private void AddTextColumn(string dataProp, string header, float weight, bool visible)
        {
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn
            {
                Name = dataProp,
                DataPropertyName = dataProp,
                HeaderText = header,
                FillWeight = weight > 0 ? weight : 10,
                Visible = visible
            };
            dgv.Columns.Add(c);
        }

        private void AddButtonColumn(string name, string text, string header)
        {
            DataGridViewButtonColumn c = new DataGridViewButtonColumn
            {
                Name = name,
                HeaderText = header,
                Text = text,
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                FillWeight = 70
            };
            dgv.Columns.Add(c);
        }

        public void LoadRequests()
        {
            lblDate.Text = $"📅 {DateTime.Now:MMMM d, yyyy | dddd}";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT r.request_id, r.reference_no, r.document_type, r.status,
                               COALESCE(NULLIF(TRIM(CONCAT(u.first_name, ' ', u.last_name)), ''), r.username, 'Resident') AS resident_name,
                               DATE_FORMAT(r.request_at, '%b %d, %Y • %h:%i %p') AS formatted_date
                        FROM documentrequests r
                        LEFT JOIN users u ON r.user_id = u.user_id
                        WHERE " + StatusFilterSql() + @"
                        ORDER BY r.request_at DESC, r.request_id DESC";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgv.DataSource = dt;
                        lblTotal.Text = dt.Rows.Count == 0
                            ? "No requests here yet."
                            : $"Total: {dt.Rows.Count} request(s)";
                    }
                }
                dgv.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requests: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string col = dgv.Columns[e.ColumnIndex].Name;
            object idVal = dgv.Rows[e.RowIndex].Cells["request_id"].Value;
            if (idVal == null || idVal == DBNull.Value) return;
            int requestId = Convert.ToInt32(idVal);

            if (col == "btnView")
            {
                using (RequestDetailsForm f = new RequestDetailsForm(requestId, false))
                    f.ShowDialog(FindForm());
            }
            else if (col == "btnOpen")
            {
                using (DocumentEditorForm editor = new DocumentEditorForm(requestId))
                    editor.ShowDialog(FindForm());
                LoadRequests();   // the status may have changed, so the row may move to another page
                Db.RaiseRequestsChanged();
            }
            else if (col == "btnPickedUp")
            {
                DialogResult dr = MessageBox.Show(
                    "Confirm that the resident has picked up the signed document?",
                    "Mark as Picked Up", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;

                SetStatus(requestId, "Completed");
            }
        }

        private void SetStatus(int requestId, string newStatus)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE documentrequests SET status = @s WHERE request_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@s", newStatus);
                        cmd.Parameters.AddWithValue("@id", requestId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Marked as picked up. The document is now under Finished Documents.", "Updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequests();
                Db.RaiseRequestsChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update status: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Value == null) return;
            if (dgv.Columns[e.ColumnIndex].Name != "status") return;

            switch (e.Value.ToString().ToLower())
            {
                case "in process":
                    e.CellStyle.BackColor = Color.FromArgb(219, 234, 254); e.CellStyle.ForeColor = Color.FromArgb(30, 64, 175); break;
                case "ready for pickup":
                case "completed":
                case "approved":
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52); break;
                case "rejected":
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27); break;
            }
            e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
