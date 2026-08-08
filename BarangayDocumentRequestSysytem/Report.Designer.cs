namespace BarangayDocumentRequestSysytem
{
    partial class Report
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
            panel1 = new Panel();
            NavPanel = new Panel();
            DocumentReqTitleLabel = new Label();
            nameLabel = new Label();
            panel1.SuspendLayout();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(NavPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(635, 512);
            panel1.TabIndex = 0;
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
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.Anchor = AnchorStyles.Left;
            DocumentReqTitleLabel.AutoSize = true;
            DocumentReqTitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DocumentReqTitleLabel.ForeColor = Color.White;
            DocumentReqTitleLabel.Location = new Point(66, 34);
            DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            DocumentReqTitleLabel.Size = new Size(89, 30);
            DocumentReqTitleLabel.TabIndex = 27;
            DocumentReqTitleLabel.Text = "Reports";
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
            nameLabel.TabIndex = 30;
            nameLabel.Text = "Barangay Document Request System";
            // 
            // Report
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "Report";
            Size = new Size(635, 512);
            panel1.ResumeLayout(false);
            NavPanel.ResumeLayout(false);
            NavPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel NavPanel;
        private Label nameLabel;
        private Label DocumentReqTitleLabel;
    }
}
