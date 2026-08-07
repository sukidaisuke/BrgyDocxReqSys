namespace BarangayDocumentRequestSysytem
{
    partial class Setting
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PanelContainer = new Panel();
            menuPanel = new Panel();
            menuTLP = new TableLayoutPanel();
            aboutBTN = new Button();
            dbmsBTN = new Button();
            signBTN = new Button();
            accountBTN = new Button();
            brgyInfoBTN = new Button();
            docxSettingBTN = new Button();
            NavPanel = new Panel();
            nameLabel = new Label();
            DocumentReqTitleLabel = new Label();
            PanelContainer.SuspendLayout();
            menuPanel.SuspendLayout();
            menuTLP.SuspendLayout();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContainer
            // 
            PanelContainer.Controls.Add(menuPanel);
            PanelContainer.Controls.Add(NavPanel);
            PanelContainer.Dock = DockStyle.Fill;
            PanelContainer.Location = new Point(0, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(635, 512);
            PanelContainer.TabIndex = 0;
            PanelContainer.Paint += panel1_Paint;
            // 
            // menuPanel
            // 
            menuPanel.BackColor = Color.FromArgb(0, 0, 64);
            menuPanel.Controls.Add(menuTLP);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 100);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(194, 412);
            menuPanel.TabIndex = 31;
            // 
            // menuTLP
            // 
            menuTLP.ColumnCount = 1;
            menuTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            menuTLP.Controls.Add(aboutBTN, 0, 5);
            menuTLP.Controls.Add(dbmsBTN, 0, 4);
            menuTLP.Controls.Add(signBTN, 0, 3);
            menuTLP.Controls.Add(accountBTN, 0, 1);
            menuTLP.Controls.Add(brgyInfoBTN, 0, 0);
            menuTLP.Controls.Add(docxSettingBTN, 0, 2);
            menuTLP.Location = new Point(23, 25);
            menuTLP.Name = "menuTLP";
            menuTLP.RowCount = 6;
            menuTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            menuTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            menuTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            menuTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            menuTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            menuTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            menuTLP.Size = new Size(147, 359);
            menuTLP.TabIndex = 32;
            // 
            // aboutBTN
            // 
            aboutBTN.BackColor = Color.FromArgb(0, 0, 64);
            aboutBTN.FlatAppearance.BorderSize = 0;
            aboutBTN.FlatStyle = FlatStyle.Flat;
            aboutBTN.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            aboutBTN.ForeColor = Color.White;
            aboutBTN.Location = new Point(3, 303);
            aboutBTN.Name = "aboutBTN";
            aboutBTN.Size = new Size(141, 54);
            aboutBTN.TabIndex = 33;
            aboutBTN.Text = "ⓘ About";
            aboutBTN.TextAlign = ContentAlignment.MiddleLeft;
            aboutBTN.UseVisualStyleBackColor = false;
            // 
            // dbmsBTN
            // 
            dbmsBTN.BackColor = Color.FromArgb(0, 0, 64);
            dbmsBTN.FlatAppearance.BorderSize = 0;
            dbmsBTN.FlatStyle = FlatStyle.Flat;
            dbmsBTN.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dbmsBTN.ForeColor = Color.White;
            dbmsBTN.Location = new Point(3, 243);
            dbmsBTN.Name = "dbmsBTN";
            dbmsBTN.Size = new Size(141, 54);
            dbmsBTN.TabIndex = 34;
            dbmsBTN.Text = "💾 Database";
            dbmsBTN.TextAlign = ContentAlignment.MiddleLeft;
            dbmsBTN.UseVisualStyleBackColor = false;
            // 
            // signBTN
            // 
            signBTN.BackColor = Color.FromArgb(0, 0, 64);
            signBTN.FlatAppearance.BorderSize = 0;
            signBTN.FlatStyle = FlatStyle.Flat;
            signBTN.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signBTN.ForeColor = Color.White;
            signBTN.Location = new Point(3, 183);
            signBTN.Name = "signBTN";
            signBTN.Size = new Size(141, 54);
            signBTN.TabIndex = 35;
            signBTN.Text = "✍️ Signatories";
            signBTN.TextAlign = ContentAlignment.MiddleLeft;
            signBTN.UseVisualStyleBackColor = false;
            // 
            // accountBTN
            // 
            accountBTN.BackColor = Color.FromArgb(0, 0, 64);
            accountBTN.FlatAppearance.BorderSize = 0;
            accountBTN.FlatStyle = FlatStyle.Flat;
            accountBTN.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountBTN.ForeColor = Color.White;
            accountBTN.Location = new Point(3, 63);
            accountBTN.Name = "accountBTN";
            accountBTN.Size = new Size(141, 54);
            accountBTN.TabIndex = 36;
            accountBTN.Text = "👤 Account";
            accountBTN.TextAlign = ContentAlignment.MiddleLeft;
            accountBTN.UseVisualStyleBackColor = false;
            // 
            // brgyInfoBTN
            // 
            brgyInfoBTN.BackColor = Color.FromArgb(0, 0, 64);
            brgyInfoBTN.FlatAppearance.BorderSize = 0;
            brgyInfoBTN.FlatStyle = FlatStyle.Flat;
            brgyInfoBTN.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            brgyInfoBTN.ForeColor = Color.White;
            brgyInfoBTN.Location = new Point(3, 3);
            brgyInfoBTN.Name = "brgyInfoBTN";
            brgyInfoBTN.Size = new Size(141, 54);
            brgyInfoBTN.TabIndex = 32;
            brgyInfoBTN.Text = "🏦 Barangay              Information";
            brgyInfoBTN.TextAlign = ContentAlignment.MiddleLeft;
            brgyInfoBTN.UseVisualStyleBackColor = false;
            // 
            // docxSettingBTN
            // 
            docxSettingBTN.BackColor = Color.FromArgb(0, 0, 64);
            docxSettingBTN.FlatAppearance.BorderSize = 0;
            docxSettingBTN.FlatStyle = FlatStyle.Flat;
            docxSettingBTN.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            docxSettingBTN.ForeColor = Color.White;
            docxSettingBTN.Location = new Point(3, 123);
            docxSettingBTN.Name = "docxSettingBTN";
            docxSettingBTN.Size = new Size(141, 54);
            docxSettingBTN.TabIndex = 37;
            docxSettingBTN.Text = "📄 Document            Settings";
            docxSettingBTN.TextAlign = ContentAlignment.MiddleLeft;
            docxSettingBTN.UseVisualStyleBackColor = false;
            // 
            // NavPanel
            // 
            NavPanel.BackColor = Color.DarkSlateBlue;
            NavPanel.Controls.Add(nameLabel);
            NavPanel.Controls.Add(DocumentReqTitleLabel);
            NavPanel.Dock = DockStyle.Top;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(635, 100);
            NavPanel.TabIndex = 30;
            // 
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.Right;
            nameLabel.AutoSize = true;
            nameLabel.BackColor = Color.DarkSlateBlue;
            nameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.ForeColor = Color.DarkGray;
            nameLabel.Location = new Point(405, 12);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(213, 15);
            nameLabel.TabIndex = 29;
            nameLabel.Text = "Barangay Document Request System";
            // 
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.Anchor = AnchorStyles.Left;
            DocumentReqTitleLabel.AutoSize = true;
            DocumentReqTitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DocumentReqTitleLabel.ForeColor = Color.White;
            DocumentReqTitleLabel.Location = new Point(66, 34);
            DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            DocumentReqTitleLabel.Size = new Size(93, 30);
            DocumentReqTitleLabel.TabIndex = 27;
            DocumentReqTitleLabel.Text = "Settings";
            // 
            // Setting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelContainer);
            Name = "Setting";
            Size = new Size(635, 512);
            PanelContainer.ResumeLayout(false);
            menuPanel.ResumeLayout(false);
            menuTLP.ResumeLayout(false);
            NavPanel.ResumeLayout(false);
            NavPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContainer;
        private Panel NavPanel;
        private Label nameLabel;
        private Label DocumentReqTitleLabel;
        private Panel menuPanel;
        private TableLayoutPanel menuTLP;
        private Button docxSettingBTN;
        private Button accountBTN;
        private Button signBTN;
        private Button dbmsBTN;
        private Button aboutBTN;
        private Button brgyInfoBTN;
    }
}
