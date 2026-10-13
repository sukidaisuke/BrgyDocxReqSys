#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>Small helpers so the code-built dialogs look consistent with the rest of the app.</summary>
    internal static class UiKit
    {
        public static readonly Color Brand = Color.FromArgb(48, 44, 105);
        public static readonly Color Danger = Color.FromArgb(220, 38, 38);
        public static readonly Color Muted = Color.FromArgb(241, 245, 249);
        public static readonly Color HeaderBlue = Color.FromArgb(186, 218, 231);

        public const string ConnectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;Convert Zero Datetime=True;";

        public static readonly string[] SexOptions = { "Male", "Female", "Other" };
        public static readonly string[] VoterOptions = { "Yes", "No" };
        public static readonly string[] PurokOptions = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public static readonly string[] SecurityQuestions =
        {
            "What is your favourite food?",
            "What was the name of your first pet?",
            "What is your mother's maiden name?",
            "What was the name of your elementary school?",
            "In what town or city were you born?",
            "What is the name of your best friend from childhood?"
        };

        public static Label Lbl(string text, int x, int y, int w = 130, bool bold = false)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y + 3),
                Size = new Size(w, 20),
                Font = new Font("Segoe UI", 9F, bold ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = Color.FromArgb(55, 65, 81),
                AutoEllipsis = true
            };
        }

        public static Button Btn(string text, int x, int y, int w, int h, Color back, Color fore)
        {
            Button b = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(w, h),
                BackColor = back,
                ForeColor = fore,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }

        public static ComboBox Combo(string[] items, int x, int y, int w, bool dropDownList = true)
        {
            ComboBox c = new ComboBox
            {
                Location = new Point(x, y),
                Width = w,
                DropDownStyle = dropDownList ? ComboBoxStyle.DropDownList : ComboBoxStyle.DropDown,
                Font = new Font("Segoe UI", 9F)
            };
            if (items != null) c.Items.AddRange(items);
            return c;
        }

        public static TextBox Text(int x, int y, int w, int maxLength = 100)
        {
            return new TextBox { Location = new Point(x, y), Width = w, MaxLength = maxLength, Font = new Font("Segoe UI", 9F) };
        }

        public static Form BaseDialog(string title, int w, int h)
        {
            return new Form
            {
                Text = title,
                ClientSize = new Size(w, h),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9F)
            };
        }

        public static void StyleGrid(DataGridView g)
        {
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersDefaultCellStyle.BackColor = HeaderBlue;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = HeaderBlue;
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            g.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.None;
            g.RowHeadersVisible = false;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>A tiny "type a value" dialog. Returns null when cancelled.</summary>
        public static string Prompt(IWin32Window owner, string title, string message, string initial = "", bool password = false, int maxLength = 100)
        {
            using (Form f = BaseDialog(title, 400, 150))
            {
                Label l = new Label { Text = message, Location = new Point(16, 14), Size = new Size(368, 36), AutoEllipsis = false };
                TextBox t = Text(16, 56, 368, maxLength);
                t.Text = initial ?? "";
                t.UseSystemPasswordChar = password;
                Button ok = Btn("OK", 214, 100, 80, 30, Brand, Color.White);
                Button cancel = Btn("Cancel", 304, 100, 80, 30, Muted, Color.FromArgb(71, 85, 105));
                ok.DialogResult = DialogResult.OK;
                cancel.DialogResult = DialogResult.Cancel;
                f.Controls.AddRange(new Control[] { l, t, ok, cancel });
                f.AcceptButton = ok;
                f.CancelButton = cancel;
                f.Shown += (s, e) => { t.Focus(); t.SelectAll(); };
                return f.ShowDialog(owner) == DialogResult.OK ? t.Text.Trim() : null;
            }
        }

        public static void Warn(IWin32Window owner, string message, string title = "Please check")
        {
            MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Info(IWin32Window owner, string message, string title = "Done")
        {
            MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(IWin32Window owner, string message, string title = "Database Error")
        {
            MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(IWin32Window owner, string message, string title = "Please confirm", MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            return MessageBox.Show(owner, message, title, MessageBoxButtons.YesNo, icon) == DialogResult.Yes;
        }
    }
}
