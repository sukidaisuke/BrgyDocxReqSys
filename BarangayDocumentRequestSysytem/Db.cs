#nullable disable
using MySql.Data.MySqlClient;
using System;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// Shared database helpers. EnsureSchema() creates the tables that were added after the
    /// original database (so no manual SQL import is needed) and is safe to call repeatedly.
    /// </summary>
    public static class Db
    {
        public const string ConnectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        // The only positions that can sign a document.
        public static readonly string[] SignatoryPositions =
        {
            "Barangay Captain", "Barangay Secretary", "Barangay Treasurer"
        };

        private static bool schemaChecked = false;

        public static void EnsureSchema(MySqlConnection conn)
        {
            if (schemaChecked) return;

            // One row per uploaded requirement (a request can have several files).
            Exec(conn, @"CREATE TABLE IF NOT EXISTS request_attachments (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            request_id INT NOT NULL,
                            requirement_name VARCHAR(255) NULL,
                            file_name VARCHAR(255) NULL,
                            file_data LONGBLOB NULL,
                            uploaded_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                            INDEX idx_request (request_id)
                         )");

            // Admin-editable document templates (one per document type).
            Exec(conn, @"CREATE TABLE IF NOT EXISTS document_templates (
                            doc_type VARCHAR(150) NOT NULL PRIMARY KEY,
                            body TEXT NOT NULL,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                         )");

            // Documents can now contain formatting and pictures (RTF), which is larger than plain text
            TryExec(conn, "ALTER TABLE document_templates MODIFY body LONGTEXT NOT NULL");
            TryExec(conn, "ALTER TABLE issued_documents MODIFY content LONGTEXT");

            schemaChecked = true;
        }

        private static void TryExec(MySqlConnection conn, string sql)
        {
            try { Exec(conn, sql); } catch { /* column already large enough / table missing */ }
        }

        // Raised whenever a request changes status so the sidebar badges can refresh right away
        public static event Action RequestsChanged;
        public static void RaiseRequestsChanged() { RequestsChanged?.Invoke(); }

        private static void Exec(MySqlConnection conn, string sql)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                cmd.ExecuteNonQuery();
        }
    }
}
