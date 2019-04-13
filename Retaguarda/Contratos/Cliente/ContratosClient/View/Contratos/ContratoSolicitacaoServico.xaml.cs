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
using ContratosClient.ViewModel.Contratos;

namespace ContratosClient.View.Contratos
{
    /// <summary>
    /// Interaction logic for ContratoSolicitacaoServico.xaml
    /// </summary>
    public partial class ContratoSolicitacaoServico : UserControl
    {
        public ContratoSolicitacaoServico()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContratoSolicitacaoServicoViewModel)this.DataContext).IsEditar= false;
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
                ((ContratoSolicitacaoServicoViewModel)this.DataContext).salvarAtualizarContratoSolicitacaoServico();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((ContratoSolicitacaoServicoViewModel)this.DataContext).atualizarListaContratoSolicitacaoServico(0);
                ((ContratoSolicitacaoServicoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
		
		private void btPesquisarContratoTipoServico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContratoSolicitacaoServicoViewModel)DataContext).pesquisarContratoTipoServico();
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
                ((ContratoSolicitacaoServicoViewModel)DataContext).pesquisarColaborador();
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
                ((ContratoSolicitacaoServicoViewModel)DataContext).pesquisarSetor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContratoSolicitacaoServicoViewModel)DataContext).pesquisarCliente();
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
                ((ContratoSolicitacaoServicoViewModel)DataContext).pesquisarFornecedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
