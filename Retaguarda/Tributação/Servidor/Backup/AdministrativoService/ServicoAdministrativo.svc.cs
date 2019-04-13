using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AdministrativoService.Model;
using NHibernate;
using AdministrativoService.NHibernate;

namespace AdministrativoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ServicoAdministrativo : IServicoAdministrativo
    {

        #region TributOperacaoFiscal
        public int deleteTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributOperacaoFiscalDTO> DAL = new NHibernateDAL<TributOperacaoFiscalDTO>(session);
                    DAL.delete(tributOperacaoFiscal);
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


        public TributOperacaoFiscalDTO salvarAtualizarTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributOperacaoFiscalDTO> DAL = new NHibernateDAL<TributOperacaoFiscalDTO>(session);
                    DAL.saveOrUpdate(tributOperacaoFiscal);
                    session.Flush();
                }
                return tributOperacaoFiscal;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributOperacaoFiscalDTO> selectTributOperacaoFiscal(TributOperacaoFiscalDTO tributOperacaoFiscal)
        {
            try
            {
                IList<TributOperacaoFiscalDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributOperacaoFiscalDTO> DAL = new NHibernateDAL<TributOperacaoFiscalDTO>(session);
                    resultado = DAL.select(tributOperacaoFiscal);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributOperacaoFiscalDTO> selectTributOperacaoFiscalPagina(int primeiroResultado, int quantidadeResultados, TributOperacaoFiscalDTO tributOperacaoFiscal)
        {
            try
            {
                IList<TributOperacaoFiscalDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributOperacaoFiscalDTO> DAL = new NHibernateDAL<TributOperacaoFiscalDTO>(session);
                    resultado = DAL.selectPagina<TributOperacaoFiscalDTO>(primeiroResultado, quantidadeResultados, tributOperacaoFiscal);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region TributGrupoTributario
        public int deleteTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributGrupoTributarioDTO> DAL = new NHibernateDAL<TributGrupoTributarioDTO>(session);
                    DAL.delete(tributGrupoTributario);
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


        public TributGrupoTributarioDTO salvarAtualizarTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributGrupoTributarioDTO> DAL = new NHibernateDAL<TributGrupoTributarioDTO>(session);
                    DAL.saveOrUpdate(tributGrupoTributario);
                    session.Flush();
                }
                return tributGrupoTributario;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributGrupoTributarioDTO> selectTributGrupoTributario(TributGrupoTributarioDTO tributGrupoTributario)
        {
            try
            {
                IList<TributGrupoTributarioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributGrupoTributarioDTO> DAL = new NHibernateDAL<TributGrupoTributarioDTO>(session);
                    resultado = DAL.select(tributGrupoTributario);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributGrupoTributarioDTO> selectTributGrupoTributarioPagina(int primeiroResultado, int quantidadeResultados, TributGrupoTributarioDTO tributGrupoTributario)
        {
            try
            {
                IList<TributGrupoTributarioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributGrupoTributarioDTO> DAL = new NHibernateDAL<TributGrupoTributarioDTO>(session);
                    resultado = DAL.selectPagina<TributGrupoTributarioDTO>(primeiroResultado, quantidadeResultados, tributGrupoTributario);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region TributIss
        public int deleteTributIss(TributIssDTO tributIss)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributIssDTO> DAL = new NHibernateDAL<TributIssDTO>(session);
                    DAL.delete(tributIss);
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


        public TributIssDTO salvarAtualizarTributIss(TributIssDTO tributIss)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributIssDTO> DAL = new NHibernateDAL<TributIssDTO>(session);
                    DAL.saveOrUpdate(tributIss);
                    session.Flush();
                }
                return tributIss;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributIssDTO> selectTributIss(TributIssDTO tributIss)
        {
            try
            {
                IList<TributIssDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributIssDTO> DAL = new NHibernateDAL<TributIssDTO>(session);
                    resultado = DAL.select(tributIss);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributIssDTO> selectTributIssPagina(int primeiroResultado, int quantidadeResultados, TributIssDTO tributIss)
        {
            try
            {
                IList<TributIssDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TributIssDTO> DAL = new NHibernateDAL<TributIssDTO>(session);
                    resultado = DAL.selectPagina<TributIssDTO>(primeiroResultado, quantidadeResultados, tributIss);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region TributIcmsCustomCab
        public int deleteTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IcmsCustomizadoDAL DAL = new IcmsCustomizadoDAL(session);
                    DAL.delete(tributIcmsCustomCab);
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


        public TributIcmsCustomCabDTO salvarAtualizarTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IcmsCustomizadoDAL DAL = new IcmsCustomizadoDAL(session);
                    DAL.saveOrUpdate(tributIcmsCustomCab);
                    session.Flush();
                }
                return tributIcmsCustomCab;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributIcmsCustomCabDTO> selectTributIcmsCustomCab(TributIcmsCustomCabDTO tributIcmsCustomCab)
        {
            try
            {
                IList<TributIcmsCustomCabDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IcmsCustomizadoDAL DAL = new IcmsCustomizadoDAL(session);
                    resultado = DAL.select(tributIcmsCustomCab);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributIcmsCustomCabDTO> selectTributIcmsCustomCabPagina(int primeiroResultado, int quantidadeResultados, TributIcmsCustomCabDTO tributIcmsCustomCab)
        {
            try
            {
                IList<TributIcmsCustomCabDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IcmsCustomizadoDAL DAL = new IcmsCustomizadoDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, tributIcmsCustomCab);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region TributConfiguraOfGt
        public int deleteTributConfiguraOfGt(TributConfiguraOfGtDTO tributConfiguraOfGt)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ConfiguraTributacaoDAL DAL = new ConfiguraTributacaoDAL(session);
                    DAL.delete(tributConfiguraOfGt);
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


        public TributConfiguraOfGtDTO salvarAtualizarTributConfiguraOfGt(TributConfiguraOfGtDTO tributConfiguraOfGt)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ConfiguraTributacaoDAL DAL = new ConfiguraTributacaoDAL(session);
                    DAL.saveOrUpdate(tributConfiguraOfGt);
                    session.Flush();
                }
                return tributConfiguraOfGt;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributConfiguraOfGtDTO> selectTributConfiguraOfGt(TributConfiguraOfGtDTO tributConfiguraOfGt)
        {
            try
            {
                IList<TributConfiguraOfGtDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ConfiguraTributacaoDAL DAL = new ConfiguraTributacaoDAL(session);
                    resultado = DAL.select(tributConfiguraOfGt);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TributConfiguraOfGtDTO> selectTributConfiguraOfGtPagina(int primeiroResultado, int quantidadeResultados, TributConfiguraOfGtDTO tributConfiguraOfGt)
        {
            try
            {
                IList<TributConfiguraOfGtDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    ConfiguraTributacaoDAL DAL = new ConfiguraTributacaoDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, tributConfiguraOfGt);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region TipoReceitaDipi

        public IList<TipoReceitaDipiDTO> selectTipoReceitaDipi(TipoReceitaDipiDTO tipoReceitaDipi)
        {
            try
            {
                IList<TipoReceitaDipiDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoReceitaDipiDTO> DAL = new NHibernateDAL<TipoReceitaDipiDTO>(session);
                    resultado = DAL.select(tipoReceitaDipi);
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

        public ViewControleAcessoDTO selectControleAcessoId(int Id)
        {
            try
            {
                ViewControleAcessoDTO resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewControleAcessoDTO> DAL = new NHibernateDAL<ViewControleAcessoDTO>(session);
                    resultado = DAL.selectId<ViewControleAcessoDTO>(Id);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }

        }

        public int deleteUsuario(UsuarioDTO usuario)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<UsuarioDTO> DAL = new NHibernateDAL<UsuarioDTO>(session);
                    DAL.delete(usuario);
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


        public UsuarioDTO salvarAtualizarUsuario(UsuarioDTO usuario)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<UsuarioDTO> DAL = new NHibernateDAL<UsuarioDTO>(session);
                    DAL.saveOrUpdate(usuario);
                    session.Flush();
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<UsuarioDTO> selectUsuarioDto(UsuarioDTO usuario)
        {
            try
            {
                IList<UsuarioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<UsuarioDTO> DAL = new NHibernateDAL<UsuarioDTO>(session);
                    resultado = DAL.select(usuario);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<UsuarioDTO> selectUsuarioPagina(int primeiroResultado, int quantidadeResultados, UsuarioDTO usuario)
        {
            try
            {
                IList<UsuarioDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<UsuarioDTO> DAL = new NHibernateDAL<UsuarioDTO>(session);
                    resultado = DAL.selectPagina<UsuarioDTO>(primeiroResultado, quantidadeResultados, usuario);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion


        #region Papel
        public int deletePapel(PapelDTO papel)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PapelDTO> DAL = new NHibernateDAL<PapelDTO>(session);
                    DAL.delete(papel);
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


        public PapelDTO salvarAtualizarPapel(PapelDTO papel)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PapelDTO> DAL = new NHibernateDAL<PapelDTO>(session);
                    DAL.saveOrUpdate(papel);
                    session.Flush();
                }
                return papel;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PapelDTO> selectPapel(PapelDTO papel)
        {
            try
            {
                IList<PapelDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PapelDTO> DAL = new NHibernateDAL<PapelDTO>(session);
                    resultado = DAL.select(papel);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PapelDTO> selectPapelPagina(int primeiroResultado, int quantidadeResultados, PapelDTO papel)
        {
            try
            {
                IList<PapelDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PapelDTO> DAL = new NHibernateDAL<PapelDTO>(session);
                    resultado = DAL.selectPagina<PapelDTO>(primeiroResultado, quantidadeResultados, papel);
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

        #region PapelFuncao
        public int deletePapelFuncao(PapelFuncaoDTO papelFuncao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PapelFuncaoDTO> DAL = new NHibernateDAL<PapelFuncaoDTO>(session);
                    DAL.delete(papelFuncao);
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


        public PapelFuncaoDTO salvarAtualizarPapelFuncao(PapelFuncaoDTO papelFuncao)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PapelFuncaoDTO> DAL = new NHibernateDAL<PapelFuncaoDTO>(session);
                    DAL.saveOrUpdate(papelFuncao);
                    session.Flush();
                }
                return papelFuncao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PapelFuncaoDTO> selectPapelFuncao(PapelFuncaoDTO papelFuncao)
        {
            try
            {
                IList<PapelFuncaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PapelFuncaoDTO> DAL = new NHibernateDAL<PapelFuncaoDTO>(session);
                    resultado = DAL.select(papelFuncao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PapelFuncaoDTO> selectPapelFuncaoPagina(int primeiroResultado, int quantidadeResultados, PapelFuncaoDTO papelFuncao)
        {
            try
            {
                IList<PapelFuncaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PapelFuncaoDTO> DAL = new NHibernateDAL<PapelFuncaoDTO>(session);
                    resultado = DAL.selectPagina<PapelFuncaoDTO>(primeiroResultado, quantidadeResultados, papelFuncao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion

        #region Funcao
        public int deleteFuncao(FuncaoDTO funcao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FuncaoDTO> DAL = new NHibernateDAL<FuncaoDTO>(session);
                    DAL.delete(funcao);
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


        public FuncaoDTO salvarAtualizarFuncao(FuncaoDTO funcao)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FuncaoDTO> DAL = new NHibernateDAL<FuncaoDTO>(session);
                    DAL.saveOrUpdate(funcao);
                    session.Flush();
                }
                return funcao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FuncaoDTO> selectFuncao(FuncaoDTO funcao)
        {
            try
            {
                IList<FuncaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FuncaoDTO> DAL = new NHibernateDAL<FuncaoDTO>(session);
                    resultado = DAL.select(funcao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FuncaoDTO> selectFuncaoPagina(int primeiroResultado, int quantidadeResultados, FuncaoDTO funcao)
        {
            try
            {
                IList<FuncaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FuncaoDTO> DAL = new NHibernateDAL<FuncaoDTO>(session);
                    resultado = DAL.selectPagina<FuncaoDTO>(primeiroResultado, quantidadeResultados, funcao);
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
