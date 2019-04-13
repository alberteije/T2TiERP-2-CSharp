using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;
using ContasReceberClient.ContasReceberService;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for PlanoNaturezaFinanceiraPrincipal.xaml
    /// </summary>
    public partial class PlanoNaturezaFinanceiraPrincipal : UserControl
    {
        private PlanoNaturezaFinanceiraViewModel viewModel;
        public PlanoNaturezaFinanceiraPrincipal()
        {
            InitializeComponent();
            viewModel = new PlanoNaturezaFinanceiraViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.PlanoNaturezaFinanceiraSelected != null)
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
                viewModel.PlanoNaturezaFinanceiraSelected = new PlanoNaturezaFinanceiraDTO();
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
                if (viewModel.PlanoNaturezaFinanceiraSelected != null)
                {
                    viewModel.excluirPlanoNaturezaFinanceira();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaPlanoNaturezaFinanceira(0);
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
