#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class Signatories : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;Convert Zero Datetime=True;";
        private int selectedSignatoryId = -1;

        public Signatories()
        {
            InitializeComponent();
            this.Load += Signatories_Load;
        }

        private void Signatories_Load(object sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            LoadSignatories();
        }

        private void SetupDataGridViewStyle()
        {
            dgvSignatories.EnableHeadersVisualStyles = false;
            dgvSignatories.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(48, 44, 105);
            dgvSignatories.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSignatories.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvSignatories.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvSignatories.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 225, 245);
            dgvSignatories.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvSignatories.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvSignatories.RowHeadersVisible = false;
            dgvSignatories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSignatories.MultiSelect = false;
            dgvSignatories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSignatories()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT signatory_id AS 'ID', position AS 'Position / Title', official_name AS 'Official Name' FROM signatories ORDER BY signatory_id ASC";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvSignatories.DataSource = dt;

                        // Hide ID column from UI display
                        if (dgvSignatories.Columns["ID"] != null)
                        {
                            dgvSignatories.Columns["ID"].Visible = false;
                        }
                    }
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading signatories: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvSignatories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSignatories.Rows[e.RowIndex].Cells["ID"].Value != DBNull.Value)
            {
                DataGridViewRow row = dgvSignatories.Rows[e.RowIndex];
                if (int.TryParse(row.Cells["ID"].Value?.ToString(), out int id))
                {
                    selectedSignatoryId = id;
                    cmbPosition.Text = row.Cells["Position / Title"].Value?.ToString() ?? "";
                    txtName.Text = row.Cells["Official Name"].Value?.ToString() ?? "";

                    btnDelete.Enabled = true;
                    btnSave.Text = "💾 Update";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string position = cmbPosition.Text.Trim();
            string name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(position) || string.IsNullOrWhiteSpace(name) || cmbPosition.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a Position (Captain, Secretary or Treasurer) and enter the Official Name.", "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd;

                    if (selectedSignatoryId == -1)
                    {
                        string query = "INSERT INTO signatories (position, official_name, status) VALUES (@pos, @name, 'Active')";
                        cmd = new MySqlCommand(query, conn);
                    }
                    else
                    {
                        string query = "UPDATE signatories SET position = @pos, official_name = @name WHERE signatory_id = @id";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", selectedSignatoryId);
                    }

                    cmd.Parameters.AddWithValue("@pos", position);
                    cmd.Parameters.AddWithValue("@name", name);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Signatory details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSignatories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving signatory: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSignatoryId == -1)
            {
                MessageBox.Show("Please select a signatory from the list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this official signatory?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM signatories WHERE signatory_id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedSignatoryId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Signatory deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSignatories();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting signatory: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearInputs()
        {
            selectedSignatoryId = -1;
            cmbPosition.SelectedIndex = -1;
            cmbPosition.Text = "";
            txtName.Clear();
            btnDelete.Enabled = false;
            btnSave.Text = "➕ Add New";
            if (dgvSignatories.Rows.Count > 0)
            {
                dgvSignatories.ClearSelection();
            }
        }
    }
}