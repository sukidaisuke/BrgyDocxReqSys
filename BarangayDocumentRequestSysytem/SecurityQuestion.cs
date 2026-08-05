using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class SecurityQuestion : Form
    {
        public SecurityQuestion()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SecurityQuestion_Load(object sender, EventArgs e)
        {

        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResetPassword rp = new ResetPassword();
            rp.ShowDialog();
            rp = null;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Lf = new Login();
            Lf.ShowDialog();
            Lf = null;
            this.Close();
        }
    }
}
