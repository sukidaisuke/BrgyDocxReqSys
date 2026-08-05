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

        private void bdayDTP_ValueChanged(object sender, EventArgs e)
        {
            DateTime birthdate = bdayDTP.Value;
            DateTime today = DateTime.Today;

            int age = today.Year - birthdate.Year;

            // adjust if their birthday hasn't happened yet this year
            if (birthdate.Date > today.AddYears(-age))
            {
                age--;
            }

            ageComboBox.Text = age.ToString(); // swap "ageComboBox" for your Age control's actual name
        }
        private void AddResident_Load(object sender, EventArgs e)
        {
            bdayDTP_ValueChanged(sender, e); // just reuse the same logic
        }

        private void cpComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allow digits, and allow Backspace (so users can still delete)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // this blocks the keystroke
            }
        }

        private void hnComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allow digits, and allow Backspace (so users can still delete)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // this blocks the keystroke
            }
        }
    }
}
