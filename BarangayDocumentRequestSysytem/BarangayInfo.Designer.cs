namespace BarangayDocumentRequestSysytem
{
    partial class BarangayInfo
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
            bodyGB = new System.Windows.Forms.GroupBox();
            dgvBrgyInfo = new System.Windows.Forms.DataGridView();
            editorGB = new System.Windows.Forms.GroupBox();
            editorTLP = new System.Windows.Forms.TableLayoutPanel();
            lblFieldHeader = new System.Windows.Forms.Label();
            txtFieldValue = new System.Windows.Forms.TextBox();
            btnUpdateField = new System.Windows.Forms.Button();
            bodyGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBrgyInfo).BeginInit();
            editorGB.SuspendLayout();
            editorTLP.SuspendLayout();
            SuspendLayout();
            // 
            // bodyGB
            // 
            bodyGB.Controls.Add(dgvBrgyInfo);
            bodyGB.Controls.Add(editorGB);
            bodyGB.Dock = System.Windows.Forms.DockStyle.Fill;
            bodyGB.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            bodyGB.Location = new System.Drawing.Point(0, 0);
            bodyGB.Name = "bodyGB";
            bodyGB.Padding = new System.Windows.Forms.Padding(10);
            bodyGB.Size = new System.Drawing.Size(430, 420);
            bodyGB.TabIndex = 0;
            bodyGB.TabStop = false;
            bodyGB.Text = "🏛️ Barangay Information Settings";
            // 
            // dgvBrgyInfo
            // 
            dgvBrgyInfo.AllowUserToAddRows = false;
            dgvBrgyInfo.AllowUserToDeleteRows = false;
            dgvBrgyInfo.BackgroundColor = System.Drawing.Color.White;
            dgvBrgyInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvBrgyInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBrgyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvBrgyInfo.Location = new System.Drawing.Point(10, 30);
            dgvBrgyInfo.Name = "dgvBrgyInfo";
            dgvBrgyInfo.ReadOnly = true;
            dgvBrgyInfo.RowTemplate.Height = 28;
            dgvBrgyInfo.Size = new System.Drawing.Size(410, 260);
            dgvBrgyInfo.TabIndex = 0;
            dgvBrgyInfo.CellClick += dgvBrgyInfo_CellClick;
            // 
            // editorGB
            // 
            editorGB.Controls.Add(editorTLP);
            editorGB.Dock = System.Windows.Forms.DockStyle.Bottom;
            editorGB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            editorGB.ForeColor = System.Drawing.Color.FromArgb(48, 44, 105);
            editorGB.Location = new System.Drawing.Point(10, 290);
            editorGB.Name = "editorGB";
            editorGB.Size = new System.Drawing.Size(410, 120);
            editorGB.TabIndex = 1;
            editorGB.TabStop = false;
            editorGB.Text = "⚙️ Edit Selected Information";
            // 
            // editorTLP
            // 
            editorTLP.ColumnCount = 2;
            editorTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            editorTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            editorTLP.Controls.Add(lblFieldHeader, 0, 0);
            editorTLP.Controls.Add(txtFieldValue, 0, 1);
            editorTLP.Controls.Add(btnUpdateField, 1, 1);
            editorTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            editorTLP.Location = new System.Drawing.Point(3, 19);
            editorTLP.Name = "editorTLP";
            editorTLP.RowCount = 2;
            editorTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            editorTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            editorTLP.Size = new System.Drawing.Size(404, 98);
            editorTLP.TabIndex = 0;
            // 
            // lblFieldHeader
            // 
            lblFieldHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblFieldHeader.AutoSize = true;
            editorTLP.SetColumnSpan(lblFieldHeader, 2);
            lblFieldHeader.ForeColor = System.Drawing.Color.Black;
            lblFieldHeader.Location = new System.Drawing.Point(3, 7);
            lblFieldHeader.Name = "lblFieldHeader";
            lblFieldHeader.Size = new System.Drawing.Size(123, 15);
            lblFieldHeader.TabIndex = 0;
            lblFieldHeader.Text = "Select a field to edit";
            // 
            // txtFieldValue
            // 
            txtFieldValue.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtFieldValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtFieldValue.Location = new System.Drawing.Point(3, 40);
            txtFieldValue.Name = "txtFieldValue";
            txtFieldValue.Size = new System.Drawing.Size(276, 24);
            txtFieldValue.TabIndex = 1;
            // 
            // btnUpdateField
            // 
            btnUpdateField.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnUpdateField.BackColor = System.Drawing.Color.FromArgb(48, 44, 105);
            btnUpdateField.Enabled = false;
            btnUpdateField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUpdateField.ForeColor = System.Drawing.Color.White;
            btnUpdateField.Location = new System.Drawing.Point(286, 36);
            btnUpdateField.Name = "btnUpdateField";
            btnUpdateField.Size = new System.Drawing.Size(114, 33);
            btnUpdateField.TabIndex = 2;
            btnUpdateField.Text = "💾 Save Field";
            btnUpdateField.UseVisualStyleBackColor = false;
            btnUpdateField.Click += btnUpdateField_Click;
            // 
            // BarangayInfo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(bodyGB);
            Name = "BarangayInfo";
            Size = new System.Drawing.Size(430, 420);
            bodyGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBrgyInfo).EndInit();
            editorGB.ResumeLayout(false);
            editorTLP.ResumeLayout(false);
            editorTLP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox bodyGB;
        private System.Windows.Forms.DataGridView dgvBrgyInfo;
        private System.Windows.Forms.GroupBox editorGB;
        private System.Windows.Forms.TableLayoutPanel editorTLP;
        private System.Windows.Forms.Label lblFieldHeader;
        private System.Windows.Forms.TextBox txtFieldValue;
        private System.Windows.Forms.Button btnUpdateField;
    }
}