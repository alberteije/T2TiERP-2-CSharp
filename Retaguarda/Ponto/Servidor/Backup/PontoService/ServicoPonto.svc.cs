using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PontoService.Model;
using PontoService.NHibernate;
using NHibernate;

namespace PontoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ServicoPonto : IServicoPonto
    {

        #region PontoParametro
        public int deletePontoParametro(PontoParametroDTO pontoParametro)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoParametroDTO> DAL = new NHibernateDAL<PontoParametroDTO>(session);
                    DAL.delete(pontoParametro);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PontoParametroDTO salvarAtualizarPontoParametro(PontoParametroDTO pontoParametro)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoParametroDTO> DAL = new NHibernateDAL<PontoParametroDTO>(session);
                    DAL.saveOrUpdate(pontoParametro);
                    session.Flush();
                }
                return pontoParametro;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoParametroDTO> selectPontoParametro(PontoParametroDTO pontoParametro)
        {
            try
            {
                IList<PontoParametroDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoParametroDTO> DAL = new NHibernateDAL<PontoParametroDTO>(session);
                    resultado = DAL.select(pontoParametro);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoParametroDTO> selectPontoParametroPagina(int primeiroResultado, int quantidadeResultados, PontoParametroDTO pontoParametro)
        {
            try
            {
                IList<PontoParametroDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoParametroDTO> DAL = new NHibernateDAL<PontoParametroDTO>(session);
                    resultado = DAL.selectPagina<PontoParametroDTO>(primeiroResultado, quantidadeResultados, pontoParametro);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PontoHorario
        public int deletePontoHorario(PontoHorarioDTO pontoHorario)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoHorarioDTO> DAL = new NHibernateDAL<PontoHorarioDTO>(session);
                    DAL.delete(pontoHorario);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PontoHorarioDTO salvarAtualizarPontoHorario(PontoHorarioDTO pontoHorario)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoHorarioDTO> DAL = new NHibernateDAL<PontoHorarioDTO>(session);
                    DAL.saveOrUpdate(pontoHorario);
                    session.Flush();
                }
                return pontoHorario;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoHorarioDTO> selectPontoHorario(PontoHorarioDTO pontoHorario)
        {
            try
            {
                IList<PontoHorarioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoHorarioDTO> DAL = new NHibernateDAL<PontoHorarioDTO>(session);
                    resultado = DAL.select(pontoHorario);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoHorarioDTO> selectPontoHorarioPagina(int primeiroResultado, int quantidadeResultados, PontoHorarioDTO pontoHorario)
        {
            try
            {
                IList<PontoHorarioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoHorarioDTO> DAL = new NHibernateDAL<PontoHorarioDTO>(session);
                    resultado = DAL.selectPagina<PontoHorarioDTO>(primeiroResultado, quantidadeResultados, pontoHorario);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PontoEscala
        public int deletePontoEscala(PontoEscalaDTO PontoEscala)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    PontoEscalaDAL DAL = new PontoEscalaDAL(session);
                    DAL.delete(PontoEscala);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PontoEscalaDTO salvarAtualizarPontoEscala(PontoEscalaDTO PontoEscala)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    PontoEscalaDAL DAL = new PontoEscalaDAL(session);
                    DAL.saveOrUpdate(PontoEscala);
                    session.Flush();
                }
                return PontoEscala;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoEscalaDTO> selectPontoEscala(PontoEscalaDTO PontoEscala)
        {
            try
            {
                IList<PontoEscalaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    PontoEscalaDAL DAL = new PontoEscalaDAL(session);
                    resultado = DAL.select(PontoEscala);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoEscalaDTO> selectPontoEscalaPagina(int primeiroResultado, int quantidadeResultados, PontoEscalaDTO PontoEscala)
        {
            try
            {
                IList<PontoEscalaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    PontoEscalaDAL DAL = new PontoEscalaDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, PontoEscala);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PontoClassificacaoJornada
        public int deletePontoClassificacaoJornada(PontoClassificacaoJornadaDTO pontoClassificacaoJornada)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoClassificacaoJornadaDTO> DAL = new NHibernateDAL<PontoClassificacaoJornadaDTO>(session);
                    DAL.delete(pontoClassificacaoJornada);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PontoClassificacaoJornadaDTO salvarAtualizarPontoClassificacaoJornada(PontoClassificacaoJornadaDTO pontoClassificacaoJornada)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoClassificacaoJornadaDTO> DAL = new NHibernateDAL<PontoClassificacaoJornadaDTO>(session);
                    DAL.saveOrUpdate(pontoClassificacaoJornada);
                    session.Flush();
                }
                return pontoClassificacaoJornada;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoClassificacaoJornadaDTO> selectPontoClassificacaoJornada(PontoClassificacaoJornadaDTO pontoClassificacaoJornada)
        {
            try
            {
                IList<PontoClassificacaoJornadaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoClassificacaoJornadaDTO> DAL = new NHibernateDAL<PontoClassificacaoJornadaDTO>(session);
                    resultado = DAL.select(pontoClassificacaoJornada);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoClassificacaoJornadaDTO> selectPontoClassificacaoJornadaPagina(int primeiroResultado, int quantidadeResultados, PontoClassificacaoJornadaDTO pontoClassificacaoJornada)
        {
            try
            {
                IList<PontoClassificacaoJornadaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoClassificacaoJornadaDTO> DAL = new NHibernateDAL<PontoClassificacaoJornadaDTO>(session);
                    resultado = DAL.selectPagina<PontoClassificacaoJornadaDTO>(primeiroResultado, quantidadeResultados, pontoClassificacaoJornada);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PontoAbono
        public int deletePontoAbono(PontoAbonoDTO pontoAbono)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoAbonoDTO> DAL = new NHibernateDAL<PontoAbonoDTO>(session);
                    DAL.delete(pontoAbono);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PontoAbonoDTO salvarAtualizarPontoAbono(PontoAbonoDTO pontoAbono)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoAbonoDTO> DAL = new NHibernateDAL<PontoAbonoDTO>(session);
                    DAL.saveOrUpdate(pontoAbono);
                    session.Flush();
                }
                return pontoAbono;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoAbonoDTO> selectPontoAbono(PontoAbonoDTO pontoAbono)
        {
            try
            {
                IList<PontoAbonoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoAbonoDTO> DAL = new NHibernateDAL<PontoAbonoDTO>(session);
                    resultado = DAL.select(pontoAbono);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoAbonoDTO> selectPontoAbonoPagina(int primeiroResultado, int quantidadeResultados, PontoAbonoDTO pontoAbono)
        {
            try
            {
                IList<PontoAbonoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoAbonoDTO> DAL = new NHibernateDAL<PontoAbonoDTO>(session);
                    resultado = DAL.selectPagina<PontoAbonoDTO>(primeiroResultado, quantidadeResultados, pontoAbono);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PontoRelogio
        public int deletePontoRelogio(PontoRelogioDTO pontoRelogio)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoRelogioDTO> DAL = new NHibernateDAL<PontoRelogioDTO>(session);
                    DAL.delete(pontoRelogio);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PontoRelogioDTO salvarAtualizarPontoRelogio(PontoRelogioDTO pontoRelogio)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoRelogioDTO> DAL = new NHibernateDAL<PontoRelogioDTO>(session);
                    DAL.saveOrUpdate(pontoRelogio);
                    session.Flush();
                }
                return pontoRelogio;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoRelogioDTO> selectPontoRelogio(PontoRelogioDTO pontoRelogio)
        {
            try
            {
                IList<PontoRelogioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoRelogioDTO> DAL = new NHibernateDAL<PontoRelogioDTO>(session);
                    resultado = DAL.select(pontoRelogio);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoRelogioDTO> selectPontoRelogioPagina(int primeiroResultado, int quantidadeResultados, PontoRelogioDTO pontoRelogio)
        {
            try
            {
                IList<PontoRelogioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoRelogioDTO> DAL = new NHibernateDAL<PontoRelogioDTO>(session);
                    resultado = DAL.selectPagina<PontoRelogioDTO>(primeiroResultado, quantidadeResultados, pontoRelogio);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PontoBancoHoras
        public int deletePontoBancoHoras(PontoBancoHorasDTO pontoBancoHoras)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoBancoHorasDTO> DAL = new NHibernateDAL<PontoBancoHorasDTO>(session);
                    DAL.delete(pontoBancoHoras);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PontoBancoHorasDTO salvarAtualizarPontoBancoHoras(PontoBancoHorasDTO pontoBancoHoras)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoBancoHorasDTO> DAL = new NHibernateDAL<PontoBancoHorasDTO>(session);
                    DAL.saveOrUpdate(pontoBancoHoras);
                    session.Flush();
                }
                return pontoBancoHoras;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoBancoHorasDTO> selectPontoBancoHoras(PontoBancoHorasDTO pontoBancoHoras)
        {
            try
            {
                IList<PontoBancoHorasDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoBancoHorasDTO> DAL = new NHibernateDAL<PontoBancoHorasDTO>(session);
                    resultado = DAL.select(pontoBancoHoras);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoBancoHorasDTO> selectPontoBancoHorasPagina(int primeiroResultado, int quantidadeResultados, PontoBancoHorasDTO pontoBancoHoras)
        {
            try
            {
                IList<PontoBancoHorasDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoBancoHorasDTO> DAL = new NHibernateDAL<PontoBancoHorasDTO>(session);
                    resultado = DAL.selectPagina<PontoBancoHorasDTO>(primeiroResultado, quantidadeResultados, pontoBancoHoras);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PontoMarcacao
        public int deletePontoMarcacao(PontoMarcacaoDTO pontoMarcacao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoMarcacaoDTO> DAL = new NHibernateDAL<PontoMarcacaoDTO>(session);
                    DAL.delete(pontoMarcacao);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PontoMarcacaoDTO salvarAtualizarPontoMarcacao(PontoMarcacaoDTO pontoMarcacao)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoMarcacaoDTO> DAL = new NHibernateDAL<PontoMarcacaoDTO>(session);
                    DAL.saveOrUpdate(pontoMarcacao);
                    session.Flush();
                }
                return pontoMarcacao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoMarcacaoDTO> selectPontoMarcacao(PontoMarcacaoDTO pontoMarcacao)
        {
            try
            {
                IList<PontoMarcacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoMarcacaoDTO> DAL = new NHibernateDAL<PontoMarcacaoDTO>(session);
                    resultado = DAL.select(pontoMarcacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoMarcacaoDTO> selectPontoMarcacaoPagina(int primeiroResultado, int quantidadeResultados, PontoMarcacaoDTO pontoMarcacao)
        {
            try
            {
                IList<PontoMarcacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoMarcacaoDTO> DAL = new NHibernateDAL<PontoMarcacaoDTO>(session);
                    resultado = DAL.selectPagina<PontoMarcacaoDTO>(primeiroResultado, quantidadeResultados, pontoMarcacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PontoFechamentoJornada
        public int deletePontoFechamentoJornada(PontoFechamentoJornadaDTO pontoFechamentoJornada)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoFechamentoJornadaDTO> DAL = new NHibernateDAL<PontoFechamentoJornadaDTO>(session);
                    DAL.delete(pontoFechamentoJornada);
                    session.Flush();
                    resultado = 0;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public PontoFechamentoJornadaDTO salvarAtualizarPontoFechamentoJornada(PontoFechamentoJornadaDTO pontoFechamentoJornada)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoFechamentoJornadaDTO> DAL = new NHibernateDAL<PontoFechamentoJornadaDTO>(session);
                    DAL.saveOrUpdate(pontoFechamentoJornada);
                    session.Flush();
                }
                return pontoFechamentoJornada;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoFechamentoJornadaDTO> selectPontoFechamentoJornada(PontoFechamentoJornadaDTO pontoFechamentoJornada)
        {
            try
            {
                IList<PontoFechamentoJornadaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoFechamentoJornadaDTO> DAL = new NHibernateDAL<PontoFechamentoJornadaDTO>(session);
                    resultado = DAL.select(pontoFechamentoJornada);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PontoFechamentoJornadaDTO> selectPontoFechamentoJornadaPagina(int primeiroResultado, int quantidadeResultados, PontoFechamentoJornadaDTO pontoFechamentoJornada)
        {
            try
            {
                IList<PontoFechamentoJornadaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PontoFechamentoJornadaDTO> DAL = new NHibernateDAL<PontoFechamentoJornadaDTO>(session);
                    resultado = DAL.selectPagina<PontoFechamentoJornadaDTO>(primeiroResultado, quantidadeResultados, pontoFechamentoJornada);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 


        #region Apenas Consultas

        #region Colaborador
        public IList<ColaboradorDTO> selectColaborador(ColaboradorDTO colaborador)
        {
            try
            {
                IList<ColaboradorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ColaboradorDTO> DAL = new NHibernateDAL<ColaboradorDTO>(session);
                    resultado = DAL.select(colaborador);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ColaboradorDTO> selectColaboradorPagina(int primeiroResultado, int quantidadeResultados, ColaboradorDTO colaborador)
        {
            try
            {
                IList<ColaboradorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ColaboradorDTO> DAL = new NHibernateDAL<ColaboradorDTO>(session);
                    resultado = DAL.selectPagina<ColaboradorDTO>(primeiroResultado, quantidadeResultados, colaborador);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion 

        #region Usuario
        public UsuarioDTO selectUsuario(String login, String senha)
        {
            try
            {
                UsuarioDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    UsuarioDAL DAL = new UsuarioDAL(session);
                    resultado = DAL.select(login, senha);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion

        #region ControleAcesso
        public IList<ViewControleAcessoDTO> selectControleAcesso(ViewControleAcessoDTO viewControleAcesso)
        {
            try
            {
                IList<ViewControleAcessoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewControleAcessoDTO> DAL = new NHibernateDAL<ViewControleAcessoDTO>(session);
                    resultado = DAL.select(viewControleAcesso);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }

        }
        #endregion

        #region ViewPontoMarcacao
        public IList<ViewPontoMarcacaoDTO> selectViewPontoMarcacao(ViewPontoMarcacaoDTO viewPontoMarcacao)
        {
            try
            {
                IList<ViewPontoMarcacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewPontoMarcacaoDTO> DAL = new NHibernateDAL<ViewPontoMarcacaoDTO>(session);
                    resultado = DAL.select(viewPontoMarcacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewPontoMarcacaoDTO> selectViewPontoMarcacaoPagina(int primeiroResultado, int quantidadeResultados, ViewPontoMarcacaoDTO viewPontoMarcacao)
        {
            try
            {
                IList<ViewPontoMarcacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewPontoMarcacaoDTO> DAL = new NHibernateDAL<ViewPontoMarcacaoDTO>(session);
                    resultado = DAL.selectPagina<ViewPontoMarcacaoDTO>(primeiroResultado, quantidadeResultados, viewPontoMarcacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 


        #endregion

    }
}
