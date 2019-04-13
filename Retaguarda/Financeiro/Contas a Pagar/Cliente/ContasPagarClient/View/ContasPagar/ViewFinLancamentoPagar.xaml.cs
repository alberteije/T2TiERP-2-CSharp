using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ViewModel.ContasPagar;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for ViewFinLancamentoPagar.xaml
    /// </summary>
    public partial class ViewFinLancamentoPagar : UserControl
    {
        public ViewFinLancamentoPagar()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ViewFinLancamentoPagarViewModel)this.DataContext).IsEditar= false;
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
                ((ViewFinLancamentoPagarViewModel)this.DataContext).salvarAtualizarViewFinLancamentoPagar();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((ViewFinLancamentoPagarViewModel)this.DataContext).atualizarListaViewFinLancamentoPagar(0);
                ((ViewFinLancamentoPagarViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
