#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class AdminControl : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public AdminControl()
        {
            InitializeComponent();
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                RefreshDashboardData();
            }
        }

        public void RefreshDashboardData()
        {
            lblHeaderDate.Text = DateHelper.CurrentHeaderDate;
            FetchAdminMetrics();
            FetchRecentPendingRequests();
        }

        private void FetchAdminMetrics()
        {
            int totalResidents = GetDatabaseCount("SELECT COUNT(*) FROM users WHERE role = 'user' OR role IS NULL");
            int pendingRequests = GetDatabaseCount("SELECT COUNT(*) FROM document_requests WHERE status = 'Pending'");
            int completedRequests = GetDatabaseCount("SELECT COUNT(*) FROM document_requests WHERE status IN ('Approved', 'Completed', 'Ready for Pickup')");
            int totalAnnouncements = GetDatabaseCount("SELECT COUNT(*) FROM announcements");

            lblResidentsCount.Text = totalResidents.ToString();
            lblPendingCount.Text = pendingRequests.ToString();
            lblCompletedCount.Text = completedRequests.ToString();
            lblAnnounceCount.Text = totalAnnouncements.ToString();
        }

        private int GetDatabaseCount(string query)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private void FetchRecentPendingRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT r.request_id, u.username, r.document_type, r.status, r.request_date 
                                     FROM document_requests r 
                                     LEFT JOIN users u ON r.user_id = u.user_id 
                                     ORDER BY r.request_date DESC LIMIT 3";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int index = 1;
                            while (reader.Read())
                            {
                                string docType = reader["document_type"]?.ToString() ?? "Document Request";
                                string resident = reader["username"]?.ToString() ?? "Resident";
                                string status = reader["status"]?.ToString() ?? "Pending";
                                string dateStr = reader["request_date"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["request_date"]).ToString("MMM dd, yyyy")
                                    : "";

                                SetRowData(index, docType, $"{resident} • {dateStr}", status);
                                index++;
                            }
                        }
                    }
                }
                catch
                {
                    // Default values remain from designer
                }
            }
        }

        private void SetRowData(int rowIndex, string title, string sub, string status)
        {
            if (rowIndex == 1)
            {
                lblReq1Title.Text = title; lblReq1Sub.Text = sub; lblReq1Status.Text = status;
            }
            else if (rowIndex == 2)
            {
                lblReq2Title.Text = title; lblReq2Sub.Text = sub; lblReq2Status.Text = status;
            }
            else if (rowIndex == 3)
            {
                lblReq3Title.Text = title; lblReq3Sub.Text = sub; lblReq3Status.Text = status;
            }
        }
    }
}