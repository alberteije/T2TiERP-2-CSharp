using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for FinConfiguracaoBoleto.xaml
    /// </summary>
    public partial class FinConfiguracaoBoleto : UserControl
    {
        public FinConfiguracaoBoleto()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FinConfiguracaoBoletoViewModel)this.DataContext).IsEditar= false;
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
                ((FinConfiguracaoBoletoViewModel)this.DataContext).salvarAtualizarFinConfiguracaoBoleto();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FinConfiguracaoBoletoViewModel)this.DataContext).atualizarListaFinConfiguracaoBoleto(0);
                ((FinConfiguracaoBoletoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
		
		private void btPesquisarContaCaixa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FinConfiguracaoBoletoViewModel)DataContext).pesquisarContaCaixa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
