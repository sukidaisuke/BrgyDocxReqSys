#nullable disable
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BarangayDocumentRequestSysytem
{
    public partial class AnnouncementsForm : Form
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public AnnouncementsForm()
        {
            InitializeComponent();
            LoadAnnouncementsFromDatabase();
        }

        private void LoadAnnouncementsFromDatabase()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT announcement_id AS `ID`, title AS `Title`, category AS `Category`, DATE_FORMAT(date_posted, '%b %d, %Y') AS `Date Posted`, content AS `Content` FROM announcements ORDER BY announcement_id DESC";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvAnnouncements.DataSource = dt;

                        if (dgvAnnouncements.Columns["Content"] != null)
                        {
                            dgvAnnouncements.Columns["Content"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Please enter both announcement title and content.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string category = cmbCategory.SelectedItem != null ? cmbCategory.SelectedItem.ToString() : "General Notice";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO announcements (title, category, content, date_posted) VALUES (@title, @category, @content, NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@content", txtContent.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                txtTitle.Clear();
                txtContent.Clear();
                if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;

                LoadAnnouncementsFromDatabase();
                MessageBox.Show("Announcement published successfully to the system and database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save announcement: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnnouncements.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAnnouncements.SelectedRows[0];
                if (row.Cells["ID"].Value != null && int.TryParse(row.Cells["ID"].Value.ToString(), out int id))
                {
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete this announcement?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            using (MySqlConnection conn = new MySqlConnection(connectionString))
                            {
                                conn.Open();
                                string query = "DELETE FROM announcements WHERE announcement_id = @id";
                                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", id);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            LoadAnnouncementsFromDatabase();
                            MessageBox.Show("Announcement deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to delete record: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an announcement row from the list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}