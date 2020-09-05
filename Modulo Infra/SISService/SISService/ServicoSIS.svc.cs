using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SISService.Model;
using SISService.NHibernate;
using NHibernate;

namespace SISService
{
    public class ServicoSIS : IServicoSIS
    {

        #region Cargo
        public int DeleteCargo(CargoDTO cargo)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CargoDTO> DAL = new NHibernateDAL<CargoDTO>(Session);
                    DAL.Delete(cargo);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CargoDTO SalvarAtualizarCargo(CargoDTO cargo)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CargoDTO> DAL = new NHibernateDAL<CargoDTO>(Session);
                    DAL.SaveOrUpdate(cargo);
                    Session.Flush();
                }
                return cargo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CargoDTO> SelectCargo(CargoDTO cargo)
        {
            try
            {
                IList<CargoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CargoDTO> DAL = new NHibernateDAL<CargoDTO>(Session);
                    Resultado = DAL.Select(cargo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CargoDTO> SelectCargoPagina(int primeiroResultado, int quantidadeResultados, CargoDTO cargo)
        {
            try
            {
                IList<CargoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CargoDTO> DAL = new NHibernateDAL<CargoDTO>(Session);
                    Resultado = DAL.SelectPagina<CargoDTO>(primeiroResultado, quantidadeResultados, cargo);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion 

        #region SituacaoVendedor
        public int DeleteSituacaoVendedor(SituacaoVendedorDTO situacaoVendedor)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<SituacaoVendedorDTO> DAL = new NHibernateDAL<SituacaoVendedorDTO>(Session);
                    DAL.Delete(situacaoVendedor);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public SituacaoVendedorDTO SalvarAtualizarSituacaoVendedor(SituacaoVendedorDTO situacaoVendedor)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<SituacaoVendedorDTO> DAL = new NHibernateDAL<SituacaoVendedorDTO>(Session);
                    DAL.SaveOrUpdate(situacaoVendedor);
                    Session.Flush();
                }
                return situacaoVendedor;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<SituacaoVendedorDTO> SelectSituacaoVendedor(SituacaoVendedorDTO situacaoVendedor)
        {
            try
            {
                IList<SituacaoVendedorDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<SituacaoVendedorDTO> DAL = new NHibernateDAL<SituacaoVendedorDTO>(Session);
                    Resultado = DAL.Select(situacaoVendedor);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<SituacaoVendedorDTO> SelectSituacaoVendedorPagina(int primeiroResultado, int quantidadeResultados, SituacaoVendedorDTO situacaoVendedor)
        {
            try
            {
                IList<SituacaoVendedorDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<SituacaoVendedorDTO> DAL = new NHibernateDAL<SituacaoVendedorDTO>(Session);
                    Resultado = DAL.SelectPagina<SituacaoVendedorDTO>(primeiroResultado, quantidadeResultados, situacaoVendedor);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region CategoriaProduto
        public int DeleteCategoriaProduto(CategoriaProdutoDTO categoriaProduto)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CategoriaProdutoDTO> DAL = new NHibernateDAL<CategoriaProdutoDTO>(Session);
                    DAL.Delete(categoriaProduto);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public CategoriaProdutoDTO SalvarAtualizarCategoriaProduto(CategoriaProdutoDTO categoriaProduto)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CategoriaProdutoDTO> DAL = new NHibernateDAL<CategoriaProdutoDTO>(Session);
                    DAL.SaveOrUpdate(categoriaProduto);
                    Session.Flush();
                }
                return categoriaProduto;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CategoriaProdutoDTO> SelectCategoriaProduto(CategoriaProdutoDTO categoriaProduto)
        {
            try
            {
                IList<CategoriaProdutoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CategoriaProdutoDTO> DAL = new NHibernateDAL<CategoriaProdutoDTO>(Session);
                    Resultado = DAL.Select(categoriaProduto);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<CategoriaProdutoDTO> SelectCategoriaProdutoPagina(int primeiroResultado, int quantidadeResultados, CategoriaProdutoDTO categoriaProduto)
        {
            try
            {
                IList<CategoriaProdutoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<CategoriaProdutoDTO> DAL = new NHibernateDAL<CategoriaProdutoDTO>(Session);
                    Resultado = DAL.SelectPagina<CategoriaProdutoDTO>(primeiroResultado, quantidadeResultados, categoriaProduto);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region TipoPagamento
        public int DeleteTipoPagamento(TipoPagamentoDTO tipoPagamento)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoPagamentoDTO> DAL = new NHibernateDAL<TipoPagamentoDTO>(Session);
                    DAL.Delete(tipoPagamento);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public TipoPagamentoDTO SalvarAtualizarTipoPagamento(TipoPagamentoDTO tipoPagamento)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoPagamentoDTO> DAL = new NHibernateDAL<TipoPagamentoDTO>(Session);
                    DAL.SaveOrUpdate(tipoPagamento);
                    Session.Flush();
                }
                return tipoPagamento;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TipoPagamentoDTO> SelectTipoPagamento(TipoPagamentoDTO tipoPagamento)
        {
            try
            {
                IList<TipoPagamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoPagamentoDTO> DAL = new NHibernateDAL<TipoPagamentoDTO>(Session);
                    Resultado = DAL.Select(tipoPagamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<TipoPagamentoDTO> SelectTipoPagamentoPagina(int primeiroResultado, int quantidadeResultados, TipoPagamentoDTO tipoPagamento)
        {
            try
            {
                IList<TipoPagamentoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<TipoPagamentoDTO> DAL = new NHibernateDAL<TipoPagamentoDTO>(Session);
                    Resultado = DAL.SelectPagina<TipoPagamentoDTO>(primeiroResultado, quantidadeResultados, tipoPagamento);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region LocalVenda
        public int DeleteLocalVenda(LocalVendaDTO localVenda)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<LocalVendaDTO> DAL = new NHibernateDAL<LocalVendaDTO>(Session);
                    DAL.Delete(localVenda);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public LocalVendaDTO SalvarAtualizarLocalVenda(LocalVendaDTO localVenda)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<LocalVendaDTO> DAL = new NHibernateDAL<LocalVendaDTO>(Session);
                    DAL.SaveOrUpdate(localVenda);
                    Session.Flush();
                }
                return localVenda;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<LocalVendaDTO> SelectLocalVenda(LocalVendaDTO localVenda)
        {
            try
            {
                IList<LocalVendaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<LocalVendaDTO> DAL = new NHibernateDAL<LocalVendaDTO>(Session);
                    Resultado = DAL.Select(localVenda);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<LocalVendaDTO> SelectLocalVendaPagina(int primeiroResultado, int quantidadeResultados, LocalVendaDTO localVenda)
        {
            try
            {
                IList<LocalVendaDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<LocalVendaDTO> DAL = new NHibernateDAL<LocalVendaDTO>(Session);
                    Resultado = DAL.SelectPagina<LocalVendaDTO>(primeiroResultado, quantidadeResultados, localVenda);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Funcionario
        public int DeleteFuncionario(FuncionarioDTO funcionario)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FuncionarioDTO> DAL = new NHibernateDAL<FuncionarioDTO>(Session);
                    DAL.Delete(funcionario);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public FuncionarioDTO SalvarAtualizarFuncionario(FuncionarioDTO funcionario)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FuncionarioDTO> DAL = new NHibernateDAL<FuncionarioDTO>(Session);
                    DAL.SaveOrUpdate(funcionario);
                    Session.Flush();
                }
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FuncionarioDTO> SelectFuncionario(FuncionarioDTO funcionario)
        {
            try
            {
                IList<FuncionarioDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FuncionarioDTO> DAL = new NHibernateDAL<FuncionarioDTO>(Session);
                    Resultado = DAL.Select(funcionario);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<FuncionarioDTO> SelectFuncionarioPagina(int primeiroResultado, int quantidadeResultados, FuncionarioDTO funcionario)
        {
            try
            {
                IList<FuncionarioDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<FuncionarioDTO> DAL = new NHibernateDAL<FuncionarioDTO>(Session);
                    Resultado = DAL.SelectPagina<FuncionarioDTO>(primeiroResultado, quantidadeResultados, funcionario);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Produto
        public int DeleteProduto(ProdutoDTO produto)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);
                    DAL.Delete(produto);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public ProdutoDTO SalvarAtualizarProduto(ProdutoDTO produto)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);
                    DAL.SaveOrUpdate(produto);
                    Session.Flush();
                }
                return produto;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ProdutoDTO> SelectProduto(ProdutoDTO produto)
        {
            try
            {
                IList<ProdutoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);
                    Resultado = DAL.Select(produto);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<ProdutoDTO> SelectProdutoPagina(int primeiroResultado, int quantidadeResultados, ProdutoDTO produto)
        {
            try
            {
                IList<ProdutoDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ProdutoDTO> DAL = new NHibernateDAL<ProdutoDTO>(Session);
                    Resultado = DAL.SelectPagina<ProdutoDTO>(primeiroResultado, quantidadeResultados, produto);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 

        #region Vendedor
        public int DeleteVendedor(VendedorDTO vendedor)
        {
            try
            {
                int Resultado = -1;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<VendedorDTO> DAL = new NHibernateDAL<VendedorDTO>(Session);
                    DAL.Delete(vendedor);
                    Session.Flush();
                    Resultado = 0;
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public VendedorDTO SalvarAtualizarVendedor(VendedorDTO vendedor)
        {
            try
            {
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<VendedorDTO> DAL = new NHibernateDAL<VendedorDTO>(Session);
                    DAL.SaveOrUpdate(vendedor);
                    Session.Flush();
                }
                return vendedor;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<VendedorDTO> SelectVendedor(VendedorDTO vendedor)
        {
            try
            {
                IList<VendedorDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<VendedorDTO> DAL = new NHibernateDAL<VendedorDTO>(Session);
                    Resultado = DAL.Select(vendedor);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        public IList<VendedorDTO> SelectVendedorPagina(int primeiroResultado, int quantidadeResultados, VendedorDTO vendedor)
        {
            try
            {
                IList<VendedorDTO> Resultado = null;
                using (ISession Session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<VendedorDTO> DAL = new NHibernateDAL<VendedorDTO>(Session);
                    Resultado = DAL.SelectPagina<VendedorDTO>(primeiroResultado, quantidadeResultados, vendedor);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }


        #endregion 



        #region Apenas Consultas

        #region Usuario
        public UsuarioDTO SelectUsuario(String login, String senha)
        {
            try
            {
                UsuarioDTO Resultado = null;
                using (ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    UsuarioDAL DAL = new UsuarioDAL(session);
                    Resultado = DAL.Select(login, senha);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }
        }
        #endregion

        #region ControleAcesso
        public IList<ViewControleAcessoDTO> SelectControleAcesso(ViewControleAcessoDTO viewControleAcesso)
        {
            try
            {
                IList<ViewControleAcessoDTO> Resultado = null;
                using (ISession session = NHibernateHelper.GetSessionFactory().OpenSession())
                {
                    NHibernateDAL<ViewControleAcessoDTO> DAL = new NHibernateDAL<ViewControleAcessoDTO>(session);
                    Resultado = DAL.Select(viewControleAcesso);
                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + (ex.InnerException != null ? " " + ex.InnerException.Message : ""));
            }

        }
        #endregion

        #endregion

    }
}
