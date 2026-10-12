namespace BarangayDocumentRequestSysytem
{
    partial class Resident
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
            System.Windows.Forms.DataGridViewCellStyle cellStyleHeader = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleDefault = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleView = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleDelete = new System.Windows.Forms.DataGridViewCellStyle();

            this.NavPanel = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.AddResidentButton = new System.Windows.Forms.Button();
            this.DocumentReqTitleLabel = new System.Windows.Forms.Label();
            this.bodyGB = new System.Windows.Forms.GroupBox();
            this.dgvResidents = new System.Windows.Forms.DataGridView();
            this.user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formatted_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.full_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.full_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pageLBL = new System.Windows.Forms.Label();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.dividerPanel = new System.Windows.Forms.Panel();
            this.searchGB = new System.Windows.Forms.GroupBox();
            this.searchBTN = new System.Windows.Forms.Button();
            this.searchTB = new System.Windows.Forms.TextBox();

            // Modal Controls
            this.pnlModalOverlay = new System.Windows.Forms.Panel();
            this.pnlModalCard = new System.Windows.Forms.Panel();
            this.pnlModalHeader = new System.Windows.Forms.Panel();
            this.lblModalTitle = new System.Windows.Forms.Label();
            this.btnModalCloseX = new System.Windows.Forms.Button();
            this.pnlModalFooter = new System.Windows.Forms.Panel();
            this.btnModalClose = new System.Windows.Forms.Button();

            // Resident Info Details inside Modal
            this.lblCapFullName = new System.Windows.Forms.Label();
            this.lblValFullName = new System.Windows.Forms.Label();
            this.lblCapSex = new System.Windows.Forms.Label();
            this.lblValSex = new System.Windows.Forms.Label();
            this.lblCapBirthdate = new System.Windows.Forms.Label();
            this.lblValBirthdate = new System.Windows.Forms.Label();
            this.lblCapContact = new System.Windows.Forms.Label();
            this.lblValContact = new System.Windows.Forms.Label();
            this.lblCapAddress = new System.Windows.Forms.Label();
            this.lblValAddress = new System.Windows.Forms.Label();
            this.lblCapResidency = new System.Windows.Forms.Label();
            this.lblValResidency = new System.Windows.Forms.Label();
            this.lblCapVoter = new System.Windows.Forms.Label();
            this.lblValVoter = new System.Windows.Forms.Label();

            this.NavPanel.SuspendLayout();
            this.bodyGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidents)).BeginInit();
            this.PanelContainer.SuspendLayout();
            this.searchGB.SuspendLayout();
            this.pnlModalOverlay.SuspendLayout();
            this.pnlModalCard.SuspendLayout();
            this.pnlModalHeader.SuspendLayout();
            this.pnlModalFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // PanelContainer
            // 
            this.PanelContainer.Controls.Add(this.pnlModalOverlay);
            this.PanelContainer.Controls.Add(this.dividerPanel);
            this.PanelContainer.Controls.Add(this.searchGB);
            this.PanelContainer.Controls.Add(this.bodyGB);
            this.PanelContainer.Controls.Add(this.NavPanel);
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(635, 512);
            this.PanelContainer.TabIndex = 0;

            // 
            // NavPanel
            // 
            this.NavPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NavPanel.Controls.Add(this.lblDate);
            this.NavPanel.Controls.Add(this.AddResidentButton);
            this.NavPanel.Controls.Add(this.DocumentReqTitleLabel);
            this.NavPanel.Location = new System.Drawing.Point(0, 0);
            this.NavPanel.Name = "NavPanel";
            this.NavPanel.Size = new System.Drawing.Size(635, 83);
            this.NavPanel.TabIndex = 28;

            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDate.ForeColor = System.Drawing.Color.DimGray;
            this.lblDate.Location = new System.Drawing.Point(420, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(188, 17);
            this.lblDate.TabIndex = 37;
            this.lblDate.Text = "📅 Date";

            // 
            // AddResidentButton
            // 
            this.AddResidentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddResidentButton.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.AddResidentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddResidentButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.AddResidentButton.ForeColor = System.Drawing.Color.White;
            this.AddResidentButton.Location = new System.Drawing.Point(480, 39);
            this.AddResidentButton.Name = "AddResidentButton";
            this.AddResidentButton.Size = new System.Drawing.Size(130, 33);
            this.AddResidentButton.TabIndex = 28;
            this.AddResidentButton.Text = "➕ Add Resident";
            this.AddResidentButton.UseVisualStyleBackColor = false;
            this.AddResidentButton.Click += new System.EventHandler(this.AddResidentButton_Click);

            // 
            // DocumentReqTitleLabel
            // 
            this.DocumentReqTitleLabel.AutoSize = true;
            this.DocumentReqTitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.DocumentReqTitleLabel.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.DocumentReqTitleLabel.Location = new System.Drawing.Point(24, 24);
            this.DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            this.DocumentReqTitleLabel.Size = new System.Drawing.Size(123, 32);
            this.DocumentReqTitleLabel.TabIndex = 27;
            this.DocumentReqTitleLabel.Text = "Residents";

            // 
            // dividerPanel
            // 
            this.dividerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dividerPanel.Location = new System.Drawing.Point(0, 83);
            this.dividerPanel.Name = "dividerPanel";
            this.dividerPanel.Size = new System.Drawing.Size(635, 1);
            this.dividerPanel.TabIndex = 31;

            // 
            // searchGB
            // 
            this.searchGB.Controls.Add(this.searchBTN);
            this.searchGB.Controls.Add(this.searchTB);
            this.searchGB.Location = new System.Drawing.Point(26, 95);
            this.searchGB.Name = "searchGB";
            this.searchGB.Size = new System.Drawing.Size(256, 45);
            this.searchGB.TabIndex = 30;
            this.searchGB.TabStop = false;

            // 
            // searchBTN
            // 
            this.searchBTN.FlatAppearance.BorderSize = 0;
            this.searchBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBTN.Location = new System.Drawing.Point(219, 14);
            this.searchBTN.Name = "searchBTN";
            this.searchBTN.Size = new System.Drawing.Size(31, 23);
            this.searchBTN.TabIndex = 31;
            this.searchBTN.Text = "🔍";
            this.searchBTN.UseVisualStyleBackColor = true;
            this.searchBTN.Click += new System.EventHandler(this.searchBTN_Click);

            // 
            // searchTB
            // 
            this.searchTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTB.Location = new System.Drawing.Point(7, 14);
            this.searchTB.Name = "searchTB";
            this.searchTB.PlaceholderText = "Search resident...";
            this.searchTB.Size = new System.Drawing.Size(211, 23);
            this.searchTB.TabIndex = 31;
            this.searchTB.TextChanged += new System.EventHandler(this.searchTB_TextChanged);

            // 
            // bodyGB
            // 
            this.bodyGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bodyGB.Controls.Add(this.dgvResidents);
            this.bodyGB.Controls.Add(this.pageLBL);
            this.bodyGB.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.bodyGB.Location = new System.Drawing.Point(26, 145);
            this.bodyGB.Name = "bodyGB";
            this.bodyGB.Padding = new System.Windows.Forms.Padding(10);
            this.bodyGB.Size = new System.Drawing.Size(584, 345);
            this.bodyGB.TabIndex = 29;
            this.bodyGB.TabStop = false;
            this.bodyGB.Text = "Registered Residents List";

            // 
            // dgvResidents
            // 
            this.dgvResidents.AllowUserToAddRows = false;
            this.dgvResidents.AllowUserToDeleteRows = false;
            this.dgvResidents.AllowUserToResizeRows = false;
            this.dgvResidents.AutoGenerateColumns = false;
            this.dgvResidents.BackgroundColor = System.Drawing.Color.White;
            this.dgvResidents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResidents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvResidents.EnableHeadersVisualStyles = false;
            cellStyleHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyleHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            cellStyleHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            cellStyleHeader.ForeColor = System.Drawing.Color.White;
            cellStyleHeader.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            cellStyleHeader.SelectionForeColor = System.Drawing.Color.White;
            this.dgvResidents.ColumnHeadersDefaultCellStyle = cellStyleHeader;
            this.dgvResidents.ColumnHeadersHeight = 38;
            this.dgvResidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            cellStyleDefault.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyleDefault.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            cellStyleDefault.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            cellStyleDefault.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvResidents.DefaultCellStyle = cellStyleDefault;

            this.dgvResidents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResidents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvResidents.Location = new System.Drawing.Point(10, 27);
            this.dgvResidents.MultiSelect = false;
            this.dgvResidents.Name = "dgvResidents";
            this.dgvResidents.ReadOnly = true;
            this.dgvResidents.RowHeadersVisible = false;
            this.dgvResidents.RowTemplate.Height = 42;
            this.dgvResidents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResidents.Size = new System.Drawing.Size(564, 280);
            this.dgvResidents.TabIndex = 0;
            this.dgvResidents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvResidents_CellContentClick);

            // Columns Definition
            this.user_id.DataPropertyName = "user_id";
            this.user_id.HeaderText = "ID";
            this.user_id.Name = "user_id";
            this.user_id.ReadOnly = true;
            this.user_id.Visible = false;

            this.formatted_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.formatted_id.DataPropertyName = "formatted_id";
            this.formatted_id.HeaderText = "Resident ID";
            this.formatted_id.Name = "formatted_id";
            this.formatted_id.ReadOnly = true;
            this.formatted_id.Width = 90;

            this.full_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.full_name.DataPropertyName = "full_name";
            this.full_name.FillWeight = 35F;
            this.full_name.HeaderText = "Full Name";
            this.full_name.Name = "full_name";
            this.full_name.ReadOnly = true;

            this.contact_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.contact_no.DataPropertyName = "contact_no";
            this.contact_no.FillWeight = 25F;
            this.contact_no.HeaderText = "Contact Number";
            this.contact_no.Name = "contact_no";
            this.contact_no.ReadOnly = true;

            this.full_address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.full_address.DataPropertyName = "full_address";
            this.full_address.FillWeight = 40F;
            this.full_address.HeaderText = "Address";
            this.full_address.Name = "full_address";
            this.full_address.ReadOnly = true;

            // View Button (👁)
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

            // Delete Button (🗑️)
            cellStyleDelete.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            cellStyleDelete.ForeColor = System.Drawing.Color.Crimson;
            cellStyleDelete.SelectionForeColor = System.Drawing.Color.Crimson;
            this.btnDelete.DefaultCellStyle = cellStyleDelete;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.HeaderText = "Delete";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ReadOnly = true;
            this.btnDelete.Text = "🗑️";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 55;

            this.dgvResidents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.user_id,
                this.formatted_id,
                this.full_name,
                this.contact_no,
                this.full_address,
                this.btnView,
                this.btnDelete
            });

            // 
            // pageLBL
            // 
            this.pageLBL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageLBL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pageLBL.ForeColor = System.Drawing.Color.DimGray;
            this.pageLBL.Location = new System.Drawing.Point(10, 307);
            this.pageLBL.Name = "pageLBL";
            this.pageLBL.Size = new System.Drawing.Size(564, 28);
            this.pageLBL.TabIndex = 6;
            this.pageLBL.Text = "Total Residents Registered: 0";
            this.pageLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // MODAL OVERLAY SETUP (Proportioned to 635 x 512)
            // 
            this.pnlModalOverlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlModalOverlay.Controls.Add(this.pnlModalCard);
            this.pnlModalOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModalOverlay.Location = new System.Drawing.Point(0, 0);
            this.pnlModalOverlay.Name = "pnlModalOverlay";
            this.pnlModalOverlay.Size = new System.Drawing.Size(635, 512);
            this.pnlModalOverlay.TabIndex = 99;
            this.pnlModalOverlay.Visible = false;

            // Modal Card Panel (540 x 380)
            this.pnlModalCard.BackColor = System.Drawing.Color.White;
            this.pnlModalCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModalCard.Controls.Add(this.pnlModalHeader);
            this.pnlModalCard.Controls.Add(this.lblCapFullName);
            this.pnlModalCard.Controls.Add(this.lblValFullName);
            this.pnlModalCard.Controls.Add(this.lblCapSex);
            this.pnlModalCard.Controls.Add(this.lblValSex);
            this.pnlModalCard.Controls.Add(this.lblCapBirthdate);
            this.pnlModalCard.Controls.Add(this.lblValBirthdate);
            this.pnlModalCard.Controls.Add(this.lblCapContact);
            this.pnlModalCard.Controls.Add(this.lblValContact);
            this.pnlModalCard.Controls.Add(this.lblCapAddress);
            this.pnlModalCard.Controls.Add(this.lblValAddress);
            this.pnlModalCard.Controls.Add(this.lblCapResidency);
            this.pnlModalCard.Controls.Add(this.lblValResidency);
            this.pnlModalCard.Controls.Add(this.lblCapVoter);
            this.pnlModalCard.Controls.Add(this.lblValVoter);
            this.pnlModalCard.Controls.Add(this.pnlModalFooter);
            this.pnlModalCard.Location = new System.Drawing.Point(47, 66);
            this.pnlModalCard.Name = "pnlModalCard";
            this.pnlModalCard.Size = new System.Drawing.Size(540, 380);
            this.pnlModalCard.TabIndex = 0;

            // Modal Header
            this.pnlModalHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            this.pnlModalHeader.Controls.Add(this.lblModalTitle);
            this.pnlModalHeader.Controls.Add(this.btnModalCloseX);
            this.pnlModalHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlModalHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlModalHeader.Name = "pnlModalHeader";
            this.pnlModalHeader.Size = new System.Drawing.Size(538, 38);

            this.lblModalTitle.AutoSize = true;
            this.lblModalTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblModalTitle.ForeColor = System.Drawing.Color.White;
            this.lblModalTitle.Location = new System.Drawing.Point(12, 9);
            this.lblModalTitle.Text = "👤 Resident Information";

            this.btnModalCloseX.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnModalCloseX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalCloseX.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModalCloseX.ForeColor = System.Drawing.Color.White;
            this.btnModalCloseX.FlatAppearance.BorderSize = 0;
            this.btnModalCloseX.Size = new System.Drawing.Size(38, 38);
            this.btnModalCloseX.Text = "✕";
            this.btnModalCloseX.Click += new System.EventHandler(this.BtnModalClose_Click);

            // Resident Details Layout inside Modal
            // Full Name
            this.lblCapFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCapFullName.ForeColor = System.Drawing.Color.DimGray;
            this.lblCapFullName.Location = new System.Drawing.Point(24, 55);
            this.lblCapFullName.Size = new System.Drawing.Size(120, 20);
            this.lblCapFullName.Text = "Full Name:";

            this.lblValFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblValFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(105)))));
            this.lblValFullName.Location = new System.Drawing.Point(150, 55);
            this.lblValFullName.Size = new System.Drawing.Size(360, 20);
            this.lblValFullName.Text = "-";

            // Sex
            this.lblCapSex.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCapSex.ForeColor = System.Drawing.Color.DimGray;
            this.lblCapSex.Location = new System.Drawing.Point(24, 90);
            this.lblCapSex.Size = new System.Drawing.Size(120, 20);
            this.lblCapSex.Text = "Sex / Gender:";

            this.lblValSex.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValSex.Location = new System.Drawing.Point(150, 90);
            this.lblValSex.Size = new System.Drawing.Size(360, 20);
            this.lblValSex.Text = "-";

            // Birthdate
            this.lblCapBirthdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCapBirthdate.ForeColor = System.Drawing.Color.DimGray;
            this.lblCapBirthdate.Location = new System.Drawing.Point(24, 125);
            this.lblCapBirthdate.Size = new System.Drawing.Size(120, 20);
            this.lblCapBirthdate.Text = "Birth Date (Age):";

            this.lblValBirthdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValBirthdate.Location = new System.Drawing.Point(150, 125);
            this.lblValBirthdate.Size = new System.Drawing.Size(360, 20);
            this.lblValBirthdate.Text = "-";

            // Contact Number
            this.lblCapContact.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCapContact.ForeColor = System.Drawing.Color.DimGray;
            this.lblCapContact.Location = new System.Drawing.Point(24, 160);
            this.lblCapContact.Size = new System.Drawing.Size(120, 20);
            this.lblCapContact.Text = "Contact Number:";

            this.lblValContact.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValContact.Location = new System.Drawing.Point(150, 160);
            this.lblValContact.Size = new System.Drawing.Size(360, 20);
            this.lblValContact.Text = "-";

            // Complete Address
            this.lblCapAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCapAddress.ForeColor = System.Drawing.Color.DimGray;
            this.lblCapAddress.Location = new System.Drawing.Point(24, 195);
            this.lblCapAddress.Size = new System.Drawing.Size(120, 20);
            this.lblCapAddress.Text = "Complete Address:";

            this.lblValAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValAddress.Location = new System.Drawing.Point(150, 195);
            this.lblValAddress.Size = new System.Drawing.Size(360, 32);
            this.lblValAddress.Text = "-";

            // Years of Residency
            this.lblCapResidency.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCapResidency.ForeColor = System.Drawing.Color.DimGray;
            this.lblCapResidency.Location = new System.Drawing.Point(24, 235);
            this.lblCapResidency.Size = new System.Drawing.Size(120, 20);
            this.lblCapResidency.Text = "Residency Length:";

            this.lblValResidency.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValResidency.Location = new System.Drawing.Point(150, 235);
            this.lblValResidency.Size = new System.Drawing.Size(360, 20);
            this.lblValResidency.Text = "-";

            // Voter Status
            this.lblCapVoter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCapVoter.ForeColor = System.Drawing.Color.DimGray;
            this.lblCapVoter.Location = new System.Drawing.Point(24, 270);
            this.lblCapVoter.Size = new System.Drawing.Size(120, 20);
            this.lblCapVoter.Text = "Voter Status:";

            this.lblValVoter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblValVoter.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblValVoter.Location = new System.Drawing.Point(150, 270);
            this.lblValVoter.Size = new System.Drawing.Size(360, 20);
            this.lblValVoter.Text = "-";

            // Modal Footer
            this.pnlModalFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.pnlModalFooter.Controls.Add(this.btnModalClose);
            this.pnlModalFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlModalFooter.Location = new System.Drawing.Point(0, 333);
            this.pnlModalFooter.Name = "pnlModalFooter";
            this.pnlModalFooter.Size = new System.Drawing.Size(538, 45);

            this.btnModalClose.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnModalClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModalClose.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnModalClose.ForeColor = System.Drawing.Color.White;
            this.btnModalClose.Location = new System.Drawing.Point(433, 8);
            this.btnModalClose.Size = new System.Drawing.Size(85, 28);
            this.btnModalClose.Text = "Close";
            this.btnModalClose.UseVisualStyleBackColor = false;
            this.btnModalClose.Click += new System.EventHandler(this.BtnModalClose_Click);

            // 
            // Resident Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelContainer);
            this.Name = "Resident";
            this.Size = new System.Drawing.Size(635, 512);

            this.NavPanel.ResumeLayout(false);
            this.NavPanel.PerformLayout();
            this.bodyGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidents)).EndInit();
            this.PanelContainer.ResumeLayout(false);
            this.searchGB.ResumeLayout(false);
            this.searchGB.PerformLayout();
            this.pnlModalOverlay.ResumeLayout(false);
            this.pnlModalCard.ResumeLayout(false);
            this.pnlModalHeader.ResumeLayout(false);
            this.pnlModalHeader.PerformLayout();
            this.pnlModalFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel NavPanel;
        private System.Windows.Forms.Button AddResidentButton;
        private System.Windows.Forms.Label DocumentReqTitleLabel;
        private System.Windows.Forms.GroupBox bodyGB;
        private System.Windows.Forms.DataGridView dgvResidents;
        private System.Windows.Forms.Label pageLBL;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.GroupBox searchGB;
        private System.Windows.Forms.Button searchBTN;
        private System.Windows.Forms.TextBox searchTB;
        private System.Windows.Forms.Panel dividerPanel;
        private System.Windows.Forms.Label lblDate;

        // DataGridView Columns
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn formatted_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn full_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn full_address;
        private System.Windows.Forms.DataGridViewButtonColumn btnView;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;

        // Modal Controls
        private System.Windows.Forms.Panel pnlModalOverlay;
        private System.Windows.Forms.Panel pnlModalCard;
        private System.Windows.Forms.Panel pnlModalHeader;
        private System.Windows.Forms.Label lblModalTitle;
        private System.Windows.Forms.Button btnModalCloseX;
        private System.Windows.Forms.Panel pnlModalFooter;
        private System.Windows.Forms.Button btnModalClose;

        // Modal Details Labels
        private System.Windows.Forms.Label lblCapFullName;
        private System.Windows.Forms.Label lblValFullName;
        private System.Windows.Forms.Label lblCapSex;
        private System.Windows.Forms.Label lblValSex;
        private System.Windows.Forms.Label lblCapBirthdate;
        private System.Windows.Forms.Label lblValBirthdate;
        private System.Windows.Forms.Label lblCapContact;
        private System.Windows.Forms.Label lblValContact;
        private System.Windows.Forms.Label lblCapAddress;
        private System.Windows.Forms.Label lblValAddress;
        private System.Windows.Forms.Label lblCapResidency;
        private System.Windows.Forms.Label lblValResidency;
        private System.Windows.Forms.Label lblCapVoter;
        private System.Windows.Forms.Label lblValVoter;
    }
}