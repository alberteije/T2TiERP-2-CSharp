using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ContabilidadeService.Model;

namespace ContabilidadeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicoContabilidade
    {

        #region RegistroCartorio
        [OperationContract]
        int deleteRegistroCartorio(RegistroCartorioDTO registroCartorio);
        [OperationContract]
        RegistroCartorioDTO salvarAtualizarRegistroCartorio(RegistroCartorioDTO registroCartorio);
        [OperationContract]
        IList<RegistroCartorioDTO> selectRegistroCartorio(RegistroCartorioDTO registroCartorio);
        [OperationContract]
        IList<RegistroCartorioDTO> selectRegistroCartorioPagina(int primeiroResultado, int quantidadeResultados, RegistroCartorioDTO registroCartorio);
        #endregion

        #region ContabilParametros
        [OperationContract]
        int deleteContabilParametros(ContabilParametrosDTO contabilParametros);
        [OperationContract]
        ContabilParametrosDTO salvarAtualizarContabilParametros(ContabilParametrosDTO contabilParametros);
        [OperationContract]
        IList<ContabilParametrosDTO> selectContabilParametros(ContabilParametrosDTO contabilParametros);
        [OperationContract]
        IList<ContabilParametrosDTO> selectContabilParametrosPagina(int primeiroResultado, int quantidadeResultados, ContabilParametrosDTO contabilParametros);
        #endregion 

        #region ContabilIndice
        [OperationContract]
        int deleteContabilIndice(ContabilIndiceDTO contabilIndice);
        [OperationContract]
        ContabilIndiceDTO salvarAtualizarContabilIndice(ContabilIndiceDTO contabilIndice);
        [OperationContract]
        IList<ContabilIndiceDTO> selectContabilIndice(ContabilIndiceDTO contabilIndice);
        [OperationContract]
        IList<ContabilIndiceDTO> selectContabilIndicePagina(int primeiroResultado, int quantidadeResultados, ContabilIndiceDTO contabilIndice);
        #endregion 

        #region ContabilHistorico
        [OperationContract]
        int deleteContabilHistorico(ContabilHistoricoDTO contabilHistorico);
        [OperationContract]
        ContabilHistoricoDTO salvarAtualizarContabilHistorico(ContabilHistoricoDTO contabilHistorico);
        [OperationContract]
        IList<ContabilHistoricoDTO> selectContabilHistorico(ContabilHistoricoDTO contabilHistorico);
        [OperationContract]
        IList<ContabilHistoricoDTO> selectContabilHistoricoPagina(int primeiroResultado, int quantidadeResultados, ContabilHistoricoDTO contabilHistorico);
        #endregion 

        #region AidfAimdf
        [OperationContract]
        int deleteAidfAimdf(AidfAimdfDTO aidfAimdf);
        [OperationContract]
        AidfAimdfDTO salvarAtualizarAidfAimdf(AidfAimdfDTO aidfAimdf);
        [OperationContract]
        IList<AidfAimdfDTO> selectAidfAimdf(AidfAimdfDTO aidfAimdf);
        [OperationContract]
        IList<AidfAimdfDTO> selectAidfAimdfPagina(int primeiroResultado, int quantidadeResultados, AidfAimdfDTO aidfAimdf);
        #endregion 

        #region Fap
        [OperationContract]
        int deleteFap(FapDTO fap);
        [OperationContract]
        FapDTO salvarAtualizarFap(FapDTO fap);
        [OperationContract]
        IList<FapDTO> selectFap(FapDTO fap);
        [OperationContract]
        IList<FapDTO> selectFapPagina(int primeiroResultado, int quantidadeResultados, FapDTO fap);
        #endregion 

        #region PlanoConta
        [OperationContract]
        int deletePlanoConta(PlanoContaDTO planoConta);
        [OperationContract]
        PlanoContaDTO salvarAtualizarPlanoConta(PlanoContaDTO planoConta);
        [OperationContract]
        IList<PlanoContaDTO> selectPlanoConta(PlanoContaDTO planoConta);
        [OperationContract]
        IList<PlanoContaDTO> selectPlanoContaPagina(int primeiroResultado, int quantidadeResultados, PlanoContaDTO planoConta);
        #endregion 

        #region PlanoContaRefSped
        [OperationContract]
        int deletePlanoContaRefSped(PlanoContaRefSpedDTO planoContaRefSped);
        [OperationContract]
        PlanoContaRefSpedDTO salvarAtualizarPlanoContaRefSped(PlanoContaRefSpedDTO planoContaRefSped);
        [OperationContract]
        IList<PlanoContaRefSpedDTO> selectPlanoContaRefSped(PlanoContaRefSpedDTO planoContaRefSped);
        [OperationContract]
        IList<PlanoContaRefSpedDTO> selectPlanoContaRefSpedPagina(int primeiroResultado, int quantidadeResultados, PlanoContaRefSpedDTO planoContaRefSped);
        #endregion 

        #region ContabilConta
        [OperationContract]
        int deleteContabilConta(ContabilContaDTO contabilConta);
        [OperationContract]
        ContabilContaDTO salvarAtualizarContabilConta(ContabilContaDTO contabilConta);
        [OperationContract]
        IList<ContabilContaDTO> selectContabilConta(ContabilContaDTO contabilConta);
        [OperationContract]
        IList<ContabilContaDTO> selectContabilContaPagina(int primeiroResultado, int quantidadeResultados, ContabilContaDTO contabilConta);
        #endregion 

        #region ContabilFechamento
        [OperationContract]
        int deleteContabilFechamento(ContabilFechamentoDTO contabilFechamento);
        [OperationContract]
        ContabilFechamentoDTO salvarAtualizarContabilFechamento(ContabilFechamentoDTO contabilFechamento);
        [OperationContract]
        IList<ContabilFechamentoDTO> selectContabilFechamento(ContabilFechamentoDTO contabilFechamento);
        [OperationContract]
        IList<ContabilFechamentoDTO> selectContabilFechamentoPagina(int primeiroResultado, int quantidadeResultados, ContabilFechamentoDTO contabilFechamento);
        #endregion 

        #region ContabilLancamentoPadrao
        [OperationContract]
        int deleteContabilLancamentoPadrao(ContabilLancamentoPadraoDTO contabilLancamentoPadrao);
        [OperationContract]
        ContabilLancamentoPadraoDTO salvarAtualizarContabilLancamentoPadrao(ContabilLancamentoPadraoDTO contabilLancamentoPadrao);
        [OperationContract]
        IList<ContabilLancamentoPadraoDTO> selectContabilLancamentoPadrao(ContabilLancamentoPadraoDTO contabilLancamentoPadrao);
        [OperationContract]
        IList<ContabilLancamentoPadraoDTO> selectContabilLancamentoPadraoPagina(int primeiroResultado, int quantidadeResultados, ContabilLancamentoPadraoDTO contabilLancamentoPadrao);
        #endregion 

        #region ContabilLote
        [OperationContract]
        int deleteContabilLote(ContabilLoteDTO contabilLote);
        [OperationContract]
        ContabilLoteDTO salvarAtualizarContabilLote(ContabilLoteDTO contabilLote);
        [OperationContract]
        IList<ContabilLoteDTO> selectContabilLote(ContabilLoteDTO contabilLote);
        [OperationContract]
        IList<ContabilLoteDTO> selectContabilLotePagina(int primeiroResultado, int quantidadeResultados, ContabilLoteDTO contabilLote);
        #endregion 

        #region ContabilLancamentoOrcado
        [OperationContract]
        int deleteContabilLancamentoOrcado(ContabilLancamentoOrcadoDTO contabilLancamentoOrcado);
        [OperationContract]
        ContabilLancamentoOrcadoDTO salvarAtualizarContabilLancamentoOrcado(ContabilLancamentoOrcadoDTO contabilLancamentoOrcado);
        [OperationContract]
        IList<ContabilLancamentoOrcadoDTO> selectContabilLancamentoOrcado(ContabilLancamentoOrcadoDTO contabilLancamentoOrcado);
        [OperationContract]
        IList<ContabilLancamentoOrcadoDTO> selectContabilLancamentoOrcadoPagina(int primeiroResultado, int quantidadeResultados, ContabilLancamentoOrcadoDTO contabilLancamentoOrcado);
        #endregion 

        #region ContabilLancamentoCabecalho
        [OperationContract]
        int deleteContabilLancamentoCabecalho(ContabilLancamentoCabecalhoDTO contabilLancamentoCabecalho);
        [OperationContract]
        ContabilLancamentoCabecalhoDTO salvarAtualizarContabilLancamentoCabecalho(ContabilLancamentoCabecalhoDTO contabilLancamentoCabecalho);
        [OperationContract]
        IList<ContabilLancamentoCabecalhoDTO> selectContabilLancamentoCabecalho(ContabilLancamentoCabecalhoDTO contabilLancamentoCabecalho);
        [OperationContract]
        IList<ContabilLancamentoCabecalhoDTO> selectContabilLancamentoCabecalhoPagina(int primeiroResultado, int quantidadeResultados, ContabilLancamentoCabecalhoDTO contabilLancamentoCabecalho);
        #endregion 

        #region ContabilDreCabecalho
        [OperationContract]
        int deleteContabilDreCabecalho(ContabilDreCabecalhoDTO contabilDreCabecalho);
        [OperationContract]
        ContabilDreCabecalhoDTO salvarAtualizarContabilDreCabecalho(ContabilDreCabecalhoDTO contabilDreCabecalho);
        [OperationContract]
        IList<ContabilDreCabecalhoDTO> selectContabilDreCabecalho(ContabilDreCabecalhoDTO contabilDreCabecalho);
        [OperationContract]
        IList<ContabilDreCabecalhoDTO> selectContabilDreCabecalhoPagina(int primeiroResultado, int quantidadeResultados, ContabilDreCabecalhoDTO contabilDreCabecalho);
        #endregion 

        #region ContabilEncerramentoExeCab
        [OperationContract]
        int deleteContabilEncerramentoExeCab(ContabilEncerramentoExeCabDTO contabilEncerramentoExeCab);
        [OperationContract]
        ContabilEncerramentoExeCabDTO salvarAtualizarContabilEncerramentoExeCab(ContabilEncerramentoExeCabDTO contabilEncerramentoExeCab);
        [OperationContract]
        IList<ContabilEncerramentoExeCabDTO> selectContabilEncerramentoExeCab(ContabilEncerramentoExeCabDTO contabilEncerramentoExeCab);
        [OperationContract]
        IList<ContabilEncerramentoExeCabDTO> selectContabilEncerramentoExeCabPagina(int primeiroResultado, int quantidadeResultados, ContabilEncerramentoExeCabDTO contabilEncerramentoExeCab);
        #endregion 

        #region ContabilLivro
        [OperationContract]
        int deleteContabilLivro(ContabilLivroDTO contabilLivro);
        [OperationContract]
        ContabilLivroDTO salvarAtualizarContabilLivro(ContabilLivroDTO contabilLivro);
        [OperationContract]
        IList<ContabilLivroDTO> selectContabilLivro(ContabilLivroDTO contabilLivro);
        [OperationContract]
        IList<ContabilLivroDTO> selectContabilLivroPagina(int primeiroResultado, int quantidadeResultados, ContabilLivroDTO contabilLivro);
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
