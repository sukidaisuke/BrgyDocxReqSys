#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// Settings page where the admin edits the wording of each document
    /// (in case the barangay changes how a certificate should read).
    /// </summary>
    public class TemplateEditorControl : UserControl
    {
        private ComboBox cmbDocType;
        private WordEditor editor;
        private Label lblState;
        private Button btnSave, btnReset, btnPreview;
        private bool loading = false;

        public TemplateEditorControl()
        {
            BuildUi();
            Load += (s, e) => LoadDocumentTypes();
        }

        private void BuildUi()
        {
            Dock = DockStyle.Fill;
            BackColor = Color.White;

            GroupBox box = new GroupBox
            {
                Dock = DockStyle.Fill,
                Text = "📝 Document Templates",
                Font = new Font("Segoe UI", 11.25F, FontStyle.Bold),
                Padding = new Padding(10)
            };

            TableLayoutPanel t = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5,
                Font = new Font("Segoe UI", 9F)
            };
            t.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));   // doc type picker
            t.RowStyles.Add(new RowStyle(SizeType.Absolute, 52));   // help text
            t.RowStyles.Add(new RowStyle(SizeType.Percent, 100));   // editor
            t.RowStyles.Add(new RowStyle(SizeType.Absolute, 22));   // state
            t.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));   // buttons

            cmbDocType = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbDocType.SelectedIndexChanged += (s, e) => LoadTemplate();

            Label help = new Label
            {
                Dock = DockStyle.Fill,
                ForeColor = Color.FromArgb(75, 85, 99),
                Font = new Font("Segoe UI", 8.5F),
                Text = "Design the document like in Word. Use \"Insert field\" to add things that are filled in " +
                       "automatically (name, address, signing official ...). Use \"Insert Picture\" for a logo or seal."
            };

            editor = new WordEditor();
            editor.SetFieldMenu(DocumentTemplate.FieldMenu);

            lblState = new Label { Dock = DockStyle.Fill, ForeColor = Color.DimGray, Font = new Font("Segoe UI", 8.5F, FontStyle.Italic) };

            FlowLayoutPanel buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };
            btnSave = MakeButton("💾 Save Template", Color.FromArgb(48, 44, 105), 140);
            btnPreview = MakeButton("👁 Preview", Color.FromArgb(8, 145, 178), 100);
            btnReset = MakeButton("↺ Reset to Default", Color.Gray, 140);
            btnSave.Click += BtnSave_Click;
            btnPreview.Click += BtnPreview_Click;
            btnReset.Click += BtnReset_Click;
            buttons.Controls.AddRange(new Control[] { btnSave, btnPreview, btnReset });

            t.Controls.Add(cmbDocType, 0, 0);
            t.Controls.Add(help, 0, 1);
            t.Controls.Add(editor, 0, 2);
            t.Controls.Add(lblState, 0, 3);
            t.Controls.Add(buttons, 0, 4);

            box.Controls.Add(t);
            Controls.Add(box);
        }

        private Button MakeButton(string text, Color color, int width)
        {
            return new Button
            {
                Text = text,
                Size = new Size(width, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = color,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
        }

        private void LoadDocumentTypes()
        {
            try
            {
                loading = true;
                cmbDocType.Items.Clear();
                using (MySqlConnection conn = new MySqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    Db.EnsureSchema(conn);
                    using (MySqlCommand cmd = new MySqlCommand("SELECT document_name FROM document_types ORDER BY document_name", conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read()) cmbDocType.Items.Add(r["document_name"].ToString());
                    }
                }
                loading = false;
                if (cmbDocType.Items.Count > 0) cmbDocType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                loading = false;
                MessageBox.Show("Error loading document types: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CurrentDocType()
        {
            return cmbDocType.SelectedItem == null ? null : cmbDocType.SelectedItem.ToString();
        }

        private bool HasCustomTemplate(MySqlConnection conn, string docType)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM document_templates WHERE doc_type = @t", conn))
            {
                cmd.Parameters.AddWithValue("@t", docType);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void LoadTemplate()
        {
            if (loading) return;
            string docType = CurrentDocType();
            if (docType == null) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    editor.Rtf = DocumentTemplate.GetTemplateRtf(conn, docType);
                    lblState.Text = HasCustomTemplate(conn, docType)
                        ? "Using your edited template."
                        : "Using the built-in layout (not edited yet).";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading template: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string docType = CurrentDocType();
            if (docType == null) return;

            string body = editor.Rtf;
            if (editor.Rich.TextLength == 0)
            {
                MessageBox.Show("The template cannot be empty. Use \"Reset to Default\" to go back to the original layout.",
                    "Empty Template", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    Db.EnsureSchema(conn);
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"INSERT INTO document_templates (doc_type, body) VALUES (@t, @b)
                          ON DUPLICATE KEY UPDATE body = VALUES(body)", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", docType);
                        cmd.Parameters.AddWithValue("@b", body);
                        cmd.ExecuteNonQuery();
                    }
                }
                lblState.Text = "Using your edited template.";
                MessageBox.Show("Template saved. It will be used for new requests of this document.\n\n" +
                                "Requests that were already made keep their current document.",
                                "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving template: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            string docType = CurrentDocType();
            if (docType == null) return;

            if (MessageBox.Show("Discard your changes and go back to the built-in layout for \"" + docType + "\"?",
                    "Reset Template", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    Db.EnsureSchema(conn);
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM document_templates WHERE doc_type = @t", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", docType);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadTemplate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting template: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Shows the template filled with sample resident data (does not save anything)
        private void BtnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                BarangayDetails b;
                using (MySqlConnection conn = new MySqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    b = DocumentTemplate.GetBarangay(conn);
                }

                string docType = CurrentDocType() ?? "";
                string address = "House No. 12, Purok 3, Barangay " + b.Name + ", " + b.Municipality + ", " + b.Province;
                var values = DocumentTemplate.BuildValues(docType, "Juan Dela Cruz", "30", address, b, 10, "Employment", DateTime.Now);
                values["{SIGNATORY_NAME}"] = "HON. JUAN SANTOS";
                values["{SIGNATORY_POSITION}"] = "Barangay Captain";
                values["{REF_NO}"] = "REQ-0001-001";

                RichTextBoxPrinter box = new RichTextBoxPrinter { ReadOnly = true, BackColor = Color.White, Dock = DockStyle.Fill };
                box.Rtf = editor.Rtf;
                DocumentTemplate.ReplaceTokens(box, values);

                using (Form f = new Form())
                {
                    f.Text = "Preview — sample resident";
                    f.Size = new Size(720, 700);
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.Controls.Add(box);
                    f.ShowDialog(FindForm());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not build the preview: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
