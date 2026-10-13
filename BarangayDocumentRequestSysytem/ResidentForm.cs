#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// Admin dialog used to add a new resident (walk-in registration) or edit every field of an existing one.
    /// </summary>
    public class ResidentForm : Form
    {
        private readonly int? userId;          // null = add mode
        private bool IsEdit => userId.HasValue;

        private TextBox txtFirst, txtMiddle, txtLast, txtContact, txtHouse, txtUsername, txtPassword, txtSecAnswer;
        private ComboBox cmbSex, cmbPurok, cmbVoter, cmbSecQuestion;
        private DateTimePicker dtBirth;
        private NumericUpDown nudYears;

        public ResidentForm(int? existingUserId = null)
        {
            userId = existingUserId;
            Build();
            if (IsEdit) Load += (s, e) => LoadResident();
        }

        private void Build()
        {
            Text = IsEdit ? $"Edit Resident (RES-{userId.Value:D3})" : "Add Resident";
            ClientSize = new Size(520, IsEdit ? 430 : 560);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false; ShowInTaskbar = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            Panel header = new Panel { Dock = DockStyle.Top, Height = 44, BackColor = UiKit.Brand };
            header.Controls.Add(new Label
            {
                Text = IsEdit ? "✏️  Edit Resident Information" : "➕  Add New Resident",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(14, 11),
                AutoSize = true
            });
            Controls.Add(header);

            int y = 58, x1 = 16, x2 = 150, w = 340, gap = 34;

            txtFirst = UiKit.Text(x2, y, w, 60); AddRow("First name *", txtFirst, ref y, gap, x1);
            txtMiddle = UiKit.Text(x2, y, w, 60); AddRow("Middle name", txtMiddle, ref y, gap, x1);
            txtLast = UiKit.Text(x2, y, w, 60); AddRow("Last name *", txtLast, ref y, gap, x1);

            cmbSex = UiKit.Combo(UiKit.SexOptions, x2, y, 120);
            AddRow("Sex *", cmbSex, ref y, gap, x1);

            dtBirth = new DateTimePicker
            {
                Location = new Point(x2, y),
                Width = 160,
                Format = DateTimePickerFormat.Long,
                MaxDate = DateTime.Today,
                MinDate = new DateTime(1900, 1, 1),
                Value = DateTime.Today.AddYears(-18)
            };
            AddRow("Birthdate *", dtBirth, ref y, gap, x1);

            txtContact = UiKit.Text(x2, y, 200, 20);
            AddRow("Contact number", txtContact, ref y, gap, x1);

            cmbPurok = UiKit.Combo(UiKit.PurokOptions, x2, y, 80);
            AddRow("Purok *", cmbPurok, ref y, gap, x1);

            txtHouse = UiKit.Text(x2, y, 200, 20);
            AddRow("House no.", txtHouse, ref y, gap, x1);

            nudYears = new NumericUpDown { Location = new Point(x2, y), Width = 80, Minimum = 0, Maximum = 120 };
            AddRow("Years of residency", nudYears, ref y, gap, x1);

            cmbVoter = UiKit.Combo(UiKit.VoterOptions, x2, y, 80);
            cmbVoter.SelectedIndex = 1;
            AddRow("Registered voter", cmbVoter, ref y, gap, x1);

            if (!IsEdit)
            {
                Label sep = new Label { Text = "Login account", Font = new Font("Segoe UI", 9F, FontStyle.Bold), Location = new Point(x1, y + 4), AutoSize = true, ForeColor = UiKit.Brand };
                Controls.Add(sep);
                y += 26;

                txtUsername = UiKit.Text(x2, y, 200, 50); AddRow("Username *", txtUsername, ref y, gap, x1);
                txtPassword = UiKit.Text(x2, y, 200, 50); txtPassword.UseSystemPasswordChar = true;
                AddRow("Temporary password *", txtPassword, ref y, gap, x1);
                cmbSecQuestion = UiKit.Combo(UiKit.SecurityQuestions, x2, y, w);
                AddRow("Security question *", cmbSecQuestion, ref y, gap, x1);
                txtSecAnswer = UiKit.Text(x2, y, w, 100); AddRow("Security answer *", txtSecAnswer, ref y, gap, x1);
            }

            Button save = UiKit.Btn(IsEdit ? "💾 Save Changes" : "➕ Add Resident", 270, y + 10, 130, 34, UiKit.Brand, Color.White);
            Button cancel = UiKit.Btn("Cancel", 410, y + 10, 94, 34, UiKit.Muted, Color.FromArgb(71, 85, 105));
            save.Click += (s, e) => Save();
            cancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            Controls.Add(save);
            Controls.Add(cancel);
            AcceptButton = save;
            CancelButton = cancel;

            ClientSize = new Size(520, y + 60);
        }

        private void AddRow(string caption, Control input, ref int y, int gap, int x1)
        {
            Controls.Add(UiKit.Lbl(caption, x1, y, 130));
            Controls.Add(input);
            y += gap;
        }

        private void LoadResident()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT first_name, middle_name, last_name, sex, birthdate, contact_no, purok_no, house_no,
                                 years_of_residency, voter_status
                          FROM users WHERE user_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId.Value);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (!r.Read())
                            {
                                UiKit.Warn(this, "That resident no longer exists.", "Not Found");
                                DialogResult = DialogResult.Cancel;
                                return;
                            }

                            txtFirst.Text = r["first_name"]?.ToString();
                            txtMiddle.Text = r["middle_name"]?.ToString();
                            txtLast.Text = r["last_name"]?.ToString();

                            SelectOrAdd(cmbSex, r["sex"]?.ToString());
                            if (r["birthdate"] != DBNull.Value)
                            {
                                DateTime b = Convert.ToDateTime(r["birthdate"]);
                                if (b >= dtBirth.MinDate && b <= dtBirth.MaxDate) dtBirth.Value = b;
                            }
                            txtContact.Text = r["contact_no"]?.ToString();
                            SelectOrAdd(cmbPurok, r["purok_no"]?.ToString());
                            txtHouse.Text = r["house_no"]?.ToString();

                            if (r["years_of_residency"] != DBNull.Value &&
                                decimal.TryParse(r["years_of_residency"].ToString(), out decimal yrs))
                                nudYears.Value = Math.Min(Math.Max(yrs, nudYears.Minimum), nudYears.Maximum);

                            string voter = r["voter_status"]?.ToString();
                            SelectOrAdd(cmbVoter, string.IsNullOrWhiteSpace(voter) ? "No" : voter);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not load the resident: " + ex.Message);
            }
        }

        private static void SelectOrAdd(ComboBox cmb, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) { cmb.SelectedIndex = -1; return; }
            value = value.Trim();
            int idx = cmb.FindStringExact(value);
            if (idx < 0) idx = cmb.Items.Add(value);
            cmb.SelectedIndex = idx;
        }

        private bool ValidateInputs()
        {
            Regex namePattern = new Regex(@"^[\p{L}][\p{L} .'\-]*$");

            if (!namePattern.IsMatch(txtFirst.Text.Trim())) { UiKit.Warn(this, "Please enter a valid first name (letters only)."); txtFirst.Focus(); return false; }
            if (txtMiddle.Text.Trim().Length > 0 && !namePattern.IsMatch(txtMiddle.Text.Trim())) { UiKit.Warn(this, "Middle name can only contain letters."); txtMiddle.Focus(); return false; }
            if (!namePattern.IsMatch(txtLast.Text.Trim())) { UiKit.Warn(this, "Please enter a valid last name (letters only)."); txtLast.Focus(); return false; }
            if (cmbSex.SelectedIndex < 0) { UiKit.Warn(this, "Please choose a sex."); cmbSex.Focus(); return false; }
            if (dtBirth.Value.Date > DateTime.Today) { UiKit.Warn(this, "Birthdate cannot be in the future."); return false; }

            string contact = txtContact.Text.Trim();
            if (contact.Length > 0 && !Regex.IsMatch(contact, @"^[0-9+\-\s]{7,20}$"))
            {
                UiKit.Warn(this, "Contact number should only contain digits (7 to 20 characters).");
                txtContact.Focus();
                return false;
            }

            if (cmbPurok.SelectedIndex < 0) { UiKit.Warn(this, "Please choose a purok."); cmbPurok.Focus(); return false; }
            if (cmbVoter.SelectedIndex < 0) { UiKit.Warn(this, "Please choose the voter status."); cmbVoter.Focus(); return false; }

            if (!IsEdit)
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text)) { UiKit.Warn(this, "Please enter a username."); txtUsername.Focus(); return false; }
                if (txtPassword.Text.Length < 6) { UiKit.Warn(this, "The temporary password must be at least 6 characters."); txtPassword.Focus(); return false; }
                if (cmbSecQuestion.SelectedIndex < 0) { UiKit.Warn(this, "Please choose a security question."); cmbSecQuestion.Focus(); return false; }
                if (string.IsNullOrWhiteSpace(txtSecAnswer.Text)) { UiKit.Warn(this, "Please enter the security answer."); txtSecAnswer.Focus(); return false; }
            }
            return true;
        }

        private void Save()
        {
            if (!ValidateInputs()) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();

                    // Same name + birthdate already registered? Ask before creating a likely duplicate.
                    using (MySqlCommand dup = new MySqlCommand(
                        @"SELECT COUNT(*) FROM users
                          WHERE LOWER(first_name) = LOWER(@f) AND LOWER(last_name) = LOWER(@l)
                            AND birthdate = @b AND (@id IS NULL OR user_id <> @id)", conn))
                    {
                        dup.Parameters.AddWithValue("@f", txtFirst.Text.Trim());
                        dup.Parameters.AddWithValue("@l", txtLast.Text.Trim());
                        dup.Parameters.AddWithValue("@b", dtBirth.Value.ToString("yyyy-MM-dd"));
                        dup.Parameters.AddWithValue("@id", IsEdit ? (object)userId.Value : DBNull.Value);
                        if (Convert.ToInt64(dup.ExecuteScalar()) > 0 &&
                            !UiKit.Confirm(this, "A resident with the same name and birthdate is already registered.\n\nSave anyway?", "Possible duplicate", MessageBoxIcon.Warning))
                            return;
                    }

                    if (IsEdit) UpdateResident(conn); else InsertResident(conn);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not save the resident: " + ex.Message);
            }
        }

        private void AddCommonParameters(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@fname", txtFirst.Text.Trim());
            cmd.Parameters.AddWithValue("@mname", txtMiddle.Text.Trim());
            cmd.Parameters.AddWithValue("@lname", txtLast.Text.Trim());
            cmd.Parameters.AddWithValue("@sex", cmbSex.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@bdate", dtBirth.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
            cmd.Parameters.AddWithValue("@purok", cmbPurok.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@house", txtHouse.Text.Trim());
            cmd.Parameters.AddWithValue("@years", (int)nudYears.Value);
            cmd.Parameters.AddWithValue("@voter", cmbVoter.SelectedItem.ToString());
        }

        private void UpdateResident(MySqlConnection conn)
        {
            using (MySqlCommand cmd = new MySqlCommand(
                @"UPDATE users SET first_name = @fname, middle_name = @mname, last_name = @lname, sex = @sex,
                                   birthdate = @bdate, contact_no = @contact, purok_no = @purok, house_no = @house,
                                   years_of_residency = @years, voter_status = @voter
                  WHERE user_id = @id AND (role IS NULL OR LOWER(role) <> 'admin')", conn))
            {
                AddCommonParameters(cmd);
                cmd.Parameters.AddWithValue("@id", userId.Value);
                cmd.ExecuteNonQuery();
            }
        }

        private void InsertResident(MySqlConnection conn)
        {
            using (MySqlCommand check = new MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @u", conn))
            {
                check.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                if (Convert.ToInt64(check.ExecuteScalar()) > 0)
                    throw new InvalidOperationException($"The username '{txtUsername.Text.Trim()}' is already taken.");
            }

            using (MySqlCommand cmd = new MySqlCommand(
                @"INSERT INTO users (username, password, first_name, middle_name, last_name, sex, birthdate, contact_no,
                                     purok_no, house_no, years_of_residency, voter_status, security_question, security_answer)
                  VALUES (@username, @password, @fname, @mname, @lname, @sex, @bdate, @contact,
                          @purok, @house, @years, @voter, @secQ, @secA)", conn))
            {
                AddCommonParameters(cmd);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@password", BCrypt.Net.BCrypt.HashPassword(txtPassword.Text));
                cmd.Parameters.AddWithValue("@secQ", cmbSecQuestion.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@secA", txtSecAnswer.Text.Trim());
                cmd.ExecuteNonQuery();
            }
        }
    }
}
