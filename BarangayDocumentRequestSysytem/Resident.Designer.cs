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
            nameLabel = new Label();
            AddResidentButton = new Button();
            DocumentReqTitleLabel = new Label();
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
            NavPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NavPanel.BackColor = Color.DarkSlateBlue;
            NavPanel.Controls.Add(nameLabel);
            NavPanel.Controls.Add(AddResidentButton);
            NavPanel.Controls.Add(DocumentReqTitleLabel);
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(635, 100);
            NavPanel.TabIndex = 28;
            NavPanel.Paint += NavPanel_Paint;
            // 
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.Right;
            nameLabel.AutoSize = true;
            nameLabel.BackColor = Color.DarkSlateBlue;
            nameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.ForeColor = Color.DarkGray;
            nameLabel.Location = new Point(408, 11);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(213, 15);
            nameLabel.TabIndex = 28;
            nameLabel.Text = "Barangay Document Request System";
            nameLabel.Click += nameLabel_Click;
            // 
            // AddResidentButton
            // 
            AddResidentButton.Anchor = AnchorStyles.Right;
            AddResidentButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddResidentButton.Location = new Point(473, 38);
            AddResidentButton.Name = "AddResidentButton";
            AddResidentButton.Size = new Size(119, 33);
            AddResidentButton.TabIndex = 28;
            AddResidentButton.Text = "➕ Add Resident";
            AddResidentButton.UseVisualStyleBackColor = true;
            AddResidentButton.Click += AddResidentButton_Click;
            // 
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.Anchor = AnchorStyles.Left;
            DocumentReqTitleLabel.AutoSize = true;
            DocumentReqTitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DocumentReqTitleLabel.ForeColor = Color.White;
            DocumentReqTitleLabel.Location = new Point(66, 35);
            DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            DocumentReqTitleLabel.Size = new Size(106, 30);
            DocumentReqTitleLabel.TabIndex = 27;
            DocumentReqTitleLabel.Text = "Residents";
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
        private Label nameLabel;
    }
}
