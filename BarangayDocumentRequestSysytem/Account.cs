using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class Account : UserControl
    {
        public Account()
        {
            InitializeComponent();
        }

        private void hidepwBTN_Click(object sender, EventArgs e)
        {
            passwordTXT.UseSystemPasswordChar = !passwordTXT.UseSystemPasswordChar;
        }

        private void hidePWConfirmBTN_Click(object sender, EventArgs e)
        {
            pwConfirmTXT.UseSystemPasswordChar = !pwConfirmTXT.UseSystemPasswordChar;
        }
    }
}
