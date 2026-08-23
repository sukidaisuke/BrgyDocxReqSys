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
            panel1 = new Panel();
            nameLabel = new Label();
            DocumentReqTitleLabel = new Label();
            buttonsTLP = new TableLayoutPanel();
            clearButton = new Button();
            cancelButton = new Button();
            addResidentButton = new Button();
            BodyGroupBox = new GroupBox();
            addResidentLabel = new Label();
            bodyTLP = new TableLayoutPanel();
            fnLabel = new Label();
            mnLabel = new Label();
            lnTable = new Label();
            bdayLabel = new Label();
            zoneLabel = new Label();
            hnLabel = new Label();
            cpLabel = new Label();
            mnCB = new ComboBox();
            zoneCB = new ComboBox();
            bdayDTP = new DateTimePicker();
            fnTB = new TextBox();
            lnTB = new TextBox();
            hnTB = new TextBox();
            cpTB = new TextBox();
            PanelContainer.SuspendLayout();
            NavPanel.SuspendLayout();
            buttonsTLP.SuspendLayout();
            BodyGroupBox.SuspendLayout();
            bodyTLP.SuspendLayout();
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
            PanelContainer.Paint += PanelContainer_Paint;
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
            NavPanel.Controls.Add(panel1);
            NavPanel.Controls.Add(nameLabel);
            NavPanel.Controls.Add(DocumentReqTitleLabel);
            NavPanel.Dock = DockStyle.Top;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(635, 83);
            NavPanel.TabIndex = 29;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Location = new Point(0, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(634, 1);
            panel1.TabIndex = 34;
            // 
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.Right;
            nameLabel.AutoSize = true;
            nameLabel.BackColor = SystemColors.Control;
            nameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.ForeColor = Color.Gray;
            nameLabel.Location = new Point(408, 10);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(213, 15);
            nameLabel.TabIndex = 28;
            nameLabel.Text = "Barangay Document Request System";
            // 
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.Anchor = AnchorStyles.Left;
            DocumentReqTitleLabel.AutoSize = true;
            DocumentReqTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            DocumentReqTitleLabel.ForeColor = Color.DarkSlateBlue;
            DocumentReqTitleLabel.Location = new Point(66, 26);
            DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            DocumentReqTitleLabel.Size = new Size(123, 32);
            DocumentReqTitleLabel.TabIndex = 27;
            DocumentReqTitleLabel.Text = "Residents";
            // 
            // buttonsTLP
            // 
            buttonsTLP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonsTLP.ColumnCount = 3;
            buttonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            buttonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            buttonsTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            buttonsTLP.Controls.Add(clearButton, 1, 0);
            buttonsTLP.Controls.Add(cancelButton, 0, 0);
            buttonsTLP.Controls.Add(addResidentButton, 2, 0);
            buttonsTLP.Location = new Point(77, 448);
            buttonsTLP.Name = "buttonsTLP";
            buttonsTLP.RowCount = 1;
            buttonsTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            buttonsTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            buttonsTLP.Size = new Size(481, 47);
            buttonsTLP.TabIndex = 34;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Top;
            clearButton.BackColor = SystemColors.ControlDarkDark;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearButton.ForeColor = Color.White;
            clearButton.Location = new Point(163, 3);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(154, 41);
            clearButton.TabIndex = 35;
            clearButton.Text = "⌫ Clear";
            clearButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top;
            cancelButton.BackColor = Color.Red;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(3, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(154, 41);
            cancelButton.TabIndex = 33;
            cancelButton.Text = "❌ Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // addResidentButton
            // 
            addResidentButton.Anchor = AnchorStyles.Top;
            addResidentButton.BackColor = Color.DarkSlateBlue;
            addResidentButton.FlatStyle = FlatStyle.Flat;
            addResidentButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addResidentButton.ForeColor = Color.White;
            addResidentButton.Location = new Point(323, 3);
            addResidentButton.Name = "addResidentButton";
            addResidentButton.Size = new Size(155, 41);
            addResidentButton.TabIndex = 32;
            addResidentButton.Text = "➕ Add Resident";
            addResidentButton.UseVisualStyleBackColor = false;
            // 
            // BodyGroupBox
            // 
            BodyGroupBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BodyGroupBox.Controls.Add(addResidentLabel);
            BodyGroupBox.Controls.Add(bodyTLP);
            BodyGroupBox.Location = new Point(45, 104);
            BodyGroupBox.Margin = new Padding(0);
            BodyGroupBox.Name = "BodyGroupBox";
            BodyGroupBox.Padding = new Padding(7);
            BodyGroupBox.Size = new Size(550, 326);
            BodyGroupBox.TabIndex = 30;
            BodyGroupBox.TabStop = false;
            // 
            // addResidentLabel
            // 
            addResidentLabel.AutoSize = true;
            addResidentLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addResidentLabel.Location = new Point(17, 4);
            addResidentLabel.Name = "addResidentLabel";
            addResidentLabel.Size = new Size(90, 17);
            addResidentLabel.TabIndex = 32;
            addResidentLabel.Text = "Add Resident";
            // 
            // bodyTLP
            // 
            bodyTLP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bodyTLP.ColumnCount = 2;
            bodyTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            bodyTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            bodyTLP.Controls.Add(fnLabel, 0, 0);
            bodyTLP.Controls.Add(mnLabel, 0, 1);
            bodyTLP.Controls.Add(lnTable, 0, 2);
            bodyTLP.Controls.Add(bdayLabel, 0, 3);
            bodyTLP.Controls.Add(zoneLabel, 0, 4);
            bodyTLP.Controls.Add(hnLabel, 0, 5);
            bodyTLP.Controls.Add(cpLabel, 0, 6);
            bodyTLP.Controls.Add(mnCB, 1, 1);
            bodyTLP.Controls.Add(zoneCB, 1, 4);
            bodyTLP.Controls.Add(bdayDTP, 1, 3);
            bodyTLP.Controls.Add(fnTB, 1, 0);
            bodyTLP.Controls.Add(lnTB, 1, 2);
            bodyTLP.Controls.Add(hnTB, 1, 5);
            bodyTLP.Controls.Add(cpTB, 1, 6);
            bodyTLP.Location = new Point(7, 30);
            bodyTLP.Margin = new Padding(0);
            bodyTLP.Name = "bodyTLP";
            bodyTLP.Padding = new Padding(10);
            bodyTLP.RowCount = 7;
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            bodyTLP.Size = new Size(536, 289);
            bodyTLP.TabIndex = 0;
            // 
            // fnLabel
            // 
            fnLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            fnLabel.AutoSize = true;
            fnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            fnLabel.Location = new Point(13, 22);
            fnLabel.Name = "fnLabel";
            fnLabel.Size = new Size(148, 15);
            fnLabel.TabIndex = 0;
            fnLabel.Text = "First Name* :";
            fnLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mnLabel
            // 
            mnLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            mnLabel.AutoSize = true;
            mnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            mnLabel.Location = new Point(13, 62);
            mnLabel.Name = "mnLabel";
            mnLabel.Size = new Size(148, 15);
            mnLabel.TabIndex = 1;
            mnLabel.Text = "Middle Name :";
            mnLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lnTable
            // 
            lnTable.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lnTable.AutoSize = true;
            lnTable.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lnTable.Location = new Point(13, 102);
            lnTable.Name = "lnTable";
            lnTable.Size = new Size(148, 15);
            lnTable.TabIndex = 2;
            lnTable.Text = "Last Name* :";
            lnTable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bdayLabel
            // 
            bdayLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bdayLabel.AutoSize = true;
            bdayLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bdayLabel.Location = new Point(13, 142);
            bdayLabel.Name = "bdayLabel";
            bdayLabel.Size = new Size(148, 15);
            bdayLabel.TabIndex = 3;
            bdayLabel.Text = "Birthdate* :";
            bdayLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // zoneLabel
            // 
            zoneLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            zoneLabel.AutoSize = true;
            zoneLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            zoneLabel.Location = new Point(13, 182);
            zoneLabel.Name = "zoneLabel";
            zoneLabel.Size = new Size(148, 15);
            zoneLabel.TabIndex = 5;
            zoneLabel.Text = "Zone/Purok* :";
            zoneLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // hnLabel
            // 
            hnLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hnLabel.AutoSize = true;
            hnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            hnLabel.Location = new Point(13, 222);
            hnLabel.Name = "hnLabel";
            hnLabel.Size = new Size(148, 15);
            hnLabel.TabIndex = 6;
            hnLabel.Text = "House Number* :";
            hnLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cpLabel
            // 
            cpLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cpLabel.AutoSize = true;
            cpLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cpLabel.Location = new Point(13, 262);
            cpLabel.Name = "cpLabel";
            cpLabel.Size = new Size(148, 15);
            cpLabel.TabIndex = 7;
            cpLabel.Text = "Cellphone Number* :";
            cpLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mnCB
            // 
            mnCB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            mnCB.FormattingEnabled = true;
            mnCB.Location = new Point(167, 58);
            mnCB.Name = "mnCB";
            mnCB.Size = new Size(356, 23);
            mnCB.TabIndex = 8;
            // 
            // zoneCB
            // 
            zoneCB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            zoneCB.FormattingEnabled = true;
            zoneCB.Location = new Point(167, 178);
            zoneCB.Name = "zoneCB";
            zoneCB.Size = new Size(356, 23);
            zoneCB.TabIndex = 10;
            // 
            // bdayDTP
            // 
            bdayDTP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bdayDTP.Location = new Point(167, 138);
            bdayDTP.Name = "bdayDTP";
            bdayDTP.Size = new Size(356, 23);
            bdayDTP.TabIndex = 9;
            // 
            // fnTB
            // 
            fnTB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            fnTB.BorderStyle = BorderStyle.FixedSingle;
            fnTB.Location = new Point(167, 18);
            fnTB.Name = "fnTB";
            fnTB.PlaceholderText = "Juan";
            fnTB.Size = new Size(356, 23);
            fnTB.TabIndex = 11;
            // 
            // lnTB
            // 
            lnTB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lnTB.BorderStyle = BorderStyle.FixedSingle;
            lnTB.Location = new Point(167, 98);
            lnTB.Name = "lnTB";
            lnTB.PlaceholderText = "Dela Cruz";
            lnTB.Size = new Size(356, 23);
            lnTB.TabIndex = 12;
            // 
            // hnTB
            // 
            hnTB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hnTB.BorderStyle = BorderStyle.FixedSingle;
            hnTB.Location = new Point(167, 218);
            hnTB.Name = "hnTB";
            hnTB.Size = new Size(356, 23);
            hnTB.TabIndex = 14;
            hnTB.KeyPress += hnTB_KeyPress;
            // 
            // cpTB
            // 
            cpTB.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cpTB.BorderStyle = BorderStyle.FixedSingle;
            cpTB.Location = new Point(167, 258);
            cpTB.MaxLength = 11;
            cpTB.Name = "cpTB";
            cpTB.PlaceholderText = "09XXXXXXXXX";
            cpTB.Size = new Size(356, 23);
            cpTB.TabIndex = 15;
            cpTB.KeyPress += cpTB_KeyPress;
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
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContainer;
        private Panel NavPanel;
        private Label DocumentReqTitleLabel;
        private GroupBox BodyGroupBox;
        private Label nameLabel;
        private TableLayoutPanel bodyTLP;
        private Label fnLabel;
        private Label mnLabel;
        private Label lnTable;
        private Label bdayLabel;
        private Label hnLabel;
        private Label cpLabel;
        private ComboBox mnCB;
        private DateTimePicker bdayDTP;
        private TextBox fnTB;
        private TextBox lnTB;
        private TextBox hnTB;
        private TextBox cpTB;
        private Label addResidentLabel;
        private TableLayoutPanel buttonsTLP;
        private Button clearButton;
        private Button cancelButton;
        private Button addResidentButton;
        private Label zoneLabel;
        private ComboBox zoneCB;
        private Panel dividerPanel;
        private Panel panel1;
    }
}
