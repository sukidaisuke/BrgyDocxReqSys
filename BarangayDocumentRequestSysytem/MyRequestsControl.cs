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
        public MyRequestsControl()
        {
            InitializeComponent();
        }

        private void MyRequestsControl_Load(object sender, EventArgs e)
        {
            dgvMyRequests.Rows.Add("REQ-0001", "Barangay Clearance", "May 25, 2025", "Pending");
            dgvMyRequests.Rows.Add("REQ-0002", "Certificate of Residency", "May 20, 2025", "Completed");
            dgvMyRequests.Rows.Add("REQ-0003", "Indigency Certificate", "May 15, 2025", "Completed");
            dgvMyRequests.Rows.Add("REQ-0004", "Certificate of Good Moral Character", "May 10, 2025", "Rejected");

            lblShowingCount.Text = $"Showing 1 to {dgvMyRequests.Rows.Count} of {dgvMyRequests.Rows.Count} requests";
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
