using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class ProfileControl : UserControl
    {
        public ProfileControl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

      
private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                MessageBox.Show("Contact number cannot be empty.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // TODO later: update these values in the database

            MessageBox.Show("Contact information updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtContactNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
