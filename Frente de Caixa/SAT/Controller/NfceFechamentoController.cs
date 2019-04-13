/********************************************************************************
Title: T2TiNFCe
Description: Classe de controle do fechamento

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

namespace NFCe.Controller
{

    public class NfceFechamentoController
    {

        public static NfceFechamentoDTO ConsultaNfceFechamento(string pFiltro)
        {
            try
            {
                NfceFechamentoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceFechamentoDTO> DAL = new NHibernateDAL<NfceFechamentoDTO>(Session);

                    String ConsultaSql = "from NfceFechamentoDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<NfceFechamentoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfceFechamentoDTO> ConsultaNfceFechamentoLista(string pFiltro)
        {
            try
            {
                IList<NfceFechamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceFechamentoDTO> DAL = new NHibernateDAL<NfceFechamentoDTO>(Session);

                    String ConsultaSql = "from NfceFechamentoDTO where " + pFiltro;
                    Resultado = DAL.SelectListaSql<NfceFechamentoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfceFechamentoDTO> ConsultaNfceFechamentoPagina(int pPrimeiroResultado, int pQuantidadeResultados, NfceFechamentoDTO pNfceFechamento)
        {
            try
            {
                IList<NfceFechamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceFechamentoDTO> DAL = new NHibernateDAL<NfceFechamentoDTO>(Session);
                    Resultado = DAL.SelectPagina<NfceFechamentoDTO>(pPrimeiroResultado, pQuantidadeResultados, pNfceFechamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static NfceFechamentoDTO GravaNfceFechamento(NfceFechamentoDTO pNfceFechamento)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceFechamentoDTO> DAL = new NHibernateDAL<NfceFechamentoDTO>(Session);
                    DAL.SaveOrUpdate(pNfceFechamento);
                    Session.Flush();
                }
                return pNfceFechamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int ExcluiNfceFechamento(NfceFechamentoDTO pNfceFechamento)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceFechamentoDTO> DAL = new NHibernateDAL<NfceFechamentoDTO>(Session);
                    DAL.Delete(pNfceFechamento);
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
