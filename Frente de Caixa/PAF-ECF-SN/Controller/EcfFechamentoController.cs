/********************************************************************************
Title: T2TiPDV
Description: Classe de controle do fechamento

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

    public class EcfFechamentoController
    {

        public static EcfFechamentoDTO ConsultaEcfFechamento(string pFiltro)
        {
            try
            {
                EcfFechamentoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfFechamentoDTO> DAL = new NHibernateDAL<EcfFechamentoDTO>(Session);

                    String ConsultaSql = "from EcfFechamentoDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<EcfFechamentoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfFechamentoDTO> ConsultaEcfFechamentoLista(string pFiltro)
        {
            try
            {
                IList<EcfFechamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfFechamentoDTO> DAL = new NHibernateDAL<EcfFechamentoDTO>(Session);

                    String ConsultaSql = "from EcfFechamentoDTO where " + pFiltro;
                    Resultado = DAL.SelectListaSql<EcfFechamentoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfFechamentoDTO> ConsultaEcfFechamentoPagina(int pPrimeiroResultado, int pQuantidadeResultados, EcfFechamentoDTO pEcfFechamento)
        {
            try
            {
                IList<EcfFechamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfFechamentoDTO> DAL = new NHibernateDAL<EcfFechamentoDTO>(Session);
                    Resultado = DAL.SelectPagina<EcfFechamentoDTO>(pPrimeiroResultado, pQuantidadeResultados, pEcfFechamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static EcfFechamentoDTO GravaEcfFechamento(EcfFechamentoDTO pEcfFechamento)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfFechamentoDTO> DAL = new NHibernateDAL<EcfFechamentoDTO>(Session);
                    DAL.SaveOrUpdate(pEcfFechamento);
                    Session.Flush();
                }
                return pEcfFechamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int ExcluiEcfFechamento(EcfFechamentoDTO pEcfFechamento)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfFechamentoDTO> DAL = new NHibernateDAL<EcfFechamentoDTO>(Session);
                    DAL.Delete(pEcfFechamento);
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
