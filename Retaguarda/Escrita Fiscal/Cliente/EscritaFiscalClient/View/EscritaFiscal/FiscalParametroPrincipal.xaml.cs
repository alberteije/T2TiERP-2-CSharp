using System;
using System.Windows;
using System.Windows.Controls;
using EscritaFiscalClient.ViewModel.EscritaFiscal;
using EscritaFiscalClient.ServicoEscritaFiscalReference;

namespace EscritaFiscalClient.View.EscritaFiscal
{
    /// <summary>
    /// Interaction logic for FiscalParametroPrincipal.xaml
    /// </summary>
    public partial class FiscalParametroPrincipal : UserControl
    {
        private FiscalParametroViewModel viewModel;
        public FiscalParametroPrincipal()
        {
            InitializeComponent();
            viewModel = new FiscalParametroViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FiscalParametroSelected != null)
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
                viewModel.FiscalParametroSelected = new FiscalParametroDTO();
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
                if (viewModel.FiscalParametroSelected != null)
                {
                    viewModel.excluirFiscalParametro();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFiscalParametro(0);
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
