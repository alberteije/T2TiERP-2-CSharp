using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ViewModel.ContasPagar;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for FinLancamentoPagar.xaml
    /// </summary>
    public partial class FinLancamentoPagar : UserControl
    {
        public FinLancamentoPagar()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FinLancamentoPagarViewModel)this.DataContext).IsEditar= false;
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
                ((FinLancamentoPagarViewModel)this.DataContext).salvarAtualizarFinLancamentoPagar();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FinLancamentoPagarViewModel)this.DataContext).atualizarListaFinLancamentoPagar(0);
                ((FinLancamentoPagarViewModel)this.DataContext).IsEditar = false;
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
                ((FinLancamentoPagarViewModel)DataContext).pesquisarFornecedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
		
		private void btPesquisarFinDocumentoOrigem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FinLancamentoPagarViewModel)DataContext).pesquisarFinDocumentoOrigem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
