using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for PlanoNaturezaFinanceira.xaml
    /// </summary>
    public partial class PlanoNaturezaFinanceira : UserControl
    {
        public PlanoNaturezaFinanceira()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((PlanoNaturezaFinanceiraViewModel)this.DataContext).IsEditar= false;
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
                ((PlanoNaturezaFinanceiraViewModel)this.DataContext).salvarAtualizarPlanoNaturezaFinanceira();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((PlanoNaturezaFinanceiraViewModel)this.DataContext).atualizarListaPlanoNaturezaFinanceira(0);
                ((PlanoNaturezaFinanceiraViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
