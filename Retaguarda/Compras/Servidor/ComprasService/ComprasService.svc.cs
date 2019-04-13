using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ComprasService.NHibernate;
using NHibernate;
using ComprasService.Model;

namespace ComprasService
{
    public class ComprasService : IComprasService
    {


        #region CompraTipoRequisicao
        public int deleteCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoRequisicaoDTO> DAL = new NHibernateDAL<CompraTipoRequisicaoDTO>(session);
                    DAL.delete(compraTipoRequisicao);
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


        public CompraTipoRequisicaoDTO salvarAtualizarCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoRequisicaoDTO> DAL = new NHibernateDAL<CompraTipoRequisicaoDTO>(session);
                    DAL.saveOrUpdate(compraTipoRequisicao);
                    session.Flush();
                }
                return compraTipoRequisicao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraTipoRequisicaoDTO> selectCompraTipoRequisicao(CompraTipoRequisicaoDTO compraTipoRequisicao)
        {
            try
            {
                IList<CompraTipoRequisicaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoRequisicaoDTO> DAL = new NHibernateDAL<CompraTipoRequisicaoDTO>(session);
                    resultado = DAL.select(compraTipoRequisicao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraTipoRequisicaoDTO> selectCompraTipoRequisicaoPagina(int primeiroResultado, int quantidadeResultados, CompraTipoRequisicaoDTO compraTipoRequisicao)
        {
            try
            {
                IList<CompraTipoRequisicaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoRequisicaoDTO> DAL = new NHibernateDAL<CompraTipoRequisicaoDTO>(session);
                    resultado = DAL.selectPagina<CompraTipoRequisicaoDTO>(primeiroResultado, quantidadeResultados, compraTipoRequisicao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraTipoPedido
        public int deleteCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoPedidoDTO> DAL = new NHibernateDAL<CompraTipoPedidoDTO>(session);
                    DAL.delete(compraTipoPedido);
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


        public CompraTipoPedidoDTO salvarAtualizarCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoPedidoDTO> DAL = new NHibernateDAL<CompraTipoPedidoDTO>(session);
                    DAL.saveOrUpdate(compraTipoPedido);
                    session.Flush();
                }
                return compraTipoPedido;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraTipoPedidoDTO> selectCompraTipoPedido(CompraTipoPedidoDTO compraTipoPedido)
        {
            try
            {
                IList<CompraTipoPedidoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoPedidoDTO> DAL = new NHibernateDAL<CompraTipoPedidoDTO>(session);
                    resultado = DAL.select(compraTipoPedido);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraTipoPedidoDTO> selectCompraTipoPedidoPagina(int primeiroResultado, int quantidadeResultados, CompraTipoPedidoDTO compraTipoPedido)
        {
            try
            {
                IList<CompraTipoPedidoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraTipoPedidoDTO> DAL = new NHibernateDAL<CompraTipoPedidoDTO>(session);
                    resultado = DAL.selectPagina<CompraTipoPedidoDTO>(primeiroResultado, quantidadeResultados, compraTipoPedido);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraRequisicao
        public int deleteCompraRequisicao(CompraRequisicaoDTO compraRequisicao)
        {
            try
            {
                int resultado = -1;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    CompraRequisicaoDAL DAL = new CompraRequisicaoDAL(session);  
                    DAL.delete(compraRequisicao);
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


        public CompraRequisicaoDTO salvarAtualizarCompraRequisicao(CompraRequisicaoDTO compraRequisicao)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    CompraRequisicaoDAL DAL = new CompraRequisicaoDAL(session);
                    DAL.saveOrUpdate(compraRequisicao);
                    session.Flush();
                }
                return compraRequisicao;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraRequisicaoDTO> selectCompraRequisicao(CompraRequisicaoDTO compraRequisicao)
        {
            try
            {
                IList<CompraRequisicaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    CompraRequisicaoDAL DAL = new CompraRequisicaoDAL(session);
                    resultado = DAL.select(compraRequisicao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CompraRequisicaoDTO> selectCompraRequisicaoPagina(int primeiroResultado, int quantidadeResultados, CompraRequisicaoDTO compraRequisicao)
        {
            try
            {
                IList<CompraRequisicaoDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    CompraRequisicaoDAL DAL = new CompraRequisicaoDAL(session);
                    resultado = DAL.selectPagina<CompraRequisicaoDTO>(primeiroResultado, quantidadeResultados, compraRequisicao);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CompraCotacao
        public IList<CompraCotacaoDTO> selectCotacaoCompra(CompraCotacaoDTO cotacaoCompra)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<CompraCotacaoDTO> cotacaoCompraDAL = new NHibernateDAL<CompraCotacaoDTO>(session);
                    IList<CompraCotacaoDTO> resultado = cotacaoCompraDAL.select<CompraCotacaoDTO>(cotacaoCompra);
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CompraCotacaoDTO selectCotacaoCompraId(CompraCotacaoDTO cotacaoCompra)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<CompraCotacaoDTO> cotacaoCompraDAL = new NHibernateDAL<CompraCotacaoDTO>(session);
                    CompraCotacaoDTO resultado = cotacaoCompraDAL.selectId<CompraCotacaoDTO>((int)cotacaoCompra.Id);

                    IDAL<CompraCotacaoDetalheDTO> cotacaoCompraDetDAL = new NHibernateDAL<CompraCotacaoDetalheDTO>(session);
                    IDAL<CompraFornecedorCotacaoDTO> fornecedorCompraDAL = new NHibernateDAL<CompraFornecedorCotacaoDTO>(session);

                    resultado.listaFornecedor = fornecedorCompraDAL.select(new CompraFornecedorCotacaoDTO { IdCompraCotacao = resultado.Id });
                    
                    foreach (CompraFornecedorCotacaoDTO fornecedor in resultado.listaFornecedor)
                    {
                        fornecedor.listaCotacaoCompraDetalhe = cotacaoCompraDetDAL.select(new CompraCotacaoDetalheDTO { IdCompraFornecedorCotacao = fornecedor.Id });
                    }
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CompraCotacaoDTO saveCotacaoCompra(CompraCotacaoDTO cotacaoCompra)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<CompraCotacaoDTO> cotacaoCompraDAL = new NHibernateDAL<CompraCotacaoDTO>(session);
                    CompraCotacaoDTO resultado = cotacaoCompraDAL.save(cotacaoCompra);

                    IDAL<CompraCotacaoDetalheDTO> cotacaoCompraDetDAL = new NHibernateDAL<CompraCotacaoDetalheDTO>(session);
                    IDAL<CompraFornecedorCotacaoDTO> fornecedorCompraDAL = new NHibernateDAL<CompraFornecedorCotacaoDTO>(session);

                    foreach (CompraFornecedorCotacaoDTO fornecedor in cotacaoCompra.listaFornecedor)
                    {
                        fornecedor.IdCompraCotacao = cotacaoCompra.Id;
                        fornecedorCompraDAL.save(fornecedor);
                        foreach (CompraCotacaoDetalheDTO cotacaoDet in fornecedor.listaCotacaoCompraDetalhe)
                        {
                            cotacaoDet.IdCompraFornecedorCotacao = fornecedor.Id;
                            cotacaoCompraDetDAL.save(cotacaoDet);
                        }
                    }
                    session.Flush();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CompraCotacaoDTO updateCotacaoCompra(CompraCotacaoDTO cotacaoCompra)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<CompraCotacaoDTO> cotacaoCompraDAL = new NHibernateDAL<CompraCotacaoDTO>(session);
                    CompraCotacaoDTO resultado = cotacaoCompraDAL.update(cotacaoCompra);

                    IDAL<CompraCotacaoDetalheDTO> cotacaoCompraDetDAL = new NHibernateDAL<CompraCotacaoDetalheDTO>(session);
                    IDAL<CompraFornecedorCotacaoDTO> fornecedorCompraDAL = new NHibernateDAL<CompraFornecedorCotacaoDTO>(session);

                    IList<CompraFornecedorCotacaoDTO> listaFDelete = fornecedorCompraDAL.select(
                        new CompraFornecedorCotacaoDTO { IdCompraCotacao = cotacaoCompra.Id });

                    foreach (CompraFornecedorCotacaoDTO fornecedor in listaFDelete)
                    {
                        IList<CompraCotacaoDetalheDTO> listaCDelete = cotacaoCompraDetDAL.select(
                            new CompraCotacaoDetalheDTO { IdCompraFornecedorCotacao = fornecedor.Id });

                        foreach (CompraCotacaoDetalheDTO cotacaoDet in listaCDelete)
                        {
                            cotacaoCompraDetDAL.delete(cotacaoDet);
                        }

                        fornecedorCompraDAL.delete(fornecedor);
                    }

                    foreach (CompraFornecedorCotacaoDTO fornecedor in cotacaoCompra.listaFornecedor)
                    {
                        fornecedor.IdCompraCotacao = cotacaoCompra.Id;
                        fornecedorCompraDAL.save(fornecedor);
                        foreach (CompraCotacaoDetalheDTO cotacaoDet in fornecedor.listaCotacaoCompraDetalhe)
                        {
                            cotacaoDet.IdCompraFornecedorCotacao = fornecedor.Id;
                            cotacaoCompraDetDAL.save(cotacaoDet);
                        }
                    }
                    session.Flush();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteCotacaoCompra(CompraCotacaoDTO cotacaoCompra)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<CompraCotacaoDTO> cotacaoCompraDAL = new NHibernateDAL<CompraCotacaoDTO>(session);
                    IDAL<CompraCotacaoDetalheDTO> cotacaoCompraDetDAL = new NHibernateDAL<CompraCotacaoDetalheDTO>(session);
                    IDAL<CompraFornecedorCotacaoDTO> fornecedorCompraDAL = new NHibernateDAL<CompraFornecedorCotacaoDTO>(session);

                    IList<CompraFornecedorCotacaoDTO> listaFDelete = fornecedorCompraDAL.select(
                        new CompraFornecedorCotacaoDTO { IdCompraCotacao = cotacaoCompra.Id });

                    foreach (CompraFornecedorCotacaoDTO fornecedor in listaFDelete)
                    {
                        IList<CompraCotacaoDetalheDTO> listaCDelete = cotacaoCompraDetDAL.select(
                            new CompraCotacaoDetalheDTO { IdCompraFornecedorCotacao = fornecedor.Id });

                        foreach (CompraCotacaoDetalheDTO cotacaoDet in listaCDelete)
                        {
                            cotacaoCompraDetDAL.delete(cotacaoDet);
                        }

                        fornecedorCompraDAL.delete(fornecedor);
                    }
                    int resultado = cotacaoCompraDAL.delete(cotacaoCompra);
                    session.Flush();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CompraRequisicaoDetalhe
        public IList<CompraRequisicaoDetalheDTO> selectCompraRequisicaoDetalhe(CompraRequisicaoDetalheDTO compraRequisicaoDetalhe)
        {
            try
            {
                IList<CompraRequisicaoDetalheDTO> resultado = null;
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    NHibernateDAL<CompraRequisicaoDetalheDTO> DAL = new NHibernateDAL<CompraRequisicaoDetalheDTO>(session);
                    resultado = DAL.select(compraRequisicaoDetalhe);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }

        #endregion 

        #region CompraPedido
        public IList<CompraPedidoDTO> selectPedidoCompra(CompraPedidoDTO pedidoCompra)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<CompraPedidoDTO> pedidoCompraDAL = new NHibernateDAL<CompraPedidoDTO>(session);
                    return pedidoCompraDAL.select(pedidoCompra);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CompraPedidoDTO selectPedidoCompraId(CompraPedidoDTO pedidoCompra)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<CompraPedidoDTO> pedidoCompraDAL = new NHibernateDAL<CompraPedidoDTO>(session);
                    CompraPedidoDTO resultado = pedidoCompraDAL.selectId<CompraPedidoDTO>((int)pedidoCompra.Id);

                    IDAL<CompraPedidoDetalheDTO> pedidoCompraDetDAL = new NHibernateDAL<CompraPedidoDetalheDTO>(session);

                    resultado.listaPedidoCompraDetalhe = pedidoCompraDetDAL.select(
                        new CompraPedidoDetalheDTO { IdCompraPedido = resultado.Id });

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CompraPedidoDTO savePedidoCompra(CompraPedidoDTO pedidoCompra)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<CompraPedidoDTO> pedidoCompraDAL = new NHibernateDAL<CompraPedidoDTO>(session);
                    CompraPedidoDTO resultado = pedidoCompraDAL.save(pedidoCompra);

                    IDAL<CompraPedidoDetalheDTO> pedidoCompraDetDAL = new NHibernateDAL<CompraPedidoDetalheDTO>(session);

                    foreach (CompraPedidoDetalheDTO pedidoDetalhe in pedidoCompra.listaPedidoCompraDetalhe)
                    {
                        pedidoDetalhe.IdCompraPedido = pedidoCompra.Id;
                        pedidoCompraDetDAL.save(pedidoDetalhe);
                    }
                    session.Flush();

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CompraPedidoDTO updatePedidoCompra(CompraPedidoDTO pedidoCompra)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<CompraPedidoDTO> pedidoCompraDAL = new NHibernateDAL<CompraPedidoDTO>(session);
                    CompraPedidoDTO resultado = pedidoCompraDAL.update(pedidoCompra);

                    IDAL<CompraPedidoDetalheDTO> pedidoCompraDetDAL = new NHibernateDAL<CompraPedidoDetalheDTO>(session);

                    IList<CompraPedidoDetalheDTO> listaDetalheExcluir = pedidoCompraDetDAL.select
                        (new CompraPedidoDetalheDTO { IdCompraPedido = pedidoCompra.Id });

                    foreach (CompraPedidoDetalheDTO pDetalhe in listaDetalheExcluir)
                    {
                        pedidoCompraDetDAL.delete(pDetalhe);
                    }

                    foreach (CompraPedidoDetalheDTO pedidoDetalhe in pedidoCompra.listaPedidoCompraDetalhe)
                    {
                        pedidoDetalhe.IdCompraPedido = pedidoCompra.Id;
                        pedidoCompraDetDAL.save(pedidoDetalhe);
                    }
                    session.Flush();

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deletePedidoCompra(CompraPedidoDTO pedidoCompra)
        {
            try
            {
                using (ISession session = NHibernateHelper.getSessionFactory().OpenSession())
                {
                    IDAL<CompraPedidoDTO> pedidoCompraDAL = new NHibernateDAL<CompraPedidoDTO>(session);
                    IDAL<CompraPedidoDetalheDTO> pedidoCompraDetDAL = new NHibernateDAL<CompraPedidoDetalheDTO>(session);

                    IList<CompraPedidoDetalheDTO> listaDetalheExcluir = pedidoCompraDetDAL.select
                        (new CompraPedidoDetalheDTO { IdCompraPedido = pedidoCompra.Id });

                    foreach (CompraPedidoDetalheDTO pDetalhe in listaDetalheExcluir)
                    {
                        pedidoCompraDetDAL.delete(pDetalhe);
                    }
                    int resultado = pedidoCompraDAL.delete(pedidoCompra);
                    session.Flush();

                    return resultado;
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
