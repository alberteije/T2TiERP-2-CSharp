using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ContabilidadeService.Model;
using NHibernate;
using ContabilidadeService.NHibernate;

namespace ContabilidadeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IServicoContabilidade
    {

        #region RegistroCartorio
        public int deleteRegistroCartorio(RegistroCartorioDTO registroCartorio)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<RegistroCartorioDTO> DAL = new NHibernateDAL<RegistroCartorioDTO>(session);
                    DAL.delete(registroCartorio);
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


        public RegistroCartorioDTO salvarAtualizarRegistroCartorio(RegistroCartorioDTO registroCartorio)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<RegistroCartorioDTO> DAL = new NHibernateDAL<RegistroCartorioDTO>(session);
                    DAL.saveOrUpdate(registroCartorio);
                    session.Flush();
                }
                return registroCartorio;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<RegistroCartorioDTO> selectRegistroCartorio(RegistroCartorioDTO registroCartorio)
        {
            try
            {
                IList<RegistroCartorioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<RegistroCartorioDTO> DAL = new NHibernateDAL<RegistroCartorioDTO>(session);
                    resultado = DAL.select(registroCartorio);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<RegistroCartorioDTO> selectRegistroCartorioPagina(int primeiroResultado, int quantidadeResultados, RegistroCartorioDTO registroCartorio)
        {
            try
            {
                IList<RegistroCartorioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<RegistroCartorioDTO> DAL = new NHibernateDAL<RegistroCartorioDTO>(session);
                    resultado = DAL.selectPagina<RegistroCartorioDTO>(primeiroResultado, quantidadeResultados, registroCartorio);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        #endregion 
    
        #region ContabilParametros
        public int deleteContabilParametros(ContabilParametrosDTO contabilParametros)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilParametrosDTO> DAL = new NHibernateDAL<ContabilParametrosDTO>(session);
                    DAL.delete(contabilParametros);
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


        public ContabilParametrosDTO salvarAtualizarContabilParametros(ContabilParametrosDTO contabilParametros)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilParametrosDTO> DAL = new NHibernateDAL<ContabilParametrosDTO>(session);
                    DAL.saveOrUpdate(contabilParametros);
                    session.Flush();
                }
                return contabilParametros;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilParametrosDTO> selectContabilParametros(ContabilParametrosDTO contabilParametros)
        {
            try
            {
                IList<ContabilParametrosDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilParametrosDTO> DAL = new NHibernateDAL<ContabilParametrosDTO>(session);
                    resultado = DAL.select(contabilParametros);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilParametrosDTO> selectContabilParametrosPagina(int primeiroResultado, int quantidadeResultados, ContabilParametrosDTO contabilParametros)
        {
            try
            {
                IList<ContabilParametrosDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilParametrosDTO> DAL = new NHibernateDAL<ContabilParametrosDTO>(session);
                    resultado = DAL.selectPagina<ContabilParametrosDTO>(primeiroResultado, quantidadeResultados, contabilParametros);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilIndice
        public int deleteContabilIndice(ContabilIndiceDTO contabilIndice)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilIndiceDAL DAL = new ContabilIndiceDAL(session);
                    DAL.delete(contabilIndice);
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


        public ContabilIndiceDTO salvarAtualizarContabilIndice(ContabilIndiceDTO contabilIndice)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilIndiceDAL DAL = new ContabilIndiceDAL(session);
                    DAL.saveOrUpdate(contabilIndice);
                    session.Flush();
                }
                return contabilIndice;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilIndiceDTO> selectContabilIndice(ContabilIndiceDTO contabilIndice)
        {
            try
            {
                IList<ContabilIndiceDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilIndiceDAL DAL = new ContabilIndiceDAL(session);
                    resultado = DAL.select(contabilIndice);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilIndiceDTO> selectContabilIndicePagina(int primeiroResultado, int quantidadeResultados, ContabilIndiceDTO contabilIndice)
        {
            try
            {
                IList<ContabilIndiceDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilIndiceDAL DAL = new ContabilIndiceDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, contabilIndice);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilHistorico
        public int deleteContabilHistorico(ContabilHistoricoDTO contabilHistorico)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilHistoricoDTO> DAL = new NHibernateDAL<ContabilHistoricoDTO>(session);
                    DAL.delete(contabilHistorico);
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


        public ContabilHistoricoDTO salvarAtualizarContabilHistorico(ContabilHistoricoDTO contabilHistorico)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilHistoricoDTO> DAL = new NHibernateDAL<ContabilHistoricoDTO>(session);
                    DAL.saveOrUpdate(contabilHistorico);
                    session.Flush();
                }
                return contabilHistorico;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilHistoricoDTO> selectContabilHistorico(ContabilHistoricoDTO contabilHistorico)
        {
            try
            {
                IList<ContabilHistoricoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilHistoricoDTO> DAL = new NHibernateDAL<ContabilHistoricoDTO>(session);
                    resultado = DAL.select(contabilHistorico);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilHistoricoDTO> selectContabilHistoricoPagina(int primeiroResultado, int quantidadeResultados, ContabilHistoricoDTO contabilHistorico)
        {
            try
            {
                IList<ContabilHistoricoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilHistoricoDTO> DAL = new NHibernateDAL<ContabilHistoricoDTO>(session);
                    resultado = DAL.selectPagina<ContabilHistoricoDTO>(primeiroResultado, quantidadeResultados, contabilHistorico);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region AidfAimdf
        public int deleteAidfAimdf(AidfAimdfDTO aidfAimdf)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<AidfAimdfDTO> DAL = new NHibernateDAL<AidfAimdfDTO>(session);
                    DAL.delete(aidfAimdf);
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


        public AidfAimdfDTO salvarAtualizarAidfAimdf(AidfAimdfDTO aidfAimdf)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<AidfAimdfDTO> DAL = new NHibernateDAL<AidfAimdfDTO>(session);
                    DAL.saveOrUpdate(aidfAimdf);
                    session.Flush();
                }
                return aidfAimdf;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<AidfAimdfDTO> selectAidfAimdf(AidfAimdfDTO aidfAimdf)
        {
            try
            {
                IList<AidfAimdfDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<AidfAimdfDTO> DAL = new NHibernateDAL<AidfAimdfDTO>(session);
                    resultado = DAL.select(aidfAimdf);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<AidfAimdfDTO> selectAidfAimdfPagina(int primeiroResultado, int quantidadeResultados, AidfAimdfDTO aidfAimdf)
        {
            try
            {
                IList<AidfAimdfDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<AidfAimdfDTO> DAL = new NHibernateDAL<AidfAimdfDTO>(session);
                    resultado = DAL.selectPagina<AidfAimdfDTO>(primeiroResultado, quantidadeResultados, aidfAimdf);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Fap
        public int deleteFap(FapDTO fap)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FapDTO> DAL = new NHibernateDAL<FapDTO>(session);
                    DAL.delete(fap);
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


        public FapDTO salvarAtualizarFap(FapDTO fap)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FapDTO> DAL = new NHibernateDAL<FapDTO>(session);
                    DAL.saveOrUpdate(fap);
                    session.Flush();
                }
                return fap;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FapDTO> selectFap(FapDTO fap)
        {
            try
            {
                IList<FapDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FapDTO> DAL = new NHibernateDAL<FapDTO>(session);
                    resultado = DAL.select(fap);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FapDTO> selectFapPagina(int primeiroResultado, int quantidadeResultados, FapDTO fap)
        {
            try
            {
                IList<FapDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FapDTO> DAL = new NHibernateDAL<FapDTO>(session);
                    resultado = DAL.selectPagina<FapDTO>(primeiroResultado, quantidadeResultados, fap);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PlanoConta
        public int deletePlanoConta(PlanoContaDTO planoConta)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoContaDTO> DAL = new NHibernateDAL<PlanoContaDTO>(session);
                    DAL.delete(planoConta);
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


        public PlanoContaDTO salvarAtualizarPlanoConta(PlanoContaDTO planoConta)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoContaDTO> DAL = new NHibernateDAL<PlanoContaDTO>(session);
                    DAL.saveOrUpdate(planoConta);
                    session.Flush();
                }
                return planoConta;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PlanoContaDTO> selectPlanoConta(PlanoContaDTO planoConta)
        {
            try
            {
                IList<PlanoContaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoContaDTO> DAL = new NHibernateDAL<PlanoContaDTO>(session);
                    resultado = DAL.select(planoConta);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PlanoContaDTO> selectPlanoContaPagina(int primeiroResultado, int quantidadeResultados, PlanoContaDTO planoConta)
        {
            try
            {
                IList<PlanoContaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoContaDTO> DAL = new NHibernateDAL<PlanoContaDTO>(session);
                    resultado = DAL.selectPagina<PlanoContaDTO>(primeiroResultado, quantidadeResultados, planoConta);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PlanoContaRefSped
        public int deletePlanoContaRefSped(PlanoContaRefSpedDTO planoContaRefSped)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoContaRefSpedDTO> DAL = new NHibernateDAL<PlanoContaRefSpedDTO>(session);
                    DAL.delete(planoContaRefSped);
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


        public PlanoContaRefSpedDTO salvarAtualizarPlanoContaRefSped(PlanoContaRefSpedDTO planoContaRefSped)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoContaRefSpedDTO> DAL = new NHibernateDAL<PlanoContaRefSpedDTO>(session);
                    DAL.saveOrUpdate(planoContaRefSped);
                    session.Flush();
                }
                return planoContaRefSped;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PlanoContaRefSpedDTO> selectPlanoContaRefSped(PlanoContaRefSpedDTO planoContaRefSped)
        {
            try
            {
                IList<PlanoContaRefSpedDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoContaRefSpedDTO> DAL = new NHibernateDAL<PlanoContaRefSpedDTO>(session);
                    resultado = DAL.select(planoContaRefSped);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PlanoContaRefSpedDTO> selectPlanoContaRefSpedPagina(int primeiroResultado, int quantidadeResultados, PlanoContaRefSpedDTO planoContaRefSped)
        {
            try
            {
                IList<PlanoContaRefSpedDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoContaRefSpedDTO> DAL = new NHibernateDAL<PlanoContaRefSpedDTO>(session);
                    resultado = DAL.selectPagina<PlanoContaRefSpedDTO>(primeiroResultado, quantidadeResultados, planoContaRefSped);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilConta
        public int deleteContabilConta(ContabilContaDTO contabilConta)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilContaDTO> DAL = new NHibernateDAL<ContabilContaDTO>(session);
                    DAL.delete(contabilConta);
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


        public ContabilContaDTO salvarAtualizarContabilConta(ContabilContaDTO contabilConta)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilContaDTO> DAL = new NHibernateDAL<ContabilContaDTO>(session);
                    DAL.saveOrUpdate(contabilConta);
                    session.Flush();
                }
                return contabilConta;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilContaDTO> selectContabilConta(ContabilContaDTO contabilConta)
        {
            try
            {
                IList<ContabilContaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilContaDTO> DAL = new NHibernateDAL<ContabilContaDTO>(session);
                    resultado = DAL.select(contabilConta);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilContaDTO> selectContabilContaPagina(int primeiroResultado, int quantidadeResultados, ContabilContaDTO contabilConta)
        {
            try
            {
                IList<ContabilContaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilContaDTO> DAL = new NHibernateDAL<ContabilContaDTO>(session);
                    resultado = DAL.selectPagina<ContabilContaDTO>(primeiroResultado, quantidadeResultados, contabilConta);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilFechamento
        public int deleteContabilFechamento(ContabilFechamentoDTO contabilFechamento)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilFechamentoDTO> DAL = new NHibernateDAL<ContabilFechamentoDTO>(session);
                    DAL.delete(contabilFechamento);
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


        public ContabilFechamentoDTO salvarAtualizarContabilFechamento(ContabilFechamentoDTO contabilFechamento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilFechamentoDTO> DAL = new NHibernateDAL<ContabilFechamentoDTO>(session);
                    DAL.saveOrUpdate(contabilFechamento);
                    session.Flush();
                }
                return contabilFechamento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilFechamentoDTO> selectContabilFechamento(ContabilFechamentoDTO contabilFechamento)
        {
            try
            {
                IList<ContabilFechamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilFechamentoDTO> DAL = new NHibernateDAL<ContabilFechamentoDTO>(session);
                    resultado = DAL.select(contabilFechamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilFechamentoDTO> selectContabilFechamentoPagina(int primeiroResultado, int quantidadeResultados, ContabilFechamentoDTO contabilFechamento)
        {
            try
            {
                IList<ContabilFechamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilFechamentoDTO> DAL = new NHibernateDAL<ContabilFechamentoDTO>(session);
                    resultado = DAL.selectPagina<ContabilFechamentoDTO>(primeiroResultado, quantidadeResultados, contabilFechamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilLancamentoPadrao
        public int deleteContabilLancamentoPadrao(ContabilLancamentoPadraoDTO contabilLancamentoPadrao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLancamentoPadraoDTO> DAL = new NHibernateDAL<ContabilLancamentoPadraoDTO>(session);
                    DAL.delete(contabilLancamentoPadrao);
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


        public ContabilLancamentoPadraoDTO salvarAtualizarContabilLancamentoPadrao(ContabilLancamentoPadraoDTO contabilLancamentoPadrao)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLancamentoPadraoDTO> DAL = new NHibernateDAL<ContabilLancamentoPadraoDTO>(session);
                    DAL.saveOrUpdate(contabilLancamentoPadrao);
                    session.Flush();
                }
                return contabilLancamentoPadrao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilLancamentoPadraoDTO> selectContabilLancamentoPadrao(ContabilLancamentoPadraoDTO contabilLancamentoPadrao)
        {
            try
            {
                IList<ContabilLancamentoPadraoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLancamentoPadraoDTO> DAL = new NHibernateDAL<ContabilLancamentoPadraoDTO>(session);
                    resultado = DAL.select(contabilLancamentoPadrao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilLancamentoPadraoDTO> selectContabilLancamentoPadraoPagina(int primeiroResultado, int quantidadeResultados, ContabilLancamentoPadraoDTO contabilLancamentoPadrao)
        {
            try
            {
                IList<ContabilLancamentoPadraoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLancamentoPadraoDTO> DAL = new NHibernateDAL<ContabilLancamentoPadraoDTO>(session);
                    resultado = DAL.selectPagina<ContabilLancamentoPadraoDTO>(primeiroResultado, quantidadeResultados, contabilLancamentoPadrao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilLote
        public int deleteContabilLote(ContabilLoteDTO contabilLote)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLoteDTO> DAL = new NHibernateDAL<ContabilLoteDTO>(session);
                    DAL.delete(contabilLote);
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


        public ContabilLoteDTO salvarAtualizarContabilLote(ContabilLoteDTO contabilLote)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLoteDTO> DAL = new NHibernateDAL<ContabilLoteDTO>(session);
                    DAL.saveOrUpdate(contabilLote);
                    session.Flush();
                }
                return contabilLote;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilLoteDTO> selectContabilLote(ContabilLoteDTO contabilLote)
        {
            try
            {
                IList<ContabilLoteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLoteDTO> DAL = new NHibernateDAL<ContabilLoteDTO>(session);
                    resultado = DAL.select(contabilLote);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilLoteDTO> selectContabilLotePagina(int primeiroResultado, int quantidadeResultados, ContabilLoteDTO contabilLote)
        {
            try
            {
                IList<ContabilLoteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLoteDTO> DAL = new NHibernateDAL<ContabilLoteDTO>(session);
                    resultado = DAL.selectPagina<ContabilLoteDTO>(primeiroResultado, quantidadeResultados, contabilLote);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilLancamentoOrcado
        public int deleteContabilLancamentoOrcado(ContabilLancamentoOrcadoDTO contabilLancamentoOrcado)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLancamentoOrcadoDTO> DAL = new NHibernateDAL<ContabilLancamentoOrcadoDTO>(session);
                    DAL.delete(contabilLancamentoOrcado);
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


        public ContabilLancamentoOrcadoDTO salvarAtualizarContabilLancamentoOrcado(ContabilLancamentoOrcadoDTO contabilLancamentoOrcado)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLancamentoOrcadoDTO> DAL = new NHibernateDAL<ContabilLancamentoOrcadoDTO>(session);
                    DAL.saveOrUpdate(contabilLancamentoOrcado);
                    session.Flush();
                }
                return contabilLancamentoOrcado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilLancamentoOrcadoDTO> selectContabilLancamentoOrcado(ContabilLancamentoOrcadoDTO contabilLancamentoOrcado)
        {
            try
            {
                IList<ContabilLancamentoOrcadoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLancamentoOrcadoDTO> DAL = new NHibernateDAL<ContabilLancamentoOrcadoDTO>(session);
                    resultado = DAL.select(contabilLancamentoOrcado);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilLancamentoOrcadoDTO> selectContabilLancamentoOrcadoPagina(int primeiroResultado, int quantidadeResultados, ContabilLancamentoOrcadoDTO contabilLancamentoOrcado)
        {
            try
            {
                IList<ContabilLancamentoOrcadoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLancamentoOrcadoDTO> DAL = new NHibernateDAL<ContabilLancamentoOrcadoDTO>(session);
                    resultado = DAL.selectPagina<ContabilLancamentoOrcadoDTO>(primeiroResultado, quantidadeResultados, contabilLancamentoOrcado);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilLancamentoCabecalho
        public int deleteContabilLancamentoCabecalho(ContabilLancamentoCabecalhoDTO contabilLancamentoCabecalho)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilLancamentoDAL DAL = new ContabilLancamentoDAL(session);
                    DAL.delete(contabilLancamentoCabecalho);
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


        public ContabilLancamentoCabecalhoDTO salvarAtualizarContabilLancamentoCabecalho(ContabilLancamentoCabecalhoDTO contabilLancamentoCabecalho)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilLancamentoDAL DAL = new ContabilLancamentoDAL(session);
                    DAL.saveOrUpdate(contabilLancamentoCabecalho);
                    session.Flush();
                }
                return contabilLancamentoCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilLancamentoCabecalhoDTO> selectContabilLancamentoCabecalho(ContabilLancamentoCabecalhoDTO contabilLancamentoCabecalho)
        {
            try
            {
                IList<ContabilLancamentoCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilLancamentoDAL DAL = new ContabilLancamentoDAL(session);
                    resultado = DAL.select(contabilLancamentoCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilLancamentoCabecalhoDTO> selectContabilLancamentoCabecalhoPagina(int primeiroResultado, int quantidadeResultados, ContabilLancamentoCabecalhoDTO contabilLancamentoCabecalho)
        {
            try
            {
                IList<ContabilLancamentoCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilLancamentoDAL DAL = new ContabilLancamentoDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, contabilLancamentoCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilDreCabecalho
        public int deleteContabilDreCabecalho(ContabilDreCabecalhoDTO contabilDreCabecalho)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilDreDAL DAL = new ContabilDreDAL(session);
                    DAL.delete(contabilDreCabecalho);
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


        public ContabilDreCabecalhoDTO salvarAtualizarContabilDreCabecalho(ContabilDreCabecalhoDTO contabilDreCabecalho)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilDreDAL DAL = new ContabilDreDAL(session);
                    DAL.saveOrUpdate(contabilDreCabecalho);
                    session.Flush();
                }
                return contabilDreCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilDreCabecalhoDTO> selectContabilDreCabecalho(ContabilDreCabecalhoDTO contabilDreCabecalho)
        {
            try
            {
                IList<ContabilDreCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilDreDAL DAL = new ContabilDreDAL(session);
                    resultado = DAL.select(contabilDreCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilDreCabecalhoDTO> selectContabilDreCabecalhoPagina(int primeiroResultado, int quantidadeResultados, ContabilDreCabecalhoDTO contabilDreCabecalho)
        {
            try
            {
                IList<ContabilDreCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilDreDAL DAL = new ContabilDreDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, contabilDreCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilEncerramentoExeCab
        public int deleteContabilEncerramentoExeCab(ContabilEncerramentoExeCabDTO contabilEncerramentoExeCab)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilEncerramentoExercicioDAL DAL = new ContabilEncerramentoExercicioDAL(session);
                    DAL.delete(contabilEncerramentoExeCab);
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


        public ContabilEncerramentoExeCabDTO salvarAtualizarContabilEncerramentoExeCab(ContabilEncerramentoExeCabDTO contabilEncerramentoExeCab)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilEncerramentoExercicioDAL DAL = new ContabilEncerramentoExercicioDAL(session);
                    DAL.saveOrUpdate(contabilEncerramentoExeCab);
                    session.Flush();
                }
                return contabilEncerramentoExeCab;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilEncerramentoExeCabDTO> selectContabilEncerramentoExeCab(ContabilEncerramentoExeCabDTO contabilEncerramentoExeCab)
        {
            try
            {
                IList<ContabilEncerramentoExeCabDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilEncerramentoExercicioDAL DAL = new ContabilEncerramentoExercicioDAL(session);
                    resultado = DAL.select(contabilEncerramentoExeCab);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilEncerramentoExeCabDTO> selectContabilEncerramentoExeCabPagina(int primeiroResultado, int quantidadeResultados, ContabilEncerramentoExeCabDTO contabilEncerramentoExeCab)
        {
            try
            {
                IList<ContabilEncerramentoExeCabDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilEncerramentoExercicioDAL DAL = new ContabilEncerramentoExercicioDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, contabilEncerramentoExeCab);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion

        #region ContabilLivro
        public int deleteContabilLivro(ContabilLivroDTO ContabilLivro)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilLivroDAL DAL = new ContabilLivroDAL(session);
                    DAL.delete(ContabilLivro);
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


        public ContabilLivroDTO salvarAtualizarContabilLivro(ContabilLivroDTO ContabilLivro)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilLivroDAL DAL = new ContabilLivroDAL(session);
                    DAL.saveOrUpdate(ContabilLivro);
                    session.Flush();
                }
                return ContabilLivro;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilLivroDTO> selectContabilLivro(ContabilLivroDTO ContabilLivro)
        {
            try
            {
                IList<ContabilLivroDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilLivroDAL DAL = new ContabilLivroDAL(session);
                    resultado = DAL.select(ContabilLivro);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilLivroDTO> selectContabilLivroPagina(int primeiroResultado, int quantidadeResultados, ContabilLivroDTO ContabilLivro)
        {
            try
            {
                IList<ContabilLivroDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ContabilLivroDAL DAL = new ContabilLivroDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, ContabilLivro);
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

    }
}
