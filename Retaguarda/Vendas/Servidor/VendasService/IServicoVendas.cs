using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using VendasService.Model;

namespace VendasService
{

    [ServiceContract]
    public interface IServicoVendas
    {
        #region TipoNotaFiscal
        [OperationContract]
        int deleteTipoNotaFiscal(TipoNotaFiscalDTO tipoNotaFiscal);
        [OperationContract]
        TipoNotaFiscalDTO salvarAtualizarTipoNotaFiscal(TipoNotaFiscalDTO tipoNotaFiscal);
        [OperationContract]
        IList<TipoNotaFiscalDTO> selectTipoNotaFiscal(TipoNotaFiscalDTO tipoNotaFiscal);
        [OperationContract]
        IList<TipoNotaFiscalDTO> selectTipoNotaFiscalPagina(int primeiroResultado, int quantidadeResultados, TipoNotaFiscalDTO tipoNotaFiscal);
        #endregion 
        #region CondicoesPagamento
        [OperationContract]
        int deleteCondicoesPagamento(CondicoesPagamentoDTO condicoesPagamento);
        [OperationContract]
        CondicoesPagamentoDTO salvarAtualizarCondicoesPagamento(CondicoesPagamentoDTO condicoesPagamento);
        [OperationContract]
        IList<CondicoesPagamentoDTO> selectCondicoesPagamento(CondicoesPagamentoDTO condicoesPagamento);
        [OperationContract]
        IList<CondicoesPagamentoDTO> selectCondicoesPagamentoPagina(int primeiroResultado, int quantidadeResultados, CondicoesPagamentoDTO condicoesPagamento);
        #endregion 
        #region OrcamentoPedidoVendaCab
        [OperationContract]
        int deleteOrcamentoPedidoVendaCab(OrcamentoPedidoVendaCabDTO orcamentoPedidoVendaCab);
        [OperationContract]
        OrcamentoPedidoVendaCabDTO salvarAtualizarOrcamentoPedidoVendaCab(OrcamentoPedidoVendaCabDTO orcamentoPedidoVendaCab);
        [OperationContract]
        IList<OrcamentoPedidoVendaCabDTO> selectOrcamentoPedidoVendaCab(OrcamentoPedidoVendaCabDTO orcamentoPedidoVendaCab);
        [OperationContract]
        IList<OrcamentoPedidoVendaCabDTO> selectOrcamentoPedidoVendaCabPagina(int primeiroResultado, int quantidadeResultados, OrcamentoPedidoVendaCabDTO orcamentoPedidoVendaCab);
        #endregion 
        #region VendaCabecalho
        [OperationContract]
        int deleteVendaCabecalho(VendaCabecalhoDTO vendaCabecalho);
        [OperationContract]
        VendaCabecalhoDTO salvarAtualizarVendaCabecalho(VendaCabecalhoDTO vendaCabecalho);
        [OperationContract]
        IList<VendaCabecalhoDTO> selectVendaCabecalho(VendaCabecalhoDTO vendaCabecalho);
        [OperationContract]
        IList<VendaCabecalhoDTO> selectVendaCabecalhoPagina(int primeiroResultado, int quantidadeResultados, VendaCabecalhoDTO vendaCabecalho);
        #endregion 
        #region FreteVenda
        [OperationContract]
        int deleteFreteVenda(FreteVendaDTO freteVenda);
        [OperationContract]
        FreteVendaDTO salvarAtualizarFreteVenda(FreteVendaDTO freteVenda);
        [OperationContract]
        IList<FreteVendaDTO> selectFreteVenda(FreteVendaDTO freteVenda);
        [OperationContract]
        IList<FreteVendaDTO> selectFreteVendaPagina(int primeiroResultado, int quantidadeResultados, FreteVendaDTO freteVenda);
        #endregion 
        #region Cliente
        [OperationContract]
        IList<ClienteDTO> selectCliente(ClienteDTO cliente);
        [OperationContract]
        IList<ClienteDTO> selectClientePagina(int primeiroResultado, int quantidadeResultados, ClienteDTO cliente);
        #endregion 
        #region Vendedor
        [OperationContract]
        IList<VendedorDTO> selectVendedor(VendedorDTO vendedor);
        [OperationContract]
        IList<VendedorDTO> selectVendedorPagina(int primeiroResultado, int quantidadeResultados, VendedorDTO vendedor);
        #endregion 
        #region Transportadora
        [OperationContract]
        IList<TransportadoraDTO> selectTransportadora(TransportadoraDTO transportadora);
        [OperationContract]
        IList<TransportadoraDTO> selectTransportadoraPagina(int primeiroResultado, int quantidadeResultados, TransportadoraDTO transportadora);
        #endregion 
        #region Produto
        [OperationContract]
        IList<ProdutoDTO> selectProduto(ProdutoDTO produto);
        [OperationContract]
        IList<ProdutoDTO> selectProdutoPagina(int primeiroResultado, int quantidadeResultados, ProdutoDTO produto);
        #endregion 
    
    
        #region Usuario
        [OperationContract]
        UsuarioDTO selectUsuario(String login, String senha);
        #endregion

        #region ControleAcesso
        [OperationContract]
        IList<ViewControleAcessoDTO> selectControleAcesso(ViewControleAcessoDTO viewControleAcesso);
        #endregion
    }
}
