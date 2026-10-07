#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class Resident : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;Convert Zero Datetime=True;";

        public Resident()
        {
            InitializeComponent();

            this.Load += Resident_Load;
            this.VisibleChanged += Resident_VisibleChanged;
            this.Resize += (s, e) => CenterModalCard();
        }

        private void Resident_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                UpdateHeaderDate();
                LoadResidents();
                CenterModalCard();
            }
        }

        private void Resident_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !this.DesignMode)
            {
                LoadResidents();
                CenterModalCard();
            }
        }

        private string GetBarangayName(MySqlConnection conn)
        {
            try
            {
                string query = "SELECT barangay_name FROM barangay_info WHERE id = 1 LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        string name = result.ToString().Trim();
                        if (!string.IsNullOrEmpty(name))
                        {
                            return name.StartsWith("Barangay", StringComparison.OrdinalIgnoreCase)
                                ? name
                                : $"Barangay {name}";
                        }
                    }
                }
            }
            catch
            {
                // Fallback in case table is missing or empty
            }
            return "Barangay Central";
        }

        private void CenterModalCard()
        {
            if (pnlModalCard != null && pnlModalOverlay != null)
            {
                pnlModalCard.Location = new Point(
                    Math.Max((pnlModalOverlay.Width - pnlModalCard.Width) / 2, 0),
                    Math.Max((pnlModalOverlay.Height - pnlModalCard.Height) / 2, 0)
                );
            }
        }

        private void UpdateHeaderDate()
        {
            if (lblDate != null)
            {
                lblDate.Text = $"📅 {DateTime.Now:MMMM d, yyyy | dddd}";
            }
        }

        // --- Load Residents from MySQL Database ---
        public void LoadResidents(string filter = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string currentBarangay = GetBarangayName(conn);

                    string query = @"
                        SELECT 
                            user_id,
                            CONCAT('RES-', LPAD(user_id, 3, '0')) AS formatted_id,
                            TRIM(CONCAT(first_name, ' ', IFNULL(CONCAT(middle_name, ' '), ''), last_name)) AS full_name,
                            contact_no,
                            CONCAT(
                                IF(house_no IS NOT NULL AND TRIM(house_no) != '', CONCAT('House #', house_no, ', '), ''),
                                'Purok ', IFNULL(purok_no, 'N/A'), ', ', @brgyName
                            ) AS full_address,
                            sex,
                            birthdate,
                            house_no,
                            purok_no,
                            years_of_residency,
                            voter_status
                        FROM users
                        WHERE role='user'";

                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        query += @" AND (
                            first_name LIKE @filter OR 
                            last_name LIKE @filter OR 
                            contact_no LIKE @filter OR 
                            purok_no LIKE @filter OR 
                            CONCAT('RES-', LPAD(user_id, 3, '0')) LIKE @filter
                        )";
                    }

                    query += " ORDER BY user_id DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@brgyName", currentBarangay);

                        if (!string.IsNullOrWhiteSpace(filter))
                        {
                            cmd.Parameters.AddWithValue("@filter", $"%{filter}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvResidents.DataSource = dt;

                            if (pageLBL != null)
                            {
                                pageLBL.Text = $"Total Residents Registered: {dt.Rows.Count}";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading residents: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- DGV Action Click Handler (View / Delete) ---
        private void DgvResidents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int userId = Convert.ToInt32(dgvResidents.Rows[e.RowIndex].Cells["user_id"].Value);
            string colName = dgvResidents.Columns[e.ColumnIndex].Name;

            if (colName == "btnView")
            {
                ShowResidentDetailsModal(userId);
            }
            else if (colName == "btnDelete")
            {
                string residentName = dgvResidents.Rows[e.RowIndex].Cells["full_name"].Value?.ToString();
                DialogResult dialogResult = MessageBox.Show(
                    $"Are you sure you want to delete resident '{residentName}'?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    DeleteResident(userId);
                }
            }
        }

        // --- View Details Modal ---
        private void ShowResidentDetailsModal(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string currentBarangay = GetBarangayName(conn);

                    string query = @"
                        SELECT user_id, first_name, middle_name, last_name, sex, birthdate, 
                               contact_no, house_no, purok_no, years_of_residency, voter_status
                        FROM users WHERE user_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblModalTitle.Text = $"👤 Resident Profile (RES-{userId:D3})";

                                string fullName = $"{reader["first_name"]} {reader["middle_name"]} {reader["last_name"]}".Replace("  ", " ");
                                lblValFullName.Text = fullName;
                                lblValSex.Text = reader["sex"]?.ToString() ?? "N/A";

                                if (reader["birthdate"] != DBNull.Value)
                                {
                                    DateTime bdate = Convert.ToDateTime(reader["birthdate"]);
                                    int age = DateTime.Today.Year - bdate.Year;
                                    if (bdate.Date > DateTime.Today.AddYears(-age)) age--;
                                    lblValBirthdate.Text = $"{bdate:MMM dd, yyyy} ({age} yrs old)";
                                }
                                else
                                {
                                    lblValBirthdate.Text = "N/A";
                                }

                                lblValContact.Text = string.IsNullOrWhiteSpace(reader["contact_no"]?.ToString()) ? "N/A" : reader["contact_no"].ToString();

                                string house = reader["house_no"]?.ToString();
                                string purok = reader["purok_no"]?.ToString();
                                string housePart = string.IsNullOrWhiteSpace(house) ? "" : $"House #{house}, ";
                                lblValAddress.Text = $"{housePart}Purok {purok}, {currentBarangay}";

                                lblValResidency.Text = $"{reader["years_of_residency"]} Year(s)";
                                lblValVoter.Text = reader["voter_status"]?.ToString() ?? "N/A";

                                CenterModalCard();
                                pnlModalOverlay.BringToFront();
                                pnlModalOverlay.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving resident details: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteResident(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM users WHERE user_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Resident successfully deleted.", "Record Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadResidents(searchTB.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete resident: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnModalClose_Click(object sender, EventArgs e)
        {
            pnlModalOverlay.Visible = false;
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            LoadResidents(searchTB.Text.Trim());
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            LoadResidents(searchTB.Text.Trim());
        }

        private void AddResidentButton_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();
            AddResident addresidentContent = new AddResident();
            addresidentContent.Dock = DockStyle.Fill;
            PanelContainer.Controls.Add(addresidentContent);
            PanelContainer.Visible = true;
        }
    }
}