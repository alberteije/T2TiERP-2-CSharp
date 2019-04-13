using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministrativoClient.ServicoAdministrativoReference;
using SearchWindow.Attributes;
using SearchWindow;

namespace AdministrativoClient.Model
{
    public class ServicoAdministrativo : ServicoAdministrativoClient
    {
        [SearchWindowDataSource(typeof(TributOperacaoFiscalDTO), new string[] { "Cfop", "Descricao" }, new string[] { "CFOP", "Descrição" })]
        public new List<TributOperacaoFiscalDTO> selectTributOperacaoFiscal(TributOperacaoFiscalDTO dtoPesquisa)
        {
            return base.selectTributOperacaoFiscal(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(TributGrupoTributarioDTO), new string[] { "Id", "Descricao" }, new string[] { "Id", "Descrição" })]
        public new List<TributGrupoTributarioDTO> selectTributGrupoTributario(TributGrupoTributarioDTO dtoPesquisa)
        {
            return base.selectTributGrupoTributario(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(TipoReceitaDipiDTO), new string[] { "Id", "Descricao" }, new string[] { "Id", "Descrição" })]
        public new List<TipoReceitaDipiDTO> selectTipoReceitaDipi(TipoReceitaDipiDTO dtoPesquisa)
        {
            return base.selectTipoReceitaDipi(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(PapelDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new List<PapelDTO> selectPapel(PapelDTO dtoPesquisa)
        {
            return base.selectPapel(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(ColaboradorDTO), new string[] { "Id", "Pessoa.Nome" }, new string[] { "Id", "Nome" })]
        public new List<ColaboradorDTO> selectColaborador(ColaboradorDTO dtoPesquisa)
        {
            return base.selectColaborador(dtoPesquisa);
        }
    }
}
