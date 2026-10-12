namespace BarangayDocumentRequestSysytem
{
    partial class ReadyToPrintForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDocType = new System.Windows.Forms.Label();
            this.cmbDocType = new System.Windows.Forms.ComboBox();
            this.lblResidentName = new System.Windows.Forms.Label();
            this.txtResidentName = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblCivilStatus = new System.Windows.Forms.Label();
            this.cmbCivilStatus = new System.Windows.Forms.ComboBox();
            this.lblPurpose = new System.Windows.Forms.Label();
            this.cmbPurpose = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.rtbPreview = new System.Windows.Forms.RichTextBox();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Location = new System.Drawing.Point(15, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(260, 23);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "📄 Ready-To-Print Documents";
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnGenerate);
            this.pnlControls.Controls.Add(this.cmbPurpose);
            this.pnlControls.Controls.Add(this.lblPurpose);
            this.pnlControls.Controls.Add(this.cmbCivilStatus);
            this.pnlControls.Controls.Add(this.lblCivilStatus);
            this.pnlControls.Controls.Add(this.txtAge);
            this.pnlControls.Controls.Add(this.lblAge);
            this.pnlControls.Controls.Add(this.txtResidentName);
            this.pnlControls.Controls.Add(this.lblResidentName);
            this.pnlControls.Controls.Add(this.cmbDocType);
            this.pnlControls.Controls.Add(this.lblDocType);
            this.pnlControls.Controls.Add(this.lblHeader);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(320, 560);
            this.pnlControls.TabIndex = 0;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDocType.Location = new System.Drawing.Point(17, 60);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(104, 17);
            this.lblDocType.TabIndex = 1;
            this.lblDocType.Text = "Document Type";
            // 
            // cmbDocType
            // 
            this.cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbDocType.FormattingEnabled = true;
            this.cmbDocType.Location = new System.Drawing.Point(20, 82);
            this.cmbDocType.Name = "cmbDocType";
            this.cmbDocType.Size = new System.Drawing.Size(280, 25);
            this.cmbDocType.TabIndex = 2;
            this.cmbDocType.SelectedIndexChanged += new System.EventHandler(this.cmbDocType_SelectedIndexChanged);
            // 
            // lblResidentName
            // 
            this.lblResidentName.AutoSize = true;
            this.lblResidentName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResidentName.Location = new System.Drawing.Point(17, 120);
            this.lblResidentName.Name = "lblResidentName";
            this.lblResidentName.Size = new System.Drawing.Size(130, 17);
            this.lblResidentName.TabIndex = 3;
            this.lblResidentName.Text = "Resident Full Name";
            // 
            // txtResidentName
            // 
            this.txtResidentName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtResidentName.Location = new System.Drawing.Point(20, 142);
            this.txtResidentName.Name = "txtResidentName";
            this.txtResidentName.Size = new System.Drawing.Size(280, 24);
            this.txtResidentName.TabIndex = 4;
            this.txtResidentName.Text = "Juan Dela Cruz";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAge.Location = new System.Drawing.Point(17, 180);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 17);
            this.lblAge.TabIndex = 5;
            this.lblAge.Text = "Age";
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtAge.Location = new System.Drawing.Point(20, 202);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(280, 24);
            this.txtAge.TabIndex = 6;
            this.txtAge.Text = "28";
            // 
            // lblCivilStatus
            // 
            this.lblCivilStatus.AutoSize = true;
            this.lblCivilStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCivilStatus.Location = new System.Drawing.Point(17, 240);
            this.lblCivilStatus.Name = "lblCivilStatus";
            this.lblCivilStatus.Size = new System.Drawing.Size(77, 17);
            this.lblCivilStatus.TabIndex = 7;
            this.lblCivilStatus.Text = "Civil Status";
            // 
            // cmbCivilStatus
            // 
            this.cmbCivilStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCivilStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCivilStatus.FormattingEnabled = true;
            this.cmbCivilStatus.Location = new System.Drawing.Point(20, 262);
            this.cmbCivilStatus.Name = "cmbCivilStatus";
            this.cmbCivilStatus.Size = new System.Drawing.Size(280, 25);
            this.cmbCivilStatus.TabIndex = 8;
            this.cmbCivilStatus.SelectedIndexChanged += new System.EventHandler(this.cmbCivilStatus_SelectedIndexChanged);
            // 
            // lblPurpose
            // 
            this.lblPurpose.AutoSize = true;
            this.lblPurpose.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPurpose.Location = new System.Drawing.Point(17, 300);
            this.lblPurpose.Name = "lblPurpose";
            this.lblPurpose.Size = new System.Drawing.Size(58, 17);
            this.lblPurpose.TabIndex = 9;
            this.lblPurpose.Text = "Purpose";
            // 
            // cmbPurpose
            // 
            this.cmbPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPurpose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPurpose.FormattingEnabled = true;
            this.cmbPurpose.Location = new System.Drawing.Point(20, 322);
            this.cmbPurpose.Name = "cmbPurpose";
            this.cmbPurpose.Size = new System.Drawing.Size(280, 25);
            this.cmbPurpose.TabIndex = 10;
            this.cmbPurpose.SelectedIndexChanged += new System.EventHandler(this.cmbPurpose_SelectedIndexChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(20, 370);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(280, 36);
            this.btnGenerate.TabIndex = 11;
            this.btnGenerate.Text = "🔄 Update Preview";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // rtbPreview
            // 
            this.rtbPreview.BackColor = System.Drawing.Color.White;
            this.rtbPreview.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.rtbPreview.Location = new System.Drawing.Point(335, 15);
            this.rtbPreview.Name = "rtbPreview";
            this.rtbPreview.ReadOnly = true;
            this.rtbPreview.Size = new System.Drawing.Size(430, 480);
            this.rtbPreview.TabIndex = 1;
            this.rtbPreview.Text = "";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(530, 508);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(130, 34);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "🖨 Print / Preview";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnClose.Location = new System.Drawing.Point(670, 508);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 34);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReadyToPrintForm
            // 
            this.ClientSize = new System.Drawing.Size(780, 560);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.rtbPreview);
            this.Controls.Add(this.pnlControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadyToPrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ready-To-Print Barangay Document Generator";
            this.Load += new System.EventHandler(this.ReadyToPrintForm_Load);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.ComboBox cmbDocType;
        private System.Windows.Forms.Label lblResidentName;
        private System.Windows.Forms.TextBox txtResidentName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblCivilStatus;
        private System.Windows.Forms.ComboBox cmbCivilStatus;
        private System.Windows.Forms.Label lblPurpose;
        private System.Windows.Forms.ComboBox cmbPurpose;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox rtbPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}