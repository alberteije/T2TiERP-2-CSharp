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
    /// Interaction logic for FeriasPeriodoAquisitivoPrincipal.xaml
    /// </summary>
    public partial class FeriasPeriodoAquisitivoPrincipal : UserControl
    {
        private FeriasPeriodoAquisitivoViewModel viewModel;
        public FeriasPeriodoAquisitivoPrincipal()
        {
            InitializeComponent();
            viewModel = new FeriasPeriodoAquisitivoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FeriasPeriodoAquisitivoSelected != null)
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
                viewModel.FeriasPeriodoAquisitivoSelected = new FeriasPeriodoAquisitivoDTO();
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
                if (viewModel.FeriasPeriodoAquisitivoSelected != null)
                {
                    viewModel.excluirFeriasPeriodoAquisitivo();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFeriasPeriodoAquisitivo(0);
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
