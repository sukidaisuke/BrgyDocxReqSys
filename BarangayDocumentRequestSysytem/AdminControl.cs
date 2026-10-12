#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class AdminControl : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public AdminControl()
        {
            InitializeComponent();

            this.Load += AdminControl_Load;
            this.VisibleChanged += AdminControl_VisibleChanged;
            this.SizeChanged += AdminControl_SizeChanged;
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                RefreshDashboardData();
            }
        }

        private void AdminControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !this.DesignMode)
            {
                RefreshDashboardData();
            }
        }

        private void AdminControl_SizeChanged(object sender, EventArgs e)
        {
            AdjustHeaderDatePosition();
        }

        public void RefreshDashboardData()
        {
            UpdateHeaderDate();
            FetchAdminMetrics();
            FetchRecentRequests();
        }

        private void UpdateHeaderDate()
        {
            if (lblHeaderDate != null)
            {
                lblHeaderDate.Text = $"📅 {DateTime.Now:MMMM d, yyyy | dddd}";
                AdjustHeaderDatePosition();
            }
        }

        private void AdjustHeaderDatePosition()
        {
            if (lblHeaderDate != null && NavPanel != null)
            {
                // Align Date right margin (20px from right edge) to match Residents view
                lblHeaderDate.Left = NavPanel.Width - lblHeaderDate.Width - 20;
            }
        }

        // --- 1. Fetch Real Summary Counters from Database ---
        private void FetchAdminMetrics()
        {
            int totalResidents = GetDatabaseCount("SELECT COUNT(*) FROM users WHERE LOWER(role) = 'user' OR role IS NULL OR role = ''");
            int pendingRequests = GetDatabaseCount("SELECT COUNT(*) FROM documentrequests WHERE LOWER(status) = 'pending'");
            int completedRequests = GetDatabaseCount("SELECT COUNT(*) FROM documentrequests WHERE LOWER(status) IN ('approved', 'completed', 'processed', 'ready for pickup')");
            int totalAnnouncements = GetDatabaseCount("SELECT COUNT(*) FROM announcements");

            if (lblResidentsCount != null) lblResidentsCount.Text = totalResidents.ToString();
            if (lblPendingCount != null) lblPendingCount.Text = pendingRequests.ToString();
            if (lblCompletedCount != null) lblCompletedCount.Text = completedRequests.ToString();
            if (lblAnnounceCount != null) lblAnnounceCount.Text = totalAnnouncements.ToString();
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
            catch (Exception ex)
            {
                Console.WriteLine($"Database Count Error: {ex.Message}");
                return 0;
            }
        }

        // --- 2. Fetch Recent Document Requests ---
        private void FetchRecentRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            r.document_type, 
                            r.request_at, 
                            r.status, 
                            COALESCE(NULLIF(TRIM(CONCAT(u.first_name, ' ', u.last_name)), ''), r.username, 'Resident') AS resident_name
                        FROM documentrequests r 
                        LEFT JOIN users u ON r.user_id = u.user_id 
                        ORDER BY r.request_at DESC 
                        LIMIT 3";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int index = 1;
                            while (reader.Read() && index <= 3)
                            {
                                string docType = reader["document_type"]?.ToString() ?? "Document Request";
                                string resident = reader["resident_name"]?.ToString() ?? "Resident";
                                string status = reader["status"]?.ToString() ?? "Pending";
                                string dateStr = "";

                                if (reader["request_at"] != DBNull.Value)
                                {
                                    dateStr = Convert.ToDateTime(reader["request_at"]).ToString("MMM dd, yyyy");
                                }

                                SetRowData(index, docType, $"{resident} • {dateStr}", status);
                                index++;
                            }

                            for (int i = index; i <= 3; i++)
                            {
                                SetRowData(i, "No Request", "-", "");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database Connection Error: {ex.Message}\n\nCheck if MySQL service is running and database 'barangay_db' exists.",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // --- 3. Assign Row Data & Format Status Badges ---
        private void SetRowData(int rowIndex, string title, string sub, string status)
        {
            Label lblTitle = rowIndex == 1 ? lblReq1Title : rowIndex == 2 ? lblReq2Title : lblReq3Title;
            Label lblSub = rowIndex == 1 ? lblReq1Sub : rowIndex == 2 ? lblReq2Sub : lblReq3Sub;

            if (lblTitle != null) lblTitle.Text = title;
            if (lblSub != null) lblSub.Text = sub;

            UpdateStatusBadge(rowIndex, status);
        }

        private void UpdateStatusBadge(int rowIndex, string status)
        {
            Label lbl = rowIndex == 1 ? lblReq1Status : rowIndex == 2 ? lblReq2Status : lblReq3Status;
            if (lbl == null) return;

            if (string.IsNullOrWhiteSpace(status))
            {
                lbl.Text = "";
                lbl.Visible = false;
                return;
            }

            lbl.Visible = true;
            lbl.Text = status;

            string normalizedStatus = status.Trim().ToLower();
            Color backColor;
            Color textColor;

            switch (normalizedStatus)
            {
                case "completed":
                case "approved":
                case "processed":
                case "ready for pickup":
                    backColor = Color.FromArgb(220, 252, 231); // Soft Green
                    textColor = Color.FromArgb(22, 101, 52);   // Dark Green
                    break;

                case "pending":
                case "for review":
                case "in progress":
                    backColor = Color.FromArgb(254, 249, 195); // Soft Yellow
                    textColor = Color.FromArgb(133, 77, 14);   // Dark Amber
                    break;

                case "failed":
                case "rejected":
                case "disapproved":
                case "cancelled":
                    backColor = Color.FromArgb(254, 226, 226); // Soft Red
                    textColor = Color.FromArgb(153, 27, 27);   // Dark Red
                    break;

                default:
                    backColor = Color.FromArgb(243, 244, 246);
                    textColor = Color.FromArgb(75, 85, 99);
                    break;
            }

            lbl.BackColor = backColor;
            lbl.ForeColor = textColor;
        }
    }
}