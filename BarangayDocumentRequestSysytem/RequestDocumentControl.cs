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

        // One row per requirement of the selected document (e.g. "Valid ID", "Proof of Residency")
        private class RequirementRow
        {
            public string Name;
            public string FilePath = "";
            public Label NameLabel;
            public Label StatusLabel;
            public Button AttachButton;
        }

        private readonly System.Collections.Generic.List<RequirementRow> requirementRows = new System.Collections.Generic.List<RequirementRow>();
        private Panel pnlRequirementFiles;

        public RequestDocumentControl()
        {
            InitializeComponent();
            SetupRequirementUploader();
        }

        // The old single "Attach File" button is replaced by one attach row per requirement.
        private void SetupRequirementUploader()
        {
            AutoScroll = true;
            panel3.Visible = false;     // old single-file controls (kept only so the designer file still compiles)

            pnlRequirementFiles = new Panel
            {
                Name = "pnlRequirementFiles",
                Location = new Point(0, 24),
                Size = new Size(panel2.Width, 0),
                BackColor = Color.Transparent
            };
            panel2.Controls.Add(pnlRequirementFiles);
            LayoutForRows();
        }

        // Splits the requirements text from the database into individual requirement names
        private static System.Collections.Generic.List<string> ParseRequirements(string text)
        {
            var result = new System.Collections.Generic.List<string>();
            if (string.IsNullOrWhiteSpace(text)) return result;

            string[] parts = text.Split(new[] { '\r', '\n', ',', ';', '|', '\u2022' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string raw in parts)
            {
                string item = raw.Trim().TrimStart('-', '*', ' ').Trim();
                // strip "1." / "2)" numbering
                int i = 0;
                while (i < item.Length && char.IsDigit(item[i])) i++;
                if (i > 0 && i < item.Length && (item[i] == '.' || item[i] == ')')) item = item.Substring(i + 1).Trim();

                if (item.Length == 0) continue;
                if (item.Equals("none", StringComparison.OrdinalIgnoreCase) || item.Equals("n/a", StringComparison.OrdinalIgnoreCase)) continue;
                result.Add(item);
            }
            return result;
        }

        private void BuildRequirementRows(System.Collections.Generic.List<string> names)
        {
            foreach (RequirementRow r in requirementRows)
            {
                r.NameLabel.Dispose();
                r.StatusLabel.Dispose();
                r.AttachButton.Dispose();
            }
            requirementRows.Clear();
            pnlRequirementFiles.Controls.Clear();

            int y = 2;
            foreach (string name in names)
            {
                RequirementRow row = new RequirementRow { Name = name };

                row.NameLabel = new Label
                {
                    Text = name + ":",
                    AutoSize = false,
                    Location = new Point(6, y + 5),
                    Size = new Size(165, 20),
                    Font = new Font("Gill Sans MT", 9.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(55, 65, 81),
                    AutoEllipsis = true
                };
                row.StatusLabel = new Label
                {
                    Text = "No file attached.",
                    AutoSize = false,
                    Location = new Point(175, y + 6),
                    Size = new Size(215, 18),
                    ForeColor = SystemColors.ControlDarkDark,
                    AutoEllipsis = true
                };
                row.AttachButton = new Button
                {
                    Text = "⬆ Attach File",
                    Location = new Point(399, y + 2),
                    Size = new Size(90, 25),
                    UseVisualStyleBackColor = true
                };
                RequirementRow captured = row;
                row.AttachButton.Click += (s, e) => PickFileForRow(captured);

                pnlRequirementFiles.Controls.Add(row.NameLabel);
                pnlRequirementFiles.Controls.Add(row.StatusLabel);
                pnlRequirementFiles.Controls.Add(row.AttachButton);
                requirementRows.Add(row);
                y += 32;
            }

            LayoutForRows();
        }

        // Grow the requirements box (and the form card below it) to fit the attach rows
        private void LayoutForRows()
        {
            int rowsHeight = Math.Max(requirementRows.Count * 32 + 4, 0);
            pnlRequirementFiles.Height = rowsHeight;
            pnlRequirementFiles.Width = panel2.Width;

            panel2.Height = Math.Max(63, 26 + rowsHeight);
            btnSubmitRequest.Top = panel2.Bottom + 12;
            panel1.Height = btnSubmitRequest.Bottom + 14;
            AutoScrollMinSize = new Size(0, panel1.Bottom + 20);
        }

        private void PickFileForRow(RequirementRow row)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Document Files (*.pdf;*.docx;*.doc;*.jpg;*.jpeg;*.png)|*.pdf;*.docx;*.doc;*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";
                openFileDialog.Title = "Attach: " + row.Name;

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                // Keep attachments under 5 MB so they can be stored in the database
                long sizeBytes = new FileInfo(openFileDialog.FileName).Length;
                if (sizeBytes > 5 * 1024 * 1024)
                {
                    MessageBox.Show(
                        $"This file is {sizeBytes / (1024.0 * 1024.0):0.0} MB. Please choose a file smaller than 5 MB.",
                        "File Too Large", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                row.FilePath = openFileDialog.FileName;
                row.StatusLabel.Text = Path.GetFileName(row.FilePath);
                row.StatusLabel.ForeColor = Color.FromArgb(22, 101, 52);
                row.AttachButton.Text = "↻ Change";
            }
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
                BuildRequirementRows(new System.Collections.Generic.List<string>());
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
                BuildRequirementRows(new System.Collections.Generic.List<string> { "Supporting document" });
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

                // One attach field per requirement (ID, Proof of Residency, ...)
                var names = new System.Collections.Generic.List<string>();
                if (selectedDoc.RequiresAttachment)
                {
                    names = ParseRequirements(selectedDoc.Requirements);
                    if (names.Count == 0) names.Add("Supporting document");
                }
                BuildRequirementRows(names);

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
            foreach (RequirementRow row in requirementRows)
            {
                if (string.IsNullOrEmpty(row.FilePath) || !File.Exists(row.FilePath))
                {
                    MessageBox.Show($"Please attach your \"{row.Name}\" before submitting.", "Missing Requirement",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.AttachButton.Focus();
                    return;
                }
            }

            // Resolve Document Type & Purpose String Values
            string finalDocumentType = cmbDocumentType.SelectedItem.ToString() == "Others: (Please specify on the field below)"
                ? txtOtherDocType.Text.Trim()
                : cmbDocumentType.SelectedItem.ToString();

            // Determine final Purpose value to save into MySQL
            string finalPurpose = isOtherPurpose ? txtOtherPurpose.Text.Trim() : selectedPurposeStr;

            // Read every attachment (one per requirement)
            var attachments = new System.Collections.Generic.List<(string requirement, string fileName, byte[] data)>();
            foreach (RequirementRow row in requirementRows)
            {
                attachments.Add((row.Name, Path.GetFileName(row.FilePath), File.ReadAllBytes(row.FilePath)));
            }

            // The first file is also kept in the old single-attachment columns for backward compatibility
            byte[] fileBytes = attachments.Count > 0 ? attachments[0].data : null;
            string fileName = attachments.Count > 0 ? attachments[0].fileName : null;

            // Database Operations
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Db.EnsureSchema(conn);

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
                        long newRequestId = cmd.LastInsertedId;

                        // Save every uploaded requirement
                        foreach (var att in attachments)
                        {
                            using (MySqlCommand attCmd = new MySqlCommand(
                                @"INSERT INTO request_attachments (request_id, requirement_name, file_name, file_data)
                                  VALUES (@rid, @req, @fname, @fdata)", conn))
                            {
                                attCmd.Parameters.AddWithValue("@rid", newRequestId);
                                attCmd.Parameters.AddWithValue("@req", att.requirement);
                                attCmd.Parameters.AddWithValue("@fname", att.fileName);
                                attCmd.Parameters.AddWithValue("@fdata", att.data);
                                attCmd.ExecuteNonQuery();
                            }
                        }

                        // Create the document draft (filled with the resident's info) and store it in the database
                        try
                        {
                            DocumentTemplate.SaveDraft(conn, (int)newRequestId, currentUserId, finalDocumentType, finalPurpose);
                        }
                        catch (Exception draftEx)
                        {
                            Console.WriteLine("Draft creation failed: " + draftEx.Message);
                        }

                        MessageBox.Show($"Your request has been submitted!\nReference Number: {referenceNo}\n\nYou can track its status under My Requests.",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset Form Controls
                        cmbDocumentType.SelectedIndex = 0;
                        cmbPurpose.SelectedIndex = 0;
                        txtOtherDocType.Clear();
                        BuildRequirementRows(new System.Collections.Generic.List<string>());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Kept only because the designer file still references this handler; the attach buttons
        // are now created per requirement (see BuildRequirementRows).
        private void btnAttachFile_Click(object sender, EventArgs e) { }

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