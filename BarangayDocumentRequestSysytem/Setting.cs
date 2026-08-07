using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class Setting : UserControl
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void LoadSettingsPage(UserControl page)
        {
            contentPanel.Controls.Clear();

            page.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(page);
        }

        private void brgyInfoBTN_Click(object sender, EventArgs e)
        {
            LoadSettingsPage(new BarangayInfo());
        }

        private void accountBTN_Click(object sender, EventArgs e)
        {
            LoadSettingsPage(new Account());
        }

        private void docxSettingBTN_Click(object sender, EventArgs e)
        {
            LoadSettingsPage(new DocumentSettings());
        }

        private void signBTN_Click(object sender, EventArgs e)
        {
            LoadSettingsPage(new Signatories());
        }

        private void aboutBTN_Click(object sender, EventArgs e)
        {
            LoadSettingsPage(new About());
        }
    }
}
