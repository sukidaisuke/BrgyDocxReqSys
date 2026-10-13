#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// Read-only view of a request: resident, document, purpose and ALL uploaded requirement files.
    /// When showActions is true the admin can also choose "Prepare Document" or "Decline".
    /// </summary>
    public class RequestDetailsForm : Form
    {
        public enum ChosenAction { None, Prepare, Decline }
        public ChosenAction Action { get; private set; } = ChosenAction.None;

        private class AttachmentItem
        {
            public string Requirement;
            public string FileName;
            public byte[] Data;
            public override string ToString()
            {
                return string.IsNullOrWhiteSpace(Requirement) ? FileName : Requirement + "  —  " + FileName;
            }
        }

        private readonly int requestId;
        private readonly bool showActions;

        private Label lblResident, lblDoc, lblDate, lblStatus;
        private TextBox txtPurpose;
        private ListBox lstFiles;
        private PictureBox picPreview;
        private Label lblNoPreview;
        private Button btnOpen;

        public RequestDetailsForm(int requestId, bool showActions)
        {
            this.requestId = requestId;
            this.showActions = showActions;
            BuildUi();
            LoadData();
        }

        private void BuildUi()
        {
            Text = "Request Details";
            Size = new Size(760, 600);
            MinimumSize = new Size(640, 520);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9.5F);

            Label title = new Label
            {
                Text = "📄 Request Details",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(16, 12)
            };
            lblResident = new Label { AutoSize = true, Location = new Point(18, 50) };
            lblDoc = new Label { AutoSize = true, Location = new Point(18, 72) };
            lblDate = new Label { AutoSize = true, Location = new Point(18, 94) };
            lblStatus = new Label { AutoSize = true, Location = new Point(18, 116), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };

            Label lblPurposeTitle = new Label { Text = "Purpose:", AutoSize = true, Location = new Point(18, 144), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            txtPurpose = new TextBox
            {
                Location = new Point(18, 164),
                Size = new Size(710, 48),
                Multiline = true,
                ReadOnly = true,
                BackColor = Color.FromArgb(249, 250, 251),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            Label lblFilesTitle = new Label { Text = "Uploaded requirements:", AutoSize = true, Location = new Point(18, 222), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
            lstFiles = new ListBox
            {
                Location = new Point(18, 244),
                Size = new Size(260, 250),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left,
                HorizontalScrollbar = true
            };
            lstFiles.SelectedIndexChanged += (s, e) => ShowPreview();

            picPreview = new PictureBox
            {
                Location = new Point(290, 244),
                Size = new Size(438, 250),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(249, 250, 251),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            lblNoPreview = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DimGray,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            picPreview.Controls.Add(lblNoPreview);

            btnOpen = new Button
            {
                Text = "Open File",
                Location = new Point(18, 502),
                Size = new Size(110, 32),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Enabled = false
            };
            btnOpen.Click += (s, e) => OpenSelectedFile();

            Button btnClose = MakeButton("Close", Color.FromArgb(107, 114, 128));
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(Width - 140, 500);
            btnClose.Click += (s, e) => Close();

            Controls.AddRange(new Control[] { title, lblResident, lblDoc, lblDate, lblStatus, lblPurposeTitle, txtPurpose,
                                              lblFilesTitle, lstFiles, picPreview, btnOpen, btnClose });

            if (showActions)
            {
                Button btnPrepare = MakeButton("📝 Prepare Document", Color.FromArgb(22, 163, 74));
                btnPrepare.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                btnPrepare.Location = new Point(Width - 340, 500);
                btnPrepare.Click += (s, e) => { Action = ChosenAction.Prepare; Close(); };

                Button btnDecline = MakeButton("❌ Decline", Color.FromArgb(220, 38, 38));
                btnDecline.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                btnDecline.Location = new Point(Width - 470, 500);
                btnDecline.Click += (s, e) => { Action = ChosenAction.Decline; Close(); };

                Controls.AddRange(new Control[] { btnPrepare, btnDecline });
            }
        }

        private Button MakeButton(string text, Color color)
        {
            return new Button
            {
                Text = text,
                Size = new Size(text.Length > 10 ? 190 : 110, 34),
                FlatStyle = FlatStyle.Flat,
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    Db.EnsureSchema(conn);

                    string legacyName = null;
                    byte[] legacyData = null;

                    using (MySqlCommand cmd = new MySqlCommand(@"
                        SELECT r.document_type, r.purpose, r.status, r.request_at, r.attachment_name, r.attachment_data,
                               COALESCE(NULLIF(TRIM(CONCAT(u.first_name, ' ', u.last_name)), ''), r.username, 'Resident') AS resident_name
                        FROM documentrequests r
                        LEFT JOIN users u ON r.user_id = u.user_id
                        WHERE r.request_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", requestId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (!r.Read())
                            {
                                MessageBox.Show("Request not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            Text = "Request Details (#" + requestId + ")";
                            lblResident.Text = "Resident: " + r["resident_name"];
                            lblDoc.Text = "Document: " + r["document_type"];
                            lblDate.Text = r["request_at"] == DBNull.Value ? "" : "Requested: " + Convert.ToDateTime(r["request_at"]).ToString("MMM dd, yyyy • hh:mm tt");
                            lblStatus.Text = "Status: " + r["status"];
                            string purpose = r["purpose"].ToString();
                            txtPurpose.Text = string.IsNullOrWhiteSpace(purpose) ? "No purpose specified." : purpose;

                            legacyName = r["attachment_name"] == DBNull.Value ? null : r["attachment_name"].ToString();
                            legacyData = r["attachment_data"] == DBNull.Value ? null : (byte[])r["attachment_data"];
                        }
                    }

                    var items = new List<AttachmentItem>();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT requirement_name, file_name, file_data FROM request_attachments WHERE request_id = @id ORDER BY id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", requestId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                items.Add(new AttachmentItem
                                {
                                    Requirement = r["requirement_name"].ToString(),
                                    FileName = r["file_name"].ToString(),
                                    Data = r["file_data"] == DBNull.Value ? new byte[0] : (byte[])r["file_data"]
                                });
                            }
                        }
                    }

                    // Requests made before multi-file support only have the single legacy attachment
                    if (items.Count == 0 && legacyData != null && legacyData.Length > 0)
                    {
                        items.Add(new AttachmentItem { Requirement = "", FileName = legacyName ?? "attachment", Data = legacyData });
                    }

                    foreach (AttachmentItem it in items) lstFiles.Items.Add(it);

                    if (lstFiles.Items.Count > 0) lstFiles.SelectedIndex = 0;
                    else lblNoPreview.Text = "(No attachments provided)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching request details: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPreview()
        {
            if (picPreview.Image != null) { picPreview.Image.Dispose(); picPreview.Image = null; }

            AttachmentItem item = lstFiles.SelectedItem as AttachmentItem;
            btnOpen.Enabled = item != null && item.Data != null && item.Data.Length > 0;
            if (item == null || item.Data == null || item.Data.Length == 0)
            {
                lblNoPreview.Text = "(Empty file)";
                return;
            }

            try
            {
                using (MemoryStream ms = new MemoryStream(item.Data))
                using (Image img = Image.FromStream(ms))
                {
                    picPreview.Image = new Bitmap(img);   // copy, so the stream can be closed
                }
                lblNoPreview.Text = "";
            }
            catch
            {
                // PDF / Word files cannot be shown as a picture
                lblNoPreview.Text = item.FileName + "\n\nNo preview for this file type.\nClick \"Open File\" to view it.";
            }
        }

        private void OpenSelectedFile()
        {
            AttachmentItem item = lstFiles.SelectedItem as AttachmentItem;
            if (item == null) return;

            try
            {
                string dir = Path.Combine(Path.GetTempPath(), "BrgyDocxReqSys");
                Directory.CreateDirectory(dir);

                string safe = item.FileName;
                foreach (char c in Path.GetInvalidFileNameChars()) safe = safe.Replace(c, '_');
                string path = Path.Combine(dir, requestId + "_" + safe);

                File.WriteAllBytes(path, item.Data);
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
