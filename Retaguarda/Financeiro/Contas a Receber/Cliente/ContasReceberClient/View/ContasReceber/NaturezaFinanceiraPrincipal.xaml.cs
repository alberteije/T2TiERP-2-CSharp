using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;
using ContasReceberClient.ContasReceberService;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for NaturezaFinanceiraPrincipal.xaml
    /// </summary>
    public partial class NaturezaFinanceiraPrincipal : UserControl
    {
        private NaturezaFinanceiraViewModel viewModel;
        public NaturezaFinanceiraPrincipal()
        {
            InitializeComponent();
            viewModel = new NaturezaFinanceiraViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.NaturezaFinanceiraSelected != null)
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
                viewModel.NaturezaFinanceiraSelected = new NaturezaFinanceiraDTO();
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
                if (viewModel.NaturezaFinanceiraSelected != null)
                {
                    viewModel.excluirNaturezaFinanceira();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaNaturezaFinanceira(0);
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
