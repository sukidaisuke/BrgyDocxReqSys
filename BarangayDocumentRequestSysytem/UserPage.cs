#nullable disable
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

        public UserPage()
        {
            InitializeComponent();
            ShowHomeView(); // Default landing screen
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
            LoadControl(new AnnouncementsControl());
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (profileControl == null)
            {
                profileControl = new ProfileControl();
            }
            LoadControl(profileControl);
            profileControl.LoadUserProfile(); // Refresh profile details
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