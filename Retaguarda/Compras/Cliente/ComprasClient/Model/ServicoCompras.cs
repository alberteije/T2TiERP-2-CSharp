using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchWindow.Attributes;
using ComprasClient.ComprasService;


namespace ComprasClient.Model
{
    public class ServicoCompras : ComprasServiceClient
    {
        [SearchWindowDataSource(typeof(ContabilContaDTO))]
        public new List<ContabilContaDTO> selectContabilConta(ContabilContaDTO ContabilConta)
        {
            return base.selectContabilConta(ContabilConta);
        }

        [SearchWindowDataSource(typeof(ColaboradorDTO))]
        public new List<ColaboradorDTO> selectColaborador(ColaboradorDTO Colaborador)
        {
            return base.selectColaborador(Colaborador);
        }

        [SearchWindowDataSource(typeof(CompraTipoRequisicaoDTO))]
        public new List<CompraTipoRequisicaoDTO> selectCompraTipoRequisicao(CompraTipoRequisicaoDTO CompraTipoRequisicao)
        {
            return base.selectCompraTipoRequisicao(CompraTipoRequisicao);
        }

        [SearchWindowDataSource(typeof(ProdutoDTO))]
        public new List<ProdutoDTO> selectProduto(ProdutoDTO Produto)
        {
            return base.selectProduto(Produto);
        }

        [SearchWindowDataSource(typeof(ViewPessoaFornecedorDTO))]
        public new List<ViewPessoaFornecedorDTO> selectViewPessoaFornecedor(ViewPessoaFornecedorDTO ViewPessoaFornecedor)
        {
            return base.selectViewPessoaFornecedor(ViewPessoaFornecedor);
        }

        [SearchWindowDataSource(typeof(CompraRequisicaoDetalheDTO), new string[] { "Id", "Produto.Nome", "Quantidade" }, new string[] { "Id", "Produto.Nome", "Quantidade" })]
        public new List<CompraRequisicaoDetalheDTO> selectCompraRequisicaoDetalhe(CompraRequisicaoDetalheDTO CompraRequisicaoDetalhe)
        {
            return base.selectCompraRequisicaoDetalhe(CompraRequisicaoDetalhe);
        }

        [SearchWindowDataSource(typeof(CompraTipoPedidoDTO))]
        public new List<CompraTipoPedidoDTO> selectCompraTipoPedido(CompraTipoPedidoDTO CompraTipoPedido)
        {
            return base.selectCompraTipoPedido(CompraTipoPedido);
        }

    }



}
