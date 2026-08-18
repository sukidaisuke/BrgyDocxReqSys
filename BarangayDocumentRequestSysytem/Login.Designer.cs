namespace BarangayDocumentRequestSysytem
{
    partial class Login
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            createAccountLink = new LinkLabel();
            label5 = new Label();
            label4 = new Label();
            loginButton = new Button();
            forgotPassword = new LinkLabel();
            rememberMe = new CheckBox();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            password = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            userName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            welcomeText = new Label();
            logoMain = new PictureBox();
            leftPanel = new PictureBox();
            btnShowPassword = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)leftPanel).BeginInit();
            SuspendLayout();
            // 
            // createAccountLink
            // 
            createAccountLink.AutoSize = true;
            createAccountLink.Cursor = Cursors.Hand;
            createAccountLink.Font = new Font("Gill Sans MT", 8.25F);
            createAccountLink.LinkColor = Color.DarkSlateBlue;
            createAccountLink.Location = new Point(490, 383);
            createAccountLink.Name = "createAccountLink";
            createAccountLink.Size = new Size(92, 16);
            createAccountLink.TabIndex = 29;
            createAccountLink.TabStop = true;
            createAccountLink.Text = "Create an account";
            createAccountLink.LinkClicked += createAccountLink_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Gill Sans MT", 8.25F);
            label5.ForeColor = Color.SlateGray;
            label5.Location = new Point(481, 361);
            label5.Name = "label5";
            label5.Size = new Size(115, 16);
            label5.TabIndex = 28;
            label5.Text = "Don't have an account?";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.SlateGray;
            label4.Location = new Point(431, 336);
            label4.Name = "label4";
            label4.Size = new Size(213, 16);
            label4.TabIndex = 27;
            label4.Text = "----------------------- OR -----------------------";
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.DarkSlateBlue;
            loginButton.Cursor = Cursors.Hand;
            loginButton.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginButton.ForeColor = SystemColors.ButtonHighlight;
            loginButton.Location = new Point(431, 285);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(216, 32);
            loginButton.TabIndex = 26;
            loginButton.Text = "Log In";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // forgotPassword
            // 
            forgotPassword.AutoSize = true;
            forgotPassword.Cursor = Cursors.Hand;
            forgotPassword.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            forgotPassword.LinkColor = Color.DarkSlateBlue;
            forgotPassword.Location = new Point(560, 249);
            forgotPassword.Name = "forgotPassword";
            forgotPassword.Size = new Size(87, 16);
            forgotPassword.TabIndex = 25;
            forgotPassword.TabStop = true;
            forgotPassword.Text = "Forgot Password?";
            forgotPassword.LinkClicked += forgotPassword_LinkClicked;
            // 
            // rememberMe
            // 
            rememberMe.AutoSize = true;
            rememberMe.Cursor = Cursors.Hand;
            rememberMe.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rememberMe.ForeColor = Color.SlateGray;
            rememberMe.Location = new Point(431, 252);
            rememberMe.Name = "rememberMe";
            rememberMe.Size = new Size(99, 17);
            rememberMe.TabIndex = 24;
            rememberMe.Text = "Remember Me";
            rememberMe.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(password);
            panel2.Font = new Font("Gill Sans MT", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel2.Location = new Point(431, 219);
            panel2.Name = "panel2";
            panel2.Size = new Size(216, 27);
            panel2.TabIndex = 23;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(18, 19);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // password
            // 
            password.BackColor = SystemColors.Control;
            password.BorderStyle = BorderStyle.None;
            password.Cursor = Cursors.IBeam;
            password.Font = new Font("Gill Sans MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            password.Location = new Point(32, 5);
            password.Margin = new Padding(8);
            password.Name = "password";
            password.Size = new Size(178, 14);
            password.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.SlateGray;
            label3.Location = new Point(431, 201);
            label3.Name = "label3";
            label3.Size = new Size(68, 18);
            label3.TabIndex = 22;
            label3.Text = "Password";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(userName);
            panel1.Font = new Font("Gill Sans MT", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(431, 163);
            panel1.Name = "panel1";
            panel1.Size = new Size(216, 26);
            panel1.TabIndex = 21;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 19);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // userName
            // 
            userName.BackColor = SystemColors.Control;
            userName.BorderStyle = BorderStyle.None;
            userName.Cursor = Cursors.IBeam;
            userName.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userName.Location = new Point(28, 5);
            userName.Margin = new Padding(8);
            userName.Name = "userName";
            userName.Size = new Size(179, 16);
            userName.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.SlateGray;
            label2.Location = new Point(431, 142);
            label2.Name = "label2";
            label2.Size = new Size(72, 18);
            label2.TabIndex = 20;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SlateGray;
            label1.Location = new Point(458, 104);
            label1.Name = "label1";
            label1.Size = new Size(169, 16);
            label1.TabIndex = 19;
            label1.Text = "Log in to your account to continue.";
            // 
            // welcomeText
            // 
            welcomeText.AutoSize = true;
            welcomeText.BackColor = Color.Transparent;
            welcomeText.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            welcomeText.ForeColor = Color.DarkSlateBlue;
            welcomeText.Location = new Point(489, 86);
            welcomeText.Margin = new Padding(4, 0, 4, 0);
            welcomeText.Name = "welcomeText";
            welcomeText.Size = new Size(110, 20);
            welcomeText.TabIndex = 17;
            welcomeText.Text = "Welcome Back!";
            // 
            // logoMain
            // 
            logoMain.Image = (Image)resources.GetObject("logoMain.Image");
            logoMain.Location = new Point(484, 44);
            logoMain.Margin = new Padding(4, 5, 4, 5);
            logoMain.Name = "logoMain";
            logoMain.Size = new Size(119, 39);
            logoMain.SizeMode = PictureBoxSizeMode.Zoom;
            logoMain.TabIndex = 16;
            logoMain.TabStop = false;
            // 
            // leftPanel
            // 
            leftPanel.Image = (Image)resources.GetObject("leftPanel.Image");
            leftPanel.Location = new Point(-22, -108);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(303, 692);
            leftPanel.SizeMode = PictureBoxSizeMode.Zoom;
            leftPanel.TabIndex = 30;
            leftPanel.TabStop = false;
            // 
            // btnShowPassword
            // 
            btnShowPassword.BackColor = SystemColors.Control;
            btnShowPassword.Location = new Point(652, 221);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(28, 23);
            btnShowPassword.TabIndex = 31;
            btnShowPassword.Text = "👁";
            btnShowPassword.UseVisualStyleBackColor = false;
            btnShowPassword.Click += button1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(800, 450);
            Controls.Add(btnShowPassword);
            Controls.Add(leftPanel);
            Controls.Add(createAccountLink);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(loginButton);
            Controls.Add(forgotPassword);
            Controls.Add(rememberMe);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(welcomeText);
            Controls.Add(logoMain);
            MaximizeBox = false;
            Name = "Login";
            Text = "Barangay Document Request System";
            Load += Login_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)leftPanel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel createAccountLink;
        private Label label5;
        private Label label4;
        private Button loginButton;
        private LinkLabel forgotPassword;
        private CheckBox rememberMe;
        private Panel panel2;
        private PictureBox pictureBox2;
        private TextBox password;
        private Label label3;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TextBox userName;
        private Label label2;
        private Label label1;
        private Label welcomeText;
        private PictureBox logoMain;
        private PictureBox leftPanel;
        private Button btnShowPassword;
    }
}