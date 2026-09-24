#nullable disable
using MySql.Data.MySqlClient; // MySQL driver
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ApplyCustomGridStyling();
        }

        private void ApplyCustomGridStyling()
        {
            // 1. Disable default OS styles so custom header colors take effect
            dgvMyRequests.EnableHeadersVisualStyles = false;

            // 2. Custom header colors matching your UI theme
            Color headerBg = Color.FromArgb(186, 218, 231); // Light blue header color
            Color headerFg = Color.FromArgb(30, 41, 59);    // Dark slate text

            dgvMyRequests.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            dgvMyRequests.ColumnHeadersDefaultCellStyle.ForeColor = headerFg;

            // 3. Prevent column headers from turning blue when selected or clicked
            dgvMyRequests.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBg;
            dgvMyRequests.ColumnHeadersDefaultCellStyle.SelectionForeColor = headerFg;

            // 4. Configure full-row selection with a clean, modern soft highlight
            dgvMyRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyRequests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvMyRequests.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void MyRequestsControl_Load(object sender, EventArgs e)
        {
            LoadUserRequests();
        }

        private void MyRequestsControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadUserRequests();
            }
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

            string query = @"SELECT reference_no, document_type, request_at, status 
                    FROM documentrequests 
                    WHERE user_id = @UserId 
                    ORDER BY request_at DESC";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", currentUserId);

                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string refNo = reader["reference_no"] != DBNull.Value
                                    ? reader["reference_no"].ToString()
                                    : "N/A";
                                string docType = reader["document_type"].ToString();

                                string dateReq = reader["request_at"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["request_at"]).ToString("MMM dd, yyyy")
                                    : "N/A";

                                string status = reader["status"] != DBNull.Value
                                    ? reader["status"].ToString()
                                    : "Pending";

                                dgvMyRequests.Rows.Add(refNo, docType, dateReq, status);
                            }
                        }

                        // Footer counter text
                        int totalRows = dgvMyRequests.Rows.Count;
                        if (totalRows == 0)
                        {
                            lblShowingCount.Text = "No request history found.";
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

        private void dgvMyRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMyRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMyRequests.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "Pending":
                        e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                        e.CellStyle.ForeColor = Color.FromArgb(180, 120, 20);
                        break;
                    case "Completed":
                        e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                        e.CellStyle.ForeColor = Color.FromArgb(22, 128, 61);
                        break;
                    case "Rejected":
                        e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                        e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                        break;
                }
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}