#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class ForgotPassword : Form
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        // Step 1: verify the username exists and fetch its security question
        private void btnNext_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your username.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT security_question FROM users WHERE username = @username LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value || string.IsNullOrWhiteSpace(result.ToString()))
                        {
                            MessageBox.Show(
                                "No account with a security question was found for that username.",
                                "Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string question = result.ToString();

                        this.Hide();
                        SecurityQuestion sq = new SecurityQuestion(username, question);
                        sq.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Lf = new Login();
            Lf.ShowDialog();
            Lf = null;
            this.Close();
        }
    }
}
