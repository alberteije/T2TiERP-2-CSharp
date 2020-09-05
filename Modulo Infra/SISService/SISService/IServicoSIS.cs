using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SISService.Model;

namespace SISService
{

    [ServiceContract]
    public interface IServicoSIS
    {

        #region Cargo
        [OperationContract]
        int DeleteCargo(CargoDTO cargo);
        [OperationContract]
        CargoDTO SalvarAtualizarCargo(CargoDTO cargo);
        [OperationContract]
        IList<CargoDTO> SelectCargo(CargoDTO cargo);
        [OperationContract]
        IList<CargoDTO> SelectCargoPagina(int primeiroResultado, int quantidadeResultados, CargoDTO cargo);
        #endregion

        #region SituacaoVendedor
        [OperationContract]
        int DeleteSituacaoVendedor(SituacaoVendedorDTO situacaoVendedor);
        [OperationContract]
        SituacaoVendedorDTO SalvarAtualizarSituacaoVendedor(SituacaoVendedorDTO situacaoVendedor);
        [OperationContract]
        IList<SituacaoVendedorDTO> SelectSituacaoVendedor(SituacaoVendedorDTO situacaoVendedor);
        [OperationContract]
        IList<SituacaoVendedorDTO> SelectSituacaoVendedorPagina(int primeiroResultado, int quantidadeResultados, SituacaoVendedorDTO situacaoVendedor);
        #endregion 

        #region CategoriaProduto
        [OperationContract]
        int DeleteCategoriaProduto(CategoriaProdutoDTO categoriaProduto);
        [OperationContract]
        CategoriaProdutoDTO SalvarAtualizarCategoriaProduto(CategoriaProdutoDTO categoriaProduto);
        [OperationContract]
        IList<CategoriaProdutoDTO> SelectCategoriaProduto(CategoriaProdutoDTO categoriaProduto);
        [OperationContract]
        IList<CategoriaProdutoDTO> SelectCategoriaProdutoPagina(int primeiroResultado, int quantidadeResultados, CategoriaProdutoDTO categoriaProduto);
        #endregion 

        #region TipoPagamento
        [OperationContract]
        int DeleteTipoPagamento(TipoPagamentoDTO tipoPagamento);
        [OperationContract]
        TipoPagamentoDTO SalvarAtualizarTipoPagamento(TipoPagamentoDTO tipoPagamento);
        [OperationContract]
        IList<TipoPagamentoDTO> SelectTipoPagamento(TipoPagamentoDTO tipoPagamento);
        [OperationContract]
        IList<TipoPagamentoDTO> SelectTipoPagamentoPagina(int primeiroResultado, int quantidadeResultados, TipoPagamentoDTO tipoPagamento);
        #endregion 

        #region LocalVenda
        [OperationContract]
        int DeleteLocalVenda(LocalVendaDTO localVenda);
        [OperationContract]
        LocalVendaDTO SalvarAtualizarLocalVenda(LocalVendaDTO localVenda);
        [OperationContract]
        IList<LocalVendaDTO> SelectLocalVenda(LocalVendaDTO localVenda);
        [OperationContract]
        IList<LocalVendaDTO> SelectLocalVendaPagina(int primeiroResultado, int quantidadeResultados, LocalVendaDTO localVenda);
        #endregion 

        #region Funcionario
        [OperationContract]
        int DeleteFuncionario(FuncionarioDTO funcionario);
        [OperationContract]
        FuncionarioDTO SalvarAtualizarFuncionario(FuncionarioDTO funcionario);
        [OperationContract]
        IList<FuncionarioDTO> SelectFuncionario(FuncionarioDTO funcionario);
        [OperationContract]
        IList<FuncionarioDTO> SelectFuncionarioPagina(int primeiroResultado, int quantidadeResultados, FuncionarioDTO funcionario);
        #endregion 

        #region Produto
        [OperationContract]
        int DeleteProduto(ProdutoDTO produto);
        [OperationContract]
        ProdutoDTO SalvarAtualizarProduto(ProdutoDTO produto);
        [OperationContract]
        IList<ProdutoDTO> SelectProduto(ProdutoDTO produto);
        [OperationContract]
        IList<ProdutoDTO> SelectProdutoPagina(int primeiroResultado, int quantidadeResultados, ProdutoDTO produto);
        #endregion 

        #region Vendedor
        [OperationContract]
        int DeleteVendedor(VendedorDTO vendedor);
        [OperationContract]
        VendedorDTO SalvarAtualizarVendedor(VendedorDTO vendedor);
        [OperationContract]
        IList<VendedorDTO> SelectVendedor(VendedorDTO vendedor);
        [OperationContract]
        IList<VendedorDTO> SelectVendedorPagina(int primeiroResultado, int quantidadeResultados, VendedorDTO vendedor);
        #endregion 



        #region Apenas Consultas

        #region Usuario
        [OperationContract]
        UsuarioDTO SelectUsuario(String login, String senha);
        #endregion

        #region ControleAcesso
        [OperationContract]
        IList<ViewControleAcessoDTO> SelectControleAcesso(ViewControleAcessoDTO viewControleAcesso);
        #endregion

        #endregion

    }

}
