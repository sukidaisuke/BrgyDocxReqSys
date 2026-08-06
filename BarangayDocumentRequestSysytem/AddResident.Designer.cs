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
            NavPanel = new Panel();
            nameLabel = new Label();
            DocumentReqTitleLabel = new Label();
            buttonsTBP = new TableLayoutPanel();
            clearButton = new Button();
            cancelButton = new Button();
            addResidentButton = new Button();
            BodyGroupBox = new GroupBox();
            ReqInformationHeaderLabel = new Label();
            bodyTB = new TableLayoutPanel();
            fnLabel = new Label();
            mnLabel = new Label();
            lnTable = new Label();
            bdayLabel = new Label();
            ageLabel = new Label();
            zoneLabel = new Label();
            hnLabel = new Label();
            cpLabel = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            PanelContainer.SuspendLayout();
            NavPanel.SuspendLayout();
            buttonsTBP.SuspendLayout();
            BodyGroupBox.SuspendLayout();
            bodyTB.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContainer
            // 
            PanelContainer.Controls.Add(NavPanel);
            PanelContainer.Controls.Add(buttonsTBP);
            PanelContainer.Controls.Add(BodyGroupBox);
            PanelContainer.Dock = DockStyle.Fill;
            PanelContainer.Location = new Point(0, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(635, 512);
            PanelContainer.TabIndex = 0;
            PanelContainer.Paint += PanelContainer_Paint;
            // 
            // NavPanel
            // 
            NavPanel.BackColor = Color.DarkSlateBlue;
            NavPanel.Controls.Add(nameLabel);
            NavPanel.Controls.Add(DocumentReqTitleLabel);
            NavPanel.Dock = DockStyle.Top;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(635, 100);
            NavPanel.TabIndex = 29;
            // 
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.Right;
            nameLabel.AutoSize = true;
            nameLabel.BackColor = Color.DarkSlateBlue;
            nameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.ForeColor = Color.DarkGray;
            nameLabel.Location = new Point(405, 12);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(213, 15);
            nameLabel.TabIndex = 28;
            nameLabel.Text = "Barangay Document Request System";
            // 
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.Anchor = AnchorStyles.Left;
            DocumentReqTitleLabel.AutoSize = true;
            DocumentReqTitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DocumentReqTitleLabel.ForeColor = Color.White;
            DocumentReqTitleLabel.Location = new Point(66, 34);
            DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            DocumentReqTitleLabel.Size = new Size(106, 30);
            DocumentReqTitleLabel.TabIndex = 27;
            DocumentReqTitleLabel.Text = "Residents";
            // 
            // buttonsTBP
            // 
            buttonsTBP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonsTBP.ColumnCount = 3;
            buttonsTBP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            buttonsTBP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            buttonsTBP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            buttonsTBP.Controls.Add(clearButton, 1, 0);
            buttonsTBP.Controls.Add(cancelButton, 0, 0);
            buttonsTBP.Controls.Add(addResidentButton, 2, 0);
            buttonsTBP.Location = new Point(77, 448);
            buttonsTBP.Name = "buttonsTBP";
            buttonsTBP.RowCount = 1;
            buttonsTBP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            buttonsTBP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            buttonsTBP.Size = new Size(481, 47);
            buttonsTBP.TabIndex = 34;
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
            BodyGroupBox.Anchor = AnchorStyles.None;
            BodyGroupBox.Controls.Add(ReqInformationHeaderLabel);
            BodyGroupBox.Controls.Add(bodyTB);
            BodyGroupBox.Location = new Point(77, 109);
            BodyGroupBox.Margin = new Padding(0);
            BodyGroupBox.Name = "BodyGroupBox";
            BodyGroupBox.Padding = new Padding(7);
            BodyGroupBox.Size = new Size(481, 326);
            BodyGroupBox.TabIndex = 30;
            BodyGroupBox.TabStop = false;
            // 
            // ReqInformationHeaderLabel
            // 
            ReqInformationHeaderLabel.AutoSize = true;
            ReqInformationHeaderLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ReqInformationHeaderLabel.Location = new Point(17, 4);
            ReqInformationHeaderLabel.Name = "ReqInformationHeaderLabel";
            ReqInformationHeaderLabel.Size = new Size(90, 17);
            ReqInformationHeaderLabel.TabIndex = 32;
            ReqInformationHeaderLabel.Text = "Add Resident";
            // 
            // bodyTB
            // 
            bodyTB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bodyTB.ColumnCount = 2;
            bodyTB.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            bodyTB.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            bodyTB.Controls.Add(fnLabel, 0, 0);
            bodyTB.Controls.Add(mnLabel, 0, 1);
            bodyTB.Controls.Add(lnTable, 0, 2);
            bodyTB.Controls.Add(bdayLabel, 0, 3);
            bodyTB.Controls.Add(ageLabel, 0, 4);
            bodyTB.Controls.Add(zoneLabel, 0, 5);
            bodyTB.Controls.Add(hnLabel, 0, 6);
            bodyTB.Controls.Add(cpLabel, 0, 7);
            bodyTB.Controls.Add(comboBox1, 1, 1);
            bodyTB.Controls.Add(comboBox2, 1, 5);
            bodyTB.Controls.Add(dateTimePicker1, 1, 3);
            bodyTB.Controls.Add(textBox1, 1, 0);
            bodyTB.Controls.Add(textBox2, 1, 2);
            bodyTB.Controls.Add(textBox3, 1, 4);
            bodyTB.Controls.Add(textBox4, 1, 6);
            bodyTB.Controls.Add(textBox5, 1, 7);
            bodyTB.Location = new Point(7, 30);
            bodyTB.Margin = new Padding(0);
            bodyTB.Name = "bodyTB";
            bodyTB.Padding = new Padding(10);
            bodyTB.RowCount = 9;
            bodyTB.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            bodyTB.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            bodyTB.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            bodyTB.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            bodyTB.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            bodyTB.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            bodyTB.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            bodyTB.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            bodyTB.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            bodyTB.Size = new Size(467, 296);
            bodyTB.TabIndex = 0;
            // 
            // fnLabel
            // 
            fnLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            fnLabel.AutoSize = true;
            fnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            fnLabel.Location = new Point(13, 20);
            fnLabel.Name = "fnLabel";
            fnLabel.Size = new Size(128, 15);
            fnLabel.TabIndex = 0;
            fnLabel.Text = "First Name* :";
            fnLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mnLabel
            // 
            mnLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            mnLabel.AutoSize = true;
            mnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            mnLabel.Location = new Point(13, 55);
            mnLabel.Name = "mnLabel";
            mnLabel.Size = new Size(128, 15);
            mnLabel.TabIndex = 1;
            mnLabel.Text = "Middle Name :";
            mnLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lnTable
            // 
            lnTable.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lnTable.AutoSize = true;
            lnTable.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lnTable.Location = new Point(13, 90);
            lnTable.Name = "lnTable";
            lnTable.Size = new Size(128, 15);
            lnTable.TabIndex = 2;
            lnTable.Text = "Last Name* :";
            lnTable.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bdayLabel
            // 
            bdayLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bdayLabel.AutoSize = true;
            bdayLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bdayLabel.Location = new Point(13, 125);
            bdayLabel.Name = "bdayLabel";
            bdayLabel.Size = new Size(128, 15);
            bdayLabel.TabIndex = 3;
            bdayLabel.Text = "Birthdate* :";
            bdayLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ageLabel
            // 
            ageLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ageLabel.AutoSize = true;
            ageLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ageLabel.Location = new Point(13, 160);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(128, 15);
            ageLabel.TabIndex = 4;
            ageLabel.Text = "Age :";
            ageLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // zoneLabel
            // 
            zoneLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            zoneLabel.AutoSize = true;
            zoneLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            zoneLabel.Location = new Point(13, 195);
            zoneLabel.Name = "zoneLabel";
            zoneLabel.Size = new Size(128, 15);
            zoneLabel.TabIndex = 5;
            zoneLabel.Text = "Zone/Purok* :";
            zoneLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // hnLabel
            // 
            hnLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hnLabel.AutoSize = true;
            hnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            hnLabel.Location = new Point(13, 230);
            hnLabel.Name = "hnLabel";
            hnLabel.Size = new Size(128, 15);
            hnLabel.TabIndex = 6;
            hnLabel.Text = "House Number* :";
            hnLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cpLabel
            // 
            cpLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cpLabel.AutoSize = true;
            cpLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cpLabel.Location = new Point(13, 265);
            cpLabel.Name = "cpLabel";
            cpLabel.Size = new Size(128, 15);
            cpLabel.TabIndex = 7;
            cpLabel.Text = "Cellphone Number* :";
            cpLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(147, 48);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(307, 23);
            comboBox1.TabIndex = 8;
            // 
            // comboBox2
            // 
            comboBox2.Dock = DockStyle.Fill;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(147, 188);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(307, 23);
            comboBox2.TabIndex = 10;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Dock = DockStyle.Fill;
            dateTimePicker1.Location = new Point(147, 118);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(307, 23);
            dateTimePicker1.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(147, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(307, 23);
            textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(147, 83);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(307, 23);
            textBox2.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(147, 153);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(307, 23);
            textBox3.TabIndex = 13;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Dock = DockStyle.Fill;
            textBox4.Location = new Point(147, 223);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(307, 23);
            textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Dock = DockStyle.Fill;
            textBox5.Location = new Point(147, 258);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(307, 23);
            textBox5.TabIndex = 15;
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
            buttonsTBP.ResumeLayout(false);
            BodyGroupBox.ResumeLayout(false);
            BodyGroupBox.PerformLayout();
            bodyTB.ResumeLayout(false);
            bodyTB.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContainer;
        private Panel NavPanel;
        private Label DocumentReqTitleLabel;
        private GroupBox BodyGroupBox;
        private Label nameLabel;
        private TableLayoutPanel bodyTB;
        private Label fnLabel;
        private Label mnLabel;
        private Label lnTable;
        private Label bdayLabel;
        private Label ageLabel;
        private Label zoneLabel;
        private Label hnLabel;
        private Label cpLabel;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label ReqInformationHeaderLabel;
        private TableLayoutPanel buttonsTBP;
        private Button clearButton;
        private Button cancelButton;
        private Button addResidentButton;
    }
}
