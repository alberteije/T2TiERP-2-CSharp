using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace ConciliacaoService.Model
{
    public class ExtratoContaBancoDAL : NHibernateDAL<ExtratoContaBancoDTO>
    {
        private ISession session;

        public ExtratoContaBancoDAL(ISession session): base(session)
        {
            this.session = session;
        }

        public IList<ExtratoContaBancoDTO> selectLancamentos(ExtratoContaBancoDTO extrato)
        { 
            IList<ExtratoContaBancoDTO> resultado = new List<ExtratoContaBancoDTO>();
            
            Example example = Example.Create(extrato).EnableLike(MatchMode.Anywhere).IgnoreCase().ExcludeNulls().ExcludeZeroes();
            ICriteria crit = session.CreateCriteria(typeof(ExtratoContaBancoDTO)).Add(example);
            crit.Add(Restrictions.Not(Restrictions.Like("historico","%Cheque Compensado%")));
            resultado = crit.List<ExtratoContaBancoDTO>();
            return resultado;
        }

    }
}