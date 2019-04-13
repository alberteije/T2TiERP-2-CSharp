using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for Detalhe.xaml
    /// </summary>
    public partial class FinParcelaReceber : UserControl
    {
        public FinParcelaReceber()
        {
            InitializeComponent();
        }
		
		private void btPesquisarContaCaixa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FinLancamentoReceberViewModel)DataContext).pesquisarContaCaixa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btBoleto_Click(object sender, RoutedEventArgs e)
        {
            ((FinLancamentoReceberViewModel)DataContext).gerarBoleto();
        }


    }
}
