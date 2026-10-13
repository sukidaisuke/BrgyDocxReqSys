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

            AddTemplatesButton();
            LoadSettingsPage(new BarangayInfo());
        }

        // New settings tab: edit the wording of each document template
        private void AddTemplatesButton()
        {
            Button b = new Button
            {
                Name = "templatesBTN",
                Text = "📝 Templates",
                Size = docxSettingBTN.Size,
                FlatStyle = docxSettingBTN.FlatStyle,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = docxSettingBTN.ForeColor,
                BackColor = docxSettingBTN.BackColor,
                TextAlign = ContentAlignment.MiddleLeft,
                UseVisualStyleBackColor = false
            };
            b.FlatAppearance.BorderSize = 0;
            b.Click += (s, e) => LoadSettingsPage(new TemplateEditorControl());

            menuTLP.SuspendLayout();
            menuTLP.RowCount = 7;
            menuTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            menuTLP.Controls.Add(b, 0, 6);
            menuTLP.Location = new Point(menuTLP.Left, 8);
            menuTLP.Height = 60 * 7;
            menuTLP.ResumeLayout();
        }

        private void Setting_Load(object? sender, EventArgs e)
        {
            UpdateHeaderDate();
        }

        private void Setting_VisibleChanged(object? sender, EventArgs e)
        {
            if (this.Visible)
            {
                UpdateHeaderDate();
            }
        }

        private void Setting_SizeChanged(object? sender, EventArgs e)
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