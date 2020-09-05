using System.Collections.Generic;
using SearchWindow.Attributes;
using SISClient.ServicoSISReference;

namespace SISClient.Model
{
    public class ServicoSIS : ServicoSISClient
    {

        [SearchWindowDataSource(typeof(CargoDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new List<CargoDTO> SelectCargo(CargoDTO dtoPesquisa)
        {
            return base.SelectCargo(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(CategoriaProdutoDTO), new string[] { "Id", "Codigo", "Nome" }, new string[] { "Id", "Codigo", "Nome" })]
        public new List<CategoriaProdutoDTO> SelectCategoriaProduto(CategoriaProdutoDTO dtoPesquisa)
        {
            return base.SelectCategoriaProduto(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(LocalVendaDTO), new string[] { "Id", "Numero", "Nome" }, new string[] { "Id", "Numero", "Nome" })]
        public new List<LocalVendaDTO> SelectLocalVenda(LocalVendaDTO dtoPesquisa)
        {
            return base.SelectLocalVenda(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(TipoPagamentoDTO), new string[] { "Id", "Codigo", "Nome" }, new string[] { "Id", "Codigo", "Nome" })]
        public new List<TipoPagamentoDTO> SelectTipoPagamento(TipoPagamentoDTO dtoPesquisa)
        {
            return base.SelectTipoPagamento(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(SituacaoVendedorDTO), new string[] { "Id", "Nome" }, new string[] { "Id", "Nome" })]
        public new List<SituacaoVendedorDTO> SelectSituacaoVendedor(SituacaoVendedorDTO dtoPesquisa)
        {
            return base.SelectSituacaoVendedor(dtoPesquisa);
        }

    }
}
