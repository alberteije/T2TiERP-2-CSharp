using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ViewModel.ContasPagar;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for Detalhe.xaml
    /// </summary>
    public partial class FinParcelaPagamento : UserControl
    {
        public FinParcelaPagamento()
        {
            InitializeComponent();
        }
		
		private void btPesquisarContaCaixa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ViewFinLancamentoPagarViewModel)DataContext).pesquisarContaCaixa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarFinTipoPagamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ViewFinLancamentoPagarViewModel)DataContext).pesquisarFinTipoPagamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
