using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process unidanfe = new Process();
                unidanfe.StartInfo.FileName = @"C:\Unimake\UniNFe\unidanfe.exe";
                unidanfe.StartInfo.Arguments = " arquivo=\"53150410793118000178650010000002851000002857-nfe.xml\" ";
                unidanfe.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
