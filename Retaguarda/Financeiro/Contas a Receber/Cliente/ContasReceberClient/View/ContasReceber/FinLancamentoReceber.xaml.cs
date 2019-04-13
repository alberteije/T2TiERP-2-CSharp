using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for FinLancamentoReceber.xaml
    /// </summary>
    public partial class FinLancamentoReceber : UserControl
    {
        public FinLancamentoReceber()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FinLancamentoReceberViewModel)this.DataContext).IsEditar= false;
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
                ((FinLancamentoReceberViewModel)this.DataContext).salvarAtualizarFinLancamentoReceber();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FinLancamentoReceberViewModel)this.DataContext).atualizarListaFinLancamentoReceber(0);
                ((FinLancamentoReceberViewModel)this.DataContext).IsEditar = false;
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
                ((FinLancamentoReceberViewModel)DataContext).pesquisarCliente();
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
                ((FinLancamentoReceberViewModel)DataContext).pesquisarFinDocumentoOrigem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
