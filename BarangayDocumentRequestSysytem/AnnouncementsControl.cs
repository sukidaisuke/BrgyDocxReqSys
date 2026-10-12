#nullable disable
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BarangayDocumentRequestSysytem
{
    public partial class AnnouncementsControl : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";
        private Panel pnlListContainer;

        public AnnouncementsControl()
        {
            InitializeComponent();
            SetupScrollContainer();
        }

        private void SetupScrollContainer()
        {
            // Hide fixed designer cards
            if (panelCard1 != null) panelCard1.Visible = false;
            if (panelCard2 != null) panelCard2.Visible = false;
            if (panelCard3 != null) panelCard3.Visible = false;

            // Create a dedicated scrollable panel inside panelAnnouncementsCard
            pnlListContainer = new Panel
            {
                Name = "pnlListContainer",
                Location = new Point(10, 48),
                Size = new Size(panelAnnouncementsCard.Width - 20, panelAnnouncementsCard.Height - 55),
                AutoScroll = true,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            panelAnnouncementsCard.Controls.Add(pnlListContainer);
            pnlListContainer.BringToFront();
        }

        private void AnnouncementsControl_Load(object sender, EventArgs e)
        {
            UpdateDashboard();
        }

        private void AnnouncementsControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                UpdateDashboard();
            }
        }

        public void UpdateDashboard()
        {
            lblDate.Text = "📅 " + DateTime.Now.ToString("MMMM d, yyyy | dddd");

            if (pnlListContainer == null) return;

            pnlListContainer.Controls.Clear();

            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Query ALL announcements from DB (no LIMIT)
                    string query = "SELECT announcement_id, title, category, content, DATE_FORMAT(date_posted, '%b %d, %Y • %h:%i %p') AS formatted_date FROM announcements ORDER BY announcement_id DESC";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }

                int totalCount = dt.Rows.Count;
                lblFooterCount.Text = $"Total Announcements: {totalCount}";

                if (totalCount == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "📢 No Announcements Yet\nThere are currently no official announcements published by the Barangay Office.",
                        Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                        ForeColor = Color.DimGray,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill
                    };
                    pnlListContainer.Controls.Add(lblEmpty);
                    return;
                }

                int cardWidth = pnlListContainer.Width - 25; // Leave space for scrollbar
                int yPos = 5;

                foreach (DataRow row in dt.Rows)
                {
                    Panel card = CreateAnnouncementCard(row, cardWidth);
                    card.Location = new Point(0, yPos);
                    pnlListContainer.Controls.Add(card);

                    yPos += card.Height + 10; // Spacing between cards
                }
            }
            catch (Exception ex)
            {
                Label lblError = new Label
                {
                    Text = "Database Error: " + ex.Message,
                    ForeColor = Color.Red,
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
                pnlListContainer.Controls.Add(lblError);
            }
        }

        private Panel CreateAnnouncementCard(DataRow row, int width)
        {
            string title = row["title"] != DBNull.Value ? row["title"].ToString() : "";
            string category = (row["category"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["category"].ToString()))
                ? row["category"].ToString()
                : "GENERAL NOTICE";
            string content = row["content"] != DBNull.Value ? row["content"].ToString() : "";
            string dateStr = row["formatted_date"] != DBNull.Value ? row["formatted_date"].ToString() : "";

            const int maxPreviewLength = 75;
            bool isLong = content.Length > maxPreviewLength;
            string previewText = isLong ? content.Substring(0, maxPreviewLength) + "..." : content;

            Panel card = new Panel
            {
                Size = new Size(width, 82),
                BackColor = Color.FromArgb(240, 247, 255), // Light blue card background
                BorderStyle = BorderStyle.None
            };

            // Icon
            Label lblIcon = new Label
            {
                Text = "📢",
                Font = new Font("Segoe UI", 14f),
                Location = new Point(8, 8),
                Size = new Size(30, 30),
                BackColor = Color.Transparent
            };

            // Category Badge (Auto-expanding)
            Label lblBadge = new Label
            {
                Text = category.ToUpper(),
                AutoSize = true,
                BackColor = Color.FromArgb(219, 234, 254),
                ForeColor = Color.FromArgb(30, 58, 138),
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                Padding = new Padding(6, 3, 6, 3),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblBadge);
            lblBadge.Location = new Point(width - lblBadge.PreferredWidth - 10, 6);

            // Title
            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                Location = new Point(42, 6),
                Size = new Size(width - lblBadge.PreferredWidth - 60, 20),
                AutoEllipsis = true
            };

            // Content Preview
            Label lblContent = new Label
            {
                Text = previewText,
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(42, 28),
                Size = new Size(width - 55, 30),
                AutoEllipsis = true
            };

            // Date
            Label lblDate = new Label
            {
                Text = dateStr,
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.DimGray,
                Location = new Point(42, 60),
                AutoSize = true
            };

            card.Controls.Add(lblIcon);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblContent);
            card.Controls.Add(lblDate);

            // Read More Button (opens scrollable modal)
            if (isLong)
            {
                Button btnReadMore = new Button
                {
                    Text = "Read More ↗",
                    Size = new Size(82, 20),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Transparent,
                    ForeColor = Color.DarkSlateBlue,
                    Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                    Cursor = Cursors.Hand,
                    Location = new Point(width - 90, 56)
                };
                btnReadMore.FlatAppearance.BorderSize = 0;
                btnReadMore.Tag = new AnnouncementData { Title = title, Category = category, Date = dateStr, Content = content };
                btnReadMore.Click += ReadMore_Click;
                card.Controls.Add(btnReadMore);
            }

            return card;
        }

        private void ReadMore_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is AnnouncementData data)
            {
                ShowAnnouncementModal(data.Title, data.Category, data.Date, data.Content);
            }
        }

        private void ShowAnnouncementModal(string title, string category, string datePosted, string fullContent)
        {
            using (Form modal = new Form())
            {
                modal.Text = "Barangay Announcement Details";
                modal.Size = new Size(520, 390);
                modal.StartPosition = FormStartPosition.CenterParent;
                modal.FormBorderStyle = FormBorderStyle.FixedDialog;
                modal.MaximizeBox = false;
                modal.MinimizeBox = false;
                modal.BackColor = Color.White;

                Label lblCat = new Label
                {
                    Text = category.ToUpper(),
                    AutoSize = true,
                    BackColor = Color.FromArgb(219, 234, 254),
                    ForeColor = Color.FromArgb(30, 58, 138),
                    Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                    Padding = new Padding(8, 4, 8, 4),
                    Location = new Point(22, 16)
                };

                Label lblTitle = new Label
                {
                    Text = title,
                    Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    Location = new Point(20, 48),
                    Size = new Size(460, 45),
                    AutoEllipsis = true
                };

                Label lblDate = new Label
                {
                    Text = "📅 Posted: " + datePosted,
                    Font = new Font("Segoe UI", 8.5f, FontStyle.Italic),
                    ForeColor = Color.DimGray,
                    Location = new Point(22, 95),
                    AutoSize = true
                };

                TextBox txtContent = new TextBox
                {
                    Text = fullContent,
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    Font = new Font("Segoe UI", 9.5f),
                    BackColor = Color.FromArgb(248, 250, 252),
                    ForeColor = Color.FromArgb(15, 23, 42),
                    Location = new Point(22, 122),
                    Size = new Size(460, 160),
                    BorderStyle = BorderStyle.FixedSingle
                };

                Button btnClose = new Button
                {
                    Text = "Close",
                    DialogResult = DialogResult.OK,
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    BackColor = Color.FromArgb(71, 85, 105),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(95, 32),
                    Location = new Point(387, 298),
                    Cursor = Cursors.Hand
                };
                btnClose.FlatAppearance.BorderSize = 0;

                modal.Controls.Add(lblCat);
                modal.Controls.Add(lblTitle);
                modal.Controls.Add(lblDate);
                modal.Controls.Add(txtContent);
                modal.Controls.Add(btnClose);
                modal.AcceptButton = btnClose;

                modal.ShowDialog(this);
            }
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            UpdateDashboard();
        }

        private class AnnouncementData
        {
            public string Title { get; set; }
            public string Category { get; set; }
            public string Date { get; set; }
            public string Content { get; set; }
        }
    }
}