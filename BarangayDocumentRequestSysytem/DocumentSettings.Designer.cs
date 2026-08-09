namespace BarangayDocumentRequestSysytem
{
    partial class DocumentSettings
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
            tableLayoutPanel1 = new TableLayoutPanel();
            pr1Price = new Label();
            pr2Label = new Label();
            pr2Price = new Label();
            pr3Label = new Label();
            pr3Price = new Label();
            pr4Label = new Label();
            pr4Price = new Label();
            pr1Label = new Label();
            bodyGB.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // bodyGB
            // 
            bodyGB.Controls.Add(tableLayoutPanel1);
            bodyGB.Dock = DockStyle.Fill;
            bodyGB.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            bodyGB.Location = new Point(0, 0);
            bodyGB.Margin = new Padding(0);
            bodyGB.Name = "bodyGB";
            bodyGB.Padding = new Padding(7);
            bodyGB.Size = new Size(390, 370);
            bodyGB.TabIndex = 0;
            bodyGB.TabStop = false;
            bodyGB.Text = "Document Settings";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pr1Price, 1, 0);
            tableLayoutPanel1.Controls.Add(pr2Label, 0, 1);
            tableLayoutPanel1.Controls.Add(pr2Price, 1, 1);
            tableLayoutPanel1.Controls.Add(pr3Label, 0, 2);
            tableLayoutPanel1.Controls.Add(pr3Price, 1, 2);
            tableLayoutPanel1.Controls.Add(pr4Label, 0, 3);
            tableLayoutPanel1.Controls.Add(pr4Price, 1, 3);
            tableLayoutPanel1.Controls.Add(pr1Label, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(7, 27);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(7);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(376, 172);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pr1Price
            // 
            pr1Price.AutoSize = true;
            pr1Price.Dock = DockStyle.Fill;
            pr1Price.Font = new Font("Segoe UI", 9.75F);
            pr1Price.Location = new Point(191, 7);
            pr1Price.Name = "pr1Price";
            pr1Price.Size = new Size(175, 40);
            pr1Price.TabIndex = 1;
            pr1Price.Text = "₱ 50.00";
            pr1Price.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pr2Label
            // 
            pr2Label.AutoSize = true;
            pr2Label.Dock = DockStyle.Fill;
            pr2Label.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            pr2Label.Location = new Point(10, 47);
            pr2Label.Name = "pr2Label";
            pr2Label.Size = new Size(175, 40);
            pr2Label.TabIndex = 2;
            pr2Label.Text = "Certificate of Residency :";
            pr2Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pr2Price
            // 
            pr2Price.AutoSize = true;
            pr2Price.Dock = DockStyle.Fill;
            pr2Price.Font = new Font("Segoe UI", 9.75F);
            pr2Price.Location = new Point(191, 47);
            pr2Price.Name = "pr2Price";
            pr2Price.Size = new Size(175, 40);
            pr2Price.TabIndex = 3;
            pr2Price.Text = "₱ 30.00";
            pr2Price.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pr3Label
            // 
            pr3Label.AutoSize = true;
            pr3Label.Dock = DockStyle.Fill;
            pr3Label.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            pr3Label.Location = new Point(10, 87);
            pr3Label.Name = "pr3Label";
            pr3Label.Size = new Size(175, 40);
            pr3Label.TabIndex = 4;
            pr3Label.Text = "Certificate of Indigency :";
            pr3Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pr3Price
            // 
            pr3Price.AutoSize = true;
            pr3Price.Dock = DockStyle.Fill;
            pr3Price.Font = new Font("Segoe UI", 9.75F);
            pr3Price.Location = new Point(191, 87);
            pr3Price.Name = "pr3Price";
            pr3Price.Size = new Size(175, 40);
            pr3Price.TabIndex = 5;
            pr3Price.Text = "₱ 0.00";
            pr3Price.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pr4Label
            // 
            pr4Label.AutoSize = true;
            pr4Label.Dock = DockStyle.Fill;
            pr4Label.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            pr4Label.Location = new Point(10, 127);
            pr4Label.Name = "pr4Label";
            pr4Label.Size = new Size(175, 40);
            pr4Label.TabIndex = 6;
            pr4Label.Text = "Business Permit :";
            pr4Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pr4Price
            // 
            pr4Price.AutoSize = true;
            pr4Price.Dock = DockStyle.Fill;
            pr4Price.Font = new Font("Segoe UI", 9.75F);
            pr4Price.Location = new Point(191, 127);
            pr4Price.Name = "pr4Price";
            pr4Price.Size = new Size(175, 40);
            pr4Price.TabIndex = 7;
            pr4Price.Text = "₱ 100.00";
            pr4Price.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pr1Label
            // 
            pr1Label.AutoSize = true;
            pr1Label.Dock = DockStyle.Fill;
            pr1Label.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            pr1Label.Location = new Point(10, 7);
            pr1Label.Name = "pr1Label";
            pr1Label.Size = new Size(175, 40);
            pr1Label.TabIndex = 0;
            pr1Label.Text = "Barangay Clearance :";
            pr1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DocumentSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bodyGB);
            Margin = new Padding(0);
            Name = "DocumentSettings";
            Size = new Size(390, 370);
            bodyGB.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox bodyGB;
        private TableLayoutPanel tableLayoutPanel1;
        private Label pr1Price;
        private Label pr2Label;
        private Label pr2Price;
        private Label pr3Label;
        private Label pr3Price;
        private Label pr4Label;
        private Label pr4Price;
        private Label pr1Label;
    }
}
