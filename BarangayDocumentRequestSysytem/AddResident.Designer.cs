namespace BarangayDocumentRequestSysytem
{
    partial class AddResident
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
            PanelContainer = new Panel();
            dividerPanel = new Panel();
            NavPanel = new Panel();
            lblDate = new Label();
            panel1 = new Panel();
            DocumentReqTitleLabel = new Label();
            buttonsTLP = new TableLayoutPanel();
            cancelButton = new Button();
            clearButton = new Button();
            updateButton = new Button();
            BodyGroupBox = new GroupBox();
            addResidentLabel = new Label();
            bodyTLP = new TableLayoutPanel();
            idLabel = new Label();
            searchContainer = new Panel();
            resIdTB = new TextBox();
            btnSearch = new Button();
            fnLabel = new Label();
            lblValFullName = new Label();
            addrLabel = new Label();
            lblValAddress = new Label();
            residencyLabel = new Label();
            residencyNUD = new NumericUpDown();
            voterLabel = new Label();
            voterCB = new ComboBox();
            PanelContainer.SuspendLayout();
            NavPanel.SuspendLayout();
            buttonsTLP.SuspendLayout();
            BodyGroupBox.SuspendLayout();
            bodyTLP.SuspendLayout();
            searchContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)residencyNUD).BeginInit();
            SuspendLayout();
            // 
            // PanelContainer
            // 
            PanelContainer.Controls.Add(dividerPanel);
            PanelContainer.Controls.Add(NavPanel);
            PanelContainer.Controls.Add(buttonsTLP);
            PanelContainer.Controls.Add(BodyGroupBox);
            PanelContainer.Dock = DockStyle.Fill;
            PanelContainer.Location = new Point(0, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(635, 512);
            PanelContainer.TabIndex = 0;
            // 
            // dividerPanel
            // 
            dividerPanel.BackColor = Color.Gray;
            dividerPanel.Location = new Point(0, 86);
            dividerPanel.Name = "dividerPanel";
            dividerPanel.Size = new Size(634, 1);
            dividerPanel.TabIndex = 35;
            // 
            // NavPanel
            // 
            NavPanel.BackColor = SystemColors.Control;
            NavPanel.Controls.Add(lblDate);
            NavPanel.Controls.Add(panel1);
            NavPanel.Controls.Add(DocumentReqTitleLabel);
            NavPanel.Dock = DockStyle.Top;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(635, 83);
            NavPanel.TabIndex = 29;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9.5F);
            lblDate.ForeColor = Color.DimGray;
            lblDate.Location = new Point(420, 12);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(57, 17);
            lblDate.TabIndex = 35;
            lblDate.Text = "📅 Date";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Location = new Point(0, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(634, 1);
            panel1.TabIndex = 36;
            // 
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.Anchor = AnchorStyles.Left;
            DocumentReqTitleLabel.AutoSize = true;
            DocumentReqTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            DocumentReqTitleLabel.ForeColor = Color.DarkSlateBlue;
            DocumentReqTitleLabel.Location = new Point(24, 24);
            DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            DocumentReqTitleLabel.Size = new Size(123, 32);
            DocumentReqTitleLabel.TabIndex = 37;
            DocumentReqTitleLabel.Text = "Residents";
            // 
            // buttonsTLP
            // 
            buttonsTLP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonsTLP.ColumnCount = 3;
            buttonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            buttonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            buttonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            buttonsTLP.Controls.Add(cancelButton, 0, 0);
            buttonsTLP.Controls.Add(clearButton, 1, 0);
            buttonsTLP.Controls.Add(updateButton, 2, 0);
            buttonsTLP.Location = new Point(77, 448);
            buttonsTLP.Name = "buttonsTLP";
            buttonsTLP.RowCount = 1;
            buttonsTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            buttonsTLP.Size = new Size(481, 47);
            buttonsTLP.TabIndex = 36;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top;
            cancelButton.BackColor = Color.Red;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(5, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(150, 40);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "❌ Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Top;
            clearButton.BackColor = SystemColors.ControlDarkDark;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            clearButton.ForeColor = Color.White;
            clearButton.Location = new Point(165, 3);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(150, 40);
            clearButton.TabIndex = 1;
            clearButton.Text = "⌫ Reset";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += clearButton_Click;
            // 
            // updateButton
            // 
            // updateButton
            this.updateButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.updateButton.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.updateButton.Enabled = false;
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.updateButton.ForeColor = System.Drawing.Color.White;
            this.updateButton.Location = new System.Drawing.Point(323, 3);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(155, 40);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "💾 Save Changes";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click); // <-- Wired up Click Event
            // 
            // BodyGroupBox
            // 
            BodyGroupBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BodyGroupBox.Controls.Add(addResidentLabel);
            BodyGroupBox.Controls.Add(bodyTLP);
            BodyGroupBox.Location = new Point(45, 104);
            BodyGroupBox.Name = "BodyGroupBox";
            BodyGroupBox.Padding = new Padding(10);
            BodyGroupBox.Size = new Size(545, 326);
            BodyGroupBox.TabIndex = 30;
            BodyGroupBox.TabStop = false;
            // 
            // addResidentLabel
            // 
            addResidentLabel.AutoSize = true;
            addResidentLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            addResidentLabel.ForeColor = Color.FromArgb(48, 44, 105);
            addResidentLabel.Location = new Point(15, 0);
            addResidentLabel.Name = "addResidentLabel";
            addResidentLabel.Size = new Size(240, 19);
            addResidentLabel.TabIndex = 0;
            addResidentLabel.Text = "🛠️ Modify Residency & Voter Status";
            // 
            // bodyTLP
            // 
            bodyTLP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bodyTLP.ColumnCount = 2;
            bodyTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            bodyTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68F));
            bodyTLP.Controls.Add(idLabel, 0, 0);
            bodyTLP.Controls.Add(searchContainer, 1, 0);
            bodyTLP.Controls.Add(fnLabel, 0, 1);
            bodyTLP.Controls.Add(lblValFullName, 1, 1);
            bodyTLP.Controls.Add(addrLabel, 0, 2);
            bodyTLP.Controls.Add(lblValAddress, 1, 2);
            bodyTLP.Controls.Add(residencyLabel, 0, 3);
            bodyTLP.Controls.Add(residencyNUD, 1, 3);
            bodyTLP.Controls.Add(voterLabel, 0, 4);
            bodyTLP.Controls.Add(voterCB, 1, 4);
            bodyTLP.Location = new Point(10, 28);
            bodyTLP.Name = "bodyTLP";
            bodyTLP.RowCount = 5;
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            bodyTLP.Size = new Size(525, 275);
            bodyTLP.TabIndex = 0;
            // 
            // idLabel
            // 
            idLabel.Anchor = AnchorStyles.Left;
            idLabel.AutoSize = true;
            idLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            idLabel.Location = new Point(3, 15);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(113, 15);
            idLabel.TabIndex = 0;
            idLabel.Text = "Enter Resident ID*:";
            // 
            // searchContainer
            // 
            searchContainer.Controls.Add(resIdTB);
            searchContainer.Controls.Add(btnSearch);
            searchContainer.Dock = DockStyle.Fill;
            searchContainer.Location = new Point(171, 3);
            searchContainer.Name = "searchContainer";
            searchContainer.Size = new Size(351, 39);
            searchContainer.TabIndex = 1;
            // 
            // resIdTB
            // 
            resIdTB.Location = new Point(0, 8);
            resIdTB.Name = "resIdTB";
            resIdTB.PlaceholderText = "e.g., RES-001 or 1";
            resIdTB.Size = new Size(230, 23);
            resIdTB.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DarkSlateBlue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(240, 7);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(95, 27);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // fnLabel
            // 
            fnLabel.Anchor = AnchorStyles.Left;
            fnLabel.AutoSize = true;
            fnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            fnLabel.Location = new Point(3, 60);
            fnLabel.Name = "fnLabel";
            fnLabel.Size = new Size(65, 15);
            fnLabel.TabIndex = 2;
            fnLabel.Text = "Full Name:";
            // 
            // lblValFullName
            // 
            lblValFullName.Anchor = AnchorStyles.Left;
            lblValFullName.AutoSize = true;
            lblValFullName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblValFullName.ForeColor = Color.FromArgb(48, 44, 105);
            lblValFullName.Location = new Point(171, 59);
            lblValFullName.Name = "lblValFullName";
            lblValFullName.Size = new Size(157, 17);
            lblValFullName.TabIndex = 3;
            lblValFullName.Text = "— Search Resident ID —";
            // 
            // addrLabel
            // 
            addrLabel.Anchor = AnchorStyles.Left;
            addrLabel.AutoSize = true;
            addrLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            addrLabel.Location = new Point(3, 105);
            addrLabel.Name = "addrLabel";
            addrLabel.Size = new Size(54, 15);
            addrLabel.TabIndex = 4;
            addrLabel.Text = "Address:";
            // 
            // lblValAddress
            // 
            lblValAddress.Anchor = AnchorStyles.Left;
            lblValAddress.AutoSize = true;
            lblValAddress.Font = new Font("Segoe UI", 9F);
            lblValAddress.ForeColor = Color.DimGray;
            lblValAddress.Location = new Point(171, 105);
            lblValAddress.Name = "lblValAddress";
            lblValAddress.Size = new Size(134, 15);
            lblValAddress.TabIndex = 5;
            lblValAddress.Text = "— Search Resident ID —";
            // 
            // residencyLabel
            // 
            residencyLabel.Anchor = AnchorStyles.Left;
            residencyLabel.AutoSize = true;
            residencyLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            residencyLabel.Location = new Point(3, 150);
            residencyLabel.Name = "residencyLabel";
            residencyLabel.Size = new Size(118, 15);
            residencyLabel.TabIndex = 6;
            residencyLabel.Text = "Years of Residency*:";
            // 
            // residencyNUD
            // 
            residencyNUD.Anchor = AnchorStyles.Left;
            residencyNUD.Location = new Point(171, 146);
            residencyNUD.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            residencyNUD.Name = "residencyNUD";
            residencyNUD.Size = new Size(120, 23);
            residencyNUD.TabIndex = 7;
            // 
            // voterLabel
            // 
            voterLabel.Anchor = AnchorStyles.Left;
            voterLabel.AutoSize = true;
            voterLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            voterLabel.Location = new Point(3, 220);
            voterLabel.Name = "voterLabel";
            voterLabel.Size = new Size(84, 15);
            voterLabel.TabIndex = 8;
            voterLabel.Text = "Voter Status*:";
            // 
            // voterCB
            // 
            voterCB.Anchor = AnchorStyles.Left;
            voterCB.DropDownStyle = ComboBoxStyle.DropDownList;
            voterCB.FormattingEnabled = true;
            voterCB.Items.AddRange(new object[] { "Yes", "No" });
            voterCB.Location = new Point(171, 216);
            voterCB.Name = "voterCB";
            voterCB.Size = new Size(180, 23);
            voterCB.TabIndex = 9;
            // 
            // AddResident
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelContainer);
            Name = "AddResident";
            Size = new Size(635, 512);
            PanelContainer.ResumeLayout(false);
            NavPanel.ResumeLayout(false);
            NavPanel.PerformLayout();
            buttonsTLP.ResumeLayout(false);
            BodyGroupBox.ResumeLayout(false);
            BodyGroupBox.PerformLayout();
            bodyTLP.ResumeLayout(false);
            bodyTLP.PerformLayout();
            searchContainer.ResumeLayout(false);
            searchContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)residencyNUD).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContainer;
        private GroupBox BodyGroupBox;
        private TableLayoutPanel bodyTLP;
        private Label addResidentLabel;
        private TableLayoutPanel buttonsTLP;
        private Button clearButton;
        private Button cancelButton;
        private Button updateButton;
        private Panel dividerPanel;
        private Panel NavPanel;
        private Label lblDate;
        private Panel panel1;
        private Label DocumentReqTitleLabel;

        // Custom CRUD controls
        private Label idLabel;
        private Panel searchContainer;
        private TextBox resIdTB;
        private Button btnSearch;
        private Label fnLabel;
        private Label lblValFullName;
        private Label addrLabel;
        private Label lblValAddress;
        private Label residencyLabel;
        private NumericUpDown residencyNUD;
        private Label voterLabel;
        private ComboBox voterCB;
    }
}