using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FolhaService.Model;

namespace FolhaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicoFolha
    {

        #region FolhaParametros
        [OperationContract]
        int deleteFolhaParametros(FolhaParametrosDTO folhaParametros);
        [OperationContract]
        FolhaParametrosDTO salvarAtualizarFolhaParametros(FolhaParametrosDTO folhaParametros);
        [OperationContract]
        IList<FolhaParametrosDTO> selectFolhaParametros(FolhaParametrosDTO folhaParametros);
        [OperationContract]
        IList<FolhaParametrosDTO> selectFolhaParametrosPagina(int primeiroResultado, int quantidadeResultados, FolhaParametrosDTO folhaParametros);
        #endregion 

        #region GuiasAcumuladas
        [OperationContract]
        int deleteGuiasAcumuladas(GuiasAcumuladasDTO guiasAcumuladas);
        [OperationContract]
        GuiasAcumuladasDTO salvarAtualizarGuiasAcumuladas(GuiasAcumuladasDTO guiasAcumuladas);
        [OperationContract]
        IList<GuiasAcumuladasDTO> selectGuiasAcumuladas(GuiasAcumuladasDTO guiasAcumuladas);
        [OperationContract]
        IList<GuiasAcumuladasDTO> selectGuiasAcumuladasPagina(int primeiroResultado, int quantidadeResultados, GuiasAcumuladasDTO guiasAcumuladas);
        #endregion 

        #region FolhaPlanoSaude
        [OperationContract]
        int deleteFolhaPlanoSaude(FolhaPlanoSaudeDTO folhaPlanoSaude);
        [OperationContract]
        FolhaPlanoSaudeDTO salvarAtualizarFolhaPlanoSaude(FolhaPlanoSaudeDTO folhaPlanoSaude);
        [OperationContract]
        IList<FolhaPlanoSaudeDTO> selectFolhaPlanoSaude(FolhaPlanoSaudeDTO folhaPlanoSaude);
        [OperationContract]
        IList<FolhaPlanoSaudeDTO> selectFolhaPlanoSaudePagina(int primeiroResultado, int quantidadeResultados, FolhaPlanoSaudeDTO folhaPlanoSaude);
        #endregion 

        #region FolhaEvento
        [OperationContract]
        int deleteFolhaEvento(FolhaEventoDTO folhaEvento);
        [OperationContract]
        FolhaEventoDTO salvarAtualizarFolhaEvento(FolhaEventoDTO folhaEvento);
        [OperationContract]
        IList<FolhaEventoDTO> selectFolhaEvento(FolhaEventoDTO folhaEvento);
        [OperationContract]
        IList<FolhaEventoDTO> selectFolhaEventoPagina(int primeiroResultado, int quantidadeResultados, FolhaEventoDTO folhaEvento);
        #endregion 

        #region FolhaTipoAfastamento
        [OperationContract]
        int deleteFolhaTipoAfastamento(FolhaTipoAfastamentoDTO folhaTipoAfastamento);
        [OperationContract]
        FolhaTipoAfastamentoDTO salvarAtualizarFolhaTipoAfastamento(FolhaTipoAfastamentoDTO folhaTipoAfastamento);
        [OperationContract]
        IList<FolhaTipoAfastamentoDTO> selectFolhaTipoAfastamento(FolhaTipoAfastamentoDTO folhaTipoAfastamento);
        [OperationContract]
        IList<FolhaTipoAfastamentoDTO> selectFolhaTipoAfastamentoPagina(int primeiroResultado, int quantidadeResultados, FolhaTipoAfastamentoDTO folhaTipoAfastamento);
        #endregion 

        #region FolhaAfastamento
        [OperationContract]
        int deleteFolhaAfastamento(FolhaAfastamentoDTO folhaAfastamento);
        [OperationContract]
        FolhaAfastamentoDTO salvarAtualizarFolhaAfastamento(FolhaAfastamentoDTO folhaAfastamento);
        [OperationContract]
        IList<FolhaAfastamentoDTO> selectFolhaAfastamento(FolhaAfastamentoDTO folhaAfastamento);
        [OperationContract]
        IList<FolhaAfastamentoDTO> selectFolhaAfastamentoPagina(int primeiroResultado, int quantidadeResultados, FolhaAfastamentoDTO folhaAfastamento);
        #endregion 

        #region FolhaFeriasColetivas
        [OperationContract]
        int deleteFolhaFeriasColetivas(FolhaFeriasColetivasDTO folhaFeriasColetivas);
        [OperationContract]
        FolhaFeriasColetivasDTO salvarAtualizarFolhaFeriasColetivas(FolhaFeriasColetivasDTO folhaFeriasColetivas);
        [OperationContract]
        IList<FolhaFeriasColetivasDTO> selectFolhaFeriasColetivas(FolhaFeriasColetivasDTO folhaFeriasColetivas);
        [OperationContract]
        IList<FolhaFeriasColetivasDTO> selectFolhaFeriasColetivasPagina(int primeiroResultado, int quantidadeResultados, FolhaFeriasColetivasDTO folhaFeriasColetivas);
        #endregion 

        #region FeriasPeriodoAquisitivo
        [OperationContract]
        int deleteFeriasPeriodoAquisitivo(FeriasPeriodoAquisitivoDTO feriasPeriodoAquisitivo);
        [OperationContract]
        FeriasPeriodoAquisitivoDTO salvarAtualizarFeriasPeriodoAquisitivo(FeriasPeriodoAquisitivoDTO feriasPeriodoAquisitivo);
        [OperationContract]
        IList<FeriasPeriodoAquisitivoDTO> selectFeriasPeriodoAquisitivo(FeriasPeriodoAquisitivoDTO feriasPeriodoAquisitivo);
        [OperationContract]
        IList<FeriasPeriodoAquisitivoDTO> selectFeriasPeriodoAquisitivoPagina(int primeiroResultado, int quantidadeResultados, FeriasPeriodoAquisitivoDTO feriasPeriodoAquisitivo);
        #endregion 

        #region FolhaFechamento
        [OperationContract]
        int deleteFolhaFechamento(FolhaFechamentoDTO folhaFechamento);
        [OperationContract]
        FolhaFechamentoDTO salvarAtualizarFolhaFechamento(FolhaFechamentoDTO folhaFechamento);
        [OperationContract]
        IList<FolhaFechamentoDTO> selectFolhaFechamento(FolhaFechamentoDTO folhaFechamento);
        [OperationContract]
        IList<FolhaFechamentoDTO> selectFolhaFechamentoPagina(int primeiroResultado, int quantidadeResultados, FolhaFechamentoDTO folhaFechamento);
        #endregion 

        #region FolhaHistoricoSalarial
        [OperationContract]
        int deleteFolhaHistoricoSalarial(FolhaHistoricoSalarialDTO folhaHistoricoSalarial);
        [OperationContract]
        FolhaHistoricoSalarialDTO salvarAtualizarFolhaHistoricoSalarial(FolhaHistoricoSalarialDTO folhaHistoricoSalarial);
        [OperationContract]
        IList<FolhaHistoricoSalarialDTO> selectFolhaHistoricoSalarial(FolhaHistoricoSalarialDTO folhaHistoricoSalarial);
        [OperationContract]
        IList<FolhaHistoricoSalarialDTO> selectFolhaHistoricoSalarialPagina(int primeiroResultado, int quantidadeResultados, FolhaHistoricoSalarialDTO folhaHistoricoSalarial);
        #endregion 

        #region EmpresaTransporteItinerario
        [OperationContract]
        IList<EmpresaTransporteItinerarioDTO> selectEmpresaTransporteItinerario(EmpresaTransporteItinerarioDTO empresaTransporteItinerario);
        [OperationContract]
        IList<EmpresaTransporteItinerarioDTO> selectEmpresaTransporteItinerarioPagina(int primeiroResultado, int quantidadeResultados, EmpresaTransporteItinerarioDTO empresaTransporteItinerario);
        #endregion 

        #region FolhaValeTransporte
        [OperationContract]
        int deleteFolhaValeTransporte(FolhaValeTransporteDTO folhaValeTransporte);
        [OperationContract]
        FolhaValeTransporteDTO salvarAtualizarFolhaValeTransporte(FolhaValeTransporteDTO folhaValeTransporte);
        [OperationContract]
        IList<FolhaValeTransporteDTO> selectFolhaValeTransporte(FolhaValeTransporteDTO folhaValeTransporte);
        [OperationContract]
        IList<FolhaValeTransporteDTO> selectFolhaValeTransportePagina(int primeiroResultado, int quantidadeResultados, FolhaValeTransporteDTO folhaValeTransporte);
        #endregion 

        #region FolhaRescisao
        [OperationContract]
        int deleteFolhaRescisao(FolhaRescisaoDTO folhaRescisao);
        [OperationContract]
        FolhaRescisaoDTO salvarAtualizarFolhaRescisao(FolhaRescisaoDTO folhaRescisao);
        [OperationContract]
        IList<FolhaRescisaoDTO> selectFolhaRescisao(FolhaRescisaoDTO folhaRescisao);
        [OperationContract]
        IList<FolhaRescisaoDTO> selectFolhaRescisaoPagina(int primeiroResultado, int quantidadeResultados, FolhaRescisaoDTO folhaRescisao);
        #endregion 

        #region FolhaInssServico
        [OperationContract]
        int deleteFolhaInssServico(FolhaInssServicoDTO folhaInssServico);
        [OperationContract]
        FolhaInssServicoDTO salvarAtualizarFolhaInssServico(FolhaInssServicoDTO folhaInssServico);
        [OperationContract]
        IList<FolhaInssServicoDTO> selectFolhaInssServico(FolhaInssServicoDTO folhaInssServico);
        [OperationContract]
        IList<FolhaInssServicoDTO> selectFolhaInssServicoPagina(int primeiroResultado, int quantidadeResultados, FolhaInssServicoDTO folhaInssServico);
        #endregion 

        #region FolhaLancamentoCabecalho
        [OperationContract]
        int deleteFolhaLancamentoCabecalho(FolhaLancamentoCabecalhoDTO folhaLancamentoCabecalho);
        [OperationContract]
        FolhaLancamentoCabecalhoDTO salvarAtualizarFolhaLancamentoCabecalho(FolhaLancamentoCabecalhoDTO folhaLancamentoCabecalho);
        [OperationContract]
        IList<FolhaLancamentoCabecalhoDTO> selectFolhaLancamentoCabecalho(FolhaLancamentoCabecalhoDTO folhaLancamentoCabecalho);
        [OperationContract]
        IList<FolhaLancamentoCabecalhoDTO> selectFolhaLancamentoCabecalhoPagina(int primeiroResultado, int quantidadeResultados, FolhaLancamentoCabecalhoDTO folhaLancamentoCabecalho);
        #endregion 

        #region FolhaInss
        [OperationContract]
        int deleteFolhaInss(FolhaInssDTO folhaInss);
        [OperationContract]
        FolhaInssDTO salvarAtualizarFolhaInss(FolhaInssDTO folhaInss);
        [OperationContract]
        IList<FolhaInssDTO> selectFolhaInss(FolhaInssDTO folhaInss);
        [OperationContract]
        IList<FolhaInssDTO> selectFolhaInssPagina(int primeiroResultado, int quantidadeResultados, FolhaInssDTO folhaInss);
        #endregion 

        #region FolhaPpp
        [OperationContract]
        int deleteFolhaPpp(FolhaPppDTO folhaPpp);
        [OperationContract]
        FolhaPppDTO salvarAtualizarFolhaPpp(FolhaPppDTO folhaPpp);
        [OperationContract]
        IList<FolhaPppDTO> selectFolhaPpp(FolhaPppDTO folhaPpp);
        [OperationContract]
        IList<FolhaPppDTO> selectFolhaPppPagina(int primeiroResultado, int quantidadeResultados, FolhaPppDTO folhaPpp);
        #endregion 



        #region Apenas Consultas

        #region Colaborador
        [OperationContract]
        IList<ColaboradorDTO> selectColaborador(ColaboradorDTO colaborador);
        [OperationContract]
        IList<ColaboradorDTO> selectColaboradorPagina(int primeiroResultado, int quantidadeResultados, ColaboradorDTO colaborador);
        #endregion 

        #region OperadoraPlanoSaude
        [OperationContract]
        IList<OperadoraPlanoSaudeDTO> selectOperadoraPlanoSaude(OperadoraPlanoSaudeDTO operadoraPlanoSaude);
        [OperationContract]
        IList<OperadoraPlanoSaudeDTO> selectOperadoraPlanoSaudePagina(int primeiroResultado, int quantidadeResultados, OperadoraPlanoSaudeDTO operadoraPlanoSaude);
        #endregion 

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

        #endregion

    }
}
