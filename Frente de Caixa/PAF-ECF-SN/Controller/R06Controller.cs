/********************************************************************************
Title: T2TiPDV
Description: Classe de controle do R06

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

    public class R06Controller
    {

        public static R06DTO ConsultaR06(string pFiltro)
        {
            try
            {
                R06DTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<R06DTO> DAL = new NHibernateDAL<R06DTO>(Session);

                    String ConsultaSql = "from R06DTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<R06DTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<R06DTO> ConsultaR06Lista(string pFiltro)
        {
            try
            {
                IList<R06DTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<R06DTO> DAL = new NHibernateDAL<R06DTO>(Session);

                    String ConsultaSql = "from R06DTO where " + pFiltro;
                    Resultado = DAL.SelectListaSql<R06DTO>(ConsultaSql);

                    // Consulta lista de detalhes
                    for (int i = 0; i <= Resultado.Count - 1; i++)
                    {
                        NHibernateDAL<R07DTO> DALDetalhe = new NHibernateDAL<R07DTO>(Session);
                        Resultado[i].ListaR07 = DALDetalhe.Select<R07DTO>(
                            new R07DTO { IdR06 = Resultado[i].Id });

                        if (Resultado[i].ListaR07 == null)
                            Resultado[i].ListaR07 = new List<R07DTO>();
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<R06DTO> ConsultaR06Pagina(int pPrimeiroResultado, int pQuantidadeResultados, R06DTO pR06)
        {
            try
            {
                IList<R06DTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<R06DTO> DAL = new NHibernateDAL<R06DTO>(Session);
                    Resultado = DAL.SelectPagina<R06DTO>(pPrimeiroResultado, pQuantidadeResultados, pR06);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static R06DTO GravaR06(R06DTO pR06)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<R06DTO> DAL = new NHibernateDAL<R06DTO>(Session);
                    DAL.SaveOrUpdate(pR06);
                    Session.Flush();
                }
                return pR06;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int ExcluiR06(R06DTO pR06)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<R06DTO> DAL = new NHibernateDAL<R06DTO>(Session);
                    DAL.Delete(pR06);
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
