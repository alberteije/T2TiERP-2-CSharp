/********************************************************************************
Title: T2TiNFCe
Description: Classe de controle do Operador

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

    public class NfceOperadorController
    {

        public static NfceOperadorDTO ConsultaNfceOperador(string pFiltro)
        {
            try
            {
                NfceOperadorDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceOperadorDTO> DAL = new NHibernateDAL<NfceOperadorDTO>(Session);

                    String ConsultaSql = "from NfceOperadorDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<NfceOperadorDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfceOperadorDTO> ConsultaNfceOperadorLista(NfceOperadorDTO pNfceOperador)
        {
            try
            {
                IList<NfceOperadorDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceOperadorDTO> DAL = new NHibernateDAL<NfceOperadorDTO>(Session);
                    Resultado = DAL.Select(pNfceOperador);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfceOperadorDTO> ConsultaNfceOperadorPagina(int pPrimeiroResultado, int pQuantidadeResultados, NfceOperadorDTO pNfceOperador)
        {
            try
            {
                IList<NfceOperadorDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceOperadorDTO> DAL = new NHibernateDAL<NfceOperadorDTO>(Session);
                    Resultado = DAL.SelectPagina<NfceOperadorDTO>(pPrimeiroResultado, pQuantidadeResultados, pNfceOperador);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static NfceOperadorDTO Usuario(String pLogin, String pSenha)
        {
            try
            {
                NfceOperadorDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceOperadorDTO> DAL = new NHibernateDAL<NfceOperadorDTO>(Session);

                    String ConsultaSql = "from NfceOperadorDTO where Login=" + Biblioteca.QuotedStr(pLogin) + " and Senha=" + Biblioteca.QuotedStr(pSenha);
                    Resultado = DAL.SelectObjetoSql<NfceOperadorDTO>(ConsultaSql);
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
