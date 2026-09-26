using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class Resident : UserControl
    {
        public Resident()
        {
            InitializeComponent();
        }

        private void AddResidentButton_Click(object sender, EventArgs e)
        {
            PanelContainer.Controls.Clear();

            AddResident addresidentContent = new AddResident(); // your dashboard UserControl
            addresidentContent.Dock = DockStyle.Fill;

            PanelContainer.Controls.Add(addresidentContent);
            PanelContainer.Visible = true;
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void NavPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBTN_Click(object sender, EventArgs e)
        {

        }

        private void PanelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
