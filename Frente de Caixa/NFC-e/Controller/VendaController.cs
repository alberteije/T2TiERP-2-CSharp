/********************************************************************************
Title: T2TiNFCe
Description: Classe de controle da Venda

The MIT License

Copyright: Copyright (C) 2015 T2Ti.COM

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
@version 1.0
********************************************************************************/


using System;
using NFCe.DTO;
using NHibernate;
using NFCe.NHibernate;
using System.Collections.Generic;
using NFCe.Util;
using System.IO;

namespace NFCe.Controller
{

    public class VendaController
    {

        public static NfeCabecalhoDTO ConsultaNfceVendaCabecalho(string pFiltro)
        {
            try
            {
                NfeCabecalhoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> DAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);

                    String ConsultaSql = "from NfeCabecalhoDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<NfeCabecalhoDTO>(ConsultaSql);

                    if (Resultado != null)
                    {
                        // Consulta lista de detalhes
                        NHibernateDAL<NfeDetalheDTO> DALDetalhe = new NHibernateDAL<NfeDetalheDTO>(Session);
                        Resultado.ListaNfeDetalhe = DALDetalhe.Select<NfeDetalheDTO>(
                            new NfeDetalheDTO { IdNfeCabecalho = Resultado.Id });

                        // Consulta lista de pagamentos
                        NHibernateDAL<NfeFormaPagamentoDTO> DALPagamento = new NHibernateDAL<NfeFormaPagamentoDTO>(Session);
                        Resultado.ListaNfeFormaPagamento = DALPagamento.Select<NfeFormaPagamentoDTO>(
                            new NfeFormaPagamentoDTO { IdNfeCabecalho = Resultado.Id });
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfeCabecalhoDTO> ConsultaNfceVendaCabecalhoLista(string pFiltro)
        {
            try
            {
                IList<NfeCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> DAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);

                    String ConsultaSql = "from NfeCabecalhoDTO where " + pFiltro;
                    Resultado = DAL.SelectListaSql<NfeCabecalhoDTO>(ConsultaSql);

                    if (Resultado != null)
                    {
                        for (int i = 0; i <= Resultado.Count - 1; i++)
                        {
                            // Consulta lista de detalhes
                            NHibernateDAL<NfeDetalheDTO> DALDetalhe = new NHibernateDAL<NfeDetalheDTO>(Session);
                            Resultado[i].ListaNfeDetalhe = DALDetalhe.Select<NfeDetalheDTO>(
                                new NfeDetalheDTO { IdNfeCabecalho = Resultado[i].Id });

                            // Consulta lista de pagamentos
                            NHibernateDAL<NfeFormaPagamentoDTO> DALPagamento = new NHibernateDAL<NfeFormaPagamentoDTO>(Session);
                            Resultado[i].ListaNfeFormaPagamento = DALPagamento.Select<NfeFormaPagamentoDTO>(
                                new NfeFormaPagamentoDTO { IdNfeCabecalho = Resultado[i].Id });
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

        public static IList<NfeCabecalhoDTO> ConsultaNfceVendaCabecalhoListaLimpa(string pFiltro)
        {
            try
            {
                IList<NfeCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> DAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);

                    String ConsultaSql = "from NfeCabecalhoDTO where " + pFiltro;
                    Resultado = DAL.SelectListaSql<NfeCabecalhoDTO>(ConsultaSql);
                    
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfeCabecalhoDTO> ConsultaNfceVendaCabecalhoPagina(int pPrimeiroResultado, int pQuantidadeResultados, NfeCabecalhoDTO pNfceVendaCabecalho)
        {
            try
            {
                IList<NfeCabecalhoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> DAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);
                    Resultado = DAL.SelectPagina<NfeCabecalhoDTO>(pPrimeiroResultado, pQuantidadeResultados, pNfceVendaCabecalho);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static NfeCabecalhoDTO GravaNfceVendaCabecalho(NfeCabecalhoDTO pNfceVendaCabecalho)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> DAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);
                    DAL.SaveOrUpdate(pNfceVendaCabecalho);
                    Session.Flush();
                }
                return pNfceVendaCabecalho;
            }
            catch (Exception ex)
            {
                Log.write(ex.ToString());
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static NfeDetalheDTO GravaNfceVendaDetalhe(NfeDetalheDTO pNfceVendaDetalhe)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeDetalheDTO> DAL = new NHibernateDAL<NfeDetalheDTO>(Session);
                    DAL.SaveOrUpdate(pNfceVendaDetalhe);
                    Session.Flush();
                }
                return pNfceVendaDetalhe;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int ExcluiNfceVendaCabecalho(NfeCabecalhoDTO pNfceVendaCabecalho)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> DAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);
                    DAL.Delete(pNfceVendaCabecalho);
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

        public static bool CancelaVenda(NfeCabecalhoDTO pNfceVendaCabecalho)
        {
            try
            {
                NfeCabecalhoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeCabecalhoDTO> DAL = new NHibernateDAL<NfeCabecalhoDTO>(Session);
                    Resultado = DAL.SaveOrUpdate(pNfceVendaCabecalho);

                    for (int i = 0; i <= pNfceVendaCabecalho.ListaNfeDetalhe.Count; i++)
                    {
                        NHibernateDAL<NfeDetalheDTO> DALDetalhe = new NHibernateDAL<NfeDetalheDTO>(Session);
                        DALDetalhe.SaveOrUpdate(pNfceVendaCabecalho.ListaNfeDetalhe[i]);
                    }

                    for (int i = 0; i <= pNfceVendaCabecalho.ListaNfeFormaPagamento.Count; i++)
                    {
                        pNfceVendaCabecalho.ListaNfeFormaPagamento[i].Estorno = "S";
                        NHibernateDAL<NfeFormaPagamentoDTO> DALPagamento = new NHibernateDAL<NfeFormaPagamentoDTO>(Session);
                        DALPagamento.SaveOrUpdate(pNfceVendaCabecalho.ListaNfeFormaPagamento[i]);
                    }

                }

                return Resultado != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int CancelaItemVenda(int pItem)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeDetalheDTO> DALDetalhe = new NHibernateDAL<NfeDetalheDTO>(Session);
                    NfeDetalheDTO Detalhe =  DALDetalhe.SelectObjeto<NfeDetalheDTO>(
                                                new NfeDetalheDTO { NumeroItem = pItem, IdNfeCabecalho = Sessao.Instance.VendaAtual.Id }
                                                );

                    if (Detalhe != null)
                    {
                        // Se o item existe na base, exclui o imposto e o item
                        NfeDetalheImpostoIcmsDTO Icms = new NfeDetalheImpostoIcmsDTO();
                        Icms.IdNfeDetalhe = Detalhe.Id;

                        NHibernateDAL<NfeDetalheImpostoIcmsDTO> DALIcms = new NHibernateDAL<NfeDetalheImpostoIcmsDTO>(Session);
                        DALIcms.Delete(Icms);

                        DALDetalhe.Delete(Detalhe);

                        Session.Flush();
                        Resultado = 0;
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
            
        }

    }

}
