using System;
using System.Windows;
using System.Windows.Controls;
using ComprasClient.ViewModel.Compras;
using ComprasClient.ComprasService;

namespace ComprasClient.View.Compras
{
    /// <summary>
    /// Interaction logic for CompraTipoRequisicaoPrincipal.xaml
    /// </summary>
    public partial class CompraTipoRequisicaoPrincipal : UserControl
    {
        private CompraTipoRequisicaoViewModel viewModel;
        public CompraTipoRequisicaoPrincipal()
        {
            InitializeComponent();
            viewModel = new CompraTipoRequisicaoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.CompraTipoRequisicaoSelected != null)
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
                viewModel.CompraTipoRequisicaoSelected = new CompraTipoRequisicaoDTO();
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
                if (viewModel.CompraTipoRequisicaoSelected != null)
                {
                    viewModel.excluirCompraTipoRequisicao();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaCompraTipoRequisicao(0);
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
