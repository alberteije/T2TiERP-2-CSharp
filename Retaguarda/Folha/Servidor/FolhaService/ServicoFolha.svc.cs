using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FolhaService.Model;
using FolhaService.NHibernate;
using NHibernate;

namespace FolhaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ServicoFolha : IServicoFolha
    {

        #region FolhaParametros
        public int deleteFolhaParametros(FolhaParametrosDTO folhaParametros)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaParametrosDTO> DAL = new NHibernateDAL<FolhaParametrosDTO>(session);
                    DAL.delete(folhaParametros);
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


        public FolhaParametrosDTO salvarAtualizarFolhaParametros(FolhaParametrosDTO folhaParametros)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaParametrosDTO> DAL = new NHibernateDAL<FolhaParametrosDTO>(session);
                    DAL.saveOrUpdate(folhaParametros);
                    session.Flush();
                }
                return folhaParametros;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaParametrosDTO> selectFolhaParametros(FolhaParametrosDTO folhaParametros)
        {
            try
            {
                IList<FolhaParametrosDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaParametrosDTO> DAL = new NHibernateDAL<FolhaParametrosDTO>(session);
                    resultado = DAL.select(folhaParametros);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaParametrosDTO> selectFolhaParametrosPagina(int primeiroResultado, int quantidadeResultados, FolhaParametrosDTO folhaParametros)
        {
            try
            {
                IList<FolhaParametrosDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaParametrosDTO> DAL = new NHibernateDAL<FolhaParametrosDTO>(session);
                    resultado = DAL.selectPagina<FolhaParametrosDTO>(primeiroResultado, quantidadeResultados, folhaParametros);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region GuiasAcumuladas
        public int deleteGuiasAcumuladas(GuiasAcumuladasDTO guiasAcumuladas)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GuiasAcumuladasDTO> DAL = new NHibernateDAL<GuiasAcumuladasDTO>(session);
                    DAL.delete(guiasAcumuladas);
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


        public GuiasAcumuladasDTO salvarAtualizarGuiasAcumuladas(GuiasAcumuladasDTO guiasAcumuladas)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GuiasAcumuladasDTO> DAL = new NHibernateDAL<GuiasAcumuladasDTO>(session);
                    DAL.saveOrUpdate(guiasAcumuladas);
                    session.Flush();
                }
                return guiasAcumuladas;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<GuiasAcumuladasDTO> selectGuiasAcumuladas(GuiasAcumuladasDTO guiasAcumuladas)
        {
            try
            {
                IList<GuiasAcumuladasDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GuiasAcumuladasDTO> DAL = new NHibernateDAL<GuiasAcumuladasDTO>(session);
                    resultado = DAL.select(guiasAcumuladas);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<GuiasAcumuladasDTO> selectGuiasAcumuladasPagina(int primeiroResultado, int quantidadeResultados, GuiasAcumuladasDTO guiasAcumuladas)
        {
            try
            {
                IList<GuiasAcumuladasDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<GuiasAcumuladasDTO> DAL = new NHibernateDAL<GuiasAcumuladasDTO>(session);
                    resultado = DAL.selectPagina<GuiasAcumuladasDTO>(primeiroResultado, quantidadeResultados, guiasAcumuladas);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaPlanoSaude
        public int deleteFolhaPlanoSaude(FolhaPlanoSaudeDTO folhaPlanoSaude)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaPlanoSaudeDTO> DAL = new NHibernateDAL<FolhaPlanoSaudeDTO>(session);
                    DAL.delete(folhaPlanoSaude);
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


        public FolhaPlanoSaudeDTO salvarAtualizarFolhaPlanoSaude(FolhaPlanoSaudeDTO folhaPlanoSaude)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaPlanoSaudeDTO> DAL = new NHibernateDAL<FolhaPlanoSaudeDTO>(session);
                    DAL.saveOrUpdate(folhaPlanoSaude);
                    session.Flush();
                }
                return folhaPlanoSaude;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaPlanoSaudeDTO> selectFolhaPlanoSaude(FolhaPlanoSaudeDTO folhaPlanoSaude)
        {
            try
            {
                IList<FolhaPlanoSaudeDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaPlanoSaudeDTO> DAL = new NHibernateDAL<FolhaPlanoSaudeDTO>(session);
                    resultado = DAL.select(folhaPlanoSaude);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaPlanoSaudeDTO> selectFolhaPlanoSaudePagina(int primeiroResultado, int quantidadeResultados, FolhaPlanoSaudeDTO folhaPlanoSaude)
        {
            try
            {
                IList<FolhaPlanoSaudeDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaPlanoSaudeDTO> DAL = new NHibernateDAL<FolhaPlanoSaudeDTO>(session);
                    resultado = DAL.selectPagina<FolhaPlanoSaudeDTO>(primeiroResultado, quantidadeResultados, folhaPlanoSaude);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaEvento
        public int deleteFolhaEvento(FolhaEventoDTO folhaEvento)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaEventoDTO> DAL = new NHibernateDAL<FolhaEventoDTO>(session);
                    DAL.delete(folhaEvento);
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


        public FolhaEventoDTO salvarAtualizarFolhaEvento(FolhaEventoDTO folhaEvento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaEventoDTO> DAL = new NHibernateDAL<FolhaEventoDTO>(session);
                    DAL.saveOrUpdate(folhaEvento);
                    session.Flush();
                }
                return folhaEvento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaEventoDTO> selectFolhaEvento(FolhaEventoDTO folhaEvento)
        {
            try
            {
                IList<FolhaEventoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaEventoDTO> DAL = new NHibernateDAL<FolhaEventoDTO>(session);
                    resultado = DAL.select(folhaEvento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaEventoDTO> selectFolhaEventoPagina(int primeiroResultado, int quantidadeResultados, FolhaEventoDTO folhaEvento)
        {
            try
            {
                IList<FolhaEventoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaEventoDTO> DAL = new NHibernateDAL<FolhaEventoDTO>(session);
                    resultado = DAL.selectPagina<FolhaEventoDTO>(primeiroResultado, quantidadeResultados, folhaEvento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaTipoAfastamento
        public int deleteFolhaTipoAfastamento(FolhaTipoAfastamentoDTO folhaTipoAfastamento)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaTipoAfastamentoDTO> DAL = new NHibernateDAL<FolhaTipoAfastamentoDTO>(session);
                    DAL.delete(folhaTipoAfastamento);
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


        public FolhaTipoAfastamentoDTO salvarAtualizarFolhaTipoAfastamento(FolhaTipoAfastamentoDTO folhaTipoAfastamento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaTipoAfastamentoDTO> DAL = new NHibernateDAL<FolhaTipoAfastamentoDTO>(session);
                    DAL.saveOrUpdate(folhaTipoAfastamento);
                    session.Flush();
                }
                return folhaTipoAfastamento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaTipoAfastamentoDTO> selectFolhaTipoAfastamento(FolhaTipoAfastamentoDTO folhaTipoAfastamento)
        {
            try
            {
                IList<FolhaTipoAfastamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaTipoAfastamentoDTO> DAL = new NHibernateDAL<FolhaTipoAfastamentoDTO>(session);
                    resultado = DAL.select(folhaTipoAfastamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaTipoAfastamentoDTO> selectFolhaTipoAfastamentoPagina(int primeiroResultado, int quantidadeResultados, FolhaTipoAfastamentoDTO folhaTipoAfastamento)
        {
            try
            {
                IList<FolhaTipoAfastamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaTipoAfastamentoDTO> DAL = new NHibernateDAL<FolhaTipoAfastamentoDTO>(session);
                    resultado = DAL.selectPagina<FolhaTipoAfastamentoDTO>(primeiroResultado, quantidadeResultados, folhaTipoAfastamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaAfastamento
        public int deleteFolhaAfastamento(FolhaAfastamentoDTO folhaAfastamento)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaAfastamentoDTO> DAL = new NHibernateDAL<FolhaAfastamentoDTO>(session);
                    DAL.delete(folhaAfastamento);
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


        public FolhaAfastamentoDTO salvarAtualizarFolhaAfastamento(FolhaAfastamentoDTO folhaAfastamento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaAfastamentoDTO> DAL = new NHibernateDAL<FolhaAfastamentoDTO>(session);
                    DAL.saveOrUpdate(folhaAfastamento);
                    session.Flush();
                }
                return folhaAfastamento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaAfastamentoDTO> selectFolhaAfastamento(FolhaAfastamentoDTO folhaAfastamento)
        {
            try
            {
                IList<FolhaAfastamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaAfastamentoDTO> DAL = new NHibernateDAL<FolhaAfastamentoDTO>(session);
                    resultado = DAL.select(folhaAfastamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaAfastamentoDTO> selectFolhaAfastamentoPagina(int primeiroResultado, int quantidadeResultados, FolhaAfastamentoDTO folhaAfastamento)
        {
            try
            {
                IList<FolhaAfastamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaAfastamentoDTO> DAL = new NHibernateDAL<FolhaAfastamentoDTO>(session);
                    resultado = DAL.selectPagina<FolhaAfastamentoDTO>(primeiroResultado, quantidadeResultados, folhaAfastamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaFeriasColetivas
        public int deleteFolhaFeriasColetivas(FolhaFeriasColetivasDTO folhaFeriasColetivas)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaFeriasColetivasDTO> DAL = new NHibernateDAL<FolhaFeriasColetivasDTO>(session);
                    DAL.delete(folhaFeriasColetivas);
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


        public FolhaFeriasColetivasDTO salvarAtualizarFolhaFeriasColetivas(FolhaFeriasColetivasDTO folhaFeriasColetivas)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaFeriasColetivasDTO> DAL = new NHibernateDAL<FolhaFeriasColetivasDTO>(session);
                    DAL.saveOrUpdate(folhaFeriasColetivas);
                    session.Flush();
                }
                return folhaFeriasColetivas;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaFeriasColetivasDTO> selectFolhaFeriasColetivas(FolhaFeriasColetivasDTO folhaFeriasColetivas)
        {
            try
            {
                IList<FolhaFeriasColetivasDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaFeriasColetivasDTO> DAL = new NHibernateDAL<FolhaFeriasColetivasDTO>(session);
                    resultado = DAL.select(folhaFeriasColetivas);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaFeriasColetivasDTO> selectFolhaFeriasColetivasPagina(int primeiroResultado, int quantidadeResultados, FolhaFeriasColetivasDTO folhaFeriasColetivas)
        {
            try
            {
                IList<FolhaFeriasColetivasDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaFeriasColetivasDTO> DAL = new NHibernateDAL<FolhaFeriasColetivasDTO>(session);
                    resultado = DAL.selectPagina<FolhaFeriasColetivasDTO>(primeiroResultado, quantidadeResultados, folhaFeriasColetivas);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FeriasPeriodoAquisitivo
        public int deleteFeriasPeriodoAquisitivo(FeriasPeriodoAquisitivoDTO feriasPeriodoAquisitivo)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FeriasPeriodoAquisitivoDTO> DAL = new NHibernateDAL<FeriasPeriodoAquisitivoDTO>(session);
                    DAL.delete(feriasPeriodoAquisitivo);
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


        public FeriasPeriodoAquisitivoDTO salvarAtualizarFeriasPeriodoAquisitivo(FeriasPeriodoAquisitivoDTO feriasPeriodoAquisitivo)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FeriasPeriodoAquisitivoDTO> DAL = new NHibernateDAL<FeriasPeriodoAquisitivoDTO>(session);
                    DAL.saveOrUpdate(feriasPeriodoAquisitivo);
                    session.Flush();
                }
                return feriasPeriodoAquisitivo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FeriasPeriodoAquisitivoDTO> selectFeriasPeriodoAquisitivo(FeriasPeriodoAquisitivoDTO feriasPeriodoAquisitivo)
        {
            try
            {
                IList<FeriasPeriodoAquisitivoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FeriasPeriodoAquisitivoDTO> DAL = new NHibernateDAL<FeriasPeriodoAquisitivoDTO>(session);
                    resultado = DAL.select(feriasPeriodoAquisitivo);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FeriasPeriodoAquisitivoDTO> selectFeriasPeriodoAquisitivoPagina(int primeiroResultado, int quantidadeResultados, FeriasPeriodoAquisitivoDTO feriasPeriodoAquisitivo)
        {
            try
            {
                IList<FeriasPeriodoAquisitivoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FeriasPeriodoAquisitivoDTO> DAL = new NHibernateDAL<FeriasPeriodoAquisitivoDTO>(session);
                    resultado = DAL.selectPagina<FeriasPeriodoAquisitivoDTO>(primeiroResultado, quantidadeResultados, feriasPeriodoAquisitivo);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaFechamento
        public int deleteFolhaFechamento(FolhaFechamentoDTO folhaFechamento)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaFechamentoDTO> DAL = new NHibernateDAL<FolhaFechamentoDTO>(session);
                    DAL.delete(folhaFechamento);
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


        public FolhaFechamentoDTO salvarAtualizarFolhaFechamento(FolhaFechamentoDTO folhaFechamento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaFechamentoDTO> DAL = new NHibernateDAL<FolhaFechamentoDTO>(session);
                    DAL.saveOrUpdate(folhaFechamento);
                    session.Flush();
                }
                return folhaFechamento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaFechamentoDTO> selectFolhaFechamento(FolhaFechamentoDTO folhaFechamento)
        {
            try
            {
                IList<FolhaFechamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaFechamentoDTO> DAL = new NHibernateDAL<FolhaFechamentoDTO>(session);
                    resultado = DAL.select(folhaFechamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaFechamentoDTO> selectFolhaFechamentoPagina(int primeiroResultado, int quantidadeResultados, FolhaFechamentoDTO folhaFechamento)
        {
            try
            {
                IList<FolhaFechamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaFechamentoDTO> DAL = new NHibernateDAL<FolhaFechamentoDTO>(session);
                    resultado = DAL.selectPagina<FolhaFechamentoDTO>(primeiroResultado, quantidadeResultados, folhaFechamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaHistoricoSalarial
        public int deleteFolhaHistoricoSalarial(FolhaHistoricoSalarialDTO folhaHistoricoSalarial)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaHistoricoSalarialDTO> DAL = new NHibernateDAL<FolhaHistoricoSalarialDTO>(session);
                    DAL.delete(folhaHistoricoSalarial);
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


        public FolhaHistoricoSalarialDTO salvarAtualizarFolhaHistoricoSalarial(FolhaHistoricoSalarialDTO folhaHistoricoSalarial)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaHistoricoSalarialDTO> DAL = new NHibernateDAL<FolhaHistoricoSalarialDTO>(session);
                    DAL.saveOrUpdate(folhaHistoricoSalarial);
                    session.Flush();
                }
                return folhaHistoricoSalarial;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaHistoricoSalarialDTO> selectFolhaHistoricoSalarial(FolhaHistoricoSalarialDTO folhaHistoricoSalarial)
        {
            try
            {
                IList<FolhaHistoricoSalarialDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaHistoricoSalarialDTO> DAL = new NHibernateDAL<FolhaHistoricoSalarialDTO>(session);
                    resultado = DAL.select(folhaHistoricoSalarial);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaHistoricoSalarialDTO> selectFolhaHistoricoSalarialPagina(int primeiroResultado, int quantidadeResultados, FolhaHistoricoSalarialDTO folhaHistoricoSalarial)
        {
            try
            {
                IList<FolhaHistoricoSalarialDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaHistoricoSalarialDTO> DAL = new NHibernateDAL<FolhaHistoricoSalarialDTO>(session);
                    resultado = DAL.selectPagina<FolhaHistoricoSalarialDTO>(primeiroResultado, quantidadeResultados, folhaHistoricoSalarial);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region EmpresaTransporteItinerario
        public IList<EmpresaTransporteItinerarioDTO> selectEmpresaTransporteItinerario(EmpresaTransporteItinerarioDTO empresaTransporteItinerario)
        {
            try
            {
                IList<EmpresaTransporteItinerarioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<EmpresaTransporteItinerarioDTO> DAL = new NHibernateDAL<EmpresaTransporteItinerarioDTO>(session);
                    resultado = DAL.select(empresaTransporteItinerario);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<EmpresaTransporteItinerarioDTO> selectEmpresaTransporteItinerarioPagina(int primeiroResultado, int quantidadeResultados, EmpresaTransporteItinerarioDTO empresaTransporteItinerario)
        {
            try
            {
                IList<EmpresaTransporteItinerarioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<EmpresaTransporteItinerarioDTO> DAL = new NHibernateDAL<EmpresaTransporteItinerarioDTO>(session);
                    resultado = DAL.selectPagina<EmpresaTransporteItinerarioDTO>(primeiroResultado, quantidadeResultados, empresaTransporteItinerario);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaValeTransporte
        public int deleteFolhaValeTransporte(FolhaValeTransporteDTO folhaValeTransporte)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaValeTransporteDTO> DAL = new NHibernateDAL<FolhaValeTransporteDTO>(session);
                    DAL.delete(folhaValeTransporte);
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


        public FolhaValeTransporteDTO salvarAtualizarFolhaValeTransporte(FolhaValeTransporteDTO folhaValeTransporte)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaValeTransporteDTO> DAL = new NHibernateDAL<FolhaValeTransporteDTO>(session);
                    DAL.saveOrUpdate(folhaValeTransporte);
                    session.Flush();
                }
                return folhaValeTransporte;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaValeTransporteDTO> selectFolhaValeTransporte(FolhaValeTransporteDTO folhaValeTransporte)
        {
            try
            {
                IList<FolhaValeTransporteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaValeTransporteDTO> DAL = new NHibernateDAL<FolhaValeTransporteDTO>(session);
                    resultado = DAL.select(folhaValeTransporte);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaValeTransporteDTO> selectFolhaValeTransportePagina(int primeiroResultado, int quantidadeResultados, FolhaValeTransporteDTO folhaValeTransporte)
        {
            try
            {
                IList<FolhaValeTransporteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaValeTransporteDTO> DAL = new NHibernateDAL<FolhaValeTransporteDTO>(session);
                    resultado = DAL.selectPagina<FolhaValeTransporteDTO>(primeiroResultado, quantidadeResultados, folhaValeTransporte);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaRescisao
        public int deleteFolhaRescisao(FolhaRescisaoDTO folhaRescisao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaRescisaoDTO> DAL = new NHibernateDAL<FolhaRescisaoDTO>(session);
                    DAL.delete(folhaRescisao);
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


        public FolhaRescisaoDTO salvarAtualizarFolhaRescisao(FolhaRescisaoDTO folhaRescisao)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaRescisaoDTO> DAL = new NHibernateDAL<FolhaRescisaoDTO>(session);
                    DAL.saveOrUpdate(folhaRescisao);
                    session.Flush();
                }
                return folhaRescisao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaRescisaoDTO> selectFolhaRescisao(FolhaRescisaoDTO folhaRescisao)
        {
            try
            {
                IList<FolhaRescisaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaRescisaoDTO> DAL = new NHibernateDAL<FolhaRescisaoDTO>(session);
                    resultado = DAL.select(folhaRescisao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaRescisaoDTO> selectFolhaRescisaoPagina(int primeiroResultado, int quantidadeResultados, FolhaRescisaoDTO folhaRescisao)
        {
            try
            {
                IList<FolhaRescisaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaRescisaoDTO> DAL = new NHibernateDAL<FolhaRescisaoDTO>(session);
                    resultado = DAL.selectPagina<FolhaRescisaoDTO>(primeiroResultado, quantidadeResultados, folhaRescisao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaInssServico
        public int deleteFolhaInssServico(FolhaInssServicoDTO folhaInssServico)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaInssServicoDTO> DAL = new NHibernateDAL<FolhaInssServicoDTO>(session);
                    DAL.delete(folhaInssServico);
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


        public FolhaInssServicoDTO salvarAtualizarFolhaInssServico(FolhaInssServicoDTO folhaInssServico)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaInssServicoDTO> DAL = new NHibernateDAL<FolhaInssServicoDTO>(session);
                    DAL.saveOrUpdate(folhaInssServico);
                    session.Flush();
                }
                return folhaInssServico;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaInssServicoDTO> selectFolhaInssServico(FolhaInssServicoDTO folhaInssServico)
        {
            try
            {
                IList<FolhaInssServicoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaInssServicoDTO> DAL = new NHibernateDAL<FolhaInssServicoDTO>(session);
                    resultado = DAL.select(folhaInssServico);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaInssServicoDTO> selectFolhaInssServicoPagina(int primeiroResultado, int quantidadeResultados, FolhaInssServicoDTO folhaInssServico)
        {
            try
            {
                IList<FolhaInssServicoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FolhaInssServicoDTO> DAL = new NHibernateDAL<FolhaInssServicoDTO>(session);
                    resultado = DAL.selectPagina<FolhaInssServicoDTO>(primeiroResultado, quantidadeResultados, folhaInssServico);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaLancamentoCabecalho
        public int deleteFolhaLancamentoCabecalho(FolhaLancamentoCabecalhoDTO FolhaLancamentoCabecalho)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaLancamentoDAL DAL = new FolhaLancamentoDAL(session);
                    DAL.delete(FolhaLancamentoCabecalho);
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


        public FolhaLancamentoCabecalhoDTO salvarAtualizarFolhaLancamentoCabecalho(FolhaLancamentoCabecalhoDTO FolhaLancamentoCabecalho)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaLancamentoDAL DAL = new FolhaLancamentoDAL(session);
                    DAL.saveOrUpdate(FolhaLancamentoCabecalho);
                    session.Flush();
                }
                return FolhaLancamentoCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaLancamentoCabecalhoDTO> selectFolhaLancamentoCabecalho(FolhaLancamentoCabecalhoDTO FolhaLancamentoCabecalho)
        {
            try
            {
                IList<FolhaLancamentoCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaLancamentoDAL DAL = new FolhaLancamentoDAL(session);
                    resultado = DAL.select(FolhaLancamentoCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaLancamentoCabecalhoDTO> selectFolhaLancamentoCabecalhoPagina(int primeiroResultado, int quantidadeResultados, FolhaLancamentoCabecalhoDTO FolhaLancamentoCabecalho)
        {
            try
            {
                IList<FolhaLancamentoCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaLancamentoDAL DAL = new FolhaLancamentoDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, FolhaLancamentoCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaInss
        public int deleteFolhaInss(FolhaInssDTO FolhaInss)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaInssDAL DAL = new FolhaInssDAL(session);
                    DAL.delete(FolhaInss);
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


        public FolhaInssDTO salvarAtualizarFolhaInss(FolhaInssDTO FolhaInss)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaInssDAL DAL = new FolhaInssDAL(session);
                    DAL.saveOrUpdate(FolhaInss);
                    session.Flush();
                }
                return FolhaInss;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaInssDTO> selectFolhaInss(FolhaInssDTO FolhaInss)
        {
            try
            {
                IList<FolhaInssDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaInssDAL DAL = new FolhaInssDAL(session);
                    resultado = DAL.select(FolhaInss);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaInssDTO> selectFolhaInssPagina(int primeiroResultado, int quantidadeResultados, FolhaInssDTO FolhaInss)
        {
            try
            {
                IList<FolhaInssDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaInssDAL DAL = new FolhaInssDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, FolhaInss);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FolhaPpp
        public int deleteFolhaPpp(FolhaPppDTO FolhaPpp)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaPppDAL DAL = new FolhaPppDAL(session);
                    DAL.delete(FolhaPpp);
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


        public FolhaPppDTO salvarAtualizarFolhaPpp(FolhaPppDTO FolhaPpp)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaPppDAL DAL = new FolhaPppDAL(session);
                    DAL.saveOrUpdate(FolhaPpp);
                    session.Flush();
                }
                return FolhaPpp;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaPppDTO> selectFolhaPpp(FolhaPppDTO FolhaPpp)
        {
            try
            {
                IList<FolhaPppDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaPppDAL DAL = new FolhaPppDAL(session);
                    resultado = DAL.select(FolhaPpp);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FolhaPppDTO> selectFolhaPppPagina(int primeiroResultado, int quantidadeResultados, FolhaPppDTO FolhaPpp)
        {
            try
            {
                IList<FolhaPppDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FolhaPppDAL DAL = new FolhaPppDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, FolhaPpp);
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

        #region OperadoraPlanoSaude
        public IList<OperadoraPlanoSaudeDTO> selectOperadoraPlanoSaude(OperadoraPlanoSaudeDTO operadoraPlanoSaude)
        {
            try
            {
                IList<OperadoraPlanoSaudeDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<OperadoraPlanoSaudeDTO> DAL = new NHibernateDAL<OperadoraPlanoSaudeDTO>(session);
                    resultado = DAL.select(operadoraPlanoSaude);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OperadoraPlanoSaudeDTO> selectOperadoraPlanoSaudePagina(int primeiroResultado, int quantidadeResultados, OperadoraPlanoSaudeDTO operadoraPlanoSaude)
        {
            try
            {
                IList<OperadoraPlanoSaudeDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<OperadoraPlanoSaudeDTO> DAL = new NHibernateDAL<OperadoraPlanoSaudeDTO>(session);
                    resultado = DAL.selectPagina<OperadoraPlanoSaudeDTO>(primeiroResultado, quantidadeResultados, operadoraPlanoSaude);
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


        public EmpresaDTO selectEmpresaId(int id)
        {
            try
            {
                EmpresaDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<EmpresaDTO> empresaDAL = new NHibernateDAL<EmpresaDTO>(session);
                    resultado = empresaDAL.selectId<EmpresaDTO>(id);


                    NHibernateDAL<EnderecoDTO> endDAL = new NHibernateDAL<EnderecoDTO>(session);
                    IList<EnderecoDTO> listaEnd = endDAL.select(new EnderecoDTO { idEmpresa = resultado.Id, principal = "S" });
                    if (listaEnd.Count > 0)
                        resultado.endereco = listaEnd.First();

                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        #endregion

    }
}
