using System;
using System.IO;
using System.Windows.Forms;


namespace PafEcf.Util
{
    public static class Log
    {
        private static string path = Application.StartupPath + "LogPAF.txt";

        public static void write(string texto) 
        {
            File.AppendAllText(path, DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString() + ":\t" + texto + Environment.NewLine);
        }
    }

}
