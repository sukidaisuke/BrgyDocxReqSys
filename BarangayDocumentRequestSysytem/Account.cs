#nullable disable
using MySql.Data.MySqlClient; // MySQL driver
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class Account : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public Account()
        {
            InitializeComponent();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            LoadAccountDetails();
        }

        private void Account_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadAccountDetails();
            }
        }

        public void LoadAccountDetails()
        {
            int currentUserId = UserSession.UserId;

            string query;
            if (currentUserId > 0)
            {
                query = "SELECT username, password FROM users WHERE user_id = @UserId LIMIT 1";
            }
            else
            {
                // Fallback query if UserSession is not yet set
                query = "SELECT username, password FROM users WHERE username = 'admin' OR user_id = 12 LIMIT 1";
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (currentUserId > 0)
                    {
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                    }

                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string username = reader["username"] != DBNull.Value ? reader["username"].ToString() : "";
                                string password = reader["password"] != DBNull.Value ? reader["password"].ToString() : "";

                                usernameTXT.Text = username;
                                passwordTXT.Text = password;
                                pwConfirmTXT.Text = password;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error fetching account details: {ex.Message}",
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void hidepwBTN_Click(object sender, EventArgs e)
        {
            passwordTXT.UseSystemPasswordChar = !passwordTXT.UseSystemPasswordChar;
        }

        private void hidePWConfirmBTN_Click(object sender, EventArgs e)
        {
            pwConfirmTXT.UseSystemPasswordChar = !pwConfirmTXT.UseSystemPasswordChar;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Reset inputs back to database defaults
            LoadAccountDetails();
            MessageBox.Show("Changes canceled and form reset.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void confirmBTN_Click(object sender, EventArgs e)
        {
            string newUsername = usernameTXT.Text.Trim();
            string newPassword = passwordTXT.Text.Trim();
            string confirmPassword = pwConfirmTXT.Text.Trim();

            // Validation Checks
            if (string.IsNullOrWhiteSpace(newUsername))
            {
                MessageBox.Show("Username cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernameTXT.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                passwordTXT.Focus();
                return;
            }

            if (!newPassword.Equals(confirmPassword))
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pwConfirmTXT.Focus();
                return;
            }

            int currentUserId = UserSession.UserId;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check if username is already taken by another account
                    string checkUsernameQuery = currentUserId > 0
                        ? "SELECT COUNT(*) FROM users WHERE username = @Username AND user_id != @UserId"
                        : "SELECT COUNT(*) FROM users WHERE username = @Username AND username != 'admin'";

                    using (MySqlCommand checkCmd = new MySqlCommand(checkUsernameQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", newUsername);
                        if (currentUserId > 0)
                        {
                            checkCmd.Parameters.AddWithValue("@UserId", currentUserId);
                        }

                        long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show($"The username '{newUsername}' is already in use by another account.",
                                "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            usernameTXT.Focus();
                            return;
                        }
                    }

                    // Perform Update using user_id
                    string updateQuery;
                    if (currentUserId > 0)
                    {
                        updateQuery = "UPDATE users SET username = @Username, password = @Password WHERE user_id = @UserId";
                    }
                    else
                    {
                        updateQuery = "UPDATE users SET username = @Username, password = @Password WHERE username = 'admin' OR user_id = 12 LIMIT 1";
                    }

                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Username", newUsername);
                        updateCmd.Parameters.AddWithValue("@Password", newPassword);
                        if (currentUserId > 0)
                        {
                            updateCmd.Parameters.AddWithValue("@UserId", currentUserId);
                        }

                        int rows = updateCmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Account credentials updated successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Update active session username
                            UserSession.Username = newUsername;

                            LoadAccountDetails();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update account credentials: {ex.Message}",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}