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
            panel2 = new Panel();
            SettingButton = new Button();
            ReportButton = new Button();
            DocumentReqButton = new Button();
            ResidentButton = new Button();
            DashboardButton = new Button();
            label12 = new Label();
            PanelContainer = new Panel();
            LabelDashboard = new Label();
            panel2.SuspendLayout();
            PanelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top;
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(SettingButton);
            panel2.Controls.Add(ReportButton);
            panel2.Controls.Add(DocumentReqButton);
            panel2.Controls.Add(ResidentButton);
            panel2.Controls.Add(DashboardButton);
            panel2.Controls.Add(label12);
            panel2.Location = new Point(1, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(197, 512);
            panel2.TabIndex = 19;
            // 
            // SettingButton
            // 
            SettingButton.FlatAppearance.BorderSize = 0;
            SettingButton.FlatStyle = FlatStyle.Flat;
            SettingButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SettingButton.ForeColor = Color.White;
            SettingButton.Location = new Point(0, 310);
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
            ReportButton.Location = new Point(0, 255);
            ReportButton.Name = "ReportButton";
            ReportButton.Size = new Size(197, 53);
            ReportButton.TabIndex = 21;
            ReportButton.Text = "📊 Reports";
            ReportButton.UseVisualStyleBackColor = true;
            // 
            // DocumentReqButton
            // 
            DocumentReqButton.BackColor = Color.FromArgb(0, 0, 68);
            DocumentReqButton.FlatAppearance.BorderSize = 0;
            DocumentReqButton.FlatStyle = FlatStyle.Flat;
            DocumentReqButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DocumentReqButton.ForeColor = Color.White;
            DocumentReqButton.Location = new Point(0, 200);
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
            ResidentButton.Location = new Point(0, 144);
            ResidentButton.Name = "ResidentButton";
            ResidentButton.Size = new Size(197, 54);
            ResidentButton.TabIndex = 21;
            ResidentButton.Text = "👤 Residents";
            ResidentButton.UseVisualStyleBackColor = true;
            // 
            // DashboardButton
            // 
            DashboardButton.BackColor = Color.FromArgb(0, 0, 64);
            DashboardButton.FlatAppearance.BorderSize = 0;
            DashboardButton.FlatStyle = FlatStyle.Flat;
            DashboardButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DashboardButton.ForeColor = Color.White;
            DashboardButton.Location = new Point(0, 87);
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
            PanelContainer.Controls.Add(LabelDashboard);
            PanelContainer.Location = new Point(200, 2);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(635, 512);
            PanelContainer.TabIndex = 20;
            // 
            // LabelDashboard
            // 
            LabelDashboard.AutoSize = true;
            LabelDashboard.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            LabelDashboard.Location = new Point(98, 180);
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
            Controls.Add(panel2);
            Controls.Add(PanelContainer);
            Name = "DashboardTest";
            Text = "DashboardTest";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            PanelContainer.ResumeLayout(false);
            PanelContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Button SettingButton;
        private Button ReportButton;
        private Button DocumentReqButton;
        private Button ResidentButton;
        private Button DashboardButton;
        private Label label12;
        private Panel PanelContainer;
        private Label LabelDashboard;
    }
}