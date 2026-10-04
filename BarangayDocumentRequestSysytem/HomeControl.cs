#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class HomeControl : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public HomeControl()
        {
            InitializeComponent();
            // Set live date immediately upon creation
            UpdateHeaderDate();
        }

        private void HomeControl_Load(object sender, EventArgs e)
        {
            LoadHomeData();
            UpdateHeaderDate();
        }

        private void HomeControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadHomeData();
                UpdateHeaderDate();
            }
        }

        public void LoadHomeData()
        {
            int currentUserId = UserSession.UserId;

            if (currentUserId <= 0)
            {
                SetLabelText("lblWelcome", "Welcome back!");
                SetLabelText("lblTotalCount", "0");
                SetLabelText("lblPendingCount", "0");
                SetLabelText("lblCompletedCount", "0");
                SetLabelText("lblRejectedCount", "0");
                SetEmptyAnnouncementState();
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Fetch User First Name & Last Name
                    string userQuery = "SELECT first_name, last_name FROM users WHERE user_id = @UserId LIMIT 1";
                    using (MySqlCommand cmdUser = new MySqlCommand(userQuery, conn))
                    {
                        cmdUser.Parameters.AddWithValue("@UserId", currentUserId);
                        using (MySqlDataReader reader = cmdUser.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fName = reader["first_name"]?.ToString() ?? "";
                                string lName = reader["last_name"]?.ToString() ?? "";
                                SetLabelText("lblWelcome", $"Welcome back, {fName} {lName}!".Trim());
                            }
                            else
                            {
                                SetLabelText("lblWelcome", "Welcome back!");
                            }
                        }
                    }

                    // 2. Fetch Transaction Counts
                    string countQuery = @"
                        SELECT 
                            COUNT(*) AS TotalCount,
                            SUM(CASE WHEN LOWER(status) = 'pending' THEN 1 ELSE 0 END) AS PendingCount,
                            SUM(CASE WHEN LOWER(status) IN ('completed', 'approved') THEN 1 ELSE 0 END) AS CompletedCount,
                            SUM(CASE WHEN LOWER(status) IN ('rejected', 'disapproved') THEN 1 ELSE 0 END) AS RejectedCount
                        FROM documentrequests 
                        WHERE user_id = @UserId";

                    using (MySqlCommand cmdCounts = new MySqlCommand(countQuery, conn))
                    {
                        cmdCounts.Parameters.AddWithValue("@UserId", currentUserId);
                        using (MySqlDataReader reader = cmdCounts.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int total = reader["TotalCount"] != DBNull.Value ? Convert.ToInt32(reader["TotalCount"]) : 0;
                                int pending = reader["PendingCount"] != DBNull.Value ? Convert.ToInt32(reader["PendingCount"]) : 0;
                                int completed = reader["CompletedCount"] != DBNull.Value ? Convert.ToInt32(reader["CompletedCount"]) : 0;
                                int rejected = reader["RejectedCount"] != DBNull.Value ? Convert.ToInt32(reader["RejectedCount"]) : 0;

                                SetLabelText("lblTotalCount", total.ToString());
                                SetLabelText("lblPendingCount", pending.ToString());
                                SetLabelText("lblCompletedCount", completed.ToString());
                                SetLabelText("lblRejectedCount", rejected.ToString());
                            }
                        }
                    }

                    // 3. Fetch 3 Most Recent Document Requests
                    string recentQuery = @"
                        SELECT document_type, request_at, status 
                        FROM documentrequests 
                        WHERE user_id = @UserId 
                        ORDER BY request_at DESC 
                        LIMIT 3";

                    using (MySqlCommand cmdRecent = new MySqlCommand(recentQuery, conn))
                    {
                        cmdRecent.Parameters.AddWithValue("@UserId", currentUserId);
                        using (MySqlDataReader reader = cmdRecent.ExecuteReader())
                        {
                            int index = 1;
                            while (reader.Read() && index <= 3)
                            {
                                string docType = reader["document_type"]?.ToString() ?? "Document Request";
                                string status = reader["status"]?.ToString() ?? "Pending";
                                string formattedDate = "";

                                if (reader["request_at"] != DBNull.Value)
                                {
                                    DateTime reqDate = Convert.ToDateTime(reader["request_at"]);
                                    formattedDate = reqDate.ToString("MMM dd, yyyy • h:mm tt");
                                }

                                SetLabelText($"lblReq{index}Title", docType);
                                SetLabelText($"lblReq{index}Date", formattedDate);

                                // Use UpdateStatusBadge instead of SetLabelText for dynamic styling
                                UpdateStatusBadge($"lblReq{index}Status", status);

                                index++;
                            }

                            // Clear remaining empty slots
                            for (int i = index; i <= 3; i++)
                            {
                                SetLabelText($"lblReq{i}Title", "");
                                SetLabelText($"lblReq{i}Date", "");
                                UpdateStatusBadge($"lblReq{i}Status", "");
                            }
                        }
                    }

                    // 4. Fetch Latest Announcement
                    LoadLatestAnnouncement(conn);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading home dashboard: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadLatestAnnouncement(MySqlConnection conn)
        {
            try
            {
                // Queries latest announcement from MySQL table
                string announceQuery = "SELECT title, content, date_posted FROM announcements ORDER BY date_posted DESC LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(announceQuery, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string title = reader["title"]?.ToString() ?? "Barangay Announcement";
                            string content = reader["content"]?.ToString() ?? "";
                            string datePosted = "";

                            if (reader["date_posted"] != DBNull.Value)
                            {
                                DateTime dt = Convert.ToDateTime(reader["date_posted"]);
                                datePosted = dt.ToString("MMMM dd, yyyy • h:mm tt");
                            }

                            SetLabelText("lblAnnouncementTitle", title);
                            SetLabelText("lblAnnouncementBody", content);
                            SetLabelText("lblAnnouncementDate", datePosted);
                        }
                        else
                        {
                            SetEmptyAnnouncementState();
                        }
                    }
                }
            }
            catch
            {
                // Fallback if announcements table does not exist or fails
                SetEmptyAnnouncementState();
            }
        }

        private void SetEmptyAnnouncementState()
        {
            SetLabelText("lblAnnouncementTitle", "No Announcements Yet");
            SetLabelText("lblAnnouncementBody", "There are currently no active announcements from the Barangay Office. Check back later for updates!");
            SetLabelText("lblAnnouncementDate", "");
        }

        // --- Recursive Helper Methods ---

        private void SetLabelText(string controlName, string text)
        {
            Label lbl = FindChildControl<Label>(this, controlName);
            if (lbl != null)
            {
                lbl.Text = text ?? "";
            }
        }

        private void UpdateHeaderDate()
        {
            if (lblDate != null)
            {
                lblDate.Text = DateHelper.CurrentHeaderDate;
            }
        }

        private void FormOrControl_Load(object sender, EventArgs e)
        {
            // Sets the standard header date dynamically
            lblDate.Text = DateHelper.CurrentHeaderDate;
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            // Updates automatically every second
            lblDate.Text = DateHelper.CurrentHeaderDate;
        }

        private T FindChildControl<T>(Control parent, string name) where T : Control
        {
            foreach (Control c in parent.Controls)
            {
                if (c is T match && string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return match;
                }

                if (c.HasChildren)
                {
                    T childMatch = FindChildControl<T>(c, name);
                    if (childMatch != null) return childMatch;
                }
            }
            return null;
        }

        private void UpdateStatusBadge(string controlName, string status)
        {
            Label lbl = FindChildControl<Label>(this, controlName);
            if (lbl == null) return;

            if (string.IsNullOrWhiteSpace(status))
            {
                lbl.Text = "";
                lbl.Visible = false;
                if (lbl.Parent is Panel pnl) pnl.Visible = false;
                return;
            }

            lbl.Visible = true;
            if (lbl.Parent is Panel pnlParent) pnlParent.Visible = true;

            // Force fixed label bounds and middle alignment
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Text = status;

            string normalizedStatus = status.Trim().ToLower();
            Color backColor;
            Color textColor;

            switch (normalizedStatus)
            {
                // GREEN: Completed / Approved / Processed
                case "completed":
                case "approved":
                case "processed":
                    backColor = Color.FromArgb(220, 252, 231); // Soft Green
                    textColor = Color.FromArgb(22, 101, 52);   // Dark Green Text
                    break;

                // YELLOW: Pending / For Review
                case "pending":
                case "for review":
                case "in progress":
                    backColor = Color.FromArgb(254, 249, 195); // Soft Yellow
                    textColor = Color.FromArgb(133, 77, 14);   // Dark Amber Text
                    break;

                // RED: Failed / Rejected / Disapproved / Cancelled
                case "failed":
                case "rejected":
                case "disapproved":
                case "cancelled":
                    backColor = Color.FromArgb(254, 226, 226); // Soft Red
                    textColor = Color.FromArgb(153, 27, 27);   // Dark Red Text
                    break;

                // DEFAULT: Soft Gray
                default:
                    backColor = Color.FromArgb(243, 244, 246);
                    textColor = Color.FromArgb(75, 85, 99);
                    break;
            }

            lbl.BackColor = backColor;
            lbl.ForeColor = textColor;

            // Sync parent panel container color if badges are hosted inside panels
            if (lbl.Parent is Panel badgePanel)
            {
                badgePanel.BackColor = backColor;
            }
        }
    }
}