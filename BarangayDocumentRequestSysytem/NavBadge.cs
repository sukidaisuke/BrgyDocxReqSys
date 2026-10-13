#nullable disable
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>Draws a small red notification number on the right side of a sidebar button.</summary>
    public class NavBadge
    {
        private readonly Button button;
        private int count;

        public NavBadge(Button button)
        {
            this.button = button;
            button.Paint += Button_Paint;
        }

        public int Count
        {
            get { return count; }
            set
            {
                if (count == value) return;
                count = value;
                button.Invalidate();
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            if (count <= 0) return;

            string text = count > 99 ? "99+" : count.ToString();
            using (Font f = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            {
                SizeF size = e.Graphics.MeasureString(text, f);
                int h = 20;
                int w = Math.Max(h, (int)size.Width + 10);
                Rectangle r = new Rectangle(button.Width - w - 10, (button.Height - h) / 2, w, h);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = RoundedRect(r, h / 2))
                using (SolidBrush fill = new SolidBrush(Color.FromArgb(220, 38, 38)))
                {
                    e.Graphics.FillPath(fill, path);
                }

                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(text, f, Brushes.White, r, sf);
                }
            }
        }

        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }
    }
}
