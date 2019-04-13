/********************************************************************************
Title: T2TiPDV
Description: Classe de controle do Sintegra60M

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

    public class Sintegra60MController
    {

        public static Sintegra60mDTO ConsultaSintegra60M(string pFiltro)
        {
            try
            {
                Sintegra60mDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<Sintegra60mDTO> DAL = new NHibernateDAL<Sintegra60mDTO>(Session);

                    String ConsultaSql = "from Sintegra60mDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<Sintegra60mDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<Sintegra60mDTO> ConsultaSintegra60MLista(Sintegra60mDTO pSintegra60M)
        {
            try
            {
                IList<Sintegra60mDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<Sintegra60mDTO> DAL = new NHibernateDAL<Sintegra60mDTO>(Session);
                    Resultado = DAL.Select(pSintegra60M);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<Sintegra60mDTO> ConsultaSintegra60MPagina(int pPrimeiroResultado, int pQuantidadeResultados, Sintegra60mDTO pSintegra60M)
        {
            try
            {
                IList<Sintegra60mDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<Sintegra60mDTO> DAL = new NHibernateDAL<Sintegra60mDTO>(Session);
                    Resultado = DAL.SelectPagina<Sintegra60mDTO>(pPrimeiroResultado, pQuantidadeResultados, pSintegra60M);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static Sintegra60mDTO GravaSintegra60M(Sintegra60mDTO pSintegra60M)
        {
            try
            {
                Sintegra60mDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<Sintegra60mDTO> DAL = new NHibernateDAL<Sintegra60mDTO>(Session);
                    Resultado = DAL.SaveOrUpdate(pSintegra60M);

                    for (int i = 0; i <= pSintegra60M.Lista60A.Count; i++)
                    {
                        NHibernateDAL<Sintegra60aDTO> DALDetalhe = new NHibernateDAL<Sintegra60aDTO>(Session);
                        DALDetalhe.SaveOrUpdate(pSintegra60M.Lista60A[i]);
                    }

                    Session.Flush();
                }
                return pSintegra60M;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int ExcluiSintegra60M(Sintegra60mDTO pSintegra60M)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<Sintegra60mDTO> DAL = new NHibernateDAL<Sintegra60mDTO>(Session);
                    DAL.Delete(pSintegra60M);
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
