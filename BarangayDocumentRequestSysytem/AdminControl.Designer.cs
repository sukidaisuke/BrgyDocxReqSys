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
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderDate = new System.Windows.Forms.Label();

            // KPI Cards
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

            // Requests Panel
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

            // Info Panel
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfoHeader = new System.Windows.Forms.Label();
            this.lblInfoBody = new System.Windows.Forms.Label();

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
            // AdminControl Layout (635 x 512)
            // 
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Name = "AdminControl";
            this.Size = new System.Drawing.Size(635, 512);

            // Header Title & Date
            this.lblHeaderTitle.Text = "Admin Overview";
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblHeaderTitle.Location = new System.Drawing.Point(15, 12);
            this.lblHeaderTitle.AutoSize = true;

            this.lblHeaderDate.Text = "September 26, 2026 | Saturday";
            this.lblHeaderDate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderDate.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHeaderDate.Location = new System.Drawing.Point(370, 15);
            this.lblHeaderDate.Size = new System.Drawing.Size(250, 20);
            this.lblHeaderDate.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // --- Card 1 (Residents) ---
            this.card1.BackColor = System.Drawing.Color.White;
            this.card1.Location = new System.Drawing.Point(15, 50);
            this.card1.Size = new System.Drawing.Size(140, 80);
            this.accent1.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.accent1.Location = new System.Drawing.Point(0, 0);
            this.accent1.Size = new System.Drawing.Size(4, 80);
            this.lblResidentsCount.Text = "0";
            this.lblResidentsCount.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblResidentsCount.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblResidentsCount.Location = new System.Drawing.Point(10, 8);
            this.lblResidentsCount.AutoSize = true;
            this.lblTitle1.Text = "Residents";
            this.lblTitle1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle1.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitle1.Location = new System.Drawing.Point(10, 48);
            this.lblTitle1.AutoSize = true;
            this.card1.Controls.Add(this.accent1);
            this.card1.Controls.Add(this.lblResidentsCount);
            this.card1.Controls.Add(this.lblTitle1);

            // --- Card 2 (Pending) ---
            this.card2.BackColor = System.Drawing.Color.White;
            this.card2.Location = new System.Drawing.Point(170, 50);
            this.card2.Size = new System.Drawing.Size(140, 80);
            this.accent2.BackColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.accent2.Location = new System.Drawing.Point(0, 0);
            this.accent2.Size = new System.Drawing.Size(4, 80);
            this.lblPendingCount.Text = "0";
            this.lblPendingCount.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblPendingCount.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblPendingCount.Location = new System.Drawing.Point(10, 8);
            this.lblPendingCount.AutoSize = true;
            this.lblTitle2.Text = "Pending";
            this.lblTitle2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle2.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitle2.Location = new System.Drawing.Point(10, 48);
            this.lblTitle2.AutoSize = true;
            this.card2.Controls.Add(this.accent2);
            this.card2.Controls.Add(this.lblPendingCount);
            this.card2.Controls.Add(this.lblTitle2);

            // --- Card 3 (Issued) ---
            this.card3.BackColor = System.Drawing.Color.White;
            this.card3.Location = new System.Drawing.Point(325, 50);
            this.card3.Size = new System.Drawing.Size(140, 80);
            this.accent3.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.accent3.Location = new System.Drawing.Point(0, 0);
            this.accent3.Size = new System.Drawing.Size(4, 80);
            this.lblCompletedCount.Text = "0";
            this.lblCompletedCount.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblCompletedCount.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblCompletedCount.Location = new System.Drawing.Point(10, 8);
            this.lblCompletedCount.AutoSize = true;
            this.lblTitle3.Text = "Issued";
            this.lblTitle3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle3.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitle3.Location = new System.Drawing.Point(10, 48);
            this.lblTitle3.AutoSize = true;
            this.card3.Controls.Add(this.accent3);
            this.card3.Controls.Add(this.lblCompletedCount);
            this.card3.Controls.Add(this.lblTitle3);

            // --- Card 4 (Notices) ---
            this.card4.BackColor = System.Drawing.Color.White;
            this.card4.Location = new System.Drawing.Point(480, 50);
            this.card4.Size = new System.Drawing.Size(140, 80);
            this.accent4.BackColor = System.Drawing.Color.FromArgb(147, 51, 234);
            this.accent4.Location = new System.Drawing.Point(0, 0);
            this.accent4.Size = new System.Drawing.Size(4, 80);
            this.lblAnnounceCount.Text = "0";
            this.lblAnnounceCount.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblAnnounceCount.ForeColor = System.Drawing.Color.FromArgb(147, 51, 234);
            this.lblAnnounceCount.Location = new System.Drawing.Point(10, 8);
            this.lblAnnounceCount.AutoSize = true;
            this.lblTitle4.Text = "Notices";
            this.lblTitle4.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle4.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitle4.Location = new System.Drawing.Point(10, 48);
            this.lblTitle4.AutoSize = true;
            this.card4.Controls.Add(this.accent4);
            this.card4.Controls.Add(this.lblAnnounceCount);
            this.card4.Controls.Add(this.lblTitle4);

            // --- Left Panel: Recent Requests ---
            this.pnlRequests.BackColor = System.Drawing.Color.White;
            this.pnlRequests.Location = new System.Drawing.Point(15, 145);
            this.pnlRequests.Size = new System.Drawing.Size(375, 350);

            this.lblReqHeader.Text = "Recent Document Requests";
            this.lblReqHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblReqHeader.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblReqHeader.Location = new System.Drawing.Point(12, 12);
            this.lblReqHeader.AutoSize = true;

            // Row 1
            this.row1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.row1.Location = new System.Drawing.Point(15, 45);
            this.row1.Size = new System.Drawing.Size(345, 75);
            this.lblReq1Title.Text = "Barangay Clearance";
            this.lblReq1Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReq1Title.Location = new System.Drawing.Point(10, 10);
            this.lblReq1Title.Size = new System.Drawing.Size(220, 20);
            this.lblReq1Sub.Text = "Juan Dela Cruz • Sep 26, 2026";
            this.lblReq1Sub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblReq1Sub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblReq1Sub.Location = new System.Drawing.Point(10, 36);
            this.lblReq1Sub.Size = new System.Drawing.Size(220, 20);
            this.lblReq1Status.Text = "Pending";
            this.lblReq1Status.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblReq1Status.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblReq1Status.BackColor = System.Drawing.Color.FromArgb(254, 243, 199);
            this.lblReq1Status.Location = new System.Drawing.Point(255, 15);
            this.lblReq1Status.Size = new System.Drawing.Size(80, 24);
            this.lblReq1Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.row1.Controls.Add(this.lblReq1Title);
            this.row1.Controls.Add(this.lblReq1Sub);
            this.row1.Controls.Add(this.lblReq1Status);

            // Row 2
            this.row2.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.row2.Location = new System.Drawing.Point(15, 130);
            this.row2.Size = new System.Drawing.Size(345, 75);
            this.lblReq2Title.Text = "Indigency Certificate";
            this.lblReq2Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReq2Title.Location = new System.Drawing.Point(10, 10);
            this.lblReq2Title.Size = new System.Drawing.Size(220, 20);
            this.lblReq2Sub.Text = "Maria Clara • Sep 26, 2026";
            this.lblReq2Sub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblReq2Sub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblReq2Sub.Location = new System.Drawing.Point(10, 36);
            this.lblReq2Sub.Size = new System.Drawing.Size(220, 20);
            this.lblReq2Status.Text = "Pending";
            this.lblReq2Status.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblReq2Status.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblReq2Status.BackColor = System.Drawing.Color.FromArgb(254, 243, 199);
            this.lblReq2Status.Location = new System.Drawing.Point(255, 15);
            this.lblReq2Status.Size = new System.Drawing.Size(80, 24);
            this.lblReq2Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.row2.Controls.Add(this.lblReq2Title);
            this.row2.Controls.Add(this.lblReq2Sub);
            this.row2.Controls.Add(this.lblReq2Status);

            // Row 3
            this.row3.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.row3.Location = new System.Drawing.Point(15, 215);
            this.row3.Size = new System.Drawing.Size(345, 75);
            this.lblReq3Title.Text = "Residency Certificate";
            this.lblReq3Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReq3Title.Location = new System.Drawing.Point(10, 10);
            this.lblReq3Title.Size = new System.Drawing.Size(220, 20);
            this.lblReq3Sub.Text = "Jose Rizal • Sep 25, 2026";
            this.lblReq3Sub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblReq3Sub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblReq3Sub.Location = new System.Drawing.Point(10, 36);
            this.lblReq3Sub.Size = new System.Drawing.Size(220, 20);
            this.lblReq3Status.Text = "Approved";
            this.lblReq3Status.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblReq3Status.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblReq3Status.BackColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblReq3Status.Location = new System.Drawing.Point(255, 15);
            this.lblReq3Status.Size = new System.Drawing.Size(80, 24);
            this.lblReq3Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.row3.Controls.Add(this.lblReq3Title);
            this.row3.Controls.Add(this.lblReq3Sub);
            this.row3.Controls.Add(this.lblReq3Status);

            this.pnlRequests.Controls.Add(this.lblReqHeader);
            this.pnlRequests.Controls.Add(this.row1);
            this.pnlRequests.Controls.Add(this.row2);
            this.pnlRequests.Controls.Add(this.row3);

            // --- Right Panel: Info / Status ---
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(405, 145);
            this.pnlInfo.Size = new System.Drawing.Size(215, 350);

            this.lblInfoHeader.Text = "System Status";
            this.lblInfoHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblInfoHeader.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblInfoHeader.Location = new System.Drawing.Point(12, 12);
            this.lblInfoHeader.AutoSize = true;

            this.lblInfoBody.Text = "• Barangay Document System\n\n• Database: ACTIVE\n\n• Auto-Sync: ENABLED\n\n• Live resident registrations and incoming request updates.";
            this.lblInfoBody.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblInfoBody.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblInfoBody.Location = new System.Drawing.Point(12, 45);
            this.lblInfoBody.Size = new System.Drawing.Size(185, 280);

            this.pnlInfo.Controls.Add(this.lblInfoHeader);
            this.pnlInfo.Controls.Add(this.lblInfoBody);

            // Add all main components
            this.Controls.Add(this.lblHeaderTitle);
            this.Controls.Add(this.lblHeaderDate);
            this.Controls.Add(this.card1);
            this.Controls.Add(this.card2);
            this.Controls.Add(this.card3);
            this.Controls.Add(this.card4);
            this.Controls.Add(this.pnlRequests);
            this.Controls.Add(this.pnlInfo);

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
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderDate;

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