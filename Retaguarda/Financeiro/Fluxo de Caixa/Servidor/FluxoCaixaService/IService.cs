using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FluxoCaixaService.Model;

namespace FluxoCaixaService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        IList<ViewFinFluxoCaixaDTO> selectFluxoCaixa(ViewFinFluxoCaixaDTO fluxo);
        [OperationContract]
        IList<ViewFinFluxoCaixaDTO> selectFluxoCaixaMes(ViewFinFluxoCaixaDTO fluxo);

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
