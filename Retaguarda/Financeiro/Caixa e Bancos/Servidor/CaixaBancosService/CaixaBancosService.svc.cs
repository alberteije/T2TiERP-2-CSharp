using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CaixaBancosService.Model;
using CaixaBancosService.NHibernate;
using NHibernate;

namespace CaixaBancosService
{
    public class CaixaBancosService : ICaixaBancosService
    {

        #region FinFechamentoCaixaBanco
        public int deleteFinFechamentoCaixaBanco(FinFechamentoCaixaBancoDTO finFechamentoCaixaBanco)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinFechamentoCaixaBancoDTO> DAL = new NHibernateDAL<FinFechamentoCaixaBancoDTO>(session);
                    DAL.delete(finFechamentoCaixaBanco);
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


        public FinFechamentoCaixaBancoDTO salvarAtualizarFinFechamentoCaixaBanco(FinFechamentoCaixaBancoDTO finFechamentoCaixaBanco)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinFechamentoCaixaBancoDTO> DAL = new NHibernateDAL<FinFechamentoCaixaBancoDTO>(session);
                    DAL.saveOrUpdate(finFechamentoCaixaBanco);
                    session.Flush();
                }
                return finFechamentoCaixaBanco;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public FinFechamentoCaixaBancoDTO selectFinFechamentoCaixaBanco(FinFechamentoCaixaBancoDTO finFechamentoCaixaBanco)
        {
            try
            {
                IList<FinFechamentoCaixaBancoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinFechamentoCaixaBancoDTO> DAL = new NHibernateDAL<FinFechamentoCaixaBancoDTO>(session);
                    resultado = DAL.select(finFechamentoCaixaBanco);
                }

                if (resultado != null && resultado.Count > 0)
                    return resultado.First();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinFechamentoCaixaBancoDTO> selectFinFechamentoCaixaBancoPagina(int primeiroResultado, int quantidadeResultados, FinFechamentoCaixaBancoDTO finFechamentoCaixaBanco)
        {
            try
            {
                IList<FinFechamentoCaixaBancoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinFechamentoCaixaBancoDTO> DAL = new NHibernateDAL<FinFechamentoCaixaBancoDTO>(session);
                    resultado = DAL.selectPagina<FinFechamentoCaixaBancoDTO>(primeiroResultado, quantidadeResultados, finFechamentoCaixaBanco);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ViewFinChequeNaoCompensado
        public int deleteViewFinChequeNaoCompensado(ViewFinChequeNaoCompensadoDTO viewFinChequeNaoCompensado)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewFinChequeNaoCompensadoDTO> DAL = new NHibernateDAL<ViewFinChequeNaoCompensadoDTO>(session);
                    DAL.delete(viewFinChequeNaoCompensado);
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


        public ViewFinChequeNaoCompensadoDTO salvarAtualizarViewFinChequeNaoCompensado(ViewFinChequeNaoCompensadoDTO viewFinChequeNaoCompensado)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewFinChequeNaoCompensadoDTO> DAL = new NHibernateDAL<ViewFinChequeNaoCompensadoDTO>(session);
                    DAL.saveOrUpdate(viewFinChequeNaoCompensado);
                    session.Flush();
                }
                return viewFinChequeNaoCompensado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewFinChequeNaoCompensadoDTO> selectViewFinChequeNaoCompensado(ViewFinChequeNaoCompensadoDTO viewFinChequeNaoCompensado)
        {
            try
            {
                IList<ViewFinChequeNaoCompensadoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewFinChequeNaoCompensadoDTO> DAL = new NHibernateDAL<ViewFinChequeNaoCompensadoDTO>(session);
                    resultado = DAL.select(viewFinChequeNaoCompensado);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewFinChequeNaoCompensadoDTO> selectViewFinChequeNaoCompensadoPagina(int primeiroResultado, int quantidadeResultados, ViewFinChequeNaoCompensadoDTO viewFinChequeNaoCompensado)
        {
            try
            {
                IList<ViewFinChequeNaoCompensadoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewFinChequeNaoCompensadoDTO> DAL = new NHibernateDAL<ViewFinChequeNaoCompensadoDTO>(session);
                    resultado = DAL.selectPagina<ViewFinChequeNaoCompensadoDTO>(primeiroResultado, quantidadeResultados, viewFinChequeNaoCompensado);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ViewFinMovimentoCaixaBanco
        public ViewFinMovimentoCaixaBancoDTO salvarAtualizarViewFinMovimentoCaixaBanco(ViewFinMovimentoCaixaBancoDTO viewFinMovimentoCaixaBanco)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewFinMovimentoCaixaBancoDTO> DAL = new NHibernateDAL<ViewFinMovimentoCaixaBancoDTO>(session);
                    DAL.saveOrUpdate(viewFinMovimentoCaixaBanco);
                    session.Flush();
                }
                return viewFinMovimentoCaixaBanco;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewFinMovimentoCaixaBancoDTO> selectViewFinMovimentoCaixaBanco(ViewFinMovimentoCaixaBancoDTO viewFinMovimentoCaixaBanco)
        {
            try
            {
                IList<ViewFinMovimentoCaixaBancoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewFinMovimentoCaixaBancoDTO> DAL = new NHibernateDAL<ViewFinMovimentoCaixaBancoDTO>(session);
                    resultado = DAL.select(viewFinMovimentoCaixaBanco);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewFinMovimentoCaixaBancoDTO> selectViewFinMovimentoCaixaBancoPagina(int primeiroResultado, int quantidadeResultados, ViewFinMovimentoCaixaBancoDTO viewFinMovimentoCaixaBanco)
        {
            try
            {
                IList<ViewFinMovimentoCaixaBancoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewFinMovimentoCaixaBancoDTO> DAL = new NHibernateDAL<ViewFinMovimentoCaixaBancoDTO>(session);
                    resultado = DAL.selectPagina<ViewFinMovimentoCaixaBancoDTO>(primeiroResultado, quantidadeResultados, viewFinMovimentoCaixaBanco);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewFinMovimentoCaixaBancoDTO> selectPeriodoMovimentoCaixaBanco(ViewFinMovimentoCaixaBancoDTO movimentoCaixaBanco)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    MovimentoCaixaBancoDAL movCaixaBancoDAL = new MovimentoCaixaBancoDAL(session);
                    return movCaixaBancoDAL.selectPeriodo(movimentoCaixaBanco);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 



        #region ContabilConta
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

        #region ContaCaixa
        public IList<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO contaCaixa)
        {
            try
            {
                IList<ContaCaixaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContaCaixaDTO> DAL = new NHibernateDAL<ContaCaixaDTO>(session);
                    resultado = DAL.select(contaCaixa);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContaCaixaDTO> selectContaCaixaPagina(int primeiroResultado, int quantidadeResultados, ContaCaixaDTO contaCaixa)
        {
            try
            {
                IList<ContaCaixaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContaCaixaDTO> DAL = new NHibernateDAL<ContaCaixaDTO>(session);
                    resultado = DAL.selectPagina<ContaCaixaDTO>(primeiroResultado, quantidadeResultados, contaCaixa);
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
