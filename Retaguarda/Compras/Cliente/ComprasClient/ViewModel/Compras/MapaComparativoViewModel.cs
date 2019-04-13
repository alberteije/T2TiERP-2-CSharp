using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComprasClient.ComprasService;
using System.Collections.ObjectModel;
using ExportarParaArquivo;

namespace ComprasClient.ViewModel.Compras
{
    public class MapaComparativoViewModel : ERPViewModelBase
    {
        public Operacao operacao { get; set; }
        public string textoPesquisa { get; set; }
        public ObservableCollection<CompraCotacaoDTO> listaCotacao { get; set; }
        private bool _isSelectedTabPrincipal;
        private bool _isSelectedTabOperacoes;
        private CompraCotacaoDTO _selectedItem;

        public MapaComparativoViewModel()
        {
            listaCotacao = new ObservableCollection<CompraCotacaoDTO>();
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
                        foreach (CompraFornecedorCotacaoDTO fornecedor in selectedItem.listaFornecedor)
                        {
                            CompraPedidoDTO pedido = new CompraPedidoDTO();
                            pedido.listaPedidoCompraDetalhe = new List<CompraPedidoDetalheDTO>();
                            pedido.Fornecedor = fornecedor.Fornecedor;
                            pedido.CompraTipoPedido = new CompraTipoPedidoDTO { Id = 1 };
                            foreach (CompraCotacaoDetalheDTO cotacaoDetalhe in fornecedor.listaCotacaoCompraDetalhe)
                            {
                                if (cotacaoDetalhe.QuantidadePedida != null &&
                                    cotacaoDetalhe.QuantidadePedida > 0)
                                {
                                    CompraPedidoDetalheDTO pedidoDetalhe = new CompraPedidoDetalheDTO();
                                    pedidoDetalhe.Produto = cotacaoDetalhe.Produto;
                                    pedidoDetalhe.Quantidade = cotacaoDetalhe.QuantidadePedida;
                                    pedidoDetalhe.ValorUnitario = cotacaoDetalhe.ValorUnitario;
                                    pedido.listaPedidoCompraDetalhe.Add(pedidoDetalhe);
                                }
                            }
                            if (pedido.listaPedidoCompraDetalhe.Count > 0)
                                comprasService.savePedidoCompra(pedido);
                        }
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

        public void pesquisar()
        {
            atualizarListaCotacao();
        }

        public void incluir()
        {
            operacao = Operacao.Incluir;
            selecionarCotacaoCompleta();
            isSelectedTabOperacoes = true;
        }

        private void selecionarCotacaoCompleta()
        {
            try
            {
                using (ComprasServiceClient comprasService = new ComprasServiceClient())
                {
                    selectedItem = comprasService.selectCotacaoCompraId(selectedItem);
                }
                notifyPropertyChanged("selectedItem");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool hasListaCotacao
        {
            get { return listaCotacao.Count > 0; }
        }

        public bool isSelectedItem
        {
            get { return _selectedItem != null; }
        }

        public CompraCotacaoDTO selectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                notifyPropertyChanged("selectedItem");
                notifyPropertyChanged("isSelectedItem");
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
                    atualizarListaCotacao();
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

        private void atualizarListaCotacao()
        {
            try
            {
                using (ComprasServiceClient comprasService = new ComprasServiceClient())
                {
                    List<CompraCotacaoDTO> listaResultado = comprasService.selectCotacaoCompra(
                        new CompraCotacaoDTO { Descricao = textoPesquisa });
                    listaCotacao.Clear();
                    foreach (CompraCotacaoDTO cotacao in listaResultado)
                        listaCotacao.Add(cotacao);
                }
                notifyPropertyChanged("listaCotacao");
                notifyPropertyChanged("hasListaCotacao");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void exportarDataGrid(ExportarParaArquivo.Formato formato, System.Windows.Controls.DataGrid dg)
        {
            Exportar exportar = new Exportar(formato);
            exportar.exportarDataGrid(dg);
        }
    }
}
