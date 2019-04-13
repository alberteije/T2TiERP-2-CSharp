/* *******************************************************************************
  Title: T2TiPDV
  Description: Gerar Arquivo Eletronico de Estoque.

  The MIT License

  Copyright: Copyright (C) 2012 T2Ti.COM

  Permission is hereby granted, free of charge, to any person
  obtaining a copy of this software and associated documentation
  files (the "Software"), to deal in the Software without
  restriction, including without limitation the rights to use,
  copy, modify, merge, publish, distribute, sublicense, and/or sell
  copies of the Software, and to permit persons to whom the
  Software is furnished to do so, subject to the following
  conditions:

  The above copyright notice and this permission notice shall be
  included in all copies or substantial portions of the Software.

  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
  EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
  OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
  NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
  HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
  WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
  FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
  OTHER DEALINGS IN THE SOFTWARE.

  The author may be contacted at:
  alberteije@gmail.com

  @author T2Ti.COM
  @version 1.0
  ******************************************************************************* */


using PafEcf.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PafEcf.View
{

    public partial class RegistrosPAF : Form
    {

        public RegistrosPAF()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
        }

        private void FEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                Confirma();
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        private void cbEstoqueTotal_Click(object sender, EventArgs e)
        {
            /*
            RadioGroup2.Visible = false;
            panCodigo.Visible = false;
            panDescricao.Visible = false;
             */ 
        }

        private void cbEstoqueParcial_Click(object sender, EventArgs e)
        {
            /*
            RadioGroup2.Visible = true;
            panCodigo.Visible = true;
            panDescricao.Visible = true;
            cbCodigoProduto.PerformClick();
            cbCodigoProduto.Focus();
             */ 
        }

        private void cbCodigoProduto_Click(object sender, EventArgs e)
        {
            /*
            panCodigo.Enabled = true;
            panCodigo.BorderStyle = BorderStyle.Fixed3D;
            panDescricao.Enabled = false;
            panDescricao.BorderStyle = BorderStyle.None;
             */ 
        }

        private void cbDescricaoMercadoria_Click(object sender, EventArgs e)
        {
            /*
            panCodigo.Enabled = false;
            panCodigo.BorderStyle = BorderStyle.None;
            panDescricao.Enabled = true;
            panDescricao.BorderStyle = BorderStyle.Fixed3D;
             */ 
        }

        private void botaoConfirma_Click(object sender, EventArgs e)
        {
            Confirma();
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Confirma()
        {
            if (MessageBox.Show("Deseja gerar o arquivo com os Registros do PAF?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PAFUtil.GerarRegistrosPAF(Convert.ToDateTime(mkeDataIni.Text), Convert.ToDateTime(mkeDataFim.Text), "");

                /*

                Comentado para o PAF-ECF-SN
                 
                //  Estoque Total
                if (cbEstoqueTotal.Checked)
                {
                    PAFUtil.GerarRegistrosPAF(Convert.ToDateTime(mkeDataIni.Text), Convert.ToDateTime(mkeDataFim.Text), "T");
                }

                //  Estoque Parcial
                if (cbEstoqueParcial.Checked)
                {
                    //  por codigo
                    if (cbCodigoProduto.Checked)
                        PAFUtil.GerarRegistrosPAF(Convert.ToDateTime(mkeDataIni.Text), Convert.ToDateTime(mkeDataFim.Text), "T", "C", editInicio.Text, editFim.Text);
                    //  por nome
                    if (cbDescricaoMercadoria.Checked)
                        PAFUtil.GerarRegistrosPAF(Convert.ToDateTime(mkeDataIni.Text), Convert.ToDateTime(mkeDataFim.Text), "T", "N", editNomeInicial.Text, editNomeFinal.Text);
                }
                 * */
            }
        }

    }

}
