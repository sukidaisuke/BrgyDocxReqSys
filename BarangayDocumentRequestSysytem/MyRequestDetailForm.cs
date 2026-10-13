#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// A resident's view of one of their own requests. While the request is still "Pending" they can change the
    /// purpose, replace an uploaded file, or cancel it. Finished / cancelled requests can be requested again,
    /// and cancelled ones can be removed from the list.
    /// </summary>
    internal class MyRequestDetailForm : Form
    {
        private readonly int requestId;
        private readonly int userId = UserSession.UserId;

        private string reference, docType, purpose, status;
        private DateTime? requestedAt;
        private int firstAttachmentId = -1;

        private Label lblRef, lblDoc, lblDate, lblStatus, lblNote;
        private ComboBox cmbPurpose;
        private Button btnSavePurpose, btnCancelRequest, btnDeleteRequest, btnAgain, btnClose;
        private Panel pnlAttachments;

        public MyRequestDetailForm(int requestId)
        {
            this.requestId = requestId;
            Build();
            Load += (s, e) => LoadRequest();
        }

        private bool IsPending => string.Equals(status, "Pending", StringComparison.OrdinalIgnoreCase);
        private bool IsCancelled => string.Equals(status, "Cancelled", StringComparison.OrdinalIgnoreCase);

        private bool CanRequestAgain =>
            IsCancelled ||
            string.Equals(status, "Rejected", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(status, "Approved", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(status, "Completed", StringComparison.OrdinalIgnoreCase);

        // ------------------------------------------------------------------ layout

        private void Build()
        {
            Text = "My Request";
            ClientSize = new Size(560, 470);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false; ShowInTaskbar = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            Panel header = new Panel { Dock = DockStyle.Top, Height = 46, BackColor = UiKit.Brand };
            lblRef = new Label { ForeColor = Color.White, Font = new Font("Segoe UI", 11F, FontStyle.Bold), Location = new Point(14, 12), AutoSize = true, Text = "📄 Request" };
            header.Controls.Add(lblRef);
            Controls.Add(header);

            int y = 60, x1 = 16, x2 = 130;

            Controls.Add(UiKit.Lbl("Document", x1, y, 110, true));
            lblDoc = new Label { Location = new Point(x2, y + 3), Size = new Size(410, 20) };
            Controls.Add(lblDoc);
            y += 28;

            Controls.Add(UiKit.Lbl("Requested on", x1, y, 110, true));
            lblDate = new Label { Location = new Point(x2, y + 3), Size = new Size(200, 20) };
            Controls.Add(lblDate);
            y += 28;

            Controls.Add(UiKit.Lbl("Status", x1, y, 110, true));
            lblStatus = new Label { Location = new Point(x2, y + 3), Size = new Size(200, 20), Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            Controls.Add(lblStatus);
            y += 32;

            Controls.Add(UiKit.Lbl("Purpose", x1, y, 110, true));
            cmbPurpose = UiKit.Combo(null, x2, y, 300, false);
            cmbPurpose.MaxLength = 150;
            Controls.Add(cmbPurpose);
            btnSavePurpose = UiKit.Btn("💾 Save", 440, y - 1, 104, 26, UiKit.Brand, Color.White);
            btnSavePurpose.Click += (s, e) => SavePurpose();
            Controls.Add(btnSavePurpose);
            y += 40;

            Controls.Add(UiKit.Lbl("Uploaded requirements", x1, y, 200, true));
            y += 26;
            pnlAttachments = new Panel { Location = new Point(x1, y), Size = new Size(528, 120), AutoScroll = true, BorderStyle = BorderStyle.FixedSingle, BackColor = Color.White };
            Controls.Add(pnlAttachments);
            y += 130;

            lblNote = new Label { Location = new Point(x1, y), Size = new Size(528, 36), ForeColor = Color.FromArgb(71, 85, 105) };
            Controls.Add(lblNote);
            y += 44;

            btnCancelRequest = UiKit.Btn("🚫 Cancel Request", x1, y, 140, 32, UiKit.Danger, Color.White);
            btnCancelRequest.Click += (s, e) => CancelRequest();
            btnDeleteRequest = UiKit.Btn("🗑 Delete", x1, y, 110, 32, UiKit.Danger, Color.White);
            btnDeleteRequest.Click += (s, e) => DeleteCancelled();
            btnAgain = UiKit.Btn("🔁 Request Again", 160, y, 140, 32, Color.SteelBlue, Color.White);
            btnAgain.Click += (s, e) => RequestAgain();
            btnClose = UiKit.Btn("Close", 444, y, 100, 32, UiKit.Muted, Color.FromArgb(71, 85, 105));
            btnClose.Click += (s, e) => Close();
            Controls.AddRange(new Control[] { btnCancelRequest, btnDeleteRequest, btnAgain, btnClose });
            CancelButton = btnClose;

            ClientSize = new Size(560, y + 50);
        }

        // ------------------------------------------------------------------ loading

        private void LoadRequest()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT reference_no, document_type, purpose, request_at, status
                          FROM documentrequests WHERE request_id = @id AND user_id = @u", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", requestId);
                        cmd.Parameters.AddWithValue("@u", userId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (!r.Read())
                            {
                                UiKit.Warn(this, "This request no longer exists.", "Not found");
                                DialogResult = DialogResult.OK;
                                return;
                            }
                            reference = r["reference_no"]?.ToString();
                            docType = r["document_type"]?.ToString();
                            purpose = r["purpose"]?.ToString();
                            requestedAt = r["request_at"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["request_at"]);
                            status = r["status"] == DBNull.Value ? "Pending" : r["status"].ToString().Trim();
                        }
                    }

                    LoadPurposeChoices(conn);
                    LoadAttachments(conn);
                }

                ApplyState();
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not load the request: " + ex.Message);
            }
        }

        private void LoadPurposeChoices(MySqlConnection conn)
        {
            cmbPurpose.Items.Clear();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(
                    @"SELECT p.purpose_name FROM document_purposes p
                      JOIN document_types t ON t.id = p.doc_type_id
                      WHERE t.document_name = @n ORDER BY p.purpose_name", conn))
                {
                    cmd.Parameters.AddWithValue("@n", docType ?? "");
                    using (MySqlDataReader r = cmd.ExecuteReader())
                        while (r.Read()) cmbPurpose.Items.Add(r["purpose_name"].ToString());
                }
            }
            catch { /* the list is only a convenience; the box still accepts typed text */ }

            cmbPurpose.Text = purpose ?? "";
        }

        private void LoadAttachments(MySqlConnection conn)
        {
            pnlAttachments.Controls.Clear();
            firstAttachmentId = -1;

            var rows = new List<(int id, string requirement, string file)>();
            using (MySqlCommand cmd = new MySqlCommand(
                "SELECT id, requirement_name, file_name FROM request_attachments WHERE request_id = @id ORDER BY id", conn))
            {
                cmd.Parameters.AddWithValue("@id", requestId);
                using (MySqlDataReader r = cmd.ExecuteReader())
                    while (r.Read())
                        rows.Add((Convert.ToInt32(r["id"]), r["requirement_name"]?.ToString(), r["file_name"]?.ToString()));
            }

            if (rows.Count == 0)
            {
                pnlAttachments.Controls.Add(new Label { Text = "No files were uploaded with this request.", Location = new Point(8, 8), AutoSize = true, ForeColor = Color.DimGray });
                return;
            }

            firstAttachmentId = rows[0].id;
            int y = 4;
            foreach (var row in rows)
            {
                int attachmentId = row.id;
                string requirement = string.IsNullOrWhiteSpace(row.requirement) ? "Attachment" : row.requirement;

                pnlAttachments.Controls.Add(new Label
                {
                    Text = requirement + ":",
                    Location = new Point(6, y + 5),
                    Size = new Size(150, 20),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    AutoEllipsis = true
                });
                pnlAttachments.Controls.Add(new Label
                {
                    Text = row.file ?? "",
                    Location = new Point(160, y + 5),
                    Size = new Size(250, 20),
                    AutoEllipsis = true,
                    ForeColor = Color.FromArgb(22, 101, 52)
                });

                Button replace = UiKit.Btn("↻ Replace", 414, y + 1, 90, 26, Color.Azure, UiKit.Brand);
                replace.Name = "replace_" + attachmentId;
                replace.Tag = "replace";
                replace.Click += (s, e) => ReplaceAttachment(attachmentId, requirement);
                pnlAttachments.Controls.Add(replace);
                y += 32;
            }
        }

        private void ApplyState()
        {
            lblRef.Text = "📄 " + (string.IsNullOrWhiteSpace(reference) ? $"Request #{requestId}" : reference);
            lblDoc.Text = docType;
            lblDate.Text = requestedAt.HasValue ? requestedAt.Value.ToString("MMMM dd, yyyy") : "N/A";
            lblStatus.Text = status;

            switch (status.ToLowerInvariant())
            {
                case "pending": lblStatus.ForeColor = Color.FromArgb(180, 120, 20); break;
                case "in process": lblStatus.ForeColor = Color.FromArgb(30, 64, 175); break;
                case "rejected": lblStatus.ForeColor = Color.FromArgb(185, 28, 28); break;
                case "cancelled": lblStatus.ForeColor = Color.DimGray; break;
                default: lblStatus.ForeColor = Color.FromArgb(22, 128, 61); break;
            }

            bool pending = IsPending;
            cmbPurpose.Enabled = pending;
            btnSavePurpose.Visible = pending;
            btnCancelRequest.Visible = pending;
            btnDeleteRequest.Visible = IsCancelled;
            btnAgain.Visible = CanRequestAgain;
            btnAgain.Left = IsCancelled ? 134 : 16;

            foreach (Control c in pnlAttachments.Controls)
                if (c is Button b && (b.Tag as string) == "replace") b.Visible = pending;

            if (pending)
                lblNote.Text = "You can still change the purpose, replace a file, or cancel this request while it is Pending.";
            else if (IsCancelled)
                lblNote.Text = "This request was cancelled. You can delete it from your list or submit it again.";
            else if (string.Equals(status, "Rejected", StringComparison.OrdinalIgnoreCase))
                lblNote.Text = "This request was declined. Check your requirements, then press Request Again to resubmit.";
            else if (CanRequestAgain)
                lblNote.Text = "This request is finished. Press Request Again if you need another copy.";
            else
                lblNote.Text = "The barangay is already working on this request, so it can no longer be changed.";
        }

        // ------------------------------------------------------------------ actions

        private void SavePurpose()
        {
            string newPurpose = cmbPurpose.Text.Trim();
            if (newPurpose.Length == 0) { UiKit.Warn(this, "Please enter the purpose of your request."); cmbPurpose.Focus(); return; }
            if (newPurpose == (purpose ?? "")) { UiKit.Info(this, "The purpose is unchanged."); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "UPDATE documentrequests SET purpose = @p WHERE request_id = @id AND user_id = @u AND status = 'Pending'", conn))
                    {
                        cmd.Parameters.AddWithValue("@p", newPurpose);
                        cmd.Parameters.AddWithValue("@id", requestId);
                        cmd.Parameters.AddWithValue("@u", userId);
                        if (cmd.ExecuteNonQuery() != 1) { NoLongerPending(); return; }
                    }

                    // Rebuild the draft document so it shows the new purpose
                    try
                    {
                        string content = DocumentTemplate.BuildDraft(conn, userId, docType, newPurpose);
                        using (MySqlCommand cmd = new MySqlCommand(
                            "UPDATE issued_documents SET content = @c WHERE request_id = @id AND printed_at IS NULL", conn))
                        {
                            cmd.Parameters.AddWithValue("@c", content);
                            cmd.Parameters.AddWithValue("@id", requestId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch { /* the draft is regenerated by the admin editor if this fails */ }
                }

                purpose = newPurpose;
                UiKit.Info(this, "Purpose updated.", "Saved");
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not update the purpose: " + ex.Message);
            }
        }

        private void ReplaceAttachment(int attachmentId, string requirement)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Replace: " + requirement;
                dlg.Filter = "Document Files (*.pdf;*.docx;*.doc;*.jpg;*.jpeg;*.png)|*.pdf;*.docx;*.doc;*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                long size = new FileInfo(dlg.FileName).Length;
                if (size > 5 * 1024 * 1024)
                {
                    UiKit.Warn(this, $"This file is {size / (1024.0 * 1024.0):0.0} MB. Please choose a file smaller than 5 MB.", "File Too Large");
                    return;
                }

                string fileName = Path.GetFileName(dlg.FileName);
                byte[] data = File.ReadAllBytes(dlg.FileName);

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                    {
                        conn.Open();
                        using (MySqlTransaction tx = conn.BeginTransaction())
                        {
                            int changed;
                            using (MySqlCommand cmd = new MySqlCommand(
                                @"UPDATE request_attachments a
                                  JOIN documentrequests r ON r.request_id = a.request_id
                                  SET a.file_name = @f, a.file_data = @d, a.uploaded_at = NOW()
                                  WHERE a.id = @aid AND r.request_id = @rid AND r.user_id = @u AND r.status = 'Pending'", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@f", fileName);
                                cmd.Parameters.AddWithValue("@d", data);
                                cmd.Parameters.AddWithValue("@aid", attachmentId);
                                cmd.Parameters.AddWithValue("@rid", requestId);
                                cmd.Parameters.AddWithValue("@u", userId);
                                changed = cmd.ExecuteNonQuery();
                            }

                            if (changed != 1) { tx.Rollback(); NoLongerPending(); return; }

                            // The first file is also kept in the old single-attachment columns
                            if (attachmentId == firstAttachmentId)
                            {
                                using (MySqlCommand cmd = new MySqlCommand(
                                    "UPDATE documentrequests SET attachment_name = @f, attachment_data = @d WHERE request_id = @rid", conn, tx))
                                {
                                    cmd.Parameters.AddWithValue("@f", fileName);
                                    cmd.Parameters.AddWithValue("@d", data);
                                    cmd.Parameters.AddWithValue("@rid", requestId);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            tx.Commit();
                        }

                        LoadAttachments(conn);
                        ApplyState();
                    }
                    UiKit.Info(this, $"\"{requirement}\" was replaced with {fileName}.", "File replaced");
                }
                catch (Exception ex)
                {
                    UiKit.Error(this, "Could not replace the file: " + ex.Message);
                }
            }
        }

        private void NoLongerPending()
        {
            UiKit.Warn(this, "The barangay has already started working on this request, so it can no longer be changed.", "Request is locked");
            DialogResult = DialogResult.OK;
            LoadRequest();
        }

        private void CancelRequest()
        {
            if (!UiKit.Confirm(this, "Cancel this request?\n\nThe barangay will no longer process it. You can submit it again later.", "Cancel Request", MessageBoxIcon.Warning)) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    int rows;
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand(
                            "UPDATE documentrequests SET status = 'Cancelled' WHERE request_id = @id AND user_id = @u AND status = 'Pending'", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", requestId);
                            cmd.Parameters.AddWithValue("@u", userId);
                            rows = cmd.ExecuteNonQuery();
                        }

                        // Some databases silently blank a value their status list does not allow; make sure it really stuck.
                        if (rows == 1)
                        {
                            object stored;
                            using (MySqlCommand check = new MySqlCommand("SELECT status FROM documentrequests WHERE request_id = @id", conn))
                            {
                                check.Parameters.AddWithValue("@id", requestId);
                                stored = check.ExecuteScalar();
                            }
                            if (!string.Equals(stored?.ToString(), "Cancelled", StringComparison.OrdinalIgnoreCase))
                                rows = DeleteRequestRows(conn, stored == null || stored == DBNull.Value ? null : stored.ToString()) ? 1 : 0;
                        }
                    }
                    catch (MySqlException)
                    {
                        // The status column does not accept "Cancelled" (e.g. it is a fixed list), so remove the request instead.
                        rows = DeleteRequestRows(conn, "Pending") ? 1 : 0;
                    }

                    if (rows != 1) { NoLongerPending(); return; }
                }

                Db.RaiseRequestsChanged();
                UiKit.Info(this, "Your request was cancelled.", "Cancelled");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not cancel the request: " + ex.Message);
            }
        }

        private void DeleteCancelled()
        {
            if (!UiKit.Confirm(this, "Permanently delete this cancelled request from your list?\nThis cannot be undone.", "Delete Request", MessageBoxIcon.Warning)) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    if (!DeleteRequestRows(conn, "Cancelled")) { UiKit.Warn(this, "Only cancelled requests can be deleted."); return; }
                }
                Db.RaiseRequestsChanged();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not delete the request: " + ex.Message);
            }
        }

        // Removes the request with its files and draft, but only if it is still in the expected status.
        private bool DeleteRequestRows(MySqlConnection conn, string requiredStatus)
        {
            using (MySqlTransaction tx = conn.BeginTransaction())
            {
                try
                {
                    string[] statements =
                    {
                        @"DELETE a FROM request_attachments a JOIN documentrequests r ON r.request_id = a.request_id
                          WHERE r.request_id = @id AND r.user_id = @u AND r.status <=> @s",
                        @"DELETE d FROM issued_documents d JOIN documentrequests r ON r.request_id = d.request_id
                          WHERE r.request_id = @id AND r.user_id = @u AND r.status <=> @s",
                        "DELETE FROM documentrequests WHERE request_id = @id AND user_id = @u AND status <=> @s"
                    };

                    int removed = 0;
                    foreach (string sql in statements)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@id", requestId);
                            cmd.Parameters.AddWithValue("@u", userId);
                            cmd.Parameters.AddWithValue("@s", requiredStatus == null ? DBNull.Value : (object)requiredStatus);
                            removed = cmd.ExecuteNonQuery();
                        }
                    }

                    if (removed != 1) { tx.Rollback(); return false; }
                    tx.Commit();
                    return true;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        private void RequestAgain()
        {
            if (!UiKit.Confirm(this,
                $"Submit a new \"{docType}\" request with the same purpose and the same uploaded files?\n\nIf any file is out of date, replace it afterwards while the new request is still Pending.",
                "Request Again")) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    Db.EnsureSchema(conn);

                    long newId;
                    string newReference;
                    using (MySqlTransaction tx = conn.BeginTransaction())
                    {
                        try
                        {
                            int nextNo;
                            using (MySqlCommand cmd = new MySqlCommand(
                                "SELECT COALESCE(MAX(user_req_no), 0) + 1 FROM documentrequests WHERE user_id = @u", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@u", userId);
                                nextNo = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                            newReference = $"REQ-{userId:D4}-{nextNo:D3}";

                            using (MySqlCommand cmd = new MySqlCommand(
                                @"INSERT INTO documentrequests
                                    (user_id, user_req_no, reference_no, username, document_type, purpose, attachment_name, attachment_data)
                                  SELECT user_id, @no, @ref, username, document_type, purpose, attachment_name, attachment_data
                                  FROM documentrequests WHERE request_id = @old AND user_id = @u", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@no", nextNo);
                                cmd.Parameters.AddWithValue("@ref", newReference);
                                cmd.Parameters.AddWithValue("@old", requestId);
                                cmd.Parameters.AddWithValue("@u", userId);
                                if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("The original request could not be found.");
                                newId = cmd.LastInsertedId;
                            }

                            using (MySqlCommand cmd = new MySqlCommand(
                                @"INSERT INTO request_attachments (request_id, requirement_name, file_name, file_data)
                                  SELECT @new, requirement_name, file_name, file_data FROM request_attachments WHERE request_id = @old", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@new", newId);
                                cmd.Parameters.AddWithValue("@old", requestId);
                                cmd.ExecuteNonQuery();
                            }

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }

                    try { DocumentTemplate.SaveDraft(conn, (int)newId, userId, docType, purpose); }
                    catch { /* the admin editor can still build the draft later */ }

                    Db.RaiseRequestsChanged();
                    UiKit.Info(this, $"Your new request has been submitted.\nReference Number: {newReference}", "Request submitted");
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not submit the new request: " + ex.Message);
            }
        }
    }
}
