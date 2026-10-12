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
            if (lblDate != null)
            {
                lblDate.Text = DateHelper.CurrentHeaderDate;
            }
        }

        private void LockAdminFields()
        {
            if (button2 != null)
            {
                button2.Visible = false; // Hide quick save button by default
            }
            SetProfileFieldsReadOnly(true);
        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
            CheckUpdateRequestStatus();
        }

        private void ProfileControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadUserProfile();
                CheckUpdateRequestStatus();
            }
        }

        public void RefreshControl()
        {
            LoadUserProfile();
            CheckUpdateRequestStatus();
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
                                string fName = reader["first_name"]?.ToString() ?? "";
                                string mName = reader["middle_name"]?.ToString() ?? "";
                                string lName = reader["last_name"]?.ToString() ?? "";
                                string middlePart = !string.IsNullOrWhiteSpace(mName) ? $" {mName}" : "";
                                string fullName = $"{fName}{middlePart} {lName}".Trim();
                                SetText("txtFullName", fullName);

                                if (reader["birthdate"] != DBNull.Value)
                                {
                                    DateTime bdate = Convert.ToDateTime(reader["birthdate"]);
                                    SetText("txtDateOfBirth", bdate.ToString("MMMM dd, yyyy"));
                                }

                                SetText("txtSex", reader["sex"]?.ToString());
                                SetText("txtContactNumber", reader["contact_no"]?.ToString());

                                string house = reader["house_no"]?.ToString() ?? "";
                                string purok = reader["purok_no"]?.ToString() ?? "";
                                string fullAddress = $"House No. {house}, Purok {purok}, Barangay Sevilla, San Fernando City, La Union";
                                SetText("txtAddress", fullAddress);

                                string residency = reader["years_of_residency"] != DBNull.Value ? reader["years_of_residency"].ToString() : "Unverified";
                                string voter = reader["voter_status"] != DBNull.Value ? reader["voter_status"].ToString() : "Non-Voter";

                                SetText("txtResidency", residency);
                                SetText("txtVoterStatus", voter);
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

        public void CheckUpdateRequestStatus()
        {
            int currentUserId = UserSession.UserId;
            if (currentUserId <= 0)
            {
                if (button2 != null) button2.Visible = false;
                button3.Text = "✏️ Request Information Update";
                button3.Enabled = true;
                SetProfileFieldsReadOnly(true);
                return;
            }

            string query = @"SELECT status FROM info_update_requests 
                             WHERE user_id = @UserId 
                             ORDER BY request_id DESC LIMIT 1";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", currentUserId);
                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        string status = result != null ? result.ToString().Trim() : "";

                        if (status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                        {
                            if (button2 != null) button2.Visible = false;
                            button3.Text = "⏳ Pending Approval";
                            button3.Enabled = false;
                            SetProfileFieldsReadOnly(true);
                        }
                        else if (status.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                        {
                            if (button2 != null) button2.Visible = true;
                            button3.Text = "💾 Save Updated Information";
                            button3.Enabled = true;
                            SetProfileFieldsReadOnly(false);
                        }
                        else // 'Completed', 'Rejected', or no record
                        {
                            if (button2 != null) button2.Visible = false;
                            button3.Text = "✏️ Request Information Update";
                            button3.Enabled = true;
                            SetProfileFieldsReadOnly(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error checking update request status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int currentUserId = UserSession.UserId;
            if (currentUserId <= 0) return;

            if (button3.Text.Contains("Request Information Update"))
            {
                string checkQuery = "SELECT COUNT(*) FROM info_update_requests WHERE user_id = @UserId AND status = 'Pending'";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@UserId", currentUserId);
                        long pendingCount = Convert.ToInt64(checkCmd.ExecuteScalar());
                        if (pendingCount > 0)
                        {
                            MessageBox.Show("You already have a pending update request waiting for Admin approval.", "Request Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            CheckUpdateRequestStatus();
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO info_update_requests (user_id, status) VALUES (@UserId, 'Pending')";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Your update request has been sent to the Barangay Administrator for approval.", "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CheckUpdateRequestStatus();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error filing request: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else if (button3.Text.Contains("Save Updated Information"))
            {
                SaveProfileUpdates();
            }
        }

        private void SaveProfileUpdates()
        {
            int currentUserId = UserSession.UserId;
            if (currentUserId <= 0) return;

            TextBox fullNameTxt = FindChildTextBox(this, "txtFullName");
            TextBox sexTxt = FindChildTextBox(this, "txtSex");
            TextBox contactTxt = FindChildTextBox(this, "txtContactNumber");
            TextBox dobTxt = FindChildTextBox(this, "txtDateOfBirth");

            string fullName = fullNameTxt != null ? fullNameTxt.Text.Trim() : "";
            string sex = sexTxt != null ? sexTxt.Text.Trim() : "";
            string contact = contactTxt != null ? contactTxt.Text.Trim() : "";
            string dobString = dobTxt != null ? dobTxt.Text.Trim() : "";

            string[] nameParts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstName = nameParts.Length > 0 ? nameParts[0] : "";
            string lastName = nameParts.Length > 1 ? nameParts[nameParts.Length - 1] : "";
            string middleName = nameParts.Length > 2 ? string.Join(" ", nameParts, 1, nameParts.Length - 2) : "";

            DateTime? birthdate = null;
            if (DateTime.TryParse(dobString, out DateTime parsedDob))
            {
                birthdate = parsedDob;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    string updateProfileQuery = @"UPDATE users 
                                                 SET first_name = @FirstName, 
                                                     last_name = @LastName, 
                                                     middle_name = @MiddleName,
                                                     sex = @Sex, 
                                                     contact_no = @Contact";

                    if (birthdate.HasValue)
                    {
                        updateProfileQuery += ", birthdate = @Birthdate";
                    }

                    updateProfileQuery += " WHERE user_id = @UserId";

                    using (MySqlCommand cmd = new MySqlCommand(updateProfileQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@MiddleName", middleName);
                        cmd.Parameters.AddWithValue("@Sex", sex);
                        cmd.Parameters.AddWithValue("@Contact", contact);
                        if (birthdate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@Birthdate", birthdate.Value.ToString("yyyy-MM-dd"));
                        }
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                        cmd.ExecuteNonQuery();
                    }

                    string updateReqQuery = "UPDATE info_update_requests SET status = 'Completed' WHERE user_id = @UserId AND status = 'Approved'";
                    using (MySqlCommand cmdReq = new MySqlCommand(updateReqQuery, conn, transaction))
                    {
                        cmdReq.Parameters.AddWithValue("@UserId", currentUserId);
                        cmdReq.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("Your profile has been updated successfully!\n\nTo make further changes in the future, please file a new request.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUserProfile();
                    CheckUpdateRequestStatus();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        try { transaction.Rollback(); } catch { }
                    }
                    MessageBox.Show($"Failed to save updates: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetProfileFieldsReadOnly(bool readOnly)
        {
            SetTextBoxReadOnly("txtFullName", readOnly);
            SetTextBoxReadOnly("txtDateOfBirth", readOnly);
            SetTextBoxReadOnly("txtSex", readOnly);
            SetTextBoxReadOnly("txtContactNumber", readOnly);

            // Admin-verified and address composition fields remain permanently locked
            SetTextBoxReadOnly("txtAddress", true);
            SetTextBoxReadOnly("txtResidency", true);
            SetTextBoxReadOnly("txtVoterStatus", true);
        }

        private void SetTextBoxReadOnly(string name, bool readOnly)
        {
            TextBox target = FindChildTextBox(this, name);
            if (target != null)
            {
                target.ReadOnly = readOnly;
                target.Enabled = true;
                target.BackColor = readOnly ? Color.FromArgb(243, 244, 246) : Color.White;
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
            SaveProfileUpdates();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ResetPassword resetModal = new ResetPassword();
            resetModal.ShowDialog();
        }

        private void FormOrControl_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateHelper.CurrentHeaderDate;
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            lblDate.Text = DateHelper.CurrentHeaderDate;
        }
    }
}