using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class DashboardTest : Form
    {
        public DashboardTest()
        {
            InitializeComponent();
            LoadControl(new HomeControl());
        }

        private void LoadControl(UserControl control)
        {
            PanelContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            PanelContainer.Controls.Add(control);
        }

        private void btnResident_Click(object sender, EventArgs e)
        {
            LoadControl(new Resident());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            LoadControl(new Setting());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadControl(new HomeControl());
        }

        private void btnPendingRequests_Click(object sender, EventArgs e)
        {
            LoadControl(new DocumentRequest());
        }
    }
}
