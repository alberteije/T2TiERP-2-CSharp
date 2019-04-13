using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using VendasService.Model;
using NHibernate;
using VendasService.NHibernate;

namespace VendasService
{
    public class ServicoVendas : IServicoVendas
    {
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
        #region CondicoesPagamento
        public int deleteCondicoesPagamento(CondicoesPagamentoDTO condicoesPagamento)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    CondicoesPagamentoDAL DAL = new CondicoesPagamentoDAL(session);
                    DAL.delete(condicoesPagamento);
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
        public CondicoesPagamentoDTO salvarAtualizarCondicoesPagamento(CondicoesPagamentoDTO condicoesPagamento)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    CondicoesPagamentoDAL DAL = new CondicoesPagamentoDAL(session);
                    DAL.saveOrUpdate(condicoesPagamento);
                    session.Flush();
                }
                return condicoesPagamento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<CondicoesPagamentoDTO> selectCondicoesPagamento(CondicoesPagamentoDTO condicoesPagamento)
        {
            try
            {
                IList<CondicoesPagamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    CondicoesPagamentoDAL DAL = new CondicoesPagamentoDAL(session);
                    resultado = DAL.select(condicoesPagamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<CondicoesPagamentoDTO> selectCondicoesPagamentoPagina(int primeiroResultado, int quantidadeResultados, CondicoesPagamentoDTO condicoesPagamento)
        {
            try
            {
                IList<CondicoesPagamentoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    CondicoesPagamentoDAL DAL = new CondicoesPagamentoDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, condicoesPagamento);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion 
        #region OrcamentoPedidoVendaCab
        public int deleteOrcamentoPedidoVendaCab(OrcamentoPedidoVendaCabDTO orcamentoPedidoVendaCab)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    OrcamentoDAL DAL = new OrcamentoDAL(session);
                    DAL.delete(orcamentoPedidoVendaCab);
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
        public OrcamentoPedidoVendaCabDTO salvarAtualizarOrcamentoPedidoVendaCab(OrcamentoPedidoVendaCabDTO orcamentoPedidoVendaCab)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    OrcamentoDAL DAL = new OrcamentoDAL(session);
                    DAL.saveOrUpdate(orcamentoPedidoVendaCab);
                    session.Flush();
                }
                return orcamentoPedidoVendaCab;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<OrcamentoPedidoVendaCabDTO> selectOrcamentoPedidoVendaCab(OrcamentoPedidoVendaCabDTO orcamentoPedidoVendaCab)
        {
            try
            {
                IList<OrcamentoPedidoVendaCabDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    OrcamentoDAL DAL = new OrcamentoDAL(session);
                    resultado = DAL.select(orcamentoPedidoVendaCab);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<OrcamentoPedidoVendaCabDTO> selectOrcamentoPedidoVendaCabPagina(int primeiroResultado, int quantidadeResultados, OrcamentoPedidoVendaCabDTO orcamentoPedidoVendaCab)
        {
            try
            {
                IList<OrcamentoPedidoVendaCabDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    OrcamentoDAL DAL = new OrcamentoDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, orcamentoPedidoVendaCab);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion 
        #region VendaCabecalho
        public int deleteVendaCabecalho(VendaCabecalhoDTO vendaCabecalho)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    VendaDAL DAL = new VendaDAL(session);
                    DAL.delete(vendaCabecalho);
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
        public VendaCabecalhoDTO salvarAtualizarVendaCabecalho(VendaCabecalhoDTO vendaCabecalho)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    VendaDAL DAL = new VendaDAL(session);
                    DAL.saveOrUpdate(vendaCabecalho);
                    session.Flush();
                }
                return vendaCabecalho;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<VendaCabecalhoDTO> selectVendaCabecalho(VendaCabecalhoDTO vendaCabecalho)
        {
            try
            {
                IList<VendaCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    VendaDAL DAL = new VendaDAL(session);
                    resultado = DAL.select(vendaCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<VendaCabecalhoDTO> selectVendaCabecalhoPagina(int primeiroResultado, int quantidadeResultados, VendaCabecalhoDTO vendaCabecalho)
        {
            try
            {
                IList<VendaCabecalhoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    VendaDAL DAL = new VendaDAL(session);
                    resultado = DAL.selectPagina(primeiroResultado, quantidadeResultados, vendaCabecalho);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion 
        #region FreteVenda
        public int deleteFreteVenda(FreteVendaDTO freteVenda)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FreteVendaDTO> DAL = new NHibernateDAL<FreteVendaDTO>(session);
                    DAL.delete(freteVenda);
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
        public FreteVendaDTO salvarAtualizarFreteVenda(FreteVendaDTO freteVenda)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FreteVendaDTO> DAL = new NHibernateDAL<FreteVendaDTO>(session);
                    DAL.saveOrUpdate(freteVenda);
                    session.Flush();
                }
                return freteVenda;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<FreteVendaDTO> selectFreteVenda(FreteVendaDTO freteVenda)
        {
            try
            {
                IList<FreteVendaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FreteVendaDTO> DAL = new NHibernateDAL<FreteVendaDTO>(session);
                    resultado = DAL.select(freteVenda);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<FreteVendaDTO> selectFreteVendaPagina(int primeiroResultado, int quantidadeResultados, FreteVendaDTO freteVenda)
        {
            try
            {
                IList<FreteVendaDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<FreteVendaDTO> DAL = new NHibernateDAL<FreteVendaDTO>(session);
                    resultado = DAL.selectPagina<FreteVendaDTO>(primeiroResultado, quantidadeResultados, freteVenda);
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
        #region Vendedor
        public IList<VendedorDTO> selectVendedor(VendedorDTO vendedor)
        {
            try
            {
                IList<VendedorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<VendedorDTO> DAL = new NHibernateDAL<VendedorDTO>(session);
                    resultado = DAL.select(vendedor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<VendedorDTO> selectVendedorPagina(int primeiroResultado, int quantidadeResultados, VendedorDTO vendedor)
        {
            try
            {
                IList<VendedorDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<VendedorDTO> DAL = new NHibernateDAL<VendedorDTO>(session);
                    resultado = DAL.selectPagina<VendedorDTO>(primeiroResultado, quantidadeResultados, vendedor);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion
        #region transportadora
        public IList<TransportadoraDTO> selectTransportadora(TransportadoraDTO transportadora)
        {
            try
            {
                IList<TransportadoraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TransportadoraDTO> DAL = new NHibernateDAL<TransportadoraDTO>(session);
                    resultado = DAL.select(transportadora);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<TransportadoraDTO> selectTransportadoraPagina(int primeiroResultado, int quantidadeResultados, TransportadoraDTO transportadora)
        {
            try
            {
                IList<TransportadoraDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<TransportadoraDTO> DAL = new NHibernateDAL<TransportadoraDTO>(session);
                    resultado = DAL.selectPagina<TransportadoraDTO>(primeiroResultado, quantidadeResultados, transportadora);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion
        #region Produto
        public IList<ProdutoDTO> selectProduto(ProdutoDTO produto)
        {
            try
            {
                IList<ProdutoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(session);
                    resultado = DAL.select(produto);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        public IList<ProdutoDTO> selectProdutoPagina(int primeiroResultado, int quantidadeResultados, ProdutoDTO produto)
        {
            try
            {
                IList<ProdutoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(session);
                    resultado = DAL.selectPagina<ProdutoDTO>(primeiroResultado, quantidadeResultados, produto);
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
