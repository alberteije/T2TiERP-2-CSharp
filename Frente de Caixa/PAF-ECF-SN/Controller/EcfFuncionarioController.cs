/********************************************************************************
Title: T2TiPDV
Description: Classe de controle do Funcionario

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

namespace PafEcf.Controller
{

    public class EcfFuncionarioController
    {

        public static EcfFuncionarioDTO ConsultaFuncionario(string pFiltro)
        {
            try
            {
                EcfFuncionarioDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfFuncionarioDTO> DAL = new NHibernateDAL<EcfFuncionarioDTO>(Session);

                    String ConsultaSql = "from EcfFuncionarioDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<EcfFuncionarioDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfFuncionarioDTO> ConsultaFuncionarioLista(EcfFuncionarioDTO pFuncionario)
        {
            try
            {
                IList<EcfFuncionarioDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfFuncionarioDTO> DAL = new NHibernateDAL<EcfFuncionarioDTO>(Session);
                    Resultado = DAL.Select(pFuncionario);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfFuncionarioDTO> ConsultaFuncionarioPagina(int pPrimeiroResultado, int pQuantidadeResultados, EcfFuncionarioDTO pFuncionario)
        {
            try
            {
                IList<EcfFuncionarioDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfFuncionarioDTO> DAL = new NHibernateDAL<EcfFuncionarioDTO>(Session);
                    Resultado = DAL.SelectPagina<EcfFuncionarioDTO>(pPrimeiroResultado, pQuantidadeResultados, pFuncionario);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static EcfOperadorDTO Usuario(String pLogin, String pSenha)
        {
            try
            {
                EcfOperadorDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfOperadorDTO> DAL = new NHibernateDAL<EcfOperadorDTO>(Session);

                    String ConsultaSql = "from EcfOperadorDTO where Login=" + Biblioteca.QuotedStr(pLogin) + " and Senha=" + Biblioteca.QuotedStr(pSenha);
                    Resultado = DAL.SelectObjetoSql<EcfOperadorDTO>(ConsultaSql);
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
