using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for ViewFinLancamentoReceber.xaml
    /// </summary>
    public partial class ViewFinLancamentoReceber : UserControl
    {
        public ViewFinLancamentoReceber()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ViewFinLancamentoReceberViewModel)this.DataContext).IsEditar= false;
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
                ((ViewFinLancamentoReceberViewModel)this.DataContext).salvarAtualizarViewFinLancamentoReceber();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((ViewFinLancamentoReceberViewModel)this.DataContext).atualizarListaViewFinLancamentoReceber(0);
                ((ViewFinLancamentoReceberViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
