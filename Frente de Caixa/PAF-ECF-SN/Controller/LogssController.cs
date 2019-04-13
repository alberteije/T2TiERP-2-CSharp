/********************************************************************************
Title: T2TiPDV
Description: Classe de controle de log de segurança

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


namespace PafEcf.Controller
{

    public class LogssController
    {

        public static bool VerificarQuantidades()
        {
            try
            {
                int TotalProduto = 0;
                int TotalTTP = 0;
                int TotalR01 = 0;
                int TotalR02 = 0;
                int TotalR03 = 0;
                int TotalR04 = 0;
                int TotalR05 = 0;
                int TotalR06 = 0;
                int TotalR07 = 0;

                LogssDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<LogssDTO> DAL = new NHibernateDAL<LogssDTO>(Session);

                    String ConsultaSql = "from LogssDTO where Id=1";
                    Resultado = DAL.SelectObjetoSql<LogssDTO>(ConsultaSql);

                    TotalProduto = (int)Session.CreateQuery("select count(*) from ProdutoDTO").UniqueResult();
                    TotalTTP = (int)Session.CreateQuery("select count(*) from EcfTotalTipoPagamentoDTO").UniqueResult();
                    TotalR01 = (int)Session.CreateQuery("select count(*) from R01DTO").UniqueResult();
                    TotalR02 = (int)Session.CreateQuery("select count(*) from R02DTO").UniqueResult();
                    TotalR03 = (int)Session.CreateQuery("select count(*) from R03DTO").UniqueResult();
                    TotalR04 = (int)Session.CreateQuery("select count(*) from EcfVendaCabecalhoDTO").UniqueResult();
                    TotalR05 = (int)Session.CreateQuery("select count(*) from EcfVendaDetalheDTO").UniqueResult();
                    TotalR06 = (int)Session.CreateQuery("select count(*) from R06DTO").UniqueResult();
                    TotalR07 = (int)Session.CreateQuery("select count(*) from R07DTO").UniqueResult();
                }
                if (
                    (TotalProduto == Resultado.Produto.Value) &&
                    (TotalTTP == Resultado.Ttp.Value) &&
                    (TotalR01 == Resultado.R01.Value) &&
                    (TotalR02 == Resultado.R02.Value) &&
                    (TotalR03 == Resultado.R03.Value) &&
                    (TotalR04 == Resultado.R04.Value) &&
                    (TotalR05 == Resultado.R05.Value) &&
                    (TotalR06 == Resultado.R06.Value) &&
                    (TotalR07 == Resultado.R07.Value)
                )
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public static bool AtualizarQuantidades()
        {
            try
            {
                int TotalProduto = 0;
                int TotalTTP = 0;
                int TotalR01 = 0;
                int TotalR02 = 0;
                int TotalR03 = 0;
                int TotalR04 = 0;
                int TotalR05 = 0;
                int TotalR06 = 0;
                int TotalR07 = 0;

                LogssDTO Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<LogssDTO> DAL = new NHibernateDAL<LogssDTO>(Session);

                    String ConsultaSql = "from LogssDTO where Id=1";
                    Resultado = DAL.SelectObjetoSql<LogssDTO>(ConsultaSql);

                    TotalProduto = (int)Session.CreateQuery("select count(*) from ProdutoDTO").UniqueResult();
                    TotalTTP = (int)Session.CreateQuery("select count(*) from EcfTotalTipoPagamentoDTO").UniqueResult();
                    TotalR01 = (int)Session.CreateQuery("select count(*) from R01DTO").UniqueResult();
                    TotalR02 = (int)Session.CreateQuery("select count(*) from R02DTO").UniqueResult();
                    TotalR03 = (int)Session.CreateQuery("select count(*) from R03DTO").UniqueResult();
                    TotalR04 = (int)Session.CreateQuery("select count(*) from EcfVendaCabecalhoDTO").UniqueResult();
                    TotalR05 = (int)Session.CreateQuery("select count(*) from EcfVendaDetalheDTO").UniqueResult();
                    TotalR06 = (int)Session.CreateQuery("select count(*) from R06DTO").UniqueResult();
                    TotalR07 = (int)Session.CreateQuery("select count(*) from R07DTO").UniqueResult();

                    Resultado.Produto = TotalProduto;
                    Resultado.Ttp = TotalTTP;
                    Resultado.R01 = TotalR01;
                    Resultado.R02 = TotalR02;
                    Resultado.R03 = TotalR03;
                    Resultado.R04 = TotalR04;
                    Resultado.R05 = TotalR05;
                    Resultado.R06 = TotalR06;
                    Resultado.R07 = TotalR07;

                    Session.Save(Resultado);

                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


    }

}
