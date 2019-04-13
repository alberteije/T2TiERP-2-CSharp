/********************************************************************************
Title: T2TiNFCe
Description: Classe de controle do total dos tipos de pagamento

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


using NFCe.DTO;
using NFCe.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;

namespace NFCe.Controller
{

    public class NfeFormaPagamentoController
    {

        public static NfeFormaPagamentoDTO ConsultaNfeFormaPagamento(string pFiltro)
        {
            try
            {
                NfeFormaPagamentoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeFormaPagamentoDTO> DAL = new NHibernateDAL<NfeFormaPagamentoDTO>(Session);

                    String ConsultaSql = "from NfeFormaPagamentoDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<NfeFormaPagamentoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfeFormaPagamentoDTO> ConsultaNfeFormaPagamentoLista(string pFiltro)
        {
            try
            {
                IList<NfeFormaPagamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeFormaPagamentoDTO> DAL = new NHibernateDAL<NfeFormaPagamentoDTO>(Session);

                    String ConsultaSql = "from NfeFormaPagamentoDTO where " + pFiltro;
                    Resultado = DAL.SelectListaSql<NfeFormaPagamentoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfeFormaPagamentoDTO> ConsultaNfeFormaPagamentoPagina(int pPrimeiroResultado, int pQuantidadeResultados, NfeFormaPagamentoDTO pNfeFormaPagamento)
        {
            try
            {
                IList<NfeFormaPagamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeFormaPagamentoDTO> DAL = new NHibernateDAL<NfeFormaPagamentoDTO>(Session);
                    Resultado = DAL.SelectPagina<NfeFormaPagamentoDTO>(pPrimeiroResultado, pQuantidadeResultados, pNfeFormaPagamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static NfeFormaPagamentoDTO GravaNfeFormaPagamento(NfeFormaPagamentoDTO pNfeFormaPagamento)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeFormaPagamentoDTO> DAL = new NHibernateDAL<NfeFormaPagamentoDTO>(Session);
                    DAL.SaveOrUpdate(pNfeFormaPagamento);
                    Session.Flush();
                }
                return pNfeFormaPagamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static void GravaNfeFormaPagamentoLista(List<NfeFormaPagamentoDTO> pListaNfeFormaPagamento)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeFormaPagamentoDTO> DAL = new NHibernateDAL<NfeFormaPagamentoDTO>(Session);
                    for (int i = 0; i < pListaNfeFormaPagamento.Count; i++)
                    {
                        DAL.SaveOrUpdate(pListaNfeFormaPagamento[i]);
                        Session.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int ExcluiNfeFormaPagamento(NfeFormaPagamentoDTO pNfeFormaPagamento)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfeFormaPagamentoDTO> DAL = new NHibernateDAL<NfeFormaPagamentoDTO>(Session);
                    DAL.Delete(pNfeFormaPagamento);
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


    }

}
