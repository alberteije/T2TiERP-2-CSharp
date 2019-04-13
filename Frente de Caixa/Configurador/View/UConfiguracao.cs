/********************************************************************************
Title: T2TiPDV
Description: Configurações do PAF-ECF

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
           t2ti.com@gmail.com

@author Albert Eije
@version 1.0
********************************************************************************/


using System.Windows.Forms;
using System.Xml;
using ConfiguraPAFECF.Util;
using System;
using ConfiguraPAFECF.VO;
using ConfiguraPAFECF.Controller;
using ACBrFramework.ECF;
using System.Collections.Generic;
using PafEcf.View;

namespace ConfiguraPAFECF.View
{


    public partial class FConfiguracao : Form
    {

        private static List<PosicaoComponentesVO> ListaPosicaoComponentes;
        public static ConfiguracaoVO Configuracao;

        public FConfiguracao()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            FDataModule FDataModule = new FDataModule();
            GridComponentes.AutoGenerateColumns = false;
            Configuracao = new ConfiguracaoController().PegaConfiguracao();
            CarregaDadosConfiguracao();
            ConfiguraACBr();
            CarregaArquivoAuxiliar();
            comboBoxResolucao.SelectedIndex = 0;
        }

        public void CarregaArquivoAuxiliar()
        {
            XmlDocument ArquivoXML = new XmlDocument();
            ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");

            try
            {
                // *******************************************************************************************
                //   Aba Principal
                // *******************************************************************************************

                MemoSerieEcf.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("serie1").Item(0).InnerText.Trim());

                editGT.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("gt").Item(0).InnerText.Trim());

