#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// Admin screen to add, rename, re-price and delete document types, and to manage the purposes
    /// residents can pick for each one.
    /// </summary>
    internal class ManageDocumentTypesForm : Form
    {
        private class PurposeItem
        {
            public int Id;
            public string Name;
            public override string ToString() { return Name; }
        }

        private readonly DataGridView grid = new DataGridView();
        private readonly ListBox lstPurposes = new ListBox();
        private readonly Label lblPurposes = new Label();
        private Button btnPurposeAdd, btnPurposeRename, btnPurposeDelete;

        public ManageDocumentTypesForm()
        {
            Text = "Manage Document Types & Purposes";
            ClientSize = new Size(820, 470);
            StartPosition = FormStartPosition.CenterParent;
            MinimizeBox = false;
            ShowInTaskbar = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            Panel header = new Panel { Dock = DockStyle.Top, Height = 44, BackColor = UiKit.Brand };
            header.Controls.Add(new Label { Text = "📑  Document Types & Purposes", ForeColor = Color.White, Font = new Font("Segoe UI", 11F, FontStyle.Bold), Location = new Point(14, 11), AutoSize = true });
            Controls.Add(header);

            // ---- left: document types ----
            Controls.Add(new Label { Text = "Document types", Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Location = new Point(16, 56), AutoSize = true });

            grid.Location = new Point(16, 80);
            grid.Size = new Size(500, 330);
            grid.ReadOnly = true;
            UiKit.StyleGrid(grid);
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.AutoGenerateColumns = false;
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "id", DataPropertyName = "id", Visible = false });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "document_name", DataPropertyName = "document_name", HeaderText = "Document", FillWeight = 140 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "price", DataPropertyName = "price", HeaderText = "Price (₱)", FillWeight = 60, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "requirements", DataPropertyName = "requirements", HeaderText = "Requirements", FillWeight = 160 });
            grid.SelectionChanged += (s, e) => LoadPurposes();
            grid.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) EditType(); };
            Controls.Add(grid);

            Button add = UiKit.Btn("➕ Add", 16, 420, 90, 30, UiKit.Brand, Color.White);
            Button edit = UiKit.Btn("✏ Edit", 114, 420, 90, 30, Color.SteelBlue, Color.White);
            Button del = UiKit.Btn("🗑 Delete", 212, 420, 90, 30, UiKit.Danger, Color.White);
            add.Click += (s, e) => AddType();
            edit.Click += (s, e) => EditType();
            del.Click += (s, e) => DeleteType();
            Controls.AddRange(new Control[] { add, edit, del });

            // ---- right: purposes of the selected type ----
            lblPurposes.Location = new Point(536, 56);
            lblPurposes.Size = new Size(270, 20);
            lblPurposes.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPurposes.AutoEllipsis = true;
            Controls.Add(lblPurposes);

            lstPurposes.Location = new Point(536, 80);
            lstPurposes.Size = new Size(270, 330);
            lstPurposes.BorderStyle = BorderStyle.FixedSingle;
            lstPurposes.DoubleClick += (s, e) => RenamePurpose();
            Controls.Add(lstPurposes);

            btnPurposeAdd = UiKit.Btn("➕ Add", 536, 420, 80, 30, UiKit.Brand, Color.White);
            btnPurposeRename = UiKit.Btn("✏ Rename", 624, 420, 90, 30, Color.SteelBlue, Color.White);
            btnPurposeDelete = UiKit.Btn("🗑", 722, 420, 40, 30, UiKit.Danger, Color.White);
            btnPurposeAdd.Click += (s, e) => AddPurpose();
            btnPurposeRename.Click += (s, e) => RenamePurpose();
            btnPurposeDelete.Click += (s, e) => DeletePurpose();
            Controls.AddRange(new Control[] { btnPurposeAdd, btnPurposeRename, btnPurposeDelete });

            Button close = UiKit.Btn("Close", 770, 420, 40, 30, UiKit.Muted, Color.FromArgb(71, 85, 105));
            close.Text = "✕";
            close.Click += (s, e) => Close();
            Controls.Add(close);
            CancelButton = close;

            Load += (s, e) => LoadTypes(null);
        }

        // ------------------------------------------------------------------ helpers

        private int? SelectedTypeId()
        {
            if (grid.CurrentRow == null) return null;
            object v = grid.CurrentRow.Cells["id"].Value;
            return v == null || v == DBNull.Value ? (int?)null : Convert.ToInt32(v);
        }

        private string SelectedTypeName()
        {
            return grid.CurrentRow?.Cells["document_name"].Value?.ToString();
        }

        private void LoadTypes(int? keepId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                using (MySqlDataAdapter ad = new MySqlDataAdapter("SELECT id, document_name, price, requirements FROM document_types ORDER BY document_name", conn))
                {
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    grid.DataSource = dt;
                }

                if (keepId.HasValue)
                    foreach (DataGridViewRow r in grid.Rows)
                        if (Convert.ToInt32(r.Cells["id"].Value) == keepId.Value) { grid.CurrentCell = r.Cells["document_name"]; break; }

                LoadPurposes();
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not load document types: " + ex.Message);
            }
        }

        private void LoadPurposes()
        {
            lstPurposes.Items.Clear();
            int? typeId = SelectedTypeId();
            bool has = typeId.HasValue;
            btnPurposeAdd.Enabled = btnPurposeRename.Enabled = btnPurposeDelete.Enabled = has;
            lblPurposes.Text = has ? "Purposes for: " + SelectedTypeName() : "Purposes";
            if (!has) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT id, purpose_name FROM document_purposes WHERE doc_type_id = @t ORDER BY purpose_name", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", typeId.Value);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                            while (r.Read())
                                lstPurposes.Items.Add(new PurposeItem { Id = Convert.ToInt32(r["id"]), Name = r["purpose_name"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not load purposes: " + ex.Message);
            }
        }

        // ------------------------------------------------------------------ document types

        private void AddType()
        {
            using (DocTypeDialog dlg = new DocTypeDialog(null))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                    {
                        conn.Open();
                        if (NameTaken(conn, dlg.TypeName, null)) { UiKit.Warn(this, $"A document type named \"{dlg.TypeName}\" already exists."); return; }

                        long newId;
                        using (MySqlCommand cmd = new MySqlCommand(
                            "INSERT INTO document_types (document_name, price, requirements, requires_attachment) VALUES (@n, @p, @r, @a)", conn))
                        {
                            cmd.Parameters.AddWithValue("@n", dlg.TypeName);
                            cmd.Parameters.AddWithValue("@p", dlg.Price);
                            cmd.Parameters.AddWithValue("@r", dlg.Requirements);
                            cmd.Parameters.AddWithValue("@a", dlg.RequiresAttachment ? 1 : 0);
                            cmd.ExecuteNonQuery();
                            newId = cmd.LastInsertedId;
                        }
                        LoadTypes((int)newId);
                    }
                }
                catch (Exception ex)
                {
                    UiKit.Error(this, "Could not add the document type: " + ex.Message);
                }
            }
        }

        private void EditType()
        {
            int? id = SelectedTypeId();
            if (!id.HasValue) { UiKit.Warn(this, "Select a document type first.", "Nothing selected"); return; }

            try
            {
                string oldName, requirements; decimal price; bool requires;
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT document_name, price, requirements, requires_attachment FROM document_types WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id.Value);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (!r.Read()) { UiKit.Warn(this, "That document type no longer exists."); LoadTypes(null); return; }
                            oldName = r["document_name"].ToString();
                            price = r["price"] == DBNull.Value ? 0m : Convert.ToDecimal(r["price"]);
                            requirements = r["requirements"]?.ToString() ?? "";
                            requires = r["requires_attachment"] != DBNull.Value && Convert.ToBoolean(r["requires_attachment"]);
                        }
                    }

                    using (DocTypeDialog dlg = new DocTypeDialog(new object[] { oldName, price, requirements, requires }))
                    {
                        if (dlg.ShowDialog(this) != DialogResult.OK) return;
                        if (NameTaken(conn, dlg.TypeName, id.Value)) { UiKit.Warn(this, $"A document type named \"{dlg.TypeName}\" already exists."); return; }

                        using (MySqlTransaction tx = conn.BeginTransaction())
                        {
                            try
                            {
                                using (MySqlCommand cmd = new MySqlCommand(
                                    "UPDATE document_types SET document_name = @n, price = @p, requirements = @r, requires_attachment = @a WHERE id = @id", conn, tx))
                                {
                                    cmd.Parameters.AddWithValue("@n", dlg.TypeName);
                                    cmd.Parameters.AddWithValue("@p", dlg.Price);
                                    cmd.Parameters.AddWithValue("@r", dlg.Requirements);
                                    cmd.Parameters.AddWithValue("@a", dlg.RequiresAttachment ? 1 : 0);
                                    cmd.Parameters.AddWithValue("@id", id.Value);
                                    cmd.ExecuteNonQuery();
                                }

                                // Requests, drafts and templates remember the type by name, so carry a rename through.
                                if (!string.Equals(oldName, dlg.TypeName, StringComparison.Ordinal))
                                {
                                    string[] renames =
                                    {
                                        "UPDATE documentrequests SET document_type = @new WHERE document_type = @old",
                                        "UPDATE issued_documents SET document_type = @new WHERE document_type = @old",
                                        "UPDATE IGNORE document_templates SET doc_type = @new WHERE doc_type = @old"
                                    };
                                    foreach (string sql in renames)
                                        using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
                                        {
                                            cmd.Parameters.AddWithValue("@new", dlg.TypeName);
                                            cmd.Parameters.AddWithValue("@old", oldName);
                                            cmd.ExecuteNonQuery();
                                        }
                                }
                                tx.Commit();
                            }
                            catch
                            {
                                tx.Rollback();
                                throw;
                            }
                        }
                    }
                }
                LoadTypes(id);
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not update the document type: " + ex.Message);
            }
        }

        private void DeleteType()
        {
            int? id = SelectedTypeId();
            if (!id.HasValue) { UiKit.Warn(this, "Select a document type first.", "Nothing selected"); return; }
            string name = SelectedTypeName();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    long used;
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM documentrequests WHERE document_type = @n", conn))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        used = Convert.ToInt64(cmd.ExecuteScalar());
                    }

                    string message = $"Delete the document type \"{name}\" and all of its purposes?\n\nResidents will no longer be able to request it.";
                    if (used > 0) message += $"\n\n{used} existing request(s) for it will keep their records.";
                    if (!UiKit.Confirm(this, message, "Delete Document Type", MessageBoxIcon.Warning)) return;

                    using (MySqlTransaction tx = conn.BeginTransaction())
                    {
                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM document_purposes WHERE doc_type_id = @id", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", id.Value);
                                cmd.ExecuteNonQuery();
                            }
                            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM document_types WHERE id = @id", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", id.Value);
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
                }
                LoadTypes(null);
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not delete the document type: " + ex.Message);
            }
        }

        private static bool NameTaken(MySqlConnection conn, string name, int? exceptId)
        {
            using (MySqlCommand cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM document_types WHERE LOWER(document_name) = LOWER(@n) AND (@id IS NULL OR id <> @id)", conn))
            {
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@id", exceptId.HasValue ? (object)exceptId.Value : DBNull.Value);
                return Convert.ToInt64(cmd.ExecuteScalar()) > 0;
            }
        }

        // ------------------------------------------------------------------ purposes

        private void AddPurpose()
        {
            int? typeId = SelectedTypeId();
            if (!typeId.HasValue) return;

            string name = UiKit.Prompt(this, "Add Purpose", $"New purpose for \"{SelectedTypeName()}\":", "", false, 100);
            if (string.IsNullOrWhiteSpace(name)) return;

            foreach (PurposeItem p in lstPurposes.Items)
                if (string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase)) { UiKit.Warn(this, "That purpose already exists for this document."); return; }

            RunPurposeSql("INSERT INTO document_purposes (doc_type_id, purpose_name) VALUES (@t, @n)", typeId.Value, name, null);
        }

        private void RenamePurpose()
        {
            if (!(lstPurposes.SelectedItem is PurposeItem item)) { UiKit.Warn(this, "Select a purpose first.", "Nothing selected"); return; }

            string name = UiKit.Prompt(this, "Rename Purpose", "Purpose name:", item.Name, false, 100);
            if (string.IsNullOrWhiteSpace(name) || name == item.Name) return;

            RunPurposeSql("UPDATE document_purposes SET purpose_name = @n WHERE id = @pid", 0, name, item.Id);
        }

        private void DeletePurpose()
        {
            if (!(lstPurposes.SelectedItem is PurposeItem item)) { UiKit.Warn(this, "Select a purpose first.", "Nothing selected"); return; }
            if (!UiKit.Confirm(this, $"Delete the purpose \"{item.Name}\"?", "Delete Purpose", MessageBoxIcon.Warning)) return;

            RunPurposeSql("DELETE FROM document_purposes WHERE id = @pid", 0, null, item.Id);
        }

        private void RunPurposeSql(string sql, int typeId, string name, int? purposeId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        if (sql.Contains("@t")) cmd.Parameters.AddWithValue("@t", typeId);
                        if (sql.Contains("@n")) cmd.Parameters.AddWithValue("@n", name);
                        if (sql.Contains("@pid")) cmd.Parameters.AddWithValue("@pid", purposeId.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadPurposes();
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not save the purpose: " + ex.Message);
            }
        }
    }

    /// <summary>Add / edit dialog for one document type.</summary>
    internal class DocTypeDialog : Form
    {
        private readonly TextBox txtName, txtReq;
        private readonly NumericUpDown nudPrice;
        private readonly CheckBox chkAttach;

        public string TypeName => txtName.Text.Trim();
        public decimal Price => nudPrice.Value;
        public string Requirements => txtReq.Text.Replace("\r\n", "\n").Trim().Replace("\n", "\r\n");
        public bool RequiresAttachment => chkAttach.Checked;

        // existing = null for "add", otherwise { name, price, requirements, requiresAttachment }
        public DocTypeDialog(object[] existing)
        {
            Text = existing == null ? "Add Document Type" : "Edit Document Type";
            ClientSize = new Size(440, 340);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false; ShowInTaskbar = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            Controls.Add(UiKit.Lbl("Document name *", 16, 16, 120));
            txtName = UiKit.Text(140, 16, 280, 100);
            Controls.Add(txtName);

            Controls.Add(UiKit.Lbl("Price (₱)", 16, 52, 120));
            nudPrice = new NumericUpDown { Location = new Point(140, 52), Width = 110, DecimalPlaces = 2, Minimum = 0, Maximum = 100000 };
            Controls.Add(nudPrice);

            chkAttach = new CheckBox { Text = "Residents must upload the requirements", Location = new Point(140, 86), AutoSize = true };
            Controls.Add(chkAttach);

            Controls.Add(UiKit.Lbl("Requirements", 16, 118, 120));
            txtReq = new TextBox { Location = new Point(140, 118), Size = new Size(280, 130), Multiline = true, ScrollBars = ScrollBars.Vertical, AcceptsReturn = true, MaxLength = 500 };
            Controls.Add(txtReq);
            Controls.Add(new Label { Text = "One requirement per line, e.g.\n  Valid ID\n  Proof of Residency", Location = new Point(140, 252), Size = new Size(280, 48), ForeColor = Color.DimGray });

            if (existing != null)
            {
                txtName.Text = (string)existing[0];
                nudPrice.Value = Math.Min(Math.Max((decimal)existing[1], nudPrice.Minimum), nudPrice.Maximum);
                txtReq.Text = ((string)existing[2]).Replace("\r\n", "\n").Replace("\n", "\r\n");
                chkAttach.Checked = (bool)existing[3];
            }

            Button save = UiKit.Btn("💾 Save", 230, 300, 100, 32, UiKit.Brand, Color.White);
            Button cancel = UiKit.Btn("Cancel", 340, 300, 80, 32, UiKit.Muted, Color.FromArgb(71, 85, 105));
            save.Click += (s, e) => TrySave();
            cancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            Controls.Add(save);
            Controls.Add(cancel);
            AcceptButton = null;     // Enter must stay a new line inside the requirements box
            CancelButton = cancel;
        }

        private void TrySave()
        {
            if (TypeName.Length == 0) { UiKit.Warn(this, "Please enter the document name."); txtName.Focus(); return; }
            if (chkAttach.Checked && Requirements.Length == 0)
            {
                UiKit.Warn(this, "List at least one requirement, or untick \"Residents must upload the requirements\".");
                txtReq.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
