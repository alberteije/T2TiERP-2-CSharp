using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ViewModel.ContasPagar;
using ContasPagarClient.ContasPagarService;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for FinStatusParcelaPrincipal.xaml
    /// </summary>
    public partial class FinStatusParcelaPrincipal : UserControl
    {
        private FinStatusParcelaViewModel viewModel;
        public FinStatusParcelaPrincipal()
        {
            InitializeComponent();
            viewModel = new FinStatusParcelaViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FinStatusParcelaSelected != null)
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
                viewModel.FinStatusParcelaSelected = new FinStatusParcelaDTO();
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
                if (viewModel.FinStatusParcelaSelected != null)
                {
                    viewModel.excluirFinStatusParcela();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFinStatusParcela(0);
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
