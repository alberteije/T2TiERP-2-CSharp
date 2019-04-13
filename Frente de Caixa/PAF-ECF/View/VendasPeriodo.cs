/********************************************************************************
Title: T2TiPDV
Description: Permite a emissão dos relatorios do Sintegra e SPED Fiscal

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
********************************************************************************/


using PafEcf.ServidorReference;
using PafEcf.Util;
using System;
using System.Windows.Forms;


namespace PafEcf.View
{

    public partial class VendasPeriodo : Form
    {

        public VendasPeriodo()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            this.cbGerarSintegra.Checked = true;
            ComboBoxConvenio.SelectedIndex = 0;
            ComboBoxNaturezaInformacoes.SelectedIndex = 0;
            ComboBoxFinalidadeArquivo.SelectedIndex = 0;
            ComboBoxVersaoLeiauteSped.SelectedIndex = 0;
            ComboBoxFinalidadeArquivoSped.SelectedIndex = 0;
            ComboBoxPerfilSped.SelectedIndex = 0;
            mkeDataIni.Text = DateTime.Now.ToString("dd/MM/yyyy");
            mkeDataFim.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void FVendasPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                Confirma();
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botaoConfirma_Click(object sender, EventArgs e)
        {
            Confirma();
        }

        private void cbGerarSintegra_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedIndex = 0;
        }

        private void cbGerarSped_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedIndex = 1;
        }

        private void Confirma()
        {
            int CodigoConvenio, NaturezaInformacao, FinalidadeArquivo, Versao, Perfil;
            if (cbGerarSintegra.Checked)
            {
                if (MessageBox.Show("Deseja gerar o arquivo do SINTEGRA (Convenio 57/95)?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CodigoConvenio = Convert.ToInt32(ComboBoxConvenio.Text.Substring(0, 1));
                    NaturezaInformacao = Convert.ToInt32(ComboBoxNaturezaInformacoes.Text.Substring(0, 1));
                    FinalidadeArquivo = Convert.ToInt32(ComboBoxFinalidadeArquivo.Text.Substring(0, 1));

                    ArquivoDTO ArquivoGerado;
                    PafEcf.ServidorReference.ServiceServidor Service = new PafEcf.ServidorReference.ServiceServidor();
                    ArquivoGerado = Service.GerarSintegra(
                        mkeDataIni.Text,
                        mkeDataFim.Text,
                        CodigoConvenio.ToString(),
                        FinalidadeArquivo.ToString(),
                        NaturezaInformacao.ToString(),
                        Sessao.Instance.Configuracao.EcfEmpresa.Id.ToString(),
                        "0",
                        "1"
                         );

                    string CaminhoArquivo = SalvaArquivoTempLocal(ArquivoGerado);
                    MessageBox.Show("Arquivo armazenado em: " + CaminhoArquivo, "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (cbGerarSped.Checked)
            {
                if (MessageBox.Show("Deseja gerar o arquivo do SPED FISCAL (Ato COTEPE/ICMS 09/08)?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Versao = ComboBoxVersaoLeiauteSped.SelectedIndex;
                    FinalidadeArquivo = ComboBoxVersaoLeiauteSped.SelectedIndex;
                    Perfil = ComboBoxPerfilSped.SelectedIndex;

                    ArquivoDTO ArquivoGerado;
                    PafEcf.ServidorReference.ServiceServidor Service = new PafEcf.ServidorReference.ServiceServidor();
                    ArquivoGerado = Service.GerarSped(
                        mkeDataIni.Text,
                        mkeDataFim.Text,
                        Versao.ToString(),
                        FinalidadeArquivo.ToString(),
                        Perfil.ToString(),
                        Sessao.Instance.Configuracao.EcfEmpresa.Id.ToString(),
                        "0",
                        "1"
                         );

                    string CaminhoArquivo = SalvaArquivoTempLocal(ArquivoGerado);
                    MessageBox.Show("Arquivo armazenado em: " + CaminhoArquivo, "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string SalvaArquivoTempLocal(ArquivoDTO pArquivo)
        {
            try
            {
                string caminhoTemp = System.IO.Path.GetTempPath() + "VendasPeriodoTemp.txt";

                if (!System.IO.File.Exists(caminhoTemp))
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(caminhoTemp, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                    {
                        //pArquivo.memoryStream.WriteTo(fs);
                        pArquivo.memoryStream.ToString();
                        fs.Close();
                    }
                }
                return caminhoTemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
