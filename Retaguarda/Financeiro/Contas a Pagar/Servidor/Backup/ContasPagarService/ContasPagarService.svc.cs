using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ContasPagarService.Model;
using NHibernate;
using ContasPagarService.NHibernate;

namespace ContasPagarService
{
    public class ContasPagarService : IContasPagarService
    {

        #region PlanoNaturezaFinanceira
        public int deletePlanoNaturezaFinanceira(PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoNaturezaFinanceiraDTO> DAL = new NHibernateDAL<PlanoNaturezaFinanceiraDTO>(session);
                    DAL.delete(planoNaturezaFinanceira);
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


        public PlanoNaturezaFinanceiraDTO salvarAtualizarPlanoNaturezaFinanceira(PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoNaturezaFinanceiraDTO> DAL = new NHibernateDAL<PlanoNaturezaFinanceiraDTO>(session);
                    DAL.saveOrUpdate(planoNaturezaFinanceira);
                    session.Flush();
                }
                return planoNaturezaFinanceira;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PlanoNaturezaFinanceiraDTO> selectPlanoNaturezaFinanceira(PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira)
        {
            try
            {
                IList<PlanoNaturezaFinanceiraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoNaturezaFinanceiraDTO> DAL = new NHibernateDAL<PlanoNaturezaFinanceiraDTO>(session);
                    resultado = DAL.select(planoNaturezaFinanceira);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<PlanoNaturezaFinanceiraDTO> selectPlanoNaturezaFinanceiraPagina(int primeiroResultado, int quantidadeResultados, PlanoNaturezaFinanceiraDTO planoNaturezaFinanceira)
        {
            try
            {
                IList<PlanoNaturezaFinanceiraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<PlanoNaturezaFinanceiraDTO> DAL = new NHibernateDAL<PlanoNaturezaFinanceiraDTO>(session);
                    resultado = DAL.selectPagina<PlanoNaturezaFinanceiraDTO>(primeiroResultado, quantidadeResultados, planoNaturezaFinanceira);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region NaturezaFinanceira
        public int deleteNaturezaFinanceira(NaturezaFinanceiraDTO naturezaFinanceira)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<NaturezaFinanceiraDTO> DAL = new NHibernateDAL<NaturezaFinanceiraDTO>(session);
                    DAL.delete(naturezaFinanceira);
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


        public NaturezaFinanceiraDTO salvarAtualizarNaturezaFinanceira(NaturezaFinanceiraDTO naturezaFinanceira)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<NaturezaFinanceiraDTO> DAL = new NHibernateDAL<NaturezaFinanceiraDTO>(session);
                    DAL.saveOrUpdate(naturezaFinanceira);
                    session.Flush();
                }
                return naturezaFinanceira;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<NaturezaFinanceiraDTO> selectNaturezaFinanceira(NaturezaFinanceiraDTO naturezaFinanceira)
        {
            try
            {
                IList<NaturezaFinanceiraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<NaturezaFinanceiraDTO> DAL = new NHibernateDAL<NaturezaFinanceiraDTO>(session);
                    resultado = DAL.select(naturezaFinanceira);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<NaturezaFinanceiraDTO> selectNaturezaFinanceiraPagina(int primeiroResultado, int quantidadeResultados, NaturezaFinanceiraDTO naturezaFinanceira)
        {
            try
            {
                IList<NaturezaFinanceiraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<NaturezaFinanceiraDTO> DAL = new NHibernateDAL<NaturezaFinanceiraDTO>(session);
                    resultado = DAL.selectPagina<NaturezaFinanceiraDTO>(primeiroResultado, quantidadeResultados, naturezaFinanceira);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FinStatusParcela
        public int deleteFinStatusParcela(FinStatusParcelaDTO finStatusParcela)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinStatusParcelaDTO> DAL = new NHibernateDAL<FinStatusParcelaDTO>(session);
                    DAL.delete(finStatusParcela);
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


        public FinStatusParcelaDTO salvarAtualizarFinStatusParcela(FinStatusParcelaDTO finStatusParcela)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinStatusParcelaDTO> DAL = new NHibernateDAL<FinStatusParcelaDTO>(session);
                    DAL.saveOrUpdate(finStatusParcela);
                    session.Flush();
                }
                return finStatusParcela;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinStatusParcelaDTO> selectFinStatusParcela(FinStatusParcelaDTO finStatusParcela)
        {
            try
            {
                IList<FinStatusParcelaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinStatusParcelaDTO> DAL = new NHibernateDAL<FinStatusParcelaDTO>(session);
                    resultado = DAL.select(finStatusParcela);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinStatusParcelaDTO> selectFinStatusParcelaPagina(int primeiroResultado, int quantidadeResultados, FinStatusParcelaDTO finStatusParcela)
        {
            try
            {
                IList<FinStatusParcelaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinStatusParcelaDTO> DAL = new NHibernateDAL<FinStatusParcelaDTO>(session);
                    resultado = DAL.selectPagina<FinStatusParcelaDTO>(primeiroResultado, quantidadeResultados, finStatusParcela);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FinTipoPagamento
        public int deleteFinTipoPagamento(FinTipoPagamentoDTO finTipoPagamento)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinTipoPagamentoDTO> DAL = new NHibernateDAL<FinTipoPagamentoDTO>(session);
                    DAL.delete(finTipoPagamento);
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


        public FinTipoPagamentoDTO salvarAtualizarFinTipoPagamento(FinTipoPagamentoDTO finTipoPagamento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinTipoPagamentoDTO> DAL = new NHibernateDAL<FinTipoPagamentoDTO>(session);
                    DAL.saveOrUpdate(finTipoPagamento);
                    session.Flush();
                }
                return finTipoPagamento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinTipoPagamentoDTO> selectFinTipoPagamento(FinTipoPagamentoDTO finTipoPagamento)
        {
            try
            {
                IList<FinTipoPagamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinTipoPagamentoDTO> DAL = new NHibernateDAL<FinTipoPagamentoDTO>(session);
                    resultado = DAL.select(finTipoPagamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinTipoPagamentoDTO> selectFinTipoPagamentoPagina(int primeiroResultado, int quantidadeResultados, FinTipoPagamentoDTO finTipoPagamento)
        {
            try
            {
                IList<FinTipoPagamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinTipoPagamentoDTO> DAL = new NHibernateDAL<FinTipoPagamentoDTO>(session);
                    resultado = DAL.selectPagina<FinTipoPagamentoDTO>(primeiroResultado, quantidadeResultados, finTipoPagamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FinDocumentoOrigem
        public int deleteFinDocumentoOrigem(FinDocumentoOrigemDTO finDocumentoOrigem)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinDocumentoOrigemDTO> DAL = new NHibernateDAL<FinDocumentoOrigemDTO>(session);
                    DAL.delete(finDocumentoOrigem);
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


        public FinDocumentoOrigemDTO salvarAtualizarFinDocumentoOrigem(FinDocumentoOrigemDTO finDocumentoOrigem)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinDocumentoOrigemDTO> DAL = new NHibernateDAL<FinDocumentoOrigemDTO>(session);
                    DAL.saveOrUpdate(finDocumentoOrigem);
                    session.Flush();
                }
                return finDocumentoOrigem;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinDocumentoOrigemDTO> selectFinDocumentoOrigem(FinDocumentoOrigemDTO finDocumentoOrigem)
        {
            try
            {
                IList<FinDocumentoOrigemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinDocumentoOrigemDTO> DAL = new NHibernateDAL<FinDocumentoOrigemDTO>(session);
                    resultado = DAL.select(finDocumentoOrigem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinDocumentoOrigemDTO> selectFinDocumentoOrigemPagina(int primeiroResultado, int quantidadeResultados, FinDocumentoOrigemDTO finDocumentoOrigem)
        {
            try
            {
                IList<FinDocumentoOrigemDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FinDocumentoOrigemDTO> DAL = new NHibernateDAL<FinDocumentoOrigemDTO>(session);
                    resultado = DAL.selectPagina<FinDocumentoOrigemDTO>(primeiroResultado, quantidadeResultados, finDocumentoOrigem);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region FinLancamentoPagar
        public int deleteFinLancamentoPagar(FinLancamentoPagarDTO FinLancamentoPagar)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    LancamentoPagarDAL DAL = new LancamentoPagarDAL(session);
                    DAL.delete(FinLancamentoPagar);
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


        public FinLancamentoPagarDTO salvarAtualizarFinLancamentoPagar(FinLancamentoPagarDTO FinLancamentoPagar)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    LancamentoPagarDAL DAL = new LancamentoPagarDAL(session);
                    DAL.saveOrUpdate(FinLancamentoPagar);
                    session.Flush();
                }
                return FinLancamentoPagar;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinLancamentoPagarDTO> selectFinLancamentoPagar(FinLancamentoPagarDTO FinLancamentoPagar)
        {
            try
            {
                IList<FinLancamentoPagarDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    LancamentoPagarDAL DAL = new LancamentoPagarDAL(session);
                    resultado = DAL.select(FinLancamentoPagar);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FinLancamentoPagarDTO> selectFinLancamentoPagarPagina(int primeiroResultado, int quantidadeResultados, FinLancamentoPagarDTO FinLancamentoPagar)
        {
            try
            {
                IList<FinLancamentoPagarDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    LancamentoPagarDAL DAL = new LancamentoPagarDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, FinLancamentoPagar);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region ViewFinLancamentoPagar
        public ViewFinLancamentoPagarDTO salvarAtualizarViewFinLancamentoPagar(ViewFinLancamentoPagarDTO ViewFinLancamentoPagar)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    PagamentoDAL DAL = new PagamentoDAL(session);
                    DAL.saveOrUpdate(ViewFinLancamentoPagar);
                    session.Flush();
                }
                return ViewFinLancamentoPagar;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewFinLancamentoPagarDTO> selectViewFinLancamentoPagar(ViewFinLancamentoPagarDTO ViewFinLancamentoPagar)
        {
            try
            {
                IList<ViewFinLancamentoPagarDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    PagamentoDAL DAL = new PagamentoDAL(session);
                    resultado = DAL.select(ViewFinLancamentoPagar);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewFinLancamentoPagarDTO> selectViewFinLancamentoPagarPagina(int primeiroResultado, int quantidadeResultados, ViewFinLancamentoPagarDTO ViewFinLancamentoPagar)
        {
            try
            {
                IList<ViewFinLancamentoPagarDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    PagamentoDAL DAL = new PagamentoDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, ViewFinLancamentoPagar);
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

        #region ViewPessoaFornecedor
        public IList<ViewPessoaFornecedorDTO> selectViewPessoaFornecedor(ViewPessoaFornecedorDTO viewPessoaFornecedor)
        {
            try
            {
                IList<ViewPessoaFornecedorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewPessoaFornecedorDTO> DAL = new NHibernateDAL<ViewPessoaFornecedorDTO>(session);
                    resultado = DAL.select(viewPessoaFornecedor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ViewPessoaFornecedorDTO> selectViewPessoaFornecedorPagina(int primeiroResultado, int quantidadeResultados, ViewPessoaFornecedorDTO viewPessoaFornecedor)
        {
            try
            {
                IList<ViewPessoaFornecedorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewPessoaFornecedorDTO> DAL = new NHibernateDAL<ViewPessoaFornecedorDTO>(session);
                    resultado = DAL.selectPagina<ViewPessoaFornecedorDTO>(primeiroResultado, quantidadeResultados, viewPessoaFornecedor);
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
