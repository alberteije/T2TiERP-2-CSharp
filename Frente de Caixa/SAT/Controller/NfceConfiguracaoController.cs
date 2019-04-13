/********************************************************************************
Title: T2TiNFCe
Description: Classe de controle da Configuracao NFCe

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

    public class NfceConfiguracaoController
    {

        public static NfceConfiguracaoDTO ConsultaNfceConfiguracao(string pFiltro)
        {
            try
            {
                NfceConfiguracaoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceConfiguracaoDTO> DAL = new NHibernateDAL<NfceConfiguracaoDTO>(Session);

                    String ConsultaSql = "from NfceConfiguracaoDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<NfceConfiguracaoDTO>(ConsultaSql);

                    if (Resultado.Empresa.ListaEndereco != null)
                    {
                        for (int i = 0; i <= Resultado.Empresa.ListaEndereco.Count - 1; i++)
                        {
                            if (Resultado.Empresa.ListaEndereco[i].Principal == "S")
                                Resultado.Empresa.EnderecoPrincipal = Resultado.Empresa.ListaEndereco[i];
                        }
                    }

                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfceConfiguracaoDTO> ConsultaNfceConfiguracaoLista(NfceConfiguracaoDTO pNfceConfiguracao)
        {
            try
            {
                IList<NfceConfiguracaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceConfiguracaoDTO> DAL = new NHibernateDAL<NfceConfiguracaoDTO>(Session);
                    Resultado = DAL.Select(pNfceConfiguracao);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static IList<NfceConfiguracaoDTO> ConsultaNfceConfiguracaoPagina(int pPrimeiroResultado, int pQuantidadeResultados, NfceConfiguracaoDTO pNfceConfiguracao)
        {
            try
            {
                IList<NfceConfiguracaoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NfceConfiguracaoDTO> DAL = new NHibernateDAL<NfceConfiguracaoDTO>(Session);
                    Resultado = DAL.SelectPagina<NfceConfiguracaoDTO>(pPrimeiroResultado, pQuantidadeResultados, pNfceConfiguracao);
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