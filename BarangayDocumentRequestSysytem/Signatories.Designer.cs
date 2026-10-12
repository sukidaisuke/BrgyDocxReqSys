namespace BarangayDocumentRequestSysytem
{
    partial class Signatories
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            bodyGB = new GroupBox();
            dgvSignatories = new DataGridView();
            editorGB = new GroupBox();
            editorTLP = new TableLayoutPanel();
            lblPosition = new Label();
            cmbPosition = new ComboBox();
            lblName = new Label();
            txtName = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            actionsTLP = new TableLayoutPanel();
            btnNew = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            bodyGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSignatories).BeginInit();
            editorGB.SuspendLayout();
            editorTLP.SuspendLayout();
            actionsTLP.SuspendLayout();
            SuspendLayout();
            // 
            // bodyGB
            // 
            bodyGB.Controls.Add(dgvSignatories);
            bodyGB.Controls.Add(editorGB);
            bodyGB.Dock = DockStyle.Fill;
            bodyGB.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            bodyGB.Location = new Point(0, 0);
            bodyGB.Name = "bodyGB";
            bodyGB.Padding = new Padding(10);
            bodyGB.Size = new Size(430, 420);
            bodyGB.TabIndex = 0;
            bodyGB.TabStop = false;
            bodyGB.Text = "📜 Barangay Official Signatories";
            // 
            // dgvSignatories
            // 
            dgvSignatories.AllowUserToAddRows = false;
            dgvSignatories.AllowUserToDeleteRows = false;
            dgvSignatories.BackgroundColor = Color.White;
            dgvSignatories.BorderStyle = BorderStyle.Fixed3D;
            dgvSignatories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSignatories.Dock = DockStyle.Fill;
            dgvSignatories.Location = new Point(10, 30);
            dgvSignatories.Name = "dgvSignatories";
            dgvSignatories.ReadOnly = true;
            dgvSignatories.RowTemplate.Height = 28;
            dgvSignatories.Size = new Size(410, 190);
            dgvSignatories.TabIndex = 0;
            dgvSignatories.CellClick += dgvSignatories_CellClick;
            // 
            // editorGB
            // 
            editorGB.Controls.Add(editorTLP);
            editorGB.Controls.Add(actionsTLP);
            editorGB.Dock = DockStyle.Bottom;
            editorGB.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            editorGB.ForeColor = Color.FromArgb(48, 44, 105);
            editorGB.Location = new Point(10, 220);
            editorGB.Name = "editorGB";
            editorGB.Size = new Size(410, 190);
            editorGB.TabIndex = 1;
            editorGB.TabStop = false;
            editorGB.Text = "⚙️ Edit Selected Official";
            // 
            // editorTLP
            // 
            editorTLP.ColumnCount = 2;
            editorTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            editorTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            editorTLP.Controls.Add(lblPosition, 0, 0);
            editorTLP.Controls.Add(cmbPosition, 1, 0);
            editorTLP.Controls.Add(lblName, 0, 1);
            editorTLP.Controls.Add(txtName, 1, 1);
            editorTLP.Controls.Add(lblStatus, 0, 2);
            editorTLP.Controls.Add(cmbStatus, 1, 2);
            editorTLP.Dock = DockStyle.Top;
            editorTLP.Location = new Point(3, 19);
            editorTLP.Name = "editorTLP";
            editorTLP.RowCount = 3;
            editorTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            editorTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            editorTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            editorTLP.Size = new Size(404, 115);
            editorTLP.TabIndex = 0;
            // 
            // lblPosition
            // 
            lblPosition.Anchor = AnchorStyles.Left;
            lblPosition.AutoSize = true;
            lblPosition.ForeColor = Color.Black;
            lblPosition.Location = new Point(3, 11);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(90, 15);
            lblPosition.TabIndex = 0;
            lblPosition.Text = "Position / Title:";
            // 
            // cmbPosition
            // 
            cmbPosition.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.Font = new Font("Segoe UI", 9F);
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Items.AddRange(new object[] { "Barangay Captain", "Barangay Kagawad", "Barangay Secretary", "Barangay Treasurer", "SK Chairman", "Chief Tanod", "Lupon Tagapamayapa Member", "Barangay Health Worker (BHW)", "Barangay Nutrition Scholar (BNS)" });
            cmbPosition.Location = new Point(144, 7);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(257, 23);
            cmbPosition.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Left;
            lblName.AutoSize = true;
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(3, 49);
            lblName.Name = "lblName";
            lblName.Size = new Size(86, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Official Name:";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Font = new Font("Segoe UI", 9F);
            txtName.Location = new Point(144, 45);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "e.g., Juan Dela Cruz";
            txtName.Size = new Size(257, 23);
            txtName.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(3, 88);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(45, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.Anchor = AnchorStyles.Left;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 9F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cmbStatus.Location = new Point(144, 84);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 23);
            cmbStatus.TabIndex = 5;
            // 
            // actionsTLP
            // 
            actionsTLP.ColumnCount = 3;
            actionsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            actionsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            actionsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            actionsTLP.Controls.Add(btnNew, 0, 0);
            actionsTLP.Controls.Add(btnSave, 1, 0);
            actionsTLP.Controls.Add(btnDelete, 2, 0);
            actionsTLP.Dock = DockStyle.Bottom;
            actionsTLP.Location = new Point(3, 142);
            actionsTLP.Name = "actionsTLP";
            actionsTLP.RowCount = 1;
            actionsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            actionsTLP.Size = new Size(404, 45);
            actionsTLP.TabIndex = 1;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.None;
            btnNew.BackColor = Color.Gray;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(8, 6);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(118, 33);
            btnNew.TabIndex = 0;
            btnNew.Text = "⌫ Reset";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.BackColor = Color.FromArgb(48, 44, 105);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(142, 6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(118, 33);
            btnSave.TabIndex = 1;
            btnSave.Text = "➕ Add New";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.BackColor = Color.DarkRed;
            btnDelete.Enabled = false;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(276, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 33);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // Signatories
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bodyGB);
            Name = "Signatories";
            Size = new Size(430, 420);
            bodyGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSignatories).EndInit();
            editorGB.ResumeLayout(false);
            editorTLP.ResumeLayout(false);
            editorTLP.PerformLayout();
            actionsTLP.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox bodyGB;
        private System.Windows.Forms.DataGridView dgvSignatories;
        private System.Windows.Forms.GroupBox editorGB;
        private System.Windows.Forms.TableLayoutPanel editorTLP;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TableLayoutPanel actionsTLP;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
    }
}