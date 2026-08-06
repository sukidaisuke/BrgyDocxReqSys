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
            logoPicBox = new PictureBox();
            SettingButton = new Button();
            ReportButton = new Button();
            DocumentReqButton = new Button();
            ResidentButton = new Button();
            DashboardButton = new Button();
            label12 = new Label();
            PanelContainer = new Panel();
            LabelDashboard = new Label();
            NavPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicBox).BeginInit();
            PanelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // NavPanel
            // 
            NavPanel.BackColor = Color.FromArgb(12, 45, 93);
            NavPanel.Controls.Add(logoPicBox);
            NavPanel.Controls.Add(SettingButton);
            NavPanel.Controls.Add(ReportButton);
            NavPanel.Controls.Add(DocumentReqButton);
            NavPanel.Controls.Add(ResidentButton);
            NavPanel.Controls.Add(DashboardButton);
            NavPanel.Controls.Add(label12);
            NavPanel.Dock = DockStyle.Left;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(209, 511);
            NavPanel.TabIndex = 19;
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
            // SettingButton
            // 
            SettingButton.FlatAppearance.BorderSize = 0;
            SettingButton.FlatStyle = FlatStyle.Flat;
            SettingButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SettingButton.ForeColor = Color.White;
            SettingButton.Location = new Point(5, 310);
            SettingButton.Name = "SettingButton";
            SettingButton.Size = new Size(197, 53);
            SettingButton.TabIndex = 21;
            SettingButton.Text = "⚙️ Settings";
            SettingButton.UseVisualStyleBackColor = true;
            // 
            // ReportButton
            // 
            ReportButton.FlatAppearance.BorderSize = 0;
            ReportButton.FlatStyle = FlatStyle.Flat;
            ReportButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ReportButton.ForeColor = Color.White;
            ReportButton.Location = new Point(5, 255);
            ReportButton.Name = "ReportButton";
            ReportButton.Size = new Size(197, 53);
            ReportButton.TabIndex = 21;
            ReportButton.Text = "📊 Reports";
            ReportButton.UseVisualStyleBackColor = true;
            // 
            // DocumentReqButton
            // 
            DocumentReqButton.BackColor = Color.FromArgb(12, 45, 93);
            DocumentReqButton.FlatAppearance.BorderSize = 0;
            DocumentReqButton.FlatStyle = FlatStyle.Flat;
            DocumentReqButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DocumentReqButton.ForeColor = Color.White;
            DocumentReqButton.Location = new Point(5, 200);
            DocumentReqButton.Name = "DocumentReqButton";
            DocumentReqButton.Size = new Size(197, 53);
            DocumentReqButton.TabIndex = 21;
            DocumentReqButton.Text = "📄 Document\n       Request";
            DocumentReqButton.UseVisualStyleBackColor = false;
            DocumentReqButton.Click += DocumentReqButton_Click;
            // 
            // ResidentButton
            // 
            ResidentButton.FlatAppearance.BorderSize = 0;
            ResidentButton.FlatStyle = FlatStyle.Flat;
            ResidentButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ResidentButton.ForeColor = Color.White;
            ResidentButton.Location = new Point(5, 144);
            ResidentButton.Name = "ResidentButton";
            ResidentButton.Size = new Size(197, 54);
            ResidentButton.TabIndex = 21;
            ResidentButton.Text = "👤 Residents";
            ResidentButton.UseVisualStyleBackColor = true;
            ResidentButton.Click += ResidentButton_Click;
            // 
            // DashboardButton
            // 
            DashboardButton.BackColor = Color.FromArgb(12, 45, 93);
            DashboardButton.FlatAppearance.BorderSize = 0;
            DashboardButton.FlatStyle = FlatStyle.Flat;
            DashboardButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DashboardButton.ForeColor = Color.White;
            DashboardButton.Location = new Point(5, 87);
            DashboardButton.Name = "DashboardButton";
            DashboardButton.Size = new Size(197, 53);
            DashboardButton.TabIndex = 21;
            DashboardButton.Text = "🏠 Dashboard";
            DashboardButton.UseVisualStyleBackColor = false;
            DashboardButton.Click += DashboardButton_Click;
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
            PanelContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelContainer.Controls.Add(LabelDashboard);
            PanelContainer.Location = new Point(208, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(626, 511);
            PanelContainer.TabIndex = 20;
            // 
            // LabelDashboard
            // 
            LabelDashboard.Anchor = AnchorStyles.None;
            LabelDashboard.AutoSize = true;
            LabelDashboard.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            LabelDashboard.Location = new Point(126, 180);
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
            ((System.ComponentModel.ISupportInitialize)logoPicBox).EndInit();
            PanelContainer.ResumeLayout(false);
            PanelContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel NavPanel;
        private Button SettingButton;
        private Button ReportButton;
        private Button DocumentReqButton;
        private Button ResidentButton;
        private Button DashboardButton;
        private Label label12;
        private Panel PanelContainer;
        private PictureBox logoPicBox;
        private Label LabelDashboard;
    }
}