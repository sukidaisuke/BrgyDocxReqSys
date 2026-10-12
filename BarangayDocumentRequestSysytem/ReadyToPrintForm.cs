#nullable disable
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BarangayDocumentRequestSysytem
{
    public partial class ReadyToPrintForm : Form
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public ReadyToPrintForm()
        {
            InitializeComponent();
        }

        private void ReadyToPrintForm_Load(object sender, EventArgs e)
        {
            LoadCivilStatuses();
            LoadDocumentTypesFromDatabase();
            GenerateDocumentText();
        }

        private void LoadCivilStatuses()
        {
            cmbCivilStatus.Items.Clear();
            cmbCivilStatus.Items.AddRange(new object[] {
                "Single",
                "Married",
                "Widowed",
                "Separated",
                "Divorced"
            });
            cmbCivilStatus.SelectedIndex = 0;
        }

        private void LoadDocumentTypesFromDatabase()
        {
            cmbDocType.Items.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, document_name FROM document_types ORDER BY document_name ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbDocType.Items.Add(new DocumentTypeItem
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Name = reader["document_name"].ToString()
                                });
                            }
                        }
                    }
                }

                if (cmbDocType.Items.Count > 0)
                {
                    cmbDocType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading document types: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPurpose.Items.Clear();

            if (cmbDocType.SelectedItem is DocumentTypeItem selectedDoc)
            {
                LoadPurposesForDocumentType(selectedDoc.Id);
            }

            GenerateDocumentText();
        }

        private void LoadPurposesForDocumentType(int docTypeId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
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
                }

                if (cmbPurpose.Items.Count > 0)
                {
                    cmbPurpose.SelectedIndex = 0;
                }
                else
                {
                    cmbPurpose.Items.Add("General Purpose");
                    cmbPurpose.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading document purposes: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateDocumentText();
        }

        private void cmbCivilStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateDocumentText();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateDocumentText();
        }

        private void GenerateDocumentText()
        {
            string docType = cmbDocType.SelectedItem != null ? cmbDocType.SelectedItem.ToString() : "BARANGAY CLEARANCE";
            string residentName = string.IsNullOrWhiteSpace(txtResidentName.Text) ? "[RESIDENT NAME]" : txtResidentName.Text.Trim();
            string age = string.IsNullOrWhiteSpace(txtAge.Text) ? "[AGE]" : txtAge.Text.Trim();
            string status = cmbCivilStatus.SelectedItem != null ? cmbCivilStatus.SelectedItem.ToString() : "Single";
            string purpose = cmbPurpose.SelectedItem != null ? cmbPurpose.SelectedItem.ToString() : "Employment Application";

            int day = DateTime.Now.Day;
            string dateStr = $"{day}{GetOrdinalSuffix(day)} day of {DateTime.Now:MMMM, yyyy}";

            rtbPreview.Clear();
            rtbPreview.SelectionAlignment = HorizontalAlignment.Center;
            rtbPreview.SelectionFont = new Font("Times New Roman", 15, FontStyle.Bold);
            rtbPreview.AppendText("REPUBLIC OF THE PHILIPPINES\nOFFICE OF THE BARANGAY CAPTAIN\nBARANGAY DOCUMENT REQUEST SYSTEM\n\n");

            rtbPreview.SelectionFont = new Font("Times New Roman", 17, FontStyle.Bold | FontStyle.Underline);
            rtbPreview.AppendText($"{docType.ToUpper()}\n\n\n");

            rtbPreview.SelectionAlignment = HorizontalAlignment.Left;
            rtbPreview.SelectionFont = new Font("Times New Roman", 11.5f, FontStyle.Regular);

            rtbPreview.AppendText("TO WHOM IT MAY CONCERN:\n\n");
            rtbPreview.AppendText("   This is to certify that ");

            rtbPreview.SelectionFont = new Font("Times New Roman", 11.5f, FontStyle.Bold);
            rtbPreview.AppendText($"{residentName.ToUpper()}");

            rtbPreview.SelectionFont = new Font("Times New Roman", 11.5f, FontStyle.Regular);
            rtbPreview.AppendText($", {age} years old, {status}, and a bonafide resident of this Barangay, is known to be a person of good moral character and law-abiding citizen with no derogatory criminal records on file.\n\n");

            rtbPreview.AppendText("   This certification is issued upon request of the above-named person for the purpose of: ");
            rtbPreview.SelectionFont = new Font("Times New Roman", 11.5f, FontStyle.Bold);
            rtbPreview.AppendText($"{purpose}.\n\n");

            rtbPreview.SelectionFont = new Font("Times New Roman", 11.5f, FontStyle.Regular);
            rtbPreview.AppendText($"   Issued this {dateStr} at the Barangay Hall.\n\n\n\n");

            rtbPreview.SelectionAlignment = HorizontalAlignment.Right;
            rtbPreview.SelectionFont = new Font("Times New Roman", 11.5f, FontStyle.Bold);
            rtbPreview.AppendText("_________________________\nHon. Barangay Captain    ");
        }

        private string GetOrdinalSuffix(int day)
        {
            if (day >= 11 && day <= 13) return "th";
            switch (day % 10)
            {
                case 1: return "st";
                case 2: return "nd";
                case 3: return "rd";
                default: return "th";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawString(rtbPreview.Text, new Font("Times New Roman", 12), Brushes.Black, new RectangleF(50, 50, ev.MarginBounds.Width, ev.MarginBounds.Height));
            };

            using (PrintPreviewDialog previewDlg = new PrintPreviewDialog())
            {
                previewDlg.Document = printDoc;
                previewDlg.Width = 800;
                previewDlg.Height = 600;
                previewDlg.ShowDialog(this);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class DocumentTypeItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class PurposeItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}