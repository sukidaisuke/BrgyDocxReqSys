namespace BarangayDocumentRequestSysytem
{
    partial class DocumentSettings
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            bodyGB = new GroupBox();
            btnSaveAll = new Button();
            dgvDocumentSettings = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDocName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewButtonColumn();
            bodyGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDocumentSettings).BeginInit();
            SuspendLayout();
            // 
            // bodyGB
            // 
            bodyGB.Controls.Add(btnSaveAll);
            bodyGB.Controls.Add(dgvDocumentSettings);
            bodyGB.Dock = DockStyle.Fill;
            bodyGB.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            bodyGB.ForeColor = Color.FromArgb(30, 41, 59);
            bodyGB.Location = new Point(0, 0);
            bodyGB.Name = "bodyGB";
            bodyGB.Size = new Size(406, 403);
            bodyGB.TabIndex = 0;
            bodyGB.TabStop = false;
            bodyGB.Text = "Document Settings";
            // 
            // btnSaveAll
            // 
            btnSaveAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSaveAll.BackColor = Color.FromArgb(30, 41, 59);
            btnSaveAll.Cursor = Cursors.Hand;
            btnSaveAll.FlatAppearance.BorderSize = 0;
            btnSaveAll.FlatStyle = FlatStyle.Flat;
            btnSaveAll.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSaveAll.ForeColor = Color.White;
            btnSaveAll.Location = new Point(12, 355);
            btnSaveAll.Name = "btnSaveAll";
            btnSaveAll.Size = new Size(382, 36);
            btnSaveAll.TabIndex = 1;
            btnSaveAll.Text = "💾 Save All Price Changes";
            btnSaveAll.UseVisualStyleBackColor = false;
            btnSaveAll.Click += btnSaveAll_Click;
            // 
            // dgvDocumentSettings
            // 
            dgvDocumentSettings.AllowUserToAddRows = false;
            dgvDocumentSettings.AllowUserToDeleteRows = false;
            dgvDocumentSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDocumentSettings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDocumentSettings.BackgroundColor = SystemColors.ButtonHighlight;
            dgvDocumentSettings.BorderStyle = BorderStyle.FixedSingle;
            dgvDocumentSettings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDocumentSettings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(186, 218, 231);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(186, 218, 231);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDocumentSettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDocumentSettings.ColumnHeadersHeight = 38;
            dgvDocumentSettings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDocumentSettings.Columns.AddRange(new DataGridViewColumn[] { colId, colDocName, colPrice, colAction });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDocumentSettings.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDocumentSettings.EnableHeadersVisualStyles = false;
            dgvDocumentSettings.GridColor = Color.FromArgb(229, 231, 235);
            dgvDocumentSettings.Location = new Point(12, 30);
            dgvDocumentSettings.MultiSelect = false;
            dgvDocumentSettings.Name = "dgvDocumentSettings";
            dgvDocumentSettings.RowHeadersVisible = false;
            dgvDocumentSettings.RowTemplate.Height = 42;
            dgvDocumentSettings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDocumentSettings.Size = new Size(382, 312);
            dgvDocumentSettings.TabIndex = 0;
            dgvDocumentSettings.CellContentClick += dgvDocumentSettings_CellContentClick;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colDocName
            // 
            colDocName.FillWeight = 190F;
            colDocName.HeaderText = "Document Name";
            colDocName.Name = "colDocName";
            colDocName.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.FillWeight = 110F;
            colPrice.HeaderText = "Price (₱)";
            colPrice.Name = "colPrice";
            // 
            // colAction
            // 
            colAction.FillWeight = 90F;
            colAction.HeaderText = "Action";
            colAction.Name = "colAction";
            colAction.Text = "Update";
            colAction.UseColumnTextForButtonValue = true;
            // 
            // DocumentSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bodyGB);
            Name = "DocumentSettings";
            Size = new Size(406, 403);
            Load += DocumentSettings_Load;
            VisibleChanged += DocumentSettings_VisibleChanged;
            bodyGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDocumentSettings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox bodyGB;
        private DataGridView dgvDocumentSettings;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDocName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewButtonColumn colAction;
        private Button btnSaveAll;
    }
}