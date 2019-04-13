/********************************************************************************
Title: T2TiPDV
Description: Classe de controle do suprimento

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

    public class EcfSuprimentoController
    {

        public static EcfSuprimentoDTO ConsultaEcfSuprimento(string pFiltro)
        {
            try
            {
                EcfSuprimentoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfSuprimentoDTO> DAL = new NHibernateDAL<EcfSuprimentoDTO>(Session);

                    String ConsultaSql = "from EcfSuprimentoDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<EcfSuprimentoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfSuprimentoDTO> ConsultaEcfSuprimentoLista(EcfSuprimentoDTO pEcfSuprimento)
        {
            try
            {
                IList<EcfSuprimentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfSuprimentoDTO> DAL = new NHibernateDAL<EcfSuprimentoDTO>(Session);
                    Resultado = DAL.Select(pEcfSuprimento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfSuprimentoDTO> ConsultaEcfSuprimentoPagina(int pPrimeiroResultado, int pQuantidadeResultados, EcfSuprimentoDTO pEcfSuprimento)
        {
            try
            {
                IList<EcfSuprimentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfSuprimentoDTO> DAL = new NHibernateDAL<EcfSuprimentoDTO>(Session);
                    Resultado = DAL.SelectPagina<EcfSuprimentoDTO>(pPrimeiroResultado, pQuantidadeResultados, pEcfSuprimento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static EcfSuprimentoDTO GravaEcfSuprimento(EcfSuprimentoDTO pEcfSuprimento)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfSuprimentoDTO> DAL = new NHibernateDAL<EcfSuprimentoDTO>(Session);
                    DAL.SaveOrUpdate(pEcfSuprimento);
                    Session.Flush();
                }
                return pEcfSuprimento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int ExcluiEcfSuprimento(EcfSuprimentoDTO pEcfSuprimento)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfSuprimentoDTO> DAL = new NHibernateDAL<EcfSuprimentoDTO>(Session);
                    DAL.Delete(pEcfSuprimento);
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
