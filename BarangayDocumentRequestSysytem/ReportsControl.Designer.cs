namespace BarangayDocumentRequestSysytem
{
    partial class ReportsControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.NavPanel = new System.Windows.Forms.Panel();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.dividerPanel = new System.Windows.Forms.Panel();

            // Announcements Card
            this.cardAnnouncements = new System.Windows.Forms.Panel();
            this.pnlAnnounceAccent = new System.Windows.Forms.Panel();
            this.lblAnnouncementsTitle = new System.Windows.Forms.Label();
            this.lblAnnouncementsDesc = new System.Windows.Forms.Label();

            // Documents Card
            this.cardDocuments = new System.Windows.Forms.Panel();
            this.pnlDocAccent = new System.Windows.Forms.Panel();
            this.lblDocumentsTitle = new System.Windows.Forms.Label();
            this.lblDocumentsDesc = new System.Windows.Forms.Label();

            this.PanelContainer.SuspendLayout();
            this.NavPanel.SuspendLayout();
            this.cardAnnouncements.SuspendLayout();
            this.cardDocuments.SuspendLayout();
            this.SuspendLayout();

            // 
            // PanelContainer
            // 
            this.PanelContainer.Controls.Add(this.cardDocuments);
            this.PanelContainer.Controls.Add(this.cardAnnouncements);
            this.PanelContainer.Controls.Add(this.dividerPanel);
            this.PanelContainer.Controls.Add(this.NavPanel);
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(635, 512);
            this.PanelContainer.TabIndex = 27;

            // 
            // NavPanel
            // 
            this.NavPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NavPanel.Controls.Add(this.btnGenerateReport);
            this.NavPanel.Controls.Add(this.lblDate);
            this.NavPanel.Controls.Add(this.lblReportTitle);
            this.NavPanel.Location = new System.Drawing.Point(0, 0);
            this.NavPanel.Name = "NavPanel";
            this.NavPanel.Size = new System.Drawing.Size(635, 83);
            this.NavPanel.TabIndex = 27;

            // 
            // lblReportTitle
            // 
            this.lblReportTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblReportTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblReportTitle.Location = new System.Drawing.Point(24, 24);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(278, 32);
            this.lblReportTitle.TabIndex = 23;
            this.lblReportTitle.Text = "Reports & Management";

            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
            this.lblDate.ForeColor = System.Drawing.Color.DimGray;
            this.lblDate.Location = new System.Drawing.Point(420, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(188, 17);
            this.lblDate.TabIndex = 36;
            this.lblDate.Text = "📅 Date";

            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            this.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(430, 42);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(178, 30);
            this.btnGenerateReport.TabIndex = 37;
            this.btnGenerateReport.Text = "📊 Export Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.BtnGenerateReport_Click);

            // 
            // dividerPanel
            // 
            this.dividerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dividerPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.dividerPanel.Location = new System.Drawing.Point(0, 85);
            this.dividerPanel.Name = "dividerPanel";
            this.dividerPanel.Size = new System.Drawing.Size(635, 1);
            this.dividerPanel.TabIndex = 33;

            // 
            // cardAnnouncements
            // 
            this.cardAnnouncements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardAnnouncements.BackColor = System.Drawing.Color.White;
            this.cardAnnouncements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardAnnouncements.Controls.Add(this.pnlAnnounceAccent);
            this.cardAnnouncements.Controls.Add(this.lblAnnouncementsDesc);
            this.cardAnnouncements.Controls.Add(this.lblAnnouncementsTitle);
            this.cardAnnouncements.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardAnnouncements.Location = new System.Drawing.Point(24, 160);
            this.cardAnnouncements.Name = "cardAnnouncements";
            this.cardAnnouncements.Size = new System.Drawing.Size(584, 110);
            this.cardAnnouncements.TabIndex = 34;

            // 
            // pnlAnnounceAccent
            // 
            this.pnlAnnounceAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            this.pnlAnnounceAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAnnounceAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlAnnounceAccent.Name = "pnlAnnounceAccent";
            this.pnlAnnounceAccent.Size = new System.Drawing.Size(5, 108);
            this.pnlAnnounceAccent.TabIndex = 2;

            // 
            // lblAnnouncementsTitle
            // 
            this.lblAnnouncementsTitle.AutoSize = true;
            this.lblAnnouncementsTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblAnnouncementsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblAnnouncementsTitle.Location = new System.Drawing.Point(24, 22);
            this.lblAnnouncementsTitle.Name = "lblAnnouncementsTitle";
            this.lblAnnouncementsTitle.Size = new System.Drawing.Size(298, 23);
            this.lblAnnouncementsTitle.TabIndex = 0;
            this.lblAnnouncementsTitle.Text = "📢   ANNOUNCEMENTS SECTION";

            // 
            // lblAnnouncementsDesc
            // 
            this.lblAnnouncementsDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnnouncementsDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAnnouncementsDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAnnouncementsDesc.Location = new System.Drawing.Point(26, 54);
            this.lblAnnouncementsDesc.Name = "lblAnnouncementsDesc";
            this.lblAnnouncementsDesc.Size = new System.Drawing.Size(534, 38);
            this.lblAnnouncementsDesc.TabIndex = 1;
            this.lblAnnouncementsDesc.Text = "Create, publish, and update barangay notices fetched to all resident accounts.";

            // 
            // cardDocuments
            // 
            this.cardDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardDocuments.BackColor = System.Drawing.Color.White;
            this.cardDocuments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardDocuments.Controls.Add(this.pnlDocAccent);
            this.cardDocuments.Controls.Add(this.lblDocumentsDesc);
            this.cardDocuments.Controls.Add(this.lblDocumentsTitle);
            this.cardDocuments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardDocuments.Location = new System.Drawing.Point(24, 295);
            this.cardDocuments.Name = "cardDocuments";
            this.cardDocuments.Size = new System.Drawing.Size(584, 110);
            this.cardDocuments.TabIndex = 35;

            // 
            // pnlDocAccent
            // 
            this.pnlDocAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.pnlDocAccent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDocAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlDocAccent.Name = "pnlDocAccent";
            this.pnlDocAccent.Size = new System.Drawing.Size(5, 108);
            this.pnlDocAccent.TabIndex = 2;

            // 
            // lblDocumentsTitle
            // 
            this.lblDocumentsTitle.AutoSize = true;
            this.lblDocumentsTitle.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblDocumentsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDocumentsTitle.Location = new System.Drawing.Point(24, 22);
            this.lblDocumentsTitle.Name = "lblDocumentsTitle";
            this.lblDocumentsTitle.Size = new System.Drawing.Size(308, 23);
            this.lblDocumentsTitle.TabIndex = 0;
            this.lblDocumentsTitle.Text = "📄   READY-TO-PRINT DOCUMENTS";

            // 
            // lblDocumentsDesc
            // 
            this.lblDocumentsDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocumentsDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDocumentsDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDocumentsDesc.Location = new System.Drawing.Point(26, 54);
            this.lblDocumentsDesc.Name = "lblDocumentsDesc";
            this.lblDocumentsDesc.Size = new System.Drawing.Size(534, 38);
            this.lblDocumentsDesc.TabIndex = 1;
            this.lblDocumentsDesc.Text = "Generate official document samples pre-filled with the requestee's information.";

            // 
            // ReportsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelContainer);
            this.Name = "ReportsControl";
            this.Size = new System.Drawing.Size(635, 512);

            this.PanelContainer.ResumeLayout(false);
            this.NavPanel.ResumeLayout(false);
            this.NavPanel.PerformLayout();
            this.cardAnnouncements.ResumeLayout(false);
            this.cardAnnouncements.PerformLayout();
            this.cardDocuments.ResumeLayout(false);
            this.cardDocuments.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Panel NavPanel;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Panel dividerPanel;

        private System.Windows.Forms.Panel cardAnnouncements;
        private System.Windows.Forms.Panel pnlAnnounceAccent;
        private System.Windows.Forms.Label lblAnnouncementsTitle;
        private System.Windows.Forms.Label lblAnnouncementsDesc;

        private System.Windows.Forms.Panel cardDocuments;
        private System.Windows.Forms.Panel pnlDocAccent;
        private System.Windows.Forms.Label lblDocumentsTitle;
        private System.Windows.Forms.Label lblDocumentsDesc;
    }
}