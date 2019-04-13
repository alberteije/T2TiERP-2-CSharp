using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CaixaBancosService.Model;

namespace CaixaBancosService
{
    [ServiceContract]
    public interface ICaixaBancosService
    {

        #region FinFechamentoCaixaBanco
        [OperationContract]
        int deleteFinFechamentoCaixaBanco(FinFechamentoCaixaBancoDTO finFechamentoCaixaBanco);
        [OperationContract]
        FinFechamentoCaixaBancoDTO salvarAtualizarFinFechamentoCaixaBanco(FinFechamentoCaixaBancoDTO finFechamentoCaixaBanco);
        [OperationContract]
        FinFechamentoCaixaBancoDTO selectFinFechamentoCaixaBanco(FinFechamentoCaixaBancoDTO finFechamentoCaixaBanco);
        [OperationContract]
        IList<FinFechamentoCaixaBancoDTO> selectFinFechamentoCaixaBancoPagina(int primeiroResultado, int quantidadeResultados, FinFechamentoCaixaBancoDTO finFechamentoCaixaBanco);
        #endregion 

        #region ViewFinChequeNaoCompensado
        [OperationContract]
        int deleteViewFinChequeNaoCompensado(ViewFinChequeNaoCompensadoDTO viewFinChequeNaoCompensado);
        [OperationContract]
        ViewFinChequeNaoCompensadoDTO salvarAtualizarViewFinChequeNaoCompensado(ViewFinChequeNaoCompensadoDTO viewFinChequeNaoCompensado);
        [OperationContract]
        IList<ViewFinChequeNaoCompensadoDTO> selectViewFinChequeNaoCompensado(ViewFinChequeNaoCompensadoDTO viewFinChequeNaoCompensado);
        [OperationContract]
        IList<ViewFinChequeNaoCompensadoDTO> selectViewFinChequeNaoCompensadoPagina(int primeiroResultado, int quantidadeResultados, ViewFinChequeNaoCompensadoDTO viewFinChequeNaoCompensado);
        #endregion 

        #region ViewFinMovimentoCaixaBanco
        [OperationContract]
        IList<ViewFinMovimentoCaixaBancoDTO> selectViewFinMovimentoCaixaBanco(ViewFinMovimentoCaixaBancoDTO viewFinMovimentoCaixaBanco);
        [OperationContract]
        IList<ViewFinMovimentoCaixaBancoDTO> selectViewFinMovimentoCaixaBancoPagina(int primeiroResultado, int quantidadeResultados, ViewFinMovimentoCaixaBancoDTO viewFinMovimentoCaixaBanco);
        [OperationContract]
        IList<ViewFinMovimentoCaixaBancoDTO> selectPeriodoMovimentoCaixaBanco(ViewFinMovimentoCaixaBancoDTO movimentoCaixaBanco);
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


    }
}
