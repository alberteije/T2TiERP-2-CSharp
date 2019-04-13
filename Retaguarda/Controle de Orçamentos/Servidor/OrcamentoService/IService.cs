using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using OrcamentoService.Model;

namespace OrcamentoService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        IList<OrcamentoPeriodoDTO> selectPeriodo(OrcamentoPeriodoDTO periodo);
        [OperationContract]
        IList<NaturezaFinanceiraDTO> selectNaturezaFinanceira(NaturezaFinanceiraDTO naturezaFinanceira);
        [OperationContract]
        IList<ParcelaPagarDTO> selectLancamentosPagar(DateTime dataInicio, DateTime dataFim);
        [OperationContract]
        IList<ParcelaReceberDTO> selectLancamentosReceber(DateTime dataInicio, DateTime dataFim);

        [OperationContract]
        IList<OrcamentoDTO> selectOrcamento(OrcamentoDTO orcamento);
        [OperationContract]
        OrcamentoDTO selectOrcamentoCompleto(OrcamentoDTO orcamento);
        [OperationContract]
        OrcamentoDTO saveOrcamento(OrcamentoDTO orcamento);

        #region Usuario
        [OperationContract]
        UsuarioDTO selectUsuario(String login, String senha);
        #endregion

        #region ControleAcesso
        [OperationContract]
        IList<ViewControleAcessoDTO> selectControleAcesso(ViewControleAcessoDTO viewControleAcesso);
        #endregion

        [OperationContract]
        EmpresaDTO selectEmpresaId(int id);


    }
}
