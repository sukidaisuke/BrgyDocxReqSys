#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class AdminControl : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public AdminControl()
        {
            InitializeComponent();

            this.Load += AdminControl_Load;
            this.VisibleChanged += AdminControl_VisibleChanged;
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                RefreshDashboardData();
            }
        }

        private void AdminControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !this.DesignMode)
            {
                RefreshDashboardData();
            }
        }

        public void RefreshDashboardData()
        {
            UpdateHeaderDate();
            FetchAdminMetrics();
            FetchRecentRequests();
        }

        private void UpdateHeaderDate()
        {
            SetLabelText(DateHelper.CurrentHeaderDate, "lblHeaderDate", "lblDate", "lblAdminDate");
        }

        // --- 1. Fetch Real Summary Counters from Database ---
        private void FetchAdminMetrics()
        {
            int totalResidents = GetDatabaseCount("SELECT COUNT(*) FROM users WHERE LOWER(role) = 'user' OR role IS NULL OR role = ''");
            int pendingRequests = GetDatabaseCount("SELECT COUNT(*) FROM documentrequests WHERE LOWER(status) = 'pending'");
            int completedRequests = GetDatabaseCount("SELECT COUNT(*) FROM documentrequests WHERE LOWER(status) IN ('approved', 'completed', 'processed', 'ready for pickup')");
            int totalAnnouncements = GetDatabaseCount("SELECT COUNT(*) FROM announcements");

            SetLabelText(totalResidents.ToString(), "lblResidentsCount", "lblResidents", "lblTotalResidents");
            SetLabelText(pendingRequests.ToString(), "lblPendingCount", "lblPending", "lblPendingRequests");
            SetLabelText(completedRequests.ToString(), "lblCompletedCount", "lblIssuedCount", "lblIssued", "lblCompleted");
            SetLabelText(totalAnnouncements.ToString(), "lblAnnounceCount", "lblNoticesCount", "lblNotices", "lblAnnouncements");
        }

        private int GetDatabaseCount(string query)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Displays connection or query errors explicitly if MySQL fails
                Console.WriteLine($"Database Count Error: {ex.Message}");
                return 0;
            }
        }

        // --- 2. Fetch Recent Document Requests ---
        private void FetchRecentRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            r.document_type, 
                            r.request_at, 
                            r.status, 
                            COALESCE(NULLIF(TRIM(CONCAT(u.first_name, ' ', u.last_name)), ''), r.username, 'Resident') AS resident_name
                        FROM documentrequests r 
                        LEFT JOIN users u ON r.user_id = u.user_id 
                        ORDER BY r.request_at DESC 
                        LIMIT 3";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int index = 1;
                            while (reader.Read() && index <= 3)
                            {
                                string docType = reader["document_type"]?.ToString() ?? "Document Request";
                                string resident = reader["resident_name"]?.ToString() ?? "Resident";
                                string status = reader["status"]?.ToString() ?? "Pending";
                                string dateStr = "";

                                if (reader["request_at"] != DBNull.Value)
                                {
                                    dateStr = Convert.ToDateTime(reader["request_at"]).ToString("MMM dd, yyyy");
                                }

                                SetRowData(index, docType, $"{resident} • {dateStr}", status);
                                index++;
                            }

                            // Clear remaining rows if DB has fewer than 3 records
                            for (int i = index; i <= 3; i++)
                            {
                                SetRowData(i, "", "", "");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database Connection Error: {ex.Message}\n\nCheck if MySQL service is running and database 'barangay_db' exists.",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // --- 3. Robust Label Location & Data Assignment ---
        private void SetRowData(int rowIndex, string title, string sub, string status)
        {
            // Title mapping (Fallback search checks for default designer text if control names differ)
            Label lblTitle = FindLabelByNamesOrPlaceholder($"lblReq{rowIndex}Title", $"lblTitle{rowIndex}",
                rowIndex == 1 ? "Barangay Clearance" : rowIndex == 2 ? "Indigency Certificate" : "Residency Certificate");
            if (lblTitle != null) lblTitle.Text = title;

            // Subtitle mapping
            Label lblSub = FindLabelByNamesOrPlaceholder($"lblReq{rowIndex}Sub", $"lblReq{rowIndex}Date",
                rowIndex == 1 ? "Juan Dela Cruz" : rowIndex == 2 ? "Maria Clara" : "Jose Rizal");
            if (lblSub != null) lblSub.Text = sub;

            // Badge mapping
            UpdateStatusBadge(rowIndex, status);
        }

        private void SetLabelText(string text, params string[] possibleNames)
        {
            foreach (string name in possibleNames)
            {
                Label lbl = FindChildControl<Label>(this, name);
                if (lbl != null)
                {
                    lbl.Text = text ?? "";
                    return;
                }
            }
        }

        private Label FindLabelByNamesOrPlaceholder(string primaryName, string secondaryName, string placeholderText)
        {
            Label lbl = FindChildControl<Label>(this, primaryName) ?? FindChildControl<Label>(this, secondaryName);
            if (lbl != null) return lbl;

            // Fallback: locate by matching current designer text
            List<Label> allLabels = new List<Label>();
            GetAllControlsOfType(this, allLabels);
            foreach (Label l in allLabels)
            {
                if (l.Text.Contains(placeholderText))
                {
                    return l;
                }
            }

            return null;
        }

        private void UpdateStatusBadge(int rowIndex, string status)
        {
            Label lbl = FindChildControl<Label>(this, $"lblReq{rowIndex}Status")
                     ?? FindChildControl<Label>(this, $"lblStatus{rowIndex}");

            if (lbl == null)
            {
                // Fallback search for status badges by matching initial designer text
                List<Label> allLabels = new List<Label>();
                GetAllControlsOfType(this, allLabels);
                int count = 1;
                foreach (Label l in allLabels)
                {
                    if (l.Text.Equals("Pending", StringComparison.OrdinalIgnoreCase) ||
                        l.Text.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                    {
                        if (count == rowIndex)
                        {
                            lbl = l;
                            break;
                        }
                        count++;
                    }
                }
            }

            if (lbl == null) return;

            if (string.IsNullOrWhiteSpace(status))
            {
                lbl.Text = "";
                lbl.Visible = false;
                return;
            }

            lbl.Visible = true;
            lbl.Text = status;

            // Reset card background to keep the row panel white/light gray
            if (lbl.Parent is Panel parentPanel && parentPanel.Width > 150)
            {
                parentPanel.BackColor = Color.FromArgb(249, 250, 251); // Light gray card background
            }

            string normalizedStatus = status.Trim().ToLower();
            Color backColor;
            Color textColor;

            switch (normalizedStatus)
            {
                case "completed":
                case "approved":
                case "processed":
                case "ready for pickup":
                    backColor = Color.FromArgb(220, 252, 231); // Soft Green
                    textColor = Color.FromArgb(22, 101, 52);   // Dark Green
                    break;

                case "pending":
                case "for review":
                case "in progress":
                    backColor = Color.FromArgb(254, 249, 195); // Soft Yellow
                    textColor = Color.FromArgb(133, 77, 14);   // Dark Amber
                    break;

                case "failed":
                case "rejected":
                case "disapproved":
                case "cancelled":
                    backColor = Color.FromArgb(254, 226, 226); // Soft Red
                    textColor = Color.FromArgb(153, 27, 27);   // Dark Red
                    break;

                default:
                    backColor = Color.FromArgb(243, 244, 246);
                    textColor = Color.FromArgb(75, 85, 99);
                    break;
            }

            // Apply colors ONLY to the status label badge itself
            lbl.BackColor = backColor;
            lbl.ForeColor = textColor;
        }

        private T FindChildControl<T>(Control parent, string name) where T : Control
        {
            foreach (Control c in parent.Controls)
            {
                if (c is T match && string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return match;
                }

                if (c.HasChildren)
                {
                    T childMatch = FindChildControl<T>(c, name);
                    if (childMatch != null) return childMatch;
                }
            }
            return null;
        }

        private void GetAllControlsOfType<T>(Control parent, List<T> resultList) where T : Control
        {
            foreach (Control c in parent.Controls)
            {
                if (c is T match)
                {
                    resultList.Add(match);
                }

                if (c.HasChildren)
                {
                    GetAllControlsOfType<T>(c, resultList);
                }
            }
        }
    }
}