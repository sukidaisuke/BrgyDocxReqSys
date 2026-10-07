#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class BarangayInfo : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;Convert Zero Datetime=True;";

        public BarangayInfo()
        {
            InitializeComponent();
            this.Load += BarangayInfo_Load;
        }

        private void BarangayInfo_Load(object sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            LoadBarangayInfo();
        }

        private void SetupDataGridViewStyle()
        {
            dgvBrgyInfo.EnableHeadersVisualStyles = false;
            dgvBrgyInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(48, 44, 105);
            dgvBrgyInfo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBrgyInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvBrgyInfo.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvBrgyInfo.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 225, 245);
            dgvBrgyInfo.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvBrgyInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvBrgyInfo.RowHeadersVisible = false;
            dgvBrgyInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBrgyInfo.MultiSelect = false;
            dgvBrgyInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadBarangayInfo()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM barangay_info WHERE id = 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Information Field", typeof(string));
                        dt.Columns.Add("Details / Value", typeof(string));

                        if (reader.Read())
                        {
                            dt.Rows.Add("Barangay Name", reader["barangay_name"].ToString());
                            dt.Rows.Add("Municipality / City", reader["municipality"].ToString());
                            dt.Rows.Add("Province", reader["province"].ToString());
                            dt.Rows.Add("Region", reader["region"].ToString());
                            dt.Rows.Add("Zip Code", reader["zip_code"].ToString());
                            dt.Rows.Add("Office Address", reader["office_address"].ToString());
                            dt.Rows.Add("Contact Number", reader["contact_number"].ToString());
                            dt.Rows.Add("Office Email", reader["office_email"].ToString());
                            dt.Rows.Add("Office Hours", reader["office_hours"].ToString());
                        }

                        dgvBrgyInfo.DataSource = dt;
                        if (dgvBrgyInfo.Columns["Information Field"] != null)
                        {
                            dgvBrgyInfo.Columns["Information Field"].ReadOnly = true;
                            dgvBrgyInfo.Columns["Information Field"].Width = 150;
                        }
                    }
                    ClearSelectionAndInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading barangay info: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvBrgyInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBrgyInfo.Rows[e.RowIndex];
                lblFieldHeader.Text = row.Cells["Information Field"].Value?.ToString() ?? "Field Value";
                txtFieldValue.Text = row.Cells["Details / Value"].Value?.ToString() ?? "";
                btnUpdateField.Enabled = true;
            }
        }

        private void btnUpdateField_Click(object sender, EventArgs e)
        {
            if (dgvBrgyInfo.CurrentRow == null || dgvBrgyInfo.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a field from the table to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fieldName = dgvBrgyInfo.CurrentRow.Cells["Information Field"].Value?.ToString();
            string newValue = txtFieldValue.Text.Trim();

            string dbColumnName = GetColumnName(fieldName);
            if (string.IsNullOrEmpty(dbColumnName)) return;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = $"UPDATE barangay_info SET {dbColumnName} = @val WHERE id = 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@val", newValue);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"{fieldName} updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBarangayInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating info: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetColumnName(string fieldName)
        {
            return fieldName switch
            {
                "Barangay Name" => "barangay_name",
                "Municipality / City" => "municipality",
                "Province" => "province",
                "Region" => "region",
                "Zip Code" => "zip_code",
                "Office Address" => "office_address",
                "Contact Number" => "contact_number",
                "Office Email" => "office_email",
                "Office Hours" => "office_hours",
                _ => string.Empty
            };
        }

        private void ClearSelectionAndInputs()
        {
            lblFieldHeader.Text = "Select a field to edit";
            txtFieldValue.Clear();
            btnUpdateField.Enabled = false;
            if (dgvBrgyInfo.Rows.Count > 0)
            {
                dgvBrgyInfo.ClearSelection();
            }
        }
    }
}