using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ContratosService.Model;

namespace ContratosService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicoContratos
    {
        #region Contrato
        [OperationContract]
        int deleteContrato(ContratoDTO contrato);
        [OperationContract]
        ContratoDTO salvarAtualizarContrato(ContratoDTO contrato);
        [OperationContract]
        IList<ContratoDTO> selectContrato(ContratoDTO contrato);
        [OperationContract]
        IList<ContratoDTO> selectContratoPagina(int primeiroResultado, int quantidadeResultados, ContratoDTO contrato);
        #endregion 

        #region ContratoTipoServico
        [OperationContract]
        int deleteContratoTipoServico(ContratoTipoServicoDTO contratoTipoServico);
        [OperationContract]
        ContratoTipoServicoDTO salvarAtualizarContratoTipoServico(ContratoTipoServicoDTO contratoTipoServico);
        [OperationContract]
        IList<ContratoTipoServicoDTO> selectContratoTipoServico(ContratoTipoServicoDTO contratoTipoServico);
        [OperationContract]
        IList<ContratoTipoServicoDTO> selectContratoTipoServicoPagina(int primeiroResultado, int quantidadeResultados, ContratoTipoServicoDTO contratoTipoServico);
        #endregion 

        #region TipoContrato
        [OperationContract]
        int deleteTipoContrato(TipoContratoDTO tipoContrato);
        [OperationContract]
        TipoContratoDTO salvarAtualizarTipoContrato(TipoContratoDTO tipoContrato);
        [OperationContract]
        IList<TipoContratoDTO> selectTipoContrato(TipoContratoDTO tipoContrato);
        [OperationContract]
        IList<TipoContratoDTO> selectTipoContratoPagina(int primeiroResultado, int quantidadeResultados, TipoContratoDTO tipoContrato);
        #endregion 

        #region ContratoSolicitacaoServico
        [OperationContract]
        int deleteContratoSolicitacaoServico(ContratoSolicitacaoServicoDTO contratoSolicitacaoServico);
        [OperationContract]
        ContratoSolicitacaoServicoDTO salvarAtualizarContratoSolicitacaoServico(ContratoSolicitacaoServicoDTO contratoSolicitacaoServico);
        [OperationContract]
        IList<ContratoSolicitacaoServicoDTO> selectContratoSolicitacaoServico(ContratoSolicitacaoServicoDTO contratoSolicitacaoServico);
        [OperationContract]
        IList<ContratoSolicitacaoServicoDTO> selectContratoSolicitacaoServicoPagina(int primeiroResultado, int quantidadeResultados, ContratoSolicitacaoServicoDTO contratoSolicitacaoServico);
        #endregion 

        #region Fornecedor
        [OperationContract]
        IList<FornecedorDTO> selectFornecedor(FornecedorDTO fornecedor);
        [OperationContract]
        IList<FornecedorDTO> selectFornecedorPagina(int primeiroResultado, int quantidadeResultados, FornecedorDTO fornecedor);
        #endregion     

        #region Cliente
        [OperationContract]
        IList<ClienteDTO> selectCliente(ClienteDTO cliente);
        [OperationContract]
        IList<ClienteDTO> selectClientePagina(int primeiroResultado, int quantidadeResultados, ClienteDTO cliente);
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
