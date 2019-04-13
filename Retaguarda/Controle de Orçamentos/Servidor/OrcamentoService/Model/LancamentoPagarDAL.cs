using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace OrcamentoService.Model
{
    public class ParcelaDAL : NHibernateDAL<ParcelaPagarDTO>
    {
        public ParcelaDAL(ISession session) : base(session) { }

        public IList<ParcelaPagarDTO> selectParcelaPagar(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                IList<ParcelaPagarDTO> resultado = new List<ParcelaPagarDTO>();

                ICriteria crit = session.CreateCriteria(typeof(ParcelaPagarDTO)).
                    Add(Expression.Between("dataVencimento", dataInicio, dataFim));

                resultado = crit.List<ParcelaPagarDTO>();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<ParcelaReceberDTO> selectParcelaReceber(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                IList<ParcelaReceberDTO> resultado = new List<ParcelaReceberDTO>();

                ICriteria crit = session.CreateCriteria(typeof(ParcelaReceberDTO)).
                    Add(Expression.Between("dataVencimento", dataInicio, dataFim));

                resultado = crit.List<ParcelaReceberDTO>();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}