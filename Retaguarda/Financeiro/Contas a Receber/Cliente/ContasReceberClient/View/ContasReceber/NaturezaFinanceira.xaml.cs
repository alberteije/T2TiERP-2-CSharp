using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for NaturezaFinanceira.xaml
    /// </summary>
    public partial class NaturezaFinanceira : UserControl
    {
        public NaturezaFinanceira()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((NaturezaFinanceiraViewModel)this.DataContext).IsEditar= false;
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
                ((NaturezaFinanceiraViewModel)this.DataContext).salvarAtualizarNaturezaFinanceira();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((NaturezaFinanceiraViewModel)this.DataContext).atualizarListaNaturezaFinanceira(0);
                ((NaturezaFinanceiraViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		
		private void btPesquisarContabilConta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((NaturezaFinanceiraViewModel)DataContext).pesquisarContabilConta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarPlanoNaturezaFinanceira_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((NaturezaFinanceiraViewModel)DataContext).pesquisarPlanoNaturezaFinanceira();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
