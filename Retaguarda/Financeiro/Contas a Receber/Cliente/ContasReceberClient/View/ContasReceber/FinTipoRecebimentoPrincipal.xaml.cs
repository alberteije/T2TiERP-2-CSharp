using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;
using ContasReceberClient.ContasReceberService;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for FinTipoRecebimentoPrincipal.xaml
    /// </summary>
    public partial class FinTipoRecebimentoPrincipal : UserControl
    {
        private FinTipoRecebimentoViewModel viewModel;
        public FinTipoRecebimentoPrincipal()
        {
            InitializeComponent();
            viewModel = new FinTipoRecebimentoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FinTipoRecebimentoSelected != null)
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
                viewModel.FinTipoRecebimentoSelected = new FinTipoRecebimentoDTO();
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
                if (viewModel.FinTipoRecebimentoSelected != null)
                {
                    viewModel.excluirFinTipoRecebimento();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFinTipoRecebimento(0);
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
