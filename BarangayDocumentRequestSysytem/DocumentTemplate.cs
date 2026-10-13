#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public class BarangayDetails
    {
        public string Name = "";
        public string Municipality = "";
        public string Province = "";
        public string Address = "";
    }

    /// <summary>
    /// Builds the editable body text of a barangay document from the
    /// resident's saved information and stores the first draft in the database.
    /// </summary>
    public static class DocumentTemplate
    {
        public static BarangayDetails GetBarangay(MySqlConnection conn)
        {
            BarangayDetails b = new BarangayDetails();
            using (MySqlCommand cmd = new MySqlCommand(
                "SELECT barangay_name, municipality, province, office_address FROM barangay_info WHERE id = 1 LIMIT 1", conn))
            using (MySqlDataReader r = cmd.ExecuteReader())
            {
                if (r.Read())
                {
                    b.Name = r["barangay_name"].ToString();
                    b.Municipality = r["municipality"].ToString();
                    b.Province = r["province"].ToString();
                    b.Address = r["office_address"].ToString();
                }
            }
            return b;
        }

        /// <summary>Reads the resident's profile and builds the first draft (as a formatted RTF document).</summary>
        public static string BuildDraft(MySqlConnection conn, int userId, string docType, string purpose)
        {
            string fullName = "[RESIDENT NAME]";
            string age = "[AGE]";
            string houseNo = "";
            string purokNo = "";
            int years = 0;

            using (MySqlCommand cmd = new MySqlCommand(
                @"SELECT first_name, middle_name, last_name, birthdate, house_no, purok_no, years_of_residency
                  FROM users WHERE user_id = @id LIMIT 1", conn))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        string f = r["first_name"].ToString().Trim();
                        string m = r["middle_name"].ToString().Trim();
                        string l = r["last_name"].ToString().Trim();
                        fullName = (f + " " + (m.Length > 0 ? m + " " : "") + l).Trim();

                        if (r["birthdate"] != DBNull.Value)
                        {
                            DateTime bd = Convert.ToDateTime(r["birthdate"]);
                            int a = DateTime.Today.Year - bd.Year;
                            if (bd.Date > DateTime.Today.AddYears(-a)) a--;
                            age = a.ToString();
                        }

                        houseNo = r["house_no"].ToString().Trim();
                        purokNo = r["purok_no"].ToString().Trim();
                        int.TryParse(r["years_of_residency"].ToString(), out years);
                    }
                }
            }

            BarangayDetails b = GetBarangay(conn);

            string address = (houseNo.Length > 0 ? "House No. " + houseNo + ", " : "")
                           + (purokNo.Length > 0 ? "Purok " + purokNo + ", " : "")
                           + "Barangay " + b.Name + ", " + b.Municipality + ", " + b.Province;

            return RenderRtf(GetTemplateRtf(conn, docType),
                             BuildValues(docType, fullName, age, address, b, years, purpose, DateTime.Now));
        }

        /// <summary>Creates the first draft and stores it in issued_documents.</summary>
        public static void SaveDraft(MySqlConnection conn, int requestId, int userId, string docType, string purpose)
        {
            Db.EnsureSchema(conn);
            string content = BuildDraft(conn, userId, docType, purpose);

            using (MySqlCommand cmd = new MySqlCommand(
                @"INSERT INTO issued_documents (request_id, document_type, content)
                  VALUES (@rid, @type, @content)
                  ON DUPLICATE KEY UPDATE document_type = VALUES(document_type)", conn))
            {
                cmd.Parameters.AddWithValue("@rid", requestId);
                cmd.Parameters.AddWithValue("@type", docType);
                cmd.Parameters.AddWithValue("@content", content);
                cmd.ExecuteNonQuery();
            }
        }

        // ---------------------------------------------------------------
        // Templates
        // A template is a whole page (letterhead, title, wording, signature) written like a Word
        // document and stored as RTF. {PLACEHOLDERS} are filled in automatically.
        // Admins edit it in Settings > Templates; until they do, the built-in default is used.
        // ---------------------------------------------------------------

        /// <summary>(label shown to the admin, placeholder)</summary>
        public static readonly string[][] FieldMenu =
        {
            new[] { "Resident's name", "{NAME}" },
            new[] { "Resident's age", "{AGE}" },
            new[] { "Resident's address", "{ADDRESS}" },
            new[] { "Years of residency", "{YEARS}" },
            new[] { "Purpose of request", "{PURPOSE}" },
            new[] { "Barangay name", "{BARANGAY_NAME}" },
            new[] { "Municipality / City", "{MUNICIPALITY}" },
            new[] { "Province", "{PROVINCE}" },
            new[] { "Barangay, Municipality, Province", "{BARANGAY}" },
            new[] { "Document title", "{DOCUMENT_TITLE}" },
            new[] { "Day (e.g. 5th)", "{DAY}" },
            new[] { "Month and year", "{MONTH_YEAR}" },
            new[] { "Signing official's name", "{SIGNATORY_NAME}" },
            new[] { "Signing official's position", "{SIGNATORY_POSITION}" },
            new[] { "Reference number", "{REF_NO}" }
        };

        public static bool IsRtf(string text)
        {
            return text != null && text.TrimStart().StartsWith("{\\rtf", StringComparison.Ordinal);
        }

        /// <summary>Plain-text wording (with placeholders) of the main paragraphs of a document type.</summary>
        public static string GetDefaultTemplate(string docType)
        {
            string t = (docType ?? "").ToLower();
            string main;

            if (t.Contains("indigency"))
            {
                main = "This is to certify that {NAME}, {AGE} years old, residing at {ADDRESS}, " +
                       "belongs to an indigent family in this barangay and has no sufficient source of income.";
            }
            else if (t.Contains("residency"))
            {
                main = "This is to certify that {NAME}, {AGE} years old, residing at {ADDRESS}, {STAY}.";
            }
            else if (t.Contains("good moral"))
            {
                main = "This is to certify that {NAME}, {AGE} years old, residing at {ADDRESS}, " +
                       "is known to this office as a person of good moral character and a law-abiding citizen.";
            }
            else if (t.Contains("no pending"))
            {
                main = "This is to certify that {NAME}, {AGE} years old, residing at {ADDRESS}, " +
                       "has no pending case on record in the Office of the Punong Barangay and the Lupon Tagapamayapa as of this date.";
            }
            else if (t.Contains("business"))
            {
                main = "This is to certify that {NAME}, {AGE} years old, residing at {ADDRESS}, " +
                       "is endorsed for the issuance of a Business Permit for the business named [BUSINESS NAME] " +
                       "located at [BUSINESS ADDRESS]. This office has no objection to its operation in this barangay.";
            }
            else if (t.Contains("barangay id"))
            {
                main = "This is to confirm the application for a Barangay Identification Card of {NAME}, " +
                       "{AGE} years old, residing at {ADDRESS}, a registered resident of this barangay.";
            }
            else if (t.Contains("clearance"))
            {
                main = "This is to certify that {NAME}, {AGE} years old, residing at {ADDRESS}, " +
                       "is a bonafide resident of this barangay and has no derogatory record on file in this office as of this date.";
            }
            else
            {
                main = "This is to certify that {NAME}, {AGE} years old, residing at {ADDRESS}, " +
                       "is a bonafide resident of this barangay.";
            }

            return "TO WHOM IT MAY CONCERN:\n\n" +
                   main + "\n\n" +
                   "This document is issued upon the request of the above-named person for the purpose of: {PURPOSE}.\n\n" +
                   "Issued this {DAY} day of {MONTH_YEAR} at {BARANGAY}.";
        }

        // Escapes plain text for use inside RTF (braces in {PLACEHOLDERS} are escaped too)
        private static string RtfEscape(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s ?? "")
            {
                if (c == '\\' || c == '{' || c == '}') sb.Append('\\').Append(c);
                else if (c > 127) sb.Append("\\u").Append((int)(short)c).Append('?');
                else sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>The built-in full-page layout (letterhead, title, wording, signature) as RTF.</summary>
        public static string GetDefaultTemplateRtf(string docType)
        {
            StringBuilder r = new StringBuilder();
            r.Append("{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\froman Times New Roman;}}\\f0\\fs24 ");

            // Letterhead
            r.Append("\\pard\\qc Republic of the Philippines\\par ");
            r.Append("Province of ").Append(RtfEscape("{PROVINCE}")).Append("\\par ");
            r.Append(RtfEscape("{MUNICIPALITY}")).Append("\\par ");
            r.Append("\\b\\fs26 BARANGAY ").Append(RtfEscape("{BARANGAY_NAME}")).Append("\\par ");
            r.Append("OFFICE OF THE PUNONG BARANGAY\\b0\\fs24\\par ");
            r.Append("\\pard\\qc ________________________________________________\\par\\par ");

            // Title
            r.Append("\\pard\\qc\\b\\ul\\fs36 ").Append(RtfEscape("{DOCUMENT_TITLE}")).Append("\\ulnone\\b0\\fs24\\par\\par\\par ");

            // Wording
            string[] lines = GetDefaultTemplate(docType).Split('\n');
            foreach (string line in lines)
            {
                if (line.Length == 0) { r.Append("\\par "); continue; }
                bool indent = !line.StartsWith("TO WHOM");
                r.Append(indent ? "\\pard\\qj\\fi720 " : "\\pard\\ql ").Append(RtfEscape(line)).Append("\\par ");
            }

            // Signature
            r.Append("\\pard\\par\\par\\par\\par ");
            r.Append("\\pard\\qr\\b ").Append(RtfEscape("{SIGNATORY_NAME}")).Append("\\b0\\par ");
            r.Append("\\pard\\qr ").Append(RtfEscape("{SIGNATORY_POSITION}")).Append("\\par ");

            // Footer
            r.Append("\\pard\\par\\par\\pard\\ql\\i\\fs18 Ref. No.: ").Append(RtfEscape("{REF_NO}")).Append("\\par ");
            r.Append("Not valid without official dry seal.\\i0\\par ");
            r.Append("}");
            return r.ToString();
        }

        /// <summary>The admin's saved template for this document type, or the built-in layout if none was saved.</summary>
        public static string GetTemplateRtf(MySqlConnection conn, string docType)
        {
            try
            {
                Db.EnsureSchema(conn);
                using (MySqlCommand cmd = new MySqlCommand("SELECT body FROM document_templates WHERE doc_type = @t LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@t", docType ?? "");
                    object o = cmd.ExecuteScalar();
                    if (o != null && o != DBNull.Value && IsRtf(o.ToString()))
                        return o.ToString();
                }
            }
            catch { /* fall back to the default layout */ }

            return GetDefaultTemplateRtf(docType);
        }

        /// <summary>Values for the {PLACEHOLDERS} that are known when the request is made.</summary>
        public static Dictionary<string, string> BuildValues(string docType, string fullName, string age, string address,
                                                             BarangayDetails b, int years, string purpose, DateTime date)
        {
            string stay = years > 0
                ? "has been a resident of this barangay for " + years + " year(s)"
                : "is a bonafide resident of this barangay";

            return new Dictionary<string, string>
            {
                { "{NAME}", (fullName ?? "").ToUpper() },
                { "{AGE}", age },
                { "{ADDRESS}", address },
                { "{PURPOSE}", string.IsNullOrWhiteSpace(purpose) ? "[PURPOSE]" : purpose.Trim() },
                { "{STAY}", stay },
                { "{YEARS}", years.ToString() },
                { "{BARANGAY_NAME}", (b.Name ?? "").ToUpper() },
                { "{MUNICIPALITY}", b.Municipality },
                { "{PROVINCE}", b.Province },
                { "{BARANGAY}", "Barangay " + b.Name + ", " + b.Municipality + ", " + b.Province },
                { "{DOCUMENT_TITLE}", (docType ?? "").ToUpper() },
                { "{DAY}", date.Day + GetOrdinalSuffix(date.Day) },
                { "{MONTH_YEAR}", date.ToString("MMMM, yyyy") }
            };
        }

        /// <summary>Replaces placeholders inside a RichTextBox, keeping the formatting around them.</summary>
        public static void ReplaceTokens(RichTextBox rtb, IDictionary<string, string> values)
        {
            foreach (KeyValuePair<string, string> kv in values)
            {
                int start = 0;
                int idx;
                while ((idx = rtb.Find(kv.Key, start, RichTextBoxFinds.MatchCase)) >= 0)
                {
                    rtb.Select(idx, kv.Key.Length);
                    rtb.SelectedText = kv.Value ?? "";
                    start = idx + (kv.Value ?? "").Length;
                }
            }
            rtb.Select(0, 0);
        }

        /// <summary>Fills the placeholders of an RTF document and returns the new RTF.</summary>
        public static string RenderRtf(string rtf, IDictionary<string, string> values)
        {
            using (RichTextBox rtb = new RichTextBox())
            {
                rtb.Rtf = rtf;
                ReplaceTokens(rtb, values);
                return rtb.Rtf;
            }
        }

        public static string GetOrdinalSuffix(int day)
        {
            if (day >= 11 && day <= 13) return "th";
            switch (day % 10)
            {
                case 1: return "st";
                case 2: return "nd";
                case 3: return "rd";
                default: return "th";
            }
        }
    }
}
