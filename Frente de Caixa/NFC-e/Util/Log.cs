using System;
using System.IO;
using System.Windows.Forms;


namespace NFCe.Util
{
    public static class Log
    {
        private static string path = Application.StartupPath + "LogNFCe.txt";

        public static void write(string texto) 
        {
            File.AppendAllText(path, DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString() + ":\t" + texto + Environment.NewLine);
        }
    }

}
