using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ViewModel.ContasPagar;
using ContasPagarClient.ContasPagarService;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for FinTipoPagamentoPrincipal.xaml
    /// </summary>
    public partial class FinTipoPagamentoPrincipal : UserControl
    {
        private FinTipoPagamentoViewModel viewModel;
        public FinTipoPagamentoPrincipal()
        {
            InitializeComponent();
            viewModel = new FinTipoPagamentoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FinTipoPagamentoSelected != null)
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
                viewModel.FinTipoPagamentoSelected = new FinTipoPagamentoDTO();
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
                if (viewModel.FinTipoPagamentoSelected != null)
                {
                    viewModel.excluirFinTipoPagamento();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFinTipoPagamento(0);
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
