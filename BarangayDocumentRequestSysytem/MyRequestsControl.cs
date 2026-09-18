using MySql.Data.MySqlClient; // My sql driver
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

        public static class UserSession
        {
            public static string Username { get; set; }
        }

        public MyRequestsControl()
        {
            InitializeComponent();
        }

        private void MyRequestsControl_Load(object sender, EventArgs e)
        {
            LoadUserRequests();
        }

        public void LoadUserRequests()
        {
            dgvMyRequests.Rows.Clear();

            // Check if a user is logged in
            if (string.IsNullOrEmpty(UserSession.Username)) UserSession.Username = " ";

            string query = @"SELECT RequestId, DocumentType, RequestedAt, Status 
                    FROM documentrequests 
                    WHERE RequesterUsername = @Username 
                    ORDER BY RequestedAt DESC";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Bind global logged-in username
                    cmd.Parameters.AddWithValue("@Username", UserSession.Username);

                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int reqId = Convert.ToInt32(reader["RequestId"]);
                                string refNo = $"REQ-{reqId:D4}"; // Formats 1 into REQ-0001
                                string docType = reader["DocumentType"].ToString();
                                string dateReq = Convert.ToDateTime(reader["RequestedAt"]).ToString("MMM dd, yyyy");
                                string status = reader["Status"].ToString();

                                dgvMyRequests.Rows.Add(refNo, docType, dateReq, status);
                            }
                        }

                        int totalRows = dgvMyRequests.Rows.Count;
                        lblShowingCount.Text = totalRows > 0
                            ? $"Showing 1 to {totalRows} of {totalRows} requests"
                            : "No request history found.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"MySQL Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
