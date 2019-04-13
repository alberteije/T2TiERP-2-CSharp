using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConciliacaoContabilService.Model;

namespace ConciliacaoContabilService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicoConciliacaoContabil
    {

        #region ContaCaixa
        [OperationContract]
        IList<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO contaCaixa);
        [OperationContract]
        IList<ContaCaixaDTO> selectContaCaixaPagina(int primeiroResultado, int quantidadeResultados, ContaCaixaDTO contaCaixa);
        #endregion 

        #region FinExtratoContaBanco
        [OperationContract]
        IList<FinExtratoContaBancoDTO> selectFinExtratoContaBanco(FinExtratoContaBancoDTO finExtratoContaBanco);
        [OperationContract]
        IList<FinExtratoContaBancoDTO> selectFinExtratoContaBancoPagina(int primeiroResultado, int quantidadeResultados, FinExtratoContaBancoDTO finExtratoContaBanco);
        #endregion 

        #region ContabilLancamentoDetalhe
        [OperationContract]
        IList<ContabilLancamentoDetalheDTO> selectContabilLancamentoDetalhe(ContabilLancamentoDetalheDTO contabilLancamentoDetalhe);
        [OperationContract]
        IList<ContabilLancamentoDetalheDTO> selectContabilLancamentoDetalhePagina(int primeiroResultado, int quantidadeResultados, ContabilLancamentoDetalheDTO contabilLancamentoDetalhe);
        #endregion 

        #region Cliente
        [OperationContract]
        IList<ClienteDTO> selectCliente(ClienteDTO cliente);
        [OperationContract]
        IList<ClienteDTO> selectClientePagina(int primeiroResultado, int quantidadeResultados, ClienteDTO cliente);
        #endregion 

        #region ViewConciliaCliente
        [OperationContract]
        IList<ViewConciliaClienteDTO> selectViewConciliaCliente(ViewConciliaClienteDTO viewConciliaCliente);
        [OperationContract]
        IList<ViewConciliaClienteDTO> selectViewConciliaClientePagina(int primeiroResultado, int quantidadeResultados, ViewConciliaClienteDTO viewConciliaCliente);
        #endregion 

        #region Fornecedor
        [OperationContract]
        IList<FornecedorDTO> selectFornecedor(FornecedorDTO fornecedor);
        [OperationContract]
        IList<FornecedorDTO> selectFornecedorPagina(int primeiroResultado, int quantidadeResultados, FornecedorDTO fornecedor);
        #endregion 

        #region ViewConciliaFornecedor
        [OperationContract]
        IList<ViewConciliaFornecedorDTO> selectViewConciliaFornecedor(ViewConciliaFornecedorDTO viewConciliaFornecedor);
        [OperationContract]
        IList<ViewConciliaFornecedorDTO> selectViewConciliaFornecedorPagina(int primeiroResultado, int quantidadeResultados, ViewConciliaFornecedorDTO viewConciliaFornecedor);
        #endregion 

        #region ContabilLancamentoCabecalho
        [OperationContract]
        IList<ContabilLancamentoCabecalhoDTO> selectContabilLancamentoCabecalho(ContabilLancamentoCabecalhoDTO contabilLancamentoCabecalho);
        [OperationContract]
        IList<ContabilLancamentoCabecalhoDTO> selectContabilLancamentoCabecalhoPagina(int primeiroResultado, int quantidadeResultados, ContabilLancamentoCabecalhoDTO contabilLancamentoCabecalho);
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
