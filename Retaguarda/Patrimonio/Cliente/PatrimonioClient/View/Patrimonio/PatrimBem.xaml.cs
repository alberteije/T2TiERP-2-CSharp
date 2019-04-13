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

namespace PatrimonioClient.View.Patrimonio
{
    /// <summary>
    /// Interaction logic for PatrimBem.xaml
    /// </summary>
    public partial class PatrimBem : UserControl
    {
        public PatrimBem()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PatrimBemViewModel)this.DataContext).IsEditar= false;
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
                ((PatrimBemViewModel)this.DataContext).salvarAtualizarPatrimBem();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((PatrimBemViewModel)this.DataContext).atualizarListaPatrimBem(0);
                ((PatrimBemViewModel)this.DataContext).IsEditar = false;
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
                ((PatrimBemViewModel)DataContext).pesquisarColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarFornecedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PatrimBemViewModel)DataContext).pesquisarFornecedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
		
		private void btPesquisarSetor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PatrimBemViewModel)DataContext).pesquisarSetor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
		
		private void btPesquisarPatrimGrupoBem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PatrimBemViewModel)DataContext).pesquisarPatrimGrupoBem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarPatrimEstadoConservacao_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PatrimBemViewModel)DataContext).pesquisarPatrimEstadoConservacao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarPatrimTipoAquisicaoBem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PatrimBemViewModel)DataContext).pesquisarPatrimTipoAquisicaoBem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}
