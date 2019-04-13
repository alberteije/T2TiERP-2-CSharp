using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConciliacaoContabilService.Model;
using NHibernate;
using ConciliacaoContabilService.NHibernate;

namespace ConciliacaoContabilService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class ServicoConciliacaoContabil : IServicoConciliacaoContabil
    {

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

        #region FinExtratoContaBanco
        public IList<FinExtratoContaBancoDTO> selectFinExtratoContaBanco(FinExtratoContaBancoDTO finExtratoContaBanco)
        {
            try
            {
                IList<FinExtratoContaBancoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinExtratoContaBancoDTO> DAL = new NHibernateDAL<FinExtratoContaBancoDTO>(session);
                    resultado = DAL.select(finExtratoContaBanco);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinExtratoContaBancoDTO> selectFinExtratoContaBancoPagina(int primeiroResultado, int quantidadeResultados, FinExtratoContaBancoDTO finExtratoContaBanco)
        {
            try
            {
                IList<FinExtratoContaBancoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinExtratoContaBancoDTO> DAL = new NHibernateDAL<FinExtratoContaBancoDTO>(session);
                    resultado = DAL.selectPagina<FinExtratoContaBancoDTO>(primeiroResultado, quantidadeResultados, finExtratoContaBanco);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ContabilLancamentoDetalhe
        public IList<ContabilLancamentoDetalheDTO> selectContabilLancamentoDetalhe(ContabilLancamentoDetalheDTO contabilLancamentoDetalhe)
        {
            try
            {
                IList<ContabilLancamentoDetalheDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLancamentoDetalheDTO> DAL = new NHibernateDAL<ContabilLancamentoDetalheDTO>(session);
                    resultado = DAL.select(contabilLancamentoDetalhe);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ContabilLancamentoDetalheDTO> selectContabilLancamentoDetalhePagina(int primeiroResultado, int quantidadeResultados, ContabilLancamentoDetalheDTO contabilLancamentoDetalhe)
        {
            try
            {
                IList<ContabilLancamentoDetalheDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ContabilLancamentoDetalheDTO> DAL = new NHibernateDAL<ContabilLancamentoDetalheDTO>(session);
                    resultado = DAL.selectPagina<ContabilLancamentoDetalheDTO>(primeiroResultado, quantidadeResultados, contabilLancamentoDetalhe);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Cliente
        public IList<ClienteDTO> selectCliente(ClienteDTO cliente)
        {
            try
            {
                IList<ClienteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ClienteDTO> DAL = new NHibernateDAL<ClienteDTO>(session);
                    resultado = DAL.select(cliente);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ClienteDTO> selectClientePagina(int primeiroResultado, int quantidadeResultados, ClienteDTO cliente)
        {
            try
            {
                IList<ClienteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ClienteDTO> DAL = new NHibernateDAL<ClienteDTO>(session);
                    resultado = DAL.selectPagina<ClienteDTO>(primeiroResultado, quantidadeResultados, cliente);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ViewConciliaCliente
        public IList<ViewConciliaClienteDTO> selectViewConciliaCliente(ViewConciliaClienteDTO viewConciliaCliente)
        {
            try
            {
                IList<ViewConciliaClienteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewConciliaClienteDTO> DAL = new NHibernateDAL<ViewConciliaClienteDTO>(session);
                    resultado = DAL.select(viewConciliaCliente);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewConciliaClienteDTO> selectViewConciliaClientePagina(int primeiroResultado, int quantidadeResultados, ViewConciliaClienteDTO viewConciliaCliente)
        {
            try
            {
                IList<ViewConciliaClienteDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewConciliaClienteDTO> DAL = new NHibernateDAL<ViewConciliaClienteDTO>(session);
                    resultado = DAL.selectPagina<ViewConciliaClienteDTO>(primeiroResultado, quantidadeResultados, viewConciliaCliente);
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

        #region ViewConciliaFornecedor
        public IList<ViewConciliaFornecedorDTO> selectViewConciliaFornecedor(ViewConciliaFornecedorDTO viewConciliaFornecedor)
        {
            try
            {
                IList<ViewConciliaFornecedorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewConciliaFornecedorDTO> DAL = new NHibernateDAL<ViewConciliaFornecedorDTO>(session);
                    resultado = DAL.select(viewConciliaFornecedor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewConciliaFornecedorDTO> selectViewConciliaFornecedorPagina(int primeiroResultado, int quantidadeResultados, ViewConciliaFornecedorDTO viewConciliaFornecedor)
        {
            try
            {
                IList<ViewConciliaFornecedorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewConciliaFornecedorDTO> DAL = new NHibernateDAL<ViewConciliaFornecedorDTO>(session);
                    resultado = DAL.selectPagina<ViewConciliaFornecedorDTO>(primeiroResultado, quantidadeResultados, viewConciliaFornecedor);
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
