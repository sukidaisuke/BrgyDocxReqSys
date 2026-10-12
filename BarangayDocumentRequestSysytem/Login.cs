#nullable disable
using BCrypt.Net;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void forgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgotPassword fp = new ForgotPassword();
            fp.ShowDialog();
            this.Close();
        }

        private void createAccountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Registration Rg = new Registration();
            Rg.ShowDialog();
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string usernameInput = userName.Text.Trim();
            string passInput = password.Text;

            if (string.IsNullOrEmpty(usernameInput) || string.IsNullOrEmpty(passInput))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=localhost;Database=barangay_db;Uid=root;Pwd=;";
            string query = "SELECT user_id, password, role FROM users WHERE username = @username";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", usernameInput);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int fetchUserId = Convert.ToInt32(reader["user_id"]);
                                string storedHash = reader["password"]?.ToString() ?? "";
                                string role = reader["role"]?.ToString() ?? "user";

                                bool isPasswordValid = false;

                                try
                                {
                                    isPasswordValid = BCrypt.Net.BCrypt.Verify(passInput, storedHash);
                                }
                                catch
                                {
                                    // Fallback for non-BCrypt/plain test passwords in database
                                    isPasswordValid = (passInput == storedHash);
                                }

                                if (isPasswordValid)
                                {
                                    // Store user session details
                                    UserSession.UserId = fetchUserId;
                                    UserSession.Username = usernameInput;

                                    this.Hide();

                                    // Redirect based on database role
                                    if (string.Equals(role, "admin", StringComparison.OrdinalIgnoreCase))
                                    {
                                        DashboardTest adminDb = new DashboardTest();
                                        adminDb.ShowDialog();
                                    }
                                    else
                                    {
                                        UserPage userPage = new UserPage();
                                        userPage.ShowDialog();
                                    }

                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Username not found.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = !password.UseSystemPasswordChar;
        }

        private void Login_Load(object sender, EventArgs e) { }
        private void password_TextChanged(object sender, EventArgs e) { }
        private void userName_TextChanged(object sender, EventArgs e) { }
    }
}