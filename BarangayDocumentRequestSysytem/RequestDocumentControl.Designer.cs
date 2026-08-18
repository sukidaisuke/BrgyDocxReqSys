namespace BarangayDocumentRequestSysytem
{
    partial class RequestDocumentControl
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
            lblDate = new Label();
            lblSubtext = new Label();
            lblWelcome = new Label();
            panel1 = new Panel();
            btnSubmitRequest = new Button();
            panel2 = new Panel();
            lblRequirementsList = new Label();
            label1 = new Label();
            panel3 = new Panel();
            btnAttachFile = new Button();
            lblFileStatus = new Label();
            lblPurposeCount = new Label();
            txtPurpose = new TextBox();
            lblPurpose = new Label();
            cmbDocumentType = new ComboBox();
            lblDocType = new Label();
            lblFormTitle = new Label();
            label2 = new Label();
            txtOtherDocType = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.DimGray;
            lblDate.Location = new Point(401, 16);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(172, 18);
            lblDate.TabIndex = 14;
            lblDate.Text = "📅 August 8, 2026 | Saturday";
            // 
            // lblSubtext
            // 
            lblSubtext.AutoSize = true;
            lblSubtext.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtext.ForeColor = Color.DimGray;
            lblSubtext.Location = new Point(14, 39);
            lblSubtext.Name = "lblSubtext";
            lblSubtext.Size = new Size(222, 18);
            lblSubtext.TabIndex = 13;
            lblSubtext.Text = "Fill out the form to request a document";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.DarkSlateBlue;
            lblWelcome.Location = new Point(12, 13);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(189, 26);
            lblWelcome.TabIndex = 12;
            lblWelcome.Text = "Request a Document";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(btnSubmitRequest);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lblPurposeCount);
            panel1.Controls.Add(txtPurpose);
            panel1.Controls.Add(lblPurpose);
            panel1.Controls.Add(cmbDocumentType);
            panel1.Controls.Add(lblDocType);
            panel1.Controls.Add(lblFormTitle);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtOtherDocType);
            panel1.Location = new Point(14, 71);
            panel1.Name = "panel1";
            panel1.Size = new Size(559, 361);
            panel1.TabIndex = 15;
            // 
            // btnSubmitRequest
            // 
            btnSubmitRequest.BackColor = Color.SlateBlue;
            btnSubmitRequest.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmitRequest.ForeColor = SystemColors.ButtonHighlight;
            btnSubmitRequest.Location = new Point(28, 310);
            btnSubmitRequest.Name = "btnSubmitRequest";
            btnSubmitRequest.Size = new Size(507, 39);
            btnSubmitRequest.TabIndex = 28;
            btnSubmitRequest.Text = "➤  Submit Request";
            btnSubmitRequest.UseVisualStyleBackColor = false;
            btnSubmitRequest.Click += btnSubmitRequest_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.Controls.Add(lblRequirementsList);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(28, 237);
            panel2.Name = "panel2";
            panel2.Size = new Size(507, 63);
            panel2.TabIndex = 27;
            panel2.Paint += panel2_Paint;
            // 
            // lblRequirementsList
            // 
            lblRequirementsList.AutoSize = true;
            lblRequirementsList.Font = new Font("Gill Sans MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRequirementsList.ForeColor = SystemColors.ControlDarkDark;
            lblRequirementsList.Location = new Point(83, 3);
            lblRequirementsList.Name = "lblRequirementsList";
            lblRequirementsList.RightToLeft = RightToLeft.Yes;
            lblRequirementsList.Size = new Size(85, 18);
            lblRequirementsList.TabIndex = 26;
            lblRequirementsList.Text = "Requirement(s)";
            lblRequirementsList.TextAlign = ContentAlignment.BottomRight;
            lblRequirementsList.Click += label3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(83, 18);
            label1.TabIndex = 28;
            label1.Text = "Requirements: ";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnAttachFile);
            panel3.Controls.Add(lblFileStatus);
            panel3.Location = new Point(0, 22);
            panel3.Name = "panel3";
            panel3.Size = new Size(507, 41);
            panel3.TabIndex = 27;
            // 
            // btnAttachFile
            // 
            btnAttachFile.Location = new Point(399, 10);
            btnAttachFile.Name = "btnAttachFile";
            btnAttachFile.Size = new Size(90, 23);
            btnAttachFile.TabIndex = 30;
            btnAttachFile.Text = "⬆ Attach File";
            btnAttachFile.UseVisualStyleBackColor = true;
            // 
            // lblFileStatus
            // 
            lblFileStatus.AutoSize = true;
            lblFileStatus.ForeColor = SystemColors.ControlDarkDark;
            lblFileStatus.Location = new Point(6, 14);
            lblFileStatus.Name = "lblFileStatus";
            lblFileStatus.Size = new Size(94, 15);
            lblFileStatus.TabIndex = 29;
            lblFileStatus.Text = "No file attached.";
            // 
            // lblPurposeCount
            // 
            lblPurposeCount.AutoSize = true;
            lblPurposeCount.ForeColor = SystemColors.AppWorkspace;
            lblPurposeCount.Location = new Point(464, 183);
            lblPurposeCount.Name = "lblPurposeCount";
            lblPurposeCount.Size = new Size(36, 15);
            lblPurposeCount.TabIndex = 24;
            lblPurposeCount.Text = "0/300";
            // 
            // txtPurpose
            // 
            txtPurpose.BorderStyle = BorderStyle.FixedSingle;
            txtPurpose.Location = new Point(28, 148);
            txtPurpose.Multiline = true;
            txtPurpose.Name = "txtPurpose";
            txtPurpose.ScrollBars = ScrollBars.Vertical;
            txtPurpose.Size = new Size(507, 78);
            txtPurpose.TabIndex = 23;
            txtPurpose.TextChanged += txtPurpose_TextChanged;
            // 
            // lblPurpose
            // 
            lblPurpose.AutoSize = true;
            lblPurpose.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPurpose.Location = new Point(28, 127);
            lblPurpose.Name = "lblPurpose";
            lblPurpose.Size = new Size(122, 18);
            lblPurpose.TabIndex = 22;
            lblPurpose.Text = "Purpose of Request *";
            // 
            // cmbDocumentType
            // 
            cmbDocumentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDocumentType.FormattingEnabled = true;
            cmbDocumentType.Items.AddRange(new object[] { "-- Select Document Type --", "Barangay Clearance", "Certificate of Residency", "Certificate of Indigency", "Certificate of Good Moral Character", "Barangay ID", "Business Permit Endorsement", "Certificate of No Pending Case", "Others: (Please specify on the field below)" });
            cmbDocumentType.Location = new Point(28, 75);
            cmbDocumentType.Name = "cmbDocumentType";
            cmbDocumentType.Size = new Size(507, 23);
            cmbDocumentType.TabIndex = 21;
            cmbDocumentType.SelectedIndexChanged += cmbDocumentType_SelectedIndexChanged;
            // 
            // lblDocType
            // 
            lblDocType.AutoSize = true;
            lblDocType.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDocType.Location = new Point(28, 54);
            lblDocType.Name = "lblDocType";
            lblDocType.Size = new Size(105, 18);
            lblDocType.TabIndex = 20;
            lblDocType.Text = "Document Type *";
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Gill Sans MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFormTitle.Location = new Point(17, 10);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(152, 27);
            lblFormTitle.TabIndex = 17;
            lblFormTitle.Text = "📄 Request Form";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.InactiveCaption;
            label2.Location = new Point(3, 25);
            label2.Name = "label2";
            label2.Size = new Size(550, 23);
            label2.TabIndex = 19;
            label2.Text = "____________________________________________________________";
            label2.Click += label2_Click;
            // 
            // txtOtherDocType
            // 
            txtOtherDocType.Enabled = false;
            txtOtherDocType.Location = new Point(28, 98);
            txtOtherDocType.Name = "txtOtherDocType";
            txtOtherDocType.Size = new Size(507, 23);
            txtOtherDocType.TabIndex = 29;
            // 
            // RequestDocumentControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(panel1);
            Controls.Add(lblDate);
            Controls.Add(lblSubtext);
            Controls.Add(lblWelcome);
            Name = "RequestDocumentControl";
            Size = new Size(586, 447);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDate;
        private Label lblSubtext;
        private Label lblWelcome;
        private Panel panel1;
        private Label lblFormTitle;
        private Label label2;
        private Label lblPurpose;
        private ComboBox cmbDocumentType;
        private Label lblDocType;
        private TextBox txtPurpose;
        private Label lblPurposeCount;
        private Panel panel2;
        private Label lblRequirementsList;
        private Panel panel3;
        private Button btnAttachFile;
        private Label lblFileStatus;
        private Label label1;
        private Button btnSubmitRequest;
        private TextBox txtOtherDocType;
    }
}
