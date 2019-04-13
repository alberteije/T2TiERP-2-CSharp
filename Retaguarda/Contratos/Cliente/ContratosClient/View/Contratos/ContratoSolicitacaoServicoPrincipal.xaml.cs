using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContratosClient.ViewModel.Contratos;
using ContratosClient.ContratosReference;

namespace ContratosClient.View.Contratos
{
    /// <summary>
    /// Interaction logic for ContratoSolicitacaoServicoPrincipal.xaml
    /// </summary>
    public partial class ContratoSolicitacaoServicoPrincipal : UserControl
    {
        private ContratoSolicitacaoServicoViewModel viewModel;
        public ContratoSolicitacaoServicoPrincipal()
        {
            InitializeComponent();
            viewModel = new ContratoSolicitacaoServicoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.ContratoSolicitacaoServicoSelected != null)
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
                viewModel.ContratoSolicitacaoServicoSelected = new ContratoSolicitacaoServicoDTO();
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
                if (viewModel.ContratoSolicitacaoServicoSelected != null)
                {
                    viewModel.excluirContratoSolicitacaoServico();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaContratoSolicitacaoServico(0);
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
