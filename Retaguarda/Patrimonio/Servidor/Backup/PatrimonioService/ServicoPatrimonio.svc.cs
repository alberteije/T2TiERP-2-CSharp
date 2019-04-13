using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PatrimonioService.Model;
using NHibernate;
using PatrimonioService.NHibernate;

namespace PatrimonioService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ServicoPatrimonio : IServicoPatrimonio
    {
        #region PatrimTaxaDepreciacao
        public int deletePatrimTaxaDepreciacao(PatrimTaxaDepreciacaoDTO patrimTaxaDepreciacao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTaxaDepreciacaoDTO> DAL = new NHibernateDAL<PatrimTaxaDepreciacaoDTO>(session);
                    DAL.delete(patrimTaxaDepreciacao);
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


        public PatrimTaxaDepreciacaoDTO salvarAtualizarPatrimTaxaDepreciacao(PatrimTaxaDepreciacaoDTO patrimTaxaDepreciacao)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTaxaDepreciacaoDTO> DAL = new NHibernateDAL<PatrimTaxaDepreciacaoDTO>(session);
                    DAL.saveOrUpdate(patrimTaxaDepreciacao);
                    session.Flush();
                }
                return patrimTaxaDepreciacao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimTaxaDepreciacaoDTO> selectPatrimTaxaDepreciacao(PatrimTaxaDepreciacaoDTO patrimTaxaDepreciacao)
        {
            try
            {
                IList<PatrimTaxaDepreciacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTaxaDepreciacaoDTO> DAL = new NHibernateDAL<PatrimTaxaDepreciacaoDTO>(session);
                    resultado = DAL.select(patrimTaxaDepreciacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimTaxaDepreciacaoDTO> selectPatrimTaxaDepreciacaoPagina(int primeiroResultado, int quantidadeResultados, PatrimTaxaDepreciacaoDTO patrimTaxaDepreciacao)
        {
            try
            {
                IList<PatrimTaxaDepreciacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTaxaDepreciacaoDTO> DAL = new NHibernateDAL<PatrimTaxaDepreciacaoDTO>(session);
                    resultado = DAL.selectPagina<PatrimTaxaDepreciacaoDTO>(primeiroResultado, quantidadeResultados, patrimTaxaDepreciacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PatrimIndiceAtualizacao
        public int deletePatrimIndiceAtualizacao(PatrimIndiceAtualizacaoDTO patrimIndiceAtualizacao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimIndiceAtualizacaoDTO> DAL = new NHibernateDAL<PatrimIndiceAtualizacaoDTO>(session);
                    DAL.delete(patrimIndiceAtualizacao);
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


        public PatrimIndiceAtualizacaoDTO salvarAtualizarPatrimIndiceAtualizacao(PatrimIndiceAtualizacaoDTO patrimIndiceAtualizacao)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimIndiceAtualizacaoDTO> DAL = new NHibernateDAL<PatrimIndiceAtualizacaoDTO>(session);
                    DAL.saveOrUpdate(patrimIndiceAtualizacao);
                    session.Flush();
                }
                return patrimIndiceAtualizacao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimIndiceAtualizacaoDTO> selectPatrimIndiceAtualizacao(PatrimIndiceAtualizacaoDTO patrimIndiceAtualizacao)
        {
            try
            {
                IList<PatrimIndiceAtualizacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimIndiceAtualizacaoDTO> DAL = new NHibernateDAL<PatrimIndiceAtualizacaoDTO>(session);
                    resultado = DAL.select(patrimIndiceAtualizacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimIndiceAtualizacaoDTO> selectPatrimIndiceAtualizacaoPagina(int primeiroResultado, int quantidadeResultados, PatrimIndiceAtualizacaoDTO patrimIndiceAtualizacao)
        {
            try
            {
                IList<PatrimIndiceAtualizacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimIndiceAtualizacaoDTO> DAL = new NHibernateDAL<PatrimIndiceAtualizacaoDTO>(session);
                    resultado = DAL.selectPagina<PatrimIndiceAtualizacaoDTO>(primeiroResultado, quantidadeResultados, patrimIndiceAtualizacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PatrimTipoAquisicaoBem
        public int deletePatrimTipoAquisicaoBem(PatrimTipoAquisicaoBemDTO patrimTipoAquisicaoBem)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTipoAquisicaoBemDTO> DAL = new NHibernateDAL<PatrimTipoAquisicaoBemDTO>(session);
                    DAL.delete(patrimTipoAquisicaoBem);
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


        public PatrimTipoAquisicaoBemDTO salvarAtualizarPatrimTipoAquisicaoBem(PatrimTipoAquisicaoBemDTO patrimTipoAquisicaoBem)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTipoAquisicaoBemDTO> DAL = new NHibernateDAL<PatrimTipoAquisicaoBemDTO>(session);
                    DAL.saveOrUpdate(patrimTipoAquisicaoBem);
                    session.Flush();
                }
                return patrimTipoAquisicaoBem;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimTipoAquisicaoBemDTO> selectPatrimTipoAquisicaoBem(PatrimTipoAquisicaoBemDTO patrimTipoAquisicaoBem)
        {
            try
            {
                IList<PatrimTipoAquisicaoBemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTipoAquisicaoBemDTO> DAL = new NHibernateDAL<PatrimTipoAquisicaoBemDTO>(session);
                    resultado = DAL.select(patrimTipoAquisicaoBem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimTipoAquisicaoBemDTO> selectPatrimTipoAquisicaoBemPagina(int primeiroResultado, int quantidadeResultados, PatrimTipoAquisicaoBemDTO patrimTipoAquisicaoBem)
        {
            try
            {
                IList<PatrimTipoAquisicaoBemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTipoAquisicaoBemDTO> DAL = new NHibernateDAL<PatrimTipoAquisicaoBemDTO>(session);
                    resultado = DAL.selectPagina<PatrimTipoAquisicaoBemDTO>(primeiroResultado, quantidadeResultados, patrimTipoAquisicaoBem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PatrimTipoMovimentacao
        public int deletePatrimTipoMovimentacao(PatrimTipoMovimentacaoDTO patrimTipoMovimentacao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTipoMovimentacaoDTO> DAL = new NHibernateDAL<PatrimTipoMovimentacaoDTO>(session);
                    DAL.delete(patrimTipoMovimentacao);
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


        public PatrimTipoMovimentacaoDTO salvarAtualizarPatrimTipoMovimentacao(PatrimTipoMovimentacaoDTO patrimTipoMovimentacao)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTipoMovimentacaoDTO> DAL = new NHibernateDAL<PatrimTipoMovimentacaoDTO>(session);
                    DAL.saveOrUpdate(patrimTipoMovimentacao);
                    session.Flush();
                }
                return patrimTipoMovimentacao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimTipoMovimentacaoDTO> selectPatrimTipoMovimentacao(PatrimTipoMovimentacaoDTO patrimTipoMovimentacao)
        {
            try
            {
                IList<PatrimTipoMovimentacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTipoMovimentacaoDTO> DAL = new NHibernateDAL<PatrimTipoMovimentacaoDTO>(session);
                    resultado = DAL.select(patrimTipoMovimentacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimTipoMovimentacaoDTO> selectPatrimTipoMovimentacaoPagina(int primeiroResultado, int quantidadeResultados, PatrimTipoMovimentacaoDTO patrimTipoMovimentacao)
        {
            try
            {
                IList<PatrimTipoMovimentacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimTipoMovimentacaoDTO> DAL = new NHibernateDAL<PatrimTipoMovimentacaoDTO>(session);
                    resultado = DAL.selectPagina<PatrimTipoMovimentacaoDTO>(primeiroResultado, quantidadeResultados, patrimTipoMovimentacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PatrimEstadoConservacao
        public int deletePatrimEstadoConservacao(PatrimEstadoConservacaoDTO patrimEstadoConservacao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimEstadoConservacaoDTO> DAL = new NHibernateDAL<PatrimEstadoConservacaoDTO>(session);
                    DAL.delete(patrimEstadoConservacao);
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


        public PatrimEstadoConservacaoDTO salvarAtualizarPatrimEstadoConservacao(PatrimEstadoConservacaoDTO patrimEstadoConservacao)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimEstadoConservacaoDTO> DAL = new NHibernateDAL<PatrimEstadoConservacaoDTO>(session);
                    DAL.saveOrUpdate(patrimEstadoConservacao);
                    session.Flush();
                }
                return patrimEstadoConservacao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimEstadoConservacaoDTO> selectPatrimEstadoConservacao(PatrimEstadoConservacaoDTO patrimEstadoConservacao)
        {
            try
            {
                IList<PatrimEstadoConservacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimEstadoConservacaoDTO> DAL = new NHibernateDAL<PatrimEstadoConservacaoDTO>(session);
                    resultado = DAL.select(patrimEstadoConservacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimEstadoConservacaoDTO> selectPatrimEstadoConservacaoPagina(int primeiroResultado, int quantidadeResultados, PatrimEstadoConservacaoDTO patrimEstadoConservacao)
        {
            try
            {
                IList<PatrimEstadoConservacaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimEstadoConservacaoDTO> DAL = new NHibernateDAL<PatrimEstadoConservacaoDTO>(session);
                    resultado = DAL.selectPagina<PatrimEstadoConservacaoDTO>(primeiroResultado, quantidadeResultados, patrimEstadoConservacao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PatrimGrupoBem
        public int deletePatrimGrupoBem(PatrimGrupoBemDTO patrimGrupoBem)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimGrupoBemDTO> DAL = new NHibernateDAL<PatrimGrupoBemDTO>(session);
                    DAL.delete(patrimGrupoBem);
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


        public PatrimGrupoBemDTO salvarAtualizarPatrimGrupoBem(PatrimGrupoBemDTO patrimGrupoBem)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimGrupoBemDTO> DAL = new NHibernateDAL<PatrimGrupoBemDTO>(session);
                    DAL.saveOrUpdate(patrimGrupoBem);
                    session.Flush();
                }
                return patrimGrupoBem;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimGrupoBemDTO> selectPatrimGrupoBem(PatrimGrupoBemDTO patrimGrupoBem)
        {
            try
            {
                IList<PatrimGrupoBemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimGrupoBemDTO> DAL = new NHibernateDAL<PatrimGrupoBemDTO>(session);
                    resultado = DAL.select(patrimGrupoBem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimGrupoBemDTO> selectPatrimGrupoBemPagina(int primeiroResultado, int quantidadeResultados, PatrimGrupoBemDTO patrimGrupoBem)
        {
            try
            {
                IList<PatrimGrupoBemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimGrupoBemDTO> DAL = new NHibernateDAL<PatrimGrupoBemDTO>(session);
                    resultado = DAL.selectPagina<PatrimGrupoBemDTO>(primeiroResultado, quantidadeResultados, patrimGrupoBem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Seguradora
        public int deleteSeguradora(SeguradoraDTO seguradora)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<SeguradoraDTO> DAL = new NHibernateDAL<SeguradoraDTO>(session);
                    DAL.delete(seguradora);
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


        public SeguradoraDTO salvarAtualizarSeguradora(SeguradoraDTO seguradora)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<SeguradoraDTO> DAL = new NHibernateDAL<SeguradoraDTO>(session);
                    DAL.saveOrUpdate(seguradora);
                    session.Flush();
                }
                return seguradora;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<SeguradoraDTO> selectSeguradora(SeguradoraDTO seguradora)
        {
            try
            {
                IList<SeguradoraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<SeguradoraDTO> DAL = new NHibernateDAL<SeguradoraDTO>(session);
                    resultado = DAL.select(seguradora);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<SeguradoraDTO> selectSeguradoraPagina(int primeiroResultado, int quantidadeResultados, SeguradoraDTO seguradora)
        {
            try
            {
                IList<SeguradoraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<SeguradoraDTO> DAL = new NHibernateDAL<SeguradoraDTO>(session);
                    resultado = DAL.selectPagina<SeguradoraDTO>(primeiroResultado, quantidadeResultados, seguradora);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PatrimBem
        public int deletePatrimBem(PatrimBemDTO patrimBem)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    PatrimonioBemDAL DAL = new PatrimonioBemDAL(session);
                    DAL.delete(patrimBem);
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


        public PatrimBemDTO salvarAtualizarPatrimBem(PatrimBemDTO patrimBem)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    PatrimonioBemDAL DAL = new PatrimonioBemDAL(session);
                    DAL.saveOrUpdate(patrimBem);
                    session.Flush();
                }
                return patrimBem;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimBemDTO> selectPatrimBem(PatrimBemDTO patrimBem)
        {
            try
            {
                IList<PatrimBemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    PatrimonioBemDAL DAL = new PatrimonioBemDAL(session);
                    resultado = DAL.select(patrimBem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimBemDTO> selectPatrimBemPagina(int primeiroResultado, int quantidadeResultados, PatrimBemDTO patrimBem)
        {
            try
            {
                IList<PatrimBemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    PatrimonioBemDAL DAL = new PatrimonioBemDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, patrimBem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PatrimDepreciacaoBem
        public int deletePatrimDepreciacaoBem(PatrimDepreciacaoBemDTO patrimDepreciacaoBem)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimDepreciacaoBemDTO> DAL = new NHibernateDAL<PatrimDepreciacaoBemDTO>(session);
                    DAL.delete(patrimDepreciacaoBem);
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


        public PatrimDepreciacaoBemDTO salvarAtualizarPatrimDepreciacaoBem(PatrimDepreciacaoBemDTO patrimDepreciacaoBem)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimDepreciacaoBemDTO> DAL = new NHibernateDAL<PatrimDepreciacaoBemDTO>(session);
                    DAL.saveOrUpdate(patrimDepreciacaoBem);
                    session.Flush();
                }
                return patrimDepreciacaoBem;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimDepreciacaoBemDTO> selectPatrimDepreciacaoBem(PatrimDepreciacaoBemDTO patrimDepreciacaoBem)
        {
            try
            {
                IList<PatrimDepreciacaoBemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimDepreciacaoBemDTO> DAL = new NHibernateDAL<PatrimDepreciacaoBemDTO>(session);
                    resultado = DAL.select(patrimDepreciacaoBem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimDepreciacaoBemDTO> selectPatrimDepreciacaoBemPagina(int primeiroResultado, int quantidadeResultados, PatrimDepreciacaoBemDTO patrimDepreciacaoBem)
        {
            try
            {
                IList<PatrimDepreciacaoBemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimDepreciacaoBemDTO> DAL = new NHibernateDAL<PatrimDepreciacaoBemDTO>(session);
                    resultado = DAL.selectPagina<PatrimDepreciacaoBemDTO>(primeiroResultado, quantidadeResultados, patrimDepreciacaoBem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PatrimMovimentacaoBem
        public int deletePatrimMovimentacaoBem(PatrimMovimentacaoBemDTO patrimMovimentacaoBem)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimMovimentacaoBemDTO> DAL = new NHibernateDAL<PatrimMovimentacaoBemDTO>(session);
                    DAL.delete(patrimMovimentacaoBem);
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


        public PatrimMovimentacaoBemDTO salvarAtualizarPatrimMovimentacaoBem(PatrimMovimentacaoBemDTO patrimMovimentacaoBem)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimMovimentacaoBemDTO> DAL = new NHibernateDAL<PatrimMovimentacaoBemDTO>(session);
                    DAL.saveOrUpdate(patrimMovimentacaoBem);
                    session.Flush();
                }
                return patrimMovimentacaoBem;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimMovimentacaoBemDTO> selectPatrimMovimentacaoBem(PatrimMovimentacaoBemDTO patrimMovimentacaoBem)
        {
            try
            {
                IList<PatrimMovimentacaoBemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimMovimentacaoBemDTO> DAL = new NHibernateDAL<PatrimMovimentacaoBemDTO>(session);
                    resultado = DAL.select(patrimMovimentacaoBem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimMovimentacaoBemDTO> selectPatrimMovimentacaoBemPagina(int primeiroResultado, int quantidadeResultados, PatrimMovimentacaoBemDTO patrimMovimentacaoBem)
        {
            try
            {
                IList<PatrimMovimentacaoBemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimMovimentacaoBemDTO> DAL = new NHibernateDAL<PatrimMovimentacaoBemDTO>(session);
                    resultado = DAL.selectPagina<PatrimMovimentacaoBemDTO>(primeiroResultado, quantidadeResultados, patrimMovimentacaoBem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region PatrimApoliceSeguro
        public int deletePatrimApoliceSeguro(PatrimApoliceSeguroDTO patrimApoliceSeguro)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimApoliceSeguroDTO> DAL = new NHibernateDAL<PatrimApoliceSeguroDTO>(session);
                    DAL.delete(patrimApoliceSeguro);
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


        public PatrimApoliceSeguroDTO salvarAtualizarPatrimApoliceSeguro(PatrimApoliceSeguroDTO patrimApoliceSeguro)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimApoliceSeguroDTO> DAL = new NHibernateDAL<PatrimApoliceSeguroDTO>(session);
                    DAL.saveOrUpdate(patrimApoliceSeguro);
                    session.Flush();
                }
                return patrimApoliceSeguro;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimApoliceSeguroDTO> selectPatrimApoliceSeguro(PatrimApoliceSeguroDTO patrimApoliceSeguro)
        {
            try
            {
                IList<PatrimApoliceSeguroDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimApoliceSeguroDTO> DAL = new NHibernateDAL<PatrimApoliceSeguroDTO>(session);
                    resultado = DAL.select(patrimApoliceSeguro);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PatrimApoliceSeguroDTO> selectPatrimApoliceSeguroPagina(int primeiroResultado, int quantidadeResultados, PatrimApoliceSeguroDTO patrimApoliceSeguro)
        {
            try
            {
                IList<PatrimApoliceSeguroDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PatrimApoliceSeguroDTO> DAL = new NHibernateDAL<PatrimApoliceSeguroDTO>(session);
                    resultado = DAL.selectPagina<PatrimApoliceSeguroDTO>(primeiroResultado, quantidadeResultados, patrimApoliceSeguro);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Fornecedor
        public IList<FornecedorDTO> selectFornecedor(FornecedorDTO fornecedor)
        {
            try
            {
                IList<FornecedorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FornecedorDTO> DAL = new NHibernateDAL<FornecedorDTO>(session);
                    resultado = DAL.select(fornecedor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        public IList<FornecedorDTO> selectFornecedorPagina(int primeiroResultado, int quantidadeResultados, FornecedorDTO fornecedor)
        {
            try
            {
                IList<FornecedorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FornecedorDTO> DAL = new NHibernateDAL<FornecedorDTO>(session);
                    resultado = DAL.selectPagina<FornecedorDTO>(primeiroResultado, quantidadeResultados, fornecedor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        #endregion

        #region Setor

        public IList<SetorDTO> selectSetor(SetorDTO setor)
        {
            try
            {
                IList<SetorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<SetorDTO> DAL = new NHibernateDAL<SetorDTO>(session);
                    resultado = DAL.select(setor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<SetorDTO> selectSetorPagina(int primeiroResultado, int quantidadeResultados, SetorDTO setor)
        {
            try
            {
                IList<SetorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<SetorDTO> DAL = new NHibernateDAL<SetorDTO>(session);
                    resultado = DAL.selectPagina<SetorDTO>(primeiroResultado, quantidadeResultados, setor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion

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

        #region Pessoa
        public PessoaDTO selectPessoa(PessoaDTO pessoa)
        {
            PessoaDTO resultado = null;
            using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
            {
                NHibernateDAL<PessoaDTO> DAL = new NHibernateDAL<PessoaDTO>(session);
                resultado = DAL.selectId<PessoaDTO>(pessoa.Id);

                if (resultado != null)
                {
                    NHibernateDAL<EnderecoDTO> DALEnd = new NHibernateDAL<EnderecoDTO>(session);
                    IList<EnderecoDTO> listaEnd = DALEnd.select<EnderecoDTO>(new EnderecoDTO { IdPessoa = resultado.Id });
                    if (listaEnd != null && listaEnd.Count > 0)
                        resultado.Endereco = listaEnd.First();
                }
            }
            return resultado;
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
