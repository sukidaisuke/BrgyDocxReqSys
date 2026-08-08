using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    public partial class RequestDocumentControl : UserControl
    {
        public RequestDocumentControl()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPurpose_TextChanged(object sender, EventArgs e)
        {
            lblPurposeCount.Text = $"{txtPurpose.Text.Length}/300";

        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string requirements = "";
            bool needsAttachment = true;

            bool isOthers = cmbDocumentType.SelectedItem?.ToString() == "Others: (Please specify on the field below)";

            txtOtherDocType.Enabled = isOthers;
            txtOtherDocType.BackColor = isOthers ? Color.White : Color.FromArgb(243, 244, 246);

            if (!isOthers)
            {
                txtOtherDocType.Clear();
            }


            switch (cmbDocumentType.SelectedItem.ToString())
            {
                case "Barangay Clearance":
                    requirements = "Valid ID";
                    break;
                case "Certificate of Indigency":
                    requirements = "Valid ID, Proof of low income";
                    break;
                case "Certificate of Residency":
                    requirements = "Valid ID, Proof of Address";
                    break;
                default:
                    requirements = "None";
                    needsAttachment = false;
                    break;
            }

            lblRequirementsList.Text = requirements;
            btnAttachFile.Enabled = needsAttachment;
        }

        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            // Purpose required
            if (string.IsNullOrWhiteSpace(txtPurpose.Text))
            {
                MessageBox.Show("Please enter the purpose of your request.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Purpose too short
            if (txtPurpose.Text.Trim().Length < 10)
            {
                MessageBox.Show("Purpose must be at least 10 characters long.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPurpose.Focus();
                return;
            }
            
            // Document type required
            if (cmbDocumentType.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a document type.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // "Others" picked but not specified
            if (cmbDocumentType.SelectedItem.ToString() == "Others: (Please specify on the field below)" && string.IsNullOrWhiteSpace(txtOtherDocType.Text))
            {
                MessageBox.Show("Please specify the document type.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOtherDocType.Focus();
                return;
            }

            // Purpose required
            if (string.IsNullOrWhiteSpace(txtPurpose.Text))
            {
                MessageBox.Show("Please enter the purpose of your request.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Attachment required but not attached
            if (btnAttachFile.Enabled && lblFileStatus.Text == "No file attached.")
            {
                MessageBox.Show("Please attach the required document(s) before submitting.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Placeholder confirmation — swap for actual DB save later
            MessageBox.Show("Your request has been submitted!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form
            cmbDocumentType.SelectedIndex = 0;
            txtOtherDocType.Clear();
            txtPurpose.Clear();
            lblFileStatus.Text = "No file attached.";
        }
    }
}
