using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using CaixaBancosService.NHibernate;

namespace CaixaBancosService.Model
{
    public class MovimentoCaixaBancoDAL : NHibernateDAL<ViewFinMovimentoCaixaBancoDTO>
    {
        public MovimentoCaixaBancoDAL(ISession session) : base(session) { }

        public IList<ViewFinMovimentoCaixaBancoDTO> select(ViewFinMovimentoCaixaBancoDTO objeto)
        {
            try
            {
                IList<ViewFinMovimentoCaixaBancoDTO> resultado = base.select<ViewFinMovimentoCaixaBancoDTO>(objeto);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IList<ViewFinMovimentoCaixaBancoDTO> selectPagina(int primeiroResultado, int quantidadeResultados, ViewFinMovimentoCaixaBancoDTO objeto)
        {
            try
            {
                IList<ViewFinMovimentoCaixaBancoDTO> resultado = base.selectPagina<ViewFinMovimentoCaixaBancoDTO>(primeiroResultado, quantidadeResultados, objeto);
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<ViewFinMovimentoCaixaBancoDTO> selectPeriodo(ViewFinMovimentoCaixaBancoDTO objeto)
        {
            try
            {
                IList<ViewFinMovimentoCaixaBancoDTO> resultado = new List<ViewFinMovimentoCaixaBancoDTO>();
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    DateTime data = (DateTime)objeto.DataPagoRecebido;
                    DateTime dataInicio = new DateTime(data.Year, data.Month, 1);
                    DateTime dataFim = new DateTime(data.Year, data.Month, 1).AddMonths(1).AddDays(-1);

                    resultado = session.CreateCriteria(typeof(ViewFinMovimentoCaixaBancoDTO)).
                        Add(Restrictions.And(Restrictions.Between("DataPagoRecebido", dataInicio, dataFim),
                        Restrictions.Eq("IdContaCaixa", (int)objeto.IdContaCaixa))).
                        List<ViewFinMovimentoCaixaBancoDTO>();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}