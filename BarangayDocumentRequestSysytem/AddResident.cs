#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class AddResident : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;Convert Zero Datetime=True;";
        private int selectedUserId = -1;

        public AddResident()
        {
            InitializeComponent();
            this.Load += AddResident_Load;
        }

        private void AddResident_Load(object sender, EventArgs e)
        {
            lblDate.Text = $"📅 {DateTime.Now:MMMM d, yyyy | dddd}";
            ResetForm();
        }

        // --- Lookup Resident by ID (Supports "RES-001" or plain "1") ---
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string rawInput = resIdTB.Text.Trim();

            if (string.IsNullOrWhiteSpace(rawInput))
            {
                MessageBox.Show("Please enter a Resident ID.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Extract numeric ID if formatted like "RES-001"
            string cleanId = rawInput.ToUpper().Replace("RES-", "").TrimStart('0');
            if (!int.TryParse(cleanId, out int userId))
            {
                MessageBox.Show("Invalid Resident ID format. Please enter a valid ID (e.g., RES-001 or 1).", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FetchResidentDetails(userId);
        }

        private void FetchResidentDetails(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT user_id, 
                               TRIM(CONCAT(first_name, ' ', IFNULL(CONCAT(middle_name, ' '), ''), last_name)) AS full_name,
                               CONCAT(
                                   IF(house_no IS NOT NULL AND TRIM(house_no) != '', CONCAT('House #', house_no, ', '), ''),
                                   'Purok ', IFNULL(purok_no, 'N/A'),
                                   ', Barangay Central'
                               ) AS full_address,
                               years_of_residency, 
                               voter_status 
                        FROM users 
                        WHERE user_id = @id AND (role != 'Admin' OR role IS NULL)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedUserId = Convert.ToInt32(reader["user_id"]);
                                lblValFullName.Text = reader["full_name"].ToString();
                                lblValAddress.Text = reader["full_address"].ToString();

                                // Safe parsing for years of residency
                                object rawResidency = reader["years_of_residency"];
                                if (rawResidency != DBNull.Value && decimal.TryParse(rawResidency.ToString(), out decimal parsedResidency))
                                {
                                    residencyNUD.Value = Math.Min(Math.Max(parsedResidency, residencyNUD.Minimum), residencyNUD.Maximum);
                                }
                                else
                                {
                                    residencyNUD.Value = 0;
                                }

                                // Set Voter Status
                                string voterStatus = reader["voter_status"]?.ToString() ?? "No";
                                voterCB.SelectedItem = voterCB.Items.Contains(voterStatus) ? voterStatus : "No";

                                updateButton.Enabled = true; // Enables Save button on successful fetch
                            }
                            else
                            {
                                MessageBox.Show("No resident found matching that ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ResetForm();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving resident details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Save Changes Event Handler ---
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please search and select a resident first before saving.", "No Resident Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newResidency = (int)residencyNUD.Value;
            string newVoterStatus = voterCB.SelectedItem?.ToString() ?? "No";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        UPDATE users 
                        SET years_of_residency = @residency, 
                            voter_status = @voter 
                        WHERE user_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@residency", newResidency);
                        cmd.Parameters.AddWithValue("@voter", newVoterStatus);
                        cmd.Parameters.AddWithValue("@id", selectedUserId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Resident details updated successfully!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NavigateBackToResidents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update resident details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            NavigateBackToResidents();
        }

        private void ResetForm()
        {
            selectedUserId = -1;
            resIdTB.Clear();
            lblValFullName.Text = "— Search Resident ID —";
            lblValAddress.Text = "— Search Resident ID —";
            residencyNUD.Value = 0;
            voterCB.SelectedIndex = 0;
            updateButton.Enabled = false; // Disabled until searched
        }

        private void NavigateBackToResidents()
        {
            if (this.Parent is Panel parentPanel)
            {
                parentPanel.Controls.Clear();
                Resident residentList = new Resident();
                residentList.Dock = DockStyle.Fill;
                parentPanel.Controls.Add(residentList);
            }
        }
    }
}