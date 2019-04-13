using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ViewModel.ContasPagar;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for FinStatusParcela.xaml
    /// </summary>
    public partial class FinStatusParcela : UserControl
    {
        public FinStatusParcela()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FinStatusParcelaViewModel)this.DataContext).IsEditar= false;
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
                ((FinStatusParcelaViewModel)this.DataContext).salvarAtualizarFinStatusParcela();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FinStatusParcelaViewModel)this.DataContext).atualizarListaFinStatusParcela(0);
                ((FinStatusParcelaViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
