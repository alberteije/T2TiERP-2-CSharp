using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Criterion;
using NHibernate;

namespace OrcamentoService.Model
{
    public class OrcamentoDetalheDAL : NHibernateDAL<OrcamentoDetalheDTO>
    {

        public OrcamentoDetalheDAL(ISession session): base(session)
        {
        }

        public IList<OrcamentoDetalheDTO> select(OrcamentoDetalheDTO objeto)
        {
            try
            {
                IList<OrcamentoDetalheDTO> resultado = new List<OrcamentoDetalheDTO>();

                ICriteria crit = session.CreateCriteria(typeof(OrcamentoDetalheDTO)).
                    Add(Example.Create(objeto)).Add(Expression.Eq("orcamento", objeto.orcamento));

                resultado = crit.List<OrcamentoDetalheDTO>();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}