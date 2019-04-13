using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ContasReceberService.Model;
using BoletoNet;

namespace ContasReceberService
{
    [ServiceContract]
    public interface IContasReceberService
    {

        #region Boleto
        [OperationContract]
        FinParcelaReceberDTO gerarBoleto(FinParcelaReceberDTO parcelaReceber);
        #endregion

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

        #region FinTipoRecebimento
        [OperationContract]
        int deleteFinTipoRecebimento(FinTipoRecebimentoDTO finTipoRecebimento);
        [OperationContract]
        FinTipoRecebimentoDTO salvarAtualizarFinTipoRecebimento(FinTipoRecebimentoDTO finTipoRecebimento);
        [OperationContract]
        IList<FinTipoRecebimentoDTO> selectFinTipoRecebimento(FinTipoRecebimentoDTO finTipoRecebimento);
        [OperationContract]
        IList<FinTipoRecebimentoDTO> selectFinTipoRecebimentoPagina(int primeiroResultado, int quantidadeResultados, FinTipoRecebimentoDTO finTipoRecebimento);
        #endregion 

        #region FinConfiguracaoBoleto
        [OperationContract]
        int deleteFinConfiguracaoBoleto(FinConfiguracaoBoletoDTO finConfiguracaoBoleto);
        [OperationContract]
        FinConfiguracaoBoletoDTO salvarAtualizarFinConfiguracaoBoleto(FinConfiguracaoBoletoDTO finConfiguracaoBoleto);
        [OperationContract]
        IList<FinConfiguracaoBoletoDTO> selectFinConfiguracaoBoleto(FinConfiguracaoBoletoDTO finConfiguracaoBoleto);
        [OperationContract]
        IList<FinConfiguracaoBoletoDTO> selectFinConfiguracaoBoletoPagina(int primeiroResultado, int quantidadeResultados, FinConfiguracaoBoletoDTO finConfiguracaoBoleto);
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

        #region FinLancamentoReceber
        [OperationContract]
        int deleteFinLancamentoReceber(FinLancamentoReceberDTO finLancamentoReceber);
        [OperationContract]
        FinLancamentoReceberDTO salvarAtualizarFinLancamentoReceber(FinLancamentoReceberDTO finLancamentoReceber);
        [OperationContract]
        IList<FinLancamentoReceberDTO> selectFinLancamentoReceber(FinLancamentoReceberDTO finLancamentoReceber);
        [OperationContract]
        IList<FinLancamentoReceberDTO> selectFinLancamentoReceberPagina(int primeiroResultado, int quantidadeResultados, FinLancamentoReceberDTO finLancamentoReceber);
        #endregion 

        #region ViewFinLancamentoReceber
        [OperationContract]
        ViewFinLancamentoReceberDTO salvarAtualizarViewFinLancamentoReceber(ViewFinLancamentoReceberDTO viewFinLancamentoReceber);
        [OperationContract]
        IList<ViewFinLancamentoReceberDTO> selectViewFinLancamentoReceber(ViewFinLancamentoReceberDTO viewFinLancamentoReceber);
        [OperationContract]
        IList<ViewFinLancamentoReceberDTO> selectViewFinLancamentoReceberPagina(int primeiroResultado, int quantidadeResultados, ViewFinLancamentoReceberDTO viewFinLancamentoReceber);
        #endregion 



        #region ContaCaixa
        [OperationContract]
        IList<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO contaCaixa);
        [OperationContract]
        IList<ContaCaixaDTO> selectContaCaixaPagina(int primeiroResultado, int quantidadeResultados, ContaCaixaDTO contaCaixa);
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

        #region ViewPessoaCliente
        [OperationContract]
        IList<ViewPessoaClienteDTO> selectViewPessoaCliente(ViewPessoaClienteDTO viewPessoaCliente);
        [OperationContract]
        IList<ViewPessoaClienteDTO> selectViewPessoaClientePagina(int primeiroResultado, int quantidadeResultados, ViewPessoaClienteDTO viewPessoaCliente);
        #endregion 

    }
}
