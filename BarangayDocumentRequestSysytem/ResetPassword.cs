using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Password reset successfully!");
            this.Hide();
            Login Lf = new Login();
            Lf.ShowDialog();
            Lf = null;
            this.Close();
        }
    }
    }
