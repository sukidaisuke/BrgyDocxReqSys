namespace BarangayDocumentRequestSysytem
{
    partial class DocumentRequest
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
            System.Windows.Forms.DataGridViewCellStyle cellStyleHeader = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleDefault = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleReject = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleView = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleApprove = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleHistHeader = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleHistDefault = new System.Windows.Forms.DataGridViewCellStyle();

            this.PanelContainer = new System.Windows.Forms.Panel();
            this.BodyGroupBox = new System.Windows.Forms.GroupBox();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.request_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.document_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resident_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.request_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReject = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnApprove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.lblTotalRequests = new System.Windows.Forms.Label();
            this.dividerPanel = new System.Windows.Forms.Panel();
            this.NavPanel = new System.Windows.Forms.Panel();
            this.btnRequestHistory = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.pendingReqLBL = new System.Windows.Forms.Label();

            // Modal Overlay Controls (Details)
            this.pnlModalOverlay = new System.Windows.Forms.Panel();
            this.pnlModalCard = new System.Windows.Forms.Panel();
            this.pnlModalHeader = new System.Windows.Forms.Panel();
            this.lblModalTitle = new System.Windows.Forms.Label();
            this.btnModalCloseX = new System.Windows.Forms.Button();
            this.lblDetailResident = new System.Windows.Forms.Label();
            this.lblDetailDocType = new System.Windows.Forms.Label();
            this.lblDetailDate = new System.Windows.Forms.Label();
            this.lblDetailPurposeTitle = new System.Windows.Forms.Label();
            this.txtDetailPurpose = new System.Windows.Forms.TextBox();
            this.lblDetailAttachmentTitle = new System.Windows.Forms.Label();
            this.lblAttachmentName = new System.Windows.Forms.Label();
            this.picAttachment = new System.Windows.Forms.PictureBox();
            this.pnlModalFooter = new System.Windows.Forms.Panel();
            this.btnModalApprove = new System.Windows.Forms.Button();
            this.btnModalDecline = new System.Windows.Forms.Button();
            this.btnModalClose = new System.Windows.Forms.Button();

            // History Modal Overlay Controls
            this.pnlHistoryModalOverlay = new System.Windows.Forms.Panel();
            this.pnlHistoryModalCard = new System.Windows.Forms.Panel();
            this.pnlHistoryHeader = new System.Windows.Forms.Panel();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.btnHistoryCloseX = new System.Windows.Forms.Button();
            this.pnlHistoryFilterBar = new System.Windows.Forms.Panel();
            this.lblHistoryFilterTitle = new System.Windows.Forms.Label();
            this.cmbHistoryStatusFilter = new System.Windows.Forms.ComboBox();
            this.dgvHistoryRequests = new System.Windows.Forms.DataGridView();
            this.hist_request_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hist_resident_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hist_document_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hist_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hist_formatted_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHistoryFooter = new System.Windows.Forms.Panel();
            this.lblHistoryTotal = new System.Windows.Forms.Label();
            this.btnHistoryClose = new System.Windows.Forms.Button();

            this.PanelContainer.SuspendLayout();
            this.BodyGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.footerPanel.SuspendLayout();
            this.NavPanel.SuspendLayout();
            this.pnlModalOverlay.SuspendLayout();
            this.pnlModalCard.SuspendLayout();
            this.pnlModalHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAttachment)).BeginInit();
            this.pnlModalFooter.SuspendLayout();
            this.pnlHistoryModalOverlay.SuspendLayout();
            this.pnlHistoryModalCard.SuspendLayout();
            this.pnlHistoryHeader.SuspendLayout();
            this.pnlHistoryFilterBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryRequests)).BeginInit();
            this.pnlHistoryFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // PanelContainer
            // 
            this.PanelContainer.Controls.Add(this.pnlHistoryModalOverlay);
            this.PanelContainer.Controls.Add(this.pnlModalOverlay);
            this.PanelContainer.Controls.Add(this.BodyGroupBox);
            this.PanelContainer.Controls.Add(this.footerPanel);
            this.PanelContainer.Controls.Add(this.dividerPanel);
            this.PanelContainer.Controls.Add(this.NavPanel);
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(635, 512);
            this.PanelContainer.TabIndex = 27;

            // 
            // BodyGroupBox
            // 
            this.BodyGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BodyGroupBox.Controls.Add(this.dgvRequests);
            this.BodyGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.BodyGroupBox.Location = new System.Drawing.Point(24, 98);
            this.BodyGroupBox.Name = "BodyGroupBox";
            this.BodyGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.BodyGroupBox.Size = new System.Drawing.Size(587, 360);
            this.BodyGroupBox.TabIndex = 21;
            this.BodyGroupBox.TabStop = false;
            this.BodyGroupBox.Text = "Request List";

            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.AllowUserToResizeRows = false;
            this.dgvRequests.AutoGenerateColumns = false;
            this.dgvRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequests.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvRequests.EnableHeadersVisualStyles = false;
            cellStyleHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyleHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            cellStyleHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            cellStyleHeader.ForeColor = System.Drawing.Color.White;
            cellStyleHeader.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            cellStyleHeader.SelectionForeColor = System.Drawing.Color.White;
            cellStyleHeader.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequests.ColumnHeadersDefaultCellStyle = cellStyleHeader;
            this.dgvRequests.ColumnHeadersHeight = 40;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            cellStyleDefault.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyleDefault.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            cellStyleDefault.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            cellStyleDefault.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRequests.DefaultCellStyle = cellStyleDefault;

            this.dgvRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRequests.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvRequests.Location = new System.Drawing.Point(10, 28);
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersVisible = false;
            this.dgvRequests.RowTemplate.Height = 48;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(567, 322);
            this.dgvRequests.TabIndex = 0;
            this.dgvRequests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRequests_CellContentClick);

            // Columns Definition
            this.request_id.DataPropertyName = "request_id";
            this.request_id.HeaderText = "ID";
            this.request_id.Name = "request_id";
            this.request_id.ReadOnly = true;
            this.request_id.Visible = false;

            this.document_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.document_type.DataPropertyName = "document_type";
            this.document_type.FillWeight = 35F;
            this.document_type.HeaderText = "Document Requested";
            this.document_type.Name = "document_type";
            this.document_type.ReadOnly = true;

            this.resident_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.resident_name.DataPropertyName = "resident_name";
            this.resident_name.FillWeight = 30F;
            this.resident_name.HeaderText = "Resident Name";
            this.resident_name.Name = "resident_name";
            this.resident_name.ReadOnly = true;

            this.request_at.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.request_at.DataPropertyName = "formatted_date";
            this.request_at.FillWeight = 25F;
            this.request_at.HeaderText = "Date & Time Requested";
            this.request_at.Name = "request_at";
            this.request_at.ReadOnly = true;

            cellStyleReject.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            cellStyleReject.ForeColor = System.Drawing.Color.Crimson;
            cellStyleReject.SelectionForeColor = System.Drawing.Color.Crimson;
            this.btnReject.DefaultCellStyle = cellStyleReject;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.HeaderText = "Decline";
            this.btnReject.Name = "btnReject";
            this.btnReject.ReadOnly = true;
            this.btnReject.Text = "❌";
            this.btnReject.UseColumnTextForButtonValue = true;
            this.btnReject.Width = 65;

            cellStyleView.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            cellStyleView.ForeColor = System.Drawing.Color.DarkSlateBlue;
            cellStyleView.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            this.btnView.DefaultCellStyle = cellStyleView;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.HeaderText = "View";
            this.btnView.Name = "btnView";
            this.btnView.ReadOnly = true;
            this.btnView.Text = "👁️";
            this.btnView.UseColumnTextForButtonValue = true;
            this.btnView.Width = 55;

            cellStyleApprove.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            cellStyleApprove.ForeColor = System.Drawing.Color.ForestGreen;
            cellStyleApprove.SelectionForeColor = System.Drawing.Color.ForestGreen;
            this.btnApprove.DefaultCellStyle = cellStyleApprove;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.HeaderText = "Approve";
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.ReadOnly = true;
            this.btnApprove.Text = "✔️";
            this.btnApprove.UseColumnTextForButtonValue = true;
            this.btnApprove.Width = 65;

            this.dgvRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.request_id,
                this.document_type,
                this.resident_name,
                this.request_at,
                this.btnReject,
                this.btnView,
                this.btnApprove
            });

            // 
            // FLOATING DETAILS MODAL OVERLAY SETUP
            // 
            this.pnlModalOverlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlModalOverlay.Controls.Add(this.pnlModalCard);
            this.pnlModalOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModalOverlay.Location = new System.Drawing.Point(0, 0);
            this.pnlModalOverlay.Name = "pnlModalOverlay";
            this.pnlModalOverlay.Size = new System.Drawing.Size(635, 512);
            this.pnlModalOverlay.TabIndex = 99;
            this.pnlModalOverlay.Visible = false;

            this.pnlModalCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlModalCard.BackColor = System.Drawing.Color.White;
            this.pnlModalCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModalCard.Controls.Add(this.pnlModalHeader);
            this.pnlModalCard.Controls.Add(this.lblDetailResident);
            this.pnlModalCard.Controls.Add(this.lblDetailDocType);
            this.pnlModalCard.Controls.Add(this.lblDetailDate);
            this.pnlModalCard.Controls.Add(this.lblDetailPurposeTitle);
            this.pnlModalCard.Controls.Add(this.txtDetailPurpose);
            this.pnlModalCard.Controls.Add(this.lblDetailAttachmentTitle);
            this.pnlModalCard.Controls.Add(this.lblAttachmentName);
            this.pnlModalCard.Controls.Add(this.picAttachment);
            this.pnlModalCard.Controls.Add(this.pnlModalFooter);
            this.pnlModalCard.Location = new System.Drawing.Point(50, 25);
            this.pnlModalCard.Name = "pnlModalCard";
            this.pnlModalCard.Size = new System.Drawing.Size(535, 460);
            this.pnlModalCard.TabIndex = 0;

            this.pnlModalHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            this.pnlModalHeader.Controls.Add(this.lblModalTitle);
            this.pnlModalHeader.Controls.Add(this.btnModalCloseX);
            this.pnlModalHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlModalHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlModalHeader.Name = "pnlModalHeader";
            this.pnlModalHeader.Size = new System.Drawing.Size(533, 40);

            this.lblModalTitle.AutoSize = true;
            this.lblModalTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblModalTitle.ForeColor = System.Drawing.Color.White;
            this.lblModalTitle.Location = new System.Drawing.Point(15, 10);
            this.lblModalTitle.Text = "📄 Document Request Details";

            this.btnModalCloseX.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnModalCloseX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalCloseX.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnModalCloseX.ForeColor = System.Drawing.Color.White;
            this.btnModalCloseX.FlatAppearance.BorderSize = 0;
            this.btnModalCloseX.Size = new System.Drawing.Size(40, 40);
            this.btnModalCloseX.Text = "✕";
            this.btnModalCloseX.Click += new System.EventHandler(this.BtnModalClose_Click);

            this.lblDetailResident.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDetailResident.Location = new System.Drawing.Point(15, 52);
            this.lblDetailResident.Size = new System.Drawing.Size(250, 20);
            this.lblDetailResident.Text = "Resident: -";

            this.lblDetailDocType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDetailDocType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            this.lblDetailDocType.Location = new System.Drawing.Point(275, 52);
            this.lblDetailDocType.Size = new System.Drawing.Size(240, 20);
            this.lblDetailDocType.Text = "Document: -";

            this.lblDetailDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetailDate.ForeColor = System.Drawing.Color.DimGray;
            this.lblDetailDate.Location = new System.Drawing.Point(15, 76);
            this.lblDetailDate.Size = new System.Drawing.Size(500, 20);
            this.lblDetailDate.Text = "Requested: -";

            this.lblDetailPurposeTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetailPurposeTitle.Location = new System.Drawing.Point(15, 102);
            this.lblDetailPurposeTitle.Size = new System.Drawing.Size(100, 18);
            this.lblDetailPurposeTitle.Text = "Purpose:";

            this.txtDetailPurpose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtDetailPurpose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetailPurpose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDetailPurpose.Location = new System.Drawing.Point(15, 122);
            this.txtDetailPurpose.Multiline = true;
            this.txtDetailPurpose.ReadOnly = true;
            this.txtDetailPurpose.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetailPurpose.Size = new System.Drawing.Size(500, 52);

            this.lblDetailAttachmentTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetailAttachmentTitle.Location = new System.Drawing.Point(15, 182);
            this.lblDetailAttachmentTitle.Size = new System.Drawing.Size(150, 18);
            this.lblDetailAttachmentTitle.Text = "Attachment / Requirements:";

            this.lblAttachmentName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblAttachmentName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblAttachmentName.Location = new System.Drawing.Point(170, 182);
            this.lblAttachmentName.Size = new System.Drawing.Size(345, 18);
            this.lblAttachmentName.Text = "(No file uploaded)";

            this.picAttachment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.picAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAttachment.Location = new System.Drawing.Point(15, 204);
            this.picAttachment.Size = new System.Drawing.Size(500, 188);
            this.picAttachment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.pnlModalFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.pnlModalFooter.Controls.Add(this.btnModalApprove);
            this.pnlModalFooter.Controls.Add(this.btnModalDecline);
            this.pnlModalFooter.Controls.Add(this.btnModalClose);
            this.pnlModalFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlModalFooter.Location = new System.Drawing.Point(0, 408);
            this.pnlModalFooter.Name = "pnlModalFooter";
            this.pnlModalFooter.Size = new System.Drawing.Size(533, 50);

            this.btnModalApprove.BackColor = System.Drawing.Color.ForestGreen;
            this.btnModalApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalApprove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModalApprove.ForeColor = System.Drawing.Color.White;
            this.btnModalApprove.Location = new System.Drawing.Point(423, 10);
            this.btnModalApprove.Size = new System.Drawing.Size(95, 30);
            this.btnModalApprove.Text = "✔️ Approve";
            this.btnModalApprove.UseVisualStyleBackColor = false;
            this.btnModalApprove.Click += new System.EventHandler(this.BtnModalApprove_Click);

            this.btnModalDecline.BackColor = System.Drawing.Color.Crimson;
            this.btnModalDecline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalDecline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModalDecline.ForeColor = System.Drawing.Color.White;
            this.btnModalDecline.Location = new System.Drawing.Point(320, 10);
            this.btnModalDecline.Size = new System.Drawing.Size(95, 30);
            this.btnModalDecline.Text = "❌ Decline";
            this.btnModalDecline.UseVisualStyleBackColor = false;
            this.btnModalDecline.Click += new System.EventHandler(this.BtnModalDecline_Click);

            this.btnModalClose.BackColor = System.Drawing.Color.Gray;
            this.btnModalClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModalClose.ForeColor = System.Drawing.Color.White;
            this.btnModalClose.Location = new System.Drawing.Point(15, 10);
            this.btnModalClose.Size = new System.Drawing.Size(80, 30);
            this.btnModalClose.Text = "Close";
            this.btnModalClose.UseVisualStyleBackColor = false;
            this.btnModalClose.Click += new System.EventHandler(this.BtnModalClose_Click);

            // 
            // FLOATING REQUEST HISTORY MODAL OVERLAY SETUP
            // 
            this.pnlHistoryModalOverlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlHistoryModalOverlay.Controls.Add(this.pnlHistoryModalCard);
            this.pnlHistoryModalOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistoryModalOverlay.Location = new System.Drawing.Point(0, 0);
            this.pnlHistoryModalOverlay.Name = "pnlHistoryModalOverlay";
            this.pnlHistoryModalOverlay.Size = new System.Drawing.Size(635, 512);
            this.pnlHistoryModalOverlay.TabIndex = 100;
            this.pnlHistoryModalOverlay.Visible = false;

            // History Card Panel
            this.pnlHistoryModalCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlHistoryModalCard.BackColor = System.Drawing.Color.White;
            this.pnlHistoryModalCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHistoryModalCard.Controls.Add(this.dgvHistoryRequests);
            this.pnlHistoryModalCard.Controls.Add(this.pnlHistoryFilterBar);
            this.pnlHistoryModalCard.Controls.Add(this.pnlHistoryHeader);
            this.pnlHistoryModalCard.Controls.Add(this.pnlHistoryFooter);
            this.pnlHistoryModalCard.Location = new System.Drawing.Point(25, 20);
            this.pnlHistoryModalCard.Name = "pnlHistoryModalCard";
            this.pnlHistoryModalCard.Size = new System.Drawing.Size(585, 470);
            this.pnlHistoryModalCard.TabIndex = 0;

            // History Header
            this.pnlHistoryHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            this.pnlHistoryHeader.Controls.Add(this.lblHistoryTitle);
            this.pnlHistoryHeader.Controls.Add(this.btnHistoryCloseX);
            this.pnlHistoryHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHistoryHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHistoryHeader.Name = "pnlHistoryHeader";
            this.pnlHistoryHeader.Size = new System.Drawing.Size(583, 40);

            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.White;
            this.lblHistoryTitle.Location = new System.Drawing.Point(15, 10);
            this.lblHistoryTitle.Text = "📜 Processed Request History";

            this.btnHistoryCloseX.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHistoryCloseX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoryCloseX.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHistoryCloseX.ForeColor = System.Drawing.Color.White;
            this.btnHistoryCloseX.FlatAppearance.BorderSize = 0;
            this.btnHistoryCloseX.Size = new System.Drawing.Size(40, 40);
            this.btnHistoryCloseX.Text = "✕";
            this.btnHistoryCloseX.Click += new System.EventHandler(this.BtnHistoryClose_Click);

            // History Filter Bar
            this.pnlHistoryFilterBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlHistoryFilterBar.Controls.Add(this.lblHistoryFilterTitle);
            this.pnlHistoryFilterBar.Controls.Add(this.cmbHistoryStatusFilter);
            this.pnlHistoryFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHistoryFilterBar.Location = new System.Drawing.Point(0, 40);
            this.pnlHistoryFilterBar.Name = "pnlHistoryFilterBar";
            this.pnlHistoryFilterBar.Size = new System.Drawing.Size(583, 40);

            this.lblHistoryFilterTitle.AutoSize = true;
            this.lblHistoryFilterTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHistoryFilterTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblHistoryFilterTitle.Location = new System.Drawing.Point(15, 12);
            this.lblHistoryFilterTitle.Text = "Filter by Status:";

            this.cmbHistoryStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHistoryStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbHistoryStatusFilter.FormattingEnabled = true;
            this.cmbHistoryStatusFilter.Items.AddRange(new object[] { "All", "Approved", "Rejected" });
            this.cmbHistoryStatusFilter.Location = new System.Drawing.Point(110, 8);
            this.cmbHistoryStatusFilter.Name = "cmbHistoryStatusFilter";
            this.cmbHistoryStatusFilter.Size = new System.Drawing.Size(130, 23);
            this.cmbHistoryStatusFilter.SelectedIndexChanged += new System.EventHandler(this.CmbHistoryStatusFilter_SelectedIndexChanged);

            // History DataGridView
            this.dgvHistoryRequests.AllowUserToAddRows = false;
            this.dgvHistoryRequests.AllowUserToDeleteRows = false;
            this.dgvHistoryRequests.AllowUserToResizeRows = false;
            this.dgvHistoryRequests.AutoGenerateColumns = false;
            this.dgvHistoryRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistoryRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistoryRequests.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvHistoryRequests.EnableHeadersVisualStyles = false;
            cellStyleHistHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyleHistHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            cellStyleHistHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            cellStyleHistHeader.ForeColor = System.Drawing.Color.White;
            cellStyleHistHeader.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            cellStyleHistHeader.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHistoryRequests.ColumnHeadersDefaultCellStyle = cellStyleHistHeader;
            this.dgvHistoryRequests.ColumnHeadersHeight = 35;

            cellStyleHistDefault.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyleHistDefault.Font = new System.Drawing.Font("Segoe UI", 9F);
            cellStyleHistDefault.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            cellStyleHistDefault.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvHistoryRequests.DefaultCellStyle = cellStyleHistDefault;

            this.dgvHistoryRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistoryRequests.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvHistoryRequests.Location = new System.Drawing.Point(0, 80);
            this.dgvHistoryRequests.MultiSelect = false;
            this.dgvHistoryRequests.Name = "dgvHistoryRequests";
            this.dgvHistoryRequests.ReadOnly = true;
            this.dgvHistoryRequests.RowHeadersVisible = false;
            this.dgvHistoryRequests.RowTemplate.Height = 40;
            this.dgvHistoryRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistoryRequests.Size = new System.Drawing.Size(583, 340);
            this.dgvHistoryRequests.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvHistoryRequests_CellFormatting);

            // History Columns
            this.hist_request_id.DataPropertyName = "request_id";
            this.hist_request_id.HeaderText = "ID";
            this.hist_request_id.Name = "hist_request_id";
            this.hist_request_id.ReadOnly = true;
            this.hist_request_id.Width = 45;

            this.hist_resident_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hist_resident_name.DataPropertyName = "resident_name";
            this.hist_resident_name.FillWeight = 30F;
            this.hist_resident_name.HeaderText = "Resident Name";
            this.hist_resident_name.Name = "hist_resident_name";
            this.hist_resident_name.ReadOnly = true;

            this.hist_document_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hist_document_type.DataPropertyName = "document_type";
            this.hist_document_type.FillWeight = 35F;
            this.hist_document_type.HeaderText = "Document Requested";
            this.hist_document_type.Name = "hist_document_type";
            this.hist_document_type.ReadOnly = true;

            this.hist_status.DataPropertyName = "status";
            this.hist_status.HeaderText = "Status";
            this.hist_status.Name = "hist_status";
            this.hist_status.ReadOnly = true;
            this.hist_status.Width = 90;

            this.hist_formatted_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hist_formatted_date.DataPropertyName = "formatted_date";
            this.hist_formatted_date.FillWeight = 35F;
            this.hist_formatted_date.HeaderText = "Date Requested";
            this.hist_formatted_date.Name = "hist_formatted_date";
            this.hist_formatted_date.ReadOnly = true;

            this.dgvHistoryRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.hist_request_id,
                this.hist_resident_name,
                this.hist_document_type,
                this.hist_status,
                this.hist_formatted_date
            });

            // History Footer
            this.pnlHistoryFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.pnlHistoryFooter.Controls.Add(this.lblHistoryTotal);
            this.pnlHistoryFooter.Controls.Add(this.btnHistoryClose);
            this.pnlHistoryFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHistoryFooter.Location = new System.Drawing.Point(0, 420);
            this.pnlHistoryFooter.Name = "pnlHistoryFooter";
            this.pnlHistoryFooter.Size = new System.Drawing.Size(583, 48);

            this.lblHistoryTotal.AutoSize = true;
            this.lblHistoryTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTotal.ForeColor = System.Drawing.Color.DimGray;
            this.lblHistoryTotal.Location = new System.Drawing.Point(15, 16);
            this.lblHistoryTotal.Text = "Total History Records: 0";

            this.btnHistoryClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistoryClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            this.btnHistoryClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoryClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHistoryClose.ForeColor = System.Drawing.Color.White;
            this.btnHistoryClose.Location = new System.Drawing.Point(485, 10);
            this.btnHistoryClose.Size = new System.Drawing.Size(85, 28);
            this.btnHistoryClose.Text = "Close";
            this.btnHistoryClose.UseVisualStyleBackColor = false;
            this.btnHistoryClose.Click += new System.EventHandler(this.BtnHistoryClose_Click);

            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.lblTotalRequests);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 468);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(635, 44);
            this.footerPanel.TabIndex = 34;

            // 
            // lblTotalRequests
            // 
            this.lblTotalRequests.AutoSize = true;
            this.lblTotalRequests.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalRequests.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotalRequests.Location = new System.Drawing.Point(24, 12);
            this.lblTotalRequests.Name = "lblTotalRequests";
            this.lblTotalRequests.Size = new System.Drawing.Size(126, 17);
            this.lblTotalRequests.TabIndex = 6;
            this.lblTotalRequests.Text = "Total: 0 Request(s)";

            // 
            // dividerPanel
            // 
            this.dividerPanel.BackColor = System.Drawing.Color.Gray;
            this.dividerPanel.Location = new System.Drawing.Point(0, 86);
            this.dividerPanel.Name = "dividerPanel";
            this.dividerPanel.Size = new System.Drawing.Size(634, 1);
            this.dividerPanel.TabIndex = 33;

            // 
            // NavPanel
            // 
            this.NavPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NavPanel.Controls.Add(this.btnRequestHistory);
            this.NavPanel.Controls.Add(this.lblDate);
            this.NavPanel.Controls.Add(this.pendingReqLBL);
            this.NavPanel.Location = new System.Drawing.Point(0, 0);
            this.NavPanel.Name = "NavPanel";
            this.NavPanel.Size = new System.Drawing.Size(635, 83);
            this.NavPanel.TabIndex = 27;

            // 
            // btnRequestHistory
            // 
            this.btnRequestHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequestHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            this.btnRequestHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequestHistory.FlatAppearance.BorderSize = 0;
            this.btnRequestHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRequestHistory.ForeColor = System.Drawing.Color.White;
            this.btnRequestHistory.Location = new System.Drawing.Point(430, 42);
            this.btnRequestHistory.Name = "btnRequestHistory";
            this.btnRequestHistory.Size = new System.Drawing.Size(178, 30);
            this.btnRequestHistory.TabIndex = 37;
            this.btnRequestHistory.Text = "📜 Request History";
            this.btnRequestHistory.UseVisualStyleBackColor = false;
            this.btnRequestHistory.Click += new System.EventHandler(this.BtnRequestHistory_Click);

            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
            this.lblDate.ForeColor = System.Drawing.Color.DimGray;
            this.lblDate.Location = new System.Drawing.Point(420, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(188, 17);
            this.lblDate.TabIndex = 36;
            this.lblDate.Text = "📅 Date";

            // 
            // pendingReqLBL
            // 
            this.pendingReqLBL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pendingReqLBL.AutoSize = true;
            this.pendingReqLBL.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.pendingReqLBL.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.pendingReqLBL.Location = new System.Drawing.Point(24, 24);
            this.pendingReqLBL.Name = "pendingReqLBL";
            this.pendingReqLBL.Size = new System.Drawing.Size(206, 32);
            this.pendingReqLBL.TabIndex = 23;
            this.pendingReqLBL.Text = "Pending Request";

            // 
            // DocumentRequest Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelContainer);
            this.Name = "DocumentRequest";
            this.Size = new System.Drawing.Size(635, 512);

            this.PanelContainer.ResumeLayout(false);
            this.BodyGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.pnlModalOverlay.ResumeLayout(false);
            this.pnlModalCard.ResumeLayout(false);
            this.pnlModalCard.PerformLayout();
            this.pnlModalHeader.ResumeLayout(false);
            this.pnlModalHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAttachment)).EndInit();
            this.pnlModalFooter.ResumeLayout(false);
            this.pnlHistoryModalOverlay.ResumeLayout(false);
            this.pnlHistoryModalCard.ResumeLayout(false);
            this.pnlHistoryHeader.ResumeLayout(false);
            this.pnlHistoryHeader.PerformLayout();
            this.pnlHistoryFilterBar.ResumeLayout(false);
            this.pnlHistoryFilterBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryRequests)).EndInit();
            this.pnlHistoryFooter.ResumeLayout(false);
            this.pnlHistoryFooter.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.NavPanel.ResumeLayout(false);
            this.NavPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.GroupBox BodyGroupBox;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label lblTotalRequests;
        private System.Windows.Forms.Panel dividerPanel;
        private System.Windows.Forms.Panel NavPanel;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label pendingReqLBL;
        private System.Windows.Forms.Button btnRequestHistory;

        // DataGridView Columns
        private System.Windows.Forms.DataGridViewTextBoxColumn request_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn document_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn resident_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn request_at;
        private System.Windows.Forms.DataGridViewButtonColumn btnReject;
        private System.Windows.Forms.DataGridViewButtonColumn btnView;
        private System.Windows.Forms.DataGridViewButtonColumn btnApprove;

        // Overlay Modal Controls (Details)
        private System.Windows.Forms.Panel pnlModalOverlay;
        private System.Windows.Forms.Panel pnlModalCard;
        private System.Windows.Forms.Panel pnlModalHeader;
        private System.Windows.Forms.Label lblModalTitle;
        private System.Windows.Forms.Button btnModalCloseX;
        private System.Windows.Forms.Label lblDetailResident;
        private System.Windows.Forms.Label lblDetailDocType;
        private System.Windows.Forms.Label lblDetailDate;
        private System.Windows.Forms.Label lblDetailPurposeTitle;
        private System.Windows.Forms.TextBox txtDetailPurpose;
        private System.Windows.Forms.Label lblDetailAttachmentTitle;
        private System.Windows.Forms.Label lblAttachmentName;
        private System.Windows.Forms.PictureBox picAttachment;
        private System.Windows.Forms.Panel pnlModalFooter;
        private System.Windows.Forms.Button btnModalApprove;
        private System.Windows.Forms.Button btnModalDecline;
        private System.Windows.Forms.Button btnModalClose;

        // Overlay Modal Controls (Request History)
        private System.Windows.Forms.Panel pnlHistoryModalOverlay;
        private System.Windows.Forms.Panel pnlHistoryModalCard;
        private System.Windows.Forms.Panel pnlHistoryHeader;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.Button btnHistoryCloseX;
        private System.Windows.Forms.Panel pnlHistoryFilterBar;
        private System.Windows.Forms.Label lblHistoryFilterTitle;
        private System.Windows.Forms.ComboBox cmbHistoryStatusFilter;
        private System.Windows.Forms.DataGridView dgvHistoryRequests;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_request_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_resident_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_document_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_formatted_date;
        private System.Windows.Forms.Panel pnlHistoryFooter;
        private System.Windows.Forms.Label lblHistoryTotal;
        private System.Windows.Forms.Button btnHistoryClose;
    }
}