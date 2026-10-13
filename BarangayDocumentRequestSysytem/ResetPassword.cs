#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// Two modes:
    ///  1) Change Password (opened from Profile): resident is logged in, must type the current password.
    ///  2) Forgot Password (opened after the security question): no current password needed.
    /// </summary>
    public partial class ResetPassword : Form
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";
        private readonly bool forgotMode;
        private readonly string forgotUsername;

        // Change Password (logged-in user)
        public ResetPassword()
        {
            InitializeComponent();
            forgotMode = false;
            forgotUsername = null;
        }

        // Forgot Password (verified by security question)
        public ResetPassword(string username)
        {
            InitializeComponent();
            forgotMode = true;
            forgotUsername = username;

            lblSubtitle.Text = "Please enter and confirm your new password.";

            // The security question already verified the user, so hide "current password" and close the gap.
            int shift = lblNewPassword.Top - lblCurrentPassword.Top;
            lblCurrentPassword.Visible = false;
            txtCurrentPassword.Visible = false;

            foreach (Control c in new Control[] { lblNewPassword, txtNewPassword,
                                                   lblConfirmPassword, txtConfirmPassword,
                                                   btnReset, btnCancel })
            {
                c.Top -= shift;
            }
            this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height - shift);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!forgotMode && string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                MessageBox.Show("Please enter your current password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Please enter a new password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("New password and confirm password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            // Which account are we changing?
            string whereColumn = forgotMode ? "username" : "user_id";
            object whereValue = forgotMode ? (object)forgotUsername : UserSession.UserId;

            if (forgotMode && string.IsNullOrEmpty(forgotUsername))
            {
                MessageBox.Show("No account selected. Please start from Forgot Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!forgotMode && UserSession.UserId <= 0)
            {
                MessageBox.Show("Invalid session. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Change Password mode: verify the current password first
                    if (!forgotMode)
                    {
                        string storedHash = "";
                        using (MySqlCommand check = new MySqlCommand("SELECT password FROM users WHERE user_id = @id LIMIT 1", conn))
                        {
                            check.Parameters.AddWithValue("@id", UserSession.UserId);
                            object result = check.ExecuteScalar();
                            storedHash = (result == null || result == DBNull.Value) ? "" : result.ToString();
                        }

                        bool valid;
                        try
                        {
                            valid = BCrypt.Net.BCrypt.Verify(txtCurrentPassword.Text, storedHash);
                        }
                        catch
                        {
                            // plain-text test passwords
                            valid = (txtCurrentPassword.Text == storedHash);
                        }

                        if (!valid)
                        {
                            MessageBox.Show("Your current password is incorrect.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCurrentPassword.Clear();
                            txtCurrentPassword.Focus();
                            return;
                        }
                    }

                    string hashed = BCrypt.Net.BCrypt.HashPassword(txtNewPassword.Text);

                    using (MySqlCommand cmd = new MySqlCommand($"UPDATE users SET password = @password WHERE {whereColumn} = @who", conn))
                    {
                        cmd.Parameters.AddWithValue("@password", hashed);
                        cmd.Parameters.AddWithValue("@who", whereValue);

                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("Password could not be updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                if (forgotMode)
                {
                    MessageBox.Show("Password reset successfully! You can now log in with your new password.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    using (Login Lf = new Login())
                    {
                        Lf.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your password has been changed successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
