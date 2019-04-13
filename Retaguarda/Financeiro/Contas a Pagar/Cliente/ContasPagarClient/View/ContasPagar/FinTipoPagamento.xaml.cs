using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ViewModel.ContasPagar;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for FinTipoPagamento.xaml
    /// </summary>
    public partial class FinTipoPagamento : UserControl
    {
        public FinTipoPagamento()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FinTipoPagamentoViewModel)this.DataContext).IsEditar= false;
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
                ((FinTipoPagamentoViewModel)this.DataContext).salvarAtualizarFinTipoPagamento();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FinTipoPagamentoViewModel)this.DataContext).atualizarListaFinTipoPagamento(0);
                ((FinTipoPagamentoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
