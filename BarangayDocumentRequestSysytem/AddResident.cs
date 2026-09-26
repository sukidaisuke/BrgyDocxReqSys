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

        private void FormOrControl_Load(object sender, EventArgs e)
        {
            // Sets the standard header date dynamically
            lblDate.Text = DateHelper.CurrentHeaderDate;
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

        private void Date_Tick(object sender, EventArgs e)
        {
            // Updates automatically every second
            lblDate.Text = DateHelper.CurrentHeaderDate;
        }
    }
}
