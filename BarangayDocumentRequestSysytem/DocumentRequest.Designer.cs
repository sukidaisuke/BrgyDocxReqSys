namespace BarangayDocumentRequestSysytem
{
    partial class DocumentRequest
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
            BodyGroupBox = new GroupBox();
            DateReqLabel = new Label();
            DateReqDateTimePicker = new DateTimePicker();
            ResidentLabel = new Label();
            DocumentTypeLabel = new Label();
            PurposeLabel = new Label();
            ResidentComboBox = new ComboBox();
            DocumentTypeComboBox = new ComboBox();
            PurposeTextBox = new TextBox();
            NewReqSubTitleLabel = new Label();
            CancelButton = new Button();
            SubmitReqButton = new Button();
            DocumentReqTitleLabel = new Label();
            ReqInformationHeaderLabel = new Label();
            PanelContainer = new Panel();
            NavPanel = new Panel();
            BodyGroupBox.SuspendLayout();
            PanelContainer.SuspendLayout();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // BodyGroupBox
            // 
            BodyGroupBox.Controls.Add(DateReqLabel);
            BodyGroupBox.Controls.Add(DateReqDateTimePicker);
            BodyGroupBox.Controls.Add(ResidentLabel);
            BodyGroupBox.Controls.Add(DocumentTypeLabel);
            BodyGroupBox.Controls.Add(PurposeLabel);
            BodyGroupBox.Controls.Add(ResidentComboBox);
            BodyGroupBox.Controls.Add(DocumentTypeComboBox);
            BodyGroupBox.Controls.Add(PurposeTextBox);
            BodyGroupBox.Location = new Point(84, 131);
            BodyGroupBox.Name = "BodyGroupBox";
            BodyGroupBox.Size = new Size(455, 294);
            BodyGroupBox.TabIndex = 21;
            BodyGroupBox.TabStop = false;
            // 
            // DateReqLabel
            // 
            DateReqLabel.Anchor = AnchorStyles.Top;
            DateReqLabel.AutoSize = true;
            DateReqLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DateReqLabel.Location = new Point(17, 247);
            DateReqLabel.Name = "DateReqLabel";
            DateReqLabel.Size = new Size(103, 15);
            DateReqLabel.TabIndex = 12;
            DateReqLabel.Text = "Date Requested :";
            // 
            // DateReqDateTimePicker
            // 
            DateReqDateTimePicker.Anchor = AnchorStyles.Top;
            DateReqDateTimePicker.Location = new Point(130, 247);
            DateReqDateTimePicker.Name = "DateReqDateTimePicker";
            DateReqDateTimePicker.Size = new Size(307, 23);
            DateReqDateTimePicker.TabIndex = 13;
            // 
            // ResidentLabel
            // 
            ResidentLabel.Anchor = AnchorStyles.Top;
            ResidentLabel.AutoSize = true;
            ResidentLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ResidentLabel.Location = new Point(17, 33);
            ResidentLabel.Name = "ResidentLabel";
            ResidentLabel.Size = new Size(62, 15);
            ResidentLabel.TabIndex = 1;
            ResidentLabel.Text = "Resident :";
            // 
            // DocumentTypeLabel
            // 
            DocumentTypeLabel.Anchor = AnchorStyles.Top;
            DocumentTypeLabel.AutoSize = true;
            DocumentTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DocumentTypeLabel.Location = new Point(17, 77);
            DocumentTypeLabel.Name = "DocumentTypeLabel";
            DocumentTypeLabel.Size = new Size(101, 15);
            DocumentTypeLabel.TabIndex = 2;
            DocumentTypeLabel.Text = "Document Type :";
            // 
            // PurposeLabel
            // 
            PurposeLabel.Anchor = AnchorStyles.Top;
            PurposeLabel.AutoSize = true;
            PurposeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PurposeLabel.Location = new Point(17, 137);
            PurposeLabel.Name = "PurposeLabel";
            PurposeLabel.Size = new Size(58, 15);
            PurposeLabel.TabIndex = 3;
            PurposeLabel.Text = "Purpose :";
            // 
            // ResidentComboBox
            // 
            ResidentComboBox.Anchor = AnchorStyles.Top;
            ResidentComboBox.FormattingEnabled = true;
            ResidentComboBox.Location = new Point(130, 33);
            ResidentComboBox.Name = "ResidentComboBox";
            ResidentComboBox.Size = new Size(306, 23);
            ResidentComboBox.TabIndex = 8;
            // 
            // DocumentTypeComboBox
            // 
            DocumentTypeComboBox.Anchor = AnchorStyles.Top;
            DocumentTypeComboBox.FormattingEnabled = true;
            DocumentTypeComboBox.Location = new Point(131, 77);
            DocumentTypeComboBox.Name = "DocumentTypeComboBox";
            DocumentTypeComboBox.Size = new Size(306, 23);
            DocumentTypeComboBox.TabIndex = 9;
            // 
            // PurposeTextBox
            // 
            PurposeTextBox.Anchor = AnchorStyles.Top;
            PurposeTextBox.BorderStyle = BorderStyle.FixedSingle;
            PurposeTextBox.Location = new Point(130, 135);
            PurposeTextBox.Multiline = true;
            PurposeTextBox.Name = "PurposeTextBox";
            PurposeTextBox.Size = new Size(306, 92);
            PurposeTextBox.TabIndex = 10;
            // 
            // NewReqSubTitleLabel
            // 
            NewReqSubTitleLabel.Anchor = AnchorStyles.Top;
            NewReqSubTitleLabel.AutoSize = true;
            NewReqSubTitleLabel.BackColor = Color.DarkSlateBlue;
            NewReqSubTitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            NewReqSubTitleLabel.ForeColor = Color.White;
            NewReqSubTitleLabel.Location = new Point(239, 35);
            NewReqSubTitleLabel.Name = "NewReqSubTitleLabel";
            NewReqSubTitleLabel.Size = new Size(142, 30);
            NewReqSubTitleLabel.TabIndex = 26;
            NewReqSubTitleLabel.Text = "New Request";
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Top;
            CancelButton.BackColor = Color.Red;
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelButton.ForeColor = Color.White;
            CancelButton.Location = new Point(335, 450);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(204, 39);
            CancelButton.TabIndex = 25;
            CancelButton.Text = "❌ Cancel";
            CancelButton.UseVisualStyleBackColor = false;
            // 
            // SubmitReqButton
            // 
            SubmitReqButton.Anchor = AnchorStyles.Top;
            SubmitReqButton.BackColor = Color.DarkSlateBlue;
            SubmitReqButton.FlatStyle = FlatStyle.Flat;
            SubmitReqButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SubmitReqButton.ForeColor = Color.White;
            SubmitReqButton.Location = new Point(84, 450);
            SubmitReqButton.Name = "SubmitReqButton";
            SubmitReqButton.Size = new Size(204, 39);
            SubmitReqButton.TabIndex = 24;
            SubmitReqButton.Text = "📄 Submit Request";
            SubmitReqButton.UseVisualStyleBackColor = false;
            // 
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.Anchor = AnchorStyles.Top;
            DocumentReqTitleLabel.AutoSize = true;
            DocumentReqTitleLabel.BackColor = Color.DarkSlateBlue;
            DocumentReqTitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            DocumentReqTitleLabel.ForeColor = Color.White;
            DocumentReqTitleLabel.Location = new Point(63, 35);
            DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            DocumentReqTitleLabel.Size = new Size(232, 30);
            DocumentReqTitleLabel.TabIndex = 23;
            DocumentReqTitleLabel.Text = "Document Request   >";
            // 
            // ReqInformationHeaderLabel
            // 
            ReqInformationHeaderLabel.Anchor = AnchorStyles.Top;
            ReqInformationHeaderLabel.AutoSize = true;
            ReqInformationHeaderLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ReqInformationHeaderLabel.Location = new Point(63, 109);
            ReqInformationHeaderLabel.Name = "ReqInformationHeaderLabel";
            ReqInformationHeaderLabel.Size = new Size(135, 17);
            ReqInformationHeaderLabel.TabIndex = 22;
            ReqInformationHeaderLabel.Text = "Request Information";
            // 
            // PanelContainer
            // 
            PanelContainer.Controls.Add(BodyGroupBox);
            PanelContainer.Controls.Add(ReqInformationHeaderLabel);
            PanelContainer.Controls.Add(CancelButton);
            PanelContainer.Controls.Add(SubmitReqButton);
            PanelContainer.Controls.Add(NavPanel);
            PanelContainer.Dock = DockStyle.Fill;
            PanelContainer.Location = new Point(0, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(635, 512);
            PanelContainer.TabIndex = 27;
            // 
            // NavPanel
            // 
            NavPanel.BackColor = Color.DarkSlateBlue;
            NavPanel.Controls.Add(DocumentReqTitleLabel);
            NavPanel.Controls.Add(NewReqSubTitleLabel);
            NavPanel.Dock = DockStyle.Top;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(635, 100);
            NavPanel.TabIndex = 27;
            // 
            // DocumentRequest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelContainer);
            Name = "DocumentRequest";
            Size = new Size(635, 512);
            BodyGroupBox.ResumeLayout(false);
            BodyGroupBox.PerformLayout();
            PanelContainer.ResumeLayout(false);
            PanelContainer.PerformLayout();
            NavPanel.ResumeLayout(false);
            NavPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox BodyGroupBox;
        private Label DateReqLabel;
        private DateTimePicker DateReqDateTimePicker;
        private Label ResidentLabel;
        private Label DocumentTypeLabel;
        private Label PurposeLabel;
        private ComboBox ResidentComboBox;
        private ComboBox DocumentTypeComboBox;
        private TextBox PurposeTextBox;
        private Label NewReqSubTitleLabel;
        private Button CancelButton;
        private Button SubmitReqButton;
        private Label DocumentReqTitleLabel;
        private Label ReqInformationHeaderLabel;
        private Panel PanelContainer;
        private Panel NavPanel;
    }
}
