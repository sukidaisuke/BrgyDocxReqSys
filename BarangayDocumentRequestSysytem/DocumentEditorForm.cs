#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// Admin screen: review a resident's document, edit it, choose the signing
    /// official, save it to the database, print it, and update the request status.
    /// Built entirely in code (no designer file needed).
    /// </summary>
    public class DocumentEditorForm : Form
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        private readonly int requestId;
        private int userId;
        private string referenceNo = "";
        private string docType = "";
        private string purpose = "";
        private string residentName = "";
        private string status = "Pending";
        private string savedSignName = "";
        private string savedSignPos = "";

        private bool loadFailed = false;
        private Label lblInfo;
        private Label lblStatus;
        private ComboBox cmbSignatory;
        private RichTextBox rtbBody;
        private WordEditor editor;
        private bool legacyPlain = false;   // old requests whose document was saved as plain text
        private Button btnSave, btnView, btnPdf, btnReady, btnClose;

        private class SignatoryItem
        {
            public string Name;
            public string Position;
            public override string ToString() => Name + "  —  " + Position;
        }

        public DocumentEditorForm(int requestId)
        {
            this.requestId = requestId;
            BuildUi();
            LoadRequest();
        }

        // ---------------------------------------------------------------
        // UI (code only)
        // ---------------------------------------------------------------
        private void BuildUi()
        {
            Text = "Prepare Document";
            Size = new Size(900, 740);
            MinimumSize = new Size(760, 600);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);

            TableLayoutPanel root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(16)
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            Controls.Add(root);

            // --- top: info + signatory
            Panel top = new Panel { Dock = DockStyle.Fill };
            Label title = new Label
            {
                Text = "📄 Prepare Document",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(0, 0)
            };
            lblInfo = new Label
            {
                AutoSize = false,
                Location = new Point(0, 36),
                Size = new Size(620, 60),
                ForeColor = Color.FromArgb(55, 65, 81)
            };
            lblStatus = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(160, 30),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            top.Resize += (s, e) => lblStatus.Location = new Point(top.Width - lblStatus.Width, 4);

            Label lblSign = new Label
            {
                Text = "Signing official:",
                AutoSize = true,
                Location = new Point(0, 108),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            cmbSignatory = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(130, 104),
                Width = 420
            };
            top.Controls.AddRange(new Control[] { title, lblInfo, lblStatus, lblSign, cmbSignatory });
            root.Controls.Add(top, 0, 0);

            // --- middle: editable document body
            editor = new WordEditor();
            rtbBody = editor.Rich;
            root.Controls.Add(editor, 0, 1);

            // --- bottom: buttons
            FlowLayoutPanel buttons = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false
            };
            btnClose = MakeButton("Close", Color.FromArgb(107, 114, 128));
            btnReady = MakeButton("Ready for Pickup", Color.FromArgb(22, 163, 74));
            btnPdf = MakeButton("⬇ PDF", Color.FromArgb(124, 58, 237));
            btnView = MakeButton("👁 View", Color.FromArgb(8, 145, 178));
            btnSave = MakeButton("💾 Save", Color.FromArgb(217, 119, 6));
            buttons.Controls.AddRange(new Control[] { btnClose, btnReady, btnPdf, btnView, btnSave });
            root.Controls.Add(buttons, 0, 2);

            btnSave.Click += BtnSave_Click;
            btnView.Click += BtnView_Click;
            btnPdf.Click += BtnPdf_Click;
            btnReady.Click += BtnReady_Click;
            btnClose.Click += (s, e) => Close();
        }

        private Button MakeButton(string text, Color color)
        {
            return new Button
            {
                Text = text,
                AutoSize = true,
                MinimumSize = new Size(90, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Margin = new Padding(8, 8, 0, 0),
                Cursor = Cursors.Hand
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (loadFailed) Close();
        }

        // ---------------------------------------------------------------
        // Load
        // ---------------------------------------------------------------
        private void LoadRequest()
        {
            string content = null;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(@"
                        SELECT r.user_id, r.reference_no, r.document_type, r.purpose, r.status,
                               COALESCE(NULLIF(TRIM(CONCAT(u.first_name, ' ', u.last_name)), ''), r.username, 'Resident') AS resident_name,
                               d.content, d.signatory_name, d.signatory_position
                        FROM documentrequests r
                        LEFT JOIN users u ON r.user_id = u.user_id
                        LEFT JOIN issued_documents d ON d.request_id = r.request_id
                        WHERE r.request_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", requestId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (!r.Read())
                            {
                                MessageBox.Show("Request not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                loadFailed = true;
                                return;
                            }

                            userId = Convert.ToInt32(r["user_id"]);
                            referenceNo = r["reference_no"].ToString();
                            docType = r["document_type"].ToString();
                            purpose = r["purpose"].ToString();
                            status = string.IsNullOrWhiteSpace(r["status"].ToString()) ? "Pending" : r["status"].ToString();
                            residentName = r["resident_name"].ToString();
                            content = r["content"] == DBNull.Value ? null : r["content"].ToString();
                            savedSignName = r["signatory_name"].ToString();
                            savedSignPos = r["signatory_position"].ToString();
                        }
                    }

                    // Older requests (made before this feature) have no document yet: build one now.
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        content = DocumentTemplate.BuildDraft(conn, userId, docType, purpose);
                    }

                    cmbSignatory.Items.Clear();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT official_name, position FROM signatories " +
                        "WHERE position IN ('Barangay Captain', 'Barangay Secretary', 'Barangay Treasurer') ORDER BY signatory_id", conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            SignatoryItem item = new SignatoryItem
                            {
                                Name = r["official_name"].ToString(),
                                Position = r["position"].ToString()
                            };
                            int idx = cmbSignatory.Items.Add(item);
                            if (item.Name == savedSignName && item.Position == savedSignPos)
                                cmbSignatory.SelectedIndex = idx;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading document: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                loadFailed = true;
                return;
            }

            if (DocumentTemplate.IsRtf(content))
            {
                legacyPlain = false;
                rtbBody.Rtf = content;
            }
            else
            {
                // documents created before formatting/pictures were supported stay plain text
                legacyPlain = true;
                rtbBody.Font = new Font("Times New Roman", 13F);
                rtbBody.Text = content;
                editor.ToolbarVisible = false;
            }
            Text = "Prepare Document — " + referenceNo;
            lblInfo.Text = "Resident: " + residentName + "\n" +
                           "Document: " + docType + "\n" +
                           "Purpose: " + purpose;

            if (cmbSignatory.Items.Count == 0)
            {
                MessageBox.Show(
                    "There is no signatory yet.\n\nGo to Settings > Signatories and add the Barangay Captain, " +
                    "Secretary or Treasurer first.", "No Signatory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ApplyStatusUi();
        }

        private bool IsFinal()
        {
            string s = status.ToLower();
            return s == "completed" || s == "rejected";
        }

        private void ApplyStatusUi()
        {
            lblStatus.Text = status;

            switch (status.ToLower())
            {
                case "ready for pickup":
                    lblStatus.BackColor = Color.FromArgb(220, 252, 231);
                    lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
                    break;
                case "in process":
                    lblStatus.BackColor = Color.FromArgb(219, 234, 254);
                    lblStatus.ForeColor = Color.FromArgb(30, 64, 175);
                    break;
                case "completed":
                case "approved":
                    lblStatus.BackColor = Color.FromArgb(220, 252, 231);
                    lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
                    break;
                case "rejected":
                    lblStatus.BackColor = Color.FromArgb(254, 226, 226);
                    lblStatus.ForeColor = Color.FromArgb(153, 27, 27);
                    break;
                default:
                    lblStatus.BackColor = Color.FromArgb(254, 249, 195);
                    lblStatus.ForeColor = Color.FromArgb(133, 77, 14);
                    break;
            }

            bool final = IsFinal();
            rtbBody.ReadOnly = final;
            if (!legacyPlain) editor.EditingEnabled = !final;
            cmbSignatory.Enabled = !final;
            btnSave.Enabled = !final;
            btnReady.Enabled = !final && status.ToLower() != "ready for pickup";
        }

        // ---------------------------------------------------------------
        // Save / status
        // ---------------------------------------------------------------
        private SignatoryItem SelectedSignatory()
        {
            return cmbSignatory.SelectedItem as SignatoryItem;
        }

        /// <summary>Saves the document text + signatory and optionally changes the status.</summary>
        private bool SaveDocument(string newStatus)
        {
            SignatoryItem sig = SelectedSignatory();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlTransaction tx = conn.BeginTransaction())
                    {
                        using (MySqlCommand cmd = new MySqlCommand(@"
                            INSERT INTO issued_documents
                                (request_id, document_type, content, signatory_name, signatory_position, prepared_by, prepared_at)
                            VALUES (@rid, @type, @content, @sname, @spos, @by, NOW())
                            ON DUPLICATE KEY UPDATE
                                content = VALUES(content),
                                signatory_name = VALUES(signatory_name),
                                signatory_position = VALUES(signatory_position),
                                prepared_by = VALUES(prepared_by),
                                prepared_at = NOW()", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rid", requestId);
                            cmd.Parameters.AddWithValue("@type", docType);
                            cmd.Parameters.AddWithValue("@content", legacyPlain ? rtbBody.Text : rtbBody.Rtf);
                            cmd.Parameters.AddWithValue("@sname", sig == null ? (object)DBNull.Value : sig.Name);
                            cmd.Parameters.AddWithValue("@spos", sig == null ? (object)DBNull.Value : sig.Position);
                            cmd.Parameters.AddWithValue("@by", string.IsNullOrEmpty(UserSession.Username) ? (object)DBNull.Value : UserSession.Username);
                            cmd.ExecuteNonQuery();
                        }

                        if (newStatus != null)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(
                                "UPDATE documentrequests SET status = @s WHERE request_id = @id", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@s", newStatus);
                                cmd.Parameters.AddWithValue("@id", requestId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                    }
                }

                if (newStatus != null) status = newStatus;
                if (sig != null) { savedSignName = sig.Name; savedSignPos = sig.Position; }
                ApplyStatusUi();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save document: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // a Pending request becomes "In Process" as soon as the admin works on it
        private string StatusAfterWork()
        {
            return status.ToLower() == "pending" ? "In Process" : null;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveDocument(StatusAfterWork()))
            {
                MessageBox.Show("Document saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnReady_Click(object sender, EventArgs e)
        {
            if (SelectedSignatory() == null)
            {
                MessageBox.Show("Please choose the signing official first.", "Signatory Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Mark this document as READY FOR PICKUP?\n\nThe resident will be notified the next time they open the system.",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            if (SaveDocument("Ready for Pickup"))
            {
                MessageBox.Show("Document is now Ready for Pickup.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        // ---------------------------------------------------------------
        // Print
        // ---------------------------------------------------------------
        // Validates, saves the document, and returns a PrintDocument ready to view / print / export.
        private PrintDocument PreparePrintDocument()
        {
            SignatoryItem sig = SelectedSignatory();
            if (sig == null && !IsFinal())
            {
                MessageBox.Show("Please choose the signing official first.", "Signatory Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (!IsFinal() && !SaveDocument(StatusAfterWork())) return null;

            string signNameNow = sig != null ? sig.Name : savedSignName;
            string signPosNow = sig != null ? sig.Position : savedSignPos;

            // New-style documents: print exactly what the admin sees (formatting + pictures)
            if (!legacyPlain)
            {
                RichTextBoxPrinter printer = new RichTextBoxPrinter();
                printer.Rtf = rtbBody.Rtf;
                DocumentTemplate.ReplaceTokens(printer, new System.Collections.Generic.Dictionary<string, string>
                {
                    { "{SIGNATORY_NAME}", (signNameNow ?? "").ToUpper() },
                    { "{SIGNATORY_POSITION}", signPosNow ?? "" },
                    { "{REF_NO}", referenceNo },
                    { "{DOCUMENT_TITLE}", docType.ToUpper() }
                });
                return printer.CreatePrintDocument("Document " + referenceNo);
            }

            BarangayDetails b;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    b = DocumentTemplate.GetBarangay(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            string body = rtbBody.Text;
            string signName = sig != null ? sig.Name : savedSignName;
            string signPos = sig != null ? sig.Position : savedSignPos;

            PrintDocument pd = new PrintDocument();
            pd.DocumentName = "Document " + referenceNo;
            pd.PrintPage += (s, ev) => DrawPage(ev, b, body, signName, signPos);
            return pd;
        }

        private void MarkPrinted()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "UPDATE issued_documents SET printed_at = NOW() WHERE request_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", requestId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { /* not critical */ }
        }

        // 👁 View: on-screen preview only
        private void BtnView_Click(object sender, EventArgs e)
        {
            PrintDocument pd = PreparePrintDocument();
            if (pd == null) return;

            using (PrintPreviewDialog dlg = new PrintPreviewDialog())
            {
                dlg.Document = pd;
                dlg.Width = 900;
                dlg.Height = 760;
                dlg.ShowDialog(this);
            }
        }

        // ⬇ PDF: save the document as a PDF file
        private void BtnPdf_Click(object sender, EventArgs e)
        {
            PrintDocument pd = PreparePrintDocument();
            if (pd == null) return;

            string safeName = referenceNo + "_" + docType;
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                safeName = safeName.Replace(c, '_');

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF File (*.pdf)|*.pdf";
                dlg.FileName = safeName.Replace(' ', '_') + ".pdf";
                dlg.Title = "Save Document as PDF";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    if (!pd.PrinterSettings.IsValid)
                    {
                        MessageBox.Show(
                            "The \"Microsoft Print to PDF\" printer was not found on this computer.\n\n" +
                            "Please install or enable a PDF printer and try again.",
                            "PDF Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    pd.PrinterSettings.PrintToFile = true;
                    pd.PrinterSettings.PrintFileName = dlg.FileName;
                    pd.Print();

                    MarkPrinted();
                    MessageBox.Show("Saved as PDF:\n" + dlg.FileName, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not create the PDF: " + ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DrawPage(PrintPageEventArgs ev, BarangayDetails b, string body, string signName, string signPos)
        {
            Graphics g = ev.Graphics;
            Rectangle m = ev.MarginBounds;
            float y = m.Top;

            StringFormat center = new StringFormat { Alignment = StringAlignment.Center };

            using (Font fNormal = new Font("Times New Roman", 12F))
            using (Font fBold = new Font("Times New Roman", 13F, FontStyle.Bold))
            using (Font fTitle = new Font("Times New Roman", 18F, FontStyle.Bold | FontStyle.Underline))
            using (Font fSmall = new Font("Times New Roman", 9F, FontStyle.Italic))
            {
                void CenterLine(string text, Font f)
                {
                    SizeF sz = g.MeasureString(text, f, m.Width);
                    g.DrawString(text, f, Brushes.Black, new RectangleF(m.Left, y, m.Width, sz.Height), center);
                    y += sz.Height + 2;
                }

                // Letterhead
                CenterLine("Republic of the Philippines", fNormal);
                CenterLine("Province of " + b.Province, fNormal);
                CenterLine(b.Municipality, fNormal);
                CenterLine("BARANGAY " + b.Name.ToUpper(), fBold);
                CenterLine("OFFICE OF THE PUNONG BARANGAY", fBold);

                y += 6;
                g.DrawLine(Pens.Black, m.Left, y, m.Right, y);
                y += 24;

                // Title
                CenterLine(docType.ToUpper(), fTitle);
                y += 30;

                // Body
                float bodyHeight = m.Bottom - y - 170;
                g.DrawString(body, fNormal, Brushes.Black, new RectangleF(m.Left, y, m.Width, bodyHeight));

                // Signature block (bottom right)
                float sigWidth = 260;
                float sigX = m.Right - sigWidth;
                float sigY = m.Bottom - 120;
                StringFormat sigCenter = new StringFormat { Alignment = StringAlignment.Center };

                g.DrawLine(Pens.Black, sigX, sigY, sigX + sigWidth, sigY);
                g.DrawString((signName ?? "").ToUpper(), fBold, Brushes.Black,
                    new RectangleF(sigX, sigY + 4, sigWidth, 24), sigCenter);
                g.DrawString(signPos ?? "", fNormal, Brushes.Black,
                    new RectangleF(sigX, sigY + 28, sigWidth, 24), sigCenter);

                // Footer
                g.DrawString("Ref. No.: " + referenceNo, fSmall, Brushes.Black, m.Left, m.Bottom - 20);
                g.DrawString("Not valid without official dry seal.", fSmall, Brushes.Black, m.Left, m.Bottom - 36);
            }

            ev.HasMorePages = false;
        }
    }
}
