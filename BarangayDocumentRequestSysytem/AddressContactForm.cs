#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// Lets a resident change their own contact number, purok and house number straight away.
    /// (Name, sex and birthdate still go through the admin-approved "Request Information Update".)
    /// </summary>
    internal class AddressContactForm : Form
    {
        private readonly TextBox txtContact, txtHouse;
        private readonly ComboBox cmbPurok;

        public AddressContactForm()
        {
            Text = "Update Address & Contact";
            ClientSize = new Size(420, 250);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false; ShowInTaskbar = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            Panel header = new Panel { Dock = DockStyle.Top, Height = 44, BackColor = UiKit.Brand };
            header.Controls.Add(new Label { Text = "📍  Update Address & Contact", ForeColor = Color.White, Font = new Font("Segoe UI", 11F, FontStyle.Bold), Location = new Point(14, 11), AutoSize = true });
            Controls.Add(header);

            int y = 62;
            Controls.Add(UiKit.Lbl("Contact number", 16, y, 120));
            txtContact = UiKit.Text(140, y, 250, 20);
            Controls.Add(txtContact);
            y += 36;

            Controls.Add(UiKit.Lbl("Purok", 16, y, 120));
            cmbPurok = UiKit.Combo(UiKit.PurokOptions, 140, y, 90);
            Controls.Add(cmbPurok);
            y += 36;

            Controls.Add(UiKit.Lbl("House no.", 16, y, 120));
            txtHouse = UiKit.Text(140, y, 250, 20);
            Controls.Add(txtHouse);
            y += 44;

            Button save = UiKit.Btn("💾 Save", 200, y, 100, 32, UiKit.Brand, Color.White);
            Button cancel = UiKit.Btn("Cancel", 310, y, 90, 32, UiKit.Muted, Color.FromArgb(71, 85, 105));
            save.Click += (s, e) => Save();
            cancel.Click += (s, e) => Close();
            Controls.Add(save);
            Controls.Add(cancel);
            AcceptButton = save;
            CancelButton = cancel;

            Load += (s, e) => LoadCurrent();
        }

        private void LoadCurrent()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT contact_no, purok_no, house_no FROM users WHERE user_id = @u", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", UserSession.UserId);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            if (!r.Read()) return;
                            txtContact.Text = r["contact_no"]?.ToString();
                            txtHouse.Text = r["house_no"]?.ToString();

                            string purok = r["purok_no"]?.ToString()?.Trim();
                            if (!string.IsNullOrEmpty(purok))
                            {
                                int idx = cmbPurok.FindStringExact(purok);
                                if (idx < 0) idx = cmbPurok.Items.Add(purok);
                                cmbPurok.SelectedIndex = idx;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not load your details: " + ex.Message);
            }
        }

        private void Save()
        {
            string contact = txtContact.Text.Trim();
            if (contact.Length > 0 && !Regex.IsMatch(contact, @"^[0-9+\-\s]{7,20}$"))
            {
                UiKit.Warn(this, "Your contact number should only contain digits (7 to 20 characters).");
                txtContact.Focus();
                return;
            }
            if (cmbPurok.SelectedIndex < 0)
            {
                UiKit.Warn(this, "Please choose your purok.");
                cmbPurok.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(UiKit.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "UPDATE users SET contact_no = @c, purok_no = @p, house_no = @h WHERE user_id = @u", conn))
                    {
                        cmd.Parameters.AddWithValue("@c", contact);
                        cmd.Parameters.AddWithValue("@p", cmbPurok.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@h", txtHouse.Text.Trim());
                        cmd.Parameters.AddWithValue("@u", UserSession.UserId);
                        cmd.ExecuteNonQuery();
                    }
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                UiKit.Error(this, "Could not save your details: " + ex.Message);
            }
        }
    }
}
