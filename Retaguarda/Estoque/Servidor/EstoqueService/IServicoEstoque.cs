using System.Collections.Generic;
using System.ServiceModel;
using EstoqueService.Model;
using System;

namespace EstoqueService
{
    [ServiceContract]
    public interface IServicoEstoque
    {
        #region EstoqueContagemCabecalho
        [OperationContract]
        int deleteEstoqueContagemCabecalho(EstoqueContagemCabecalhoDTO estoqueContagemCabecalho);
        [OperationContract]
        EstoqueContagemCabecalhoDTO salvarAtualizarEstoqueContagemCabecalho(EstoqueContagemCabecalhoDTO estoqueContagemCabecalho);
        [OperationContract]
        IList<EstoqueContagemCabecalhoDTO> selectEstoqueContagemCabecalho(EstoqueContagemCabecalhoDTO estoqueContagemCabecalho);
        [OperationContract]
        IList<EstoqueContagemCabecalhoDTO> selectEstoqueContagemCabecalhoPagina(int primeiroResultado, int quantidadeResultados, EstoqueContagemCabecalhoDTO estoqueContagemCabecalho);
        #endregion 

        #region RequisicaoInternaCabecalho
        [OperationContract]
        int deleteRequisicaoInternaCabecalho(RequisicaoInternaCabecalhoDTO requisicaoInternaCabecalho);
        [OperationContract]
        RequisicaoInternaCabecalhoDTO salvarAtualizarRequisicaoInternaCabecalho(RequisicaoInternaCabecalhoDTO requisicaoInternaCabecalho);
        [OperationContract]
        IList<RequisicaoInternaCabecalhoDTO> selectRequisicaoInternaCabecalho(RequisicaoInternaCabecalhoDTO requisicaoInternaCabecalho);
        [OperationContract]
        IList<RequisicaoInternaCabecalhoDTO> selectRequisicaoInternaCabecalhoPagina(int primeiroResultado, int quantidadeResultados, RequisicaoInternaCabecalhoDTO requisicaoInternaCabecalho);
        #endregion 

        #region EstoqueReajusteCabecalho
        [OperationContract]
        int deleteEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho);
        [OperationContract]
        EstoqueReajusteCabecalhoDTO salvarAtualizarEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho);
        [OperationContract]
        IList<EstoqueReajusteCabecalhoDTO> selectEstoqueReajusteCabecalho(EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho);
        [OperationContract]
        IList<EstoqueReajusteCabecalhoDTO> selectEstoqueReajusteCabecalhoPagina(int primeiroResultado, int quantidadeResultados, EstoqueReajusteCabecalhoDTO estoqueReajusteCabecalho);
        #endregion 

        #region Entrada Nota Fiscal
        [OperationContract]
        IList<NFeCabecalhoDTO> selectNFeCabecalho(NFeCabecalhoDTO nfeCabecalho);

        [OperationContract]
        int salvarNFeCabecalho(NFeCabecalhoDTO nfeCabecalho);

        [OperationContract]
        NFeCabecalhoDTO selectNFeCabecalhoId(int id);
        #endregion


        [OperationContract]
        IList<ProdutoDTO> selectProduto(ProdutoDTO produto);

        [OperationContract]
        ProdutoDTO selectProdutoId(int id);

        [OperationContract]
        int salvarProduto(ProdutoDTO produto);


        #region Apenas Consultas

        [OperationContract]
        IList<ColaboradorDTO> selectColaborador(ColaboradorDTO colaborador);

        [OperationContract]
        EmpresaDTO selectEmpresaId(int id);

        #region Usuario
        [OperationContract]
        UsuarioDTO selectUsuario(String login, String senha);
        #endregion

        #region ControleAcesso
        [OperationContract]
        IList<ViewControleAcessoDTO> selectControleAcesso(ViewControleAcessoDTO viewControleAcesso);
        #endregion

        #region TributOperacaoFiscal
        [OperationContract]
        IList<TributOperacaoFiscalDTO> selectTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal);
        #endregion

        #region ViewTributacaoPis
        [OperationContract]
        ViewTributacaoPisDTO selectViewTributacaoPis(ViewTributacaoPisDTO viewTributacaoPis);
        #endregion

        #region ViewTributacaoCofins
        [OperationContract]
        ViewTributacaoCofinsDTO selectViewTributacaoCofins(ViewTributacaoCofinsDTO viewTributacaoCofins);
        #endregion

        #region ViewTributacaoIcms
        [OperationContract]
        ViewTributacaoIcmsDTO selectViewTributacaoIcms(ViewTributacaoIcmsDTO viewTributacaoIcms);
        #endregion

        #endregion

    }


}
