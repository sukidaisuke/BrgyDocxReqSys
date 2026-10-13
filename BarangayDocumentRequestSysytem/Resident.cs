#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class Resident : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;Convert Zero Datetime=True;";

        public Resident()
        {
            InitializeComponent();
            if (!this.DesignMode) SetupExtras();

            this.Load += Resident_Load;
            this.VisibleChanged += Resident_VisibleChanged;
            this.Resize += (s, e) => CenterModalCard();
        }

        private void Resident_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                UpdateHeaderDate();
                LoadResidents();
                CenterModalCard();
            }
        }

        private void Resident_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !this.DesignMode)
            {
                LoadResidents();
                CenterModalCard();
            }
        }

        private string GetBarangayName(MySqlConnection conn)
        {
            try
            {
                string query = "SELECT barangay_name FROM barangay_info WHERE id = 1 LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        string name = result.ToString().Trim();
                        if (!string.IsNullOrEmpty(name))
                        {
                            return name.StartsWith("Barangay", StringComparison.OrdinalIgnoreCase)
                                ? name
                                : $"Barangay {name}";
                        }
                    }
                }
            }
            catch
            {
                // Fallback in case table is missing or empty
            }
            return "Barangay Central";
        }

        private void CenterModalCard()
        {
            if (pnlModalCard != null && pnlModalOverlay != null)
            {
                pnlModalCard.Location = new Point(
                    Math.Max((pnlModalOverlay.Width - pnlModalCard.Width) / 2, 0),
                    Math.Max((pnlModalOverlay.Height - pnlModalCard.Height) / 2, 0)
                );
            }
        }

        private void UpdateHeaderDate()
        {
            if (lblDate != null)
            {
                lblDate.Text = $"📅 {DateTime.Now:MMMM d, yyyy | dddd}";
            }
        }

        // --- Load Residents from MySQL Database ---
        public void LoadResidents(string filter = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string currentBarangay = GetBarangayName(conn);

                    string query = @"
                        SELECT 
                            user_id,
                            CONCAT('RES-', LPAD(user_id, 3, '0')) AS formatted_id,
                            TRIM(CONCAT(first_name, ' ', IFNULL(CONCAT(middle_name, ' '), ''), last_name)) AS full_name,
                            contact_no,
                            CONCAT(
                                IF(house_no IS NOT NULL AND TRIM(house_no) != '', CONCAT('House #', house_no, ', '), ''),
                                'Purok ', IFNULL(purok_no, 'N/A'), ', ', @brgyName
                            ) AS full_address,
                            sex,
                            birthdate,
                            house_no,
                            purok_no,
                            years_of_residency,
                            voter_status
                        FROM users
                        WHERE role='user'";

                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        query += @" AND (
                            first_name LIKE @filter OR 
                            last_name LIKE @filter OR 
                            contact_no LIKE @filter OR 
                            purok_no LIKE @filter OR 
                            CONCAT('RES-', LPAD(user_id, 3, '0')) LIKE @filter
                        )";
                    }

                    var extraParams = new System.Collections.Generic.List<KeyValuePair<string, object>>();
                    query += BuildFilterSql(extraParams);

                    query += " ORDER BY user_id DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@brgyName", currentBarangay);
                        foreach (var kv in extraParams) cmd.Parameters.AddWithValue(kv.Key, kv.Value);

                        if (!string.IsNullOrWhiteSpace(filter))
                        {
                            cmd.Parameters.AddWithValue("@filter", $"%{filter}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvResidents.DataSource = dt;
                            currentTable = dt;

                            if (pageLBL != null)
                            {
                                bool filtered = !string.IsNullOrWhiteSpace(filter) || FiltersActive();
                                pageLBL.Text = filtered
                                    ? $"Showing {dt.Rows.Count} resident(s) matching your search/filters"
                                    : $"Total Residents Registered: {dt.Rows.Count}";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading residents: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- DGV Action Click Handler (View / Edit / Delete) ---
        private void DgvResidents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvResidents.Columns[e.ColumnIndex].Name;
            if (colName == "colSelect") return;

            int userId = RowUserId(e.RowIndex);

            if (colName == "btnView") ShowResidentDetailsModal(userId);
            else if (colName == "btnEdit") EditResident(userId);
            else if (colName == "btnDelete") DeleteResidents(new System.Collections.Generic.List<int> { userId });
        }

        // --- View Details Modal ---
        private void ShowResidentDetailsModal(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string currentBarangay = GetBarangayName(conn);

                    string query = @"
                        SELECT user_id, first_name, middle_name, last_name, sex, birthdate, 
                               contact_no, house_no, purok_no, years_of_residency, voter_status
                        FROM users WHERE user_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblModalTitle.Text = $"👤 Resident Profile (RES-{userId:D3})";

                                string fullName = $"{reader["first_name"]} {reader["middle_name"]} {reader["last_name"]}".Replace("  ", " ");
                                lblValFullName.Text = fullName;
                                lblValSex.Text = reader["sex"]?.ToString() ?? "N/A";

                                if (reader["birthdate"] != DBNull.Value)
                                {
                                    DateTime bdate = Convert.ToDateTime(reader["birthdate"]);
                                    int age = DateTime.Today.Year - bdate.Year;
                                    if (bdate.Date > DateTime.Today.AddYears(-age)) age--;
                                    lblValBirthdate.Text = $"{bdate:MMM dd, yyyy} ({age} yrs old)";
                                }
                                else
                                {
                                    lblValBirthdate.Text = "N/A";
                                }

                                lblValContact.Text = string.IsNullOrWhiteSpace(reader["contact_no"]?.ToString()) ? "N/A" : reader["contact_no"].ToString();

                                string house = reader["house_no"]?.ToString();
                                string purok = reader["purok_no"]?.ToString();
                                string housePart = string.IsNullOrWhiteSpace(house) ? "" : $"House #{house}, ";
                                lblValAddress.Text = $"{housePart}Purok {purok}, {currentBarangay}";

                                lblValResidency.Text = $"{reader["years_of_residency"]} Year(s)";
                                lblValVoter.Text = reader["voter_status"]?.ToString() ?? "N/A";

                                CenterModalCard();
                                pnlModalOverlay.BringToFront();
                                pnlModalOverlay.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving resident details: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnModalClose_Click(object sender, EventArgs e)
        {
            pnlModalOverlay.Visible = false;
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            LoadResidents(searchTB.Text.Trim());
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            LoadResidents(searchTB.Text.Trim());
        }

        private void AddResidentButton_Click(object sender, EventArgs e)
        {
            using (ResidentForm form = new ResidentForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadResidents(searchTB.Text.Trim());
                    MessageBox.Show("Resident added. Give them the username and temporary password you entered.", "Resident Added",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // =====================================================================
        // Edit / delete / filters / export / bulk actions
        // =====================================================================

        private DataTable currentTable;
        private FlowLayoutPanel pnlTools;
        private ComboBox cmbPurokFilter, cmbVoterFilter, cmbSexFilter, cmbAgeFilter;
        private ContextMenuStrip rowMenu;
        private ContextMenuStrip bulkMenu;
        private bool filtersReady = false;

        private int RowUserId(int rowIndex)
        {
            return Convert.ToInt32(dgvResidents.Rows[rowIndex].Cells["user_id"].Value);
        }

        private string RowName(int rowIndex)
        {
            return dgvResidents.Rows[rowIndex].Cells["full_name"].Value?.ToString() ?? "this resident";
        }

        private void SetupExtras()
        {
            // --- grid: tick-box column, Edit button, in-place checkbox editing ---
            dgvResidents.ReadOnly = false;   // every data column is already ReadOnly; only the tick-boxes are editable

            DataGridViewCheckBoxColumn colSelect = new DataGridViewCheckBoxColumn
            {
                Name = "colSelect",
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 34,
                Resizable = DataGridViewTriState.False
            };
            dgvResidents.Columns.Insert(0, colSelect);

            DataGridViewButtonColumn colEdit = new DataGridViewButtonColumn
            {
                Name = "btnEdit",
                HeaderText = "Edit",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 55
            };
            colEdit.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                ForeColor = Color.SteelBlue,
                SelectionForeColor = Color.SteelBlue
            };
            dgvResidents.Columns.Insert(dgvResidents.Columns["btnDelete"].Index, colEdit);

            dgvResidents.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvResidents.IsCurrentCellDirty) dgvResidents.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            dgvResidents.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvResidents.Columns[e.ColumnIndex].Name != "colSelect"
                    && !(dgvResidents.Columns[e.ColumnIndex] is DataGridViewButtonColumn))
                    EditResident(RowUserId(e.RowIndex));
            };

            // --- right-click menu on a row ---
            rowMenu = new ContextMenuStrip();
            int menuRow = -1;
            rowMenu.Items.Add("✏️  Edit resident", null, (s, e) => EditResident(RowUserId(menuRow)));
            rowMenu.Items.Add("👁️  View profile", null, (s, e) => ShowResidentDetailsModal(RowUserId(menuRow)));
            rowMenu.Items.Add("📄  Request history", null, (s, e) =>
            {
                using (ResidentRequestsForm f = new ResidentRequestsForm(RowUserId(menuRow), RowName(menuRow))) f.ShowDialog(this);
            });
            rowMenu.Items.Add("🔑  Reset password…", null, (s, e) => ResidentTools.ResetPassword(this, RowUserId(menuRow), RowName(menuRow)));
            rowMenu.Items.Add(new ToolStripSeparator());
            rowMenu.Items.Add("🗑️  Delete…", null, (s, e) => DeleteResidents(new System.Collections.Generic.List<int> { RowUserId(menuRow) }));
            dgvResidents.CellContextMenuStripNeeded += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                menuRow = e.RowIndex;
                dgvResidents.ClearSelection();
                dgvResidents.Rows[e.RowIndex].Selected = true;
                e.ContextMenuStrip = rowMenu;
            };

            // --- filter + action bar above the table ---
            pnlTools = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = true,
                Padding = new Padding(6, 2, 6, 2),
                BackColor = Color.White
            };

            cmbPurokFilter = MakeFilter(new[] { "All puroks", "Purok 1", "Purok 2", "Purok 3", "Purok 4", "Purok 5", "Purok 6", "Purok 7", "Purok 8", "Purok 9" });
            cmbVoterFilter = MakeFilter(new[] { "All voters", "Registered voters", "Non-voters" });
            cmbSexFilter = MakeFilter(new[] { "All sexes", "Male", "Female", "Other" });
            cmbAgeFilter = MakeFilter(new[] { "All ages", "Minors (0–17)", "Adults (18–59)", "Seniors (60+)" });

            Button btnReset = MakeToolButton("✖ Reset", 64, Color.FromArgb(241, 245, 249), Color.FromArgb(71, 85, 105));
            btnReset.Click += (s, e) =>
            {
                filtersReady = false;
                foreach (ComboBox c in new[] { cmbPurokFilter, cmbVoterFilter, cmbSexFilter, cmbAgeFilter }) c.SelectedIndex = 0;
                searchTB.Text = "";
                filtersReady = true;
                LoadResidents();
            };

            Button btnExport = MakeToolButton("⬇ Export CSV", 100, Color.FromArgb(220, 252, 231), Color.FromArgb(22, 101, 52));
            btnExport.Click += (s, e) => ResidentTools.ExportCsv(this, currentTable);

            bulkMenu = new ContextMenuStrip();
            bulkMenu.Items.Add("✔  Select all shown", null, (s, e) => SetAllChecked(true));
            bulkMenu.Items.Add("✘  Clear selection", null, (s, e) => SetAllChecked(false));
            bulkMenu.Items.Add(new ToolStripSeparator());
            bulkMenu.Items.Add("🗳️  Mark as registered voters", null, (s, e) => BulkSetVoter("Yes"));
            bulkMenu.Items.Add("🚫  Mark as non-voters", null, (s, e) => BulkSetVoter("No"));
            bulkMenu.Items.Add(new ToolStripSeparator());
            bulkMenu.Items.Add("🗑️  Delete ticked residents…", null, (s, e) => DeleteResidents(GetCheckedIds()));

            Button btnBulk = MakeToolButton("☑ Ticked ▾", 90, Color.FromArgb(224, 242, 254), Color.FromArgb(30, 64, 175));
            btnBulk.Click += (s, e) => bulkMenu.Show(btnBulk, new Point(0, btnBulk.Height));

            pnlTools.Controls.AddRange(new Control[] { cmbPurokFilter, cmbVoterFilter, cmbSexFilter, cmbAgeFilter, btnReset, btnExport, btnBulk });
            bodyGB.Controls.Add(pnlTools);

            filtersReady = true;
        }

        private ComboBox MakeFilter(string[] items)
        {
            ComboBox c = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 112,
                Margin = new Padding(3, 3, 3, 3),
                Font = new Font("Segoe UI", 8.75F)
            };
            c.Items.AddRange(items);
            c.SelectedIndex = 0;
            c.SelectedIndexChanged += (s, e) => { if (filtersReady) LoadResidents(searchTB.Text.Trim()); };
            return c;
        }

        private Button MakeToolButton(string text, int width, Color back, Color fore)
        {
            Button b = new Button
            {
                Text = text,
                Width = width,
                Height = 26,
                Margin = new Padding(3, 2, 3, 2),
                FlatStyle = FlatStyle.Flat,
                BackColor = back,
                ForeColor = fore,
                Font = new Font("Segoe UI", 8.75F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }

        private bool FiltersActive()
        {
            return cmbPurokFilter != null &&
                   (cmbPurokFilter.SelectedIndex > 0 || cmbVoterFilter.SelectedIndex > 0 ||
                    cmbSexFilter.SelectedIndex > 0 || cmbAgeFilter.SelectedIndex > 0);
        }

        // Builds the extra " AND ..." conditions for the filter drop-downs (all values are parameters).
        private string BuildFilterSql(System.Collections.Generic.List<KeyValuePair<string, object>> p)
        {
            if (cmbPurokFilter == null) return "";
            string sql = "";

            if (cmbPurokFilter.SelectedIndex > 0)
            {
                sql += " AND purok_no = @fPurok";
                p.Add(new KeyValuePair<string, object>("@fPurok", cmbPurokFilter.SelectedIndex.ToString()));
            }
            if (cmbVoterFilter.SelectedIndex == 1) sql += " AND voter_status = 'Yes'";
            else if (cmbVoterFilter.SelectedIndex == 2) sql += " AND (voter_status IS NULL OR voter_status <> 'Yes')";

            if (cmbSexFilter.SelectedIndex > 0)
            {
                sql += " AND sex = @fSex";
                p.Add(new KeyValuePair<string, object>("@fSex", cmbSexFilter.SelectedItem.ToString()));
            }
            if (cmbAgeFilter.SelectedIndex > 0)
            {
                int min = 0, max = 17;
                if (cmbAgeFilter.SelectedIndex == 2) { min = 18; max = 59; }
                else if (cmbAgeFilter.SelectedIndex == 3) { min = 60; max = 200; }
                sql += " AND birthdate IS NOT NULL AND TIMESTAMPDIFF(YEAR, birthdate, CURDATE()) BETWEEN @fAgeMin AND @fAgeMax";
                p.Add(new KeyValuePair<string, object>("@fAgeMin", min));
                p.Add(new KeyValuePair<string, object>("@fAgeMax", max));
            }
            return sql;
        }

        private void EditResident(int userId)
        {
            using (ResidentForm form = new ResidentForm(userId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadResidents(searchTB.Text.Trim());
                    MessageBox.Show("Resident details updated.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteResidents(System.Collections.Generic.List<int> ids)
        {
            if (ids.Count == 0)
            {
                MessageBox.Show("Tick at least one resident first.", "Nothing selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ResidentTools.DeleteResidents(this, ids))
            {
                LoadResidents(searchTB.Text.Trim());
                MessageBox.Show(ids.Count == 1 ? "Resident deleted." : $"{ids.Count} residents deleted.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private System.Collections.Generic.List<int> GetCheckedIds()
        {
            dgvResidents.EndEdit();
            var ids = new System.Collections.Generic.List<int>();
            foreach (DataGridViewRow row in dgvResidents.Rows)
            {
                if (row.Cells["colSelect"].Value is bool b && b) ids.Add(Convert.ToInt32(row.Cells["user_id"].Value));
            }
            return ids;
        }

        private void SetAllChecked(bool state)
        {
            dgvResidents.EndEdit();
            foreach (DataGridViewRow row in dgvResidents.Rows) row.Cells["colSelect"].Value = state;
        }

        private void BulkSetVoter(string status)
        {
            var ids = GetCheckedIds();
            if (ids.Count == 0)
            {
                MessageBox.Show("Tick at least one resident first.", "Nothing selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string label = status == "Yes" ? "registered voters" : "non-voters";
            if (MessageBox.Show($"Mark {ids.Count} resident(s) as {label}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            if (ResidentTools.SetVoterStatus(this, ids, status)) LoadResidents(searchTB.Text.Trim());
        }
    }
}
