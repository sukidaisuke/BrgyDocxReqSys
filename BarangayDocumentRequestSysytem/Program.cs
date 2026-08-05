using BarangayDocumentRequestSysytem;
using System;
using System.Windows.Forms;

namespace BarangayDocumentRequestSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}