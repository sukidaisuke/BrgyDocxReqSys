namespace BarangayDocumentRequestSysytem
{
    partial class Dashboard
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
            PanelContainer = new Panel();
            DashboardContent = new Label();
            PanelContainer.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContainer
            // 
            PanelContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelContainer.Controls.Add(DashboardContent);
            PanelContainer.Location = new Point(0, 0);
            PanelContainer.Name = "PanelContainer";
            PanelContainer.Size = new Size(635, 512);
            PanelContainer.TabIndex = 0;
            // 
            // DashboardContent
            // 
            DashboardContent.Anchor = AnchorStyles.None;
            DashboardContent.AutoSize = true;
            DashboardContent.Font = new Font("Segoe UI", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            DashboardContent.Location = new Point(33, 219);
            DashboardContent.Name = "DashboardContent";
            DashboardContent.Size = new Size(582, 86);
            DashboardContent.TabIndex = 0;
            DashboardContent.Text = "Dashboard Ngane";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelContainer);
            Name = "Dashboard";
            Size = new Size(635, 512);
            PanelContainer.ResumeLayout(false);
            PanelContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContainer;
        private Label DashboardContent;
    }
}
