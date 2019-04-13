/********************************************************************************
Title: T2TiNFCe
Description: Classe de controle do produto.

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

    public class ProdutoController
    {

        public static ProdutoDTO ConsultaProduto(string pFiltro)
        {
            try
            {
                ProdutoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);

                    String ConsultaSql = "from ProdutoDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<ProdutoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static ProdutoDTO ConsultaPorTipo(string pCodigo, int pTipo)
        {
            try
            {
                string Filtro = "";
                ProdutoDTO Resultado = null;

                switch (pTipo)
                {
                    case 1: // pesquisa pelo codigo da balanca
                        Filtro = "CodigoBalanca = " + Biblioteca.QuotedStr(pCodigo);
                        break;
                    case 2: // pesquisa pelo GTIN
                        Filtro = "Gtin = " + Biblioteca.QuotedStr(pCodigo);
                        break;
                    case 3: // pesquisa pelo CODIGO_INTERNO
                        Filtro = "CodigoInterno = " + Biblioteca.QuotedStr(pCodigo);
                        break;
                    case 4: // pesquisa pelo Id
                        Filtro = "Id = " + Biblioteca.QuotedStr(pCodigo);
                        break;
                    default: // retorna null
                        Filtro = "1=0";
                        break;
                }

                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);

                    String ConsultaSql = "from ProdutoDTO where " + Filtro;
                    Resultado = DAL.SelectObjetoSql<ProdutoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<ProdutoDTO> ConsultaProdutoLista(string pFiltro)
        {
            try
            {
                IList<ProdutoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);

                    String ConsultaSql = "from ProdutoDTO where " + pFiltro;
                    Resultado = DAL.SelectListaSql<ProdutoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<ProdutoDTO> ConsultaProdutoPagina(int pPrimeiroResultado, int pQuantidadeResultados, ProdutoDTO pProduto)
        {
            try
            {
                IList<ProdutoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);
                    Resultado = DAL.SelectPagina<ProdutoDTO>(pPrimeiroResultado, pQuantidadeResultados, pProduto);
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
