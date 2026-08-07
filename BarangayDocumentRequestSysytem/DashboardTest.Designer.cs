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
            navTLP = new TableLayoutPanel();
            SettingButton = new Button();
            activityButton = new Button();
            DashboardButton = new Button();
            ReportButton = new Button();
            DocumentReqButton = new Button();
            ResidentButton = new Button();
            logoPicBox = new PictureBox();
            label12 = new Label();
            PanelContainer = new Panel();
            LabelDashboard = new Label();
            NavPanel.SuspendLayout();
            navTLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicBox).BeginInit();
            PanelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // NavPanel
            // 
            NavPanel.BackColor = Color.FromArgb(12, 45, 93);
            NavPanel.Controls.Add(navTLP);
            NavPanel.Controls.Add(logoPicBox);
            NavPanel.Controls.Add(label12);
            NavPanel.Dock = DockStyle.Left;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(209, 511);
            NavPanel.TabIndex = 19;
            // 
            // navTLP
            // 
            navTLP.Anchor = AnchorStyles.None;
            navTLP.ColumnCount = 1;
            navTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            navTLP.Controls.Add(SettingButton, 0, 5);
            navTLP.Controls.Add(activityButton, 0, 4);
            navTLP.Controls.Add(DashboardButton, 0, 0);
            navTLP.Controls.Add(ReportButton, 0, 3);
            navTLP.Controls.Add(DocumentReqButton, 0, 2);
            navTLP.Controls.Add(ResidentButton, 0, 1);
            navTLP.Location = new Point(31, 90);
            navTLP.Name = "navTLP";
            navTLP.RowCount = 6;
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.Size = new Size(172, 363);
            navTLP.TabIndex = 24;
            // 
            // SettingButton
            // 
            SettingButton.Dock = DockStyle.Fill;
            SettingButton.FlatAppearance.BorderSize = 0;
            SettingButton.FlatStyle = FlatStyle.Flat;
            SettingButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SettingButton.ForeColor = Color.White;
            SettingButton.Location = new Point(3, 303);
            SettingButton.Name = "SettingButton";
            SettingButton.Size = new Size(166, 57);
            SettingButton.TabIndex = 23;
            SettingButton.Text = "⚙️ Settings";
            SettingButton.TextAlign = ContentAlignment.MiddleLeft;
            SettingButton.UseVisualStyleBackColor = true;
            SettingButton.Click += SettingButton_Click;
            // 
            // activityButton
            // 
            activityButton.Dock = DockStyle.Fill;
            activityButton.FlatAppearance.BorderSize = 0;
            activityButton.FlatStyle = FlatStyle.Flat;
            activityButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            activityButton.ForeColor = Color.White;
            activityButton.Location = new Point(3, 243);
            activityButton.Name = "activityButton";
            activityButton.Size = new Size(166, 54);
            activityButton.TabIndex = 21;
            activityButton.Text = "📁 Activity Log";
            activityButton.TextAlign = ContentAlignment.MiddleLeft;
            activityButton.UseVisualStyleBackColor = true;
            // 
            // DashboardButton
            // 
            DashboardButton.BackColor = Color.FromArgb(12, 45, 93);
            DashboardButton.Dock = DockStyle.Fill;
            DashboardButton.FlatAppearance.BorderSize = 0;
            DashboardButton.FlatStyle = FlatStyle.Flat;
            DashboardButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DashboardButton.ForeColor = Color.White;
            DashboardButton.Location = new Point(3, 3);
            DashboardButton.Name = "DashboardButton";
            DashboardButton.Size = new Size(166, 54);
            DashboardButton.TabIndex = 21;
            DashboardButton.Text = "🏠 Dashboard";
            DashboardButton.TextAlign = ContentAlignment.MiddleLeft;
            DashboardButton.UseVisualStyleBackColor = false;
            DashboardButton.Click += DashboardButton_Click;
            // 
            // ReportButton
            // 
            ReportButton.Dock = DockStyle.Fill;
            ReportButton.FlatAppearance.BorderSize = 0;
            ReportButton.FlatStyle = FlatStyle.Flat;
            ReportButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ReportButton.ForeColor = Color.White;
            ReportButton.Location = new Point(3, 183);
            ReportButton.Name = "ReportButton";
            ReportButton.Size = new Size(166, 54);
            ReportButton.TabIndex = 21;
            ReportButton.Text = "📊 Reports";
            ReportButton.TextAlign = ContentAlignment.MiddleLeft;
            ReportButton.UseVisualStyleBackColor = true;
            ReportButton.Click += ReportButton_Click;
            // 
            // DocumentReqButton
            // 
            DocumentReqButton.BackColor = Color.FromArgb(12, 45, 93);
            DocumentReqButton.Dock = DockStyle.Fill;
            DocumentReqButton.FlatAppearance.BorderSize = 0;
            DocumentReqButton.FlatStyle = FlatStyle.Flat;
            DocumentReqButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DocumentReqButton.ForeColor = Color.White;
            DocumentReqButton.Location = new Point(3, 123);
            DocumentReqButton.Name = "DocumentReqButton";
            DocumentReqButton.Size = new Size(166, 54);
            DocumentReqButton.TabIndex = 21;
            DocumentReqButton.Text = "📄 Document\n       Request";
            DocumentReqButton.TextAlign = ContentAlignment.MiddleLeft;
            DocumentReqButton.UseVisualStyleBackColor = false;
            DocumentReqButton.Click += DocumentReqButton_Click;
            // 
            // ResidentButton
            // 
            ResidentButton.Dock = DockStyle.Fill;
            ResidentButton.FlatAppearance.BorderSize = 0;
            ResidentButton.FlatStyle = FlatStyle.Flat;
            ResidentButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ResidentButton.ForeColor = Color.White;
            ResidentButton.Location = new Point(3, 63);
            ResidentButton.Name = "ResidentButton";
            ResidentButton.Size = new Size(166, 54);
            ResidentButton.TabIndex = 21;
            ResidentButton.Text = "👤 Residents";
            ResidentButton.TextAlign = ContentAlignment.MiddleLeft;
            ResidentButton.UseVisualStyleBackColor = true;
            ResidentButton.Click += ResidentButton_Click;
            // 
            // logoPicBox
            // 
            logoPicBox.BackColor = Color.FromArgb(12, 45, 93);
            logoPicBox.Image = (Image)resources.GetObject("logoPicBox.Image");
            logoPicBox.InitialImage = (Image)resources.GetObject("logoPicBox.InitialImage");
            logoPicBox.Location = new Point(0, -2);
            logoPicBox.Name = "logoPicBox";
            logoPicBox.Size = new Size(209, 72);
            logoPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPicBox.TabIndex = 22;
            logoPicBox.TabStop = false;
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
            navTLP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPicBox).EndInit();
            PanelContainer.ResumeLayout(false);
            PanelContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel NavPanel;
        private Button activityButton;
        private Button ReportButton;
        private Button DocumentReqButton;
        private Button ResidentButton;
        private Button DashboardButton;
        private Label label12;
        private Panel PanelContainer;
        private PictureBox logoPicBox;
        private Label LabelDashboard;
        private Button SettingButton;
        private TableLayoutPanel navTLP;
    }
}