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
using PatrimonioClient.ViewModel.Patrimonio;
using PatrimonioClient.ServicoPatrimonioReference;

namespace PatrimonioClient.View.Patrimonio
{
    /// <summary>
    /// Interaction logic for PatrimEstadoConservacaoPrincipal.xaml
    /// </summary>
    public partial class PatrimEstadoConservacaoPrincipal : UserControl
    {
        private PatrimEstadoConservacaoViewModel viewModel;
        public PatrimEstadoConservacaoPrincipal()
        {
            InitializeComponent();
            viewModel = new PatrimEstadoConservacaoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.PatrimEstadoConservacaoSelected != null)
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
                viewModel.PatrimEstadoConservacaoSelected = new PatrimEstadoConservacaoDTO();
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
                if (viewModel.PatrimEstadoConservacaoSelected != null)
                {
                    viewModel.excluirPatrimEstadoConservacao();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaPatrimEstadoConservacao(0);
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
