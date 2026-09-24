#nullable disable
using MySql.Data.MySqlClient;
namespace BarangayDocumentRequestSysytem
{
    public partial class Registration : Form
    {

        public Registration()
        {
            InitializeComponent();
        }
     
        private void createAccountButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Lf = new Login();
            Lf.ShowDialog();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login Lf = new Login();
            Lf.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // 1. Check if passwords match before touching the database
            if (createPassword.Text != confirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash the password before saving
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(createPassword.Text);

            // 2. Define your XAMPP connection string
            string connectionString = "Server=localhost;Database=barangay_db;Uid=root;Pwd=;";

            // 3. Insert data into MySQL
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO users 
                (username, password, first_name, middle_name, last_name, sex, birthdate, contact_no, purok_no, house_no, security_question, security_answer) 
                VALUES 
                (@username, @password, @fname, @mname, @lname, @sex, @bdate, @contact, @purok, @house, @secQ, @secA)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Replace these txt/cmb control names with the exact Name properties from your WinForms designer
                        cmd.Parameters.AddWithValue("@username", createUsername.Text);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@fname", firstName.Text);
                        cmd.Parameters.AddWithValue("@mname", middleName.Text);
                        cmd.Parameters.AddWithValue("@lname", lastName.Text);
                        cmd.Parameters.AddWithValue("@sex", sexIdentification.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@bdate", birthDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@contact", contactNumber.Text);
                        cmd.Parameters.AddWithValue("@purok", purokNumber.Text);
                        cmd.Parameters.AddWithValue("@house", houseNumber.Text);
                        cmd.Parameters.AddWithValue("@secQ", securityQuestions.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@secA", securityAnswer.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login Lf = new Login();
            Lf.ShowDialog();
            this.Close();
        }
    }
}
