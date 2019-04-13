/********************************************************************************
Title: T2TiPDV
Description: Procedimentos e fun??es da impressora fiscal.

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


using System;
using System.Windows.Forms;
using PafEcf.View;
using PafEcf.Util;
using PafEcf.DTO;
using PafEcf.Controller;

namespace PafEcf.Util
{

    public static class ECFUtil
    {

        #region Comandos do ECF

        public static void LeituraX()
        {
            try
            {
                DataModule.ACBrECF.LeituraX();
            }
            catch (Exception eError)
            {
                MessageBox.Show("Falha ao Realizar a Leitura X! Verifique a impressora e tente novamente!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.write(eError.ToString());
                return;
            }
        }

        public static void ReducaoZ()
        {
            string Estado;

            if (ImpressoraOK())
            {
                DateTime DataMovimento = DataModule.ACBrECF.DataMovimento;
                Estado = DataModule.ACBrECF.Estado.ToString();
                if (Estado != "RequerZ")
                {
                    try
                    {
                        if (Sessao.Instance.Movimento != null)
                        {
                            EncerraMovimento FEncerraMovimento = new EncerraMovimento();

                            if (FEncerraMovimento.ShowDialog() != DialogResult.OK)
                            {
                                MessageBox.Show("É Necessário Encerrar o Movimento Para Emitir a Redução Z!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                // Exercício - CancelaPreVendasPendentes(DataMovimento);
                            }
                            Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                        }
                    }
                    catch (Exception eError)
                    {
                        Log.write(eError.ToString());
                    }
                }

                Caixa.LabelMensagens.Text = "Redução Z - Aguarde!";

                DataModule.ACBrECF.Desativar();
                DataModule.ACBrECF.Ativar();

                PAFUtil.GravarR02R03();

                DataModule.ACBrECF.ReducaoZ();

                Estado = DataModule.ACBrECF.Estado.ToString();

                if (Estado != "Bloqueada")
                {
                    try
                    {
                        if (Sessao.Instance.Movimento != null)
                        {
                            Sessao.Instance.Movimento.DataFechamento = DataModule.ACBrECF.DataHora;
                            Sessao.Instance.Movimento.HoraFechamento = DataModule.ACBrECF.DataHora.ToString("hh:mm:ss");
                            Sessao.Instance.Movimento.StatusMovimento = "F";

                            EcfMovimentoController.GravaEcfMovimento(Sessao.Instance.Movimento);

                            EncerraMovimento FEncerraMovimento = new EncerraMovimento();
                            FEncerraMovimento.ImprimeFechamento();

                            IniciaMovimento FIniciaMovimento = new IniciaMovimento();
                            FIniciaMovimento.ShowDialog();
                        }
                    }
                    catch (Exception eError)
                    {
                        Log.write(eError.ToString());
                    }
                }

                try
                {
                    LogssController.AtualizarQuantidades();
                    PAFUtil.GerarRegistrosPAF(DataMovimento, DataMovimento, "T", "", "", "", Biblioteca.DataParaTexto(DataMovimento));
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }

                if (!DataModule.ACBrECF.MFD)
                    PrimeiraReducaoDoMes();

                Caixa.LabelMensagens.Text = "Movimento do ECF Encerrado.";
            }
        }

        public static void Suprimento(decimal Valor, string Descricao)
        {
            try
            {
                DataModule.ACBrECF.Suprimento(Valor, Descricao);
            }
            catch (Exception eError)
            {
                MessageBox.Show("Falha ao Registrar o Suprimento de Caixa! Verifique a impressora e tente novamente!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.write(eError.ToString());
                return;
            }
        }

        public static void Sangria(decimal Valor, string Descricao)
        {
            try
            {
                DataModule.ACBrECF.Sangria(Valor, Descricao);
            }
            catch (Exception eError)
            {
                MessageBox.Show("Falha ao Registrar a Sangria de Caixa! Verifique a impressora e tente novamente!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.write(eError.ToString());
                return;
            }
        }

        public static void AbreCupom(string CPFouCNPJ = "", string Nome = "", string Endereco = "")
        {
            try
            {
                DataModule.ACBrECF.AbreCupom(CPFouCNPJ, Nome, Endereco);
            }
            catch (Exception eError)
            {
                MessageBox.Show("Falha ao Abrir o Cupom! Verifique a impressora e tente novamente!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.write(eError.ToString());
                return;
            }
        }

        public static void CancelaCupom()
        {
            try
            {
                DataModule.ACBrECF.CancelaCupom();
            }
            catch (Exception eError)
            {
                MessageBox.Show("Falha ao Cancelar Cupom! Verifique a impressora e tente novamente!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.write(eError.ToString());
                return;
            }
            PAFUtil.AtualizaGT();
        }

        public static void SubTotalizaCupom(decimal? AscDesc)
        {
            try
            {
                DataModule.ACBrECF.SubtotalizaCupom(AscDesc.Value, "");
            }
            catch (Exception eError)
            {
                MessageBox.Show("Falha ao Sub Totalizar o Cupom!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.write(eError.ToString());
                return;
            }
        }

        public static void FechaCupom(string Observacao)
        {
            try
            {
                DataModule.ACBrECF.FechaCupom(Observacao);
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                MessageBox.Show("Falha ao Fechar o Cupom!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PAFUtil.AtualizaGT();
        }

        public static void VendeItem(EcfVendaDetalheDTO VendaDetalhe)
        {
            try
            {
                DataModule.ACBrECF.VendeItem(VendaDetalhe.Gtin, VendaDetalhe.Produto.DescricaoPdv, VendaDetalhe.EcfIcmsSt.ToString(), VendaDetalhe.Quantidade.Value, VendaDetalhe.ValorUnitario.Value);
            }
            catch (Exception eError)
            {
                MessageBox.Show("Falha ao Registrar Item!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.write(eError.ToString());
                return;
            }
        }

        public static void CancelaItem(int Item)
        {
            try
            {
                DataModule.ACBrECF.CancelaItemVendido(Item);
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                MessageBox.Show("Falha no Cancelamento do item!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        public static void EfetuaFormaPagamento(EcfTotalTipoPagamentoDTO TotalTipoPagamento)
        {
            try
            {
                DataModule.ACBrECF.EfetuaPagamento(TotalTipoPagamento.EcfTipoPagamento.Codigo, TotalTipoPagamento.Valor.Value);
            }
            catch (Exception eError)
            {
                MessageBox.Show("Falha ao Efetuar Pagamento!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.write(eError.ToString());
                return;
            }
        }

        #endregion Comandos do ECF

        #region Demais Procedimentos

        public static bool ImpressoraOK(int Msg = 1)
        {
            string Mensagem = "";
            string Estado = DataModule.ACBrECF.Estado.ToString();

            if ((Estado == "Não Inicializada") || (Estado == "Desconhecido") || (Estado == "Bloqueada"))
            {
                if (Msg == 1)
                {
                    Mensagem = "Estado da Impressora: " + Estado + ".";
                }
                else if (Msg == 2)
                {
                    Mensagem = "Não é possível iniciar o movimento pois o estado da impressora é: " + Estado + ".";
                    MessageBox.Show(Mensagem, "Erro do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void PrimeiraReducaoDoMes()
        {
            DateTime PrimeiroDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime UltimoDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            string DataInicio = Biblioteca.DataParaTexto(PrimeiroDia);
            string DataFim = Biblioteca.DataParaTexto(UltimoDia);

            string Filtro = "SerieEcf = " + Biblioteca.QuotedStr(Sessao.Instance.Configuracao.EcfImpressora.Serie) + " and (DataMovimento between " + Biblioteca.QuotedStr(DataInicio) + " and " + Biblioteca.QuotedStr(DataFim) + ")";
            if (R02Controller.ConsultaR02Lista(Filtro).Count == 1)
                DataModule.ACBrECF.LeituraMemoriaFiscal(PrimeiroDia, UltimoDia, true);
        }

        #endregion Demais Procedimentos

    }

}
