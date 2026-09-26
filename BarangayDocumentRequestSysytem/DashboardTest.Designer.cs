namespace BarangayDocumentRequestSysytem
{
    partial class DashboardTest
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardTest));
            NavPanel = new Panel();
            panel1 = new Panel();
            navTLP = new TableLayoutPanel();
            btnLogout = new Button();
            btnSetting = new Button();
            btnHome = new Button();
            btnReport = new Button();
            btnPendingRequests = new Button();
            btnResident = new Button();
            logoPicBox = new PictureBox();
            label1 = new Label();
            label12 = new Label();
            PanelContainer = new Panel();
            LabelDashboard = new Label();
            NavPanel.SuspendLayout();
            panel1.SuspendLayout();
            navTLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicBox).BeginInit();
            PanelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // NavPanel
            // 
            NavPanel.BackColor = Color.FromArgb(12, 45, 93);
            NavPanel.Controls.Add(panel1);
            NavPanel.Controls.Add(label12);
            NavPanel.Dock = DockStyle.Left;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(209, 511);
            NavPanel.TabIndex = 19;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(12, 45, 93);
            panel1.Controls.Add(navTLP);
            panel1.Controls.Add(logoPicBox);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(209, 511);
            panel1.TabIndex = 21;
            // 
            // navTLP
            // 
            navTLP.Anchor = AnchorStyles.None;
            navTLP.ColumnCount = 1;
            navTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            navTLP.Controls.Add(btnLogout, 0, 5);
            navTLP.Controls.Add(btnSetting, 0, 4);
            navTLP.Controls.Add(btnHome, 0, 0);
            navTLP.Controls.Add(btnReport, 0, 3);
            navTLP.Controls.Add(btnPendingRequests, 0, 2);
            navTLP.Controls.Add(btnResident, 0, 1);
            navTLP.Location = new Point(0, 76);
            navTLP.Name = "navTLP";
            navTLP.RowCount = 6;
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.Size = new Size(209, 374);
            navTLP.TabIndex = 24;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Fill;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(3, 303);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Size = new Size(203, 68);
            btnLogout.TabIndex = 23;
            btnLogout.Text = "🚪  Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnSetting
            // 
            btnSetting.Dock = DockStyle.Fill;
            btnSetting.FlatAppearance.BorderSize = 0;
            btnSetting.FlatStyle = FlatStyle.Flat;
            btnSetting.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSetting.ForeColor = Color.White;
            btnSetting.Location = new Point(3, 243);
            btnSetting.Name = "btnSetting";
            btnSetting.Padding = new Padding(20, 0, 0, 0);
            btnSetting.Size = new Size(203, 54);
            btnSetting.TabIndex = 21;
            btnSetting.Text = "⚙️ Settings";
            btnSetting.TextAlign = ContentAlignment.MiddleLeft;
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += btnSetting_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(12, 45, 93);
            btnHome.Dock = DockStyle.Fill;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(3, 3);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(20, 0, 0, 0);
            btnHome.Size = new Size(203, 54);
            btnHome.TabIndex = 21;
            btnHome.Text = "🏠 Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // btnReport
            // 
            btnReport.Dock = DockStyle.Fill;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(3, 183);
            btnReport.Name = "btnReport";
            btnReport.Padding = new Padding(20, 0, 0, 0);
            btnReport.Size = new Size(203, 54);
            btnReport.TabIndex = 21;
            btnReport.Text = "📊 Reports";
            btnReport.TextAlign = ContentAlignment.MiddleLeft;
            btnReport.UseVisualStyleBackColor = true;
            // 
            // btnPendingRequests
            // 
            btnPendingRequests.BackColor = Color.FromArgb(12, 45, 93);
            btnPendingRequests.Dock = DockStyle.Fill;
            btnPendingRequests.FlatAppearance.BorderSize = 0;
            btnPendingRequests.FlatStyle = FlatStyle.Flat;
            btnPendingRequests.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPendingRequests.ForeColor = Color.White;
            btnPendingRequests.Location = new Point(3, 123);
            btnPendingRequests.Name = "btnPendingRequests";
            btnPendingRequests.Padding = new Padding(20, 0, 0, 0);
            btnPendingRequests.Size = new Size(203, 54);
            btnPendingRequests.TabIndex = 21;
            btnPendingRequests.Text = "🕒 Pending Request";
            btnPendingRequests.TextAlign = ContentAlignment.MiddleLeft;
            btnPendingRequests.UseVisualStyleBackColor = false;
            btnPendingRequests.Click += btnPendingRequests_Click;
            // 
            // btnResident
            // 
            btnResident.Dock = DockStyle.Fill;
            btnResident.FlatAppearance.BorderSize = 0;
            btnResident.FlatStyle = FlatStyle.Flat;
            btnResident.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResident.ForeColor = Color.White;
            btnResident.Location = new Point(3, 63);
            btnResident.Name = "btnResident";
            btnResident.Padding = new Padding(20, 0, 0, 0);
            btnResident.Size = new Size(203, 54);
            btnResident.TabIndex = 21;
            btnResident.Text = "👤 Residents";
            btnResident.TextAlign = ContentAlignment.MiddleLeft;
            btnResident.UseVisualStyleBackColor = true;
            btnResident.Click += btnResident_Click;
            // 
            // logoPicBox
            // 
            logoPicBox.BackColor = Color.FromArgb(12, 45, 93);
            logoPicBox.Image = (Image)resources.GetObject("logoPicBox.Image");
            logoPicBox.InitialImage = (Image)resources.GetObject("logoPicBox.InitialImage");
            logoPicBox.Location = new Point(3, 3);
            logoPicBox.Name = "logoPicBox";
            logoPicBox.Size = new Size(155, 52);
            logoPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPicBox.TabIndex = 22;
            logoPicBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(31, 180);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 2;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(31, 180);
            label12.Name = "label12";
            label12.Size = new Size(0, 20);
            label12.TabIndex = 2;
            // 
            // PanelContainer
            // 
            PanelContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanelContainer.Controls.Add(LabelDashboard);
            PanelContainer.Location = new Point(209, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(625, 511);
            PanelContainer.TabIndex = 20;
            // 
            // LabelDashboard
            // 
            LabelDashboard.Anchor = AnchorStyles.None;
            LabelDashboard.AutoSize = true;
            LabelDashboard.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            LabelDashboard.Location = new Point(125, 180);
            LabelDashboard.Name = "LabelDashboard";
            LabelDashboard.Size = new Size(443, 86);
            LabelDashboard.TabIndex = 0;
            LabelDashboard.Text = "One La Union";
            // 
            // DashboardTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 511);
            Controls.Add(NavPanel);
            Controls.Add(PanelContainer);
            Name = "DashboardTest";
            Text = "DashboardTest";
            NavPanel.ResumeLayout(false);
            NavPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            navTLP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPicBox).EndInit();
            PanelContainer.ResumeLayout(false);
            PanelContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel NavPanel;
        private Label label12;
        private Panel PanelContainer;
        private Label LabelDashboard;
        private Panel panel1;
        private TableLayoutPanel navTLP;
        private Button btnLogout;
        private Button btnSetting;
        private Button btnHome;
        private Button btnReport;
        private Button btnPendingRequests;
        private Button btnResident;
        private PictureBox logoPicBox;
        private Label label1;
    }
}