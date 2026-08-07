namespace BarangayDocumentRequestSysytem
{
    partial class Registration
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            welcomeText = new Label();
            leftPanel = new PictureBox();
            label1 = new Label();
            label5 = new Label();
            linkLabel2 = new LinkLabel();
            userRegistrationPanel = new Panel();
            label19 = new Label();
            label18 = new Label();
            securityAnswer = new TextBox();
            label17 = new Label();
            label16 = new Label();
            securityQuestions = new ComboBox();
            label15 = new Label();
            houseNumber = new TextBox();
            label14 = new Label();
            contactNumber = new TextBox();
            label13 = new Label();
            purokNumber = new ComboBox();
            label12 = new Label();
            birthDate = new DateTimePicker();
            label11 = new Label();
            sexIdentification = new ComboBox();
            label10 = new Label();
            lastName = new TextBox();
            label9 = new Label();
            middleName = new TextBox();
            label8 = new Label();
            firstName = new TextBox();
            label7 = new Label();
            confirmPassword = new TextBox();
            label6 = new Label();
            createPassword = new TextBox();
            label3 = new Label();
            createUsername = new TextBox();
            label2 = new Label();
            logoMain = new PictureBox();
            button2 = new Button();
            label21 = new Label();
            linkLabel1 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)leftPanel).BeginInit();
            userRegistrationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoMain).BeginInit();
            SuspendLayout();
            // 
            // welcomeText
            // 
            welcomeText.AutoSize = true;
            welcomeText.BackColor = Color.Transparent;
            welcomeText.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            welcomeText.ForeColor = Color.DarkSlateBlue;
            welcomeText.Location = new Point(489, 8);
            welcomeText.Margin = new Padding(4, 0, 4, 0);
            welcomeText.Name = "welcomeText";
            welcomeText.Size = new Size(108, 20);
            welcomeText.TabIndex = 3;
            welcomeText.Text = "Create Account";
            welcomeText.Click += label1_Click;
            // 
            // leftPanel
            // 
            leftPanel.Image = (Image)resources.GetObject("leftPanel.Image");
            leftPanel.Location = new Point(-22, -111);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(303, 692);
            leftPanel.SizeMode = PictureBoxSizeMode.Zoom;
            leftPanel.TabIndex = 4;
            leftPanel.TabStop = false;
            leftPanel.Click += leftPanel_Click_2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Gill Sans MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SlateGray;
            label1.Location = new Point(459, 22);
            label1.Name = "label1";
            label1.Size = new Size(168, 18);
            label1.TabIndex = 5;
            label1.Text = "Create an acount to continue";
            label1.Click += label1_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.SlateGray;
            label5.Location = new Point(1205, 955);
            label5.Name = "label5";
            label5.Size = new Size(174, 23);
            label5.TabIndex = 14;
            label5.Text = "Already have an account?";
            label5.Click += label5_Click;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Cursor = Cursors.Hand;
            linkLabel2.LinkColor = Color.DarkSlateBlue;
            linkLabel2.Location = new Point(1231, 988);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(123, 23);
            linkLabel2.TabIndex = 15;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Log in to account";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // userRegistrationPanel
            // 
            userRegistrationPanel.BackColor = SystemColors.ControlLightLight;
            userRegistrationPanel.Controls.Add(label19);
            userRegistrationPanel.Controls.Add(label18);
            userRegistrationPanel.Controls.Add(securityAnswer);
            userRegistrationPanel.Controls.Add(label17);
            userRegistrationPanel.Controls.Add(label16);
            userRegistrationPanel.Controls.Add(securityQuestions);
            userRegistrationPanel.Controls.Add(label15);
            userRegistrationPanel.Controls.Add(houseNumber);
            userRegistrationPanel.Controls.Add(label14);
            userRegistrationPanel.Controls.Add(contactNumber);
            userRegistrationPanel.Controls.Add(label13);
            userRegistrationPanel.Controls.Add(purokNumber);
            userRegistrationPanel.Controls.Add(label12);
            userRegistrationPanel.Controls.Add(birthDate);
            userRegistrationPanel.Controls.Add(label11);
            userRegistrationPanel.Controls.Add(sexIdentification);
            userRegistrationPanel.Controls.Add(label10);
            userRegistrationPanel.Controls.Add(lastName);
            userRegistrationPanel.Controls.Add(label9);
            userRegistrationPanel.Controls.Add(middleName);
            userRegistrationPanel.Controls.Add(label8);
            userRegistrationPanel.Controls.Add(firstName);
            userRegistrationPanel.Controls.Add(label7);
            userRegistrationPanel.Controls.Add(confirmPassword);
            userRegistrationPanel.Controls.Add(label6);
            userRegistrationPanel.Controls.Add(createPassword);
            userRegistrationPanel.Controls.Add(label3);
            userRegistrationPanel.Controls.Add(createUsername);
            userRegistrationPanel.Controls.Add(label2);
            userRegistrationPanel.Location = new Point(319, 43);
            userRegistrationPanel.Name = "userRegistrationPanel";
            userRegistrationPanel.Size = new Size(432, 327);
            userRegistrationPanel.TabIndex = 16;
            userRegistrationPanel.Paint += panel1_Paint;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.SteelBlue;
            label19.Location = new Point(6, 7);
            label19.Name = "label19";
            label19.Size = new Size(116, 16);
            label19.TabIndex = 29;
            label19.Text = "Account Information";
            label19.Click += label19_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.SteelBlue;
            label18.Location = new Point(9, 113);
            label18.Name = "label18";
            label18.Size = new Size(117, 16);
            label18.TabIndex = 28;
            label18.Text = "Personal Information";
            // 
            // securityAnswer
            // 
            securityAnswer.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            securityAnswer.Location = new Point(113, 293);
            securityAnswer.Name = "securityAnswer";
            securityAnswer.Size = new Size(313, 20);
            securityAnswer.TabIndex = 27;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Gill Sans MT", 8.25F);
            label17.Location = new Point(17, 297);
            label17.Name = "label17";
            label17.Size = new Size(82, 16);
            label17.TabIndex = 26;
            label17.Text = "Security Answer:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.SteelBlue;
            label16.Location = new Point(9, 242);
            label16.Name = "label16";
            label16.Size = new Size(172, 16);
            label16.TabIndex = 25;
            label16.Text = "For account recovery purposes:";
            // 
            // securityQuestions
            // 
            securityQuestions.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            securityQuestions.FormattingEnabled = true;
            securityQuestions.Location = new Point(113, 261);
            securityQuestions.Name = "securityQuestions";
            securityQuestions.Size = new Size(313, 24);
            securityQuestions.TabIndex = 24;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Gill Sans MT", 8.25F);
            label15.Location = new Point(13, 269);
            label15.Name = "label15";
            label15.Size = new Size(90, 16);
            label15.TabIndex = 23;
            label15.Text = "Security Question:";
            // 
            // houseNumber
            // 
            houseNumber.Font = new Font("Gill Sans MT", 8.25F);
            houseNumber.Location = new Point(346, 210);
            houseNumber.Name = "houseNumber";
            houseNumber.Size = new Size(80, 20);
            houseNumber.TabIndex = 22;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Gill Sans MT", 9F);
            label14.Location = new Point(274, 210);
            label14.Name = "label14";
            label14.Size = new Size(66, 18);
            label14.TabIndex = 21;
            label14.Text = "House No.:";
            // 
            // contactNumber
            // 
            contactNumber.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contactNumber.Location = new Point(114, 210);
            contactNumber.Name = "contactNumber";
            contactNumber.Size = new Size(150, 20);
            contactNumber.TabIndex = 20;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Gill Sans MT", 8.25F);
            label13.Location = new Point(39, 214);
            label13.Name = "label13";
            label13.Size = new Size(67, 16);
            label13.TabIndex = 19;
            label13.Text = "Contact No.:";
            // 
            // purokNumber
            // 
            purokNumber.Font = new Font("Gill Sans MT", 8.25F);
            purokNumber.FormattingEnabled = true;
            purokNumber.Location = new Point(346, 181);
            purokNumber.Name = "purokNumber";
            purokNumber.Size = new Size(80, 24);
            purokNumber.TabIndex = 18;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Gill Sans MT", 9F);
            label12.Location = new Point(274, 185);
            label12.Name = "label12";
            label12.Size = new Size(63, 18);
            label12.TabIndex = 17;
            label12.Text = "Purok No.:";
            // 
            // birthDate
            // 
            birthDate.Font = new Font("Gill Sans MT", 8.25F);
            birthDate.Format = DateTimePickerFormat.Custom;
            birthDate.Location = new Point(346, 157);
            birthDate.Name = "birthDate";
            birthDate.Size = new Size(80, 20);
            birthDate.TabIndex = 16;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Gill Sans MT", 9F);
            label11.Location = new Point(280, 159);
            label11.Name = "label11";
            label11.Size = new Size(57, 18);
            label11.TabIndex = 14;
            label11.Text = "Birthdate:";
            // 
            // sexIdentification
            // 
            sexIdentification.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sexIdentification.FormattingEnabled = true;
            sexIdentification.Location = new Point(346, 128);
            sexIdentification.Name = "sexIdentification";
            sexIdentification.Size = new Size(80, 24);
            sexIdentification.TabIndex = 13;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Gill Sans MT", 9F);
            label10.Location = new Point(305, 134);
            label10.Name = "label10";
            label10.Size = new Size(32, 18);
            label10.TabIndex = 12;
            label10.Text = "Sex: ";
            // 
            // lastName
            // 
            lastName.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lastName.Location = new Point(114, 182);
            lastName.Name = "lastName";
            lastName.Size = new Size(150, 20);
            lastName.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Gill Sans MT", 8.25F);
            label9.Location = new Point(44, 186);
            label9.Name = "label9";
            label9.Size = new Size(57, 16);
            label9.TabIndex = 10;
            label9.Text = "Last Name:";
            // 
            // middleName
            // 
            middleName.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            middleName.Location = new Point(114, 157);
            middleName.Name = "middleName";
            middleName.Size = new Size(150, 20);
            middleName.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Gill Sans MT", 8.25F);
            label8.Location = new Point(35, 163);
            label8.Name = "label8";
            label8.Size = new Size(69, 16);
            label8.TabIndex = 8;
            label8.Text = "Middle Name:";
            // 
            // firstName
            // 
            firstName.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            firstName.Location = new Point(114, 132);
            firstName.Name = "firstName";
            firstName.Size = new Size(150, 20);
            firstName.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Gill Sans MT", 8.25F);
            label7.Location = new Point(46, 136);
            label7.Name = "label7";
            label7.Size = new Size(58, 16);
            label7.TabIndex = 6;
            label7.Text = "First Name:";
            // 
            // confirmPassword
            // 
            confirmPassword.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmPassword.Location = new Point(113, 80);
            confirmPassword.Name = "confirmPassword";
            confirmPassword.Size = new Size(150, 20);
            confirmPassword.TabIndex = 5;
            confirmPassword.UseSystemPasswordChar = true;
            confirmPassword.TextChanged += confirmPassword_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Gill Sans MT", 8.25F);
            label6.Location = new Point(7, 84);
            label6.Name = "label6";
            label6.Size = new Size(92, 16);
            label6.TabIndex = 4;
            label6.Text = "Confirm Password:";
            // 
            // createPassword
            // 
            createPassword.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createPassword.Location = new Point(113, 52);
            createPassword.Name = "createPassword";
            createPassword.Size = new Size(150, 20);
            createPassword.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Gill Sans MT", 8.25F);
            label3.Location = new Point(47, 56);
            label3.Name = "label3";
            label3.Size = new Size(52, 16);
            label3.TabIndex = 2;
            label3.Text = "Password:";
            // 
            // createUsername
            // 
            createUsername.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createUsername.Location = new Point(113, 25);
            createUsername.Name = "createUsername";
            createUsername.Size = new Size(150, 20);
            createUsername.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gill Sans MT", 8.25F);
            label2.Location = new Point(45, 29);
            label2.Name = "label2";
            label2.Size = new Size(54, 16);
            label2.TabIndex = 0;
            label2.Text = "Username:";
            label2.Click += label2_Click;
            // 
            // logoMain
            // 
            logoMain.BackColor = Color.Transparent;
            logoMain.Image = (Image)resources.GetObject("logoMain.Image");
            logoMain.Location = new Point(646, 16);
            logoMain.Margin = new Padding(4, 5, 4, 5);
            logoMain.Name = "logoMain";
            logoMain.Size = new Size(105, 24);
            logoMain.SizeMode = PictureBoxSizeMode.Zoom;
            logoMain.TabIndex = 17;
            logoMain.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkSlateBlue;
            button2.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(483, 373);
            button2.Name = "button2";
            button2.Size = new Size(114, 28);
            button2.TabIndex = 32;
            button2.Text = "Create Account";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Gill Sans MT", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.SlateGray;
            label21.Location = new Point(394, 404);
            label21.Name = "label21";
            label21.Size = new Size(285, 16);
            label21.TabIndex = 33;
            label21.Text = "-------------------------------- OR --------------------------------";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Gill Sans MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.DarkSlateBlue;
            linkLabel1.Location = new Point(492, 420);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(96, 18);
            linkLabel1.TabIndex = 35;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Log in my account";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 446);
            Controls.Add(linkLabel1);
            Controls.Add(logoMain);
            Controls.Add(userRegistrationPanel);
            Controls.Add(linkLabel2);
            Controls.Add(label5);
            Controls.Add(label21);
            Controls.Add(button2);
            Controls.Add(leftPanel);
            Controls.Add(welcomeText);
            Controls.Add(label1);
            Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Registration";
            Text = "Barangay Document Request System";
            Load += Registration_Load;
            ((System.ComponentModel.ISupportInitialize)leftPanel).EndInit();
            userRegistrationPanel.ResumeLayout(false);
            userRegistrationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label welcomeText;
        private PictureBox leftPanel;
        private Label label1;
        private PictureBox pictureBox2;
        private CheckBox checkBox1;
        private LinkLabel linkLabel1;
        private Label label5;
        private LinkLabel linkLabel2;
        private Panel userRegistrationPanel;
        private Label label2;
        private TextBox createPassword;
        private Label label3;
        private TextBox createUsername;
        private TextBox confirmPassword;
        private Label label6;
        private PictureBox logoMain;
        private ComboBox sexIdentification;
        private Label label10;
        private TextBox lastName;
        private Label label9;
        private TextBox middleName;
        private Label label8;
        private TextBox firstName;
        private Label label7;
        private DateTimePicker birthDate;
        private Label label11;
        private TextBox houseNumber;
        private Label label14;
        private TextBox contactNumber;
        private Label label13;
        private ComboBox purokNumber;
        private Label label12;
        private Label label19;
        private Label label18;
        private TextBox securityAnswer;
        private Label label17;
        private Label label16;
        private ComboBox securityQuestions;
        private Label label15;
        private Button button2;
        private Label label21;
    }
}
