using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Criterion;
using NHibernate;

namespace FluxoCaixaService.Model
{
    public class FluxoCaixaDAL : NHibernateDAL<ViewFinFluxoCaixaDTO>
    {

        private ISession session;

        public FluxoCaixaDAL(ISession session): base(session)
        {
            this.session = session;
        }

        public IList<ViewFinFluxoCaixaDTO> selectFluxoCaixaMes(ViewFinFluxoCaixaDTO objeto)
        {
            try
            {
                IList<ViewFinFluxoCaixaDTO> resultado = new List<ViewFinFluxoCaixaDTO>();
                int ano = ((DateTime)objeto.DataLancamento).Year;
                int mes = ((DateTime)objeto.DataLancamento).Month;
                IQuery consulta = session.CreateQuery("from ViewFinFluxoCaixaDTO fluxo where month(fluxo.DataLancamento) = :mes and " +
                " year(fluxo.DataLancamento) = :ano");
                consulta.SetParameter("mes", mes);
                consulta.SetParameter("ano", ano);

                resultado = consulta.List<ViewFinFluxoCaixaDTO>();

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}