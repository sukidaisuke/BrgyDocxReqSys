namespace BarangayDocumentRequestSysytem
{
    partial class MyRequestsControl
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
            lblDate = new Label();
            lblPageTitle = new Label();
            panelTableCard = new Panel();
            dgvMyRequests = new DataGridView();
            colRefNo = new DataGridViewTextBoxColumn();
            colDocType = new DataGridViewTextBoxColumn();
            colDateRequested = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            txtSearch = new TextBox();
            cmbFilterStatus = new ComboBox();
            lblShowingCount = new Label();
            panelTableCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyRequests).BeginInit();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.DimGray;
            lblDate.Location = new Point(402, 17);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(172, 18);
            lblDate.TabIndex = 18;
            lblDate.Text = "📅 August 8, 2026 | Saturday";
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPageTitle.ForeColor = Color.DarkSlateBlue;
            lblPageTitle.Location = new Point(13, 14);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(121, 26);
            lblPageTitle.TabIndex = 16;
            lblPageTitle.Text = "My Requests";
            // 
            // panelTableCard
            // 
            panelTableCard.BackColor = SystemColors.ButtonHighlight;
            panelTableCard.BorderStyle = BorderStyle.FixedSingle;
            panelTableCard.Controls.Add(dgvMyRequests);
            panelTableCard.ForeColor = SystemColors.ActiveCaptionText;
            panelTableCard.Location = new Point(13, 80);
            panelTableCard.Name = "panelTableCard";
            panelTableCard.Size = new Size(561, 339);
            panelTableCard.TabIndex = 19;
            // 
            // dgvMyRequests
            // 
            dgvMyRequests.AllowUserToAddRows = false;
            dgvMyRequests.AllowUserToDeleteRows = false;
            dgvMyRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyRequests.BackgroundColor = SystemColors.ButtonHighlight;
            dgvMyRequests.BorderStyle = BorderStyle.None;
            dgvMyRequests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMyRequests.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMyRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMyRequests.ColumnHeadersHeight = 45;
            dgvMyRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMyRequests.Columns.AddRange(new DataGridViewColumn[] { colRefNo, colDocType, colDateRequested, colStatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMyRequests.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMyRequests.EnableHeadersVisualStyles = false;
            dgvMyRequests.GridColor = Color.FromArgb(229, 231, 235);
            dgvMyRequests.Location = new Point(3, 3);
            dgvMyRequests.MultiSelect = false;
            dgvMyRequests.Name = "dgvMyRequests";
            dgvMyRequests.ReadOnly = true;
            dgvMyRequests.RowHeadersVisible = false;
            dgvMyRequests.RowTemplate.Height = 55;
            dgvMyRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyRequests.Size = new Size(553, 331);
            dgvMyRequests.TabIndex = 0;
            dgvMyRequests.CellContentClick += dgvMyRequests_CellContentClick;
            dgvMyRequests.CellFormatting += dgvMyRequests_CellFormatting;
            // 
            // colRefNo
            // 
            colRefNo.HeaderText = "Reference No.";
            colRefNo.Name = "colRefNo";
            colRefNo.ReadOnly = true;
            // 
            // colDocType
            // 
            colDocType.HeaderText = "Document Type";
            colDocType.Name = "colDocType";
            colDocType.ReadOnly = true;
            // 
            // colDateRequested
            // 
            colDateRequested.HeaderText = "Date Requested";
            colDateRequested.Name = "colDateRequested";
            colDateRequested.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = SystemColors.ControlDark;
            txtSearch.Location = new Point(160, 50);
            txtSearch.Margin = new Padding(5, 3, 3, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(275, 23);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "🔍  Search by document type or reference no.";
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Items.AddRange(new object[] { "All", "Pending", "Completed", "Rejected" });
            cmbFilterStatus.Location = new Point(443, 51);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(121, 23);
            cmbFilterStatus.TabIndex = 1;
            // 
            // lblShowingCount
            // 
            lblShowingCount.AutoSize = true;
            lblShowingCount.Location = new Point(17, 422);
            lblShowingCount.Name = "lblShowingCount";
            lblShowingCount.Size = new Size(95, 15);
            lblShowingCount.TabIndex = 20;
            lblShowingCount.Text = "Total Requests: 1";
            // 
            // MyRequestsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(lblShowingCount);
            Controls.Add(cmbFilterStatus);
            Controls.Add(txtSearch);
            Controls.Add(lblDate);
            Controls.Add(lblPageTitle);
            Controls.Add(panelTableCard);
            Name = "MyRequestsControl";
            Size = new Size(586, 447);
            Load += MyRequestsControl_Load;
            panelTableCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMyRequests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDate;
        private Label lblPageTitle;
        private Panel panelTableCard;
        private TextBox txtSearch;
        private ComboBox cmbFilterStatus;
        private DataGridView dgvMyRequests;
        private DataGridViewTextBoxColumn colRefNo;
        private DataGridViewTextBoxColumn colDocType;
        private DataGridViewTextBoxColumn colDateRequested;
        private DataGridViewTextBoxColumn colStatus;
        private Label lblShowingCount;
    }
}
