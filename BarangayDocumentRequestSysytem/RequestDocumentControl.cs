using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySQL driver

namespace BarangayDocumentRequestSysytem
{
    public partial class RequestDocumentControl : UserControl
    {
        // XAMPP default MySQL connection string
        private string connectionString = "Server=localhost;Database=barangay_db;Uid=root;Pwd=;";
        private string selectedFilePath = string.Empty;

        public RequestDocumentControl()
        {
            InitializeComponent();
        }

        public static class UserSession
        {
            public static string Username { get; set; }
            public static int UserId { get; set; }
        }

        private void txtPurpose_TextChanged(object sender, EventArgs e)
        {
            lblPurposeCount.Text = $"{txtPurpose.Text.Length}/300";


        }

        private void cmbDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocumentType.SelectedItem == null) return;

            string selectedType = cmbDocumentType.SelectedItem.ToString();
            bool isOthers = selectedType == "Others: (Please specify on the field below)";

            txtOtherDocType.Enabled = isOthers;
            txtOtherDocType.BackColor = isOthers ? Color.White : Color.FromArgb(243, 244, 246);

            if (!isOthers)
            {
                txtOtherDocType.Clear();
            }

            string requirements = "";
            bool needsAttachment = true; // Default to true for valid choices

            switch (selectedType)
            {
                case "Barangay Clearance":
                    requirements = "Valid ID";
                    break;
                case "Certificate of Indigency":
                    requirements = "Valid ID, Proof of low income";
                    break;
                case "Certificate of Residency":
                    requirements = "Valid ID, Proof of Address";
                    break;
                case "Certificate of Good Moral Character":
                    requirements = "Valid ID, Barangay Clearance";
                    break;
                case "Business Permit Endorsement":
                    requirements = "DTI Registration, Proof of Business Address";
                    break;
                case "Barangay ID":
                    requirements = "Valid ID, 1x1 Photo";
                    break;
                case "Certificate of No Pending Case":
                    requirements = "Court Documents";
                    break;
                case "Others: (Please specify on the field below)":
                    requirements = "Supporting documents for your request";
                    break;
                default:
                    // Only index 0 ("-- Select Document Type --") reaches here
                    requirements = "None";
                    needsAttachment = false;
                    break;
            }

            lblRequirementsList.Text = requirements;
            btnAttachFile.Enabled = needsAttachment;
        }

        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            // Retrieve logged-in session data
            string requesterUsername = UserSession.Username;
            int currentUserId = UserSession.UserId;

            // Session Check
            if (currentUserId <= 0)
            {
                MessageBox.Show("Invalid session. Please log in again.", "Session Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Purpose required
            if (string.IsNullOrWhiteSpace(txtPurpose.Text))
            {
                MessageBox.Show("Please enter the purpose of your request.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPurpose.Focus();
                return;
            }

            // 2. Purpose length check
            if (txtPurpose.Text.Trim().Length < 10)
            {
                MessageBox.Show("Purpose must be at least 10 characters long.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPurpose.Focus();
                return;
            }

            // 3. Document type required
            if (cmbDocumentType.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a document type.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDocumentType.Focus();
                return;
            }

            // 4. "Others" check
            if (cmbDocumentType.SelectedItem?.ToString() == "Others: (Please specify on the field below)" && string.IsNullOrWhiteSpace(txtOtherDocType.Text))
            {
                MessageBox.Show("Please specify the document type.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOtherDocType.Focus();
                return;
            }

            // 5. Attachment check
            if (btnAttachFile.Enabled && lblFileStatus.Text == "No file attached.")
            {
                MessageBox.Show("Please attach the required document(s) before submitting.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determine final Document Type string
            string documentType = cmbDocumentType.SelectedItem.ToString() == "Others: (Please specify on the field below)"
                ? txtOtherDocType.Text.Trim()
                : cmbDocumentType.SelectedItem.ToString();

            // Read binary attachment data
            byte[] fileBytes = null;
            string fileName = null;

            if (!string.IsNullOrEmpty(selectedFilePath) && File.Exists(selectedFilePath))
            {
                fileBytes = File.ReadAllBytes(selectedFilePath);
                fileName = Path.GetFileName(selectedFilePath);
            }

            // Database Insert Operation
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Calculate next user sequence count
                    string countQuery = "SELECT COALESCE(MAX(user_req_no), 0) + 1 FROM documentrequests WHERE user_id = @UserId";
                    int nextUserReqNo = 1;

                    using (MySqlCommand countCmd = new MySqlCommand(countQuery, conn))
                    {
                        countCmd.Parameters.AddWithValue("@UserId", currentUserId);
                        nextUserReqNo = Convert.ToInt32(countCmd.ExecuteScalar());
                    }

                    // 2. Format Reference Number (e.g., REQ-0005-001)
                    string referenceNo = $"REQ-{currentUserId:D4}-{nextUserReqNo:D3}";

                    // 3. Insert record into database (Includes 'username')
                    string insertQuery = @"INSERT INTO documentrequests 
                                  (user_id, user_req_no, reference_no, username, document_type, purpose, attachment_name, attachment_data) 
                                  VALUES (@UserId, @UserRequestNo, @ReferenceNo, @Username, @DocumentType, @Purpose, @FileName, @FileData)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", currentUserId);
                        cmd.Parameters.AddWithValue("@UserRequestNo", nextUserReqNo);
                        cmd.Parameters.AddWithValue("@ReferenceNo", referenceNo);
                        cmd.Parameters.AddWithValue("@Username", string.IsNullOrEmpty(requesterUsername) ? DBNull.Value : (object)requesterUsername);
                        cmd.Parameters.AddWithValue("@DocumentType", documentType);
                        cmd.Parameters.AddWithValue("@Purpose", txtPurpose.Text.Trim());
                        cmd.Parameters.AddWithValue("@FileName", string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName);
                        cmd.Parameters.AddWithValue("@FileData", fileBytes == null ? DBNull.Value : (object)fileBytes);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Your request has been submitted!\nReference Number: {referenceNo}",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset form
                        cmbDocumentType.SelectedIndex = 0;
                        txtOtherDocType.Clear();
                        txtPurpose.Clear();
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
                // Define allowable file types
                openFileDialog.Filter = "Document Files (*.pdf;*.docx;*.doc;*.jpg;*.png)|*.pdf;*.docx;*.doc;*.jpg;*.png|PDF Files (*.pdf)|*.pdf|Word Documents (*.docx;*.doc)|*.docx;*.doc|All Files (*.*)|*.*";
                openFileDialog.Title = "Select Requirement Attachment";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Store full file path
                    selectedFilePath = openFileDialog.FileName;

                    // Display only the file name on the label (replace 'lblFileName' with your label's Name property)
                    lblFileStatus.Text = Path.GetFileName(selectedFilePath);
                }
            }
        }
    }
}
