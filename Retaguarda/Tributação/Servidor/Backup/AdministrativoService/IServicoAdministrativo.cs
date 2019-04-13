using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AdministrativoService.Model;

namespace AdministrativoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicoAdministrativo
    {

        #region TributOperacaoFiscal
        [OperationContract]
        int deleteTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal);
        [OperationContract]
        TributOperacaoFiscalDTO salvarAtualizarTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal);
        [OperationContract]
        IList<TributOperacaoFiscalDTO> selectTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal);
        [OperationContract]
        IList<TributOperacaoFiscalDTO> selectTributOperacaoFiscalPagina(int primeiroResultado, int quantidadeResultados, TributOperacaoFiscalDTO tributOperacaoFiscal);
        #endregion 

        #region TributGrupoTributario
        [OperationContract]
        int deleteTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario);
        [OperationContract]
        TributGrupoTributarioDTO salvarAtualizarTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario);
        [OperationContract]
        IList<TributGrupoTributarioDTO> selectTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario);
        [OperationContract]
        IList<TributGrupoTributarioDTO> selectTributGrupoTributarioPagina(int primeiroResultado, int quantidadeResultados, TributGrupoTributarioDTO tributGrupoTributario);
        #endregion 

        #region TributIss
        [OperationContract]
        int deleteTributIss(TributIssDTO tributIss);
        [OperationContract]
        TributIssDTO salvarAtualizarTributIss(TributIssDTO tributIss);
        [OperationContract]
        IList<TributIssDTO> selectTributIss(TributIssDTO tributIss);
        [OperationContract]
        IList<TributIssDTO> selectTributIssPagina(int primeiroResultado, int quantidadeResultados, TributIssDTO tributIss);
        #endregion 

        #region TributIcmsCustomCab
        [OperationContract]
        int deleteTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab);
        [OperationContract]
        TributIcmsCustomCabDTO salvarAtualizarTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab);
        [OperationContract]
        IList<TributIcmsCustomCabDTO> selectTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab);
        [OperationContract]
        IList<TributIcmsCustomCabDTO> selectTributIcmsCustomCabPagina(int primeiroResultado, int quantidadeResultados, TributIcmsCustomCabDTO tributIcmsCustomCab);
        #endregion 

        #region TributConfiguraOfGt
        [OperationContract]
        int deleteTributConfiguraOfGt(TributConfiguraOfGtDTO tributConfiguraOfGt);
        [OperationContract]
        TributConfiguraOfGtDTO salvarAtualizarTributConfiguraOfGt(TributConfiguraOfGtDTO tributConfiguraOfGt);
        [OperationContract]
        IList<TributConfiguraOfGtDTO> selectTributConfiguraOfGt(TributConfiguraOfGtDTO tributConfiguraOfGt);
        [OperationContract]
        IList<TributConfiguraOfGtDTO> selectTributConfiguraOfGtPagina(int primeiroResultado, int quantidadeResultados, TributConfiguraOfGtDTO tributConfiguraOfGt);
        #endregion 

        #region TipoReceitaDipi
        [OperationContract]
        IList<TipoReceitaDipiDTO> selectTipoReceitaDipi(TipoReceitaDipiDTO tipoReceitaDipi);
        #endregion 


        #region Usuario
        [OperationContract]
        UsuarioDTO selectUsuario(String login, String senha);

        [OperationContract]
        int deleteUsuario(UsuarioDTO usuario);
        [OperationContract]
        UsuarioDTO salvarAtualizarUsuario(UsuarioDTO usuario);
        [OperationContract]
        IList<UsuarioDTO> selectUsuarioDto(UsuarioDTO usuario);
        [OperationContract]
        IList<UsuarioDTO> selectUsuarioPagina(int primeiroResultado, int quantidadeResultados, UsuarioDTO usuario);

        #endregion

        #region ControleAcesso
        [OperationContract]
        IList<ViewControleAcessoDTO> selectControleAcesso(ViewControleAcessoDTO viewControleAcesso);
        [OperationContract]
        ViewControleAcessoDTO selectControleAcessoId(int Id);
        #endregion

        #region Papel
        [OperationContract]
        int deletePapel(PapelDTO papel);
        [OperationContract]
        PapelDTO salvarAtualizarPapel(PapelDTO papel);
        [OperationContract]
        IList<PapelDTO> selectPapel(PapelDTO papel);
        [OperationContract]
        IList<PapelDTO> selectPapelPagina(int primeiroResultado, int quantidadeResultados, PapelDTO papel);
        #endregion 

        #region Colaborador
        [OperationContract]
        IList<ColaboradorDTO> selectColaborador(ColaboradorDTO colaborador);
        [OperationContract]
        IList<ColaboradorDTO> selectColaboradorPagina(int primeiroResultado, int quantidadeResultados, ColaboradorDTO colaborador);
        #endregion

        #region PapelFuncao
        [OperationContract]
        int deletePapelFuncao(PapelFuncaoDTO papelFuncao);
        [OperationContract]
        PapelFuncaoDTO salvarAtualizarPapelFuncao(PapelFuncaoDTO papelFuncao);
        [OperationContract]
        IList<PapelFuncaoDTO> selectPapelFuncao(PapelFuncaoDTO papelFuncao);
        [OperationContract]
        IList<PapelFuncaoDTO> selectPapelFuncaoPagina(int primeiroResultado, int quantidadeResultados, PapelFuncaoDTO papelFuncao);
        #endregion 

        #region Funcao
        [OperationContract]
        int deleteFuncao(FuncaoDTO funcao);
        [OperationContract]
        FuncaoDTO salvarAtualizarFuncao(FuncaoDTO funcao);
        [OperationContract]
        IList<FuncaoDTO> selectFuncao(FuncaoDTO funcao);
        [OperationContract]
        IList<FuncaoDTO> selectFuncaoPagina(int primeiroResultado, int quantidadeResultados, FuncaoDTO funcao);
        #endregion 

    }
}
