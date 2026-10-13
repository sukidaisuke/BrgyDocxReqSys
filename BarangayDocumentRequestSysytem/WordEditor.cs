#nullable disable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// A small "Word-like" editor: fonts, bold/italic/underline, colour, alignment, bullets,
    /// undo/redo and inserting pictures (logo, seal ...). Content is stored as RTF.
    /// </summary>
    public class WordEditor : UserControl
    {
        private readonly ToolStrip bar;
        private readonly RichTextBoxPrinter rtb;
        private ToolStripComboBox cmbFont, cmbSize, cmbPictureSize;
        private ToolStripButton btnBold, btnItalic, btnUnderline, btnLeft, btnCenter, btnRight, btnJustify, btnBullet;
        private ToolStripDropDownButton btnFields;
        private bool syncing = false;

        public WordEditor()
        {
            Dock = DockStyle.Fill;

            rtb = new RichTextBoxPrinter
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                AcceptsTab = true,
                HideSelection = false,
                EnableAutoDragDrop = false,
                Font = new Font("Times New Roman", 12F)
            };
            rtb.SelectionChanged += (s, e) => SyncToolbar();

            bar = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Dock = DockStyle.Top, ImageScalingSize = new Size(16, 16) };
            BuildToolbar();

            Controls.Add(rtb);
            Controls.Add(bar);
            bar.SendToBack();
            rtb.BringToFront();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RichTextBoxPrinter Rich { get { return rtb; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Rtf
        {
            get { return rtb.Rtf; }
            set { rtb.Rtf = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EditingEnabled
        {
            get { return !rtb.ReadOnly; }
            set { rtb.ReadOnly = !value; bar.Enabled = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ToolbarVisible
        {
            get { return bar.Visible; }
            set { bar.Visible = value; }
        }

        // ---------------------------------------------------------------
        // Toolbar
        // ---------------------------------------------------------------
        private void BuildToolbar()
        {
            cmbFont = new ToolStripComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 150, AutoSize = false };
            foreach (FontFamily f in FontFamily.Families) cmbFont.Items.Add(f.Name);
            cmbFont.SelectedIndexChanged += (s, e) => { if (!syncing) ApplyFont(cmbFont.Text, null, null); };

            cmbSize = new ToolStripComboBox { DropDownStyle = ComboBoxStyle.DropDown, Width = 48, AutoSize = false };
            foreach (int sz in new[] { 8, 9, 10, 11, 12, 13, 14, 16, 18, 20, 24, 28, 32, 36, 48 }) cmbSize.Items.Add(sz.ToString());
            cmbSize.SelectedIndexChanged += (s, e) => { if (!syncing) ApplySize(); };
            cmbSize.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { ApplySize(); rtb.Focus(); e.SuppressKeyPress = true; } };

            btnBold = Toggle("B", "Bold (Ctrl+B)", FontStyle.Bold);
            btnItalic = Toggle("I", "Italic (Ctrl+I)", FontStyle.Italic);
            btnUnderline = Toggle("U", "Underline (Ctrl+U)", FontStyle.Underline);
            btnBold.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnItalic.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            btnUnderline.Font = new Font("Segoe UI", 9F, FontStyle.Underline);

            ToolStripButton btnColor = Button("A", "Text colour", (s, e) => PickColor());
            btnColor.ForeColor = Color.Firebrick;
            btnColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            btnLeft = AlignButton("⯇", "Align left", HorizontalAlignment.Left);
            btnCenter = AlignButton("≡", "Center", HorizontalAlignment.Center);
            btnRight = AlignButton("⯈", "Align right", HorizontalAlignment.Right);

            btnBullet = Button("• List", "Bulleted list", (s, e) => { rtb.SelectionBullet = !rtb.SelectionBullet; rtb.Focus(); });

            ToolStripButton btnUndo = Button("↶", "Undo (Ctrl+Z)", (s, e) => { if (rtb.CanUndo) rtb.Undo(); rtb.Focus(); });
            ToolStripButton btnRedo = Button("↷", "Redo (Ctrl+Y)", (s, e) => { if (rtb.CanRedo) rtb.Redo(); rtb.Focus(); });

            ToolStripButton btnPicture = Button("🖼 Insert Picture", "Insert a logo or picture at the cursor", (s, e) => InsertPicture());
            cmbPictureSize = new ToolStripComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 95, AutoSize = false, ToolTipText = "Size of the picture to insert" };
            cmbPictureSize.Items.AddRange(new object[] { "Small", "Medium", "Large" });
            cmbPictureSize.SelectedIndex = 1;

            btnFields = new ToolStripDropDownButton("Insert field ▾") { ToolTipText = "Insert information that is filled in automatically", Visible = false };

            bar.Items.AddRange(new ToolStripItem[]
            {
                cmbFont, cmbSize, new ToolStripSeparator(),
                btnBold, btnItalic, btnUnderline, btnColor, new ToolStripSeparator(),
                btnLeft, btnCenter, btnRight, btnBullet, new ToolStripSeparator(),
                btnUndo, btnRedo, new ToolStripSeparator(),
                btnPicture, cmbPictureSize, new ToolStripSeparator(),
                btnFields
            });
        }

        private ToolStripButton Button(string text, string tip, EventHandler onClick)
        {
            ToolStripButton b = new ToolStripButton(text) { ToolTipText = tip, DisplayStyle = ToolStripItemDisplayStyle.Text };
            b.Click += onClick;
            return b;
        }

        private ToolStripButton Toggle(string text, string tip, FontStyle style)
        {
            ToolStripButton b = Button(text, tip, null);
            b.CheckOnClick = false;
            b.Click += (s, e) => { ToggleStyle(style); rtb.Focus(); };
            return b;
        }

        private ToolStripButton AlignButton(string text, string tip, HorizontalAlignment align)
        {
            return Button(text, tip, (s, e) => { rtb.SelectionAlignment = align; SyncToolbar(); rtb.Focus(); });
        }

        /// <summary>Adds the "Insert field" menu: (label shown to the admin, placeholder inserted).</summary>
        public void SetFieldMenu(params string[][] labelAndToken)
        {
            btnFields.DropDownItems.Clear();
            foreach (string[] item in labelAndToken)
            {
                string token = item[1];
                ToolStripMenuItem mi = new ToolStripMenuItem(item[0] + "   " + token);
                mi.Click += (s, e) => { rtb.SelectedText = token; rtb.Focus(); };
                btnFields.DropDownItems.Add(mi);
            }
            btnFields.Visible = labelAndToken.Length > 0;
        }

        // ---------------------------------------------------------------
        // Formatting helpers
        // ---------------------------------------------------------------
        private Font CurrentFont()
        {
            return rtb.SelectionFont ?? rtb.Font;
        }

        private void ApplyFont(string family, float? size, FontStyle? style)
        {
            Font cur = CurrentFont();
            try
            {
                Font nf = new Font(family ?? cur.FontFamily.Name, size ?? cur.Size, style ?? cur.Style);
                rtb.SelectionFont = nf;
            }
            catch { /* some fonts do not support every style */ }
            rtb.Focus();
        }

        private void ApplySize()
        {
            float sz;
            if (float.TryParse(cmbSize.Text, out sz) && sz >= 4 && sz <= 120) ApplyFont(null, sz, null);
        }

        private void ToggleStyle(FontStyle style)
        {
            Font cur = CurrentFont();
            FontStyle ns = cur.Style ^ style;
            ApplyFont(null, null, ns);
            SyncToolbar();
        }

        private void PickColor()
        {
            using (ColorDialog cd = new ColorDialog { Color = rtb.SelectionColor })
            {
                if (cd.ShowDialog(FindForm()) == DialogResult.OK) rtb.SelectionColor = cd.Color;
            }
            rtb.Focus();
        }

        private void SyncToolbar()
        {
            syncing = true;
            try
            {
                Font f = rtb.SelectionFont;
                if (f != null)
                {
                    cmbFont.Text = f.FontFamily.Name;
                    cmbSize.Text = ((int)Math.Round(f.Size)).ToString();
                    btnBold.Checked = f.Bold;
                    btnItalic.Checked = f.Italic;
                    btnUnderline.Checked = f.Underline;
                }
                btnLeft.Checked = rtb.SelectionAlignment == HorizontalAlignment.Left;
                btnCenter.Checked = rtb.SelectionAlignment == HorizontalAlignment.Center;
                btnRight.Checked = rtb.SelectionAlignment == HorizontalAlignment.Right;
                btnBullet.Checked = rtb.SelectionBullet;
            }
            catch { }
            finally { syncing = false; }
        }

        // ---------------------------------------------------------------
        // Pictures
        // ---------------------------------------------------------------
        private void InsertPicture()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Choose a picture (logo, seal ...)";
                ofd.Filter = "Pictures (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                if (ofd.ShowDialog(FindForm()) != DialogResult.OK) return;

                int targetWidth = cmbPictureSize.SelectedIndex == 0 ? 70 : cmbPictureSize.SelectedIndex == 2 ? 220 : 120;

                try
                {
                    using (Image src = Image.FromFile(ofd.FileName))
                    {
                        int w = Math.Min(targetWidth, src.Width);
                        int h = Math.Max(1, (int)Math.Round(src.Height * (w / (double)src.Width)));

                        using (Bitmap bmp = new Bitmap(w, h))
                        {
                            bmp.SetResolution(96, 96);
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                g.Clear(Color.White);
                                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                g.DrawImage(src, 0, 0, w, h);
                            }
                            PutPicture(bmp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not insert that picture: " + ex.Message, "Picture", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            rtb.Focus();
        }

        private static int CountPictures(string rtf)
        {
            int n = 0, i = 0;
            while ((i = rtf.IndexOf("\\pict", i, StringComparison.Ordinal)) >= 0) { n++; i += 5; }
            return n;
        }

        // Inserts a bitmap at the cursor. First as a compact PNG inside the RTF; if the control
        // does not accept that, falls back to a clipboard paste.
        private void PutPicture(Bitmap bmp)
        {
            int before = CountPictures(rtb.Rtf);

            byte[] png;
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                png = ms.ToArray();
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("{\\rtf1{\\pict\\pngblip\\picw").Append(bmp.Width).Append("\\pich").Append(bmp.Height)
              .Append("\\picwgoal").Append(bmp.Width * 15).Append("\\pichgoal").Append(bmp.Height * 15).Append(' ');
            foreach (byte b in png) sb.Append(b.ToString("x2"));
            sb.Append("}}");

            try { rtb.SelectedRtf = sb.ToString(); } catch { }

            if (CountPictures(rtb.Rtf) <= before)
            {
                Clipboard.SetImage(bmp);
                rtb.Paste(DataFormats.GetFormat(DataFormats.Bitmap));
            }
        }
    }
}
