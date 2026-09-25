#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class ProfileControl : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public ProfileControl()
        {
            InitializeComponent();
            LockAdminFields();
        }

        private void LockAdminFields()
        {
            SetReadOnly("txtResidency");
            SetReadOnly("txtVoterStatus");
            SetReadOnly("txtFullName");
            SetReadOnly("txtDateOfBirth");
            SetReadOnly("txtSex");
            SetReadOnly("txtAddress");
        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
        }

        private void ProfileControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadUserProfile();
            }
        }

        public void LoadUserProfile()
        {
            int currentUserId = UserSession.UserId;

            if (currentUserId <= 0)
            {
                MessageBox.Show($"UserSession.UserId is currently {currentUserId}.\n\nIf logged in as 'admin', log out and sign in using a resident account.",
                                "Session Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT first_name, middle_name, last_name, sex, birthdate, 
                                    contact_no, purok_no, house_no, years_of_residency, voter_status 
                             FROM users 
                             WHERE user_id = @UserId LIMIT 1";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", currentUserId);

                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 1. Full Name
                                string fName = reader["first_name"]?.ToString() ?? "";
                                string mName = reader["middle_name"]?.ToString() ?? "";
                                string lName = reader["last_name"]?.ToString() ?? "";
                                string middleInitial = !string.IsNullOrWhiteSpace(mName) ? $" {mName[0]}." : "";
                                string fullName = $"{fName}{middleInitial} {lName}".Trim();
                                SetText("txtFullName", fullName);

                                // 2. Birthdate
                                if (reader["birthdate"] != DBNull.Value)
                                {
                                    DateTime bdate = Convert.ToDateTime(reader["birthdate"]);
                                    SetText("txtDateOfBirth", bdate.ToString("MMMM dd, yyyy"));
                                }

                                // 3. Sex
                                SetText("txtSex", reader["sex"]?.ToString());

                                // 4. Contact Number
                                SetText("txtContactNumber", reader["contact_no"]?.ToString());

                                // 5. Full Address
                                string house = reader["house_no"]?.ToString() ?? "";
                                string purok = reader["purok_no"]?.ToString() ?? "";
                                string fullAddress = $"House No. {house}, Purok {purok}, Barangay Sevilla, San Fernando City, La Union";
                                SetText("txtAddress", fullAddress);

                                // 6. Admin Verification Fields
                                string residency = reader["years_of_residency"] != DBNull.Value ? reader["years_of_residency"].ToString() : "Unverified";
                                string voter = reader["voter_status"] != DBNull.Value ? reader["voter_status"].ToString() : "Non-Voter";

                                SetText("txtResidency", residency);
                                SetText("txtVoterStatus", voter);
                            }
                            else
                            {
                                MessageBox.Show($"No record found in MySQL for user_id: {currentUserId}", "Database Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"MySQL Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SetText(string name, string value)
        {
            TextBox target = FindChildTextBox(this, name);
            if (target != null)
            {
                target.Text = value ?? "";
            }
        }

        private void SetReadOnly(string name)
        {
            TextBox target = FindChildTextBox(this, name);
            if (target != null)
            {
                target.ReadOnly = true;
                target.BackColor = Color.FromArgb(243, 244, 246);
            }
        }

        private TextBox FindChildTextBox(Control parent, string name)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox txt && string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return txt;
                }

                if (c.HasChildren)
                {
                    TextBox childMatch = FindChildTextBox(c, name);
                    if (childMatch != null) return childMatch;
                }
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox contactTxt = FindChildTextBox(this, "txtContactNumber");
            string contactValue = contactTxt != null ? contactTxt.Text : "";

            if (string.IsNullOrWhiteSpace(contactValue))
            {
                MessageBox.Show("Contact number cannot be empty.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int currentUserId = UserSession.UserId;
            if (currentUserId <= 0) return;

            string query = "UPDATE users SET contact_no = @Contact WHERE user_id = @UserId";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Contact", contactValue.Trim());
                    cmd.Parameters.AddWithValue("@UserId", currentUserId);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Contact information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to update contact number: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRequestUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your update request has been sent to the Barangay Administrator for verification.", "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ResetPassword resetModal = new ResetPassword();
            resetModal.ShowDialog();
        }
    }
}