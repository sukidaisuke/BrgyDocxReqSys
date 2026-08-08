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
            bodyTLP = new TableLayoutPanel();
            ResidentLabel = new Label();
            DateReqLabel = new Label();
            DateReqDateTimePicker = new DateTimePicker();
            DocumentTypeLabel = new Label();
            PurposeTextBox = new TextBox();
            DocumentTypeComboBox = new ComboBox();
            ResidentComboBox = new ComboBox();
            PurposeLabel = new Label();
            ReqInformationHeaderLabel = new Label();
            NewReqSubTitleLabel = new Label();
            CancelButton = new Button();
            SubmitReqButton = new Button();
            DocumentReqTitleLabel = new Label();
            PanelContainer = new Panel();
            buttonTLP = new TableLayoutPanel();
            NavPanel = new Panel();
            nameLabel = new Label();
            BodyGroupBox.SuspendLayout();
            bodyTLP.SuspendLayout();
            PanelContainer.SuspendLayout();
            buttonTLP.SuspendLayout();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // BodyGroupBox
            // 
            BodyGroupBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BodyGroupBox.Controls.Add(bodyTLP);
            BodyGroupBox.Controls.Add(ReqInformationHeaderLabel);
            BodyGroupBox.Location = new Point(77, 109);
            BodyGroupBox.Name = "BodyGroupBox";
            BodyGroupBox.Padding = new Padding(7);
            BodyGroupBox.Size = new Size(481, 326);
            BodyGroupBox.TabIndex = 21;
            BodyGroupBox.TabStop = false;
            // 
            // bodyTLP
            // 
            bodyTLP.ColumnCount = 2;
            bodyTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            bodyTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            bodyTLP.Controls.Add(ResidentLabel, 0, 0);
            bodyTLP.Controls.Add(DateReqLabel, 0, 3);
            bodyTLP.Controls.Add(DateReqDateTimePicker, 1, 3);
            bodyTLP.Controls.Add(DocumentTypeLabel, 0, 1);
            bodyTLP.Controls.Add(PurposeTextBox, 1, 2);
            bodyTLP.Controls.Add(DocumentTypeComboBox, 1, 1);
            bodyTLP.Controls.Add(ResidentComboBox, 1, 0);
            bodyTLP.Controls.Add(PurposeLabel, 0, 2);
            bodyTLP.Dock = DockStyle.Fill;
            bodyTLP.Location = new Point(7, 23);
            bodyTLP.Margin = new Padding(0);
            bodyTLP.Name = "bodyTLP";
            bodyTLP.Padding = new Padding(10);
            bodyTLP.RowCount = 4;
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 19.97301F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 19.97301F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 34.7503357F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 25.3036423F));
            bodyTLP.Size = new Size(467, 296);
            bodyTLP.TabIndex = 23;
            // 
            // ResidentLabel
            // 
            ResidentLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ResidentLabel.AutoSize = true;
            ResidentLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ResidentLabel.Location = new Point(13, 30);
            ResidentLabel.Name = "ResidentLabel";
            ResidentLabel.Size = new Size(128, 15);
            ResidentLabel.TabIndex = 1;
            ResidentLabel.Text = "Resident :";
            ResidentLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DateReqLabel
            // 
            DateReqLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DateReqLabel.AutoSize = true;
            DateReqLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DateReqLabel.Location = new Point(13, 243);
            DateReqLabel.Name = "DateReqLabel";
            DateReqLabel.Size = new Size(128, 15);
            DateReqLabel.TabIndex = 12;
            DateReqLabel.Text = "Date Requested :";
            DateReqLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DateReqDateTimePicker
            // 
            DateReqDateTimePicker.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DateReqDateTimePicker.Enabled = false;
            DateReqDateTimePicker.Location = new Point(147, 239);
            DateReqDateTimePicker.Name = "DateReqDateTimePicker";
            DateReqDateTimePicker.Size = new Size(307, 23);
            DateReqDateTimePicker.TabIndex = 13;
            // 
            // DocumentTypeLabel
            // 
            DocumentTypeLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DocumentTypeLabel.AutoSize = true;
            DocumentTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DocumentTypeLabel.Location = new Point(13, 85);
            DocumentTypeLabel.Name = "DocumentTypeLabel";
            DocumentTypeLabel.Size = new Size(128, 15);
            DocumentTypeLabel.TabIndex = 2;
            DocumentTypeLabel.Text = "Document Type :";
            DocumentTypeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PurposeTextBox
            // 
            PurposeTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            PurposeTextBox.BorderStyle = BorderStyle.FixedSingle;
            PurposeTextBox.Location = new Point(147, 123);
            PurposeTextBox.Multiline = true;
            PurposeTextBox.Name = "PurposeTextBox";
            PurposeTextBox.Size = new Size(307, 89);
            PurposeTextBox.TabIndex = 10;
            // 
            // DocumentTypeComboBox
            // 
            DocumentTypeComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DocumentTypeComboBox.FormattingEnabled = true;
            DocumentTypeComboBox.Location = new Point(147, 81);
            DocumentTypeComboBox.Name = "DocumentTypeComboBox";
            DocumentTypeComboBox.Size = new Size(307, 23);
            DocumentTypeComboBox.TabIndex = 9;
            // 
            // ResidentComboBox
            // 
            ResidentComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ResidentComboBox.FormattingEnabled = true;
            ResidentComboBox.Location = new Point(147, 26);
            ResidentComboBox.Name = "ResidentComboBox";
            ResidentComboBox.Size = new Size(307, 23);
            ResidentComboBox.TabIndex = 8;
            // 
            // PurposeLabel
            // 
            PurposeLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            PurposeLabel.AutoSize = true;
            PurposeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PurposeLabel.Location = new Point(13, 160);
            PurposeLabel.Name = "PurposeLabel";
            PurposeLabel.Size = new Size(128, 15);
            PurposeLabel.TabIndex = 3;
            PurposeLabel.Text = "Purpose :";
            PurposeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ReqInformationHeaderLabel
            // 
            ReqInformationHeaderLabel.AutoSize = true;
            ReqInformationHeaderLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ReqInformationHeaderLabel.Location = new Point(17, 4);
            ReqInformationHeaderLabel.Name = "ReqInformationHeaderLabel";
            ReqInformationHeaderLabel.Size = new Size(135, 17);
            ReqInformationHeaderLabel.TabIndex = 22;
            ReqInformationHeaderLabel.Text = "Request Information";
            // 
            // NewReqSubTitleLabel
            // 
            NewReqSubTitleLabel.Anchor = AnchorStyles.Left;
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
            CancelButton.Location = new Point(18, 3);
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
            SubmitReqButton.Location = new Point(258, 3);
            SubmitReqButton.Name = "SubmitReqButton";
            SubmitReqButton.Size = new Size(204, 39);
            SubmitReqButton.TabIndex = 24;
            SubmitReqButton.Text = "📄 Submit Request";
            SubmitReqButton.UseVisualStyleBackColor = false;
            // 
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.Anchor = AnchorStyles.Left;
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
            // PanelContainer
            // 
            PanelContainer.Controls.Add(buttonTLP);
            PanelContainer.Controls.Add(BodyGroupBox);
            PanelContainer.Controls.Add(NavPanel);
            PanelContainer.Dock = DockStyle.Fill;
            PanelContainer.Location = new Point(0, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(635, 512);
            PanelContainer.TabIndex = 27;
            // 
            // buttonTLP
            // 
            buttonTLP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonTLP.ColumnCount = 2;
            buttonTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            buttonTLP.Controls.Add(CancelButton, 0, 0);
            buttonTLP.Controls.Add(SubmitReqButton, 1, 0);
            buttonTLP.Location = new Point(77, 452);
            buttonTLP.Name = "buttonTLP";
            buttonTLP.RowCount = 1;
            buttonTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            buttonTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            buttonTLP.Size = new Size(481, 46);
            buttonTLP.TabIndex = 28;
            // 
            // NavPanel
            // 
            NavPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NavPanel.BackColor = Color.DarkSlateBlue;
            NavPanel.Controls.Add(nameLabel);
            NavPanel.Controls.Add(DocumentReqTitleLabel);
            NavPanel.Controls.Add(NewReqSubTitleLabel);
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(635, 100);
            NavPanel.TabIndex = 27;
            // 
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.Right;
            nameLabel.AutoSize = true;
            nameLabel.BackColor = Color.DarkSlateBlue;
            nameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.ForeColor = Color.DarkGray;
            nameLabel.Location = new Point(408, 10);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(213, 15);
            nameLabel.TabIndex = 27;
            nameLabel.Text = "Barangay Document Request System";
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
            bodyTLP.ResumeLayout(false);
            bodyTLP.PerformLayout();
            PanelContainer.ResumeLayout(false);
            buttonTLP.ResumeLayout(false);
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
        private Label nameLabel;
        private TableLayoutPanel bodyTLP;
        private TableLayoutPanel buttonTLP;
    }
}
