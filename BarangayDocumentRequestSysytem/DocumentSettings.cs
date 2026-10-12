#nullable disable
using MySql.Data.MySqlClient; // MySQL driver
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class DocumentSettings : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public DocumentSettings()
        {
            InitializeComponent();
            ApplyCustomGridStyling();
        }

        private void DocumentSettings_Load(object sender, EventArgs e)
        {
            LoadDocumentTypes();
        }

        private void DocumentSettings_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadDocumentTypes();
            }
        }

        private void ApplyCustomGridStyling()
        {
            // Disable OS default styles to use theme colors
            dgvDocumentSettings.EnableHeadersVisualStyles = false;

            Color headerBg = Color.FromArgb(186, 218, 231); // Light blue header
            Color headerFg = Color.FromArgb(30, 41, 59);    // Slate text

            dgvDocumentSettings.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            dgvDocumentSettings.ColumnHeadersDefaultCellStyle.ForeColor = headerFg;
            dgvDocumentSettings.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBg;
            dgvDocumentSettings.ColumnHeadersDefaultCellStyle.SelectionForeColor = headerFg;

            dgvDocumentSettings.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvDocumentSettings.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // Configure proportional column widths
            if (dgvDocumentSettings.Columns["colDocName"] != null)
            {
                dgvDocumentSettings.Columns["colDocName"].FillWeight = 190F;
                dgvDocumentSettings.Columns["colPrice"].FillWeight = 110F;
                dgvDocumentSettings.Columns["colAction"].FillWeight = 90F;
            }
        }

        public void LoadDocumentTypes()
        {
            dgvDocumentSettings.Rows.Clear();

            string query = "SELECT id, document_name, price FROM document_types ORDER BY id ASC";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0;
                                string docName = reader["document_name"].ToString();
                                decimal price = reader["price"] != DBNull.Value ? Convert.ToDecimal(reader["price"]) : 0m;

                                dgvDocumentSettings.Rows.Add(id, docName, price.ToString("0.00"));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading document prices from database: {ex.Message}",
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            dgvDocumentSettings.ClearSelection();
        }

        private void dgvDocumentSettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle row 'Update' button click
            if (e.RowIndex >= 0 && dgvDocumentSettings.Columns[e.ColumnIndex].Name == "colAction")
            {
                dgvDocumentSettings.EndEdit(); // Commit active cell edit
                SaveRowPrice(e.RowIndex);
            }
        }

        private void SaveRowPrice(int rowIndex)
        {
            DataGridViewRow row = dgvDocumentSettings.Rows[rowIndex];
            if (row.Cells["colId"].Value == null) return;

            int id = Convert.ToInt32(row.Cells["colId"].Value);
            string docName = row.Cells["colDocName"].Value?.ToString();
            string priceInput = row.Cells["colPrice"].Value?.ToString();

            if (!decimal.TryParse(priceInput, out decimal newPrice) || newPrice < 0)
            {
                MessageBox.Show($"Please enter a valid non-negative numeric price for '{docName}'.",
                    "Invalid Price Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string updateQuery = "UPDATE document_types SET price = @Price WHERE id = @Id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Price", newPrice);
                    cmd.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Price for '{docName}' successfully updated to ₱{newPrice:N2}!",
                                "Price Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDocumentTypes();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to update price in database: {ex.Message}",
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            dgvDocumentSettings.EndEdit();

            int updatedCount = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    foreach (DataGridViewRow row in dgvDocumentSettings.Rows)
                    {
                        if (row.IsNewRow || row.Cells["colId"].Value == null) continue;

                        int id = Convert.ToInt32(row.Cells["colId"].Value);
                        string priceInput = row.Cells["colPrice"].Value?.ToString();

                        if (decimal.TryParse(priceInput, out decimal newPrice) && newPrice >= 0)
                        {
                            string updateQuery = "UPDATE document_types SET price = @Price WHERE id = @Id";
                            using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Price", newPrice);
                                cmd.Parameters.AddWithValue("@Id", id);
                                updatedCount += cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show($"All document prices ({updatedCount} items) saved to database successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDocumentTypes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving changes: {ex.Message}",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}