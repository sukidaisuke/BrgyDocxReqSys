namespace BarangayDocumentRequestSysytem
{
    partial class About
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
            bodyGB = new GroupBox();
            mainCardPanel = new Panel();
            lblTitle = new Label();
            lblVersion = new Label();
            divider1 = new Panel();
            lblDevHeader = new Label();
            lblDevTeam = new Label();
            lblProgram = new Label();
            lblCampus = new Label();
            lblCopyright = new Label();
            bodyGB.SuspendLayout();
            mainCardPanel.SuspendLayout();
            SuspendLayout();
            // 
            // bodyGB
            // 
            bodyGB.Controls.Add(mainCardPanel);
            bodyGB.Dock = DockStyle.Fill;
            bodyGB.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            bodyGB.ForeColor = Color.FromArgb(30, 41, 59);
            bodyGB.Location = new Point(0, 0);
            bodyGB.Name = "bodyGB";
            bodyGB.Size = new Size(406, 403);
            bodyGB.TabIndex = 0;
            bodyGB.TabStop = false;
            bodyGB.Text = "System Information";
            // 
            // mainCardPanel
            // 
            mainCardPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainCardPanel.BackColor = Color.FromArgb(248, 250, 252);
            mainCardPanel.BorderStyle = BorderStyle.FixedSingle;
            mainCardPanel.Controls.Add(lblCopyright);
            mainCardPanel.Controls.Add(lblCampus);
            mainCardPanel.Controls.Add(lblProgram);
            mainCardPanel.Controls.Add(lblDevTeam);
            mainCardPanel.Controls.Add(lblDevHeader);
            mainCardPanel.Controls.Add(divider1);
            mainCardPanel.Controls.Add(lblVersion);
            mainCardPanel.Controls.Add(lblTitle);
            mainCardPanel.Location = new Point(16, 32);
            mainCardPanel.Name = "mainCardPanel";
            mainCardPanel.Size = new Size(374, 352);
            mainCardPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 20, 0, 0);
            lblTitle.Size = new Size(372, 55);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Barangay Document Request System";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblVersion
            // 
            lblVersion.Dock = DockStyle.Top;
            lblVersion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblVersion.ForeColor = Color.FromArgb(71, 85, 105);
            lblVersion.Location = new Point(0, 55);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(372, 25);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "Version 1.0.0";
            lblVersion.TextAlign = ContentAlignment.TopCenter;
            // 
            // divider1
            // 
            divider1.BackColor = Color.FromArgb(226, 232, 240);
            divider1.Location = new Point(30, 95);
            divider1.Name = "divider1";
            divider1.Size = new Size(314, 1);
            divider1.TabIndex = 2;
            // 
            // lblDevHeader
            // 
            lblDevHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDevHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblDevHeader.Location = new Point(12, 110);
            lblDevHeader.Name = "lblDevHeader";
            lblDevHeader.Size = new Size(348, 22);
            lblDevHeader.TabIndex = 3;
            lblDevHeader.Text = "DEVELOPED BY";
            lblDevHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDevTeam
            // 
            lblDevTeam.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblDevTeam.ForeColor = Color.FromArgb(30, 41, 59);
            lblDevTeam.Location = new Point(12, 135);
            lblDevTeam.Name = "lblDevTeam";
            lblDevTeam.Size = new Size(348, 26);
            lblDevTeam.TabIndex = 4;
            lblDevTeam.Text = "JOJI INC.";
            lblDevTeam.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblProgram
            // 
            lblProgram.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblProgram.ForeColor = Color.FromArgb(51, 65, 85);
            lblProgram.Location = new Point(12, 165);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(348, 24);
            lblProgram.TabIndex = 5;
            lblProgram.Text = "Bachelor of Science in Information Technology";
            lblProgram.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCampus
            // 
            lblCampus.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblCampus.ForeColor = Color.FromArgb(51, 65, 85);
            lblCampus.Location = new Point(12, 190);
            lblCampus.Name = "lblCampus";
            lblCampus.Size = new Size(348, 24);
            lblCampus.TabIndex = 6;
            lblCampus.Text = "DMMMSU Mid-La Union Campus";
            lblCampus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCopyright
            // 
            lblCopyright.Dock = DockStyle.Bottom;
            lblCopyright.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCopyright.ForeColor = Color.FromArgb(100, 116, 139);
            lblCopyright.Location = new Point(0, 310);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(372, 40);
            lblCopyright.TabIndex = 7;
            lblCopyright.Text = "© 2026 JOJI INC. All Rights Reserved.";
            lblCopyright.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bodyGB);
            Name = "About";
            Size = new Size(406, 403);
            bodyGB.ResumeLayout(false);
            mainCardPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox bodyGB;
        private Panel mainCardPanel;
        private Label lblTitle;
        private Label lblVersion;
        private Panel divider1;
        private Label lblDevHeader;
        private Label lblDevTeam;
        private Label lblProgram;
        private Label lblCampus;
        private Label lblCopyright;
    }
}