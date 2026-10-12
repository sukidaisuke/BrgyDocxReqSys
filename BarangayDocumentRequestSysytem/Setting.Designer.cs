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
            PanelContainer = new System.Windows.Forms.Panel();
            dividerPanel = new System.Windows.Forms.Panel();
            contentPanel = new System.Windows.Forms.Panel();
            menuPanel = new System.Windows.Forms.Panel();
            menuTLP = new System.Windows.Forms.TableLayoutPanel();
            aboutBTN = new System.Windows.Forms.Button();
            dbmsBTN = new System.Windows.Forms.Button();
            signBTN = new System.Windows.Forms.Button();
            accountBTN = new System.Windows.Forms.Button();
            brgyInfoBTN = new System.Windows.Forms.Button();
            docxSettingBTN = new System.Windows.Forms.Button();
            NavPanel = new System.Windows.Forms.Panel();
            lblDate = new System.Windows.Forms.Label();
            DocumentReqTitleLabel = new System.Windows.Forms.Label();
            PanelContainer.SuspendLayout();
            menuPanel.SuspendLayout();
            menuTLP.SuspendLayout();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContainer
            // 
            PanelContainer.Controls.Add(dividerPanel);
            PanelContainer.Controls.Add(contentPanel);
            PanelContainer.Controls.Add(menuPanel);
            PanelContainer.Controls.Add(NavPanel);
            PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            PanelContainer.Location = new System.Drawing.Point(0, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new System.Drawing.Size(635, 512);
            PanelContainer.TabIndex = 0;
            // 
            // dividerPanel
            // 
            dividerPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dividerPanel.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            dividerPanel.Location = new System.Drawing.Point(0, 75);
            dividerPanel.Name = "dividerPanel";
            dividerPanel.Size = new System.Drawing.Size(635, 1);
            dividerPanel.TabIndex = 33;
            // 
            // contentPanel
            // 
            contentPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            contentPanel.Location = new System.Drawing.Point(190, 85);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new System.Drawing.Size(430, 415);
            contentPanel.TabIndex = 32;
            // 
            // menuPanel
            // 
            menuPanel.BackColor = System.Drawing.SystemColors.Control;
            menuPanel.Controls.Add(menuTLP);
            menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            menuPanel.Location = new System.Drawing.Point(0, 74);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new System.Drawing.Size(181, 438);
            menuPanel.TabIndex = 31;
            // 
            // menuTLP
            // 
            menuTLP.ColumnCount = 1;
            menuTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            menuTLP.Controls.Add(aboutBTN, 0, 5);
            menuTLP.Controls.Add(dbmsBTN, 0, 4);
            menuTLP.Controls.Add(signBTN, 0, 3);
            menuTLP.Controls.Add(accountBTN, 0, 1);
            menuTLP.Controls.Add(brgyInfoBTN, 0, 0);
            menuTLP.Controls.Add(docxSettingBTN, 0, 2);
            menuTLP.Location = new System.Drawing.Point(17, 20);
            menuTLP.Name = "menuTLP";
            menuTLP.RowCount = 6;
            menuTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            menuTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            menuTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            menuTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            menuTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            menuTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            menuTLP.Size = new System.Drawing.Size(147, 359);
            menuTLP.TabIndex = 32;
            // 
            // aboutBTN
            // 
            aboutBTN.BackColor = System.Drawing.SystemColors.Control;
            aboutBTN.FlatAppearance.BorderSize = 0;
            aboutBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            aboutBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            aboutBTN.ForeColor = System.Drawing.Color.DarkSlateBlue;
            aboutBTN.Location = new System.Drawing.Point(3, 303);
            aboutBTN.Name = "aboutBTN";
            aboutBTN.Size = new System.Drawing.Size(141, 54);
            aboutBTN.TabIndex = 33;
            aboutBTN.Text = "ⓘ About";
            aboutBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            aboutBTN.UseVisualStyleBackColor = false;
            aboutBTN.Click += aboutBTN_Click;
            // 
            // dbmsBTN
            // 
            dbmsBTN.BackColor = System.Drawing.SystemColors.Control;
            dbmsBTN.FlatAppearance.BorderSize = 0;
            dbmsBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            dbmsBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dbmsBTN.ForeColor = System.Drawing.Color.DarkSlateBlue;
            dbmsBTN.Location = new System.Drawing.Point(3, 243);
            dbmsBTN.Name = "dbmsBTN";
            dbmsBTN.Size = new System.Drawing.Size(141, 54);
            dbmsBTN.TabIndex = 34;
            dbmsBTN.Text = "💾 Information         Update";
            dbmsBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            dbmsBTN.UseVisualStyleBackColor = false;
            dbmsBTN.Click += dbmsBTN_Click;
            // 
            // signBTN
            // 
            signBTN.BackColor = System.Drawing.SystemColors.Control;
            signBTN.FlatAppearance.BorderSize = 0;
            signBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            signBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            signBTN.ForeColor = System.Drawing.Color.DarkSlateBlue;
            signBTN.Location = new System.Drawing.Point(3, 183);
            signBTN.Name = "signBTN";
            signBTN.Size = new System.Drawing.Size(141, 54);
            signBTN.TabIndex = 35;
            signBTN.Text = "✍️ Signatories";
            signBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            signBTN.UseVisualStyleBackColor = false;
            signBTN.Click += signBTN_Click;
            // 
            // accountBTN
            // 
            accountBTN.BackColor = System.Drawing.SystemColors.Control;
            accountBTN.FlatAppearance.BorderSize = 0;
            accountBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            accountBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            accountBTN.ForeColor = System.Drawing.Color.DarkSlateBlue;
            accountBTN.Location = new System.Drawing.Point(3, 63);
            accountBTN.Name = "accountBTN";
            accountBTN.Size = new System.Drawing.Size(141, 54);
            accountBTN.TabIndex = 36;
            accountBTN.Text = "👤 Account";
            accountBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            accountBTN.UseVisualStyleBackColor = false;
            accountBTN.Click += accountBTN_Click;
            // 
            // brgyInfoBTN
            // 
            brgyInfoBTN.BackColor = System.Drawing.SystemColors.Control;
            brgyInfoBTN.FlatAppearance.BorderSize = 0;
            brgyInfoBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            brgyInfoBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            brgyInfoBTN.ForeColor = System.Drawing.Color.DarkSlateBlue;
            brgyInfoBTN.Location = new System.Drawing.Point(3, 3);
            brgyInfoBTN.Name = "brgyInfoBTN";
            brgyInfoBTN.Size = new System.Drawing.Size(141, 54);
            brgyInfoBTN.TabIndex = 32;
            brgyInfoBTN.Text = "🏦 Barangay              Information";
            brgyInfoBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            brgyInfoBTN.UseVisualStyleBackColor = false;
            brgyInfoBTN.Click += brgyInfoBTN_Click;
            // 
            // docxSettingBTN
            // 
            docxSettingBTN.BackColor = System.Drawing.SystemColors.Control;
            docxSettingBTN.FlatAppearance.BorderSize = 0;
            docxSettingBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            docxSettingBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            docxSettingBTN.ForeColor = System.Drawing.Color.DarkSlateBlue;
            docxSettingBTN.Location = new System.Drawing.Point(3, 123);
            docxSettingBTN.Name = "docxSettingBTN";
            docxSettingBTN.Size = new System.Drawing.Size(141, 54);
            docxSettingBTN.TabIndex = 37;
            docxSettingBTN.Text = "📄 Document            Settings";
            docxSettingBTN.TextAlign = ContentAlignment.MiddleLeft;
            docxSettingBTN.UseVisualStyleBackColor = false;
            docxSettingBTN.Click += docxSettingBTN_Click;
            // 
            // NavPanel
            // 
            NavPanel.BackColor = System.Drawing.SystemColors.Control;
            NavPanel.Controls.Add(lblDate);
            NavPanel.Controls.Add(DocumentReqTitleLabel);
            NavPanel.Dock = System.Windows.Forms.DockStyle.Top;
            NavPanel.Location = new System.Drawing.Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new System.Drawing.Size(635, 74);
            NavPanel.TabIndex = 30;
            // 
            // lblDate
            // 
            lblDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblDate.ForeColor = System.Drawing.Color.DimGray;
            lblDate.Location = new System.Drawing.Point(365, 24);
            lblDate.Name = "lblDate";
            lblDate.Size = new System.Drawing.Size(250, 22);
            lblDate.TabIndex = 37;
            lblDate.Text = "📅 Date";
            lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.AutoSize = true;
            DocumentReqTitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            DocumentReqTitleLabel.ForeColor = System.Drawing.Color.DarkSlateBlue;
            DocumentReqTitleLabel.Location = new System.Drawing.Point(20, 20);
            DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            DocumentReqTitleLabel.Size = new System.Drawing.Size(106, 32);
            DocumentReqTitleLabel.TabIndex = 27;
            DocumentReqTitleLabel.Text = "Settings";
            // 
            // Setting
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(PanelContainer);
            Name = "Setting";
            Size = new System.Drawing.Size(635, 512);
            PanelContainer.ResumeLayout(false);
            menuPanel.ResumeLayout(false);
            menuTLP.ResumeLayout(false);
            NavPanel.ResumeLayout(false);
            NavPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Panel NavPanel;
        private System.Windows.Forms.Label DocumentReqTitleLabel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.TableLayoutPanel menuTLP;
        private System.Windows.Forms.Button docxSettingBTN;
        private System.Windows.Forms.Button accountBTN;
        private System.Windows.Forms.Button signBTN;
        private System.Windows.Forms.Button dbmsBTN;
        private System.Windows.Forms.Button aboutBTN;
        private System.Windows.Forms.Button brgyInfoBTN;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel dividerPanel;
        private System.Windows.Forms.Label lblDate;
    }
}