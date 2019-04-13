/* *******************************************************************************
Title: T2TiPDV
Description: Janela Menu Fiscal que deve ser chamada de qualquer lugar da
aplicação

The MIT License

Copyright: Copyright (C) 2014 T2Ti.COM

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
@version 2.0
******************************************************************************* */


using System;
using System.Windows.Forms;

using PafEcf.Util;

namespace PafEcf.View
{

    public partial class MenuFiscal : Form
    {

        public MenuFiscal()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
        }

        private void FMenuFiscal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sessao.Instance.MenuAberto = false;
        }

        public void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLX_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a emissão da Leitura X?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DataModule.ACBrECF.PafMF_LX_Impressao();
        }

        private void btnLMFC_Click(object sender, EventArgs e)
        {
            LMF Lmf = new LMF();
            Lmf.ShowDialog();
        }

        private void btnArquivoMF_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja gerar o arquivo MF?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string NomeArquivo = Application.StartupPath + "\\ArquivoMF.txt";
                    DataModule.ACBrECF.PafMF_ArqMF(NomeArquivo);
                    MessageBox.Show("Arquivo armazenado em: " + NomeArquivo, "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }
            }
        }

        private void btnArqMFD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja gerar o arquivo MFD?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string NomeArquivo = Application.StartupPath + "\\ArquivoMF.txt";
                    DataModule.ACBrECF.PafMF_ArqMFD(NomeArquivo);
                    MessageBox.Show("Arquivo armazenado em: " + NomeArquivo, "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }
            }
        }

        private void btnIdentificacaoPafEcf_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja imprimir o relatorio IDENTIFICAÇÃO DO PAF-ECF?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                PAFUtil.IdentificacaoPafEcf();
        }

        private void btnVendasPeriodo_Click(object sender, EventArgs e)
        {
            VendasPeriodo FVendasPeriodo = new VendasPeriodo();
            FVendasPeriodo.ShowDialog();
        }

        private void btnIndiceTecnico_Click(object sender, EventArgs e)
        {
            /*
            Comentado para o PAF-ECF-SN
            FichaTecnica FFichaTecnica = new FichaTecnica();
            FFichaTecnica.ShowDialog();
             * */
        }

        private void btnParametrosConfig_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja imprimir o relatorio PARÂMETROS DE CONFIGURAÇÃO?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                PAFUtil.ParametrodeConfiguracao();
        }

        private void btnRegistrosPaf_Click(object sender, EventArgs e)
        {
            RegistrosPAF FRegistrosPaf = new RegistrosPAF();
            FRegistrosPaf.ShowDialog();
        }

    }

}

