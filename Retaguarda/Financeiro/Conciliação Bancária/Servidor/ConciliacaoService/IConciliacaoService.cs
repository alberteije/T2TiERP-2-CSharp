using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConciliacaoService.Model;

namespace ConciliacaoService
{
    [ServiceContract]
    public interface IConciliacaoService
    {
        [OperationContract]
        IList<ExtratoContaBancoDTO> selectExtrato(ExtratoContaBancoDTO extrato);

        [OperationContract]
        int saveUpdateListaExtrato(IList<ExtratoContaBancoDTO> listaExtrato);

        [OperationContract]
        int conciliarCheques(ExtratoContaBancoDTO extrato);

        [OperationContract]
        int conciliarLancamentos(ExtratoContaBancoDTO extrato);

        [OperationContract]
        IList<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO contaCaixa);

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
        IList<EmpresaDTO> selectEmpresa(EmpresaDTO empresa);
        #endregion

    }

}
