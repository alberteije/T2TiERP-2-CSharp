using System.Windows;
using System.Windows.Controls;
using ComprasClient.ViewModel.Compras;
using ExportarParaArquivo.Control;
using ComprasClient.ViewModel;

namespace ComprasClient.View.Compras
{
    /// <summary>
    /// Interaction logic for Cotacao.xaml
    /// </summary>
    public partial class Cotacao : UserControl
    {
        private CotacaoViewModel viewModel;
        public Cotacao()
        {
            InitializeComponent();
            viewModel = new CotacaoViewModel();
            this.DataContext = viewModel;
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).exportarDataGrid(
                (ExportarParaArquivo.Formato)((ButtonExport)sender).ExportFileFormat,
                (DataGrid)((ButtonExport)sender).ExportDataGridSource);
        }

        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).pesquisar();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).incluir();
        }

        private void btIncluirFornecedor_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).incluirFornecedor();
        }

        private void btExcluirFornecedor_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).excluirFornecedor();
        }

        private void btIncluirCotacaoDetalhe_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).incluirCotacaoDetalhe();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).cancelarOperacao();
        }

        private void btConfirmar_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).executarOperacao();
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).excluir();
        }

        private void btAlterar_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).alterar();
        }

        private void btConfirmarC_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).confirmarCotacao();
        }

        private void btImportar_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).importar();
        }

        private void btExcluirCotacaoDetalhe_Click(object sender, RoutedEventArgs e)
        {
            ((CotacaoViewModel)this.DataContext).excluirCotacaoDetalhe();
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectedItem = dataGrid.Items[0];
            int offset = ((CotacaoViewModel)DataContext).selectedItem.Id - 1;

            string ConsultaSQL =
                            "select * from COMPRA_COTACAO order by ID limit " + ERPViewModelBase.QUANTIDADE_PAGINA + " offset " + offset;

            ((ERPViewModelBase)DataContext).exibirRelatorio("CompraCotacao", "Cotacao Compra", ConsultaSQL);

        }
    }
}
