#nullable disable
using MySql.Data.MySqlClient; // MySQL driver
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class MyRequestsControl : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public MyRequestsControl()
        {
            InitializeComponent();
            cmbFilterStatus.Items.Insert(2, "In Process");
            cmbFilterStatus.Items.Insert(3, "Ready for Pickup");
            ApplyCustomGridStyling();

            // Set live date immediately
            if (lblDate != null)
            {
                lblDate.Text = DateHelper.CurrentHeaderDate;
            }
        }

        private void ApplyCustomGridStyling()
        {
            // 1. Disable default OS styles so custom header colors take effect
            dgvMyRequests.EnableHeadersVisualStyles = false;

            // 2. Custom header colors matching UI theme
            Color headerBg = Color.FromArgb(186, 218, 231); // Light blue header color
            Color headerFg = Color.FromArgb(30, 41, 59);    // Dark slate text

            dgvMyRequests.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            dgvMyRequests.ColumnHeadersDefaultCellStyle.ForeColor = headerFg;

            // 3. Prevent column headers from turning blue when selected or clicked
            dgvMyRequests.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBg;
            dgvMyRequests.ColumnHeadersDefaultCellStyle.SelectionForeColor = headerFg;

            // 4. Configure full-row selection with a clean highlight
            dgvMyRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyRequests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvMyRequests.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // 5. Proportional column widths
            if (dgvMyRequests.Columns["colDocType"] != null)
            {
                dgvMyRequests.Columns["colDocType"].FillWeight = 210F;      // ~44% width
                dgvMyRequests.Columns["colDateRequested"].FillWeight = 100F; // ~21% width
                dgvMyRequests.Columns["colFee"].FillWeight = 75F;            // ~15% width
                dgvMyRequests.Columns["colStatus"].FillWeight = 95F;         // ~20% width
            }
        }

        private void MyRequestsControl_Load(object sender, EventArgs e)
        {
            // Default to "All" on initial load
            if (cmbFilterStatus.SelectedIndex < 0)
            {
                cmbFilterStatus.SelectedIndex = 0;
            }
            else
            {
                LoadUserRequests();
            }
        }

        private void MyRequestsControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadUserRequests();
            }
        }

        // --- Helper to get fee rate for the document ---
        private string GetFeeForDocument(string docType, MySqlConnection conn)
        {
            try
            {
                string priceQuery = "SELECT price FROM document_types WHERE document_name = @DocName LIMIT 1";
                using (MySqlCommand priceCmd = new MySqlCommand(priceQuery, conn))
                {
                    priceCmd.Parameters.AddWithValue("@DocName", docType);
                    object result = priceCmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        decimal p = Convert.ToDecimal(result);
                        return p > 0 ? $"₱{p:N2}" : "FREE";
                    }
                }
            }
            catch
            {
                // Fallback to standard rates if query fails or price column is absent
            }

            if (string.IsNullOrWhiteSpace(docType)) return "₱0.00";

            if (docType.Equals("Certificate of Indigency", StringComparison.OrdinalIgnoreCase))
                return "FREE";
            if (docType.Equals("Barangay ID", StringComparison.OrdinalIgnoreCase))
                return "₱100.00";
            if (docType.Equals("Business Permit Endorsement", StringComparison.OrdinalIgnoreCase))
                return "₱150.00";

            return "₱50.00"; // Standard fee for Barangay Clearance, Residency, etc.
        }

        public void LoadUserRequests()
        {
            dgvMyRequests.Rows.Clear();

            int currentUserId = UserSession.UserId;

            // Session Check
            if (currentUserId <= 0)
            {
                lblShowingCount.Text = "Please log in to view your requests.";
                return;
            }

            string selectedStatus = cmbFilterStatus.SelectedItem != null
                ? cmbFilterStatus.SelectedItem.ToString()
                : "All";

            string searchText = txtSearch.Text.Replace("🔍  Search by document type...", "").Trim();

            // Construct SQL Query with dynamic filtering
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(@"SELECT document_type, request_at, status 
                    FROM documentrequests 
                    WHERE user_id = @UserId");

            if (!string.IsNullOrEmpty(selectedStatus) && !selectedStatus.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                if (selectedStatus.Equals("Approved", StringComparison.OrdinalIgnoreCase) ||
                    selectedStatus.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                {
                    queryBuilder.Append(" AND (status = 'Approved' OR status = 'Completed')");
                }
                else
                {
                    queryBuilder.Append(" AND status = @Status");
                }
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                queryBuilder.Append(" AND document_type LIKE @SearchText");
            }

            queryBuilder.Append(" ORDER BY request_at DESC");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(queryBuilder.ToString(), conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", currentUserId);

                    if (!string.IsNullOrEmpty(selectedStatus) &&
                        !selectedStatus.Equals("All", StringComparison.OrdinalIgnoreCase) &&
                        !selectedStatus.Equals("Approved", StringComparison.OrdinalIgnoreCase) &&
                        !selectedStatus.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                    {
                        cmd.Parameters.AddWithValue("@Status", selectedStatus);
                    }

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    }

                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            var requestList = new List<(string docType, string dateReq, string status)>();

                            while (reader.Read())
                            {
                                string docType = reader["document_type"].ToString();

                                string dateReq = reader["request_at"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["request_at"]).ToString("MMM dd, yyyy")
                                    : "N/A";

                                string status = reader["status"] != DBNull.Value
                                    ? reader["status"].ToString()
                                    : "Pending";

                                requestList.Add((docType, dateReq, status));
                            }

                            reader.Close();

                            foreach (var item in requestList)
                            {
                                string feeStr = GetFeeForDocument(item.docType, conn);
                                dgvMyRequests.Rows.Add(item.docType, item.dateReq, feeStr, item.status);
                            }
                        }

                        // Footer counter text
                        int totalRows = dgvMyRequests.Rows.Count;
                        if (totalRows == 0)
                        {
                            lblShowingCount.Text = "No requests found matching criteria.";
                        }
                        else
                        {
                            string pluralSuffix = totalRows == 1 ? "request" : "requests";
                            lblShowingCount.Text = $"Total: {totalRows} {pluralSuffix}";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"MySQL Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Remove automatic default row/header highlight when opening the view
            dgvMyRequests.ClearSelection();
            dgvMyRequests.CurrentCell = null;
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUserRequests();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "🔍  Search by document type...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "🔍  Search by document type...";
                txtSearch.ForeColor = SystemColors.ControlDark;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "🔍  Search by document type...")
            {
                LoadUserRequests();
            }
        }

        private void dgvMyRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMyRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMyRequests.Columns[e.ColumnIndex].Name == "colFee" && e.Value != null)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Bold);
            }

            if (dgvMyRequests.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "Pending":
                        e.CellStyle.BackColor = Color.FromArgb(254, 243, 199); // Soft yellow
                        e.CellStyle.ForeColor = Color.FromArgb(180, 120, 20);
                        break;

                    case "In Process":
                        e.CellStyle.BackColor = Color.FromArgb(219, 234, 254); // Soft blue
                        e.CellStyle.ForeColor = Color.FromArgb(30, 64, 175);
                        break;

                    case "Ready for Pickup":
                    case "Approved":
                    case "Completed":
                        e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); // Soft green
                        e.CellStyle.ForeColor = Color.FromArgb(22, 128, 61);   // Dark green
                        break;

                    case "Rejected":
                        e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); // Soft red
                        e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                        break;
                }
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}