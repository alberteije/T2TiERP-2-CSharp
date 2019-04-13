using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EscritaFiscalService.Model;

namespace EscritaFiscalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicoEscritaFiscal
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

        #region FiscalParametro
        [OperationContract]
        int deleteFiscalParametro(FiscalParametroDTO fiscalParametro);
        [OperationContract]
        FiscalParametroDTO salvarAtualizarFiscalParametro(FiscalParametroDTO fiscalParametro);
        [OperationContract]
        IList<FiscalParametroDTO> selectFiscalParametro(FiscalParametroDTO fiscalParametro);
        [OperationContract]
        IList<FiscalParametroDTO> selectFiscalParametroPagina(int primeiroResultado, int quantidadeResultados, FiscalParametroDTO fiscalParametro);
        #endregion 

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

        #region SimplesNacionalCabecalho
        [OperationContract]
        int deleteSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho);
        [OperationContract]
        SimplesNacionalCabecalhoDTO salvarAtualizarSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho);
        [OperationContract]
        IList<SimplesNacionalCabecalhoDTO> selectSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho);
        [OperationContract]
        IList<SimplesNacionalCabecalhoDTO> selectSimplesNacionalCabecalhoPagina(int primeiroResultado, int quantidadeResultados, SimplesNacionalCabecalhoDTO simplesNacionalCabecalho);
        #endregion 

        #region FiscalLivro
        [OperationContract]
        int deleteFiscalLivro(FiscalLivroDTO fiscalLivro);
        [OperationContract]
        FiscalLivroDTO salvarAtualizarFiscalLivro(FiscalLivroDTO fiscalLivro);
        [OperationContract]
        IList<FiscalLivroDTO> selectFiscalLivro(FiscalLivroDTO fiscalLivro);
        [OperationContract]
        IList<FiscalLivroDTO> selectFiscalLivroPagina(int primeiroResultado, int quantidadeResultados, FiscalLivroDTO fiscalLivro);
        #endregion 

        #region FiscalApuracaoIcms
        [OperationContract]
        int deleteFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms);
        [OperationContract]
        FiscalApuracaoIcmsDTO salvarAtualizarFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms);
        [OperationContract]
        IList<FiscalApuracaoIcmsDTO> selectFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms);
        [OperationContract]
        IList<FiscalApuracaoIcmsDTO> selectFiscalApuracaoIcmsPagina(int primeiroResultado, int quantidadeResultados, FiscalApuracaoIcmsDTO fiscalApuracaoIcms);
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
