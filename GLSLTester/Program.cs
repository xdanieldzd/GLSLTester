using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GLSLTester
{
    static class Program
    {
        public static DateTime RetrieveLinkerTimestamp()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }

        public static System.Windows.Forms.ImageList NodeImageList { get; private set; }

        public static System.Diagnostics.Stopwatch Stopwatch { get; private set; }
        public static long Elapsed { get; set; }

        [STAThread]
        static void Main()
        {
            NodeImageList = new System.Windows.Forms.ImageList() { ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit, ImageSize = new System.Drawing.Size(16, 16) };

            System.Resources.ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentUICulture, true, true);
            foreach (System.Collections.DictionaryEntry entry in resourceSet)
            {
                NodeImageList.Images.Add((string)entry.Key, (System.Drawing.Bitmap)entry.Value);
            }

            Stopwatch = new System.Diagnostics.Stopwatch();
            Stopwatch.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
