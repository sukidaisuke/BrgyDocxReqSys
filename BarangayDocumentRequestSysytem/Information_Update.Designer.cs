namespace BarangayDocumentRequestSysytem
{
    partial class Information_Update
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnRefresh = new System.Windows.Forms.Button();
            btnReject = new System.Windows.Forms.Button();
            btnApprove = new System.Windows.Forms.Button();
            dgvRequests = new System.Windows.Forms.DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnReject);
            groupBox1.Controls.Add(btnApprove);
            groupBox1.Controls.Add(dgvRequests);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            groupBox1.Location = new System.Drawing.Point(5, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(420, 410);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Information Update Requests";
            // 
            // dgvRequests
            // 
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;
            dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dgvRequests.Location = new System.Drawing.Point(12, 25);
            dgvRequests.MultiSelect = false;
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.RowHeadersWidth = 25;
            dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new System.Drawing.Size(396, 330);
            dgvRequests.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.SteelBlue;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.Location = new System.Drawing.Point(12, 365);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(85, 33);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = System.Drawing.Color.ForestGreen;
            btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnApprove.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            btnApprove.ForeColor = System.Drawing.Color.White;
            btnApprove.Location = new System.Drawing.Point(210, 365);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new System.Drawing.Size(95, 33);
            btnApprove.TabIndex = 1;
            btnApprove.Text = "✓ Approve";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = System.Drawing.Color.Crimson;
            btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnReject.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            btnReject.ForeColor = System.Drawing.Color.White;
            btnReject.Location = new System.Drawing.Point(312, 365);
            btnReject.Name = "btnReject";
            btnReject.Size = new System.Drawing.Size(96, 33);
            btnReject.TabIndex = 2;
            btnReject.Text = "✗ Reject";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // Information_Update
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "Information_Update";
            Size = new System.Drawing.Size(430, 420);
            Load += Information_Update_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnRefresh;
    }
}