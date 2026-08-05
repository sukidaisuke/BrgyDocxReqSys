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
        }
        private void DocumentReqButton_Click(object sender, EventArgs e)
        {
            PanelContainer.Visible = true;

            PanelContainer.Controls.Clear();

            DocumentRequest documentRequest = new DocumentRequest();
            documentRequest.Dock = DockStyle.Fill;

            PanelContainer.Controls.Add(documentRequest);
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();

            Dashboard dashboardContent = new Dashboard(); // your dashboard UserControl
            dashboardContent.Dock = DockStyle.Fill;

            PanelContainer.Controls.Add(dashboardContent);
            PanelContainer.Visible = true;
        }
    }
}
