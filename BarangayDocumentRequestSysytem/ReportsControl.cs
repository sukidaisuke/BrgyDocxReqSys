#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class ReportsControl : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";
        private readonly Color normalCardBg = Color.White;
        private readonly Color hoverCardBg = Color.FromArgb(245, 247, 250);

        public ReportsControl()
        {
            InitializeComponent();

            this.Load += ReportsControl_Load;
            this.VisibleChanged += ReportsControl_VisibleChanged;

            // Register hover & click events for all inner elements
            RegisterCardEvents(cardAnnouncements, CardAnnouncements_Click);
        }

        private void ReportsControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                UpdateHeaderDate();
            }
        }

        private void ReportsControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !this.DesignMode)
            {
                UpdateHeaderDate();
            }
        }

        private void UpdateHeaderDate()
        {
            if (lblDate != null)
            {
                lblDate.Text = $"📅 {DateTime.Now:MMMM d, yyyy | dddd}";
            }
        }

        private void RegisterCardEvents(Control parent, EventHandler clickHandler)
        {
            parent.Click += clickHandler;
            parent.MouseEnter += Card_MouseEnter;
            parent.MouseLeave += Card_MouseLeave;

            foreach (Control child in parent.Controls)
            {
                child.Click += clickHandler;
                child.MouseEnter += Card_MouseEnter;
                child.MouseLeave += Card_MouseLeave;
            }
        }

        private void Card_MouseEnter(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Panel card = (control is Panel p && p.Name.StartsWith("card")) ? p : control.Parent as Panel;

            if (card != null)
            {
                card.BackColor = hoverCardBg;
            }
        }

        private void Card_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Panel card = (control is Panel p && p.Name.StartsWith("card")) ? p : control.Parent as Panel;

            if (card != null)
            {
                card.BackColor = normalCardBg;
            }
        }

        private void CardAnnouncements_Click(object sender, EventArgs e)
        {
            using (AnnouncementsForm announcementsForm = new AnnouncementsForm())
            {
                announcementsForm.ShowDialog(this.FindForm());
            }
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV File (*.csv)|*.csv|Text File (*.txt)|*.txt";
                saveFileDialog.Title = "Export Barangay System Summary Report";
                saveFileDialog.FileName = $"Barangay_Report_{DateTime.Now:yyyy_MM_dd}.csv";

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // Live summary per document type, taken from the database
                    const string approvedSet = "('approved','completed','processed','ready for pickup')";
                    const string rejectedSet = "('rejected','declined','disapproved','cancelled','failed')";

                    string query = $@"
                        SELECT r.document_type,
                               COUNT(*) AS total,
                               SUM(CASE WHEN LOWER(r.status) IN {approvedSet} THEN 1 ELSE 0 END) AS approved,
                               SUM(CASE WHEN LOWER(r.status) IN ('pending','in process') THEN 1 ELSE 0 END) AS pending,
                               SUM(CASE WHEN LOWER(r.status) IN {rejectedSet} THEN 1 ELSE 0 END) AS rejected,
                               COALESCE(SUM(CASE WHEN LOWER(r.status) IN {approvedSet}
                                                 THEN COALESCE(t.price, 0) ELSE 0 END), 0) AS fees
                        FROM documentrequests r
                        LEFT JOIN document_types t ON t.document_name = r.document_type
                        GROUP BY r.document_type
                        ORDER BY r.document_type ASC";

                    StringBuilder csv = new StringBuilder();
                    csv.AppendLine("BARANGAY DOCUMENT REQUEST SYSTEM - SUMMARY REPORT");
                    csv.AppendLine($"Generated On,{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    csv.AppendLine();
                    csv.AppendLine("Document Type,Total Requests,Approved,Pending,Rejected,Total Fees (PHP)");

                    int tTotal = 0, tApproved = 0, tPending = 0, tRejected = 0;
                    decimal tFees = 0m;

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string docType = reader["document_type"]?.ToString() ?? "Unspecified";
                                int total = Convert.ToInt32(reader["total"]);
                                int approved = Convert.ToInt32(reader["approved"]);
                                int pending = Convert.ToInt32(reader["pending"]);
                                int rejected = Convert.ToInt32(reader["rejected"]);
                                decimal fees = Convert.ToDecimal(reader["fees"]);

                                string safeName = "\"" + docType.Replace("\"", "\"\"") + "\"";
                                csv.AppendLine($"{safeName},{total},{approved},{pending},{rejected},{fees:0.00}");

                                tTotal += total; tApproved += approved; tPending += pending;
                                tRejected += rejected; tFees += fees;
                            }
                        }
                    }

                    csv.AppendLine();
                    csv.AppendLine($"TOTALS,{tTotal},{tApproved},{tPending},{tRejected},{tFees:0.00}");

                    File.WriteAllText(saveFileDialog.FileName, csv.ToString(), new UTF8Encoding(true));

                    MessageBox.Show("Summary report exported successfully!", "Export Completed",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to export report: {ex.Message}", "Export Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
