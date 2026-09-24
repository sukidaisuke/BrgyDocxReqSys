#nullable disable
using BCrypt.Net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            Rg = null;
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string usernameInput = userName.Text.Trim();
            string passInput = password.Text;

            // 1. Hardcoded Admin check
            if (usernameInput == "admin" && passInput == "admin67")
            {
                UserSession.UserId = 0; // Admin ID
                UserSession.Username = usernameInput;

                this.Hide();
                DashboardTest Db = new DashboardTest();
                Db.ShowDialog();
                this.Close();
                return;
            }

            // 2. Check MySQL Database for regular users (Fetches both 'id' and 'password')
            string connectionString = "Server=localhost;Database=barangay_db;Uid=root;Pwd=;";
            string query = "SELECT user_id, password FROM users WHERE username = @username";

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
                            if (reader.Read()) // User found
                            {
                                int fetchUserId = Convert.ToInt32(reader["user_id"]);
                                string storedHash = reader["password"].ToString();

                                // Verify typed password against stored BCrypt hash
                                if (BCrypt.Net.BCrypt.Verify(passInput, storedHash))
                                {
                                    // Store values globally in UserSession
                                    UserSession.UserId = fetchUserId;
                                    UserSession.Username = usernameInput;

                                    this.Hide();
                                    UserPage up = new UserPage();
                                    up.ShowDialog();
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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (password.UseSystemPasswordChar)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void userName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
