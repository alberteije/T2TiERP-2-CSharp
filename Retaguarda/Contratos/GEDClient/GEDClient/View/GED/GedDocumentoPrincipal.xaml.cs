using System.Windows;
using System.Windows.Controls;
using GEDClient.ViewModel.GED;
using GEDClient.ViewModel;

namespace GEDClient.View.GED
{
    /// <summary>
    /// Interaction logic for GEDPrincipal.xaml
    /// </summary>
    public partial class GedDocumentoPrincipal : UserControl
    {
        private GEDClientViewModel gedClientViewModel;
        public GedDocumentoPrincipal()
        {
            InitializeComponent();
            this.gedClientViewModel = new GEDClientViewModel();
            DataContext = gedClientViewModel;

        }

        private void btPesquisarDoc_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.pesquisarDocumento();
        }

        private void btIncluirDoc_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.carregarIncluirDocumento();
        }

        private void btVisualizar_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.visualizarDocumento();
        }

        private void btExcluirDoc_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.carregarExcluirDocumento();
        }

        private void btAlterarDoc_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.carregarAlterarDocumento();
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectedItem = dataGrid.Items[0];
            int offset = ((GEDClientViewModel)DataContext).DocumentoSelected.Id - 1;

            string ConsultaSQL = "select * from GED_DOCUMENTO limit " + ERPViewModelBase.QUANTIDADE_PAGINA + " offset " + offset;

            ((ERPViewModelBase)DataContext).exibirRelatorio("GedDocumento", "GED - Documento", ConsultaSQL);
        }
    }
}
