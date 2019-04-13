using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContabilidadeClient.ServicoContabilidadeReference;
using SearchWindow.Attributes;
using SearchWindow;

namespace ContabilidadeClient.Model
{
    public class ServicoContabilidade : ServicoContabilidadeClient
    {
        [SearchWindowDataSource(typeof(ContabilContaDTO), new string[] { "Classificacao", "Descricao" }, new string[] { "Classificação", "Descrição" })]
        public new List<ContabilContaDTO> selectContabilConta(ContabilContaDTO dtoPesquisa)
        {
            return base.selectContabilConta(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(PlanoContaDTO), new string[] { "Nome", "Mascara" }, new string[] { "Nome", "Máscara" })]
        public new List<PlanoContaDTO> selectPlanoConta(PlanoContaDTO dtoPesquisa)
        {
            return base.selectPlanoConta(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(PlanoContaRefSpedDTO), new string[] { "CodCtaRef", "Descricao" }, new string[] { "Código", "Descrição" })]
        public new List<PlanoContaRefSpedDTO> selectPlanoContaRefSped(PlanoContaRefSpedDTO dtoPesquisa)
        {
            return base.selectPlanoContaRefSped(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(ContabilLoteDTO), new string[] { "Id", "Descricao" }, new string[] { "Id", "Descrição" })]
        public new List<ContabilLoteDTO> selectContabilLote(ContabilLoteDTO dtoPesquisa)
        {
            return base.selectContabilLote(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(ContabilHistoricoDTO), new string[] { "Descricao", "Historico" }, new string[] { "Descrição", "Histórico" })]
        public new List<ContabilHistoricoDTO> selectContabilHistorico(ContabilHistoricoDTO dtoPesquisa)
        {
            return base.selectContabilHistorico(dtoPesquisa);
        }
    }
}
