using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace TesourariaService.Model
{
    public class ResumoTesourariaDAL : NHibernateDAL<ViewFinResumoTesourariaDTO>
    {
        private ISession session;

        public ResumoTesourariaDAL(ISession session) : base(session) 
        {
            this.session = session;
        }

        public IList<ViewFinResumoTesourariaDTO> selectResumoTesourariaMes(ViewFinResumoTesourariaDTO resumoTesouraria)
        {
            IList<ViewFinResumoTesourariaDTO> resultado = new List<ViewFinResumoTesourariaDTO>();
            int ano = ((DateTime)resumoTesouraria.DataLancamento).Year;
            int mes = ((DateTime)resumoTesouraria.DataLancamento).Month;
            IQuery consulta = session.CreateQuery("from ViewFinResumoTesourariaDTO resumo where month(resumo.DataLancamento) = :mes and " +
            " year(resumo.DataLancamento) = :ano");
            consulta.SetParameter("mes", mes);
            consulta.SetParameter("ano", ano);

            resultado = consulta.List<ViewFinResumoTesourariaDTO>();

            NHibernateDAL<FechamentoCaixaBancoDTO> fechamentoDAL = new NHibernateDAL<FechamentoCaixaBancoDTO>(session);
            foreach (ViewFinResumoTesourariaDTO resumo in resultado)
            {
                IList<FechamentoCaixaBancoDTO> fechamento = fechamentoDAL.select(new FechamentoCaixaBancoDTO { idContaCaixa = resumo.IdContaCaixa,
                ano = ano, mes = mes});
                if (fechamento.Count > 0) 
                    resumo.fechamento = fechamento.First();
            }

            return resultado;
        }
    }
}