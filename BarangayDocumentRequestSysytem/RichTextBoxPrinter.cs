#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BarangayDocumentRequestSysytem
{
    /// <summary>
    /// A RichTextBox that can print itself (text, formatting AND pictures) page by page.
    /// Based on the standard EM_FORMATRANGE technique.
    /// </summary>
    public class RichTextBoxPrinter : RichTextBox
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT { public int left, top, right, bottom; }

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARRANGE { public int cpMin, cpMax; }

        [StructLayout(LayoutKind.Sequential)]
        private struct FORMATRANGE
        {
            public IntPtr hdc;
            public IntPtr hdcTarget;
            public RECT rc;
            public RECT rcPage;
            public CHARRANGE chrg;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private const int WM_USER = 0x400;
        private const int EM_FORMATRANGE = WM_USER + 57;
        private const double TwipsPerHundredthInch = 14.4;   // 1440 twips per inch / 100

        private int nextChar = 0;

        /// <summary>Prints one page and returns the index of the first character of the next page.</summary>
        private int PrintPage(int charFrom, int charTo, PrintPageEventArgs e)
        {
            FORMATRANGE fr = new FORMATRANGE();
            fr.chrg.cpMin = charFrom;
            fr.chrg.cpMax = charTo;

            fr.rc.top = (int)(e.MarginBounds.Top * TwipsPerHundredthInch);
            fr.rc.bottom = (int)(e.MarginBounds.Bottom * TwipsPerHundredthInch);
            fr.rc.left = (int)(e.MarginBounds.Left * TwipsPerHundredthInch);
            fr.rc.right = (int)(e.MarginBounds.Right * TwipsPerHundredthInch);

            fr.rcPage.top = (int)(e.PageBounds.Top * TwipsPerHundredthInch);
            fr.rcPage.bottom = (int)(e.PageBounds.Bottom * TwipsPerHundredthInch);
            fr.rcPage.left = (int)(e.PageBounds.Left * TwipsPerHundredthInch);
            fr.rcPage.right = (int)(e.PageBounds.Right * TwipsPerHundredthInch);

            IntPtr hdc = e.Graphics.GetHdc();
            fr.hdc = hdc;
            fr.hdcTarget = hdc;

            IntPtr lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr));
            Marshal.StructureToPtr(fr, lparam, false);

            int result = (int)SendMessage(Handle, EM_FORMATRANGE, new IntPtr(1), lparam);   // 1 = render

            Marshal.FreeCoTaskMem(lparam);
            e.Graphics.ReleaseHdc(hdc);
            return result;
        }

        private void FormatRangeDone()
        {
            SendMessage(Handle, EM_FORMATRANGE, IntPtr.Zero, IntPtr.Zero);   // release cached info
        }

        /// <summary>Creates a PrintDocument that prints the current content of this box.</summary>
        public PrintDocument CreatePrintDocument(string documentName)
        {
            var unused = Handle;   // make sure the native control exists
            PrintDocument pd = new PrintDocument { DocumentName = documentName };

            pd.BeginPrint += (s, e) => nextChar = 0;
            pd.PrintPage += (s, e) =>
            {
                nextChar = PrintPage(nextChar, TextLength, e);
                e.HasMorePages = nextChar < TextLength;
            };
            pd.EndPrint += (s, e) => FormatRangeDone();
            return pd;
        }
    }
}
