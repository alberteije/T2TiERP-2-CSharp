/********************************************************************************
Title: T2TiPDV
Description: Classe de controle do R02

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
using System.IO;
using System.Runtime.Serialization.Json;

namespace PafEcf.Controller
{

    public class R02Controller
    {

        public static R02DTO ConsultaR02(string pFiltro)
        {
            try
            {
                R02DTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<R02DTO> DAL = new NHibernateDAL<R02DTO>(Session);

                    String ConsultaSql = "from R02DTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<R02DTO>(ConsultaSql);

                    // Consulta lista de detalhes
                    NHibernateDAL<R03DTO> DALDetalhe = new NHibernateDAL<R03DTO>(Session);
                    Resultado.ListaR03 = DALDetalhe.Select<R03DTO>(
                        new R03DTO { IdR02 = Resultado.Id });

                    if (Resultado.ListaR03 == null)
                        Resultado.ListaR03 = new List<R03DTO>();
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<R02DTO> ConsultaR02Lista(string pFiltro)
        {
            try
            {
                IList<R02DTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<R02DTO> DAL = new NHibernateDAL<R02DTO>(Session);

                    String ConsultaSql = "from R02DTO where " + pFiltro;
                    Resultado = DAL.SelectListaSql<R02DTO>(ConsultaSql);

                    // Consulta lista de detalhes
                    for (int i = 0; i <= Resultado.Count - 1; i++)
                    {
                        NHibernateDAL<R03DTO> DALDetalhe = new NHibernateDAL<R03DTO>(Session);
                        Resultado[i].ListaR03 = DALDetalhe.Select<R03DTO>(
                            new R03DTO { IdR02 = Resultado[i].Id });

                        if (Resultado[i].ListaR03 == null)
                            Resultado[i].ListaR03 = new List<R03DTO>();
                    }
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<R02DTO> ConsultaR02Pagina(int pPrimeiroResultado, int pQuantidadeResultados, R02DTO pR02)
        {
            try
            {
                IList<R02DTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<R02DTO> DAL = new NHibernateDAL<R02DTO>(Session);
                    Resultado = DAL.SelectPagina<R02DTO>(pPrimeiroResultado, pQuantidadeResultados, pR02);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static R02DTO GravaR02(R02DTO pR02)
        {
            try
            {
                pR02.Logss = "0";
                MemoryStream StreamJson = new MemoryStream();
                DataContractJsonSerializer SerializaJson = new DataContractJsonSerializer(typeof(R02DTO));
                SerializaJson.WriteObject(StreamJson, pR02);
                StreamReader LerStreamJson = new StreamReader(StreamJson);
                StreamJson.Position = 0;
                pR02.Logss = Biblioteca.MD5String(LerStreamJson.ReadToEnd());

                R02DTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<R02DTO> DAL = new NHibernateDAL<R02DTO>(Session);
                    Resultado = DAL.SaveOrUpdate(pR02);

                    for (int i = 0; i <= pR02.ListaR03.Count; i++)
                    {
                        pR02.ListaR03[i].SerieEcf = Sessao.Instance.Configuracao.EcfImpressora.Serie;
                        pR02.ListaR03[i].Logss = "0";

                        MemoryStream StreamJsonDetalhe = new MemoryStream();
                        DataContractJsonSerializer SerializaJsonDetalhe = new DataContractJsonSerializer(typeof(R03DTO));
                        SerializaJsonDetalhe.WriteObject(StreamJsonDetalhe, pR02.ListaR03[i]);
                        StreamReader LerStreamJsonDetalhe = new StreamReader(StreamJsonDetalhe);
                        StreamJsonDetalhe.Position = 0;
                        pR02.ListaR03[i].Logss = Biblioteca.MD5String(LerStreamJsonDetalhe.ReadToEnd());

                        NHibernateDAL<R03DTO> DALDetalhe = new NHibernateDAL<R03DTO>(Session);
                        DALDetalhe.SaveOrUpdate(pR02.ListaR03[i]);
                    }
                    
                    Session.Flush();
                }
                return pR02;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static int ExcluiR02(R02DTO pR02)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<R02DTO> DAL = new NHibernateDAL<R02DTO>(Session);
                    DAL.Delete(pR02);
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
