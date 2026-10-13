#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class UserPage : Form
    {
        private HomeControl homeControl;
        private ProfileControl profileControl;
        private AnnouncementsControl announcementsControl;
        private NavBadge badgeMyRequests;
        private System.Windows.Forms.Timer badgeTimer;

        private void RefreshBadges()
        {
            if (UserSession.UserId <= 0) return;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT COUNT(*) FROM documentrequests WHERE user_id = @u AND LOWER(status) = 'ready for pickup'", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", UserSession.UserId);
                        badgeMyRequests.Count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch { }
        }

        public UserPage()
        {
            InitializeComponent();
            ShowHomeView(); // Default landing screen

            // Red number on "My Requests" = documents that are ready for pickup
            badgeMyRequests = new NavBadge(btnMyRequests);
            RefreshBadges();
            badgeTimer = new System.Windows.Forms.Timer { Interval = 15000 };
            badgeTimer.Tick += (s, e) => RefreshBadges();
            badgeTimer.Start();
            this.FormClosed += (s, e) => { badgeTimer.Stop(); badgeTimer.Dispose(); };

            // Tell the resident about status changes (in process / ready for pickup / declined)
            this.Shown += (s, e) => CheckStatusNotifications();
        }

        private void CheckStatusNotifications()
        {
            if (UserSession.UserId <= 0) return;

            string cs = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";
            StringBuilder lines = new StringBuilder();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(@"
                        SELECT reference_no, document_type, status
                        FROM documentrequests
                        WHERE user_id = @u AND LOWER(status) <> 'pending'
                          AND (notified_status IS NULL OR notified_status <> status)
                        ORDER BY request_at DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", UserSession.UserId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                string doc = r["document_type"].ToString();
                                string refNo = r["reference_no"].ToString();

                                switch (r["status"].ToString().Trim().ToLower())
                                {
                                    case "in process":
                                        lines.AppendLine($"⏳ {doc} ({refNo}) is now being processed.");
                                        break;
                                    case "ready for pickup":
                                        lines.AppendLine($"✅ {doc} ({refNo}) is READY FOR PICKUP at the Barangay Hall. Please bring a valid ID.");
                                        break;
                                    case "rejected":
                                        lines.AppendLine($"❌ {doc} ({refNo}) was declined. Please visit the Barangay Hall for details.");
                                        break;
                                    case "approved":
                                        lines.AppendLine($"✔ {doc} ({refNo}) has been approved.");
                                        break;
                                }
                            }
                        }
                    }

                    using (MySqlCommand upd = new MySqlCommand(@"
                        UPDATE documentrequests SET notified_status = status
                        WHERE user_id = @u AND LOWER(status) <> 'pending'", conn))
                    {
                        upd.Parameters.AddWithValue("@u", UserSession.UserId);
                        upd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return; // a notification problem should never block the resident
            }

            if (lines.Length > 0)
            {
                MessageBox.Show(lines.ToString(), "📢 Document Request Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UserPage_Load(object sender, EventArgs e)
        {
            if (profileControl != null)
            {
                profileControl.RefreshControl();
            }
        }

        private void LoadControl(UserControl control)
        {
            panelContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
            control.BringToFront();
        }

        private void ShowHomeView()
        {
            if (homeControl == null)
            {
                homeControl = new HomeControl();
                // "View All >" links on the dashboard
                homeControl.ViewAllRequestsClicked += (s, e) => btnMyRequests_Click(s, e);
                homeControl.ViewAllAnnouncementsClicked += (s, e) => btnAnnouncements_Click(s, e);
            }
            LoadControl(homeControl);
            homeControl.LoadHomeData(); // Refresh transaction metrics
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowHomeView();
        }

        private void btnRequestDoc_Click(object sender, EventArgs e)
        {
            LoadControl(new RequestDocumentControl());
        }

        private void btnMyRequests_Click(object sender, EventArgs e)
        {
            LoadControl(new MyRequestsControl());
        }

        private void btnAnnouncements_Click(object sender, EventArgs e)
        {
            if (announcementsControl == null)
            {
                announcementsControl = new AnnouncementsControl();
            }

            panelContent.Controls.Clear();
            announcementsControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(announcementsControl);
            announcementsControl.BringToFront();

            announcementsControl.UpdateDashboard();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (profileControl == null)
            {
                profileControl = new ProfileControl();
            }
            LoadControl(profileControl);
            profileControl.RefreshControl(); // Refreshes both profile details & update request status
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to log out?\n\nYou will be returned to the login page.",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                this.Hide();

                Login lg = new Login();
                lg.ShowDialog();

                this.Close();
            }
        }
    }
}