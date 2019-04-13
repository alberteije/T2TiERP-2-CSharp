/********************************************************************************
Title: T2TiPDV
Description: Controle de importacao e exportacao de arquivos

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

@author T2Ti.COM
@version 2.0
********************************************************************************/


using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using PafEcf.Controller;
using PafEcf.Util;
using Integrador.DTO;

namespace PafEcf.View
{

    public partial class FCargaPDV : Form
    {

        public static string PathVenda, PathCarga, PathCargaRemoto;
        public static string Tipo;
        public static string NomeArquivo;
        public static string[] Identificador;
        public static ProgressBar Barra;
        public static LogImportacaoController LogImportacaoController;

        public FCargaPDV()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            LogImportacaoController = new LogImportacaoController();

            try
            {
                XmlDocument ArquivoXML = new XmlDocument();
                ArquivoXML.Load(Application.StartupPath + "\\Conexao.xml");
                PathCargaRemoto = ArquivoXML.GetElementsByTagName("remoteApp").Item(0).InnerText.Trim();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }

            Barra = this.ProgressBar1;
            Timer1.Enabled = true;
        }


        public static Boolean ImportaCarga(string pRemoteApp)
        {
            string Linha = "";
            string LocalApp, Objeto, NomeCaixa = "";
            int i = 0;

            LocalApp = Application.StartupPath + "\\Script\\carga.txt";
            Barra.Maximum = 100;

            try
            {
                if (File.Exists(pRemoteApp))
                {
                    Application.DoEvents();
                    File.Copy(pRemoteApp, LocalApp, true);
                    StreamReader objReader = new StreamReader(LocalApp);
                    Objeto = Identificador[0];
                    NomeCaixa = Identificador[1];

                    while ((Linha = objReader.ReadLine()) != null)
                    {
                        i++;
                        if (Barra.Value == 100)
                        {
                            i = 0;
                        }
                        Barra.Value = i;

                        if (Objeto == "NF")
                        {
                            // Exercício: Converta a linha JSON para Objeto
                            NotaFiscalCabecalhoDTO ObjetoNotaFiscalCabecalho = new NotaFiscalCabecalhoDTO();
                            
                            ObjetoNotaFiscalCabecalho.IdGeradoCaixa = ObjetoNotaFiscalCabecalho.Id;
                            ObjetoNotaFiscalCabecalho.NomeCaixa = NomeCaixa;
                            ObjetoNotaFiscalCabecalho.DataSincronizacao = DateTime.Now;
                            ObjetoNotaFiscalCabecalho.HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                            ObjetoNotaFiscalCabecalho.Id = 0;

                            // Exercício: Hibernate.Save(ObjetoNotaFiscalCabecalho);

                            // Detalhes
                            for (int j = 0; j < ObjetoNotaFiscalCabecalho.ListaNotaFiscalDetalhe.Count; j++)
                            {
                                ObjetoNotaFiscalCabecalho.ListaNotaFiscalDetalhe[j].IdGeradoCaixa = ObjetoNotaFiscalCabecalho.ListaNotaFiscalDetalhe[j].Id;
                                ObjetoNotaFiscalCabecalho.ListaNotaFiscalDetalhe[j].NomeCaixa = NomeCaixa;
                                ObjetoNotaFiscalCabecalho.ListaNotaFiscalDetalhe[j].DataSincronizacao = DateTime.Now;
                                ObjetoNotaFiscalCabecalho.ListaNotaFiscalDetalhe[j].HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                                ObjetoNotaFiscalCabecalho.ListaNotaFiscalDetalhe[j].Id = 0;

                                // Exercício: Hibernate.Save(ObjetoNotaFiscalCabecalho.ListaNotaFiscalDetalhe[j]);

                                if (ObjetoNotaFiscalCabecalho.ListaNotaFiscalDetalhe[j].MovimentaEstoque == "S")
                                    AtualizarEstoque(ObjetoNotaFiscalCabecalho.ListaNotaFiscalDetalhe[j].Quantidade.Value, ObjetoNotaFiscalCabecalho.ListaNotaFiscalDetalhe[j].Produto.Id);
                            }                        
                        }
                        else if (Objeto == "VENDA")
                        {
                            // Exercício: Converta a linha JSON para Objeto
                            EcfVendaCabecalhoDTO ObjetoEcfVendaCabecalho = new EcfVendaCabecalhoDTO();

                            ObjetoEcfVendaCabecalho.IdGeradoCaixa = ObjetoEcfVendaCabecalho.Id;
                            ObjetoEcfVendaCabecalho.NomeCaixa = NomeCaixa;
                            ObjetoEcfVendaCabecalho.DataSincronizacao = DateTime.Now;
                            ObjetoEcfVendaCabecalho.HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                            ObjetoEcfVendaCabecalho.Id = 0;

                            // Exercício: Hibernate.Save(ObjetoEcfVendaCabecalho);

                            // Detalhes
                            for (int j = 0; j < ObjetoEcfVendaCabecalho.ListaEcfVendaDetalhe.Count; j++)
                            {
                                ObjetoEcfVendaCabecalho.ListaEcfVendaDetalhe[j].IdGeradoCaixa = ObjetoEcfVendaCabecalho.ListaEcfVendaDetalhe[j].Id;
                                ObjetoEcfVendaCabecalho.ListaEcfVendaDetalhe[j].NomeCaixa = NomeCaixa;
                                ObjetoEcfVendaCabecalho.ListaEcfVendaDetalhe[j].DataSincronizacao = DateTime.Now;
                                ObjetoEcfVendaCabecalho.ListaEcfVendaDetalhe[j].HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                                ObjetoEcfVendaCabecalho.ListaEcfVendaDetalhe[j].Id = 0;

                                // Exercício: Hibernate.Save(ObjetoEcfVendaCabecalho.ListaEcfVendaDetalhe[j]);

                                if (ObjetoEcfVendaCabecalho.ListaEcfVendaDetalhe[j].MovimentaEstoque == "S")
                                    AtualizarEstoque(ObjetoEcfVendaCabecalho.ListaEcfVendaDetalhe[j].Quantidade.Value, ObjetoEcfVendaCabecalho.ListaEcfVendaDetalhe[j].Produto.Id);
                            }

                            // Total Tipo Pagamento
                            for (int j = 0; j < ObjetoEcfVendaCabecalho.ListaEcfTotalTipoPagamento.Count; j++)
                            {
                                ObjetoEcfVendaCabecalho.ListaEcfTotalTipoPagamento[j].IdGeradoCaixa = ObjetoEcfVendaCabecalho.ListaEcfTotalTipoPagamento[j].Id;
                                ObjetoEcfVendaCabecalho.ListaEcfTotalTipoPagamento[j].NomeCaixa = NomeCaixa;
                                ObjetoEcfVendaCabecalho.ListaEcfTotalTipoPagamento[j].DataSincronizacao = DateTime.Now;
                                ObjetoEcfVendaCabecalho.ListaEcfTotalTipoPagamento[j].HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                                ObjetoEcfVendaCabecalho.ListaEcfTotalTipoPagamento[j].Id = 0;

                                // Exercício: Hibernate.Save(ObjetoEcfVendaCabecalho.ListaEcfTotalTipoPagamento[j]);
                            }

                        }
                        else if (Objeto == "MOVIMENTO")
                        {
                            // Exercício: Converta a linha JSON para Objeto
                            EcfMovimentoDTO ObjetoEcfMovimento = new EcfMovimentoDTO();

                            ObjetoEcfMovimento.IdGeradoCaixa = ObjetoEcfMovimento.Id;
                            ObjetoEcfMovimento.NomeCaixa = NomeCaixa;
                            ObjetoEcfMovimento.DataSincronizacao = DateTime.Now;
                            ObjetoEcfMovimento.HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                            ObjetoEcfMovimento.Id = 0;

                            // Exercício: Hibernate.Save(ObjetoEcfMovimento);

                            // Suprimento
                            for (int j = 0; j < ObjetoEcfMovimento.ListaEcfSuprimento.Count; j++)
                            {
                                ObjetoEcfMovimento.ListaEcfSuprimento[j].IdGeradoCaixa = ObjetoEcfMovimento.ListaEcfSuprimento[j].Id;
                                ObjetoEcfMovimento.ListaEcfSuprimento[j].NomeCaixa = NomeCaixa;
                                ObjetoEcfMovimento.ListaEcfSuprimento[j].DataSincronizacao = DateTime.Now;
                                ObjetoEcfMovimento.ListaEcfSuprimento[j].HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                                ObjetoEcfMovimento.ListaEcfSuprimento[j].Id = 0;

                                // Exercício: Hibernate.Save(ObjetoEcfMovimento.ListaEcfSuprimento[j]);
                            }

                            // Sangria
                            for (int j = 0; j < ObjetoEcfMovimento.ListaEcfSangria.Count; j++)
                            {
                                ObjetoEcfMovimento.ListaEcfSangria[j].IdGeradoCaixa = ObjetoEcfMovimento.ListaEcfSangria[j].Id;
                                ObjetoEcfMovimento.ListaEcfSangria[j].NomeCaixa = NomeCaixa;
                                ObjetoEcfMovimento.ListaEcfSangria[j].DataSincronizacao = DateTime.Now;
                                ObjetoEcfMovimento.ListaEcfSangria[j].HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                                ObjetoEcfMovimento.ListaEcfSangria[j].Id = 0;

                                // Exercício: Hibernate.Save(ObjetoEcfMovimento.ListaEcfSangria[j]);
                            }

                            // Fechamento
                            for (int j = 0; j < ObjetoEcfMovimento.ListaEcfFechamento.Count; j++)
                            {
                                ObjetoEcfMovimento.ListaEcfFechamento[j].IdGeradoCaixa = ObjetoEcfMovimento.ListaEcfFechamento[j].Id;
                                ObjetoEcfMovimento.ListaEcfFechamento[j].NomeCaixa = NomeCaixa;
                                ObjetoEcfMovimento.ListaEcfFechamento[j].DataSincronizacao = DateTime.Now;
                                ObjetoEcfMovimento.ListaEcfFechamento[j].HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                                ObjetoEcfMovimento.ListaEcfFechamento[j].Id = 0;

                                // Exercício: Hibernate.Save(ObjetoEcfMovimento.ListaEcfFechamento[j]);
                            }
                        }
                        else if (Objeto == "R02")
                        {
                            // Exercício: Converta a linha JSON para Objeto
                            R02DTO ObjetoR02 = new R02DTO();

                            ObjetoR02.IdGeradoCaixa = ObjetoR02.Id;
                            ObjetoR02.NomeCaixa = NomeCaixa;
                            ObjetoR02.DataSincronizacao = DateTime.Now;
                            ObjetoR02.HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                            ObjetoR02.Id = 0;

                            // Exercício: Hibernate.Save(ObjetoR02);

                            // Detalhes
                            for (int j = 0; j < ObjetoR02.ListaR03.Count; j++)
                            {
                                ObjetoR02.ListaR03[j].IdGeradoCaixa = ObjetoR02.ListaR03[j].Id;
                                ObjetoR02.ListaR03[j].NomeCaixa = NomeCaixa;
                                ObjetoR02.ListaR03[j].DataSincronizacao = DateTime.Now;
                                ObjetoR02.ListaR03[j].HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                                ObjetoR02.ListaR03[j].Id = 0;

                                // Exercício: Hibernate.Save(ObjetoR02.ListaR03[j]);
                            }
                        }
                        else if (Objeto == "R06")
                        {
                            // Exercício: Converta a linha JSON para Objeto
                            R06DTO ObjetoR06 = new R06DTO();

                            ObjetoR06.IdGeradoCaixa = ObjetoR06.Id;
                            ObjetoR06.NomeCaixa = NomeCaixa;
                            ObjetoR06.DataSincronizacao = DateTime.Now;
                            ObjetoR06.HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                            ObjetoR06.Id = 0;

                            // Exercício: Hibernate.Save(ObjetoR02);
                        }
                        else if (Objeto == "SINTEGRA60M")
                        {
                            // Exercício: Converta a linha JSON para Objeto
                            Sintegra60mDTO ObjetoSintegra60M = new Sintegra60mDTO();

                            ObjetoSintegra60M.IdGeradoCaixa = ObjetoSintegra60M.Id;
                            ObjetoSintegra60M.NomeCaixa = NomeCaixa;
                            ObjetoSintegra60M.DataSincronizacao = DateTime.Now;
                            ObjetoSintegra60M.HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                            ObjetoSintegra60M.Id = 0;

                            // Exercício: Hibernate.Save(ObjetoSintegra60M);

                            // Detalhes
                            for (int j = 0; j < ObjetoSintegra60M.Lista60A.Count; j++)
                            {
                                ObjetoSintegra60M.Lista60A[j].IdGeradoCaixa = ObjetoSintegra60M.Lista60A[j].Id;
                                ObjetoSintegra60M.Lista60A[j].NomeCaixa = NomeCaixa;
                                ObjetoSintegra60M.Lista60A[j].DataSincronizacao = DateTime.Now;
                                ObjetoSintegra60M.Lista60A[j].HoraSincronizacao = DateTime.Now.ToString("hh:mm:ss");
                                ObjetoSintegra60M.Lista60A[j].Id = 0;

                                // Exercício: Hibernate.Save(ObjetoSintegra60M.Lista60A[j]);
                            }
                        }
                    }

                    objReader.Close();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                return false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(PathCargaRemoto);
                foreach (FileInfo file in dir.GetFiles())
                {
                    Identificador = file.Name.Split('_');
                    ImportaCarga(file.FullName);
                    File.Delete(file.FullName);
                }
                Thread.Sleep(10);
                this.Refresh();
            }
            catch (Exception eError)
            {
                MessageBox.Show("Problemas na aplicação. A mesma será encerrada. Erro: " + eError.Message);
                Application.Exit();
            }
        }

        public static void AtualizarEstoque(Decimal pQuantidade, int pIdProduto)
        {
            string ComandoSQL = "update Produto set QuantidadeEstoque = QuantidadeEstoque + " + pQuantidade + " where Id= " + pIdProduto;
            // Exercício: Hibernate.ExecuteSql(ComandoSQL)
        }

    }

}
