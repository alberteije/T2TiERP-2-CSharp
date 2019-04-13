/********************************************************************************
Title: T2TiNFCe
Description: Classe de controle do movimento.

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

    public class NfceMovimentoController
    {

        public static NfceMovimentoDTO ConsultaNfceMovimento(string pFiltro)
        {
            try
            {
                NfceMovimentoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceMovimentoDTO> DAL = new NHibernateDAL<NfceMovimentoDTO>(Session);

                    String ConsultaSql = "from NfceMovimentoDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<NfceMovimentoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfceMovimentoDTO> ConsultaNfceMovimentoLista(NfceMovimentoDTO pNfceMovimento)
        {
            try
            {
                IList<NfceMovimentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceMovimentoDTO> DAL = new NHibernateDAL<NfceMovimentoDTO>(Session);
                    Resultado = DAL.Select(pNfceMovimento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfceMovimentoDTO> ConsultaNfceMovimentoPagina(int pPrimeiroResultado, int pQuantidadeResultados, NfceMovimentoDTO pNfceMovimento)
        {
            try
            {
                IList<NfceMovimentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceMovimentoDTO> DAL = new NHibernateDAL<NfceMovimentoDTO>(Session);
                    Resultado = DAL.SelectPagina<NfceMovimentoDTO>(pPrimeiroResultado, pQuantidadeResultados, pNfceMovimento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static NfceMovimentoDTO GravaNfceMovimento(NfceMovimentoDTO pNfceMovimento)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceMovimentoDTO> DAL = new NHibernateDAL<NfceMovimentoDTO>(Session);
                    DAL.SaveOrUpdate(pNfceMovimento);
                    Session.Flush();
                }
                return pNfceMovimento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
    }

}
