#nullable disable
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class AnnouncementsControl : UserControl
    {
        private readonly string connectionString = "Server=localhost;Port=3306;Database=barangay_db;Uid=root;Pwd=;";

        public AnnouncementsControl()
        {
            InitializeComponent();
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
            List<Control> allControls = GetAllControls(this);

            // 1. Update Header Date to live current date
            string currentDate = DateTime.Now.ToString("MMMM d, yyyy | dddd");
            foreach (Control c in allControls)
            {
                if (c is Label lbl)
                {
                    if (lbl.Text.Contains("August") || lbl.Text.Contains("Saturday") || (lbl.Text.Contains("2026") && lbl.Text.Contains("|")))
                    {
                        lbl.Text = currentDate;
                    }
                }
            }

            // 2. Configure Card 1 (Top Card) as "No Announcements Yet"
            foreach (Control c in allControls)
            {
                if (c is Label lbl)
                {
                    if (lbl.Text.Contains("Schedule") || lbl.Text.Contains("Claiming"))
                    {
                        lbl.Text = "No Announcements Yet";
                    }
                    else if (lbl.Text.Contains("advised") || lbl.Text.Contains("8:00 AM"))
                    {
                        lbl.Text = "There are currently no official announcements published by the Barangay Office.";
                    }
                    else if (lbl.Text.Contains("July 17") || lbl.Text.Contains("7:33 AM"))
                    {
                        lbl.Text = "";
                    }
                }
            }

            // 3. Hide Card 2 and Card 3 completely (Labels, Icons, and Sub-Panels)
            foreach (Control c in allControls)
            {
                if (c is Label lbl)
                {
                    if (lbl.Text.Contains("Assembly") || lbl.Text.Contains("October 20") ||
                        lbl.Text.Contains("Maintenance") || lbl.Text.Contains("May 25") ||
                        lbl.Text.Contains("October 12") || lbl.Text.Contains("May 22"))
                    {
                        lbl.Text = "";
                        lbl.Visible = false;

                        // Hide the sub-panel container holding the card if applicable
                        if (lbl.Parent != null && lbl.Parent != this && lbl.Parent.Controls.Count <= 6)
                        {
                            lbl.Parent.Visible = false;
                        }
                    }
                }
            }

            // 4. Update Footer Text
            foreach (Control c in allControls)
            {
                if (c is Label lbl)
                {
                    if (lbl.Text.StartsWith("Showing") || lbl.Text.Contains("announcement") || lbl.Text.Contains("requests"))
                    {
                        lbl.Text = "Total Announcements: 0";
                    }
                }
            }
        }

        // Helper: Flattens the entire control tree (nested panels, table layouts, etc.)
        private List<Control> GetAllControls(Control container)
        {
            List<Control> controlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                controlList.Add(c);
                if (c.HasChildren)
                {
                    controlList.AddRange(GetAllControls(c));
                }
            }
            return controlList;
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            // Updates automatically every second
            lblDate.Text = DateHelper.CurrentHeaderDate;
        }
    }
}