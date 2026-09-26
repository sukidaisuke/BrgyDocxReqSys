using System;

namespace BarangayDocumentRequestSysytem
{
    public static class DateHelper
    {
        /// <summary>
        /// Standard format for Header Labels: "September 26, 2026 | Saturday"
        /// </summary>
        public static string CurrentHeaderDate => DateTime.Now.ToString("MMMM d, yyyy | dddd");

        /// <summary>
        /// Standard format for Timestamps/Logs: "September 26, 2026 • 9:52 PM"
        /// </summary>
        public static string FormatTimestamp(DateTime dateTime)
        {
            return dateTime.ToString("MMMM dd, yyyy • h:mm tt");
        }

        /// <summary>
        /// Standard short date format: "September 26, 2026"
        /// </summary>
        public static string FormatShortDate(DateTime dateTime)
        {
            return dateTime.ToString("MMMM dd, yyyy");
        }
    }
}