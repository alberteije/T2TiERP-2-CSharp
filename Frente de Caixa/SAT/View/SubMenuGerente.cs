using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NFCe.Util;

namespace NFCe.View
{
    public partial class FSubMenuGerente : Form
    {
        public FSubMenuGerente()
        {
            InitializeComponent();
            listaGerente.Focus();
            listaGerente.SelectedIndex = 0;
        }

        private void listaGerente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }


            if (e.KeyCode == Keys.Enter)
            {
                //  inicia movimento
                if (listaGerente.SelectedIndex == 0)
                    Caixa.IniciaMovimento();
                //  encerra movimento
                if (listaGerente.SelectedIndex == 1)
                    Caixa.EncerraMovimento();
                //  suprimento
                if (listaGerente.SelectedIndex == 3)
                    Caixa.Suprimento();
                //  sangria
                if (listaGerente.SelectedIndex == 4)
                    Caixa.Sangria();
            }

        }
    }
}
