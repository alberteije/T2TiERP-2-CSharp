using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComprasClient.ComprasService;
using System.Collections.ObjectModel;
using SearchWindow;
using ComprasClient.Model;

namespace ComprasClient.ViewModel.Compras
{
    public class PedidoViewModel : ERPViewModelBase
    {
        public Operacao operacao { get; set; }
        public string textoPesquisa { get; set; }
        private bool _isSelectedTabPrincipal;
        private bool _isSelectedTabOperacoes;
        private CompraPedidoDTO _selectedItem;
        private CompraPedidoDetalheDTO _selectedItemDetalhe;
        public ObservableCollection<CompraPedidoDTO> listaPedido { get; set; }
        public ObservableCollection<CompraPedidoDetalheDTO> listaPedidoDetalhe { get; set; }

        /// EXERCICIO: 
        /// PERGUNTAR SE O USUÁRIO DESEJA LANÇAR NO CONTAS A PAGAR E 
        /// IDENTIFICAR SE JA EXISTE UM LANÇAMENTO E AGIR DE ACORDO COM A SUA REALIDADE
        ///  01-APAGAR O LANCAMENTO ANTERIOR E INSERIR O NOVO
        ///  02-ALTERAR O LANCAMENTO ANTERIOR
        ///  03-NAO FAZER NADA, APENAS DEIXAR O LANCAMENTO ANTERIOR
        ///  04-SOLICITAR UMA SOLUCAO PARA O USUÁRIO


        public PedidoViewModel()
        {
            listaPedido = new ObservableCollection<CompraPedidoDTO>();
            isSelectedTabPrincipal = true;
        }

        public void executarOperacao()
        {
            try
            {
                using (ComprasServiceClient comprasService = new ComprasServiceClient())
                {
                    if (operacao == Operacao.Incluir)
                    {
                        selectedItem.listaPedidoCompraDetalhe = listaPedidoDetalhe.ToList();
                        comprasService.savePedidoCompra(selectedItem);
                    }
                    if (operacao == Operacao.Excluir)
                    {
                        comprasService.deletePedidoCompra(selectedItem);
                    }
                    if (operacao == Operacao.Alterar)
                    {
                        selectedItem.listaPedidoCompraDetalhe = listaPedidoDetalhe.ToList();
                        comprasService.updatePedidoCompra(selectedItem);
                    }
                }
                isSelectedTabPrincipal = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cancelarOperacao()
        {
            isSelectedTabPrincipal = true;
        }

        public void selecionarTipoPedido()
        {
            SearchWindowApp searchWindow = new SearchWindowApp(typeof(CompraTipoPedidoDTO), typeof(ServicoCompras));

            if (searchWindow.ShowDialog() == true)
            {
                selectedItem.CompraTipoPedido = (CompraTipoPedidoDTO)searchWindow.itemSelecionado;
                notifyPropertyChanged("selectedItem");
            }
        }

        public void selecionarFornecedor()
        {
            SearchWindowApp searchWindow = new SearchWindowApp(typeof(ViewPessoaFornecedorDTO), typeof(ServicoCompras));

            if (searchWindow.ShowDialog() == true)
            {
                selectedItem.Fornecedor = (ViewPessoaFornecedorDTO)searchWindow.itemSelecionado;
                notifyPropertyChanged("selectedItem");
            }
        }

        public void selecionarProduto()
        {
            SearchWindowApp searchWindow = new SearchWindowApp(typeof(ProdutoDTO), typeof(ServicoCompras));

            if (searchWindow.ShowDialog() == true)
            {
                CompraPedidoDetalheDTO pedidoDetalhe = new CompraPedidoDetalheDTO();
                pedidoDetalhe.Produto = (ProdutoDTO)searchWindow.itemSelecionado;
                listaPedidoDetalhe.Add(pedidoDetalhe);
                notifyPropertyChanged("listaPedidoDetalhe");
            }
        }

        public void incluir()
        {
            operacao = Operacao.Incluir;
            selectedItem = new CompraPedidoDTO();
            selectedItem.TipoFrete = "F";
            selectedItem.FormaPagamento = "V";
            selectedItem.listaPedidoCompraDetalhe = new List<CompraPedidoDetalheDTO>();
            listaPedidoDetalhe = new ObservableCollection<CompraPedidoDetalheDTO>();
            isSelectedTabOperacoes = true;
            notifyPropertyChanged("selectedItem");
            notifyPropertyChanged("hasListaPedido");
        }

        public void excluir()
        {
            try
            {
                operacao = Operacao.Excluir;
                carregarPedido();
                isSelectedTabOperacoes = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void alterar()
        {
            try
            {
                operacao = Operacao.Alterar;
                carregarPedido();
                isSelectedTabOperacoes = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void carregarPedido()
        {
            try
            {
                using (ComprasServiceClient comprasService = new ComprasServiceClient())
                {
                    selectedItem = comprasService.selectPedidoCompraId(selectedItem);
                    listaPedidoDetalhe = new ObservableCollection<CompraPedidoDetalheDTO>(
                        selectedItem.listaPedidoCompraDetalhe);
                    notifyPropertyChanged("selectedItem");
                    notifyPropertyChanged("listaPedidoDetalhe");
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void excluirPedidoDetalhe()
        {
            listaPedidoDetalhe.Remove(selectedItemDetalhe);
        }

        public CompraPedidoDTO selectedItem
        {
            get { return _selectedItem; }
            set 
            { 
                _selectedItem = value;
                notifyPropertyChanged("isSelectedItem");
            }
        }

        public CompraPedidoDetalheDTO selectedItemDetalhe
        {
            get { return _selectedItemDetalhe; }
            set {
                _selectedItemDetalhe = value;
                notifyPropertyChanged("isSelectedItemDetalhe");
            }
        }

        public bool isSelectedTabPrincipal
        {
            get { return _isSelectedTabPrincipal; }
            set
            {
                _isSelectedTabPrincipal = value;
                if (value)
                {
                    textoPesquisa = null;
                    atualizarListaPedido();
                }

                notifyPropertyChanged("isSelectedTabPrincipal");
            }
        }

        public bool isSelectedTabOperacoes
        {
            get { return _isSelectedTabOperacoes; }
            set
            {
                _isSelectedTabOperacoes = value;
                notifyPropertyChanged("isSelectedTabOperacoes");
            }
        }

        private void atualizarListaPedido()
        {
            try
            {
                using (ComprasServiceClient comprasService = new ComprasServiceClient())
                {
                    List<CompraPedidoDTO> listaResultado = comprasService.selectPedidoCompra(
                        new CompraPedidoDTO());
                    listaPedido.Clear();
                    foreach (CompraPedidoDTO pedido in listaResultado)
                        listaPedido.Add(pedido);
                }
                notifyPropertyChanged("listaPedido");
                notifyPropertyChanged("hasListaPedido");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool hasListaPedido
        {
            get { return listaPedido.Count > 0; }
        }

        public bool isSelectedItem
        {
            get { return _selectedItem != null; }
        }

        public bool isSelectedItemDetalhe
        {
            get { return _selectedItemDetalhe != null; }
        }
    }
}
