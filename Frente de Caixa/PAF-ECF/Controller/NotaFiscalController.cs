/********************************************************************************
Title: T2TiPDV
Description: Classe de controle da NF2

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


using NHibernate;
using PafEcf.DTO;
using PafEcf.NHibernate;
using System;
using System.Collections.Generic;

namespace PafEcf.Controller
{

    public class NotaFiscalController
    {

        public static NotaFiscalCabecalhoDTO ConsultaNotaFiscalCabecalho(string pFiltro)
        {
            try
            {
                NotaFiscalCabecalhoDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<NotaFiscalCabecalhoDTO> DAL = new NHibernateDAL<NotaFiscalCabecalhoDTO>(Session);

                    String ConsultaSql = "from NotaFiscalCabecalhoDTO where " + pFiltro;
                    Resultado = DAL.SelectObjetoSql<NotaFiscalCabecalhoDTO>(ConsultaSql);

                    // Consulta lista de detalhes
                    NHibernateDAL<NotaFiscalDetalheDTO> DALDetalhe = new NHibernateDAL<NotaFiscalDetalheDTO>(Session);
                    Resultado.ListaNotaFiscalDetalhe = DALDetalhe.Select<NotaFiscalDetalheDTO>(
                        new NotaFiscalDetalheDTO { IdNotaFiscalCabecalho = Resultado.Id });

                    if (Resultado.ListaNotaFiscalDetalhe == null)
                        Resultado.ListaNotaFiscalDetalhe = new List<NotaFiscalDetalheDTO>();
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
