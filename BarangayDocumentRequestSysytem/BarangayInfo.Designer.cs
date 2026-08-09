namespace BarangayDocumentRequestSysytem
{
    partial class BarangayInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bodyGB = new GroupBox();
            brgyInfoTLP = new TableLayoutPanel();
            brgyCaptLabel = new Label();
            province = new Label();
            provinceLabel = new Label();
            municipality = new Label();
            municipalityLabel = new Label();
            brgyNameLabel = new Label();
            brgyName = new Label();
            brgyCapt = new Label();
            SectLabel = new Label();
            Sect = new Label();
            treaLabel = new Label();
            trea = new Label();
            ofnLabel = new Label();
            ofn = new Label();
            emailLabel = new Label();
            email = new Label();
            ohLabel = new Label();
            oh = new Label();
            bodyGB.SuspendLayout();
            brgyInfoTLP.SuspendLayout();
            SuspendLayout();
            // 
            // bodyGB
            // 
            bodyGB.Controls.Add(brgyInfoTLP);
            bodyGB.Dock = DockStyle.Fill;
            bodyGB.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bodyGB.Location = new Point(0, 0);
            bodyGB.Margin = new Padding(0);
            bodyGB.Name = "bodyGB";
            bodyGB.Padding = new Padding(7);
            bodyGB.Size = new Size(390, 370);
            bodyGB.TabIndex = 0;
            bodyGB.TabStop = false;
            bodyGB.Text = "Barangay Information";
            // 
            // brgyInfoTLP
            // 
            brgyInfoTLP.ColumnCount = 2;
            brgyInfoTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            brgyInfoTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            brgyInfoTLP.Controls.Add(brgyCaptLabel, 0, 3);
            brgyInfoTLP.Controls.Add(province, 1, 2);
            brgyInfoTLP.Controls.Add(provinceLabel, 0, 2);
            brgyInfoTLP.Controls.Add(municipality, 1, 1);
            brgyInfoTLP.Controls.Add(municipalityLabel, 0, 1);
            brgyInfoTLP.Controls.Add(brgyNameLabel, 0, 0);
            brgyInfoTLP.Controls.Add(brgyName, 1, 0);
            brgyInfoTLP.Controls.Add(brgyCapt, 1, 3);
            brgyInfoTLP.Controls.Add(SectLabel, 0, 4);
            brgyInfoTLP.Controls.Add(Sect, 1, 4);
            brgyInfoTLP.Controls.Add(treaLabel, 0, 5);
            brgyInfoTLP.Controls.Add(trea, 1, 5);
            brgyInfoTLP.Controls.Add(ofnLabel, 0, 6);
            brgyInfoTLP.Controls.Add(ofn, 1, 6);
            brgyInfoTLP.Controls.Add(emailLabel, 0, 7);
            brgyInfoTLP.Controls.Add(email, 1, 7);
            brgyInfoTLP.Controls.Add(ohLabel, 0, 8);
            brgyInfoTLP.Controls.Add(oh, 1, 8);
            brgyInfoTLP.Dock = DockStyle.Fill;
            brgyInfoTLP.Location = new Point(7, 27);
            brgyInfoTLP.Margin = new Padding(0);
            brgyInfoTLP.Name = "brgyInfoTLP";
            brgyInfoTLP.Padding = new Padding(7);
            brgyInfoTLP.RowCount = 9;
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            brgyInfoTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            brgyInfoTLP.Size = new Size(376, 336);
            brgyInfoTLP.TabIndex = 0;
            // 
            // brgyCaptLabel
            // 
            brgyCaptLabel.AutoSize = true;
            brgyCaptLabel.Dock = DockStyle.Fill;
            brgyCaptLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            brgyCaptLabel.Location = new Point(10, 112);
            brgyCaptLabel.Name = "brgyCaptLabel";
            brgyCaptLabel.Size = new Size(175, 35);
            brgyCaptLabel.TabIndex = 1;
            brgyCaptLabel.Text = "Barangay Captain :";
            brgyCaptLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // province
            // 
            province.AutoSize = true;
            province.Dock = DockStyle.Fill;
            province.Font = new Font("Segoe UI", 9.75F);
            province.Location = new Point(191, 77);
            province.Name = "province";
            province.Size = new Size(175, 35);
            province.TabIndex = 2;
            province.Text = "La Union";
            province.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // provinceLabel
            // 
            provinceLabel.AutoSize = true;
            provinceLabel.Dock = DockStyle.Fill;
            provinceLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            provinceLabel.Location = new Point(10, 77);
            provinceLabel.Name = "provinceLabel";
            provinceLabel.Size = new Size(175, 35);
            provinceLabel.TabIndex = 3;
            provinceLabel.Text = "Province :";
            provinceLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // municipality
            // 
            municipality.AutoSize = true;
            municipality.Dock = DockStyle.Fill;
            municipality.Font = new Font("Segoe UI", 9.75F);
            municipality.Location = new Point(191, 42);
            municipality.Name = "municipality";
            municipality.Size = new Size(175, 35);
            municipality.TabIndex = 4;
            municipality.Text = "San Fernando City";
            municipality.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // municipalityLabel
            // 
            municipalityLabel.AutoSize = true;
            municipalityLabel.Dock = DockStyle.Fill;
            municipalityLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            municipalityLabel.Location = new Point(10, 42);
            municipalityLabel.Name = "municipalityLabel";
            municipalityLabel.Size = new Size(175, 35);
            municipalityLabel.TabIndex = 5;
            municipalityLabel.Text = "Municipality :";
            municipalityLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // brgyNameLabel
            // 
            brgyNameLabel.AutoSize = true;
            brgyNameLabel.Dock = DockStyle.Fill;
            brgyNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            brgyNameLabel.Location = new Point(10, 7);
            brgyNameLabel.Name = "brgyNameLabel";
            brgyNameLabel.Size = new Size(175, 35);
            brgyNameLabel.TabIndex = 0;
            brgyNameLabel.Text = "Barangay :";
            brgyNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // brgyName
            // 
            brgyName.AutoSize = true;
            brgyName.Dock = DockStyle.Fill;
            brgyName.Font = new Font("Segoe UI", 9.75F);
            brgyName.Location = new Point(191, 7);
            brgyName.Name = "brgyName";
            brgyName.Size = new Size(175, 35);
            brgyName.TabIndex = 1;
            brgyName.Text = "Sevilla";
            brgyName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // brgyCapt
            // 
            brgyCapt.AutoSize = true;
            brgyCapt.Dock = DockStyle.Fill;
            brgyCapt.Font = new Font("Segoe UI", 9.75F);
            brgyCapt.Location = new Point(191, 112);
            brgyCapt.Name = "brgyCapt";
            brgyCapt.Size = new Size(175, 35);
            brgyCapt.TabIndex = 6;
            brgyCapt.Text = "Juan Dela Cruz";
            brgyCapt.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SectLabel
            // 
            SectLabel.AutoSize = true;
            SectLabel.Dock = DockStyle.Fill;
            SectLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            SectLabel.Location = new Point(10, 147);
            SectLabel.Name = "SectLabel";
            SectLabel.Size = new Size(175, 35);
            SectLabel.TabIndex = 7;
            SectLabel.Text = "Secretary :";
            SectLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Sect
            // 
            Sect.AutoSize = true;
            Sect.Dock = DockStyle.Fill;
            Sect.Font = new Font("Segoe UI", 9.75F);
            Sect.Location = new Point(191, 147);
            Sect.Name = "Sect";
            Sect.Size = new Size(175, 35);
            Sect.TabIndex = 8;
            Sect.Text = "Andrew Garfield";
            Sect.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // treaLabel
            // 
            treaLabel.AutoSize = true;
            treaLabel.Dock = DockStyle.Fill;
            treaLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            treaLabel.Location = new Point(10, 182);
            treaLabel.Name = "treaLabel";
            treaLabel.Size = new Size(175, 35);
            treaLabel.TabIndex = 9;
            treaLabel.Text = "Treasurer :";
            treaLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // trea
            // 
            trea.AutoSize = true;
            trea.Dock = DockStyle.Fill;
            trea.Font = new Font("Segoe UI", 9.75F);
            trea.Location = new Point(191, 182);
            trea.Name = "trea";
            trea.Size = new Size(175, 35);
            trea.TabIndex = 10;
            trea.Text = "Tobey Maguire";
            trea.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ofnLabel
            // 
            ofnLabel.AutoSize = true;
            ofnLabel.Dock = DockStyle.Fill;
            ofnLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            ofnLabel.Location = new Point(10, 217);
            ofnLabel.Name = "ofnLabel";
            ofnLabel.Size = new Size(175, 35);
            ofnLabel.TabIndex = 11;
            ofnLabel.Text = "Office Contact Number :";
            ofnLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ofn
            // 
            ofn.AutoSize = true;
            ofn.Dock = DockStyle.Fill;
            ofn.Font = new Font("Segoe UI", 9.75F);
            ofn.Location = new Point(191, 217);
            ofn.Name = "ofn";
            ofn.Size = new Size(175, 35);
            ofn.TabIndex = 12;
            ofn.Text = "0912-345-6789";
            ofn.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Dock = DockStyle.Fill;
            emailLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            emailLabel.Location = new Point(10, 252);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(175, 35);
            emailLabel.TabIndex = 13;
            emailLabel.Text = "Office Email : ";
            emailLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // email
            // 
            email.AutoSize = true;
            email.Dock = DockStyle.Fill;
            email.Font = new Font("Segoe UI", 9.75F);
            email.Location = new Point(191, 252);
            email.Name = "email";
            email.Size = new Size(175, 35);
            email.TabIndex = 14;
            email.Text = "hotdog@gmail.com";
            email.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ohLabel
            // 
            ohLabel.AutoSize = true;
            ohLabel.Dock = DockStyle.Fill;
            ohLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            ohLabel.Location = new Point(10, 287);
            ohLabel.Name = "ohLabel";
            ohLabel.Size = new Size(175, 42);
            ohLabel.TabIndex = 15;
            ohLabel.Text = "Office Hour :";
            ohLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // oh
            // 
            oh.AutoSize = true;
            oh.Dock = DockStyle.Fill;
            oh.Font = new Font("Segoe UI", 9.75F);
            oh.Location = new Point(191, 287);
            oh.Name = "oh";
            oh.Size = new Size(175, 42);
            oh.TabIndex = 16;
            oh.Text = "8:00 am - 5:00 pm";
            oh.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BarangayInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bodyGB);
            Margin = new Padding(0);
            Name = "BarangayInfo";
            Size = new Size(390, 370);
            bodyGB.ResumeLayout(false);
            brgyInfoTLP.ResumeLayout(false);
            brgyInfoTLP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox bodyGB;
        private TableLayoutPanel brgyInfoTLP;
        private Label brgyCaptLabel;
        private Label province;
        private Label provinceLabel;
        private Label municipality;
        private Label municipalityLabel;
        private Label brgyNameLabel;
        private Label brgyName;
        private Label brgyCapt;
        private Label SectLabel;
        private Label Sect;
        private Label treaLabel;
        private Label trea;
        private Label ofnLabel;
        private Label ofn;
        private Label emailLabel;
        private Label email;
        private Label ohLabel;
        private Label oh;
    }
}
