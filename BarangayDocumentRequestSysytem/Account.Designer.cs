namespace BarangayDocumentRequestSysytem
{
    partial class Account
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
            bodyGB = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            cancelButton = new Button();
            confirmBTN = new Button();
            brgyInfoTLP = new TableLayoutPanel();
            pwConfirmLabel = new Label();
            passwordLabel = new Label();
            usernameLabel = new Label();
            pwPanel = new Panel();
            passwordTXT = new TextBox();
            hidepwBTN = new Button();
            usernameTXT = new TextBox();
            panel1 = new Panel();
            hidePWConfirmBTN = new Button();
            pwConfirmTXT = new TextBox();
            bodyGB.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            brgyInfoTLP.SuspendLayout();
            pwPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // bodyGB
            // 
            bodyGB.Controls.Add(tableLayoutPanel1);
            bodyGB.Controls.Add(brgyInfoTLP);
            bodyGB.Dock = DockStyle.Fill;
            bodyGB.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bodyGB.Location = new Point(0, 0);
            bodyGB.Name = "bodyGB";
            bodyGB.Size = new Size(406, 403);
            bodyGB.TabIndex = 1;
            bodyGB.TabStop = false;
            bodyGB.Text = "Account Settings";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(cancelButton, 0, 0);
            tableLayoutPanel1.Controls.Add(confirmBTN, 1, 0);
            tableLayoutPanel1.Location = new Point(60, 324);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(295, 41);
            tableLayoutPanel1.TabIndex = 1;
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
            cancelButton.Size = new Size(141, 35);
            cancelButton.TabIndex = 34;
            cancelButton.Text = "❌ Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // confirmBTN
            // 
            confirmBTN.Anchor = AnchorStyles.Top;
            confirmBTN.BackColor = Color.DarkSlateBlue;
            confirmBTN.FlatStyle = FlatStyle.Flat;
            confirmBTN.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmBTN.ForeColor = Color.White;
            confirmBTN.Location = new Point(150, 3);
            confirmBTN.Name = "confirmBTN";
            confirmBTN.Size = new Size(142, 35);
            confirmBTN.TabIndex = 33;
            confirmBTN.Text = "✔ Confirm";
            confirmBTN.UseVisualStyleBackColor = false;
            // 
            // brgyInfoTLP
            // 
            brgyInfoTLP.Anchor = AnchorStyles.None;
            brgyInfoTLP.ColumnCount = 2;
            brgyInfoTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            brgyInfoTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            brgyInfoTLP.Controls.Add(pwConfirmLabel, 0, 2);
            brgyInfoTLP.Controls.Add(passwordLabel, 0, 1);
            brgyInfoTLP.Controls.Add(usernameLabel, 0, 0);
            brgyInfoTLP.Controls.Add(pwPanel, 1, 1);
            brgyInfoTLP.Controls.Add(usernameTXT, 1, 0);
            brgyInfoTLP.Controls.Add(panel1, 1, 2);
            brgyInfoTLP.Location = new Point(3, 23);
            brgyInfoTLP.Margin = new Padding(0);
            brgyInfoTLP.Name = "brgyInfoTLP";
            brgyInfoTLP.Padding = new Padding(5);
            brgyInfoTLP.RowCount = 3;
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            brgyInfoTLP.Size = new Size(400, 127);
            brgyInfoTLP.TabIndex = 0;
            // 
            // pwConfirmLabel
            // 
            pwConfirmLabel.AutoSize = true;
            pwConfirmLabel.Dock = DockStyle.Fill;
            pwConfirmLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            pwConfirmLabel.Location = new Point(8, 85);
            pwConfirmLabel.Name = "pwConfirmLabel";
            pwConfirmLabel.Size = new Size(189, 40);
            pwConfirmLabel.TabIndex = 3;
            pwConfirmLabel.Text = "Confirm Password : ";
            pwConfirmLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Dock = DockStyle.Fill;
            passwordLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            passwordLabel.Location = new Point(8, 45);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(189, 40);
            passwordLabel.TabIndex = 5;
            passwordLabel.Text = "Password :";
            passwordLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Dock = DockStyle.Fill;
            usernameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            usernameLabel.Location = new Point(8, 5);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(189, 40);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "Username :";
            usernameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pwPanel
            // 
            pwPanel.Controls.Add(passwordTXT);
            pwPanel.Controls.Add(hidepwBTN);
            pwPanel.Dock = DockStyle.Fill;
            pwPanel.Location = new Point(203, 48);
            pwPanel.Name = "pwPanel";
            pwPanel.Size = new Size(189, 34);
            pwPanel.TabIndex = 18;
            // 
            // passwordTXT
            // 
            passwordTXT.BorderStyle = BorderStyle.FixedSingle;
            passwordTXT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTXT.Location = new Point(3, 4);
            passwordTXT.Name = "passwordTXT";
            passwordTXT.Size = new Size(146, 25);
            passwordTXT.TabIndex = 18;
            passwordTXT.Text = "mjpascasio";
            passwordTXT.UseSystemPasswordChar = true;
            // 
            // hidepwBTN
            // 
            hidepwBTN.Location = new Point(155, 2);
            hidepwBTN.Name = "hidepwBTN";
            hidepwBTN.Size = new Size(31, 29);
            hidepwBTN.TabIndex = 17;
            hidepwBTN.Text = "👁️";
            hidepwBTN.UseVisualStyleBackColor = true;
            hidepwBTN.Click += hidepwBTN_Click;
            // 
            // usernameTXT
            // 
            usernameTXT.BorderStyle = BorderStyle.FixedSingle;
            usernameTXT.Dock = DockStyle.Fill;
            usernameTXT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameTXT.Location = new Point(203, 8);
            usernameTXT.Name = "usernameTXT";
            usernameTXT.Size = new Size(189, 25);
            usernameTXT.TabIndex = 19;
            usernameTXT.Text = "Mark Jamin Pascasio";
            // 
            // panel1
            // 
            panel1.Controls.Add(hidePWConfirmBTN);
            panel1.Controls.Add(pwConfirmTXT);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(203, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(189, 34);
            panel1.TabIndex = 20;
            // 
            // hidePWConfirmBTN
            // 
            hidePWConfirmBTN.Location = new Point(155, 2);
            hidePWConfirmBTN.Name = "hidePWConfirmBTN";
            hidePWConfirmBTN.Size = new Size(31, 29);
            hidePWConfirmBTN.TabIndex = 18;
            hidePWConfirmBTN.Text = "👁️";
            hidePWConfirmBTN.UseVisualStyleBackColor = true;
            hidePWConfirmBTN.Click += hidePWConfirmBTN_Click;
            // 
            // pwConfirmTXT
            // 
            pwConfirmTXT.BorderStyle = BorderStyle.FixedSingle;
            pwConfirmTXT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pwConfirmTXT.Location = new Point(3, 4);
            pwConfirmTXT.Name = "pwConfirmTXT";
            pwConfirmTXT.Size = new Size(146, 25);
            pwConfirmTXT.TabIndex = 20;
            pwConfirmTXT.Text = "mjpascasio";
            pwConfirmTXT.UseSystemPasswordChar = true;
            // 
            // Account
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bodyGB);
            Name = "Account";
            Size = new Size(406, 403);
            bodyGB.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            brgyInfoTLP.ResumeLayout(false);
            brgyInfoTLP.PerformLayout();
            pwPanel.ResumeLayout(false);
            pwPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox bodyGB;
        private TableLayoutPanel brgyInfoTLP;
        private Label brgyCaptLabel;
        private Label pwConfirmLabel;
        private Label passwordLabel;
        private Label usernameLabel;
        private Label username;
        private Label brgyCapt;
        private Label emailLabel;
        private Label email;
        private Label ohLabel;
        private Label oh;
        private Panel pwPanel;
        private Button hidepwBTN;
        private TextBox passwordTXT;
        private TextBox usernameTXT;
        private TextBox pwConfirmTXT;
        private Panel panel1;
        private Button hidePWConfirmBTN;
        private TableLayoutPanel tableLayoutPanel1;
        private Button confirmBTN;
        private Button cancelButton;
    }
}
