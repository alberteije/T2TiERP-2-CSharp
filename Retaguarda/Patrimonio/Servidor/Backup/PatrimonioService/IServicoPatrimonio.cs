using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PatrimonioService.Model;

namespace PatrimonioService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicoPatrimonio
    {
        #region PatrimTaxaDepreciacao
        [OperationContract]
        int deletePatrimTaxaDepreciacao(PatrimTaxaDepreciacaoDTO patrimTaxaDepreciacao);
        [OperationContract]
        PatrimTaxaDepreciacaoDTO salvarAtualizarPatrimTaxaDepreciacao(PatrimTaxaDepreciacaoDTO patrimTaxaDepreciacao);
        [OperationContract]
        IList<PatrimTaxaDepreciacaoDTO> selectPatrimTaxaDepreciacao(PatrimTaxaDepreciacaoDTO patrimTaxaDepreciacao);
        [OperationContract]
        IList<PatrimTaxaDepreciacaoDTO> selectPatrimTaxaDepreciacaoPagina(int primeiroResultado, int quantidadeResultados, PatrimTaxaDepreciacaoDTO patrimTaxaDepreciacao);
        #endregion 

        #region PatrimIndiceAtualizacao
        [OperationContract]
        int deletePatrimIndiceAtualizacao(PatrimIndiceAtualizacaoDTO patrimIndiceAtualizacao);
        [OperationContract]
        PatrimIndiceAtualizacaoDTO salvarAtualizarPatrimIndiceAtualizacao(PatrimIndiceAtualizacaoDTO patrimIndiceAtualizacao);
        [OperationContract]
        IList<PatrimIndiceAtualizacaoDTO> selectPatrimIndiceAtualizacao(PatrimIndiceAtualizacaoDTO patrimIndiceAtualizacao);
        [OperationContract]
        IList<PatrimIndiceAtualizacaoDTO> selectPatrimIndiceAtualizacaoPagina(int primeiroResultado, int quantidadeResultados, PatrimIndiceAtualizacaoDTO patrimIndiceAtualizacao);
        #endregion 

        #region PatrimTipoAquisicaoBem
        [OperationContract]
        int deletePatrimTipoAquisicaoBem(PatrimTipoAquisicaoBemDTO patrimTipoAquisicaoBem);
        [OperationContract]
        PatrimTipoAquisicaoBemDTO salvarAtualizarPatrimTipoAquisicaoBem(PatrimTipoAquisicaoBemDTO patrimTipoAquisicaoBem);
        [OperationContract]
        IList<PatrimTipoAquisicaoBemDTO> selectPatrimTipoAquisicaoBem(PatrimTipoAquisicaoBemDTO patrimTipoAquisicaoBem);
        [OperationContract]
        IList<PatrimTipoAquisicaoBemDTO> selectPatrimTipoAquisicaoBemPagina(int primeiroResultado, int quantidadeResultados, PatrimTipoAquisicaoBemDTO patrimTipoAquisicaoBem);
        #endregion 

        #region PatrimTipoMovimentacao
        [OperationContract]
        int deletePatrimTipoMovimentacao(PatrimTipoMovimentacaoDTO patrimTipoMovimentacao);
        [OperationContract]
        PatrimTipoMovimentacaoDTO salvarAtualizarPatrimTipoMovimentacao(PatrimTipoMovimentacaoDTO patrimTipoMovimentacao);
        [OperationContract]
        IList<PatrimTipoMovimentacaoDTO> selectPatrimTipoMovimentacao(PatrimTipoMovimentacaoDTO patrimTipoMovimentacao);
        [OperationContract]
        IList<PatrimTipoMovimentacaoDTO> selectPatrimTipoMovimentacaoPagina(int primeiroResultado, int quantidadeResultados, PatrimTipoMovimentacaoDTO patrimTipoMovimentacao);
        #endregion 

        #region PatrimEstadoConservacao
        [OperationContract]
        int deletePatrimEstadoConservacao(PatrimEstadoConservacaoDTO patrimEstadoConservacao);
        [OperationContract]
        PatrimEstadoConservacaoDTO salvarAtualizarPatrimEstadoConservacao(PatrimEstadoConservacaoDTO patrimEstadoConservacao);
        [OperationContract]
        IList<PatrimEstadoConservacaoDTO> selectPatrimEstadoConservacao(PatrimEstadoConservacaoDTO patrimEstadoConservacao);
        [OperationContract]
        IList<PatrimEstadoConservacaoDTO> selectPatrimEstadoConservacaoPagina(int primeiroResultado, int quantidadeResultados, PatrimEstadoConservacaoDTO patrimEstadoConservacao);
        #endregion 

        #region PatrimGrupoBem
        [OperationContract]
        int deletePatrimGrupoBem(PatrimGrupoBemDTO patrimGrupoBem);
        [OperationContract]
        PatrimGrupoBemDTO salvarAtualizarPatrimGrupoBem(PatrimGrupoBemDTO patrimGrupoBem);
        [OperationContract]
        IList<PatrimGrupoBemDTO> selectPatrimGrupoBem(PatrimGrupoBemDTO patrimGrupoBem);
        [OperationContract]
        IList<PatrimGrupoBemDTO> selectPatrimGrupoBemPagina(int primeiroResultado, int quantidadeResultados, PatrimGrupoBemDTO patrimGrupoBem);
        #endregion 

        #region Seguradora
        [OperationContract]
        int deleteSeguradora(SeguradoraDTO seguradora);
        [OperationContract]
        SeguradoraDTO salvarAtualizarSeguradora(SeguradoraDTO seguradora);
        [OperationContract]
        IList<SeguradoraDTO> selectSeguradora(SeguradoraDTO seguradora);
        [OperationContract]
        IList<SeguradoraDTO> selectSeguradoraPagina(int primeiroResultado, int quantidadeResultados, SeguradoraDTO seguradora);
        #endregion 

        #region PatrimBem
        [OperationContract]
        int deletePatrimBem(PatrimBemDTO patrimBem);
        [OperationContract]
        PatrimBemDTO salvarAtualizarPatrimBem(PatrimBemDTO patrimBem);
        [OperationContract]
        IList<PatrimBemDTO> selectPatrimBem(PatrimBemDTO patrimBem);
        [OperationContract]
        IList<PatrimBemDTO> selectPatrimBemPagina(int primeiroResultado, int quantidadeResultados, PatrimBemDTO patrimBem);
        #endregion 

        #region PatrimDepreciacaoBem
        [OperationContract]
        int deletePatrimDepreciacaoBem(PatrimDepreciacaoBemDTO patrimDepreciacaoBem);
        [OperationContract]
        PatrimDepreciacaoBemDTO salvarAtualizarPatrimDepreciacaoBem(PatrimDepreciacaoBemDTO patrimDepreciacaoBem);
        [OperationContract]
        IList<PatrimDepreciacaoBemDTO> selectPatrimDepreciacaoBem(PatrimDepreciacaoBemDTO patrimDepreciacaoBem);
        [OperationContract]
        IList<PatrimDepreciacaoBemDTO> selectPatrimDepreciacaoBemPagina(int primeiroResultado, int quantidadeResultados, PatrimDepreciacaoBemDTO patrimDepreciacaoBem);
        #endregion 

        #region PatrimMovimentacaoBem
        [OperationContract]
        int deletePatrimMovimentacaoBem(PatrimMovimentacaoBemDTO patrimMovimentacaoBem);
        [OperationContract]
        PatrimMovimentacaoBemDTO salvarAtualizarPatrimMovimentacaoBem(PatrimMovimentacaoBemDTO patrimMovimentacaoBem);
        [OperationContract]
        IList<PatrimMovimentacaoBemDTO> selectPatrimMovimentacaoBem(PatrimMovimentacaoBemDTO patrimMovimentacaoBem);
        [OperationContract]
        IList<PatrimMovimentacaoBemDTO> selectPatrimMovimentacaoBemPagina(int primeiroResultado, int quantidadeResultados, PatrimMovimentacaoBemDTO patrimMovimentacaoBem);
        #endregion 

        #region PatrimApoliceSeguro
        [OperationContract]
        int deletePatrimApoliceSeguro(PatrimApoliceSeguroDTO patrimApoliceSeguro);
        [OperationContract]
        PatrimApoliceSeguroDTO salvarAtualizarPatrimApoliceSeguro(PatrimApoliceSeguroDTO patrimApoliceSeguro);
        [OperationContract]
        IList<PatrimApoliceSeguroDTO> selectPatrimApoliceSeguro(PatrimApoliceSeguroDTO patrimApoliceSeguro);
        [OperationContract]
        IList<PatrimApoliceSeguroDTO> selectPatrimApoliceSeguroPagina(int primeiroResultado, int quantidadeResultados, PatrimApoliceSeguroDTO patrimApoliceSeguro);
        #endregion 

        #region Fornecedor
        [OperationContract]
        IList<FornecedorDTO> selectFornecedor(FornecedorDTO fornecedor);
        [OperationContract]
        IList<FornecedorDTO> selectFornecedorPagina(int primeiroResultado, int quantidadeResultados, FornecedorDTO fornecedor);
        #endregion

        #region Setor
        [OperationContract]
        IList<SetorDTO> selectSetor(SetorDTO setor);
        [OperationContract]
        IList<SetorDTO> selectSetorPagina(int primeiroResultado, int quantidadeResultados, SetorDTO setor);
        #endregion

        #region Colaborador
        [OperationContract]
        IList<ColaboradorDTO> selectColaborador(ColaboradorDTO colaborador);
        [OperationContract]
        IList<ColaboradorDTO> selectColaboradorPagina(int primeiroResultado, int quantidadeResultados, ColaboradorDTO colaborador);
        #endregion

        #region Pessoa

        [OperationContract]
        PessoaDTO selectPessoa(PessoaDTO pessoa);

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
