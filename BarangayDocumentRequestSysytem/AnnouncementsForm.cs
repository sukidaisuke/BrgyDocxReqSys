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

        private int editingId = -1;      // announcement being edited; -1 = writing a new one
        private Button btnEdit;

        public AnnouncementsForm()
        {
            InitializeComponent();
            AddEditButton();
            LoadAnnouncementsFromDatabase();
        }

        // "Edit Selected" sits next to Delete; double-clicking a row does the same thing.
        private void AddEditButton()
        {
            btnEdit = new Button
            {
                Name = "btnEdit",
                Text = "✏ Edit Selected",
                BackColor = System.Drawing.Color.FromArgb(37, 99, 235),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold),
                Cursor = Cursors.Hand,
                Location = new System.Drawing.Point(btnDelete.Right + 10, btnDelete.Top),
                Size = btnDelete.Size,
                UseVisualStyleBackColor = false
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += btnEdit_Click;
            Controls.Add(btnEdit);

            dgvAnnouncements.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) BeginEdit(); };
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (editingId > 0) { EndEdit(); return; }
            BeginEdit();
        }

        private void BeginEdit()
        {
            if (dgvAnnouncements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an announcement row from the list to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvAnnouncements.SelectedRows[0];
            if (row.Cells["ID"].Value == null || !int.TryParse(row.Cells["ID"].Value.ToString(), out int id)) return;

            editingId = id;
            txtTitle.Text = row.Cells["Title"].Value?.ToString() ?? "";
            txtContent.Text = row.Cells["Content"].Value?.ToString() ?? "";

            string category = row.Cells["Category"].Value?.ToString();
            int idx = category == null ? -1 : cmbCategory.FindStringExact(category);
            if (idx >= 0) cmbCategory.SelectedIndex = idx;

            btnPublish.Text = "💾 Save Changes";
            btnEdit.Text = "✖ Cancel Edit";
            btnDelete.Enabled = false;
            txtTitle.Focus();
        }

        private void EndEdit()
        {
            editingId = -1;
            txtTitle.Clear();
            txtContent.Clear();
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            btnPublish.Text = "📢 Publish Notice";
            btnEdit.Text = "✏ Edit Selected";
            btnDelete.Enabled = true;
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

            // Editing an existing announcement: keep its original posting date
            if (editingId > 0)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(
                            "UPDATE announcements SET title = @title, category = @category, content = @content WHERE announcement_id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@content", txtContent.Text.Trim());
                            cmd.Parameters.AddWithValue("@id", editingId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    EndEdit();
                    LoadAnnouncementsFromDatabase();
                    MessageBox.Show("Announcement updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update announcement: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

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