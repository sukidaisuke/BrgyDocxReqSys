#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class DashboardTest : Form
    {
        public DashboardTest()
        {
            InitializeComponent();
            LoadControl(new AdminControl());
        }

        private void DashboardTest_Load(object sender, EventArgs e)
        {
            // Auto-load AdminControl once DashboardTest finishes initializing
            LoadControl(new AdminControl());
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadControl(new AdminControl());
        }

        private void btnResident_Click(object sender, EventArgs e)
        {
            LoadControl(new Resident());
        }

        private void btnPendingRequests_Click(object sender, EventArgs e)
        {
            LoadControl(new DocumentRequest());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            LoadControl(new Setting());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
            }
        }
    }
}