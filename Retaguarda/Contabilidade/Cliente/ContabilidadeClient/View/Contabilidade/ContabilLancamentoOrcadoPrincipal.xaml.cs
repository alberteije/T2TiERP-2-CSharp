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
using ContabilidadeClient.ServicoContabilidadeReference;
using ContabilidadeClient.ViewModel.Contabilidade;

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for ContabilLancamentoOrcadoPrincipal.xaml
    /// </summary>
    public partial class ContabilLancamentoOrcadoPrincipal : UserControl
    {
        private ContabilLancamentoOrcadoViewModel viewModel;
        public ContabilLancamentoOrcadoPrincipal()
        {
            InitializeComponent();
            viewModel = new ContabilLancamentoOrcadoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.ContabilLancamentoOrcadoSelected != null)
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
                viewModel.ContabilLancamentoOrcadoSelected = new ContabilLancamentoOrcadoDTO();
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
                if (viewModel.ContabilLancamentoOrcadoSelected != null)
                {
                    viewModel.excluirContabilLancamentoOrcado();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaContabilLancamentoOrcado(0);
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
