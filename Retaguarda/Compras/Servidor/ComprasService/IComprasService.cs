using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ComprasService.Model;

namespace ComprasService
{
    [ServiceContract]
    public interface IComprasService
    {

        #region CompraTipoRequisicao
        [OperationContract]
        int deleteCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao);
        [OperationContract]
        CompraTipoRequisicaoDTO salvarAtualizarCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao);
        [OperationContract]
        IList<CompraTipoRequisicaoDTO> selectCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao);
        [OperationContract]
        IList<CompraTipoRequisicaoDTO> selectCompraTipoRequisicaoPagina(int primeiroResultado, int quantidadeResultados, CompraTipoRequisicaoDTO compraTipoRequisicao);
        #endregion 

        #region CompraTipoPedido
        [OperationContract]
        int deleteCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido);
        [OperationContract]
        CompraTipoPedidoDTO salvarAtualizarCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido);
        [OperationContract]
        IList<CompraTipoPedidoDTO> selectCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido);
        [OperationContract]
        IList<CompraTipoPedidoDTO> selectCompraTipoPedidoPagina(int primeiroResultado, int quantidadeResultados, CompraTipoPedidoDTO compraTipoPedido);
        #endregion 

        #region CompraRequisicao
        [OperationContract]
        int deleteCompraRequisicao(CompraRequisicaoDTO compraRequisicao);
        [OperationContract]
        CompraRequisicaoDTO salvarAtualizarCompraRequisicao(CompraRequisicaoDTO compraRequisicao);
        [OperationContract]
        IList<CompraRequisicaoDTO> selectCompraRequisicao(CompraRequisicaoDTO compraRequisicao);
        [OperationContract]
        IList<CompraRequisicaoDTO> selectCompraRequisicaoPagina(int primeiroResultado, int quantidadeResultados, CompraRequisicaoDTO compraRequisicao);
        #endregion 

        #region CompraCotacao
        [OperationContract]
        IList<CompraCotacaoDTO> selectCotacaoCompra(CompraCotacaoDTO cotacaoCompra);
        [OperationContract]
        CompraCotacaoDTO saveCotacaoCompra(CompraCotacaoDTO cotacaoCompra);
        [OperationContract]
        CompraCotacaoDTO updateCotacaoCompra(CompraCotacaoDTO cotacaoCompra);
        [OperationContract]
        int deleteCotacaoCompra(CompraCotacaoDTO cotacaoCompra);
        [OperationContract]
        CompraCotacaoDTO selectCotacaoCompraId(CompraCotacaoDTO cotacaoCompra);
        #endregion

        #region CompraRequisicaoDetalhe
        [OperationContract]
        IList<CompraRequisicaoDetalheDTO> selectCompraRequisicaoDetalhe(CompraRequisicaoDetalheDTO compraRequisicaoDetalhe);
        #endregion 

        #region CompraPedido
        [OperationContract]
        CompraPedidoDTO savePedidoCompra(CompraPedidoDTO pedidoCompra);
        [OperationContract]
        CompraPedidoDTO updatePedidoCompra(CompraPedidoDTO pedidoCompra);
        [OperationContract]
        int deletePedidoCompra(CompraPedidoDTO pedidoCompra);
        [OperationContract]
        IList<CompraPedidoDTO> selectPedidoCompra(CompraPedidoDTO pedidoCompra);
        [OperationContract]
        CompraPedidoDTO selectPedidoCompraId(CompraPedidoDTO pedidoCompra);
        #endregion 




        #region ContabilConta
        [OperationContract]
        IList<ContabilContaDTO> selectContabilConta(ContabilContaDTO contabilConta);
        [OperationContract]
        IList<ContabilContaDTO> selectContabilContaPagina(int primeiroResultado, int quantidadeResultados, ContabilContaDTO contabilConta);
        #endregion

        #region Usuario
        [OperationContract]
        UsuarioDTO selectUsuario(String login, String senha);
        #endregion

        #region ControleAcesso
        [OperationContract]
        IList<ViewControleAcessoDTO> selectControleAcesso(ViewControleAcessoDTO viewControleAcesso);
        #endregion

        #region Colaborador
        [OperationContract]
        IList<ColaboradorDTO> selectColaborador(ColaboradorDTO colaborador);
        [OperationContract]
        IList<ColaboradorDTO> selectColaboradorPagina(int primeiroResultado, int quantidadeResultados, ColaboradorDTO colaborador);
        #endregion

        #region Produto
        [OperationContract]
        IList<ProdutoDTO> selectProduto(ProdutoDTO produto);
        [OperationContract]
        IList<ProdutoDTO> selectProdutoPagina(int primeiroResultado, int quantidadeResultados, ProdutoDTO produto);
        #endregion 

        #region ViewPessoaFornecedor
        [OperationContract]
        IList<ViewPessoaFornecedorDTO> selectViewPessoaFornecedor(ViewPessoaFornecedorDTO viewPessoaFornecedor);
        [OperationContract]
        IList<ViewPessoaFornecedorDTO> selectViewPessoaFornecedorPagina(int primeiroResultado, int quantidadeResultados, ViewPessoaFornecedorDTO viewPessoaFornecedor);
        #endregion 

    }
}
