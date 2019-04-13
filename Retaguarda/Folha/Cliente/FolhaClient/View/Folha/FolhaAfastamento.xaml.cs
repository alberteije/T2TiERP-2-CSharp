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
    /// Interaction logic for FolhaAfastamento.xaml
    /// </summary>
    public partial class FolhaAfastamento : UserControl
    {
        public FolhaAfastamento()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FolhaAfastamentoViewModel)this.DataContext).IsEditar= false;
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
                ((FolhaAfastamentoViewModel)this.DataContext).salvarAtualizarFolhaAfastamento();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FolhaAfastamentoViewModel)this.DataContext).atualizarListaFolhaAfastamento(0);
                ((FolhaAfastamentoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarFolhaTipoAfastamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FolhaAfastamentoViewModel)DataContext).pesquisarFolhaTipoAfastamento();
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
                ((FolhaAfastamentoViewModel)DataContext).pesquisarColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
