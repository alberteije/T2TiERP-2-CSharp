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
using ContabilidadeClient.View.Contabilidade;
using ContabilidadeClient.ServicoContabilidadeReference;
using ContabilidadeClient.ViewModel.Contabilidade;

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for RegistroCartorioPrincipal.xaml
    /// </summary>
    public partial class RegistroCartorioPrincipal : UserControl
    {
        private RegistroCartorioViewModel viewModel;
        public RegistroCartorioPrincipal()
        {
            InitializeComponent();
            viewModel = new RegistroCartorioViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.RegistroCartorioSelected != null)
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
                viewModel.RegistroCartorioSelected = new RegistroCartorioDTO();
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
                if (viewModel.RegistroCartorioSelected != null)
                {
                    viewModel.excluirRegistroCartorio();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaRegistroCartorio(0);
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
