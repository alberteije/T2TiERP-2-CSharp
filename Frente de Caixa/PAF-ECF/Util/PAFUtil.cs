/********************************************************************************
Title: T2TiPDV
Description: Funções e procedimentos do PAF;

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
using System.Data;
using System.IO;
using System.Windows.Forms;
using PafEcf.DTO;
using PafEcf.Controller;
using System.Collections.Generic;
using PafEcf.View;
using PafEcf.Util;
using ACBrFramework.PAF;
using System.Xml;
using System.Runtime.Serialization.Json;

namespace PafEcf.Util
{

    public static class PAFUtil
    {

        static string ValorHashRegistro, NomeArquivo, DataInicio, DataFim, Filtro = "";

        #region Geração Arquivo Registros PAF

        public static void GerarRegistrosPAF(DateTime pDataInicio, DateTime pDataFim, string pEstoqueTotalOuParcial, string pEstoqueCodigoOuNome = "", string pEstoqueCriterioUm = "", string pEstoqueCriterioDois = "", string pDataMovimento = "")
        {
            try
            {
                DataInicio = Biblioteca.DataParaTexto(pDataInicio);
                DataFim = Biblioteca.DataParaTexto(pDataFim);

                // U1 - Identificação do Estabelecimento Usuário do PAF-ECF
                GerarRegistroU();

                // A2 - Total Diário de Meios de Pagamento
                GerarRegistroA2();

                // P2 - Relação das Mercadorias e Serviços
                GerarRegistroP2();

                // E2 - Relação das Mercadorias em Estoque
                if (pEstoqueTotalOuParcial == "T")
                    Filtro = "Id>0";
                else
                {
                    if (pEstoqueCodigoOuNome == "C")
                        Filtro = "Id between " + pEstoqueCriterioUm + " and " + pEstoqueCriterioDois;
                    else if (pEstoqueCodigoOuNome == "N")
                    {
                        pEstoqueCriterioUm = "%" + pEstoqueCriterioUm.Trim() + "%";
                        pEstoqueCriterioDois = "%" + pEstoqueCriterioDois.Trim() + "%";
                        Filtro = "Nome LIKE " + Biblioteca.QuotedStr(pEstoqueCriterioUm) + " or " + "Nome LIKE " + Biblioteca.QuotedStr(pEstoqueCriterioDois);
                    };
                };
                GerarRegistroE2();

                // E3 - Identificação do ECF que Emitiu o Documento Base para a Atualização do Estoque
                GerarRegistroE3();


                // D2 - Relação dos DAV Emitidos
                // D3 - Detalhe do DAV
                GerarRegistrosDAV();

                // R01 a R07
                GerarRegistrosR();

                /*
                  O arquivo a que se refere o item 5 deverá ser denominado no formato CCCCCCNNNNNNNNNNNNNNDDMMAAAA.txt, s}o:
                  a) “CCCCCC” o Código Nacional de Identificação de ECF relativo ao ECF a que se refere o movimento informado;
                  b) “NNNNNNNNNNNNNN” os 14 (quatorze) últimos dígitos do número de fabricação do ECF;
                  c) “DDMMAAAA” a data (dia/mês/ano) do movimento informado no arquivo.
                */
                NomeArquivo = Sessao.Instance.Configuracao.EcfImpressora.Codigo;

                if (Sessao.Instance.Configuracao.EcfImpressora.Serie.Length > 14)
                    NomeArquivo = NomeArquivo + Biblioteca.Right(Sessao.Instance.Configuracao.EcfImpressora.Serie, 14);
                else
                {
                    string Complemento = new string('0', 14 - Sessao.Instance.Configuracao.EcfImpressora.Serie.Length) + Sessao.Instance.Configuracao.EcfImpressora.Serie;
                    NomeArquivo = NomeArquivo + Complemento;
                }

                if (pDataMovimento == "")
                    NomeArquivo = NomeArquivo + Convert.ToDateTime(DateTime.Now).ToString("ddmmyyyy");
                else
                    NomeArquivo = NomeArquivo + Convert.ToDateTime(pDataMovimento).ToString("ddmmyyyy");

                NomeArquivo = NomeArquivo + ".txt";

                DataModule.ACBrPAF.SaveFileTXT_RegistrosECF(NomeArquivo);
                MessageBox.Show("Arquivo armazenado em: " + NomeArquivo, "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception eError)
            {
                MessageBox.Show("Ocorreu um erro durante a geração do arquivo. Verifique o LOG.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                Log.write(eError.ToString());
            }
        }

        public static void GerarRegistroU()
        {
            try
            {
                // ALTERAR - CONSULTAR DAV NO BANCO DA RETAGUARDA

                if (LogssController.VerificarQuantidades())
                    DataModule.ACBrPAF.PAF_U.RegistroU1.CNPJ = Sessao.Instance.Configuracao.EcfEmpresa.Cnpj;
                else
                    DataModule.ACBrPAF.PAF_U.RegistroU1.CNPJ = "????????????????????????";

                DataModule.ACBrPAF.PAF_U.RegistroU1.IE = Sessao.Instance.Configuracao.EcfEmpresa.InscricaoEstadual;
                DataModule.ACBrPAF.PAF_U.RegistroU1.IM = Sessao.Instance.Configuracao.EcfEmpresa.InscricaoMunicipal;
                DataModule.ACBrPAF.PAF_U.RegistroU1.RazaoSocial = Sessao.Instance.Configuracao.EcfEmpresa.RazaoSocial;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static void GerarRegistroA2()
        {
            try
            {
                Filtro = "(DataVenda between " + Biblioteca.QuotedStr(DataInicio) + " and " + Biblioteca.QuotedStr(DataFim) + ")";
                IList<ViewTotalPagamentoDataDTO> ListaA2 = ViewTotalPagamentoDataController.ConsultaViewTotalPagamentoDataLista(Filtro);

                MemoryStream StreamJson = new MemoryStream();
                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(EcfTotalTipoPagamentoDTO));

                if (ListaA2 != null)
                {
                    for (int i = 0; i < ListaA2.Count; i++)
                    {
                        ACBrPAFRegistroA2 RegistroA2 = new ACBrPAFRegistroA2();

                        // Consulta todos os pagamentos desse tipo para observar se houve alguma alteração e se houver invalida o registro
                        Filtro = "DataVenda = " + Biblioteca.QuotedStr(Biblioteca.DataParaTexto(ListaA2[i].DataVenda.Value)) + " AND IdEcfTipoPagamento = " + ListaA2[i].IdTipoPagamento.ToString();
                        IList<EcfTotalTipoPagamentoDTO> ListaPagamentos = EcfTotalTipoPagamentoController.ConsultaEcfTotalTipoPagamentoLista(Filtro);
                        for (int j = 0; j < ListaPagamentos.Count; i++)
                        {
                            ValorHashRegistro = ListaPagamentos[j].Logss;
                            ListaPagamentos[j].Id = 0;
                            ListaPagamentos[j].Logss = "0";

                            SerializaJson.WriteObject(StreamJson, ListaPagamentos[j]);
                            StreamReader LerStreamJson = new StreamReader(StreamJson);
                            StreamJson.Position = 0;
                            string RegistroGravado = LerStreamJson.ReadToEnd();

                            RegistroA2.RegistroValido = (ValorHashRegistro == RegistroGravado);
                        }

                        RegistroA2.Data = ListaA2[i].DataVenda.Value;
                        RegistroA2.MeioPagamento = ListaA2[i].Descricao;
                        RegistroA2.CodigoTipoDocumento = CodigoTipoDocumento.CupomFiscal;
                        RegistroA2.Valor = ListaA2[i].ValorApurado.Value;

                        DataModule.ACBrPAF.PAF_A.RegistroA2.Add(RegistroA2);
                    }
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static void GerarRegistroP2()
        {
            try
            {
                IList<ProdutoDTO> ListaProduto = ProdutoController.ConsultaProdutoLista("Id > 0");

                MemoryStream StreamJson = new MemoryStream();
                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(ProdutoDTO));

                if (ListaProduto != null)
                {
                    for (int i = 0; i < ListaProduto.Count; i++)
                    {
                        ACBrPAFRegistroP2 RegistroP2 = new ACBrPAFRegistroP2();

                        ValorHashRegistro = ListaProduto[i].Logss;
                        ListaProduto[i].Logss = "0";

                        SerializaJson.WriteObject(StreamJson, ListaProduto[i]);
                        StreamReader LerStreamJson = new StreamReader(StreamJson);
                        StreamJson.Position = 0;
                        string RegistroGravado = LerStreamJson.ReadToEnd();

                        RegistroP2.RegistroValido = (ValorHashRegistro == RegistroGravado);

                        RegistroP2.COD_MERC_SERV = ListaProduto[i].Gtin;
                        RegistroP2.DESC_MERC_SERV = ListaProduto[i].DescricaoPdv;
                        RegistroP2.UN_MED = ListaProduto[i].UnidadeProduto.Sigla;
                        RegistroP2.IAT = ListaProduto[i].Iat;
                        RegistroP2.IPPT = ListaProduto[i].Ippt;
                        RegistroP2.ST = ListaProduto[i].PafPSt;
                        RegistroP2.ALIQ = ListaProduto[i].TaxaIcms.Value;
                        RegistroP2.VL_UNIT = ListaProduto[i].ValorVenda.Value;

                        DataModule.ACBrPAF.PAF_P.RegistroP2.Add(RegistroP2);
                    }
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static void GerarRegistroE2()
        {
            try
            {
                IList<ProdutoDTO> ListaProduto = ProdutoController.ConsultaProdutoLista(Filtro);

                MemoryStream StreamJson = new MemoryStream();
                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(ProdutoDTO));

                if (ListaProduto != null)
                {
                    for (int i = 0; i < ListaProduto.Count; i++)
                    {
                        ACBrPAFRegistroE2 RegistroE2 = new ACBrPAFRegistroE2();

                        ValorHashRegistro = ListaProduto[i].Logss;
                        ListaProduto[i].Logss = "0";

                        SerializaJson.WriteObject(StreamJson, ListaProduto[i]);
                        StreamReader LerStreamJson = new StreamReader(StreamJson);
                        StreamJson.Position = 0;
                        string RegistroGravado = LerStreamJson.ReadToEnd();

                        RegistroE2.RegistroValido = (ValorHashRegistro == RegistroGravado);

                        RegistroE2.COD_MERC = ListaProduto[i].Gtin;
                        RegistroE2.DESC_MERC = ListaProduto[i].DescricaoPdv;
                        RegistroE2.UN_MED = ListaProduto[i].UnidadeProduto.Sigla;
                        RegistroE2.QTDE_EST = ListaProduto[i].QuantidadeEstoque.Value;

                        DataModule.ACBrPAF.PAF_E.RegistroE2.Add(RegistroE2);
                    }
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static void GerarRegistroE3()
        {
            try
            {
                XmlDocument ArquivoXML = new XmlDocument();
                ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");
                DateTime DataEstoque = Convert.ToDateTime(ArquivoXML.GetElementsByTagName("dataEstoque").Item(0).InnerText.Trim());

                Filtro = "DataEstoque = " + Biblioteca.QuotedStr(Biblioteca.DataParaTexto(DataEstoque));

                EcfE3DTO RegistroE3 = EcfE3Controller.ConsultaEcfE3(Filtro);

                MemoryStream StreamJson = new MemoryStream();
                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(EcfE3DTO));

                if (RegistroE3 != null)
                {
                    ValorHashRegistro = RegistroE3.Logss;
                    RegistroE3.Logss = "0";

                    SerializaJson.WriteObject(StreamJson, RegistroE3);
                    StreamReader LerStreamJson = new StreamReader(StreamJson);
                    StreamJson.Position = 0;
                    string RegistroGravado = LerStreamJson.ReadToEnd();

                    DataModule.ACBrPAF.PAF_E.RegistroE3.RegistroValido = (ValorHashRegistro == RegistroGravado);

                    DataModule.ACBrPAF.PAF_E.RegistroE3.NumeroFabricacao = RegistroE3.SerieEcf;
                    DataModule.ACBrPAF.PAF_E.RegistroE3.MFAdicional = RegistroE3.MfAdicional;
                    DataModule.ACBrPAF.PAF_E.RegistroE3.TipoECF = RegistroE3.TipoEcf;
                    DataModule.ACBrPAF.PAF_E.RegistroE3.MarcaECF = RegistroE3.MarcaEcf;
                    DataModule.ACBrPAF.PAF_E.RegistroE3.ModeloECF = RegistroE3.ModeloEcf;
                    DataModule.ACBrPAF.PAF_E.RegistroE3.DataEstoque = RegistroE3.DataEstoque.Value;
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static void GerarRegistrosDAV()
        {
            try
            {
                using (PafEcf.ServidorReference.ServiceServidor Servico = new PafEcf.ServidorReference.ServiceServidor())
                {
                    string RegistroGravado = "";
                    MemoryStream StreamJson = new MemoryStream();
                    DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(PafEcf.ServidorReference.DavCabecalhoDTO));

                    PafEcf.ServidorReference.DavCabecalhoDTO Dav = new PafEcf.ServidorReference.DavCabecalhoDTO();
                    Dav.Situacao = "E";
                    IList<PafEcf.ServidorReference.DavCabecalhoDTO> ListaDAV = Servico.SelectDavCabecalho(Dav);

                    if (ListaDAV != null)
                    {

                        for (int i = 0; i < ListaDAV.Count; i++)
                        {
                            ACBrPAFRegistroD2 RegistroD2 = new ACBrPAFRegistroD2();

                            ValorHashRegistro = ListaDAV[i].Logss;
                            ListaDAV[i].Logss = "0";

                            SerializaJson.WriteObject(StreamJson, ListaDAV[i]);
                            StreamReader LerStreamJson = new StreamReader(StreamJson);
                            StreamJson.Position = 0;
                            RegistroGravado = LerStreamJson.ReadToEnd();

                            RegistroD2.RegistroValido = (ValorHashRegistro == RegistroGravado);

                            RegistroD2.NUM_FAB = Sessao.Instance.Configuracao.EcfImpressora.Serie;
                            RegistroD2.MF_ADICIONAL = Sessao.Instance.Configuracao.EcfImpressora.Mfd;
                            RegistroD2.TIPO_ECF = Sessao.Instance.Configuracao.EcfImpressora.Tipo;
                            RegistroD2.MARCA_ECF = Sessao.Instance.Configuracao.EcfImpressora.Marca;
                            RegistroD2.MODELO_ECF = Sessao.Instance.Configuracao.EcfImpressora.Modelo;
                            RegistroD2.COO = ListaDAV[i].Coo.ToString();
                            RegistroD2.NUMERO_ECF = ListaDAV[i].NumeroEcf;
                            RegistroD2.NOME_CLIENTE = ListaDAV[i].NomeDestinatario;
                            RegistroD2.CPF_CNPJ = ListaDAV[i].CpfCnpjDestinatario;
                            RegistroD2.NUM_DAV = ListaDAV[i].NumeroDav;
                            RegistroD2.DT_DAV = ListaDAV[i].DataEmissao.Value;
                            RegistroD2.TIT_DAV = "ORCAMENTO";
                            RegistroD2.VLT_DAV = ListaDAV[i].Valor.Value;

                            if (ListaDAV[i].ListaDavDetalhe.Length > 0)
                            {
                                for (int j = 0; i < ListaDAV[i].ListaDavDetalhe.Length; i++)
                                {
                                    ACBrPAFRegistroD3 RegistroD3 = new ACBrPAFRegistroD3();

                                    ValorHashRegistro = ListaDAV[i].ListaDavDetalhe[j].Logss;
                                    ListaDAV[i].Logss = "0";

                                    StreamJson = new MemoryStream();
                                    SerializaJson = new DataContractJsonSerializer(typeof(PafEcf.ServidorReference.DavDetalheDTO));
                                    SerializaJson.WriteObject(StreamJson, ListaDAV[i].ListaDavDetalhe[j]);
                                    LerStreamJson = new StreamReader(StreamJson);
                                    StreamJson.Position = 0;
                                    RegistroGravado = LerStreamJson.ReadToEnd();

                                    RegistroD3.RegistroValido = (ValorHashRegistro == RegistroGravado);

                                    RegistroD3.DT_INCLUSAO = ListaDAV[i].DataEmissao.Value;
                                    RegistroD3.NUM_ITEM = ListaDAV[i].ListaDavDetalhe[j].Item.Value;
                                    RegistroD3.COD_ITEM = ListaDAV[i].ListaDavDetalhe[j].GtinProduto;
                                    RegistroD3.DESC_ITEM = ListaDAV[i].ListaDavDetalhe[j].NomeProduto;
                                    RegistroD3.QTDE_ITEM = ListaDAV[i].ListaDavDetalhe[j].Quantidade.Value;
                                    RegistroD3.UNI_ITEM = ListaDAV[i].ListaDavDetalhe[j].UnidadeProduto;
                                    RegistroD3.VL_UNIT = ListaDAV[i].ListaDavDetalhe[j].ValorUnitario.Value;
                                    RegistroD3.VL_DESCTO = 0;
                                    RegistroD3.VL_ACRES = 0;
                                    RegistroD3.IND_CANC = ListaDAV[i].ListaDavDetalhe[j].Cancelado;
                                    RegistroD3.VL_TOTAL = ListaDAV[i].ListaDavDetalhe[j].ValorTotal.Value;

                                    RegistroD2.RegistroD3.Add(RegistroD3);
                                }
                            }

                            //Exercício: Implemente o Registro D4

                            DataModule.ACBrPAF.PAF_D.RegistroD2.Add(RegistroD2);
                        }
                    
                    }
                }
            }
            catch (Exception ex)
            {
                Log.write(ex.ToString());
                throw ex;
            }
        }

        public static void GerarRegistrosR()
        {
            IList<R02DTO> ListaR02;
            IList<R03DTO> ListaR03;
            IList<EcfVendaCabecalhoDTO> ListaR04;
            IList<EcfVendaDetalheDTO> ListaR05;
            IList<R06DTO> ListaR06;
            IList<R07DTO> ListaR07;
            IList<EcfTotalTipoPagamentoDTO> ListaR07IdR04;

            try
            {
                for (int h = 0; h <= Sessao.Instance.ListaImpressora.Count - 1; h++)
                {

                    //  Registro R01 - Identificação do ECF, do Usuário, do PAF-ECF e da Empresa DesenDTOlvedora e Dados do Arquivo
                    MemoryStream StreamJson = new MemoryStream();
                    DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(R01DTO));
                    ValorHashRegistro = Sessao.Instance.R01.Logss;
                    Sessao.Instance.R01.Logss = "0";

                    SerializaJson.WriteObject(StreamJson, Sessao.Instance.R01);
                    StreamReader LerStreamJson = new StreamReader(StreamJson);
                    StreamJson.Position = 0;
                    string RegistroGravado = LerStreamJson.ReadToEnd();

                    ACBrPAFRegistroR1 RegistroR01 = new ACBrPAFRegistroR1();

                    RegistroR01.RegistroValido = (ValorHashRegistro == RegistroGravado);
                    RegistroR01.NUM_FAB = Sessao.Instance.R01.SerieEcf;
                    RegistroR01.MF_ADICIONAL = Sessao.Instance.ListaImpressora[h].Mfd;
                    RegistroR01.TIPO_ECF = Sessao.Instance.ListaImpressora[h].Tipo;
                    RegistroR01.MARCA_ECF = Sessao.Instance.ListaImpressora[h].Marca;
                    RegistroR01.MODELO_ECF = Sessao.Instance.ListaImpressora[h].Modelo;
                    RegistroR01.VERSAO_SB = Sessao.Instance.ListaImpressora[h].Versao;
                    RegistroR01.DT_INST_SB = Sessao.Instance.ListaImpressora[h].DataInstalacaoSb.Value;
                    RegistroR01.HR_INST_SB = Convert.ToDateTime(Sessao.Instance.ListaImpressora[h].HoraInstalacaoSb);
                    RegistroR01.NUM_SEQ_ECF = Sessao.Instance.ListaImpressora[h].Numero.Value;
                    RegistroR01.CNPJ = Sessao.Instance.Configuracao.EcfEmpresa.Cnpj;
                    RegistroR01.IE = Sessao.Instance.Configuracao.EcfEmpresa.InscricaoEstadual;
                    RegistroR01.CNPJ_SH = Sessao.Instance.R01.CnpjSh;
                    RegistroR01.IE_SH = Sessao.Instance.R01.InscricaoEstadualSh;
                    RegistroR01.IM_SH = Sessao.Instance.R01.InscricaoMunicipalSh;
                    RegistroR01.NOME_SH = Sessao.Instance.R01.DenominacaoSh;
                    RegistroR01.NOME_PAF = Sessao.Instance.R01.NomePafEcf;
                    RegistroR01.VER_PAF = Sessao.Instance.R01.VersaoPafEcf;
                    RegistroR01.COD_MD5 = Sessao.Instance.R01.Md5PafEcf;
                    RegistroR01.DT_INI = Convert.ToDateTime(DataInicio);
                    RegistroR01.DT_FIN = Convert.ToDateTime(DataFim);
                    RegistroR01.ER_PAF_ECF = Sessao.Instance.R01.VersaoEr;

                    // Registro R02 - Relação de Reduções Z
                    // Registro R03 - Detalhe da Redução Z
                    Filtro = "SerieEcf = " + Biblioteca.QuotedStr(Sessao.Instance.ListaImpressora[h].Serie) + " AND (DataMovimento between " + Biblioteca.QuotedStr(DataInicio) + " and " + Biblioteca.QuotedStr(DataFim) + ")";
                    ListaR02 = R02Controller.ConsultaR02Lista(Filtro);
                    if (ListaR02 != null)
                    {
                        for (int i = 0; i <= ListaR02.Count - 1; i++)
                        {
                            StreamJson = new MemoryStream();
                            SerializaJson = new DataContractJsonSerializer(typeof(R02DTO));
                            ValorHashRegistro = ListaR02[i].Logss;
                            ListaR02[i].Logss = "0";

                            SerializaJson.WriteObject(StreamJson, ListaR02[i]);
                            LerStreamJson = new StreamReader(StreamJson);
                            StreamJson.Position = 0;
                            RegistroGravado = LerStreamJson.ReadToEnd();

                            ACBrPAFRegistroR2 RegistroR02 = new ACBrPAFRegistroR2();

                            RegistroR02.RegistroValido = (ValorHashRegistro == RegistroGravado);
                            RegistroR02.NUM_USU = ListaR02[i].IdOperador;
                            RegistroR02.CRZ = ListaR02[i].Crz.Value;
                            RegistroR02.COO = ListaR02[i].Coo.Value;
                            RegistroR02.CRO = ListaR02[i].Cro.Value;
                            RegistroR02.DT_MOV = ListaR02[i].DataMovimento.Value;
                            RegistroR02.DT_EMI = ListaR02[i].DataEmissao.Value;
                            RegistroR02.HR_EMI = Convert.ToDateTime(ListaR02[i].HoraEmissao);
                            RegistroR02.VL_VBD = ListaR02[i].VendaBruta.Value;
                            RegistroR02.PAR_ECF = "";

                            //  Registro R03 - FILHO
                            ListaR03 = ListaR02[i].ListaR03;
                            if (ListaR03 != null)
                            {
                                for (int j = 0; j <= ListaR03.Count - 1; j++)
                                {
                                    StreamJson = new MemoryStream();
                                    SerializaJson = new DataContractJsonSerializer(typeof(R03DTO));
                                    ValorHashRegistro = ListaR02[j].Logss;
                                    ListaR03[j].Logss = "0";

                                    SerializaJson.WriteObject(StreamJson, ListaR03[j]);
                                    LerStreamJson = new StreamReader(StreamJson);
                                    StreamJson.Position = 0;
                                    RegistroGravado = LerStreamJson.ReadToEnd();

                                    ACBrPAFRegistroR3 RegistroR03 = new ACBrPAFRegistroR3();

                                    RegistroR03.RegistroValido = (ValorHashRegistro == RegistroGravado);
                                    RegistroR03.TOT_PARCIAL = ListaR03[j].TotalizadorParcial;
                                    RegistroR03.VL_ACUM = ListaR03[j].ValorAcumulado.Value;

                                    RegistroR02.RegistroR3.Add(RegistroR03);
                                }// for j := 0 to ListaR03.Count - 1 do
                            }// if Assigned(ListaR03) then

                            RegistroR01.RegistroR2.Add(RegistroR02);

                        }// for i := 0 to ListaR02.Count - 1 do
                    }// if Assigned(ListaR02) then


                    // Registro R04 - Cupom Fiscal, Nota Fiscal de Venda a Consumidor ou Bilhete de Passagem - ECF_VENDA_CABECALHO
                    // Registro R05 - Detalhe do Cupom Fiscal, Nota Fiscal de Venda a Consumidor ou Bilhete de Passagem - ECF_VENDA_DETALHE
                    // Registro R07 - Detalhe do Cupom Fiscal e do Documento Não Fiscal - Meio de Pagamento
                    Filtro = "SerieEcf = " + Biblioteca.QuotedStr(Sessao.Instance.ListaImpressora[h].Serie) + " AND (DataVenda between " + Biblioteca.QuotedStr(DataInicio) + " and " + Biblioteca.QuotedStr(DataFim) + ")";
                    ListaR04 = VendaController.ConsultaEcfVendaCabecalhoLista(Filtro);
                    if (ListaR04 != null)
                    {
                        for (int i = 0; i <= ListaR04.Count - 1; i++)
                        {
                            StreamJson = new MemoryStream();
                            SerializaJson = new DataContractJsonSerializer(typeof(EcfVendaCabecalhoDTO));
                            ValorHashRegistro = ListaR04[i].Logss;
                            ListaR04[i].Logss = "0";

                            SerializaJson.WriteObject(StreamJson, ListaR04[i]);
                            LerStreamJson = new StreamReader(StreamJson);
                            StreamJson.Position = 0;
                            RegistroGravado = LerStreamJson.ReadToEnd();

                            ACBrPAFRegistroR4 RegistroR04 = new ACBrPAFRegistroR4();

                            RegistroR04.RegistroValido = (ValorHashRegistro == RegistroGravado);
                            RegistroR04.NUM_USU = ListaR04[i].EcfFuncionario.Id;
                            RegistroR04.NUM_CONT = ListaR04[i].Ccf.Value;
                            RegistroR04.COO = ListaR04[i].Coo.Value;
                            RegistroR04.DT_INI = ListaR04[i].DataVenda.Value;
                            RegistroR04.SUB_DOCTO = ListaR04[i].ValorVenda.Value;
                            RegistroR04.SUB_DESCTO = ListaR04[i].Desconto.Value;
                            RegistroR04.TP_DESCTO = "V";
                            RegistroR04.SUB_ACRES = ListaR04[i].Acrescimo.Value;
                            RegistroR04.TP_ACRES = "V";
                            RegistroR04.VL_TOT = ListaR04[i].ValorFinal.Value;
                            RegistroR04.CANC = ListaR04[i].CupomCancelado;
                            RegistroR04.VL_CA = 0;
                            RegistroR04.ORDEM_DA = "D";
                            RegistroR04.NOME_CLI = ListaR04[i].NomeCliente;
                            RegistroR04.CNPJ_CPF = ListaR04[i].CpfCnpjCliente;

                            // Registro R05 - FILHO
                            ListaR05 = ListaR04[i].ListaEcfVendaDetalhe;
                            if (ListaR05 != null)
                            {
                                for (int j = 0; j <= ListaR05.Count - 1; j++)
                                {
                                    StreamJson = new MemoryStream();
                                    SerializaJson = new DataContractJsonSerializer(typeof(EcfVendaDetalheDTO));
                                    ValorHashRegistro = ListaR05[j].Logss;
                                    ListaR05[j].Logss = "0";

                                    SerializaJson.WriteObject(StreamJson, ListaR05[j]);
                                    LerStreamJson = new StreamReader(StreamJson);
                                    StreamJson.Position = 0;
                                    RegistroGravado = LerStreamJson.ReadToEnd();

                                    ACBrPAFRegistroR5 RegistroR05 = new ACBrPAFRegistroR5();

                                    RegistroR05.RegistroValido = (ValorHashRegistro == RegistroGravado);
                                    RegistroR05.NUM_ITEM = ListaR05[j].Item.Value;
                                    RegistroR05.COD_ITEM = ListaR05[j].Gtin;
                                    RegistroR05.DESC_ITEM = ListaR05[j].Produto.DescricaoPdv;
                                    RegistroR05.QTDE_ITEM = ListaR05[j].Quantidade.Value;
                                    RegistroR05.UN_MED = ListaR05[j].Produto.UnidadeProduto.Sigla;
                                    RegistroR05.VL_UNIT = ListaR05[j].ValorUnitario.Value;
                                    RegistroR05.DESCTO_ITEM = ListaR05[j].Desconto.Value;
                                    RegistroR05.ACRES_ITEM = ListaR05[j].Acrescimo.Value;
                                    RegistroR05.VL_TOT_ITEM = ListaR05[j].TotalItem.Value;
                                    RegistroR05.COD_TOT_PARC = ListaR05[j].TotalizadorParcial;
                                    RegistroR05.IND_CANC = ListaR05[j].Cancelado;

                                    if (ListaR05[j].Cancelado == "S")
                                    {
                                        RegistroR05.QTDE_CANC = ListaR05[j].Quantidade.Value;
                                        RegistroR05.VL_CANC = ListaR05[j].TotalItem.Value;
                                    }
                                    else
                                    {
                                        RegistroR05.QTDE_CANC = 0;
                                        RegistroR05.VL_CANC = 0;
                                    }

                                    RegistroR05.VL_CANC_ACRES = 0;
                                    RegistroR05.IAT = ListaR05[j].Produto.Iat;
                                    RegistroR05.IPPT = ListaR05[j].Produto.Ippt;
                                    RegistroR05.QTDE_DECIMAL = Sessao.Instance.Configuracao.DecimaisQuantidade.Value;
                                    RegistroR05.VL_DECIMAL = Sessao.Instance.Configuracao.DecimaisValor.Value;

                                    RegistroR04.RegistroR5.Add(RegistroR05);
                                }// for j := 0 to ListaR05.Count - 1 do
                            }// if Assigned(ListaR05) then


                            //  Registro R07 - MEIOS DE PAGAMENTO
                            ListaR07IdR04 = ListaR04[i].ListaEcfTotalTipoPagamento;
                            if (ListaR07IdR04 != null)
                            {
                                for (int j = 0; j <= ListaR07IdR04.Count - 1; j++)
                                {
                                    StreamJson = new MemoryStream();
                                    SerializaJson = new DataContractJsonSerializer(typeof(EcfTotalTipoPagamentoDTO));
                                    ValorHashRegistro = ListaR07IdR04[j].Logss;
                                    ListaR07IdR04[j].Logss = "0";

                                    SerializaJson.WriteObject(StreamJson, ListaR07IdR04[j]);
                                    LerStreamJson = new StreamReader(StreamJson);
                                    StreamJson.Position = 0;
                                    RegistroGravado = LerStreamJson.ReadToEnd();

                                    ACBrPAFRegistroR7 RegistroR07 = new ACBrPAFRegistroR7();

                                    RegistroR07.RegistroValido = (ValorHashRegistro == RegistroGravado);
                                    RegistroR07.CCF = ListaR07IdR04[j].Ccf.Value;
                                    RegistroR07.GNF = ListaR07IdR04[j].Gnf.Value;
                                    RegistroR07.MP = ListaR07IdR04[j].EcfTipoPagamento.Descricao;
                                    RegistroR07.VL_PAGTO = ListaR07IdR04[j].Valor.Value;
                                    RegistroR07.IND_EST = ListaR07IdR04[j].Estorno;
                                    RegistroR07.VL_EST = ListaR07IdR04[j].Valor.Value;

                                    RegistroR04.RegistroR7.Add(RegistroR07);
                                }// for j := 0 to ListaR07.Count - 1 do
                            }// if Assigned(ListaR07) then

                            RegistroR01.RegistroR4.Add(RegistroR04);

                        }// for i := 0 to ListaR04.Count - 1 do
                    }// if Assigned(ListaR04) then


                    // Registro R06 - Demais documentos emitidos pelo ECF
                    // Registro R07 - Detalhe do Cupom Fiscal e do Documento Não Fiscal - Meio de Pagamento
                    Filtro = "SerieEcf = " + Biblioteca.QuotedStr(Sessao.Instance.ListaImpressora[h].Serie) + " AND (DataEmissao between " + Biblioteca.QuotedStr(DataInicio) + " and " + Biblioteca.QuotedStr(DataFim) + ")";
                    ListaR06 = R06Controller.ConsultaR06Lista(Filtro);
                    if (ListaR06 != null)
                    {
                        for (int i = 0; i <= ListaR06.Count - 1; i++)
                        {
                            StreamJson = new MemoryStream();
                            SerializaJson = new DataContractJsonSerializer(typeof(R06DTO));
                            ValorHashRegistro = ListaR06[i].Logss;
                            ListaR06[i].Logss = "0";

                            SerializaJson.WriteObject(StreamJson, ListaR06[i]);
                            LerStreamJson = new StreamReader(StreamJson);
                            StreamJson.Position = 0;
                            RegistroGravado = LerStreamJson.ReadToEnd();

                            ACBrPAFRegistroR6 RegistroR06 = new ACBrPAFRegistroR6();

                            RegistroR06.RegistroValido = (ValorHashRegistro == RegistroGravado);
                            RegistroR06.NUM_USU = ListaR06[i].IdOperador;
                            RegistroR06.COO = ListaR06[i].Coo.Value;
                            RegistroR06.GNF = ListaR06[i].Gnf.Value;
                            RegistroR06.GRG = ListaR06[i].Grg.Value;
                            RegistroR06.CDC = ListaR06[i].Cdc.Value;
                            RegistroR06.DENOM = ListaR06[i].Denominacao;
                            RegistroR06.DT_FIN = ListaR06[i].DataEmissao.Value;
                            RegistroR06.HR_FIN = Convert.ToDateTime(ListaR06[i].HoraEmissao);

                            //  Registro R07 - MEIOS DE PAGAMENTO
                            ListaR07 = ListaR06[i].ListaR07;
                            if (ListaR07 != null)
                            {
                                for (int j = 0; j <= ListaR07.Count - 1; j++)
                                {
                                    StreamJson = new MemoryStream();
                                    SerializaJson = new DataContractJsonSerializer(typeof(R07DTO));
                                    ValorHashRegistro = ListaR07[j].Logss;
                                    ListaR07[j].Logss = "0";

                                    SerializaJson.WriteObject(StreamJson, ListaR07[j]);
                                    LerStreamJson = new StreamReader(StreamJson);
                                    StreamJson.Position = 0;
                                    RegistroGravado = LerStreamJson.ReadToEnd();

                                    ACBrPAFRegistroR7 RegistroR07 = new ACBrPAFRegistroR7();

                                    RegistroR07.RegistroValido = (ValorHashRegistro == RegistroGravado);

                                    RegistroR07.CCF = ListaR07[j].Ccf.Value;
                                    RegistroR07.MP = ListaR07[j].MeioPagamento;
                                    RegistroR07.VL_PAGTO = ListaR07[j].ValorPagamento.Value;
                                    RegistroR07.IND_EST = ListaR07[j].Estorno;
                                    RegistroR07.VL_EST = ListaR07[j].ValorEstorno.Value;

                                    RegistroR06.RegistroR7.Add(RegistroR07);
                                }// for j := 0 to ListaR07.Count - 1 do
                            }// if Assigned(ListaR07) then

                            RegistroR01.RegistroR6.Add(RegistroR06);

                        }// for i := 0 to ListaR06.Count - 1 do
                    }// if Assigned(ListaR06) then

                    DataModule.ACBrPAF.PAF_R.RegistroR1.Add(RegistroR01);
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        #endregion Geração Arquivo Registros PAF

        #region Relatórios Gerenciais

        public static void IdentificacaoPafEcf()
        {
            string sMD5, sSerie = "";

            try
            {
                XmlDocument ArquivoXML = new XmlDocument();
                ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");

                DataModule.ACBrECF.AbreRelatorioGerencial(Sessao.Instance.Configuracao.EcfRelatorioGerencial.X.Value);
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));
                DataModule.ACBrECF.LinhaRelatorioGerencial("************IDENTIFICACAO DO PAF-ECF************");
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));
                DataModule.ACBrECF.LinhaRelatorioGerencial("NUMERO DO LAUDO...: " + Sessao.Instance.R01.NumeroLaudoPaf);
                DataModule.ACBrECF.LinhaRelatorioGerencial("*****IDENTIFICACAO DA EMPRESA DESENDTOLVEDORA****");
                DataModule.ACBrECF.LinhaRelatorioGerencial("C.N.P.J. .........: " + Sessao.Instance.R01.CnpjSh);
                DataModule.ACBrECF.LinhaRelatorioGerencial("RAZAO SOCIAL......: " + Sessao.Instance.R01.RazaoSocialSh);
                DataModule.ACBrECF.LinhaRelatorioGerencial("ENDERECO..........: " + Sessao.Instance.R01.EnderecoSh);
                DataModule.ACBrECF.LinhaRelatorioGerencial("NUMERO............: " + Sessao.Instance.R01.NumeroSh);
                DataModule.ACBrECF.LinhaRelatorioGerencial("COMPLEMENTO.......: " + Sessao.Instance.R01.ComplementoSh);
                DataModule.ACBrECF.LinhaRelatorioGerencial("BAIRRO............: " + Sessao.Instance.R01.BairroSh);
                DataModule.ACBrECF.LinhaRelatorioGerencial("CIDADE............: " + Sessao.Instance.R01.CidadeSh);
                DataModule.ACBrECF.LinhaRelatorioGerencial("CEP...............: " + Sessao.Instance.R01.CepSh);
                DataModule.ACBrECF.LinhaRelatorioGerencial("UF................: " + Sessao.Instance.R01.UfSh);
                DataModule.ACBrECF.LinhaRelatorioGerencial("TELEFONE..........: " + Sessao.Instance.R01.TelefoneSh);
                DataModule.ACBrECF.LinhaRelatorioGerencial("CONTATO...........: " + Sessao.Instance.R01.ContatoSh);
                DataModule.ACBrECF.LinhaRelatorioGerencial("************IDENTIFICACAO DO PAF-ECF************");
                DataModule.ACBrECF.LinhaRelatorioGerencial("NOME COMERCIAL....: " + Sessao.Instance.R01.NomePafEcf);
                DataModule.ACBrECF.LinhaRelatorioGerencial("VERSAO DO PAF-ECF.: " + Sessao.Instance.R01.VersaoPafEcf);
                DataModule.ACBrECF.LinhaRelatorioGerencial("**********PRINCIPAL Arquivo EXECUTAVEL**********");
                DataModule.ACBrECF.LinhaRelatorioGerencial("NOME..............: " + Sessao.Instance.R01.PrincipalExecutavel);
                sMD5 = Biblioteca.MD5File(Application.StartupPath + "\\" + Sessao.Instance.R01.PrincipalExecutavel);
                DataModule.ACBrECF.LinhaRelatorioGerencial("MD5.: " + sMD5);
                DataModule.ACBrECF.LinhaRelatorioGerencial("****************DEMAIS ArquivoS*****************");
                DataModule.ACBrECF.LinhaRelatorioGerencial("NOME..............: " + "Balcao.exe");
                sMD5 = Biblioteca.MD5File(Application.StartupPath + "\\" + "Balcao.exe");
                DataModule.ACBrECF.LinhaRelatorioGerencial("MD5.: " + sMD5);
                DataModule.ACBrECF.LinhaRelatorioGerencial("**************NOME DO Arquivo TEXTO*************");
                DataModule.ACBrECF.LinhaRelatorioGerencial("NOME..............: " + "ArquivoMD5.txt");
                sMD5 = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("arquivosMD5").Item(0).InnerText.Trim());
                DataModule.ACBrECF.LinhaRelatorioGerencial("MD5.: " + sMD5);
                DataModule.ACBrECF.LinhaRelatorioGerencial("VERSAO ER PAF-ECF.: " + Sessao.Instance.R01.VersaoEr);
                DataModule.ACBrECF.LinhaRelatorioGerencial("**********RELACAO DOS ECF AUTORIZADOS***********");
                sSerie = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("serie1").Item(0).InnerText.Trim());
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));
                DataModule.ACBrECF.FechaRelatorio();
                GravarR06("RG");
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static void ParametrodeConfiguracao()
        {
            try
            {
                XmlDocument ArquivoXML = new XmlDocument();
                ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");

                DataModule.ACBrECF.AbreRelatorioGerencial(Sessao.Instance.Configuracao.EcfRelatorioGerencial.ParametrosConfiguracao.Value);
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));
                DataModule.ACBrECF.LinhaRelatorioGerencial("***********PARAMETROS DE CONFIGURACAO***********");
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));
                DataModule.ACBrECF.LinhaRelatorioGerencial("<n>CONFIGURAÇÃO:</n>");
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));

                DataModule.ACBrECF.LinhaRelatorioGerencial("<s><n>Funcionalidades:</n></s>");
                DataModule.ACBrECF.LinhaRelatorioGerencial("");
                DataModule.ACBrECF.LinhaRelatorioGerencial("TIPO DE FUNCIONAMENTO: ......... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("fun1").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("TIPO DE DESENDTOLVIMENTO: ....... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("fun2").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("INTEGRACAO DO PAF-ECF: ......... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("fun3").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));

                DataModule.ACBrECF.LinhaRelatorioGerencial("<s><n>Parâmetros Para Não Concomitância:</n></s>");
                DataModule.ACBrECF.LinhaRelatorioGerencial("");
                DataModule.ACBrECF.LinhaRelatorioGerencial("PRÉ-VENDA: ................................. " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("par1").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("DAV POR ECF: ............................... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("par2").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("DAV IMPRESSORA NÃO FISCAL: ................. " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("par3").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("DAV-OS: .................................... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("par4").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));

                DataModule.ACBrECF.LinhaRelatorioGerencial("<s><n>Aplicações Especiais:</n></s>");
                DataModule.ACBrECF.LinhaRelatorioGerencial("");
                DataModule.ACBrECF.LinhaRelatorioGerencial("TAB. ÍNDICE TÉCNICO DE PRODUÇÃO: ........... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl1").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("POSTO REVENDEDOR DE COMBUSTÍVEIS: .......... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl2").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("Bar, Restaurante e Similar - ECF-Restaurante:" + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl3").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("Bar, Restaurante e Similar - ECF-Comum: .... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl4").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("FARMÁCIA DE MANIPULAÇÃO: ................... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl5").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("OFICINA DE CONSERTO: ....................... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl6").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("TRANSPORTE DE PASSAGEIROS: ................. " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("apl7").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));

                DataModule.ACBrECF.LinhaRelatorioGerencial("<s><n>Critérios por Unidade Federada:</n></s>");
                DataModule.ACBrECF.LinhaRelatorioGerencial("");
                DataModule.ACBrECF.LinhaRelatorioGerencial("<n>REQUISITO XVIII - Tela Consulta de Preço:</n>");
                DataModule.ACBrECF.LinhaRelatorioGerencial("");
                DataModule.ACBrECF.LinhaRelatorioGerencial("TOTALIZAÇÃO DOS VALORES DA LISTA: .......... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("cri1").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("TRANSFORMAÇÃO DAS INFORMÇÕES EM PRÉ-VENDA: . " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("cri2").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial("TRANSFORMAÇÃO DAS INFORMÇÕES EM DAV: ....... " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("cri3").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));

                DataModule.ACBrECF.LinhaRelatorioGerencial("<s><n>REQUISITO XXII - PAF-ECF Integrado ao ECF:</n></s>");
                DataModule.ACBrECF.LinhaRelatorioGerencial("");
                DataModule.ACBrECF.LinhaRelatorioGerencial("NÃO COINCIDÊNCIA GT(ECF) x Arquivo CRIPTOGRAFADO");
                DataModule.ACBrECF.LinhaRelatorioGerencial("RECOMPOE VALOR DO GT Arquivo CRIPTOGRAFADO:  " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("XXII1").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));

                DataModule.ACBrECF.LinhaRelatorioGerencial("<s><n>REQUISITO XXXVI - A - PAF-ECF Combustível:</n></s>");
                DataModule.ACBrECF.LinhaRelatorioGerencial("");
                DataModule.ACBrECF.LinhaRelatorioGerencial("Impedir Registro de Venda com Valor Zero ou");
                DataModule.ACBrECF.LinhaRelatorioGerencial("NegatiDTO: .................................. " + (Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("XXXVI1").Item(0).InnerText.Trim())));
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));

                DataModule.ACBrECF.FechaRelatorio();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        #endregion Relatórios Gerenciais

        #region Gravação de Dados

        public static void GravarR02R03()
        {
            string Indice, Aliquota;
            try
            {
                R03DTO R03;

                // Dados para o registro R02
                R02DTO R02 = new R02DTO();
                R02.IdEcfCaixa = Sessao.Instance.Movimento.EcfCaixa.Id;
                R02.IdOperador = Sessao.Instance.Movimento.EcfOperador.Id;
                R02.IdImpressora = Sessao.Instance.Movimento.EcfImpressora.Id;
                R02.SerieEcf = Sessao.Instance.Configuracao.EcfImpressora.Serie;

                DataModule.ACBrECF.DadosReducaoZ();

                R02.Crz = DataModule.ACBrECF.DadosReducaoZClass.CRZ + 1;
                R02.Coo = Convert.ToInt32(DataModule.ACBrECF.NumCOO) + 1;
                R02.Cro = DataModule.ACBrECF.DadosReducaoZClass.CRO;
                R02.DataMovimento = DataModule.ACBrECF.DadosReducaoZClass.DataDoMovimento;
                R02.DataEmissao = DataModule.ACBrECF.DadosReducaoZClass.DataDaImpressora;
                R02.HoraEmissao = DataModule.ACBrECF.DadosReducaoZClass.DataDaImpressora.ToString("hh:mm:ss");
                R02.VendaBruta = DataModule.ACBrECF.DadosReducaoZClass.ValorVendaBruta;
                R02.GrandeTotal = DataModule.ACBrECF.DadosReducaoZClass.ValorGrandeTotal;

                // Dados para o registro R03

                // Dados ICMS
                for (int i = 0; i <= DataModule.ACBrECF.DadosReducaoZClass.ICMS.Length - 1; i++)
                {
                    R03 = new R03DTO();
                    R03.Crz = DataModule.ACBrECF.DadosReducaoZClass.CRZ + 1;
                    // Completa com zeros a esquerda
                    Indice = new string('0', 2 - DataModule.ACBrECF.DadosReducaoZClass.ICMS[i].Indice.Length) + DataModule.ACBrECF.DadosReducaoZClass.ICMS[i].Indice;
                    // Tira as virgulas
                    Aliquota = (DataModule.ACBrECF.DadosReducaoZClass.ICMS[i].ValorAliquota * 100).ToString().Replace(",", "");
                    // Completa com zeros a esquerda e a direita
                    Aliquota = new string('0', 4 - Aliquota.Length) + Aliquota;
                    R03.TotalizadorParcial = Indice + "T" + Aliquota;
                    R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.ICMS[i].Total;
                    R02.ListaR03.Add(R03);
                }

                // Dados ISSQN
                for (int i = 0; i <= DataModule.ACBrECF.DadosReducaoZClass.ISSQN.Length - 1; i++)
                {
                    R03 = new R03DTO();
                    // Completa com zeros a esquerda
                    Indice = new string('0', 2 - DataModule.ACBrECF.DadosReducaoZClass.ISSQN[i].Indice.Length) + DataModule.ACBrECF.DadosReducaoZClass.ISSQN[i].Indice;
                    // Tira as virgulas
                    Aliquota = (DataModule.ACBrECF.DadosReducaoZClass.ISSQN[i].ValorAliquota * 100).ToString().Replace(",", "");
                    // Completa com zeros a esquerda
                    Aliquota = new string('0', 4 - Aliquota.Length) + Aliquota;
                    R03.TotalizadorParcial = Indice + "S" + Aliquota;
                    R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.ISSQN[i].Total;
                    R02.ListaR03.Add(R03);
                }

                // Substituição Tributária - ICMS
                R03 = new R03DTO();
                R03.TotalizadorParcial = "F1";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.SubstituicaoTributariaICMS;
                R02.ListaR03.Add(R03);

                // Isento - ICMS
                R03 = new R03DTO();
                R03.TotalizadorParcial = "I1";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.IsentoICMS;
                R02.ListaR03.Add(R03);

                // Não-incidência - ICMS
                R03 = new R03DTO();
                R03.TotalizadorParcial = "N1";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.NaoTributadoICMS;
                R02.ListaR03.Add(R03);

                // Substituição Tributária - ISSQN
                R03 = new R03DTO();
                R03.TotalizadorParcial = "FS1";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.SubstituicaoTributariaISSQN;
                R02.ListaR03.Add(R03);

                // Isento - ISSQN
                R03 = new R03DTO();
                R03.TotalizadorParcial = "IS1";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.IsentoISSQN;
                R02.ListaR03.Add(R03);

                // Não-incidência - ISSQN
                R03 = new R03DTO();
                R03.TotalizadorParcial = "NS1";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.NaoTributadoISSQN;
                R02.ListaR03.Add(R03);

                // Operações Não Fiscais
                R03 = new R03DTO();
                R03.TotalizadorParcial = "OPNF";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.TotalOperacaoNaoFiscal;
                R02.ListaR03.Add(R03);

                // Desconto - ICMS
                R03 = new R03DTO();
                R03.TotalizadorParcial = "DT";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.DescontoICMS;
                R02.ListaR03.Add(R03);

                // Desconto - ISSQN
                R03 = new R03DTO();
                R03.TotalizadorParcial = "DS";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.DescontoISSQN;
                R02.ListaR03.Add(R03);

                // Acréscimo - ICMS
                R03 = new R03DTO();
                R03.TotalizadorParcial = "AT";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.AcrescimoICMS;
                R02.ListaR03.Add(R03);

                // Acréscimo - ISSQN
                R03 = new R03DTO();
                R03.TotalizadorParcial = "AS";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.AcrescimoISSQN;
                R02.ListaR03.Add(R03);

                // Cancelamento - ICMS
                R03 = new R03DTO();
                R03.TotalizadorParcial = "Can-T";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.CancelamentoICMS;
                R02.ListaR03.Add(R03);

                // Cancelamento - ISSQN
                R03 = new R03DTO();
                R03.TotalizadorParcial = "Can-S";
                R03.ValorAcumulado = DataModule.ACBrECF.DadosReducaoZClass.CancelamentoISSQN;
                R02.ListaR03.Add(R03);

                R02Controller.GravaR02(R02);

                CargaPDV FCargaPDV = new CargaPDV();
                CargaPDV.Filtro = "Id = " + R02.Id;
                CargaPDV.Procedimento = "EXPORTA_R02";
                FCargaPDV.ShowDialog();

                Gravar60M60A(R02.IdImpressora);

            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static void Gravar60M60A(int IdImpressora)
        {
            try
            {
                Sintegra60aDTO Sintegra60A;
                Sintegra60mDTO Sintegra60M = new Sintegra60mDTO();
                Sintegra60M.ModeloDocumentoFiscal = Sessao.Instance.Configuracao.EcfImpressora.ModeloDocumentoFiscal;

                DataModule.ACBrECF.DadosReducaoZ();

                Sintegra60M.DataEmissao = DataModule.ACBrECF.DadosReducaoZClass.DataDoMovimento;
                Sintegra60M.NumeroSerieEcf = DataModule.ACBrECF.DadosReducaoZClass.NumeroDeSerie;
                Sintegra60M.NumeroEquipamento = Convert.ToInt32(DataModule.ACBrECF.DadosReducaoZClass.NumeroDoECF);
                Sintegra60M.CooInicial = Convert.ToInt32(DataModule.ACBrECF.DadosReducaoZClass.NumeroCOOInicial);
                Sintegra60M.CooFinal = DataModule.ACBrECF.DadosReducaoZClass.COO + 1;
                Sintegra60M.Crz = DataModule.ACBrECF.DadosReducaoZClass.CRZ + 1;
                Sintegra60M.Cro = DataModule.ACBrECF.DadosReducaoZClass.CRO;
                Sintegra60M.ValorVendaBruta = DataModule.ACBrECF.DadosReducaoZClass.ValorVendaBruta;
                Sintegra60M.ValorGrandeTotal = DataModule.ACBrECF.DadosReducaoZClass.ValorGrandeTotal;

                // Dados para o registro Sintegra60A

                // Dados ICMS
                for (int i = 0; i <= DataModule.ACBrECF.DadosReducaoZClass.ICMS.Length - 1; i++)
                {
                    Sintegra60A = new Sintegra60aDTO();
                    Sintegra60A.SituacaoTributaria = DataModule.ACBrECF.DadosReducaoZClass.ICMS[i].ValorAliquota.ToString().Replace(",", "");
                    Sintegra60A.Valor = DataModule.ACBrECF.DadosReducaoZClass.ICMS[i].Total;
                    Sintegra60M.Lista60A.Add(Sintegra60A);
                }

                // Dados ISSQN
                for (int i = 0; i <= DataModule.ACBrECF.DadosReducaoZClass.ISSQN.Length - 1; i++)
                {
                    Sintegra60A = new Sintegra60aDTO();
                    Sintegra60A.SituacaoTributaria = DataModule.ACBrECF.DadosReducaoZClass.ISSQN[i].ValorAliquota.ToString().Replace(",", "");
                    Sintegra60A.Valor = DataModule.ACBrECF.DadosReducaoZClass.ISSQN[i].Total;
                    Sintegra60M.Lista60A.Add(Sintegra60A);
                }

                // Substituição Tributária - ICMS
                Sintegra60A = new Sintegra60aDTO();
                Sintegra60A.SituacaoTributaria = "F";
                Sintegra60A.Valor = DataModule.ACBrECF.DadosReducaoZClass.SubstituicaoTributariaICMS;
                Sintegra60M.Lista60A.Add(Sintegra60A);

                // Isento - ICMS
                Sintegra60A = new Sintegra60aDTO();
                Sintegra60A.SituacaoTributaria = "I";
                Sintegra60A.Valor = DataModule.ACBrECF.DadosReducaoZClass.IsentoICMS;
                Sintegra60M.Lista60A.Add(Sintegra60A);

                // Não-incidência - ICMS
                Sintegra60A = new Sintegra60aDTO();
                Sintegra60A.SituacaoTributaria = "N";
                Sintegra60A.Valor = DataModule.ACBrECF.DadosReducaoZClass.NaoTributadoICMS;
                Sintegra60M.Lista60A.Add(Sintegra60A);

                // Desconto - ICMS
                Sintegra60A = new Sintegra60aDTO();
                Sintegra60A.SituacaoTributaria = "DESC";
                Sintegra60A.Valor = DataModule.ACBrECF.DadosReducaoZClass.DescontoICMS;
                Sintegra60M.Lista60A.Add(Sintegra60A);

                // Cancelamento - ICMS
                Sintegra60A = new Sintegra60aDTO();
                Sintegra60A.SituacaoTributaria = "CANC";
                Sintegra60A.Valor = DataModule.ACBrECF.DadosReducaoZClass.CancelamentoICMS;
                Sintegra60M.Lista60A.Add(Sintegra60A);

                Sintegra60MController.GravaSintegra60M(Sintegra60M);

                CargaPDV FCargaPDV = new CargaPDV();
                CargaPDV.Filtro = "Id = " + Sintegra60M.Id;
                CargaPDV.Procedimento = "EXPORTA_SINTEGRA60M";
                FCargaPDV.ShowDialog();

            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        
        }

        public static void GravarR06(string pSimbolo)
        {
            try
            {
                R06DTO R06 = new R06DTO();
                R06.IdEcfCaixa = Sessao.Instance.Movimento.EcfCaixa.Id;
                R06.IdOperador = Sessao.Instance.Movimento.EcfOperador.Id;
                R06.IdImpressora = Sessao.Instance.Movimento.EcfImpressora.Id;
                R06.SerieEcf = Sessao.Instance.Configuracao.EcfImpressora.Serie;
                R06.Coo = Convert.ToInt32(DataModule.ACBrECF.NumCOO);
                R06.Gnf = Convert.ToInt32(DataModule.ACBrECF.NumGNF);
                R06.Grg = Convert.ToInt32(DataModule.ACBrECF.NumGRG);

                if (DataModule.ACBrECF.MFD)
                    R06.Cdc = Convert.ToInt32(DataModule.ACBrECF.NumCDC);
                else
                    R06.Cdc = 0;

                R06.Denominacao = pSimbolo;
                /*
                       Relação dos Símbolos Possíveis
                  Documento                        Símbolo
                  ========================================
                  Conferência de Mesa                 - CM
                  Registro de Venda                   - RV
                  Comprovante de Crédito ou Débito    - CC
                  Comprovante Não-Fiscal              - CN
                  Comprovante Não-Fiscal Cancelamento - NC
                  Relatório Gerencial                 - RG
                */ 
                R06.DataEmissao = DataModule.ACBrECF.DataHora;
                R06.HoraEmissao = DataModule.ACBrECF.DataHora.ToString("HH:mm:ss");

                LogssController.AtualizarQuantidades();
                R06Controller.GravaR06(R06);

                CargaPDV FCargaPDV = new CargaPDV();
                CargaPDV.Filtro = "Id = " + R06.Id;
                CargaPDV.Procedimento = "EXPORTA_R06";
                FCargaPDV.ShowDialog();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        #endregion Gravação de Dados

        #region Arquivo Auxiliar

        public static bool ECFAutorizado()
        {
            string MD5Serie, Serie = "";

            if (!File.Exists(Application.StartupPath + "\\ArquivoAuxiliar.xml"))
            {
                return false;
            }
            else
            {
                try
                {
                    XmlDocument ArquivoXML = new XmlDocument();
                    ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");
                    MD5Serie = DataModule.ACBrECF.NumSerie;
                    Serie = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("serie1").Item(0).InnerText.Trim());
                    if (Serie == MD5Serie)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                    return false;
                }
            }
        }

        public static bool ConfereGT()
        {
            string sGT;
            if (!File.Exists(Application.StartupPath + "\\ArquivoAuxiliar.xml"))
            {
                return false;
            }
            else
            {
                try
                {
                    XmlDocument ArquivoXML = new XmlDocument();
                    ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");

                    string GTCritpo = Biblioteca.Encripta(DataModule.ACBrECF.GrandeTotal.ToString());

                    sGT = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("gt").Item(0).InnerText.Trim()); ;
                    if (DataModule.ACBrECF.GrandeTotal.ToString() == sGT)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                    return false;
                }
            }
        }

        public static void AtualizaGT()
        {
            try
            {
                XmlDocument ArquivoXML = new XmlDocument();
                ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");
                ArquivoXML.GetElementsByTagName("gt").Item(0).InnerText = Biblioteca.Encripta(DataModule.ACBrECF.GrandeTotal.ToString());
                ArquivoXML.Save(Application.StartupPath + "\\ArquivoAuxiliar.xml");
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static void GravarIdUltimaVenda()
        {
            try
            {
                XmlDocument ArquivoXML = new XmlDocument();
                ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");
                ArquivoXML.GetElementsByTagName("ultimaVenda").Item(0).InnerText = Sessao.Instance.VendaAtual.Id.ToString();
                ArquivoXML.Save(Application.StartupPath + "\\ArquivoAuxiliar.xml");
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static string RecuperarIdUltimaVenda()
        {
            try
            {
                XmlDocument ArquivoXML = new XmlDocument();
                ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");
                return ArquivoXML.GetElementsByTagName("ultimaVenda").Item(0).InnerText.Trim();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                return "";
            }
        }

        public static bool AtualizarEstoque(bool pForcarAtualizacao) 
        { 
            // Exercício - implementar a atualização do estoque
            return true; 
        }

        #endregion Arquivo Auxiliar

        #region Outros Procedimentos

        public static string GeraMD5()
        {
            string NomeArquivo, Mensagem, MD5ArquivoMD5;

            try
            {
                DataModule.ACBrPAF.PAF_N.RegistroN2.LAUDO = Sessao.Instance.R01.NumeroLaudoPaf;
                DataModule.ACBrPAF.PAF_N.RegistroN2.NOME = Sessao.Instance.R01.NomePafEcf;
                DataModule.ACBrPAF.PAF_N.RegistroN2.VERSAO = Sessao.Instance.R01.VersaoPafEcf;
                DataModule.ACBrPAF.PAF_N.RegistroN3.Clear();

                //  registros N3
                ACBrPAFRegistroN3 N3;
                NomeArquivo = Application.StartupPath + "\\PafEcf.exe";
                N3 = new ACBrPAFRegistroN3();
                N3.NOME_ARQUIVO = Sessao.Instance.R01.PrincipalExecutavel;
                N3.MD5 = Biblioteca.MD5File(NomeArquivo);
                DataModule.ACBrPAF.PAF_N.RegistroN3.Add(N3);

                NomeArquivo = Application.StartupPath + "\\Balcao.exe";
                N3 = new ACBrPAFRegistroN3();
                N3.NOME_ARQUIVO = "Balcao.exe";
                N3.MD5 = Biblioteca.MD5File(NomeArquivo);
                DataModule.ACBrPAF.PAF_N.RegistroN3.Add(N3);

                DataModule.ACBrPAF.Path = Application.StartupPath;
                DataModule.ACBrPAF.SaveFileTXT_N(@"\ArquivoMD5.txt");

                MD5ArquivoMD5 = Biblioteca.MD5File(Application.StartupPath + "\\ArquivoMD5.txt");

                XmlDocument ArquivoXML = new XmlDocument();
                ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");
                ArquivoXML.GetElementsByTagName("arquivosMD5").Item(0).InnerText = Biblioteca.Encripta(MD5ArquivoMD5);
                ArquivoXML.Save(Application.StartupPath + "\\ArquivoAuxiliar.xml");

                Mensagem = "Arquivo armazenado em: " + Application.StartupPath + "\\ArquivoMD5.txt";
                MessageBox.Show(Mensagem, "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return MD5ArquivoMD5;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                return null;
            }
        }

        #endregion Outros Procedimentos


    }

}
