using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TesourariaService.Model;

namespace TesourariaService
{
    [ServiceContract]
    public interface ITesourariaService
    {
        [OperationContract]
        IList<ViewFinResumoTesourariaDTO> selectResumoTesouraria(ViewFinResumoTesourariaDTO resumoTesouraria);
        [OperationContract]
        IList<ViewFinResumoTesourariaDTO> selectResumoTesourariaMes(ViewFinResumoTesourariaDTO resumoTesouraria);

        [OperationContract]
        IList<FechamentoCaixaBancoDTO> selectFechamentoCaixaBanco(FechamentoCaixaBancoDTO fechamentoCaixaBanco);

        #region ContaCaixa
        [OperationContract]
        IList<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO ContaCaixa);
        #endregion

        #region Usuario
        [OperationContract]
        UsuarioDTO selectUsuario(String login, String senha);
        #endregion

        #region ControleAcesso
        [OperationContract]
        IList<ViewControleAcessoDTO> selectControleAcesso(ViewControleAcessoDTO viewControleAcesso);
        #endregion

        #region Empresa
        [OperationContract]
        IList<EmpresaDTO> selectEmpresa(EmpresaDTO Empresa);
        #endregion

    }
}
