using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class AddResident : UserControl
    {
        public AddResident()
        {
            InitializeComponent();
        }

        private void PanelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ReqInformationHeaderLabel_Click(object sender, EventArgs e)
        {

        }

        private void hnTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cpTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
