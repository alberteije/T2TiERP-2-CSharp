using System;
using System.Windows;
using System.Windows.Controls;
using ComprasClient.ViewModel.Compras;
using ComprasClient.ComprasService;

namespace ComprasClient.View.Compras
{
    /// <summary>
    /// Interaction logic for CompraTipoPedidoPrincipal.xaml
    /// </summary>
    public partial class CompraTipoPedidoPrincipal : UserControl
    {
        private CompraTipoPedidoViewModel viewModel;
        public CompraTipoPedidoPrincipal()
        {
            InitializeComponent();
            viewModel = new CompraTipoPedidoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.CompraTipoPedidoSelected != null)
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
                viewModel.CompraTipoPedidoSelected = new CompraTipoPedidoDTO();
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
                if (viewModel.CompraTipoPedidoSelected != null)
                {
                    viewModel.excluirCompraTipoPedido();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaCompraTipoPedido(0);
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
