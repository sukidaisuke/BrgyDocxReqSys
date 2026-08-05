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
            cancelButton = new Button();
            addResidentButton = new Button();
            ReqInformationHeaderLabel = new Label();
            BodyGroupBox = new GroupBox();
            mnComboBox = new ComboBox();
            bdayDTP = new DateTimePicker();
            zoneComboBox = new ComboBox();
            ageComboBox = new ComboBox();
            cpComboBox = new TextBox();
            hnComboBox = new TextBox();
            lnTextBox = new TextBox();
            fnTextBox = new TextBox();
            cpLabel = new Label();
            hnLabel = new Label();
            zoneLabel = new Label();
            ageLabel = new Label();
            bdateLabel = new Label();
            lnLabel = new Label();
            mnLabel = new Label();
            fnLabel = new Label();
            NavPanel = new Panel();
            DocumentReqTitleLabel = new Label();
            PanelContainer.SuspendLayout();
            BodyGroupBox.SuspendLayout();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContainer
            // 
            PanelContainer.Controls.Add(cancelButton);
            PanelContainer.Controls.Add(addResidentButton);
            PanelContainer.Controls.Add(ReqInformationHeaderLabel);
            PanelContainer.Controls.Add(BodyGroupBox);
            PanelContainer.Controls.Add(NavPanel);
            PanelContainer.Dock = DockStyle.Fill;
            PanelContainer.Location = new Point(0, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(635, 512);
            PanelContainer.TabIndex = 0;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top;
            cancelButton.BackColor = Color.Red;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(340, 444);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(204, 39);
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
            addResidentButton.Location = new Point(89, 444);
            addResidentButton.Name = "addResidentButton";
            addResidentButton.Size = new Size(204, 39);
            addResidentButton.TabIndex = 32;
            addResidentButton.Text = "➕ Add Resident";
            addResidentButton.UseVisualStyleBackColor = false;
            // 
            // ReqInformationHeaderLabel
            // 
            ReqInformationHeaderLabel.AutoSize = true;
            ReqInformationHeaderLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ReqInformationHeaderLabel.Location = new Point(66, 112);
            ReqInformationHeaderLabel.Name = "ReqInformationHeaderLabel";
            ReqInformationHeaderLabel.Size = new Size(90, 17);
            ReqInformationHeaderLabel.TabIndex = 31;
            ReqInformationHeaderLabel.Text = "Add Resident";
            // 
            // BodyGroupBox
            // 
            BodyGroupBox.Controls.Add(mnComboBox);
            BodyGroupBox.Controls.Add(bdayDTP);
            BodyGroupBox.Controls.Add(zoneComboBox);
            BodyGroupBox.Controls.Add(ageComboBox);
            BodyGroupBox.Controls.Add(cpComboBox);
            BodyGroupBox.Controls.Add(hnComboBox);
            BodyGroupBox.Controls.Add(lnTextBox);
            BodyGroupBox.Controls.Add(fnTextBox);
            BodyGroupBox.Controls.Add(cpLabel);
            BodyGroupBox.Controls.Add(hnLabel);
            BodyGroupBox.Controls.Add(zoneLabel);
            BodyGroupBox.Controls.Add(ageLabel);
            BodyGroupBox.Controls.Add(bdateLabel);
            BodyGroupBox.Controls.Add(lnLabel);
            BodyGroupBox.Controls.Add(mnLabel);
            BodyGroupBox.Controls.Add(fnLabel);
            BodyGroupBox.Location = new Point(77, 131);
            BodyGroupBox.Name = "BodyGroupBox";
            BodyGroupBox.Size = new Size(481, 297);
            BodyGroupBox.TabIndex = 30;
            BodyGroupBox.TabStop = false;
            // 
            // mnComboBox
            // 
            mnComboBox.FormattingEnabled = true;
            mnComboBox.Location = new Point(147, 61);
            mnComboBox.Name = "mnComboBox";
            mnComboBox.Size = new Size(306, 23);
            mnComboBox.TabIndex = 43;
            // 
            // bdayDTP
            // 
            bdayDTP.Location = new Point(147, 126);
            bdayDTP.Name = "bdayDTP";
            bdayDTP.Size = new Size(306, 23);
            bdayDTP.TabIndex = 42;
            bdayDTP.ValueChanged += bdayDTP_ValueChanged;
            // 
            // zoneComboBox
            // 
            zoneComboBox.FormattingEnabled = true;
            zoneComboBox.Location = new Point(147, 189);
            zoneComboBox.Name = "zoneComboBox";
            zoneComboBox.Size = new Size(306, 23);
            zoneComboBox.TabIndex = 41;
            // 
            // ageComboBox
            // 
            ageComboBox.Enabled = false;
            ageComboBox.FormattingEnabled = true;
            ageComboBox.Location = new Point(147, 158);
            ageComboBox.Name = "ageComboBox";
            ageComboBox.Size = new Size(306, 23);
            ageComboBox.TabIndex = 40;
            // 
            // cpComboBox
            // 
            cpComboBox.Anchor = AnchorStyles.Top;
            cpComboBox.BorderStyle = BorderStyle.FixedSingle;
            cpComboBox.Location = new Point(147, 252);
            cpComboBox.Multiline = true;
            cpComboBox.Name = "cpComboBox";
            cpComboBox.PlaceholderText = "09 XXXXXXXXX";
            cpComboBox.Size = new Size(306, 23);
            cpComboBox.TabIndex = 39;
            cpComboBox.KeyPress += cpComboBox_KeyPress;
            // 
            // hnComboBox
            // 
            hnComboBox.Anchor = AnchorStyles.Top;
            hnComboBox.BorderStyle = BorderStyle.FixedSingle;
            hnComboBox.Location = new Point(147, 220);
            hnComboBox.Multiline = true;
            hnComboBox.Name = "hnComboBox";
            hnComboBox.Size = new Size(306, 23);
            hnComboBox.TabIndex = 38;
            hnComboBox.KeyPress += hnComboBox_KeyPress;
            // 
            // lnTextBox
            // 
            lnTextBox.Anchor = AnchorStyles.Top;
            lnTextBox.BorderStyle = BorderStyle.FixedSingle;
            lnTextBox.Location = new Point(147, 94);
            lnTextBox.Multiline = true;
            lnTextBox.Name = "lnTextBox";
            lnTextBox.PlaceholderText = "Dela Cruz";
            lnTextBox.Size = new Size(306, 23);
            lnTextBox.TabIndex = 34;
            // 
            // fnTextBox
            // 
            fnTextBox.Anchor = AnchorStyles.Top;
            fnTextBox.BorderStyle = BorderStyle.FixedSingle;
            fnTextBox.Location = new Point(147, 28);
            fnTextBox.Multiline = true;
            fnTextBox.Name = "fnTextBox";
            fnTextBox.PlaceholderText = "Juan";
            fnTextBox.Size = new Size(306, 23);
            fnTextBox.TabIndex = 32;
            // 
            // cpLabel
            // 
            cpLabel.Anchor = AnchorStyles.Top;
            cpLabel.AutoSize = true;
            cpLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cpLabel.Location = new Point(22, 260);
            cpLabel.Name = "cpLabel";
            cpLabel.Size = new Size(125, 15);
            cpLabel.TabIndex = 9;
            cpLabel.Text = "Cellphone Number* : ";
            // 
            // hnLabel
            // 
            hnLabel.Anchor = AnchorStyles.Top;
            hnLabel.AutoSize = true;
            hnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            hnLabel.Location = new Point(22, 228);
            hnLabel.Name = "hnLabel";
            hnLabel.Size = new Size(102, 15);
            hnLabel.TabIndex = 8;
            hnLabel.Text = "House Number* :";
            // 
            // zoneLabel
            // 
            zoneLabel.Anchor = AnchorStyles.Top;
            zoneLabel.AutoSize = true;
            zoneLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            zoneLabel.Location = new Point(22, 197);
            zoneLabel.Name = "zoneLabel";
            zoneLabel.Size = new Size(84, 15);
            zoneLabel.TabIndex = 7;
            zoneLabel.Text = "Zone/Purok* :";
            // 
            // ageLabel
            // 
            ageLabel.Anchor = AnchorStyles.Top;
            ageLabel.AutoSize = true;
            ageLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ageLabel.Location = new Point(22, 166);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(40, 15);
            ageLabel.TabIndex = 6;
            ageLabel.Text = "Age* :";
            // 
            // bdateLabel
            // 
            bdateLabel.Anchor = AnchorStyles.Top;
            bdateLabel.AutoSize = true;
            bdateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bdateLabel.Location = new Point(22, 134);
            bdateLabel.Name = "bdateLabel";
            bdateLabel.Size = new Size(71, 15);
            bdateLabel.TabIndex = 5;
            bdateLabel.Text = "Birthdate* :";
            // 
            // lnLabel
            // 
            lnLabel.Anchor = AnchorStyles.Top;
            lnLabel.AutoSize = true;
            lnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lnLabel.Location = new Point(22, 102);
            lnLabel.Name = "lnLabel";
            lnLabel.Size = new Size(76, 15);
            lnLabel.TabIndex = 4;
            lnLabel.Text = "Last Name* :";
            // 
            // mnLabel
            // 
            mnLabel.Anchor = AnchorStyles.Top;
            mnLabel.AutoSize = true;
            mnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            mnLabel.Location = new Point(22, 69);
            mnLabel.Name = "mnLabel";
            mnLabel.Size = new Size(87, 15);
            mnLabel.TabIndex = 3;
            mnLabel.Text = "Middle Name :";
            // 
            // fnLabel
            // 
            fnLabel.Anchor = AnchorStyles.Top;
            fnLabel.AutoSize = true;
            fnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            fnLabel.Location = new Point(22, 36);
            fnLabel.Name = "fnLabel";
            fnLabel.Size = new Size(78, 15);
            fnLabel.TabIndex = 2;
            fnLabel.Text = "First Name* :";
            // 
            // NavPanel
            // 
            NavPanel.BackColor = Color.DarkSlateBlue;
            NavPanel.Controls.Add(DocumentReqTitleLabel);
            NavPanel.Dock = DockStyle.Top;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(635, 100);
            NavPanel.TabIndex = 29;
            // 
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.Anchor = AnchorStyles.Top;
            DocumentReqTitleLabel.AutoSize = true;
            DocumentReqTitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DocumentReqTitleLabel.ForeColor = Color.White;
            DocumentReqTitleLabel.Location = new Point(66, 34);
            DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            DocumentReqTitleLabel.Size = new Size(106, 30);
            DocumentReqTitleLabel.TabIndex = 27;
            DocumentReqTitleLabel.Text = "Residents";
            // 
            // AddResident
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelContainer);
            Name = "AddResident";
            Size = new Size(635, 512);
            PanelContainer.ResumeLayout(false);
            PanelContainer.PerformLayout();
            BodyGroupBox.ResumeLayout(false);
            BodyGroupBox.PerformLayout();
            NavPanel.ResumeLayout(false);
            NavPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContainer;
        private Panel NavPanel;
        private Label DocumentReqTitleLabel;
        private GroupBox BodyGroupBox;
        private Label ReqInformationHeaderLabel;
        private Label fnLabel;
        private Label ageLabel;
        private Label bdateLabel;
        private Label lnLabel;
        private Label mnLabel;
        private Label cpLabel;
        private Label hnLabel;
        private Label zoneLabel;
        private TextBox fnTextBox;
        private DateTimePicker bdayDTP;
        private ComboBox zoneComboBox;
        private ComboBox ageComboBox;
        private TextBox cpComboBox;
        private TextBox hnComboBox;
        private TextBox lnTextBox;
        private Button cancelButton;
        private Button addResidentButton;
        private ComboBox mnComboBox;
    }
}
