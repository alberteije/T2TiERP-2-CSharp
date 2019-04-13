/********************************************************************************
Title: T2TiPDV
Description: Classe de controle do total dos tipos de pagamento

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
using PafEcf.View;
using System.IO;
using System.Runtime.Serialization.Json;

namespace PafEcf.Controller
{

    public class EcfTotalTipoPagamentoController
    {

        public static EcfTotalTipoPagamentoDTO ConsultaEcfTotalTipoPagamento(string pFiltro)
        {
            try
            {
                EcfTotalTipoPagamentoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfTotalTipoPagamentoDTO> DAL = new NHibernateDAL<EcfTotalTipoPagamentoDTO>(Session);

                    String ConsultaSql = "from EcfTotalTipoPagamento where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<EcfTotalTipoPagamentoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfTotalTipoPagamentoDTO> ConsultaEcfTotalTipoPagamentoLista(string pFiltro)
        {
            try
            {
                IList<EcfTotalTipoPagamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfTotalTipoPagamentoDTO> DAL = new NHibernateDAL<EcfTotalTipoPagamentoDTO>(Session);

                    String ConsultaSql = "from EcfTotalTipoPagamento where " + pFiltro;
                    Resultado = DAL.SelectListaSql<EcfTotalTipoPagamentoDTO>(ConsultaSql);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<EcfTotalTipoPagamentoDTO> ConsultaEcfTotalTipoPagamentoPagina(int pPrimeiroResultado, int pQuantidadeResultados, EcfTotalTipoPagamentoDTO pEcfTotalTipoPagamento)
        {
            try
            {
                IList<EcfTotalTipoPagamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfTotalTipoPagamentoDTO> DAL = new NHibernateDAL<EcfTotalTipoPagamentoDTO>(Session);
                    Resultado = DAL.SelectPagina<EcfTotalTipoPagamentoDTO>(pPrimeiroResultado, pQuantidadeResultados, pEcfTotalTipoPagamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static EcfTotalTipoPagamentoDTO GravaEcfTotalTipoPagamento(EcfTotalTipoPagamentoDTO pEcfTotalTipoPagamento)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfTotalTipoPagamentoDTO> DAL = new NHibernateDAL<EcfTotalTipoPagamentoDTO>(Session);
                    DAL.SaveOrUpdate(pEcfTotalTipoPagamento);
                    Session.Flush();
                }
                return pEcfTotalTipoPagamento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static void GravaEcfTotalTipoPagamentoLista(List<EcfTotalTipoPagamentoDTO> pListaEcfTotalTipoPagamento)
        {
            try
            {
                MemoryStream StreamJson = new MemoryStream();
                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(EcfTotalTipoPagamentoDTO));

                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfTotalTipoPagamentoDTO> DAL = new NHibernateDAL<EcfTotalTipoPagamentoDTO>(Session);
                    for (int i = 0; i < pListaEcfTotalTipoPagamento.Count; i++)
                    {
                        pListaEcfTotalTipoPagamento[i].DataVenda = DataModule.ACBrECF.DataHora; 
                        pListaEcfTotalTipoPagamento[i].Logss = "0";
                        SerializaJson.WriteObject(StreamJson, pListaEcfTotalTipoPagamento[i]);
                        StreamReader LerStreamJson = new StreamReader(StreamJson);
                        StreamJson.Position = 0;
                        pListaEcfTotalTipoPagamento[i].Logss = Biblioteca.MD5String(LerStreamJson.ReadToEnd());

                        DAL.SaveOrUpdate(pListaEcfTotalTipoPagamento[i]);
                        Session.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int ExcluiEcfTotalTipoPagamento(EcfTotalTipoPagamentoDTO pEcfTotalTipoPagamento)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<EcfTotalTipoPagamentoDTO> DAL = new NHibernateDAL<EcfTotalTipoPagamentoDTO>(Session);
                    DAL.Delete(pEcfTotalTipoPagamento);
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
