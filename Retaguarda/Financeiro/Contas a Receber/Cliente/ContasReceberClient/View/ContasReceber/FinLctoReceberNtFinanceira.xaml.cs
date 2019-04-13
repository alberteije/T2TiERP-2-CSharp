using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for Detalhe.xaml
    /// </summary>
    public partial class FinLctoReceberNtFinanceira : UserControl
    {
        public FinLctoReceberNtFinanceira()
        {
            InitializeComponent();
        }

		private void btPesquisarNaturezaFinanceira_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FinLancamentoReceberViewModel)DataContext).pesquisarNaturezaFinanceira();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
