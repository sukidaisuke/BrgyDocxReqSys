namespace BarangayDocumentRequestSysytem
{
    partial class UserPage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPage));
            NavPanel = new Panel();
            navTLP = new TableLayoutPanel();
            btnLogout = new Button();
            btnProfile = new Button();
            btnHome = new Button();
            btnAnnouncements = new Button();
            btnMyRequests = new Button();
            btnRequestDoc = new Button();
            logoPicBox = new PictureBox();
            label12 = new Label();
            panelContent = new Panel();
            NavPanel.SuspendLayout();
            navTLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicBox).BeginInit();
            SuspendLayout();
            // 
            // NavPanel
            // 
            NavPanel.BackColor = Color.FromArgb(12, 45, 93);
            NavPanel.Controls.Add(navTLP);
            NavPanel.Controls.Add(logoPicBox);
            NavPanel.Controls.Add(label12);
            NavPanel.Dock = DockStyle.Left;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(209, 450);
            NavPanel.TabIndex = 20;
            // 
            // navTLP
            // 
            navTLP.Anchor = AnchorStyles.None;
            navTLP.ColumnCount = 1;
            navTLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            navTLP.Controls.Add(btnLogout, 0, 5);
            navTLP.Controls.Add(btnProfile, 0, 4);
            navTLP.Controls.Add(btnHome, 0, 0);
            navTLP.Controls.Add(btnAnnouncements, 0, 3);
            navTLP.Controls.Add(btnMyRequests, 0, 2);
            navTLP.Controls.Add(btnRequestDoc, 0, 1);
            navTLP.Location = new Point(0, 76);
            navTLP.Name = "navTLP";
            navTLP.RowCount = 6;
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            navTLP.Size = new Size(209, 374);
            navTLP.TabIndex = 24;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Fill;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(3, 303);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Size = new Size(203, 68);
            btnLogout.TabIndex = 23;
            btnLogout.Text = "🚪  Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnProfile
            // 
            btnProfile.Dock = DockStyle.Fill;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(3, 243);
            btnProfile.Name = "btnProfile";
            btnProfile.Padding = new Padding(20, 0, 0, 0);
            btnProfile.Size = new Size(203, 54);
            btnProfile.TabIndex = 21;
            btnProfile.Text = "👤  Profile";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(12, 45, 93);
            btnHome.Dock = DockStyle.Fill;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(3, 3);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(20, 0, 0, 0);
            btnHome.Size = new Size(203, 54);
            btnHome.TabIndex = 21;
            btnHome.Text = "🏠 Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // btnAnnouncements
            // 
            btnAnnouncements.Dock = DockStyle.Fill;
            btnAnnouncements.FlatAppearance.BorderSize = 0;
            btnAnnouncements.FlatStyle = FlatStyle.Flat;
            btnAnnouncements.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnnouncements.ForeColor = Color.White;
            btnAnnouncements.Location = new Point(3, 183);
            btnAnnouncements.Name = "btnAnnouncements";
            btnAnnouncements.Padding = new Padding(20, 0, 0, 0);
            btnAnnouncements.Size = new Size(203, 54);
            btnAnnouncements.TabIndex = 21;
            btnAnnouncements.Text = "📢  Announcements";
            btnAnnouncements.TextAlign = ContentAlignment.MiddleLeft;
            btnAnnouncements.UseVisualStyleBackColor = true;
            btnAnnouncements.Click += btnAnnouncements_Click;
            // 
            // btnMyRequests
            // 
            btnMyRequests.BackColor = Color.FromArgb(12, 45, 93);
            btnMyRequests.Dock = DockStyle.Fill;
            btnMyRequests.FlatAppearance.BorderSize = 0;
            btnMyRequests.FlatStyle = FlatStyle.Flat;
            btnMyRequests.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMyRequests.ForeColor = Color.White;
            btnMyRequests.Location = new Point(3, 123);
            btnMyRequests.Name = "btnMyRequests";
            btnMyRequests.Padding = new Padding(20, 0, 0, 0);
            btnMyRequests.Size = new Size(203, 54);
            btnMyRequests.TabIndex = 21;
            btnMyRequests.Text = "🕒  My Requests";
            btnMyRequests.TextAlign = ContentAlignment.MiddleLeft;
            btnMyRequests.UseVisualStyleBackColor = false;
            btnMyRequests.Click += btnMyRequests_Click;
            // 
            // btnRequestDoc
            // 
            btnRequestDoc.Dock = DockStyle.Fill;
            btnRequestDoc.FlatAppearance.BorderSize = 0;
            btnRequestDoc.FlatStyle = FlatStyle.Flat;
            btnRequestDoc.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRequestDoc.ForeColor = Color.White;
            btnRequestDoc.Location = new Point(3, 63);
            btnRequestDoc.Name = "btnRequestDoc";
            btnRequestDoc.Padding = new Padding(20, 0, 0, 0);
            btnRequestDoc.Size = new Size(203, 54);
            btnRequestDoc.TabIndex = 21;
            btnRequestDoc.Text = "📄  Request Document";
            btnRequestDoc.TextAlign = ContentAlignment.MiddleLeft;
            btnRequestDoc.UseVisualStyleBackColor = true;
            btnRequestDoc.Click += btnRequestDoc_Click;
            // 
            // logoPicBox
            // 
            logoPicBox.BackColor = Color.FromArgb(12, 45, 93);
            logoPicBox.Image = (Image)resources.GetObject("logoPicBox.Image");
            logoPicBox.InitialImage = (Image)resources.GetObject("logoPicBox.InitialImage");
            logoPicBox.Location = new Point(3, 3);
            logoPicBox.Name = "logoPicBox";
            logoPicBox.Size = new Size(155, 52);
            logoPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPicBox.TabIndex = 22;
            logoPicBox.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(31, 180);
            label12.Name = "label12";
            label12.Size = new Size(0, 20);
            label12.TabIndex = 2;
            // 
            // panelContent
            // 
            panelContent.Location = new Point(212, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(586, 447);
            panelContent.TabIndex = 21;
            panelContent.Paint += panelContent_Paint;
            // 
            // UserPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(800, 450);
            Controls.Add(panelContent);
            Controls.Add(NavPanel);
            Name = "UserPage";
            Text = "UserPage";
            Load += UserPage_Load;
            NavPanel.ResumeLayout(false);
            NavPanel.PerformLayout();
            navTLP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPicBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel NavPanel;
        private TableLayoutPanel navTLP;
        private Button btnLogout;
        private Button btnProfile;
        private Button btnHome;
        private Button btnAnnouncements;
        private Button btnMyRequests;
        private Button btnRequestDoc;
        private PictureBox logoPicBox;
        private Label label12;
        private Panel panelContent;
    }
}