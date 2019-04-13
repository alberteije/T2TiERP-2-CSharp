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
    /// Interaction logic for PontoClassificacaoJornadaPrincipal.xaml
    /// </summary>
    public partial class PontoClassificacaoJornadaPrincipal : UserControl
    {
        private PontoClassificacaoJornadaViewModel viewModel;
        public PontoClassificacaoJornadaPrincipal()
        {
            InitializeComponent();
            viewModel = new PontoClassificacaoJornadaViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.PontoClassificacaoJornadaSelected != null)
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
                viewModel.PontoClassificacaoJornadaSelected = new PontoClassificacaoJornadaDTO();
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
                if (viewModel.PontoClassificacaoJornadaSelected != null)
                {
                    viewModel.excluirPontoClassificacaoJornada();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaPontoClassificacaoJornada(0);
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
