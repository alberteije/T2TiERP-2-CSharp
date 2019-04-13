using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendasClient.VendasReference;
using SearchWindow.Attributes;
using SearchWindow;

namespace VendasClient.Model
{
    public class ServicoVendas : ServicoVendasClient
    {
        [SearchWindowDataSource(typeof(TransportadoraDTO), new string[]{"Pessoa.Nome", "DataCadastro"},new string[]{"Nome", "Data cad." })]
        public new List<TransportadoraDTO> selectTransportadora(TransportadoraDTO dtoPesquisa)
        {
            return base.selectTransportadora(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(VendaCabecalhoDTO), new string[] { "NumeroFatura", "ValorTotal" }, new string[] { "Fatura", "Total" })]
        public new List<VendaCabecalhoDTO> selectVendaCabecalho(VendaCabecalhoDTO dtoPesquisa)
        {
            return base.selectVendaCabecalho(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(CondicoesPagamentoDTO), new string[] { "Nome", "PrazoMedio" }, new string[] { "Nome", "Prazo" })]
        public new List<CondicoesPagamentoDTO> selectCondicoesPagamento(CondicoesPagamentoDTO dtoPesquisa)
        {
            return base.selectCondicoesPagamento(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(ClienteDTO),new string[]{"Pessoa.Nome", "Desde"},new string[]{"Nome", "Data cad." })]
        public new List<ClienteDTO> selectCliente(ClienteDTO dtoPesquisa)
        {
            return base.selectCliente(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(VendedorDTO), new string[] { "Colaborador.Pessoa.Nome", "Colaborador.Matricula" }, new string[] { "Nome", "Matricula" })]
        public new List<VendedorDTO> selectVendedor(VendedorDTO dtoPesquisa)
        {
            return base.selectVendedor(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(ProdutoDTO), new string[] { "Nome", "ValorVenda" }, new string[] { "Nome", "Valor" })]
        public new List<ProdutoDTO> selectProduto(ProdutoDTO dtoPesquisa)
        {
            return base.selectProduto(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(TipoNotaFiscalDTO), new string[] { "Nome", "Modelo" }, new string[] { "Nome", "Modelo" })]
        public new List<TipoNotaFiscalDTO> selectTipoNotaFiscal(TipoNotaFiscalDTO dtoPesquisa)
        {
            return base.selectTipoNotaFiscal(dtoPesquisa);
        }

        [SearchWindowDataSource(typeof(OrcamentoPedidoVendaCabDTO), new string[] { "Codigo", "ValorTotal" }, new string[] { "Codigo", "Valor" })]
        public new List<OrcamentoPedidoVendaCabDTO> selectOrcamentoPedidoVendaCab(OrcamentoPedidoVendaCabDTO dtoPesquisa)
        {
            return base.selectOrcamentoPedidoVendaCab(dtoPesquisa);
        }
    }
}
