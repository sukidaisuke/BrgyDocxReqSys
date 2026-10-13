#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>Admin-side actions on residents that don't need a screen of their own.</summary>
    internal static class ResidentTools
    {
        /// <summary>How many document requests do these residents have in total?</summary>
        public static long CountRequests(MySqlConnection conn, IList<int> userIds)
        {
            if (userIds.Count == 0) return 0;
            using (MySqlCommand cmd = new MySqlCommand(
                $"SELECT COUNT(*) FROM documentrequests WHERE user_id IN ({IdList(userIds)})", conn))
            {
                return Convert.ToInt64(cmd.ExecuteScalar());
            }
        }

        // Ids are ints we parsed ourselves, so they are safe to inline.
        private static string IdList(IList<int> ids)
        {
            return string.Join(",", ids.Select(i => i.ToString(System.Globalization.CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Deletes residents. Their document requests (and attachments / drafts) are removed with them,
        /// so nothing is left pointing at a missing resident. Everything happens in one transaction.
        /// </summary>
        public static bool DeleteResidents(IWin32Window owner, IList<int> userIds)
        {
            if (userIds == null || userIds.Count == 0) return false;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    long requestCount = CountRequests(conn, userIds);

                    string who = userIds.Count == 1 ? "this resident" : $"these {userIds.Count} residents";
                    string message = requestCount == 0
                        ? $"Delete {who}? This cannot be undone."
                        : $"Delete {who}?\n\nThey have {requestCount} document request(s). Deleting them also permanently removes those requests, their uploaded files and drafts.\n\nThis cannot be undone.";

                    if (!UiKit.Confirm(owner, message, "Confirm Deletion", MessageBoxIcon.Warning)) return false;

                    using (MySqlTransaction tx = conn.BeginTransaction())
                    {
                        try
                        {
                            string ids = IdList(userIds);
                            string[] statements =
                            {
                                $"DELETE a FROM request_attachments a JOIN documentrequests r ON r.request_id = a.request_id WHERE r.user_id IN ({ids})",
                                $"DELETE d FROM issued_documents d JOIN documentrequests r ON r.request_id = d.request_id WHERE r.user_id IN ({ids})",
                                $"DELETE FROM documentrequests WHERE user_id IN ({ids})",
                                $"DELETE FROM info_update_requests WHERE user_id IN ({ids})",
                                $"DELETE FROM users WHERE user_id IN ({ids}) AND (role IS NULL OR LOWER(role) <> 'admin')"
                            };
                            foreach (string sql in statements)
                                using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
                                    cmd.ExecuteNonQuery();

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                Db.RaiseRequestsChanged();
                return true;
            }
            catch (Exception ex)
            {
                UiKit.Error(owner, "Failed to delete: " + ex.Message);
                return false;
            }
        }

        /// <summary>Sets the voter status for several residents at once.</summary>
        public static bool SetVoterStatus(IWin32Window owner, IList<int> userIds, string status)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        $"UPDATE users SET voter_status = @s WHERE user_id IN ({IdList(userIds)}) AND (role IS NULL OR LOWER(role) <> 'admin')", conn))
                    {
                        cmd.Parameters.AddWithValue("@s", status);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                UiKit.Error(owner, "Failed to update voter status: " + ex.Message);
                return false;
            }
        }

        /// <summary>Admin sets a new (temporary) password for a resident who is locked out.</summary>
        public static void ResetPassword(IWin32Window owner, int userId, string residentName)
        {
            string pw = UiKit.Prompt(owner, "Reset Password", $"Enter a new temporary password for {residentName} (at least 6 characters).", "", true, 50);
            if (pw == null) return;
            if (pw.Length < 6) { UiKit.Warn(owner, "The password must be at least 6 characters."); return; }

            string confirm = UiKit.Prompt(owner, "Reset Password", "Type the new password again to confirm.", "", true, 50);
            if (confirm == null) return;
            if (confirm != pw) { UiKit.Warn(owner, "The two passwords do not match."); return; }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "UPDATE users SET password = @p WHERE user_id = @id AND (role IS NULL OR LOWER(role) <> 'admin')", conn))
                    {
                        cmd.Parameters.AddWithValue("@p", BCrypt.Net.BCrypt.HashPassword(pw));
                        cmd.Parameters.AddWithValue("@id", userId);
                        if (cmd.ExecuteNonQuery() == 1)
                            UiKit.Info(owner, $"Password updated. Tell {residentName} to sign in with the new password and change it from their Profile.");
                        else
                            UiKit.Warn(owner, "That resident could not be found.");
                    }
                }
            }
            catch (Exception ex)
            {
                UiKit.Error(owner, "Failed to reset password: " + ex.Message);
            }
        }

        /// <summary>Saves the rows currently shown in the resident list to a CSV file that Excel can open.</summary>
        public static void ExportCsv(IWin32Window owner, DataTable table)
        {
            if (table == null || table.Rows.Count == 0)
            {
                UiKit.Warn(owner, "There are no residents to export.", "Nothing to export");
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV file (*.csv)|*.csv";
                dlg.FileName = $"Residents_{DateTime.Now:yyyyMMdd_HHmm}.csv";
                if (dlg.ShowDialog(owner) != DialogResult.OK) return;

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Resident ID,Full Name,Sex,Birthdate,Age,Contact Number,House No.,Purok,Years of Residency,Voter");

                    foreach (DataRow r in table.Rows)
                    {
                        string birth = "", age = "";
                        if (r["birthdate"] != DBNull.Value)
                        {
                            DateTime b = Convert.ToDateTime(r["birthdate"]);
                            birth = b.ToString("yyyy-MM-dd");
                            int a = DateTime.Today.Year - b.Year;
                            if (b.Date > DateTime.Today.AddYears(-a)) a--;
                            age = a.ToString();
                        }

                        sb.AppendLine(string.Join(",", new[]
                        {
                            Csv(r["formatted_id"]), Csv(r["full_name"]), Csv(r["sex"]), Csv(birth), Csv(age),
                            Csv(r["contact_no"]), Csv(r["house_no"]), Csv(r["purok_no"]),
                            Csv(r["years_of_residency"]), Csv(r["voter_status"])
                        }));
                    }

                    File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(true));
                    UiKit.Info(owner, $"Exported {table.Rows.Count} resident(s) to:\n{dlg.FileName}", "Export complete");
                }
                catch (Exception ex)
                {
                    UiKit.Error(owner, "Could not save the file: " + ex.Message, "Export failed");
                }
            }
        }

        private static string Csv(object value)
        {
            string s = value == null || value == DBNull.Value ? "" : value.ToString();
            // Stop spreadsheet programs from running text that looks like a formula
            if (s.Length > 0 && "=+-@".IndexOf(s[0]) >= 0 && !decimal.TryParse(s, out _)) s = "'" + s;
            if (s.IndexOfAny(new[] { ',', '"', '\r', '\n' }) >= 0) s = "\"" + s.Replace("\"", "\"\"") + "\"";
            return s;
        }
    }

    /// <summary>Read-only list of one resident's document requests.</summary>
    internal class ResidentRequestsForm : Form
    {
        public ResidentRequestsForm(int userId, string residentName)
        {
            Text = $"Request History – {residentName}";
            ClientSize = new Size(700, 380);
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            MinimizeBox = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            DataGridView grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true };
            UiKit.StyleGrid(grid);
            Label footer = new Label { Dock = DockStyle.Bottom, Height = 28, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(8, 0, 0, 0), ForeColor = Color.DimGray };
            Controls.Add(grid);
            Controls.Add(footer);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    using (MySqlDataAdapter ad = new MySqlDataAdapter(
                        @"SELECT reference_no AS `Reference`, document_type AS `Document`, purpose AS `Purpose`,
                                 DATE_FORMAT(request_at, '%b %d, %Y') AS `Requested`, status AS `Status`
                          FROM documentrequests WHERE user_id = @id ORDER BY request_at DESC, request_id DESC", conn))
                    {
                        ad.SelectCommand.Parameters.AddWithValue("@id", userId);
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        grid.DataSource = dt;
                        footer.Text = dt.Rows.Count == 0 ? "This resident has not made any requests yet." : $"Total requests: {dt.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not load the request history: " + ex.Message);
            }
        }
    }
}
