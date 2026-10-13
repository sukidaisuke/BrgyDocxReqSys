#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class SecurityQuestion : Form
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";
        private readonly string username;
        private readonly string question;

        public SecurityQuestion() : this("", "")
        {
        }

        public SecurityQuestion(string username, string question)
        {
            InitializeComponent();
            this.username = username;
            this.question = question;
            lblQuestion.Text = question;
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void SecurityQuestion_Load(object sender, EventArgs e) { }

        // Step 2: compare the typed answer with the saved answer
        private void btnVerify_Click(object sender, EventArgs e)
        {
            string answer = txtAnswer.Text.Trim();

            if (string.IsNullOrEmpty(answer))
            {
                MessageBox.Show("Please enter your answer.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnswer.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT security_answer FROM users WHERE username = @username LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        string saved = (result == null || result == DBNull.Value) ? "" : result.ToString().Trim();

                        // Case-insensitive comparison
                        if (saved.Length > 0 && string.Equals(saved, answer, StringComparison.OrdinalIgnoreCase))
                        {
                            this.Hide();
                            ResetPassword rp = new ResetPassword(username);
                            rp.ShowDialog();
                            rp = null;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect answer. Please try again.", "Verification Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtAnswer.Clear();
                            txtAnswer.Focus();
                        }
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
