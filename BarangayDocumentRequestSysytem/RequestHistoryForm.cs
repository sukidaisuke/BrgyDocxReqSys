using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class RequestHistoryForm : Form
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public RequestHistoryForm()
        {
            InitializeComponent();
        }

        private void RequestHistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void LoadHistory()
        {
            // Fetch completed, approved, or rejected requests
            string query = @"SELECT 
                                CONCAT(u.first_name, ' ', u.last_name) AS 'Resident Name',
                                u.contact_no AS 'Contact Number',
                                r.request_date AS 'Date Requested',
                                r.status AS 'Status'
                             FROM info_update_requests r
                             JOIN users u ON r.user_id = u.user_id
                             WHERE r.status IN ('Approved', 'Rejected', 'Completed')
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
                        dgvHistory.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading request history: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}