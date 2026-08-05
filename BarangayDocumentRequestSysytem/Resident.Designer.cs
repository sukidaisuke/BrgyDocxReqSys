namespace BarangayDocumentRequestSysytem
{
    partial class Resident
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
            PanelContainer = new Panel();
            NavPanel = new Panel();
            DocumentReqTitleLabel = new Label();
            AddResidentButton = new Button();
            PanelContainer.SuspendLayout();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContainer
            // 
            PanelContainer.BackgroundImageLayout = ImageLayout.None;
            PanelContainer.Controls.Add(NavPanel);
            PanelContainer.Dock = DockStyle.Fill;
            PanelContainer.Location = new Point(0, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(635, 512);
            PanelContainer.TabIndex = 0;
            // 
            // NavPanel
            // 
            NavPanel.BackColor = Color.DarkSlateBlue;
            NavPanel.Controls.Add(AddResidentButton);
            NavPanel.Controls.Add(DocumentReqTitleLabel);
            NavPanel.Dock = DockStyle.Top;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(635, 100);
            NavPanel.TabIndex = 28;
            // 
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.Anchor = AnchorStyles.Top;
            DocumentReqTitleLabel.AutoSize = true;
            DocumentReqTitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DocumentReqTitleLabel.ForeColor = Color.White;
            DocumentReqTitleLabel.Location = new Point(66, 35);
            DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            DocumentReqTitleLabel.Size = new Size(106, 30);
            DocumentReqTitleLabel.TabIndex = 27;
            DocumentReqTitleLabel.Text = "Residents";
            // 
            // AddResidentButton
            // 
            AddResidentButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddResidentButton.Location = new Point(468, 32);
            AddResidentButton.Name = "AddResidentButton";
            AddResidentButton.Size = new Size(119, 33);
            AddResidentButton.TabIndex = 28;
            AddResidentButton.Text = "➕ Add Resident";
            AddResidentButton.UseVisualStyleBackColor = true;
            AddResidentButton.Click += AddResidentButton_Click;
            // 
            // Resident
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelContainer);
            Name = "Resident";
            Size = new Size(635, 512);
            PanelContainer.ResumeLayout(false);
            NavPanel.ResumeLayout(false);
            NavPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContainer;
        private Label DocumentReqTitleLabel;
        private Panel NavPanel;
        private Button AddResidentButton;
    }
}
