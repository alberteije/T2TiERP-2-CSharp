using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GEDService.Model;

namespace GEDService
{
    [ServiceContract]
    public interface IGEDService
    {
        #region GedTipoDocumento
        [OperationContract]
        int deleteGedTipoDocumento(GedTipoDocumentoDTO gedTipoDocumento);
        [OperationContract]
        GedTipoDocumentoDTO salvarAtualizarGedTipoDocumento(GedTipoDocumentoDTO gedTipoDocumento);
        [OperationContract]
        IList<GedTipoDocumentoDTO> selectGedTipoDocumento(GedTipoDocumentoDTO gedTipoDocumento);
        [OperationContract]
        IList<GedTipoDocumentoDTO> selectGedTipoDocumentoPagina(int primeiroResultado, int quantidadeResultados, GedTipoDocumentoDTO gedTipoDocumento);
        #endregion 

        #region GedDocumento
        [OperationContract]
        GedDocumentoDTO saveDocumento(GedDocumentoDTO documento);
        [OperationContract]
        GedDocumentoDTO updateDocumento(GedDocumentoDTO documento);
        [OperationContract]
        int deleteDocumento(GedDocumentoDTO documento);
        [OperationContract]
        IList<GedDocumentoDTO> selectDocumento(GedDocumentoDTO documento);
        [OperationContract]
        GedDocumentoDTO selectDocumentoId(GedDocumentoDTO documento);
        #endregion

        #region GedVersaoDocumento
        [OperationContract]
        int deleteGedVersaoDocumento(GedVersaoDocumentoDTO gedVersaoDocumento);
        [OperationContract]
        GedVersaoDocumentoDTO salvarAtualizarGedVersaoDocumento(GedVersaoDocumentoDTO gedVersaoDocumento);
        [OperationContract]
        IList<GedVersaoDocumentoDTO> selectGedVersaoDocumento(GedVersaoDocumentoDTO gedVersaoDocumento);
        [OperationContract]
        IList<GedVersaoDocumentoDTO> selectGedVersaoDocumentoPagina(int primeiroResultado, int quantidadeResultados, GedVersaoDocumentoDTO gedVersaoDocumento);
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
