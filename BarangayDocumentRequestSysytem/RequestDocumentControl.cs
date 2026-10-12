#nullable disable
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BarangayDocumentRequestSysytem
{
    public partial class RequestDocumentControl : UserControl
    {
        private string connectionString = "Server=localhost;Database=barangay_db;Uid=root;Pwd=;";
        private string selectedFilePath = string.Empty;

        public RequestDocumentControl()
        {
            InitializeComponent();
        }

        private void RequestDocumentControl_Load(object sender, EventArgs e)
        {
            if (lblDate != null)
            {
                lblDate.Text = DateHelper.CurrentHeaderDate;
            }

            // Populate Document Types dynamically from Database
            LoadDocumentTypesFromDatabase();
        }

        // Helper to safely get price from DB column or standard Barangay rates
        private decimal GetDocumentFee(string docName, MySqlDataReader reader)
        {
            try
            {
                int priceOrdinal = reader.GetOrdinal("price");
                if (!reader.IsDBNull(priceOrdinal))
                {
                    return Convert.ToDecimal(reader.GetValue(priceOrdinal));
                }
            }
            catch
            {
                // Fallback if 'price' column does not exist in document_types table
            }

            // Standard Barangay Document Rates
            if (docName.Equals("Certificate of Indigency", StringComparison.OrdinalIgnoreCase))
                return 0.00m;
            if (docName.Equals("Barangay ID", StringComparison.OrdinalIgnoreCase))
                return 100.00m;
            if (docName.Equals("Business Permit Endorsement", StringComparison.OrdinalIgnoreCase))
                return 150.00m;

            return 50.00m; // Default standard clearance fee
        }

        // --- 1. Populate cmbDocumentType from MySQL ---
        private void LoadDocumentTypesFromDatabase()
        {
            cmbDocumentType.Items.Clear();
            cmbDocumentType.Items.Add("-- Select Document Type --");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM document_types ORDER BY document_name ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string docName = reader["document_name"].ToString();
                                cmbDocumentType.Items.Add(new DocumentTypeItem
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Name = docName,
                                    Requirements = reader["requirements"].ToString(),
                                    RequiresAttachment = Convert.ToBoolean(reader["requires_attachment"]),
                                    Price = GetDocumentFee(docName, reader)
                                });
                            }
                        }
                    }

                    cmbDocumentType.Items.Add("Others: (Please specify on the field below)");
                    cmbDocumentType.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load document types: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- 2. Handle Document Type Selection ---
        private void cmbDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPurpose.Items.Clear();
            cmbPurpose.Items.Add("-- Select Purpose --");
            cmbPurpose.SelectedIndex = 0;

            // Reset and disable purpose text box when document type changes
            txtOtherPurpose.Enabled = false;
            txtOtherPurpose.BackColor = Color.FromArgb(243, 244, 246);
            txtOtherPurpose.Clear();

            if (cmbDocumentType.SelectedIndex <= 0)
            {
                lblRequirementsList.Text = "None";
                lblFeeAmount.Text = "₱0.00";
                btnAttachFile.Enabled = false;
                txtOtherDocType.Enabled = false;
                txtOtherDocType.BackColor = Color.FromArgb(243, 244, 246);
                return;
            }

            // Check if "Others" selected in Document Type
            bool isOthers = cmbDocumentType.SelectedItem.ToString() == "Others: (Please specify on the field below)";
            txtOtherDocType.Enabled = isOthers;
            txtOtherDocType.BackColor = isOthers ? Color.White : Color.FromArgb(243, 244, 246);

            if (isOthers)
            {
                lblRequirementsList.Text = "Supporting documents for your request";
                lblFeeAmount.Text = "₱50.00";
                btnAttachFile.Enabled = true;
                cmbPurpose.Items.Add("Other Purpose");
                return;
            }
            else
            {
                txtOtherDocType.Clear();
            }

            if (cmbDocumentType.SelectedItem is DocumentTypeItem selectedDoc)
            {
                lblRequirementsList.Text = selectedDoc.Requirements;
                lblFeeAmount.Text = selectedDoc.Price > 0 ? $"₱{selectedDoc.Price:N2}" : "FREE";
                btnAttachFile.Enabled = selectedDoc.RequiresAttachment;
                LoadPurposesForDocumentType(selectedDoc.Id);
            }
        }

        // --- 3. Populate cmbPurpose dynamically based on Selected Document ---
        private void LoadPurposesForDocumentType(int docTypeId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, purpose_name FROM document_purposes WHERE doc_type_id = @DocTypeId ORDER BY purpose_name ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DocTypeId", docTypeId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbPurpose.Items.Add(new PurposeItem
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Name = reader["purpose_name"].ToString()
                                });
                            }
                        }
                    }

                    cmbPurpose.Items.Add("Others");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load document purposes: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- 4. Submit Request Handler ---
        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            int currentUserId = UserSession.UserId;
            string requesterUsername = UserSession.Username;

            if (currentUserId <= 0)
            {
                MessageBox.Show("Invalid session. Please log in again.", "Session Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Document Type Check
            if (cmbDocumentType.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a document type.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDocumentType.Focus();
                return;
            }

            // 2. Purpose Combo Box Check
            if (cmbPurpose.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a purpose for your request.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPurpose.Focus();
                return;
            }

            // 2.5. Check if "Other Purpose" requires text box input
            string selectedPurposeStr = cmbPurpose.SelectedItem.ToString();
            bool isOtherPurpose = selectedPurposeStr == "Others" || selectedPurposeStr == "Other Purpose";

            if (isOtherPurpose && string.IsNullOrWhiteSpace(txtOtherPurpose.Text))
            {
                MessageBox.Show("Please specify your purpose in the field below.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOtherPurpose.Focus();
                return;
            }

            // 3. "Others" Document Type Specification Check
            if (cmbDocumentType.SelectedItem?.ToString() == "Others: (Please specify on the field below)" && string.IsNullOrWhiteSpace(txtOtherDocType.Text))
            {
                MessageBox.Show("Please specify the document type.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOtherDocType.Focus();
                return;
            }

            // 4. Attachment Check
            if (btnAttachFile.Enabled && lblFileStatus.Text == "No file attached.")
            {
                MessageBox.Show("Please attach the required document(s) before submitting.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Resolve Document Type & Purpose String Values
            string finalDocumentType = cmbDocumentType.SelectedItem.ToString() == "Others: (Please specify on the field below)"
                ? txtOtherDocType.Text.Trim()
                : cmbDocumentType.SelectedItem.ToString();

            // Determine final Purpose value to save into MySQL
            string finalPurpose = isOtherPurpose ? txtOtherPurpose.Text.Trim() : selectedPurposeStr;

            // Read Attachment File Bytes
            byte[] fileBytes = null;
            string fileName = null;

            if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
            {
                fileBytes = File.ReadAllBytes(selectedFilePath);
                fileName = Path.GetFileName(selectedFilePath);
            }

            // Database Operations
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string countQuery = "SELECT COALESCE(MAX(user_req_no), 0) + 1 FROM documentrequests WHERE user_id = @UserId";
                    int nextUserReqNo = 1;

                    using (MySqlCommand countCmd = new MySqlCommand(countQuery, conn))
                    {
                        countCmd.Parameters.AddWithValue("@UserId", currentUserId);
                        nextUserReqNo = Convert.ToInt32(countCmd.ExecuteScalar());
                    }

                    string referenceNo = $"REQ-{currentUserId:D4}-{nextUserReqNo:D3}";

                    string insertQuery = @"INSERT INTO documentrequests 
                                  (user_id, user_req_no, reference_no, username, document_type, purpose, attachment_name, attachment_data) 
                                  VALUES (@UserId, @UserRequestNo, @ReferenceNo, @Username, @DocumentType, @Purpose, @FileName, @FileData)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                        cmd.Parameters.AddWithValue("@UserRequestNo", nextUserReqNo);
                        cmd.Parameters.AddWithValue("@ReferenceNo", referenceNo);
                        cmd.Parameters.AddWithValue("@Username", string.IsNullOrEmpty(requesterUsername) ? DBNull.Value : (object)requesterUsername);
                        cmd.Parameters.AddWithValue("@DocumentType", finalDocumentType);
                        cmd.Parameters.AddWithValue("@Purpose", finalPurpose);
                        cmd.Parameters.AddWithValue("@FileName", string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName);
                        cmd.Parameters.AddWithValue("@FileData", fileBytes == null ? DBNull.Value : (object)fileBytes);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Your request has been submitted!\nReference Number: {referenceNo}",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset Form Controls
                        cmbDocumentType.SelectedIndex = 0;
                        cmbPurpose.SelectedIndex = 0;
                        txtOtherDocType.Clear();
                        lblFileStatus.Text = "No file attached.";
                        selectedFilePath = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Document Files (*.pdf;*.docx;*.doc;*.jpg;*.png)|*.pdf;*.docx;*.doc;*.jpg;*.png|PDF Files (*.pdf)|*.pdf|Word Documents (*.docx;*.doc)|*.docx;*.doc|All Files (*.*)|*.*";
                openFileDialog.Title = "Select Requirement Attachment";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                    lblFileStatus.Text = Path.GetFileName(selectedFilePath);
                }
            }
        }

        public class DocumentTypeItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Requirements { get; set; }
            public bool RequiresAttachment { get; set; }
            public decimal Price { get; set; }

            public override string ToString()
            {
                return Name; // Displays in ComboBox
            }
        }

        public class PurposeItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name; // Displays in ComboBox
            }
        }

        private void cmbPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPurpose.SelectedItem == null) return;

            string selectedPurpose = cmbPurpose.SelectedItem.ToString();
            bool isOtherPurpose = selectedPurpose == "Others" || selectedPurpose == "Other Purpose";

            // Enable/Disable the purpose text box
            txtOtherPurpose.Enabled = isOtherPurpose;
            txtOtherPurpose.BackColor = isOtherPurpose ? Color.White : Color.FromArgb(243, 244, 246);

            if (!isOtherPurpose)
            {
                txtOtherPurpose.Clear();
            }
        }
    }
}