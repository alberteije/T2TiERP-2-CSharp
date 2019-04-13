using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for FinTipoRecebimento.xaml
    /// </summary>
    public partial class FinTipoRecebimento : UserControl
    {
        public FinTipoRecebimento()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FinTipoRecebimentoViewModel)this.DataContext).IsEditar= false;
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
                ((FinTipoRecebimentoViewModel)this.DataContext).salvarAtualizarFinTipoRecebimento();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FinTipoRecebimentoViewModel)this.DataContext).atualizarListaFinTipoRecebimento(0);
                ((FinTipoRecebimentoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
