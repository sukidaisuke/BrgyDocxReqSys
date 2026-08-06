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
            tableLayoutPanel1 = new TableLayoutPanel();
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
            NavPanel = new Panel();
            nameLabel = new Label();
            BodyGroupBox.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            PanelContainer.SuspendLayout();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // BodyGroupBox
            // 
            BodyGroupBox.Anchor = AnchorStyles.None;
            BodyGroupBox.Controls.Add(tableLayoutPanel1);
            BodyGroupBox.Controls.Add(ReqInformationHeaderLabel);
            BodyGroupBox.Location = new Point(77, 109);
            BodyGroupBox.Name = "BodyGroupBox";
            BodyGroupBox.Padding = new Padding(7);
            BodyGroupBox.Size = new Size(481, 326);
            BodyGroupBox.TabIndex = 21;
            BodyGroupBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(ResidentLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(DateReqLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(DateReqDateTimePicker, 1, 3);
            tableLayoutPanel1.Controls.Add(DocumentTypeLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(PurposeTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(DocumentTypeComboBox, 1, 1);
            tableLayoutPanel1.Controls.Add(ResidentComboBox, 1, 0);
            tableLayoutPanel1.Controls.Add(PurposeLabel, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(7, 23);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 34.7973F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25.3378372F));
            tableLayoutPanel1.Size = new Size(467, 296);
            tableLayoutPanel1.TabIndex = 23;
            // 
            // ResidentLabel
            // 
            ResidentLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ResidentLabel.AutoSize = true;
            ResidentLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ResidentLabel.Location = new Point(13, 30);
            ResidentLabel.Name = "ResidentLabel";
            ResidentLabel.Size = new Size(217, 15);
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
            DateReqLabel.Size = new Size(217, 15);
            DateReqLabel.TabIndex = 12;
            DateReqLabel.Text = "Date Requested :";
            DateReqLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DateReqDateTimePicker
            // 
            DateReqDateTimePicker.Anchor = AnchorStyles.Top;
            DateReqDateTimePicker.Enabled = false;
            DateReqDateTimePicker.Location = new Point(236, 218);
            DateReqDateTimePicker.Name = "DateReqDateTimePicker";
            DateReqDateTimePicker.Size = new Size(218, 23);
            DateReqDateTimePicker.TabIndex = 13;
            // 
            // DocumentTypeLabel
            // 
            DocumentTypeLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DocumentTypeLabel.AutoSize = true;
            DocumentTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DocumentTypeLabel.Location = new Point(13, 85);
            DocumentTypeLabel.Name = "DocumentTypeLabel";
            DocumentTypeLabel.Size = new Size(217, 15);
            DocumentTypeLabel.TabIndex = 2;
            DocumentTypeLabel.Text = "Document Type :";
            DocumentTypeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PurposeTextBox
            // 
            PurposeTextBox.Anchor = AnchorStyles.Top;
            PurposeTextBox.BorderStyle = BorderStyle.FixedSingle;
            PurposeTextBox.Location = new Point(236, 123);
            PurposeTextBox.Multiline = true;
            PurposeTextBox.Name = "PurposeTextBox";
            PurposeTextBox.Size = new Size(218, 89);
            PurposeTextBox.TabIndex = 10;
            // 
            // DocumentTypeComboBox
            // 
            DocumentTypeComboBox.Anchor = AnchorStyles.Top;
            DocumentTypeComboBox.FormattingEnabled = true;
            DocumentTypeComboBox.Location = new Point(236, 68);
            DocumentTypeComboBox.Name = "DocumentTypeComboBox";
            DocumentTypeComboBox.Size = new Size(218, 23);
            DocumentTypeComboBox.TabIndex = 9;
            // 
            // ResidentComboBox
            // 
            ResidentComboBox.Anchor = AnchorStyles.Top;
            ResidentComboBox.FormattingEnabled = true;
            ResidentComboBox.Location = new Point(236, 13);
            ResidentComboBox.Name = "ResidentComboBox";
            ResidentComboBox.Size = new Size(218, 23);
            ResidentComboBox.TabIndex = 8;
            // 
            // PurposeLabel
            // 
            PurposeLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            PurposeLabel.AutoSize = true;
            PurposeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PurposeLabel.Location = new Point(13, 160);
            PurposeLabel.Name = "PurposeLabel";
            PurposeLabel.Size = new Size(217, 15);
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
            PanelContainer.Controls.Add(BodyGroupBox);
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
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            PanelContainer.ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel1;
    }
}