                editArquivos.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("arquivosMD5").Item(0).InnerText.Trim());

                editCNPJEstabelecimento.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("cnpjEstabelecimento").Item(0).InnerText.Trim());
                editRegistraPreVenda.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("registraPreVenda").Item(0).InnerText.Trim());
                editImprimeDAV.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("imprimeDAV").Item(0).InnerText.Trim());

                editCNPJ.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("cnpjSh").Item(0).InnerText.Trim());
                editNome_PAF.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("nomeSh").Item(0).InnerText.Trim());
                editMD5PrincipalEXE.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("MD5PrincipalExe").Item(0).InnerText.Trim());

                // *******************************************************************************************
                //   Aba Parâmetros
                // *******************************************************************************************

                cmbFun1.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("fun1").Item(0).InnerText.Trim());
                cmbFun2.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("fun2").Item(0).InnerText.Trim());
                cmbFun3.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("fun3").Item(0).InnerText.Trim());

                cmbPar1.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("par1").Item(0).InnerText.Trim());
                cmbPar2.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("par2").Item(0).InnerText.Trim());
                cmbPar3.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("par3").Item(0).InnerText.Trim());
                cmbPar4.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("par4").Item(0).InnerText.Trim());

                cmbCri1.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("cri1").Item(0).InnerText.Trim());
                cmbCri2.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("cri2").Item(0).InnerText.Trim());
                cmbCri3.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("cri3").Item(0).InnerText.Trim());
                cmbCri4.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("cri4").Item(0).InnerText.Trim());

                cmbApl1.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl1").Item(0).InnerText.Trim());
                cmbApl2.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl2").Item(0).InnerText.Trim());
                cmbApl3.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl3").Item(0).InnerText.Trim());
                cmbApl4.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl4").Item(0).InnerText.Trim());
                cmbApl5.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl5").Item(0).InnerText.Trim());
                cmbApl6.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl6").Item(0).InnerText.Trim());
                cmbApl7.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl7").Item(0).InnerText.Trim());

                cmbXXII1.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("XXII1").Item(0).InnerText.Trim());
                cmbXXII2.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("XXII2").Item(0).InnerText.Trim());

                cmbXXXVI1.Text = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("XXXVI1").Item(0).InnerText.Trim());

                // *******************************************************************************************
                //   Aba Conexao
                // *******************************************************************************************
                XmlDocument ArquivoConexao = new XmlDocument();
                ArquivoConexao.Load(Application.StartupPath + "\\Conexao.xml");

                editBD.Text = ArquivoConexao.GetElementsByTagName("bd").Item(0).InnerText.Trim();
                editImporta.Text = ArquivoConexao.GetElementsByTagName("remoteApp").Item(0).InnerText.Trim();

                //  Dados ECF
                if (FDataModule.ACBrECF.Ativo)
                {
                    SerieECF.Text = FDataModule.ACBrECF.NumSerie;
                    GTECF.Text = FDataModule.ACBrECF.GrandeTotal.ToString();
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }


        public void SalvarArquivoAuxiliar()
        {
            XmlDocument ArquivoXML = new XmlDocument();
            ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");

            try
            {
                // *******************************************************************************************
                //   Aba Principal
                // *******************************************************************************************

                ArquivoXML.GetElementsByTagName("serie1").Item(0).InnerText = Biblioteca.Encripta(SerieECF.Text.Trim());
                ArquivoXML.GetElementsByTagName("gt").Item(0).InnerText = Biblioteca.Encripta(GTECF.Text.Trim());

                ArquivoXML.GetElementsByTagName("cnpjEstabelecimento").Item(0).InnerText = Biblioteca.Encripta(editCNPJEstabelecimento.Text);
                ArquivoXML.GetElementsByTagName("registraPreVenda").Item(0).InnerText = Biblioteca.Encripta(editRegistraPreVenda.Text);
                ArquivoXML.GetElementsByTagName("imprimeDAV").Item(0).InnerText = Biblioteca.Encripta(editImprimeDAV.Text);

                ArquivoXML.GetElementsByTagName("cnpjSh").Item(0).InnerText = Biblioteca.Encripta(editCNPJ.Text);
                ArquivoXML.GetElementsByTagName("nomeSh").Item(0).InnerText = Biblioteca.Encripta(editNome_PAF.Text);
                ArquivoXML.GetElementsByTagName("MD5PrincipalExe").Item(0).InnerText = Biblioteca.Encripta(editMD5PrincipalEXE.Text);

                // *******************************************************************************************
                //   Aba Parâmetros
                // *******************************************************************************************

                ArquivoXML.GetElementsByTagName("fun1").Item(0).InnerText = Biblioteca.Encripta(cmbFun1.Text);
                ArquivoXML.GetElementsByTagName("fun2").Item(0).InnerText = Biblioteca.Encripta(cmbFun2.Text);
                ArquivoXML.GetElementsByTagName("fun3").Item(0).InnerText = Biblioteca.Encripta(cmbFun3.Text);

                ArquivoXML.GetElementsByTagName("par1").Item(0).InnerText = Biblioteca.Encripta(cmbPar1.Text);
                ArquivoXML.GetElementsByTagName("par2").Item(0).InnerText = Biblioteca.Encripta(cmbPar2.Text);
                ArquivoXML.GetElementsByTagName("par3").Item(0).InnerText = Biblioteca.Encripta(cmbPar3.Text);
                ArquivoXML.GetElementsByTagName("par4").Item(0).InnerText = Biblioteca.Encripta(cmbPar4.Text);

                ArquivoXML.GetElementsByTagName("cri1").Item(0).InnerText = Biblioteca.Encripta(cmbCri1.Text);
                ArquivoXML.GetElementsByTagName("cri2").Item(0).InnerText = Biblioteca.Encripta(cmbCri2.Text);
                ArquivoXML.GetElementsByTagName("cri3").Item(0).InnerText = Biblioteca.Encripta(cmbCri3.Text);
                ArquivoXML.GetElementsByTagName("cri4").Item(0).InnerText = Biblioteca.Encripta(cmbCri4.Text);

                ArquivoXML.GetElementsByTagName("apl1").Item(0).InnerText = Biblioteca.Encripta(cmbApl1.Text);
                ArquivoXML.GetElementsByTagName("apl2").Item(0).InnerText = Biblioteca.Encripta(cmbApl2.Text);
                ArquivoXML.GetElementsByTagName("apl3").Item(0).InnerText = Biblioteca.Encripta(cmbApl3.Text);
                ArquivoXML.GetElementsByTagName("apl4").Item(0).InnerText = Biblioteca.Encripta(cmbApl4.Text);
                ArquivoXML.GetElementsByTagName("apl5").Item(0).InnerText = Biblioteca.Encripta(cmbApl5.Text);
                ArquivoXML.GetElementsByTagName("apl6").Item(0).InnerText = Biblioteca.Encripta(cmbApl6.Text);
                ArquivoXML.GetElementsByTagName("apl7").Item(0).InnerText = Biblioteca.Encripta(cmbApl7.Text);

                ArquivoXML.GetElementsByTagName("XXII1").Item(0).InnerText = Biblioteca.Encripta(cmbXXII1.Text);
                ArquivoXML.GetElementsByTagName("XXII2").Item(0).InnerText = Biblioteca.Encripta(cmbXXII2.Text);

                ArquivoXML.GetElementsByTagName("XXXVI1").Item(0).InnerText = Biblioteca.Encripta(cmbXXXVI1.Text);

                ArquivoXML.Save(Application.StartupPath + "\\ArquivoAuxiliar.xml");

                // *******************************************************************************************
                //   Aba Conexao
                // *******************************************************************************************
                XmlDocument ArquivoConexao = new XmlDocument();
                ArquivoConexao.Load(Application.StartupPath + "\\Conexao.xml");

                ArquivoConexao.GetElementsByTagName("bd").Item(0).InnerText = editBD.Text;
                ArquivoConexao.GetElementsByTagName("remoteApp").Item(0).InnerText = editImporta.Text;

                ArquivoConexao.Save(Application.StartupPath + "\\Conexao.xml");

                MessageBox.Show("Dados armazenados com sucesso.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }


        public void CarregaDadosConfiguracao()
        {
            try
            {
                // *******************************************************************************************
                //   Aba Principais
                // *******************************************************************************************
                ComboBoxEmpresa.Text = Configuracao.IdEmpresa.ToString(); //TODO: - Carregue o nome da empresa
                ComboBoxCaixa.Text = Configuracao.IdCaixa.ToString(); //TODO: - Carregue os caixas disponíveis para seleção
                ComboBoxImpressoraFiscal.Text = Configuracao.IdImpressora.ToString(); //TODO: - Carregue as impressoras disponíveis para seleção
                editCfopEcf.Text = Configuracao.CFOPECF.ToString();
                editCfopNf2.Text = Configuracao.CFOPNF2.ToString();
                EditMensagemCupom.Text = Configuracao.MensagemCupom;
                EditPortaEcf.Text = Configuracao.PortaECF;
                EditBitsPorSegundo.Text = Configuracao.BitsPorSegundo.ToString();
                EditTimeOutEcf.Text = Configuracao.TimeOutECF.ToString();
                EditIntervaloEcf.Text = Configuracao.IntervaloECF.ToString();
                EditTituloTela.Text = Configuracao.TituloTelaCaixa;
                EditCaminhoImagemProdutos.Text = Configuracao.CaminhoImagensProdutos;
                EditCaminhoImagemMarketing.Text = Configuracao.CaminhoImagensMarketing;
                EditCaminhoImagemLayout.Text = Configuracao.CaminhoImagensLayout;
                EditSuprimento.Text = Configuracao.DescricaoSuprimento;
                EditSangria.Text = Configuracao.DescricaoSangria;
                EditIpServidor.Text = Configuracao.IpServidor;
                // TODO: - Adicione os itens faltantes na aba principal. Verifique a tabela CONFIGURACAO


                // *******************************************************************************************
                //   Aba Posição dos Componentes
                // *******************************************************************************************
                ListaPosicaoComponentes = new ConfiguracaoController().VerificaPosicaoTamanho();
                GridComponentes.DataSource = ListaPosicaoComponentes;

            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }


        public void ConfiguraACBr()
        {
            FDataModule.ACBrECF.Modelo = (ModeloECF)Convert.ToInt32(Configuracao.ModeloImpressora);
            FDataModule.ACBrECF.Device.Porta = Configuracao.PortaECF;
            FDataModule.ACBrECF.Device.TimeOut = Configuracao.TimeOutECF;
            FDataModule.ACBrECF.IntervaloAposComando = Configuracao.IntervaloECF;
            FDataModule.ACBrECF.Device.Baud = Configuracao.BitsPorSegundo;
            try
            {
                FDataModule.ACBrECF.Ativar();
                SinalVerde.Visible = true;
                SinalVermelho.Visible = false;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                MessageBox.Show("ECF com problemas ou desligado. Aplicação será aberta para somente consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SinalVerde.Visible = false;
                SinalVermelho.Visible = true;
                return;
            }

            FDataModule.ACBrECF.CarregaAliquotas();
            if (FDataModule.ACBrECF.Aliquotas.Length <= 0)
            {
                MessageBox.Show("ECF sem aliquotas cadastradas. Aplicação será aberta para somente consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            FDataModule.ACBrECF.CarregaFormasPagamento();
            if (FDataModule.ACBrECF.FormasPagamento.Length <= 0)
            {
                MessageBox.Show("ECF sem formas de pagamento cadastradas. Aplicação será aberta para somente consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Image1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO: - Implemente o método salvar no ConfiguracaoController para salvar os dados da Configuração
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FDataModule.ACBrECF.Desativar();
                SinalVerde.Visible = false;
                SinalVermelho.Visible = true;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                FDataModule.ACBrECF.Desativar();
                ConfiguraACBr();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CarregaArquivoAuxiliar();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SalvarArquivoAuxiliar();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FCaixa FCaixa = new FCaixa();
            FCaixa.ShowDialog();
        }

    }

}
