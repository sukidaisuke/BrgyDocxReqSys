using System;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class Setting : UserControl
    {
        public Setting()
        {
            InitializeComponent();

            this.Load += Setting_Load;
            this.VisibleChanged += Setting_VisibleChanged;
            this.SizeChanged += Setting_SizeChanged;

            LoadSettingsPage(new BarangayInfo());
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            UpdateHeaderDate();
        }

        private void Setting_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                UpdateHeaderDate();
            }
        }

        private void Setting_SizeChanged(object sender, EventArgs e)
        {
            AdjustHeaderDatePosition();
        }

        private void UpdateHeaderDate()
        {
            if (lblDate != null)
            {
                lblDate.Text = $"📅 {DateTime.Now:MMMM d, yyyy | dddd}";
                AdjustHeaderDatePosition();
            }
        }

        private void AdjustHeaderDatePosition()
        {
            if (lblDate != null && NavPanel != null)
            {
                // Align Date right margin (20px from right edge) to match Residents header
                lblDate.Left = NavPanel.Width - lblDate.Width - 20;
            }
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

        private void dbmsBTN_Click(object sender, EventArgs e)
        {
            LoadSettingsPage(new Information_Update());
        }
    }
}