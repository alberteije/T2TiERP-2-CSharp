using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;
using ContasReceberClient.ContasReceberService;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for FinConfiguracaoBoletoPrincipal.xaml
    /// </summary>
    public partial class FinConfiguracaoBoletoPrincipal : UserControl
    {
        private FinConfiguracaoBoletoViewModel viewModel;
        public FinConfiguracaoBoletoPrincipal()
        {
            InitializeComponent();
            viewModel = new FinConfiguracaoBoletoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FinConfiguracaoBoletoSelected != null)
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
                viewModel.FinConfiguracaoBoletoSelected = new FinConfiguracaoBoletoDTO();
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
                if (viewModel.FinConfiguracaoBoletoSelected != null)
                {
                    viewModel.excluirFinConfiguracaoBoleto();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFinConfiguracaoBoleto(0);
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
