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
            NavPanel = new Panel();
            nameLabel = new Label();
            AddResidentButton = new Button();
            DocumentReqTitleLabel = new Label();
            bodyGB = new GroupBox();
            pageTLP = new TableLayoutPanel();
            sampleBTN5 = new Button();
            sampleBTN4 = new Button();
            sampleBTN3 = new Button();
            sampleBTN2 = new Button();
            sampleBTN1 = new Button();
            pageLBL = new Label();
            bodyTLP = new TableLayoutPanel();
            actionsTLP5 = new TableLayoutPanel();
            button7 = new Button();
            button8 = new Button();
            actionsTLP4 = new TableLayoutPanel();
            button5 = new Button();
            button6 = new Button();
            actionsTLP3 = new TableLayoutPanel();
            button3 = new Button();
            button4 = new Button();
            actionsTLP2 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            actionsTLP1 = new TableLayoutPanel();
            editBTN = new Button();
            trashBTN = new Button();
            addressLBL3 = new Label();
            addressLBL2 = new Label();
            addressLBL1 = new Label();
            cpnumberLBL2 = new Label();
            cpnumberLBL1 = new Label();
            nameLBL1 = new Label();
            addressLBL = new Label();
            cpnumberLBL = new Label();
            nameLBL = new Label();
            residentIdLBL = new Label();
            actionLBL = new Label();
            resLBL1 = new Label();
            resLBL2 = new Label();
            resLBL3 = new Label();
            resLBL4 = new Label();
            resLBL5 = new Label();
            nameLBL3 = new Label();
            nameLBL4 = new Label();
            label3 = new Label();
            cpnumberLBL3 = new Label();
            cpnumberLBL4 = new Label();
            cpnumberLBL5 = new Label();
            addressLBL4 = new Label();
            addressLBL5 = new Label();
            nameLBL2 = new Label();
            PanelContainer = new Panel();
            dividerPanel = new Panel();
            searchGB = new GroupBox();
            searchBTN = new Button();
            searchTB = new TextBox();
            NavPanel.SuspendLayout();
            bodyGB.SuspendLayout();
            pageTLP.SuspendLayout();
            bodyTLP.SuspendLayout();
            actionsTLP5.SuspendLayout();
            actionsTLP4.SuspendLayout();
            actionsTLP3.SuspendLayout();
            actionsTLP2.SuspendLayout();
            actionsTLP1.SuspendLayout();
            PanelContainer.SuspendLayout();
            searchGB.SuspendLayout();
            SuspendLayout();
            // 
            // NavPanel
            // 
            NavPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NavPanel.BackColor = SystemColors.Control;
            NavPanel.Controls.Add(nameLabel);
            NavPanel.Controls.Add(AddResidentButton);
            NavPanel.Controls.Add(DocumentReqTitleLabel);
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(635, 83);
            NavPanel.TabIndex = 28;
            NavPanel.Paint += NavPanel_Paint;
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
            nameLabel.Click += nameLabel_Click;
            // 
            // AddResidentButton
            // 
            AddResidentButton.Anchor = AnchorStyles.Right;
            AddResidentButton.BackColor = Color.DarkSlateBlue;
            AddResidentButton.FlatStyle = FlatStyle.Flat;
            AddResidentButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddResidentButton.ForeColor = Color.White;
            AddResidentButton.Location = new Point(473, 39);
            AddResidentButton.Name = "AddResidentButton";
            AddResidentButton.Size = new Size(119, 33);
            AddResidentButton.TabIndex = 28;
            AddResidentButton.Text = "➕ Add Resident";
            AddResidentButton.UseVisualStyleBackColor = false;
            AddResidentButton.Click += AddResidentButton_Click;
            // 
            // DocumentReqTitleLabel
            // 
            DocumentReqTitleLabel.Anchor = AnchorStyles.Left;
            DocumentReqTitleLabel.AutoSize = true;
            DocumentReqTitleLabel.BackColor = SystemColors.Control;
            DocumentReqTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DocumentReqTitleLabel.ForeColor = Color.DarkSlateBlue;
            DocumentReqTitleLabel.Location = new Point(66, 26);
            DocumentReqTitleLabel.Name = "DocumentReqTitleLabel";
            DocumentReqTitleLabel.Size = new Size(123, 32);
            DocumentReqTitleLabel.TabIndex = 27;
            DocumentReqTitleLabel.Text = "Residents";
            // 
            // bodyGB
            // 
            bodyGB.Controls.Add(pageTLP);
            bodyGB.Controls.Add(bodyTLP);
            bodyGB.Location = new Point(26, 157);
            bodyGB.Name = "bodyGB";
            bodyGB.Size = new Size(581, 315);
            bodyGB.TabIndex = 29;
            bodyGB.TabStop = false;
            // 
            // pageTLP
            // 
            pageTLP.ColumnCount = 6;
            pageTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 374F));
            pageTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            pageTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            pageTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            pageTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 42F));
            pageTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            pageTLP.Controls.Add(sampleBTN5, 5, 0);
            pageTLP.Controls.Add(sampleBTN4, 4, 0);
            pageTLP.Controls.Add(sampleBTN3, 3, 0);
            pageTLP.Controls.Add(sampleBTN2, 2, 0);
            pageTLP.Controls.Add(sampleBTN1, 1, 0);
            pageTLP.Controls.Add(pageLBL, 0, 0);
            pageTLP.Location = new Point(6, 272);
            pageTLP.Name = "pageTLP";
            pageTLP.RowCount = 1;
            pageTLP.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageTLP.Size = new Size(572, 35);
            pageTLP.TabIndex = 1;
            // 
            // sampleBTN5
            // 
            sampleBTN5.Anchor = AnchorStyles.None;
            sampleBTN5.FlatAppearance.BorderSize = 0;
            sampleBTN5.FlatStyle = FlatStyle.Flat;
            sampleBTN5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sampleBTN5.Location = new Point(535, 6);
            sampleBTN5.Name = "sampleBTN5";
            sampleBTN5.Size = new Size(34, 23);
            sampleBTN5.TabIndex = 5;
            sampleBTN5.Text = ">";
            sampleBTN5.UseVisualStyleBackColor = true;
            // 
            // sampleBTN4
            // 
            sampleBTN4.Anchor = AnchorStyles.None;
            sampleBTN4.FlatAppearance.BorderSize = 0;
            sampleBTN4.FlatStyle = FlatStyle.Flat;
            sampleBTN4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sampleBTN4.Location = new Point(494, 6);
            sampleBTN4.Name = "sampleBTN4";
            sampleBTN4.Size = new Size(34, 23);
            sampleBTN4.TabIndex = 4;
            sampleBTN4.Text = "4";
            sampleBTN4.UseVisualStyleBackColor = true;
            // 
            // sampleBTN3
            // 
            sampleBTN3.Anchor = AnchorStyles.None;
            sampleBTN3.FlatAppearance.BorderSize = 0;
            sampleBTN3.FlatStyle = FlatStyle.Flat;
            sampleBTN3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sampleBTN3.Location = new Point(453, 6);
            sampleBTN3.Name = "sampleBTN3";
            sampleBTN3.Size = new Size(34, 23);
            sampleBTN3.TabIndex = 3;
            sampleBTN3.Text = "3";
            sampleBTN3.UseVisualStyleBackColor = true;
            // 
            // sampleBTN2
            // 
            sampleBTN2.Anchor = AnchorStyles.None;
            sampleBTN2.FlatAppearance.BorderSize = 0;
            sampleBTN2.FlatStyle = FlatStyle.Flat;
            sampleBTN2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sampleBTN2.Location = new Point(415, 6);
            sampleBTN2.Name = "sampleBTN2";
            sampleBTN2.Size = new Size(32, 23);
            sampleBTN2.TabIndex = 2;
            sampleBTN2.Text = "2";
            sampleBTN2.UseVisualStyleBackColor = true;
            // 
            // sampleBTN1
            // 
            sampleBTN1.BackColor = Color.DarkSlateBlue;
            sampleBTN1.Dock = DockStyle.Fill;
            sampleBTN1.FlatAppearance.BorderSize = 0;
            sampleBTN1.FlatStyle = FlatStyle.Flat;
            sampleBTN1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sampleBTN1.ForeColor = Color.White;
            sampleBTN1.Location = new Point(377, 3);
            sampleBTN1.Name = "sampleBTN1";
            sampleBTN1.Size = new Size(32, 29);
            sampleBTN1.TabIndex = 1;
            sampleBTN1.Text = "1";
            sampleBTN1.UseVisualStyleBackColor = false;
            // 
            // pageLBL
            // 
            pageLBL.Anchor = AnchorStyles.Left;
            pageLBL.AutoSize = true;
            pageLBL.Location = new Point(3, 10);
            pageLBL.Name = "pageLBL";
            pageLBL.Size = new Size(179, 15);
            pageLBL.TabIndex = 6;
            pageLBL.Text = "Showing 1 to 5 out of 167 entries";
            // 
            // bodyTLP
            // 
            bodyTLP.ColumnCount = 5;
            bodyTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84F));
            bodyTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145F));
            bodyTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            bodyTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 166F));
            bodyTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            bodyTLP.Controls.Add(actionsTLP5, 4, 5);
            bodyTLP.Controls.Add(actionsTLP4, 4, 4);
            bodyTLP.Controls.Add(actionsTLP3, 4, 3);
            bodyTLP.Controls.Add(actionsTLP2, 4, 2);
            bodyTLP.Controls.Add(actionsTLP1, 4, 1);
            bodyTLP.Controls.Add(addressLBL3, 3, 3);
            bodyTLP.Controls.Add(addressLBL2, 3, 2);
            bodyTLP.Controls.Add(addressLBL1, 3, 1);
            bodyTLP.Controls.Add(cpnumberLBL2, 2, 2);
            bodyTLP.Controls.Add(cpnumberLBL1, 2, 1);
            bodyTLP.Controls.Add(nameLBL1, 1, 1);
            bodyTLP.Controls.Add(addressLBL, 3, 0);
            bodyTLP.Controls.Add(cpnumberLBL, 2, 0);
            bodyTLP.Controls.Add(nameLBL, 1, 0);
            bodyTLP.Controls.Add(residentIdLBL, 0, 0);
            bodyTLP.Controls.Add(actionLBL, 4, 0);
            bodyTLP.Controls.Add(resLBL1, 0, 1);
            bodyTLP.Controls.Add(resLBL2, 0, 2);
            bodyTLP.Controls.Add(resLBL3, 0, 3);
            bodyTLP.Controls.Add(resLBL4, 0, 4);
            bodyTLP.Controls.Add(resLBL5, 0, 5);
            bodyTLP.Controls.Add(nameLBL3, 1, 3);
            bodyTLP.Controls.Add(nameLBL4, 1, 4);
            bodyTLP.Controls.Add(label3, 1, 5);
            bodyTLP.Controls.Add(cpnumberLBL3, 2, 3);
            bodyTLP.Controls.Add(cpnumberLBL4, 2, 4);
            bodyTLP.Controls.Add(cpnumberLBL5, 2, 5);
            bodyTLP.Controls.Add(addressLBL4, 3, 4);
            bodyTLP.Controls.Add(addressLBL5, 3, 5);
            bodyTLP.Controls.Add(nameLBL2, 1, 2);
            bodyTLP.Location = new Point(6, 13);
            bodyTLP.Margin = new Padding(0);
            bodyTLP.Name = "bodyTLP";
            bodyTLP.RowCount = 6;
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            bodyTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            bodyTLP.Size = new Size(572, 259);
            bodyTLP.TabIndex = 0;
            // 
            // actionsTLP5
            // 
            actionsTLP5.ColumnCount = 2;
            actionsTLP5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actionsTLP5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actionsTLP5.Controls.Add(button7, 0, 0);
            actionsTLP5.Controls.Add(button8, 1, 0);
            actionsTLP5.Dock = DockStyle.Fill;
            actionsTLP5.Location = new Point(498, 218);
            actionsTLP5.Name = "actionsTLP5";
            actionsTLP5.RowCount = 1;
            actionsTLP5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            actionsTLP5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            actionsTLP5.Size = new Size(71, 39);
            actionsTLP5.TabIndex = 34;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Fill;
            button7.FlatAppearance.BorderSize = 0;
            button7.Location = new Point(3, 3);
            button7.Name = "button7";
            button7.Size = new Size(29, 33);
            button7.TabIndex = 0;
            button7.Text = "✏️";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Dock = DockStyle.Fill;
            button8.FlatAppearance.BorderSize = 0;
            button8.Location = new Point(38, 3);
            button8.Name = "button8";
            button8.Size = new Size(30, 33);
            button8.TabIndex = 1;
            button8.Text = "🗑️";
            button8.UseVisualStyleBackColor = true;
            // 
            // actionsTLP4
            // 
            actionsTLP4.ColumnCount = 2;
            actionsTLP4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actionsTLP4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actionsTLP4.Controls.Add(button5, 0, 0);
            actionsTLP4.Controls.Add(button6, 1, 0);
            actionsTLP4.Dock = DockStyle.Fill;
            actionsTLP4.Location = new Point(498, 173);
            actionsTLP4.Name = "actionsTLP4";
            actionsTLP4.RowCount = 1;
            actionsTLP4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            actionsTLP4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            actionsTLP4.Size = new Size(71, 39);
            actionsTLP4.TabIndex = 33;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.FlatAppearance.BorderSize = 0;
            button5.Location = new Point(3, 3);
            button5.Name = "button5";
            button5.Size = new Size(29, 33);
            button5.TabIndex = 0;
            button5.Text = "✏️";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Fill;
            button6.FlatAppearance.BorderSize = 0;
            button6.Location = new Point(38, 3);
            button6.Name = "button6";
            button6.Size = new Size(30, 33);
            button6.TabIndex = 1;
            button6.Text = "🗑️";
            button6.UseVisualStyleBackColor = true;
            // 
            // actionsTLP3
            // 
            actionsTLP3.ColumnCount = 2;
            actionsTLP3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actionsTLP3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actionsTLP3.Controls.Add(button3, 0, 0);
            actionsTLP3.Controls.Add(button4, 1, 0);
            actionsTLP3.Dock = DockStyle.Fill;
            actionsTLP3.Location = new Point(498, 128);
            actionsTLP3.Name = "actionsTLP3";
            actionsTLP3.RowCount = 1;
            actionsTLP3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            actionsTLP3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            actionsTLP3.Size = new Size(71, 39);
            actionsTLP3.TabIndex = 32;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.FlatAppearance.BorderSize = 0;
            button3.Location = new Point(3, 3);
            button3.Name = "button3";
            button3.Size = new Size(29, 33);
            button3.TabIndex = 0;
            button3.Text = "✏️";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.FlatAppearance.BorderSize = 0;
            button4.Location = new Point(38, 3);
            button4.Name = "button4";
            button4.Size = new Size(30, 33);
            button4.TabIndex = 1;
            button4.Text = "🗑️";
            button4.UseVisualStyleBackColor = true;
            // 
            // actionsTLP2
            // 
            actionsTLP2.ColumnCount = 2;
            actionsTLP2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actionsTLP2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actionsTLP2.Controls.Add(button1, 0, 0);
            actionsTLP2.Controls.Add(button2, 1, 0);
            actionsTLP2.Dock = DockStyle.Fill;
            actionsTLP2.Location = new Point(498, 83);
            actionsTLP2.Name = "actionsTLP2";
            actionsTLP2.RowCount = 1;
            actionsTLP2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            actionsTLP2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            actionsTLP2.Size = new Size(71, 39);
            actionsTLP2.TabIndex = 31;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.FlatAppearance.BorderSize = 0;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(29, 33);
            button1.TabIndex = 0;
            button1.Text = "✏️";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.FlatAppearance.BorderSize = 0;
            button2.Location = new Point(38, 3);
            button2.Name = "button2";
            button2.Size = new Size(30, 33);
            button2.TabIndex = 1;
            button2.Text = "🗑️";
            button2.UseVisualStyleBackColor = true;
            // 
            // actionsTLP1
            // 
            actionsTLP1.ColumnCount = 2;
            actionsTLP1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actionsTLP1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actionsTLP1.Controls.Add(editBTN, 0, 0);
            actionsTLP1.Controls.Add(trashBTN, 1, 0);
            actionsTLP1.Dock = DockStyle.Fill;
            actionsTLP1.Location = new Point(498, 38);
            actionsTLP1.Name = "actionsTLP1";
            actionsTLP1.RowCount = 1;
            actionsTLP1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            actionsTLP1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            actionsTLP1.Size = new Size(71, 39);
            actionsTLP1.TabIndex = 30;
            // 
            // editBTN
            // 
            editBTN.Dock = DockStyle.Fill;
            editBTN.FlatAppearance.BorderSize = 0;
            editBTN.Location = new Point(3, 3);
            editBTN.Name = "editBTN";
            editBTN.Size = new Size(29, 33);
            editBTN.TabIndex = 0;
            editBTN.Text = "✏️";
            editBTN.UseVisualStyleBackColor = true;
            // 
            // trashBTN
            // 
            trashBTN.Dock = DockStyle.Fill;
            trashBTN.FlatAppearance.BorderSize = 0;
            trashBTN.Location = new Point(38, 3);
            trashBTN.Name = "trashBTN";
            trashBTN.Size = new Size(30, 33);
            trashBTN.TabIndex = 1;
            trashBTN.Text = "🗑️";
            trashBTN.UseVisualStyleBackColor = true;
            // 
            // addressLBL3
            // 
            addressLBL3.Anchor = AnchorStyles.None;
            addressLBL3.AutoSize = true;
            addressLBL3.Location = new Point(343, 140);
            addressLBL3.Name = "addressLBL3";
            addressLBL3.Size = new Size(138, 15);
            addressLBL3.TabIndex = 24;
            addressLBL3.Text = "Purok 1, Barangay Sevilla";
            // 
            // addressLBL2
            // 
            addressLBL2.Anchor = AnchorStyles.None;
            addressLBL2.AutoSize = true;
            addressLBL2.Location = new Point(332, 95);
            addressLBL2.Name = "addressLBL2";
            addressLBL2.Size = new Size(159, 15);
            addressLBL2.TabIndex = 22;
            addressLBL2.Text = "Purok 2, Barangay Florentino";
            // 
            // addressLBL1
            // 
            addressLBL1.Anchor = AnchorStyles.None;
            addressLBL1.AutoSize = true;
            addressLBL1.Location = new Point(347, 50);
            addressLBL1.Name = "addressLBL1";
            addressLBL1.Size = new Size(130, 15);
            addressLBL1.TabIndex = 20;
            addressLBL1.Text = "Purok 1, Barangay Poro";
            // 
            // cpnumberLBL2
            // 
            cpnumberLBL2.Anchor = AnchorStyles.None;
            cpnumberLBL2.AutoSize = true;
            cpnumberLBL2.Location = new Point(237, 95);
            cpnumberLBL2.Name = "cpnumberLBL2";
            cpnumberLBL2.Size = new Size(83, 15);
            cpnumberLBL2.TabIndex = 18;
            cpnumberLBL2.Text = "0912-345-6789";
            // 
            // cpnumberLBL1
            // 
            cpnumberLBL1.Anchor = AnchorStyles.None;
            cpnumberLBL1.AutoSize = true;
            cpnumberLBL1.Location = new Point(237, 50);
            cpnumberLBL1.Name = "cpnumberLBL1";
            cpnumberLBL1.Size = new Size(83, 15);
            cpnumberLBL1.TabIndex = 15;
            cpnumberLBL1.Text = "0912-345-6789";
            // 
            // nameLBL1
            // 
            nameLBL1.Anchor = AnchorStyles.None;
            nameLBL1.AutoSize = true;
            nameLBL1.Location = new Point(91, 50);
            nameLBL1.Name = "nameLBL1";
            nameLBL1.Size = new Size(131, 15);
            nameLBL1.TabIndex = 10;
            nameLBL1.Text = "Mandy Casuga Gapasin";
            // 
            // addressLBL
            // 
            addressLBL.Anchor = AnchorStyles.None;
            addressLBL.AutoSize = true;
            addressLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addressLBL.Location = new Point(386, 10);
            addressLBL.Name = "addressLBL";
            addressLBL.Size = new Size(51, 15);
            addressLBL.TabIndex = 3;
            addressLBL.Text = "Address";
            addressLBL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cpnumberLBL
            // 
            cpnumberLBL.Anchor = AnchorStyles.None;
            cpnumberLBL.AutoSize = true;
            cpnumberLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cpnumberLBL.Location = new Point(252, 2);
            cpnumberLBL.Name = "cpnumberLBL";
            cpnumberLBL.Size = new Size(53, 30);
            cpnumberLBL.TabIndex = 2;
            cpnumberLBL.Text = "Contact Number";
            cpnumberLBL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nameLBL
            // 
            nameLBL.Anchor = AnchorStyles.None;
            nameLBL.AutoSize = true;
            nameLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLBL.Location = new Point(125, 10);
            nameLBL.Name = "nameLBL";
            nameLBL.Size = new Size(62, 15);
            nameLBL.TabIndex = 1;
            nameLBL.Text = "Full Name";
            nameLBL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // residentIdLBL
            // 
            residentIdLBL.Anchor = AnchorStyles.None;
            residentIdLBL.AutoSize = true;
            residentIdLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            residentIdLBL.Location = new Point(6, 10);
            residentIdLBL.Name = "residentIdLBL";
            residentIdLBL.Size = new Size(72, 15);
            residentIdLBL.TabIndex = 0;
            residentIdLBL.Text = "Resident ID";
            residentIdLBL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // actionLBL
            // 
            actionLBL.Anchor = AnchorStyles.None;
            actionLBL.AutoSize = true;
            actionLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            actionLBL.Location = new Point(509, 10);
            actionLBL.Name = "actionLBL";
            actionLBL.Size = new Size(48, 15);
            actionLBL.TabIndex = 4;
            actionLBL.Text = "Actions";
            // 
            // resLBL1
            // 
            resLBL1.Anchor = AnchorStyles.None;
            resLBL1.AutoSize = true;
            resLBL1.Location = new Point(17, 50);
            resLBL1.Name = "resLBL1";
            resLBL1.Size = new Size(49, 15);
            resLBL1.TabIndex = 5;
            resLBL1.Text = "RES-001";
            // 
            // resLBL2
            // 
            resLBL2.Anchor = AnchorStyles.None;
            resLBL2.AutoSize = true;
            resLBL2.Location = new Point(17, 95);
            resLBL2.Name = "resLBL2";
            resLBL2.Size = new Size(49, 15);
            resLBL2.TabIndex = 6;
            resLBL2.Text = "RES-002";
            // 
            // resLBL3
            // 
            resLBL3.Anchor = AnchorStyles.None;
            resLBL3.AutoSize = true;
            resLBL3.Location = new Point(17, 140);
            resLBL3.Name = "resLBL3";
            resLBL3.Size = new Size(49, 15);
            resLBL3.TabIndex = 7;
            resLBL3.Text = "RES-003";
            // 
            // resLBL4
            // 
            resLBL4.Anchor = AnchorStyles.None;
            resLBL4.AutoSize = true;
            resLBL4.Location = new Point(17, 185);
            resLBL4.Name = "resLBL4";
            resLBL4.Size = new Size(49, 15);
            resLBL4.TabIndex = 8;
            resLBL4.Text = "RES-004";
            // 
            // resLBL5
            // 
            resLBL5.Anchor = AnchorStyles.None;
            resLBL5.AutoSize = true;
            resLBL5.Location = new Point(17, 230);
            resLBL5.Name = "resLBL5";
            resLBL5.Size = new Size(49, 15);
            resLBL5.TabIndex = 9;
            resLBL5.Text = "RES-005";
            // 
            // nameLBL3
            // 
            nameLBL3.Anchor = AnchorStyles.None;
            nameLBL3.AutoSize = true;
            nameLBL3.Location = new Point(93, 140);
            nameLBL3.Name = "nameLBL3";
            nameLBL3.Size = new Size(127, 15);
            nameLBL3.TabIndex = 14;
            nameLBL3.Text = "Emson Tolentino Selda";
            // 
            // nameLBL4
            // 
            nameLBL4.Anchor = AnchorStyles.None;
            nameLBL4.AutoSize = true;
            nameLBL4.Location = new Point(106, 185);
            nameLBL4.Name = "nameLBL4";
            nameLBL4.Size = new Size(101, 15);
            nameLBL4.TabIndex = 12;
            nameLBL4.Text = "JM Pascasio Agan";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(88, 230);
            label3.Name = "label3";
            label3.Size = new Size(137, 15);
            label3.TabIndex = 13;
            label3.Text = "John Lawrence Balangue";
            // 
            // cpnumberLBL3
            // 
            cpnumberLBL3.Anchor = AnchorStyles.None;
            cpnumberLBL3.AutoSize = true;
            cpnumberLBL3.Location = new Point(237, 140);
            cpnumberLBL3.Name = "cpnumberLBL3";
            cpnumberLBL3.Size = new Size(83, 15);
            cpnumberLBL3.TabIndex = 16;
            cpnumberLBL3.Text = "0912-345-6789";
            // 
            // cpnumberLBL4
            // 
            cpnumberLBL4.Anchor = AnchorStyles.None;
            cpnumberLBL4.AutoSize = true;
            cpnumberLBL4.Location = new Point(237, 185);
            cpnumberLBL4.Name = "cpnumberLBL4";
            cpnumberLBL4.Size = new Size(83, 15);
            cpnumberLBL4.TabIndex = 19;
            cpnumberLBL4.Text = "0912-345-6789";
            // 
            // cpnumberLBL5
            // 
            cpnumberLBL5.Anchor = AnchorStyles.None;
            cpnumberLBL5.AutoSize = true;
            cpnumberLBL5.Location = new Point(237, 230);
            cpnumberLBL5.Name = "cpnumberLBL5";
            cpnumberLBL5.Size = new Size(83, 15);
            cpnumberLBL5.TabIndex = 17;
            cpnumberLBL5.Text = "0912-345-6789";
            // 
            // addressLBL4
            // 
            addressLBL4.Anchor = AnchorStyles.None;
            addressLBL4.AutoSize = true;
            addressLBL4.Location = new Point(343, 185);
            addressLBL4.Name = "addressLBL4";
            addressLBL4.Size = new Size(138, 15);
            addressLBL4.TabIndex = 21;
            addressLBL4.Text = "Purok 4, Barangay Sevilla";
            // 
            // addressLBL5
            // 
            addressLBL5.Anchor = AnchorStyles.None;
            addressLBL5.AutoSize = true;
            addressLBL5.Location = new Point(332, 230);
            addressLBL5.Name = "addressLBL5";
            addressLBL5.Size = new Size(159, 15);
            addressLBL5.TabIndex = 23;
            addressLBL5.Text = "Purok 1, Barangay Florentino";
            // 
            // nameLBL2
            // 
            nameLBL2.Anchor = AnchorStyles.None;
            nameLBL2.AutoSize = true;
            nameLBL2.Location = new Point(109, 95);
            nameLBL2.Name = "nameLBL2";
            nameLBL2.Size = new Size(95, 15);
            nameLBL2.TabIndex = 11;
            nameLBL2.Text = "Limuel Jacildone";
            // 
            // PanelContainer
            // 
            PanelContainer.BackgroundImageLayout = ImageLayout.None;
            PanelContainer.Controls.Add(dividerPanel);
            PanelContainer.Controls.Add(searchGB);
            PanelContainer.Controls.Add(bodyGB);
            PanelContainer.Controls.Add(NavPanel);
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
            dividerPanel.TabIndex = 31;
            // 
            // searchGB
            // 
            searchGB.Controls.Add(searchBTN);
            searchGB.Controls.Add(searchTB);
            searchGB.Location = new Point(26, 101);
            searchGB.Name = "searchGB";
            searchGB.Size = new Size(256, 41);
            searchGB.TabIndex = 30;
            searchGB.TabStop = false;
            // 
            // searchBTN
            // 
            searchBTN.FlatAppearance.BorderSize = 0;
            searchBTN.Location = new Point(219, 14);
            searchBTN.Name = "searchBTN";
            searchBTN.Size = new Size(31, 23);
            searchBTN.TabIndex = 31;
            searchBTN.Text = "🔍︎";
            searchBTN.UseVisualStyleBackColor = true;
            searchBTN.Click += searchBTN_Click;
            // 
            // searchTB
            // 
            searchTB.BorderStyle = BorderStyle.FixedSingle;
            searchTB.Location = new Point(7, 14);
            searchTB.Name = "searchTB";
            searchTB.PlaceholderText = "Search";
            searchTB.Size = new Size(211, 23);
            searchTB.TabIndex = 31;
            searchTB.TextChanged += searchTB_TextChanged;
            // 
            // Resident
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelContainer);
            Name = "Resident";
            Size = new Size(635, 512);
            NavPanel.ResumeLayout(false);
            NavPanel.PerformLayout();
            bodyGB.ResumeLayout(false);
            pageTLP.ResumeLayout(false);
            pageTLP.PerformLayout();
            bodyTLP.ResumeLayout(false);
            bodyTLP.PerformLayout();
            actionsTLP5.ResumeLayout(false);
            actionsTLP4.ResumeLayout(false);
            actionsTLP3.ResumeLayout(false);
            actionsTLP2.ResumeLayout(false);
            actionsTLP1.ResumeLayout(false);
            PanelContainer.ResumeLayout(false);
            searchGB.ResumeLayout(false);
            searchGB.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel NavPanel;
        private Label nameLabel;
        private Button AddResidentButton;
        private Label DocumentReqTitleLabel;
        private GroupBox bodyGB;
        private TableLayoutPanel pageTLP;
        private Button sampleBTN5;
        private Button sampleBTN4;
        private Button sampleBTN3;
        private Button sampleBTN2;
        private Button sampleBTN1;
        private Label pageLBL;
        private TableLayoutPanel bodyTLP;
        private Label addressLBL;
        private Label cpnumberLBL;
        private Label nameLBL;
        private Label residentIdLBL;
        private Label actionLBL;
        private Panel PanelContainer;
        private Label resLBL1;
        private Label resLBL2;
        private Label resLBL3;
        private Label resLBL4;
        private Label resLBL5;
        private Label nameLBL1;
        private Label nameLBL2;
        private Label nameLBL3;
        private Label nameLBL4;
        private Label label3;
        private Label addressLBL3;
        private Label addressLBL2;
        private Label addressLBL1;
        private Label cpnumberLBL2;
        private Label cpnumberLBL1;
        private Label cpnumberLBL3;
        private Label cpnumberLBL4;
        private Label cpnumberLBL5;
        private Label addressLBL4;
        private Label addressLBL5;
        private TableLayoutPanel actionsTLP1;
        private Button editBTN;
        private Button trashBTN;
        private TableLayoutPanel actionsTLP5;
        private Button button7;
        private Button button8;
        private TableLayoutPanel actionsTLP4;
        private Button button5;
        private Button button6;
        private TableLayoutPanel actionsTLP3;
        private Button button3;
        private Button button4;
        private TableLayoutPanel actionsTLP2;
        private Button button1;
        private Button button2;
        private GroupBox searchGB;
        private Button searchBTN;
        private TextBox searchTB;
        private Panel dividerPanel;
    }
}
