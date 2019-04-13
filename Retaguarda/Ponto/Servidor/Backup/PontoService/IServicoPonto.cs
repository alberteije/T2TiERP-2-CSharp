using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PontoService.Model;

namespace PontoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicoPonto
    {

        #region PontoParametro
        [OperationContract]
        int deletePontoParametro(PontoParametroDTO pontoParametro);
        [OperationContract]
        PontoParametroDTO salvarAtualizarPontoParametro(PontoParametroDTO pontoParametro);
        [OperationContract]
        IList<PontoParametroDTO> selectPontoParametro(PontoParametroDTO pontoParametro);
        [OperationContract]
        IList<PontoParametroDTO> selectPontoParametroPagina(int primeiroResultado, int quantidadeResultados, PontoParametroDTO pontoParametro);
        #endregion 

        #region PontoHorario
        [OperationContract]
        int deletePontoHorario(PontoHorarioDTO pontoHorario);
        [OperationContract]
        PontoHorarioDTO salvarAtualizarPontoHorario(PontoHorarioDTO pontoHorario);
        [OperationContract]
        IList<PontoHorarioDTO> selectPontoHorario(PontoHorarioDTO pontoHorario);
        [OperationContract]
        IList<PontoHorarioDTO> selectPontoHorarioPagina(int primeiroResultado, int quantidadeResultados, PontoHorarioDTO pontoHorario);
        #endregion 

        #region PontoEscala
        [OperationContract]
        int deletePontoEscala(PontoEscalaDTO pontoEscala);
        [OperationContract]
        PontoEscalaDTO salvarAtualizarPontoEscala(PontoEscalaDTO pontoEscala);
        [OperationContract]
        IList<PontoEscalaDTO> selectPontoEscala(PontoEscalaDTO pontoEscala);
        [OperationContract]
        IList<PontoEscalaDTO> selectPontoEscalaPagina(int primeiroResultado, int quantidadeResultados, PontoEscalaDTO pontoEscala);
        #endregion 

        #region PontoClassificacaoJornada
        [OperationContract]
        int deletePontoClassificacaoJornada(PontoClassificacaoJornadaDTO pontoClassificacaoJornada);
        [OperationContract]
        PontoClassificacaoJornadaDTO salvarAtualizarPontoClassificacaoJornada(PontoClassificacaoJornadaDTO pontoClassificacaoJornada);
        [OperationContract]
        IList<PontoClassificacaoJornadaDTO> selectPontoClassificacaoJornada(PontoClassificacaoJornadaDTO pontoClassificacaoJornada);
        [OperationContract]
        IList<PontoClassificacaoJornadaDTO> selectPontoClassificacaoJornadaPagina(int primeiroResultado, int quantidadeResultados, PontoClassificacaoJornadaDTO pontoClassificacaoJornada);
        #endregion 

        #region PontoAbono
        [OperationContract]
        int deletePontoAbono(PontoAbonoDTO pontoAbono);
        [OperationContract]
        PontoAbonoDTO salvarAtualizarPontoAbono(PontoAbonoDTO pontoAbono);
        [OperationContract]
        IList<PontoAbonoDTO> selectPontoAbono(PontoAbonoDTO pontoAbono);
        [OperationContract]
        IList<PontoAbonoDTO> selectPontoAbonoPagina(int primeiroResultado, int quantidadeResultados, PontoAbonoDTO pontoAbono);
        #endregion 

        #region PontoRelogio
        [OperationContract]
        int deletePontoRelogio(PontoRelogioDTO pontoRelogio);
        [OperationContract]
        PontoRelogioDTO salvarAtualizarPontoRelogio(PontoRelogioDTO pontoRelogio);
        [OperationContract]
        IList<PontoRelogioDTO> selectPontoRelogio(PontoRelogioDTO pontoRelogio);
        [OperationContract]
        IList<PontoRelogioDTO> selectPontoRelogioPagina(int primeiroResultado, int quantidadeResultados, PontoRelogioDTO pontoRelogio);
        #endregion 

        #region PontoBancoHoras
        [OperationContract]
        int deletePontoBancoHoras(PontoBancoHorasDTO pontoBancoHoras);
        [OperationContract]
        PontoBancoHorasDTO salvarAtualizarPontoBancoHoras(PontoBancoHorasDTO pontoBancoHoras);
        [OperationContract]
        IList<PontoBancoHorasDTO> selectPontoBancoHoras(PontoBancoHorasDTO pontoBancoHoras);
        [OperationContract]
        IList<PontoBancoHorasDTO> selectPontoBancoHorasPagina(int primeiroResultado, int quantidadeResultados, PontoBancoHorasDTO pontoBancoHoras);
        #endregion 

        #region PontoMarcacao
        [OperationContract]
        int deletePontoMarcacao(PontoMarcacaoDTO pontoMarcacao);
        [OperationContract]
        PontoMarcacaoDTO salvarAtualizarPontoMarcacao(PontoMarcacaoDTO pontoMarcacao);
        [OperationContract]
        IList<PontoMarcacaoDTO> selectPontoMarcacao(PontoMarcacaoDTO pontoMarcacao);
        [OperationContract]
        IList<PontoMarcacaoDTO> selectPontoMarcacaoPagina(int primeiroResultado, int quantidadeResultados, PontoMarcacaoDTO pontoMarcacao);
        #endregion 

        #region PontoFechamentoJornada
        [OperationContract]
        int deletePontoFechamentoJornada(PontoFechamentoJornadaDTO pontoFechamentoJornada);
        [OperationContract]
        PontoFechamentoJornadaDTO salvarAtualizarPontoFechamentoJornada(PontoFechamentoJornadaDTO pontoFechamentoJornada);
        [OperationContract]
        IList<PontoFechamentoJornadaDTO> selectPontoFechamentoJornada(PontoFechamentoJornadaDTO pontoFechamentoJornada);
        [OperationContract]
        IList<PontoFechamentoJornadaDTO> selectPontoFechamentoJornadaPagina(int primeiroResultado, int quantidadeResultados, PontoFechamentoJornadaDTO pontoFechamentoJornada);
        #endregion 




        #region Apenas Consultas

        #region Colaborador
        [OperationContract]
        IList<ColaboradorDTO> selectColaborador(ColaboradorDTO colaborador);
        [OperationContract]
        IList<ColaboradorDTO> selectColaboradorPagina(int primeiroResultado, int quantidadeResultados, ColaboradorDTO colaborador);
        #endregion 

        #region Usuario
        [OperationContract]
        UsuarioDTO selectUsuario(String login, String senha);
        #endregion

        #region ControleAcesso
        [OperationContract]
        IList<ViewControleAcessoDTO> selectControleAcesso(ViewControleAcessoDTO viewControleAcesso);
        #endregion

        #region ViewPontoMarcacao
        [OperationContract]
        IList<ViewPontoMarcacaoDTO> selectViewPontoMarcacao(ViewPontoMarcacaoDTO viewPontoMarcacao);
        [OperationContract]
        IList<ViewPontoMarcacaoDTO> selectViewPontoMarcacaoPagina(int primeiroResultado, int quantidadeResultados, ViewPontoMarcacaoDTO viewPontoMarcacao);
        #endregion
        
        #endregion

    }
}
