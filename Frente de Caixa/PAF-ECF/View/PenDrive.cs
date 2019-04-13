

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PafEcf.View
{

    public partial class PenDrive : Form
    {

        public static string Rotina;

        public PenDrive()
        {
            InitializeComponent();

            if (Rotina == "IMPORTA")
                Text = "Rotina de importacao de dados do Pen-Drive";
            else if (Rotina == "EXPORTA")
                Text = "Rotina de exportacao de dados para Pen-Drive";

            editPath.Text = "";
        }


        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FPenDrive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }


        private void SpeedButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();

            editPath.Text = OpenFileDialog.FileName;

            if (Rotina == "IMPORTA")
            {
                if (File.Exists(editPath.Text))
                {
                    CargaPDV FCargaPDV = new CargaPDV();
                    //FCargaPDV.Tipo = "importa";
                    FCargaPDV.ShowDialog();
                }
            }
            if (Rotina == "EXPORTA")
            {
                if (File.Exists(editPath.Text))
                {
                    CargaPDV FCargaPDV = new CargaPDV();
                    //FCargaPDV.Tipo = "exporta";
                    FCargaPDV.ShowDialog();
                    MessageBox.Show("Arquivos copiados para o Pen-Drive");
                }
            }

        }

    }

}
