using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class Information_Update : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public Information_Update()
        {
            InitializeComponent();
        }

        private void Information_Update_Load(object sender, EventArgs e)
        {
            LoadRequests();
        }

        public void LoadRequests()
        {
            string query = @"SELECT 
                                r.request_id AS 'Request ID',
                                CONCAT(u.first_name, ' ', u.last_name) AS 'Resident Name',
                                u.contact_no AS 'Contact Number',
                                r.request_date AS 'Date Requested',
                                r.status AS 'Status'
                             FROM info_update_requests r
                             JOIN users u ON r.user_id = u.user_id
                             ORDER BY r.request_id DESC";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvRequests.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading update requests: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            UpdateRequestStatus("Approved");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            UpdateRequestStatus("Rejected");
        }

        private void UpdateRequestStatus(string newStatus)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request row from the list.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int requestId = Convert.ToInt32(dgvRequests.SelectedRows[0].Cells["Request ID"].Value);

            string query = "UPDATE info_update_requests SET status = @Status WHERE request_id = @RequestId";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@RequestId", requestId);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Request #{requestId} updated to '{newStatus}'.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRequests();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating request status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequests();
        }
    }
}