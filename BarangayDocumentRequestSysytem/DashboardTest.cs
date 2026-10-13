#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BarangayDocumentRequestSysytem
{
    public partial class DashboardTest : Form
    {
        private Button btnProcessing, btnReadyForPickup, btnFinished, btnRejected;
        private System.Collections.Generic.List<Button> navButtons;
        private NavBadge badgePending, badgeProcessing, badgeReady;
        private System.Windows.Forms.Timer badgeTimer;

        public DashboardTest()
        {
            InitializeComponent();
            BuildSidebar();
            LoadControl(new AdminControl());
            SetActiveNav(btnHome);

            // Notification numbers on the side panel
            badgePending = new NavBadge(btnPendingRequests);
            badgeProcessing = new NavBadge(btnProcessing);
            badgeReady = new NavBadge(btnReadyForPickup);
            RefreshBadges();

            Db.RequestsChanged += RefreshBadges;                       // instant refresh after an action
            badgeTimer = new System.Windows.Forms.Timer { Interval = 10000 };   // and pick up new resident requests
            badgeTimer.Tick += (s, e) => RefreshBadges();
            badgeTimer.Start();
            FormClosed += (s, e) => { Db.RequestsChanged -= RefreshBadges; badgeTimer.Stop(); badgeTimer.Dispose(); };
        }

        private void RefreshBadges()
        {
            if (IsDisposed) return;
            if (InvokeRequired) { BeginInvoke(new Action(RefreshBadges)); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(@"
                        SELECT
                          COALESCE(SUM(status IS NULL OR TRIM(status) = '' OR LOWER(status) = 'pending'), 0),
                          COALESCE(SUM(LOWER(status) = 'in process'), 0),
                          COALESCE(SUM(LOWER(status) = 'ready for pickup'), 0)
                        FROM documentrequests", conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            badgePending.Count = Convert.ToInt32(r[0]);
                            badgeProcessing.Count = Convert.ToInt32(r[1]);
                            badgeReady.Count = Convert.ToInt32(r[2]);
                        }
                    }
                }
            }
            catch { /* badges are optional; never block the admin */ }
        }

        // Adds the status pages to the side panel:
        // Pending -> Currently Processing -> Ready for Pickup -> Finished Documents, and Rejected Requests.
        private void BuildSidebar()
        {
            btnProcessing = CloneNavButton("btnProcessing", "⏳ Currently Processing", btnProcessing_Click);
            btnReadyForPickup = CloneNavButton("btnReadyForPickup", "📦 Ready for Pickup", btnReadyForPickup_Click);
            btnFinished = CloneNavButton("btnFinished", "✅ Finished Documents", btnFinished_Click);
            btnRejected = CloneNavButton("btnRejected", "❌ Rejected Requests", btnRejected_Click);

            Button[] order =
            {
                btnHome, btnResident, btnPendingRequests, btnProcessing, btnReadyForPickup,
                btnFinished, btnRejected, btnReport, btnSetting, btnLogout
            };
            navButtons = new System.Collections.Generic.List<Button>(order);

            navTLP.SuspendLayout();
            navTLP.Controls.Clear();
            navTLP.RowStyles.Clear();
            navTLP.RowCount = order.Length;
            for (int i = 0; i < order.Length; i++)
            {
                navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
                order[i].Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                order[i].Margin = new Padding(3, 1, 3, 1);
                navTLP.Controls.Add(order[i], 0, i);
            }
            navTLP.Location = new Point(0, 66);
            navTLP.Size = new Size(209, 44 * order.Length);
            navTLP.ResumeLayout();
        }

        private Button CloneNavButton(string name, string text, EventHandler onClick)
        {
            Button b = new Button
            {
                Name = name,
                Text = text,
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(12, 45, 93),
                Padding = new Padding(20, 0, 0, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                UseVisualStyleBackColor = false
            };
            b.FlatAppearance.BorderSize = 0;
            b.Click += onClick;
            return b;
        }

        // Highlights the page that is currently open
        private void SetActiveNav(Button active)
        {
            if (navButtons == null) return;
            foreach (Button b in navButtons)
            {
                b.UseVisualStyleBackColor = false;
                b.BackColor = b == active ? Color.FromArgb(37, 78, 140) : Color.FromArgb(12, 45, 93);
            }
        }

        private void DashboardTest_Load(object sender, EventArgs e)
        {
            // Auto-load AdminControl once DashboardTest finishes initializing
            LoadControl(new AdminControl());
            SetActiveNav(btnHome);
        }

        // --- Navigation Helper Function ---
        private void LoadControl(UserControl userControl)
        {
            if (userControl == null) return;

            // Locate target content display panel
            Control container = FindControlByName<Panel>(this, "panelContent")
                             ?? FindControlByName<Panel>(this, "panelMain")
                             ?? FindMainContainerPanel();

            if (container != null)
            {
                // Properly dispose previous controls to free up memory
                foreach (Control ctrl in container.Controls)
                {
                    ctrl.Dispose();
                }
                container.Controls.Clear();

                userControl.Dock = DockStyle.Fill;
                container.Controls.Add(userControl);
                userControl.BringToFront();
            }
        }

        private T FindControlByName<T>(Control parent, string name) where T : Control
        {
            foreach (Control c in parent.Controls)
            {
                if (c is T match && string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return match;
                }
                if (c.HasChildren)
                {
                    T childMatch = FindControlByName<T>(c, name);
                    if (childMatch != null) return childMatch;
                }
            }
            return null;
        }

        private Control FindMainContainerPanel()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel p && c.Dock != DockStyle.Left && c.Dock != DockStyle.Top)
                {
                    return p;
                }
            }
            return null;
        }

        // --- Sidebar Button Events ---
        private void btnHome_Click_1(object sender, EventArgs e)
        {
            LoadControl(new AdminControl());
            SetActiveNav(btnHome);
        }

        private void btnResident_Click_1(object sender, EventArgs e)
        {
            LoadControl(new Resident());
            SetActiveNav(btnResident);
        }

        private void btnPendingRequests_Click_1(object sender, EventArgs e)
        {
            LoadControl(new DocumentRequest());
            SetActiveNav(btnPendingRequests);
        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            LoadControl(new RequestListControl(RequestListControl.ListMode.Processing));
            SetActiveNav(btnProcessing);
        }

        private void btnReadyForPickup_Click(object sender, EventArgs e)
        {
            LoadControl(new RequestListControl(RequestListControl.ListMode.ReadyForPickup));
            SetActiveNav(btnReadyForPickup);
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            LoadControl(new RequestListControl(RequestListControl.ListMode.Finished));
            SetActiveNav(btnFinished);
        }

        private void btnRejected_Click(object sender, EventArgs e)
        {
            LoadControl(new RequestListControl(RequestListControl.ListMode.Rejected));
            SetActiveNav(btnRejected);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            LoadControl(new ReportsControl());
            SetActiveNav(btnReport);
        }

        private void btnSetting_Click_1(object sender, EventArgs e)
        {
            LoadControl(new Setting());
            SetActiveNav(btnSetting);
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