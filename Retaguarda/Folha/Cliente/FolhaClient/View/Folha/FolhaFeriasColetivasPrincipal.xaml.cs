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
using FolhaClient.ViewModel.Folha;
using FolhaClient.ServicoFolhaReference;

namespace FolhaClient.View.Folha
{
    /// <summary>
    /// Interaction logic for FolhaFeriasColetivasPrincipal.xaml
    /// </summary>
    public partial class FolhaFeriasColetivasPrincipal : UserControl
    {
        private FolhaFeriasColetivasViewModel viewModel;
        public FolhaFeriasColetivasPrincipal()
        {
            InitializeComponent();
            viewModel = new FolhaFeriasColetivasViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FolhaFeriasColetivasSelected != null)
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
                viewModel.FolhaFeriasColetivasSelected = new FolhaFeriasColetivasDTO();
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
                if (viewModel.FolhaFeriasColetivasSelected != null)
                {
                    viewModel.excluirFolhaFeriasColetivas();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFolhaFeriasColetivas(0);
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
