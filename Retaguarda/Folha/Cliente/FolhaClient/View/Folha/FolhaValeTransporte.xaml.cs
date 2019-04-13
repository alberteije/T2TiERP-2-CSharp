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

namespace FolhaClient.View.Folha
{
    /// <summary>
    /// Interaction logic for FolhaValeTransporte.xaml
    /// </summary>
    public partial class FolhaValeTransporte : UserControl
    {
        public FolhaValeTransporte()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FolhaValeTransporteViewModel)this.DataContext).IsEditar= false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FolhaValeTransporteViewModel)this.DataContext).salvarAtualizarFolhaValeTransporte();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FolhaValeTransporteViewModel)this.DataContext).atualizarListaFolhaValeTransporte(0);
                ((FolhaValeTransporteViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarColaborador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FolhaValeTransporteViewModel)DataContext).pesquisarColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarEmpresaTransporteItinerario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FolhaValeTransporteViewModel)DataContext).pesquisarEmpresaTransporteItinerario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
