namespace BarangayDocumentRequestSysytem
{
    partial class SecurityQuestion
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
            label1 = new Label();
            label2 = new Label();
            lblQuestion = new Label();
            label4 = new Label();
            txtAnswer = new TextBox();
            btnCancel = new Button();
            btnVerify = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkSlateBlue;
            label1.Location = new Point(165, 32);
            label1.Name = "label1";
            label1.Size = new Size(158, 23);
            label1.TabIndex = 1;
            label1.Text = "Verify Your Identity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(65, 98);
            label2.Name = "label2";
            label2.Size = new Size(135, 23);
            label2.TabIndex = 2;
            label2.Text = "Security Question: ";
            label2.Click += label2_Click;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion.Location = new Point(206, 98);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(188, 23);
            lblQuestion.TabIndex = 3;
            lblQuestion.Text = "What is your favorite food?";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(65, 146);
            label4.Name = "label4";
            label4.Size = new Size(69, 23);
            label4.TabIndex = 4;
            label4.Text = "Answer: ";
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(143, 146);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(262, 23);
            txtAnswer.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(224, 224, 224);
            btnCancel.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ActiveCaptionText;
            btnCancel.Location = new Point(143, 250);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(222, 36);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.SteelBlue;
            btnVerify.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerify.ForeColor = SystemColors.ButtonHighlight;
            btnVerify.Location = new Point(143, 208);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(222, 36);
            btnVerify.TabIndex = 8;
            btnVerify.Text = "Verify";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // SecurityQuestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 311);
            Controls.Add(btnVerify);
            Controls.Add(btnCancel);
            Controls.Add(txtAnswer);
            Controls.Add(label4);
            Controls.Add(lblQuestion);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SecurityQuestion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SecurityQuestion";
            Load += SecurityQuestion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Button btnCancel;
        private Button btnNext;
        private Label lblQuestion;
        private TextBox txtAnswer;
        private Button btnVerify;
    }
}