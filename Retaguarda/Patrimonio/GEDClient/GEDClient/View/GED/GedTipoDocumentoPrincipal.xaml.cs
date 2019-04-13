using System;
using System.Windows;
using System.Windows.Controls;
using GEDClient.ViewModel.GED;
using GEDClient.GEDServiceReference;

namespace GEDClient.View.GED
{
    /// <summary>
    /// Interaction logic for GedTipoDocumentoPrincipal.xaml
    /// </summary>
    public partial class GedTipoDocumentoPrincipal : UserControl
    {
        private GedTipoDocumentoViewModel viewModel;
        public GedTipoDocumentoPrincipal()
        {
            InitializeComponent();
            viewModel = new GedTipoDocumentoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.GedTipoDocumentoSelected != null)
                    viewModel.IsEditar = true;
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.GedTipoDocumentoSelected = new GedTipoDocumentoDTO();
                viewModel.IsEditar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.GedTipoDocumentoSelected != null)
                {
                    viewModel.excluirGedTipoDocumento();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaGedTipoDocumento(0);
                }                
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
