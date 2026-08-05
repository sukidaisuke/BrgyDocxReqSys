namespace BarangayDocumentRequestSysytem
{
    partial class ResetPassword
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
            label3 = new Label();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnReset = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkSlateBlue;
            label1.Location = new Point(154, 34);
            label1.Name = "label1";
            label1.Size = new Size(168, 23);
            label1.TabIndex = 2;
            label1.Text = "Reset your Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(63, 98);
            label2.Name = "label2";
            label2.Size = new Size(117, 23);
            label2.TabIndex = 3;
            label2.Text = "New Password: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(63, 142);
            label3.Name = "label3";
            label3.Size = new Size(134, 23);
            label3.TabIndex = 4;
            label3.Text = "Confirm Password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(205, 98);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(210, 23);
            txtNewPassword.TabIndex = 5;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(205, 142);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(210, 23);
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.SteelBlue;
            btnReset.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.ForeColor = SystemColors.ButtonHighlight;
            btnReset.Location = new Point(163, 217);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(170, 33);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset Password";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // ResetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 311);
            Controls.Add(btnReset);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ResetPassword";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ResetPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button btnReset;
    }
}