using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ViewModel.ContasPagar;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for Detalhe.xaml
    /// </summary>
    public partial class FinLctoPagarNtFinanceira : UserControl
    {
        public FinLctoPagarNtFinanceira()
        {
            InitializeComponent();
        }

		private void btPesquisarNaturezaFinanceira_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FinLancamentoPagarViewModel)DataContext).pesquisarNaturezaFinanceira();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
