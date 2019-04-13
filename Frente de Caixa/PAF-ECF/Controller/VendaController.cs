/********************************************************************************
Title: T2TiPDV
Description: Classe de controle da Venda

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
using PafEcf.DTO;
using NHibernate;
using PafEcf.NHibernate;
using System.Collections.Generic;
using PafEcf.Util;
using System.IO;
using System.Runtime.Serialization.Json;

namespace PafEcf.Controller
{

    public class VendaController
    {

        public static EcfVendaCabecalhoDTO ConsultaEcfVendaCabecalho(string pFiltro)
        {
            try
            {
                EcfVendaCabecalhoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfVendaCabecalhoDTO> DAL = new NHibernateDAL<EcfVendaCabecalhoDTO>(Session);

                    String ConsultaSql = "from EcfVendaCabecalhoDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<EcfVendaCabecalhoDTO>(ConsultaSql);

                    if (Resultado != null)
                    {
                        // Consulta lista de detalhes
                        NHibernateDAL<EcfVendaDetalheDTO> DALDetalhe = new NHibernateDAL<EcfVendaDetalheDTO>(Session);
                        Resultado.ListaEcfVendaDetalhe = DALDetalhe.Select<EcfVendaDetalheDTO>(
                            new EcfVendaDetalheDTO { IdEcfVendaCabecalho = Resultado.Id });

                        // Consulta lista de pagamentos
                        NHibernateDAL<EcfTotalTipoPagamentoDTO> DALPagamento = new NHibernateDAL<EcfTotalTipoPagamentoDTO>(Session);
                        Resultado.ListaEcfTotalTipoPagamento = DALPagamento.Select<EcfTotalTipoPagamentoDTO>(
                            new EcfTotalTipoPagamentoDTO { IdEcfVendaCabecalho = Resultado.Id });
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfVendaCabecalhoDTO> ConsultaEcfVendaCabecalhoLista(string pFiltro)
        {
            try
            {
                IList<EcfVendaCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfVendaCabecalhoDTO> DAL = new NHibernateDAL<EcfVendaCabecalhoDTO>(Session);

                    String ConsultaSql = "from EcfVendaCabecalhoDTO where " + pFiltro;
                    Resultado = DAL.SelectListaSql<EcfVendaCabecalhoDTO>(ConsultaSql);

                    if (Resultado != null)
                    {
                        for (int i = 0; i <= Resultado.Count - 1; i++)
                        {
                            // Consulta lista de detalhes
                            NHibernateDAL<EcfVendaDetalheDTO> DALDetalhe = new NHibernateDAL<EcfVendaDetalheDTO>(Session);
                            Resultado[i].ListaEcfVendaDetalhe = DALDetalhe.Select<EcfVendaDetalheDTO>(
                                new EcfVendaDetalheDTO { IdEcfVendaCabecalho = Resultado[i].Id });

                            // Consulta lista de pagamentos
                            NHibernateDAL<EcfTotalTipoPagamentoDTO> DALPagamento = new NHibernateDAL<EcfTotalTipoPagamentoDTO>(Session);
                            Resultado[i].ListaEcfTotalTipoPagamento = DALPagamento.Select<EcfTotalTipoPagamentoDTO>(
                                new EcfTotalTipoPagamentoDTO { IdEcfVendaCabecalho = Resultado[i].Id });
                        }
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfVendaCabecalhoDTO> ConsultaEcfVendaCabecalhoPagina(int pPrimeiroResultado, int pQuantidadeResultados, EcfVendaCabecalhoDTO pEcfVendaCabecalho)
        {
            try
            {
                IList<EcfVendaCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfVendaCabecalhoDTO> DAL = new NHibernateDAL<EcfVendaCabecalhoDTO>(Session);
                    Resultado = DAL.SelectPagina<EcfVendaCabecalhoDTO>(pPrimeiroResultado, pQuantidadeResultados, pEcfVendaCabecalho);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static EcfVendaCabecalhoDTO GravaEcfVendaCabecalho(EcfVendaCabecalhoDTO pEcfVendaCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    pEcfVendaCabecalho.Logss = "0";
                    MemoryStream StreamJson = new MemoryStream();
                    DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(EcfVendaCabecalhoDTO));
                    SerializaJson.WriteObject(StreamJson, pEcfVendaCabecalho);
                    StreamReader LerStreamJson = new StreamReader(StreamJson);
                    StreamJson.Position = 0;
                    pEcfVendaCabecalho.Logss = Biblioteca.MD5String(LerStreamJson.ReadToEnd()); 
                    
                    NHibernateDAL<EcfVendaCabecalhoDTO> DAL = new NHibernateDAL<EcfVendaCabecalhoDTO>(Session);
                    DAL.SaveOrUpdate(pEcfVendaCabecalho);
                    Session.Flush();
                }
                return pEcfVendaCabecalho;
            }
            catch (Exception ex)
            {
                Log.write(ex.ToString());
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static EcfVendaDetalheDTO GravaEcfVendaDetalhe(EcfVendaDetalheDTO pEcfVendaDetalhe)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    MemoryStream StreamJsonDetalhe = new MemoryStream();
                    DataContractJsonSerializer SerializaJsonDetalhe = new DataContractJsonSerializer(typeof(EcfVendaDetalheDTO));
                    SerializaJsonDetalhe.WriteObject(StreamJsonDetalhe, pEcfVendaDetalhe);
                    StreamReader LerStreamJsonDetalhe = new StreamReader(StreamJsonDetalhe);
                    StreamJsonDetalhe.Position = 0;
                    pEcfVendaDetalhe.Logss = Biblioteca.MD5String(LerStreamJsonDetalhe.ReadToEnd());

                    NHibernateDAL<EcfVendaDetalheDTO> DAL = new NHibernateDAL<EcfVendaDetalheDTO>(Session);
                    DAL.SaveOrUpdate(pEcfVendaDetalhe);
                    Session.Flush();
                }
                return pEcfVendaDetalhe;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int ExcluiEcfVendaCabecalho(EcfVendaCabecalhoDTO pEcfVendaCabecalho)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfVendaCabecalhoDTO> DAL = new NHibernateDAL<EcfVendaCabecalhoDTO>(Session);
                    DAL.Delete(pEcfVendaCabecalho);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static bool ExisteVendaAberta()
        {
            try
            {
                EcfVendaCabecalhoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfVendaCabecalhoDTO> DAL = new NHibernateDAL<EcfVendaCabecalhoDTO>(Session);

                    String ConsultaSql = "from EcfVendaCabecalhoDTO where StatusVenda = " + Biblioteca.QuotedStr("A");
                    Resultado = DAL.SelectObjetoSql<EcfVendaCabecalhoDTO>(ConsultaSql);
                }
                return Resultado != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static bool CancelaVenda(EcfVendaCabecalhoDTO pEcfVendaCabecalho)
        {
            try
            {
                pEcfVendaCabecalho.Logss = "0";
                MemoryStream StreamJson = new MemoryStream();
                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(EcfVendaCabecalhoDTO));
                SerializaJson.WriteObject(StreamJson, pEcfVendaCabecalho);
                StreamReader LerStreamJson = new StreamReader(StreamJson);
                StreamJson.Position = 0;
                pEcfVendaCabecalho.Logss = Biblioteca.MD5String(LerStreamJson.ReadToEnd());

                EcfVendaCabecalhoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfVendaCabecalhoDTO> DAL = new NHibernateDAL<EcfVendaCabecalhoDTO>(Session);
                    Resultado = DAL.SaveOrUpdate(pEcfVendaCabecalho);

                    for (int i = 0; i <= pEcfVendaCabecalho.ListaEcfVendaDetalhe.Count; i++)
                    {
                        pEcfVendaCabecalho.ListaEcfVendaDetalhe[i].TotalizadorParcial = "Can-T";
                        pEcfVendaCabecalho.ListaEcfVendaDetalhe[i].Cancelado = "S";
                        pEcfVendaCabecalho.ListaEcfVendaDetalhe[i].Ccf = pEcfVendaCabecalho.Ccf;
                        pEcfVendaCabecalho.ListaEcfVendaDetalhe[i].Coo = pEcfVendaCabecalho.Coo;
                        pEcfVendaCabecalho.ListaEcfVendaDetalhe[i].Logss = "0";

                        MemoryStream StreamJsonDetalhe = new MemoryStream();
                        DataContractJsonSerializer SerializaJsonDetalhe = new DataContractJsonSerializer(typeof(EcfVendaDetalheDTO));
                        SerializaJsonDetalhe.WriteObject(StreamJsonDetalhe, pEcfVendaCabecalho.ListaEcfVendaDetalhe[i]);
                        StreamReader LerStreamJsonDetalhe = new StreamReader(StreamJsonDetalhe);
                        StreamJsonDetalhe.Position = 0;
                        pEcfVendaCabecalho.ListaEcfVendaDetalhe[i].Logss = Biblioteca.MD5String(LerStreamJsonDetalhe.ReadToEnd());

                        NHibernateDAL<EcfVendaDetalheDTO> DALDetalhe = new NHibernateDAL<EcfVendaDetalheDTO>(Session);
                        DALDetalhe.SaveOrUpdate(pEcfVendaCabecalho.ListaEcfVendaDetalhe[i]);
                    }

                    for (int i = 0; i <= pEcfVendaCabecalho.ListaEcfTotalTipoPagamento.Count; i++)
                    {
                        pEcfVendaCabecalho.ListaEcfTotalTipoPagamento[i].Estorno = "S";
                        pEcfVendaCabecalho.ListaEcfTotalTipoPagamento[i].Logss = "0";

                        MemoryStream StreamJsonPagamento = new MemoryStream();
                        DataContractJsonSerializer SerializaJsonPagamento = new DataContractJsonSerializer(typeof(EcfTotalTipoPagamentoDTO));
                        SerializaJsonPagamento.WriteObject(StreamJsonPagamento, pEcfVendaCabecalho.ListaEcfTotalTipoPagamento[i]);
                        StreamReader LerStreamJsonPagamento = new StreamReader(StreamJsonPagamento);
                        StreamJsonPagamento.Position = 0;
                        pEcfVendaCabecalho.ListaEcfTotalTipoPagamento[i].Logss = Biblioteca.MD5String(LerStreamJsonPagamento.ReadToEnd());

                        NHibernateDAL<EcfTotalTipoPagamentoDTO> DALPagamento = new NHibernateDAL<EcfTotalTipoPagamentoDTO>(Session);
                        DALPagamento.SaveOrUpdate(pEcfVendaCabecalho.ListaEcfTotalTipoPagamento[i]);
                    }

                }

                return Resultado != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static bool CancelaItemVenda(EcfVendaDetalheDTO pEcfVendaDetalhe)
        {
            try
            {
                pEcfVendaDetalhe.Logss = "0";
                MemoryStream StreamJson = new MemoryStream();
                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(EcfVendaDetalheDTO));
                SerializaJson.WriteObject(StreamJson, pEcfVendaDetalhe);
                StreamReader LerStreamJson = new StreamReader(StreamJson);
                StreamJson.Position = 0;
                pEcfVendaDetalhe.Logss = Biblioteca.MD5String(LerStreamJson.ReadToEnd());

                EcfVendaDetalheDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfVendaDetalheDTO> DAL = new NHibernateDAL<EcfVendaDetalheDTO>(Session);
                    Resultado = DAL.SaveOrUpdate(pEcfVendaDetalhe);
                }

                return Resultado != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

    }

}
