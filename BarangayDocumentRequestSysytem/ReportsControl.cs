#nullable disable
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class ReportsControl : UserControl
    {
        private readonly Color normalCardBg = Color.White;
        private readonly Color hoverCardBg = Color.FromArgb(245, 247, 250);

        public ReportsControl()
        {
            InitializeComponent();

            this.Load += ReportsControl_Load;
            this.VisibleChanged += ReportsControl_VisibleChanged;

            // Register hover & click events for all inner elements
            RegisterCardEvents(cardAnnouncements, CardAnnouncements_Click);
            RegisterCardEvents(cardDocuments, CardDocuments_Click);
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

        private void CardDocuments_Click(object sender, EventArgs e)
        {
            using (ReadyToPrintForm docsForm = new ReadyToPrintForm())
            {
                docsForm.ShowDialog(this.FindForm());
            }
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV File (*.csv)|*.csv|Text File (*.txt)|*.txt";
                saveFileDialog.Title = "Export Barangay System Monthly Summary Report";
                saveFileDialog.FileName = $"Barangay_Report_{DateTime.Now:yyyy_MM_dd}.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder csv = new StringBuilder();
                        csv.AppendLine("BARANGAY DOCUMENT REQUEST SYSTEM - SUMMARY REPORT");
                        csv.AppendLine($"Generated On,{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                        csv.AppendLine();
                        csv.AppendLine("Document Type,Total Requests,Approved,Pending,Rejected,Total Fees (PHP)");
                        csv.AppendLine("Barangay Clearance,142,128,10,4,7100.00");
                        csv.AppendLine("Certificate of Indigency,85,80,5,0,0.00");
                        csv.AppendLine("Certificate of Residency,64,60,3,1,3200.00");
                        csv.AppendLine("Barangay Business Clearance,29,25,2,2,14500.00");
                        csv.AppendLine();
                        csv.AppendLine("TOTALS,320,293,20,7,24800.00");

                        File.WriteAllText(saveFileDialog.FileName, csv.ToString(), Encoding.UTF8);

                        MessageBox.Show("Summary report exported successfully!", "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to export report: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}