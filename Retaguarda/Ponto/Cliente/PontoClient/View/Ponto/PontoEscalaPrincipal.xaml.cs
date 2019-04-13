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
using PontoClient.ViewModel.Ponto;
using PontoClient.ServicoPontoReference;

namespace PontoClient.View.Ponto
{
    /// <summary>
    /// Interaction logic for PontoEscalaPrincipal.xaml
    /// </summary>
    public partial class PontoEscalaPrincipal : UserControl
    {
        private PontoEscalaViewModel viewModel;
        public PontoEscalaPrincipal()
        {
            InitializeComponent();
            viewModel = new PontoEscalaViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.PontoEscalaSelected != null)
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
                viewModel.PontoEscalaSelected = new PontoEscalaDTO();
                viewModel.PontoEscalaSelected.ListaPontoTurma = new List<PontoTurmaDTO>();

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
                if (viewModel.PontoEscalaSelected != null)
                {
                    viewModel.excluirPontoEscala();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaPontoEscala(0);
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
