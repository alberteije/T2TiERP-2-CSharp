using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ComprasClient.ViewModel.Compras;
using ComprasClient.ViewModel;

namespace ComprasClient.View.Compras
{
    /// <summary>
    /// Interaction logic for Pedido.xaml
    /// </summary>
    public partial class Pedido : UserControl
    {
        private PedidoViewModel viewModel;

        public Pedido()
        {
            InitializeComponent();
            viewModel = new PedidoViewModel();
            this.DataContext = viewModel;
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            ((PedidoViewModel)this.DataContext).incluir();
        }

        private void btPesquisarColaborador_Click(object sender, RoutedEventArgs e)
        {
            ((PedidoViewModel)this.DataContext).selecionarFornecedor();
        }

        private void btPesquisarTipoPedido_Click(object sender, RoutedEventArgs e)
        {
            ((PedidoViewModel)this.DataContext).selecionarTipoPedido();
        }

        private void btIncluirProduto_Click(object sender, RoutedEventArgs e)
        {
            ((PedidoViewModel)this.DataContext).selecionarProduto();
        }

        private void btExcluirProduto_Click(object sender, RoutedEventArgs e)
        {
            ((PedidoViewModel)this.DataContext).excluirPedidoDetalhe();

        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            ((PedidoViewModel)this.DataContext).cancelarOperacao();
        }

        private void btConfirmar_Click(object sender, RoutedEventArgs e)
        {
            ((PedidoViewModel)this.DataContext).executarOperacao();
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            ((PedidoViewModel)this.DataContext).excluir();
        }

        private void btAlterar_Click(object sender, RoutedEventArgs e)
        {
            ((PedidoViewModel)this.DataContext).alterar();
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectedItem = dataGrid.Items[0];
            int offset = ((PedidoViewModel)DataContext).selectedItem.Id - 1;

            string ConsultaSQL =
                            "select CP.*, CTP.NOME AS TIPO_PEDIDO_NOME, VPF.NOME AS NOME_FORNECEDOR " +
                            " from COMPRA_PEDIDO CP INNER  JOIN COMPRA_TIPO_PEDIDO" +
                            " CTP ON (CP.ID_COMPRA_TIPO_PEDIDO = CTP.ID)  " +
                            " INNER JOIN VIEW_PESSOA_FORNECEDOR VPF ON (CP.ID_FORNECEDOR = VPF.ID) " +
                            " limit " + ERPViewModelBase.QUANTIDADE_PAGINA + " offset " + offset;

            ((ERPViewModelBase)DataContext).exibirRelatorio("CompraPedido", "Pedido Compra", ConsultaSQL);

        }
    }
}
