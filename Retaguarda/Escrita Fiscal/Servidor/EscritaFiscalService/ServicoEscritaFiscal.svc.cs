using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EscritaFiscalService.Model;
using NHibernate;
using EscritaFiscalService.NHibernate;

namespace EscritaFiscalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ServicoEscritaFiscal : IServicoEscritaFiscal
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

        #region FiscalParametro
        public int deleteFiscalParametro(FiscalParametroDTO fiscalParametro)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalParametroDTO> DAL = new NHibernateDAL<FiscalParametroDTO>(session);
                    DAL.delete(fiscalParametro);
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


        public FiscalParametroDTO salvarAtualizarFiscalParametro(FiscalParametroDTO fiscalParametro)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalParametroDTO> DAL = new NHibernateDAL<FiscalParametroDTO>(session);
                    DAL.saveOrUpdate(fiscalParametro);
                    session.Flush();
                }
                return fiscalParametro;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalParametroDTO> selectFiscalParametro(FiscalParametroDTO fiscalParametro)
        {
            try
            {
                IList<FiscalParametroDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalParametroDTO> DAL = new NHibernateDAL<FiscalParametroDTO>(session);
                    resultado = DAL.select(fiscalParametro);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalParametroDTO> selectFiscalParametroPagina(int primeiroResultado, int quantidadeResultados, FiscalParametroDTO fiscalParametro)
        {
            try
            {
                IList<FiscalParametroDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalParametroDTO> DAL = new NHibernateDAL<FiscalParametroDTO>(session);
                    resultado = DAL.selectPagina<FiscalParametroDTO>(primeiroResultado, quantidadeResultados, fiscalParametro);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region TipoNotaFiscal
        public int deleteTipoNotaFiscal(TipoNotaFiscalDTO tipoNotaFiscal)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoNotaFiscalDTO> DAL = new NHibernateDAL<TipoNotaFiscalDTO>(session);
                    DAL.delete(tipoNotaFiscal);
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


        public TipoNotaFiscalDTO salvarAtualizarTipoNotaFiscal(TipoNotaFiscalDTO tipoNotaFiscal)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoNotaFiscalDTO> DAL = new NHibernateDAL<TipoNotaFiscalDTO>(session);
                    DAL.saveOrUpdate(tipoNotaFiscal);
                    session.Flush();
                }
                return tipoNotaFiscal;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TipoNotaFiscalDTO> selectTipoNotaFiscal(TipoNotaFiscalDTO tipoNotaFiscal)
        {
            try
            {
                IList<TipoNotaFiscalDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoNotaFiscalDTO> DAL = new NHibernateDAL<TipoNotaFiscalDTO>(session);
                    resultado = DAL.select(tipoNotaFiscal);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TipoNotaFiscalDTO> selectTipoNotaFiscalPagina(int primeiroResultado, int quantidadeResultados, TipoNotaFiscalDTO tipoNotaFiscal)
        {
            try
            {
                IList<TipoNotaFiscalDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoNotaFiscalDTO> DAL = new NHibernateDAL<TipoNotaFiscalDTO>(session);
                    resultado = DAL.selectPagina<TipoNotaFiscalDTO>(primeiroResultado, quantidadeResultados, tipoNotaFiscal);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region SimplesNacionalCabecalho
        public int deleteSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    SimplesNacionalDAL DAL = new SimplesNacionalDAL(session);
                    DAL.delete(simplesNacionalCabecalho);
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


        public SimplesNacionalCabecalhoDTO salvarAtualizarSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    SimplesNacionalDAL DAL = new SimplesNacionalDAL(session);
                    DAL.saveOrUpdate(simplesNacionalCabecalho);
                    session.Flush();
                }
                return simplesNacionalCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<SimplesNacionalCabecalhoDTO> selectSimplesNacionalCabecalho(SimplesNacionalCabecalhoDTO simplesNacionalCabecalho)
        {
            try
            {
                IList<SimplesNacionalCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    SimplesNacionalDAL DAL = new SimplesNacionalDAL(session);
                    resultado = DAL.select(simplesNacionalCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<SimplesNacionalCabecalhoDTO> selectSimplesNacionalCabecalhoPagina(int primeiroResultado, int quantidadeResultados, SimplesNacionalCabecalhoDTO simplesNacionalCabecalho)
        {
            try
            {
                IList<SimplesNacionalCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    SimplesNacionalDAL DAL = new SimplesNacionalDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, simplesNacionalCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FiscalLivro
        public int deleteFiscalLivro(FiscalLivroDTO fiscalLivro)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FiscalLivroDAL DAL = new FiscalLivroDAL(session);
                    DAL.delete(fiscalLivro);
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


        public FiscalLivroDTO salvarAtualizarFiscalLivro(FiscalLivroDTO fiscalLivro)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FiscalLivroDAL DAL = new FiscalLivroDAL(session);
                    DAL.saveOrUpdate(fiscalLivro);
                    session.Flush();
                }
                return fiscalLivro;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalLivroDTO> selectFiscalLivro(FiscalLivroDTO fiscalLivro)
        {
            try
            {
                IList<FiscalLivroDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FiscalLivroDAL DAL = new FiscalLivroDAL(session);
                    resultado = DAL.select(fiscalLivro);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalLivroDTO> selectFiscalLivroPagina(int primeiroResultado, int quantidadeResultados, FiscalLivroDTO fiscalLivro)
        {
            try
            {
                IList<FiscalLivroDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    FiscalLivroDAL DAL = new FiscalLivroDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, fiscalLivro);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FiscalApuracaoIcms
        public int deleteFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalApuracaoIcmsDTO> DAL = new NHibernateDAL<FiscalApuracaoIcmsDTO>(session);
                    DAL.delete(fiscalApuracaoIcms);
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


        public FiscalApuracaoIcmsDTO salvarAtualizarFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalApuracaoIcmsDTO> DAL = new NHibernateDAL<FiscalApuracaoIcmsDTO>(session);
                    DAL.saveOrUpdate(fiscalApuracaoIcms);
                    session.Flush();
                }
                return fiscalApuracaoIcms;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalApuracaoIcmsDTO> selectFiscalApuracaoIcms(FiscalApuracaoIcmsDTO fiscalApuracaoIcms)
        {
            try
            {
                IList<FiscalApuracaoIcmsDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalApuracaoIcmsDTO> DAL = new NHibernateDAL<FiscalApuracaoIcmsDTO>(session);
                    resultado = DAL.select(fiscalApuracaoIcms);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FiscalApuracaoIcmsDTO> selectFiscalApuracaoIcmsPagina(int primeiroResultado, int quantidadeResultados, FiscalApuracaoIcmsDTO fiscalApuracaoIcms)
        {
            try
            {
                IList<FiscalApuracaoIcmsDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FiscalApuracaoIcmsDTO> DAL = new NHibernateDAL<FiscalApuracaoIcmsDTO>(session);
                    resultado = DAL.selectPagina<FiscalApuracaoIcmsDTO>(primeiroResultado, quantidadeResultados, fiscalApuracaoIcms);
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
