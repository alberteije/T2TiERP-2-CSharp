using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ContasPagarService.Model;

namespace ContasPagarService
{
    [ServiceContract]
    public interface IContasPagarService
    {

        #region PlanoNaturezaFinanceira
        [OperationContract]
        int deletePlanoNaturezaFinanceira(PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira);
        [OperationContract]
        PlanoNaturezaFinanceiraDTO salvarAtualizarPlanoNaturezaFinanceira(PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira);
        [OperationContract]
        IList<PlanoNaturezaFinanceiraDTO> selectPlanoNaturezaFinanceira(PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira);
        [OperationContract]
        IList<PlanoNaturezaFinanceiraDTO> selectPlanoNaturezaFinanceiraPagina(int primeiroResultado, int quantidadeResultados, PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira);
        #endregion 

        #region NaturezaFinanceira
        [OperationContract]
        int deleteNaturezaFinanceira(NaturezaFinanceiraDTO naturezaFinanceira);
        [OperationContract]
        NaturezaFinanceiraDTO salvarAtualizarNaturezaFinanceira(NaturezaFinanceiraDTO naturezaFinanceira);
        [OperationContract]
        IList<NaturezaFinanceiraDTO> selectNaturezaFinanceira(NaturezaFinanceiraDTO naturezaFinanceira);
        [OperationContract]
        IList<NaturezaFinanceiraDTO> selectNaturezaFinanceiraPagina(int primeiroResultado, int quantidadeResultados, NaturezaFinanceiraDTO naturezaFinanceira);
        #endregion 

        #region FinStatusParcela
        [OperationContract]
        int deleteFinStatusParcela(FinStatusParcelaDTO finStatusParcela);
        [OperationContract]
        FinStatusParcelaDTO salvarAtualizarFinStatusParcela(FinStatusParcelaDTO finStatusParcela);
        [OperationContract]
        IList<FinStatusParcelaDTO> selectFinStatusParcela(FinStatusParcelaDTO finStatusParcela);
        [OperationContract]
        IList<FinStatusParcelaDTO> selectFinStatusParcelaPagina(int primeiroResultado, int quantidadeResultados, FinStatusParcelaDTO finStatusParcela);
        #endregion 

        #region FinTipoPagamento
        [OperationContract]
        int deleteFinTipoPagamento(FinTipoPagamentoDTO finTipoPagamento);
        [OperationContract]
        FinTipoPagamentoDTO salvarAtualizarFinTipoPagamento(FinTipoPagamentoDTO finTipoPagamento);
        [OperationContract]
        IList<FinTipoPagamentoDTO> selectFinTipoPagamento(FinTipoPagamentoDTO finTipoPagamento);
        [OperationContract]
        IList<FinTipoPagamentoDTO> selectFinTipoPagamentoPagina(int primeiroResultado, int quantidadeResultados, FinTipoPagamentoDTO finTipoPagamento);
        #endregion 

        #region FinDocumentoOrigem
        [OperationContract]
        int deleteFinDocumentoOrigem(FinDocumentoOrigemDTO finDocumentoOrigem);
        [OperationContract]
        FinDocumentoOrigemDTO salvarAtualizarFinDocumentoOrigem(FinDocumentoOrigemDTO finDocumentoOrigem);
        [OperationContract]
        IList<FinDocumentoOrigemDTO> selectFinDocumentoOrigem(FinDocumentoOrigemDTO finDocumentoOrigem);
        [OperationContract]
        IList<FinDocumentoOrigemDTO> selectFinDocumentoOrigemPagina(int primeiroResultado, int quantidadeResultados, FinDocumentoOrigemDTO finDocumentoOrigem);
        #endregion 

        #region FinLancamentoPagar
        [OperationContract]
        int deleteFinLancamentoPagar(FinLancamentoPagarDTO finLancamentoPagar);
        [OperationContract]
        FinLancamentoPagarDTO salvarAtualizarFinLancamentoPagar(FinLancamentoPagarDTO finLancamentoPagar);
        [OperationContract]
        IList<FinLancamentoPagarDTO> selectFinLancamentoPagar(FinLancamentoPagarDTO finLancamentoPagar);
        [OperationContract]
        IList<FinLancamentoPagarDTO> selectFinLancamentoPagarPagina(int primeiroResultado, int quantidadeResultados, FinLancamentoPagarDTO finLancamentoPagar);
        #endregion 

        #region ViewFinLancamentoPagar
        [OperationContract]
        ViewFinLancamentoPagarDTO salvarAtualizarViewFinLancamentoPagar(ViewFinLancamentoPagarDTO viewFinLancamentoPagar);
        [OperationContract]
        IList<ViewFinLancamentoPagarDTO> selectViewFinLancamentoPagar(ViewFinLancamentoPagarDTO viewFinLancamentoPagar);
        [OperationContract]
        IList<ViewFinLancamentoPagarDTO> selectViewFinLancamentoPagarPagina(int primeiroResultado, int quantidadeResultados, ViewFinLancamentoPagarDTO viewFinLancamentoPagar);
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

        #region ContaCaixa
        [OperationContract]
        IList<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO contaCaixa);
        [OperationContract]
        IList<ContaCaixaDTO> selectContaCaixaPagina(int primeiroResultado, int quantidadeResultados, ContaCaixaDTO contaCaixa);
        #endregion 

        #region ViewPessoaFornecedor
        [OperationContract]
        IList<ViewPessoaFornecedorDTO> selectViewPessoaFornecedor(ViewPessoaFornecedorDTO viewPessoaFornecedor);
        [OperationContract]
        IList<ViewPessoaFornecedorDTO> selectViewPessoaFornecedorPagina(int primeiroResultado, int quantidadeResultados, ViewPessoaFornecedorDTO viewPessoaFornecedor);
        #endregion 

    }
}
