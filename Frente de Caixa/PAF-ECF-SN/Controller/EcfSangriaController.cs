/********************************************************************************
Title: T2TiPDV
Description: Classe de controle da sangria

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

    public class EcfSangriaController
    {

        public static EcfSangriaDTO ConsultaEcfSangria(string pFiltro)
        {
            try
            {
                EcfSangriaDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfSangriaDTO> DAL = new NHibernateDAL<EcfSangriaDTO>(Session);

                    String ConsultaSql = "from EcfSangriaDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<EcfSangriaDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfSangriaDTO> ConsultaEcfSangriaLista(EcfSangriaDTO pEcfSangria)
        {
            try
            {
                IList<EcfSangriaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfSangriaDTO> DAL = new NHibernateDAL<EcfSangriaDTO>(Session);
                    Resultado = DAL.Select(pEcfSangria);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfSangriaDTO> ConsultaEcfSangriaPagina(int pPrimeiroResultado, int pQuantidadeResultados, EcfSangriaDTO pEcfSangria)
        {
            try
            {
                IList<EcfSangriaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfSangriaDTO> DAL = new NHibernateDAL<EcfSangriaDTO>(Session);
                    Resultado = DAL.SelectPagina<EcfSangriaDTO>(pPrimeiroResultado, pQuantidadeResultados, pEcfSangria);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static EcfSangriaDTO GravaEcfSangria(EcfSangriaDTO pEcfSangria)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfSangriaDTO> DAL = new NHibernateDAL<EcfSangriaDTO>(Session);
                    DAL.SaveOrUpdate(pEcfSangria);
                    Session.Flush();
                }
                return pEcfSangria;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int ExcluiEcfSangria(EcfSangriaDTO pEcfSangria)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfSangriaDTO> DAL = new NHibernateDAL<EcfSangriaDTO>(Session);
                    DAL.Delete(pEcfSangria);
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
