using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatrimonioClient.ServicoPatrimonioReference;
using SearchWindow.Attributes;

namespace PatrimonioClient.Model
{
    public class ServicoPatrimonio : ServicoPatrimonioClient
    {
        [SearchWindowDataSource(typeof(SetorDTO))]
        public new List<SetorDTO> selectSetor(SetorDTO dtoPesquisa)
        {
            return base.selectSetor(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(FornecedorDTO), new string[] { "Pessoa.Nome", "Desde" }, new string[] { "Nome", "Data cad." })]
        public new List<FornecedorDTO> selectFornecedor(FornecedorDTO dtoPesquisa)
        {
            return base.selectFornecedor(dtoPesquisa);
        }
        [SearchWindowDataSource(typeof(ColaboradorDTO), new string[] { "Pessoa.Nome", "Matricula" }, new string[] { "Nome", "Matricula" })]
        public new List<ColaboradorDTO> selectColaborador(ColaboradorDTO dtoPesquisa)
        {
            return base.selectColaborador(dtoPesquisa);
        }
        [SearchWindowDataSource(typeof(PatrimGrupoBemDTO))]
        public new List<PatrimGrupoBemDTO> selectPatrimGrupoBem(PatrimGrupoBemDTO dtoPesquisa)
        {
            return base.selectPatrimGrupoBem(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(PatrimEstadoConservacaoDTO))]
        public new List<PatrimEstadoConservacaoDTO> selectPatrimEstadoConservacao(PatrimEstadoConservacaoDTO dtoPesquisa)
        {
            return base.selectPatrimEstadoConservacao(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(PatrimTipoAquisicaoBemDTO))]
        public new List<PatrimTipoAquisicaoBemDTO> selectPatrimTipoAquisicaoBem(PatrimTipoAquisicaoBemDTO dtoPesquisa)
        {
            return base.selectPatrimTipoAquisicaoBem(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(PatrimTipoMovimentacaoDTO))]
        public new List<PatrimTipoMovimentacaoDTO> selectPatrimTipoMovimentacao(PatrimTipoMovimentacaoDTO dtoPesquisa)
        {
            return base.selectPatrimTipoMovimentacao(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(PatrimApoliceSeguroDTO))]
        public new List<PatrimApoliceSeguroDTO> selectPatrimApoliceSeguro(PatrimApoliceSeguroDTO dtoPesquisa)
        {
            return base.selectPatrimApoliceSeguro(dtoPesquisa);
        }


        [SearchWindowDataSource(typeof(PatrimBemDTO))]
        public new List<PatrimBemDTO> selectPatrimBem(PatrimBemDTO dtoPesquisa)
        {
            return base.selectPatrimBem(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(SeguradoraDTO))]
        public new List<SeguradoraDTO> selectSeguradora(SeguradoraDTO dtoPesquisa)
        {
            return base.selectSeguradora(dtoPesquisa);
        }

    }
}
