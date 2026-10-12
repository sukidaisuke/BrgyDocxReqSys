namespace BarangayDocumentRequestSysytem
{
    partial class AdminControl
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
            this.NavPanel = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderDate = new System.Windows.Forms.Label();
            this.dividerPanel = new System.Windows.Forms.Panel();

            this.card1 = new System.Windows.Forms.Panel();
            this.accent1 = new System.Windows.Forms.Panel();
            this.lblResidentsCount = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();

            this.card2 = new System.Windows.Forms.Panel();
            this.accent2 = new System.Windows.Forms.Panel();
            this.lblPendingCount = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();

            this.card3 = new System.Windows.Forms.Panel();
            this.accent3 = new System.Windows.Forms.Panel();
            this.lblCompletedCount = new System.Windows.Forms.Label();
            this.lblTitle3 = new System.Windows.Forms.Label();

            this.card4 = new System.Windows.Forms.Panel();
            this.accent4 = new System.Windows.Forms.Panel();
            this.lblAnnounceCount = new System.Windows.Forms.Label();
            this.lblTitle4 = new System.Windows.Forms.Label();

            this.pnlRequests = new System.Windows.Forms.Panel();
            this.lblReqHeader = new System.Windows.Forms.Label();
            this.row1 = new System.Windows.Forms.Panel();
            this.lblReq1Title = new System.Windows.Forms.Label();
            this.lblReq1Sub = new System.Windows.Forms.Label();
            this.lblReq1Status = new System.Windows.Forms.Label();
            this.row2 = new System.Windows.Forms.Panel();
            this.lblReq2Title = new System.Windows.Forms.Label();
            this.lblReq2Sub = new System.Windows.Forms.Label();
            this.lblReq2Status = new System.Windows.Forms.Label();
            this.row3 = new System.Windows.Forms.Panel();
            this.lblReq3Title = new System.Windows.Forms.Label();
            this.lblReq3Sub = new System.Windows.Forms.Label();
            this.lblReq3Status = new System.Windows.Forms.Label();

            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfoHeader = new System.Windows.Forms.Label();
            this.lblInfoBody = new System.Windows.Forms.Label();

            this.NavPanel.SuspendLayout();
            this.card1.SuspendLayout();
            this.card2.SuspendLayout();
            this.card3.SuspendLayout();
            this.card4.SuspendLayout();
            this.pnlRequests.SuspendLayout();
            this.row1.SuspendLayout();
            this.row2.SuspendLayout();
            this.row3.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();

            // 
            // NavPanel (Header layout matching Residents)
            // 
            this.NavPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NavPanel.Controls.Add(this.lblHeaderTitle);
            this.NavPanel.Controls.Add(this.lblHeaderDate);
            this.NavPanel.Location = new System.Drawing.Point(0, 0);
            this.NavPanel.Name = "NavPanel";
            this.NavPanel.Size = new System.Drawing.Size(635, 74);
            this.NavPanel.TabIndex = 0;

            // 
            // lblHeaderTitle (Aligned at X=20, Y=20 to match Residents header)
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 20);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(202, 32);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Admin Overview";

            // 
            // lblHeaderDate (Right-aligned to right margin like Residents view)
            // 
            this.lblHeaderDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
            this.lblHeaderDate.ForeColor = System.Drawing.Color.DimGray;
            this.lblHeaderDate.Location = new System.Drawing.Point(365, 24);
            this.lblHeaderDate.Name = "lblHeaderDate";
            this.lblHeaderDate.Size = new System.Drawing.Size(250, 22);
            this.lblHeaderDate.TabIndex = 1;
            this.lblHeaderDate.Text = "📅 Date";
            this.lblHeaderDate.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // dividerPanel
            // 
            this.dividerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dividerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dividerPanel.Location = new System.Drawing.Point(0, 75);
            this.dividerPanel.Name = "dividerPanel";
            this.dividerPanel.Size = new System.Drawing.Size(635, 1);
            this.dividerPanel.TabIndex = 1;

            // 
            // card1 (Residents)
            // 
            this.card1.BackColor = System.Drawing.Color.White;
            this.card1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card1.Controls.Add(this.accent1);
            this.card1.Controls.Add(this.lblResidentsCount);
            this.card1.Controls.Add(this.lblTitle1);
            this.card1.Location = new System.Drawing.Point(20, 95);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(130, 82);
            this.card1.TabIndex = 2;

            this.accent1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.accent1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accent1.Location = new System.Drawing.Point(0, 0);
            this.accent1.Name = "accent1";
            this.accent1.Size = new System.Drawing.Size(4, 80);
            this.accent1.TabIndex = 0;

            this.lblResidentsCount.AutoSize = true;
            this.lblResidentsCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblResidentsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblResidentsCount.Location = new System.Drawing.Point(12, 10);
            this.lblResidentsCount.Name = "lblResidentsCount";
            this.lblResidentsCount.Size = new System.Drawing.Size(28, 32);
            this.lblResidentsCount.TabIndex = 1;
            this.lblResidentsCount.Text = "0";

            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitle1.Location = new System.Drawing.Point(12, 50);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(61, 15);
            this.lblTitle1.TabIndex = 2;
            this.lblTitle1.Text = "Residents";

            // 
            // card2 (Pending)
            // 
            this.card2.BackColor = System.Drawing.Color.White;
            this.card2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card2.Controls.Add(this.accent2);
            this.card2.Controls.Add(this.lblPendingCount);
            this.card2.Controls.Add(this.lblTitle2);
            this.card2.Location = new System.Drawing.Point(164, 95);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(130, 82);
            this.card2.TabIndex = 3;

            this.accent2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.accent2.Dock = System.Windows.Forms.DockStyle.Left;
            this.accent2.Location = new System.Drawing.Point(0, 0);
            this.accent2.Name = "accent2";
            this.accent2.Size = new System.Drawing.Size(4, 80);
            this.accent2.TabIndex = 0;

            this.lblPendingCount.AutoSize = true;
            this.lblPendingCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPendingCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblPendingCount.Location = new System.Drawing.Point(12, 10);
            this.lblPendingCount.Name = "lblPendingCount";
            this.lblPendingCount.Size = new System.Drawing.Size(28, 32);
            this.lblPendingCount.TabIndex = 1;
            this.lblPendingCount.Text = "0";

            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitle2.Location = new System.Drawing.Point(12, 50);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(52, 15);
            this.lblTitle2.TabIndex = 2;
            this.lblTitle2.Text = "Pending";

            // 
            // card3 (Issued)
            // 
            this.card3.BackColor = System.Drawing.Color.White;
            this.card3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card3.Controls.Add(this.accent3);
            this.card3.Controls.Add(this.lblCompletedCount);
            this.card3.Controls.Add(this.lblTitle3);
            this.card3.Location = new System.Drawing.Point(308, 95);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(130, 82);
            this.card3.TabIndex = 4;

            this.accent3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.accent3.Dock = System.Windows.Forms.DockStyle.Left;
            this.accent3.Location = new System.Drawing.Point(0, 0);
            this.accent3.Name = "accent3";
            this.accent3.Size = new System.Drawing.Size(4, 80);
            this.accent3.TabIndex = 0;

            this.lblCompletedCount.AutoSize = true;
            this.lblCompletedCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCompletedCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblCompletedCount.Location = new System.Drawing.Point(12, 10);
            this.lblCompletedCount.Name = "lblCompletedCount";
            this.lblCompletedCount.Size = new System.Drawing.Size(28, 32);
            this.lblCompletedCount.TabIndex = 1;
            this.lblCompletedCount.Text = "0";

            this.lblTitle3.AutoSize = true;
            this.lblTitle3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitle3.Location = new System.Drawing.Point(12, 50);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(42, 15);
            this.lblTitle3.TabIndex = 2;
            this.lblTitle3.Text = "Issued";

            // 
            // card4 (Notices)
            // 
            this.card4.BackColor = System.Drawing.Color.White;
            this.card4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card4.Controls.Add(this.accent4);
            this.card4.Controls.Add(this.lblAnnounceCount);
            this.card4.Controls.Add(this.lblTitle4);
            this.card4.Location = new System.Drawing.Point(452, 95);
            this.card4.Name = "card4";
            this.card4.Size = new System.Drawing.Size(163, 82);
            this.card4.TabIndex = 5;

            this.accent4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(51)))), ((int)(((byte)(234)))));
            this.accent4.Dock = System.Windows.Forms.DockStyle.Left;
            this.accent4.Location = new System.Drawing.Point(0, 0);
            this.accent4.Name = "accent4";
            this.accent4.Size = new System.Drawing.Size(4, 80);
            this.accent4.TabIndex = 0;

            this.lblAnnounceCount.AutoSize = true;
            this.lblAnnounceCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAnnounceCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(51)))), ((int)(((byte)(234)))));
            this.lblAnnounceCount.Location = new System.Drawing.Point(12, 10);
            this.lblAnnounceCount.Name = "lblAnnounceCount";
            this.lblAnnounceCount.Size = new System.Drawing.Size(28, 32);
            this.lblAnnounceCount.TabIndex = 1;
            this.lblAnnounceCount.Text = "0";

            this.lblTitle4.AutoSize = true;
            this.lblTitle4.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitle4.Location = new System.Drawing.Point(12, 50);
            this.lblTitle4.Name = "lblTitle4";
            this.lblTitle4.Size = new System.Drawing.Size(49, 15);
            this.lblTitle4.TabIndex = 2;
            this.lblTitle4.Text = "Notices";

            // 
            // pnlRequests
            // 
            this.pnlRequests.BackColor = System.Drawing.Color.White;
            this.pnlRequests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRequests.Controls.Add(this.lblReqHeader);
            this.pnlRequests.Controls.Add(this.row1);
            this.pnlRequests.Controls.Add(this.row2);
            this.pnlRequests.Controls.Add(this.row3);
            this.pnlRequests.Location = new System.Drawing.Point(20, 195);
            this.pnlRequests.Name = "pnlRequests";
            this.pnlRequests.Size = new System.Drawing.Size(370, 290);
            this.pnlRequests.TabIndex = 6;

            // 
            // lblReqHeader
            // 
            this.lblReqHeader.AutoSize = true;
            this.lblReqHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblReqHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblReqHeader.Location = new System.Drawing.Point(15, 12);
            this.lblReqHeader.Name = "lblReqHeader";
            this.lblReqHeader.Size = new System.Drawing.Size(201, 20);
            this.lblReqHeader.TabIndex = 0;
            this.lblReqHeader.Text = "Recent Document Requests";

            // 
            // row1
            // 
            this.row1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.row1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.row1.Controls.Add(this.lblReq1Title);
            this.row1.Controls.Add(this.lblReq1Sub);
            this.row1.Controls.Add(this.lblReq1Status);
            this.row1.Location = new System.Drawing.Point(15, 42);
            this.row1.Name = "row1";
            this.row1.Size = new System.Drawing.Size(338, 70);
            this.row1.TabIndex = 1;

            this.lblReq1Title.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReq1Title.Location = new System.Drawing.Point(10, 10);
            this.lblReq1Title.Name = "lblReq1Title";
            this.lblReq1Title.Size = new System.Drawing.Size(220, 20);
            this.lblReq1Title.TabIndex = 0;
            this.lblReq1Title.Text = "Barangay Clearance";

            this.lblReq1Sub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblReq1Sub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblReq1Sub.Location = new System.Drawing.Point(10, 36);
            this.lblReq1Sub.Name = "lblReq1Sub";
            this.lblReq1Sub.Size = new System.Drawing.Size(220, 20);
            this.lblReq1Sub.TabIndex = 1;
            this.lblReq1Sub.Text = "Resident • Date";

            this.lblReq1Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(195)))));
            this.lblReq1Status.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblReq1Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(77)))), ((int)(((byte)(14)))));
            this.lblReq1Status.Location = new System.Drawing.Point(245, 18);
            this.lblReq1Status.Name = "lblReq1Status";
            this.lblReq1Status.Size = new System.Drawing.Size(80, 24);
            this.lblReq1Status.TabIndex = 2;
            this.lblReq1Status.Text = "Pending";
            this.lblReq1Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // row2
            // 
            this.row2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.row2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.row2.Controls.Add(this.lblReq2Title);
            this.row2.Controls.Add(this.lblReq2Sub);
            this.row2.Controls.Add(this.lblReq2Status);
            this.row2.Location = new System.Drawing.Point(15, 122);
            this.row2.Name = "row2";
            this.row2.Size = new System.Drawing.Size(338, 70);
            this.row2.TabIndex = 2;

            this.lblReq2Title.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReq2Title.Location = new System.Drawing.Point(10, 10);
            this.lblReq2Title.Name = "lblReq2Title";
            this.lblReq2Title.Size = new System.Drawing.Size(220, 20);
            this.lblReq2Title.TabIndex = 0;
            this.lblReq2Title.Text = "Indigency Certificate";

            this.lblReq2Sub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblReq2Sub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblReq2Sub.Location = new System.Drawing.Point(10, 36);
            this.lblReq2Sub.Name = "lblReq2Sub";
            this.lblReq2Sub.Size = new System.Drawing.Size(220, 20);
            this.lblReq2Sub.TabIndex = 1;
            this.lblReq2Sub.Text = "Resident • Date";

            this.lblReq2Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(195)))));
            this.lblReq2Status.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblReq2Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(77)))), ((int)(((byte)(14)))));
            this.lblReq2Status.Location = new System.Drawing.Point(245, 18);
            this.lblReq2Status.Name = "lblReq2Status";
            this.lblReq2Status.Size = new System.Drawing.Size(80, 24);
            this.lblReq2Status.TabIndex = 2;
            this.lblReq2Status.Text = "Pending";
            this.lblReq2Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // row3
            // 
            this.row3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.row3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.row3.Controls.Add(this.lblReq3Title);
            this.row3.Controls.Add(this.lblReq3Sub);
            this.row3.Controls.Add(this.lblReq3Status);
            this.row3.Location = new System.Drawing.Point(15, 202);
            this.row3.Name = "row3";
            this.row3.Size = new System.Drawing.Size(338, 70);
            this.row3.TabIndex = 3;

            this.lblReq3Title.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReq3Title.Location = new System.Drawing.Point(10, 10);
            this.lblReq3Title.Name = "lblReq3Title";
            this.lblReq3Title.Size = new System.Drawing.Size(220, 20);
            this.lblReq3Title.TabIndex = 0;
            this.lblReq3Title.Text = "Residency Certificate";

            this.lblReq3Sub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblReq3Sub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblReq3Sub.Location = new System.Drawing.Point(10, 36);
            this.lblReq3Sub.Name = "lblReq3Sub";
            this.lblReq3Sub.Size = new System.Drawing.Size(220, 20);
            this.lblReq3Sub.TabIndex = 1;
            this.lblReq3Sub.Text = "Resident • Date";

            this.lblReq3Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.lblReq3Status.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblReq3Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(52)))));
            this.lblReq3Status.Location = new System.Drawing.Point(245, 18);
            this.lblReq3Status.Name = "lblReq3Status";
            this.lblReq3Status.Size = new System.Drawing.Size(80, 24);
            this.lblReq3Status.TabIndex = 2;
            this.lblReq3Status.Text = "Approved";
            this.lblReq3Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlInfo (System Status Panel)
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.lblInfoHeader);
            this.pnlInfo.Controls.Add(this.lblInfoBody);
            this.pnlInfo.Location = new System.Drawing.Point(404, 195);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(211, 290);
            this.pnlInfo.TabIndex = 7;

            // 
            // lblInfoHeader
            // 
            this.lblInfoHeader.AutoSize = true;
            this.lblInfoHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInfoHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblInfoHeader.Location = new System.Drawing.Point(12, 12);
            this.lblInfoHeader.Name = "lblInfoHeader";
            this.lblInfoHeader.Size = new System.Drawing.Size(107, 20);
            this.lblInfoHeader.TabIndex = 0;
            this.lblInfoHeader.Text = "System Status";

            // 
            // lblInfoBody
            // 
            this.lblInfoBody.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblInfoBody.Location = new System.Drawing.Point(12, 45);
            this.lblInfoBody.Name = "lblInfoBody";
            this.lblInfoBody.Size = new System.Drawing.Size(185, 225);
            this.lblInfoBody.TabIndex = 1;
            this.lblInfoBody.Text = "• Barangay Document System\r\n\r\n• Database: ACTIVE\r\n\r\n• Auto-Sync: ENABLED\r\n\r\n• Live resident registrations and incoming request updates.";

            // 
            // AdminControl Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.NavPanel);
            this.Controls.Add(this.dividerPanel);
            this.Controls.Add(this.card1);
            this.Controls.Add(this.card2);
            this.Controls.Add(this.card3);
            this.Controls.Add(this.card4);
            this.Controls.Add(this.pnlRequests);
            this.Controls.Add(this.pnlInfo);
            this.Name = "AdminControl";
            this.Size = new System.Drawing.Size(635, 512);

            this.NavPanel.ResumeLayout(false);
            this.NavPanel.PerformLayout();
            this.card1.ResumeLayout(false);
            this.card1.PerformLayout();
            this.card2.ResumeLayout(false);
            this.card2.PerformLayout();
            this.card3.ResumeLayout(false);
            this.card3.PerformLayout();
            this.card4.ResumeLayout(false);
            this.card4.PerformLayout();
            this.pnlRequests.ResumeLayout(false);
            this.pnlRequests.PerformLayout();
            this.row1.ResumeLayout(false);
            this.row2.ResumeLayout(false);
            this.row3.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel NavPanel;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderDate;
        private System.Windows.Forms.Panel dividerPanel;

        private System.Windows.Forms.Panel card1, card2, card3, card4;
        private System.Windows.Forms.Panel accent1, accent2, accent3, accent4;
        private System.Windows.Forms.Label lblTitle1, lblTitle2, lblTitle3, lblTitle4;
        private System.Windows.Forms.Label lblResidentsCount, lblPendingCount, lblCompletedCount, lblAnnounceCount;

        private System.Windows.Forms.Panel pnlRequests;
        private System.Windows.Forms.Label lblReqHeader;
        private System.Windows.Forms.Panel row1, row2, row3;
        private System.Windows.Forms.Label lblReq1Title, lblReq1Sub, lblReq1Status;
        private System.Windows.Forms.Label lblReq2Title, lblReq2Sub, lblReq2Status;
        private System.Windows.Forms.Label lblReq3Title, lblReq3Sub, lblReq3Status;

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblInfoHeader;
        private System.Windows.Forms.Label lblInfoBody;
    }
}