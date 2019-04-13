using System;
using System.Windows;
using System.Windows.Controls;

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for ContabilLancamentoCabecalho.xaml
    /// </summary>
    public partial class ContabilLancamentoCabecalho : UserControl
    {
        public ContabilLancamentoCabecalho()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilLancamentoCabecalhoViewModel)this.DataContext).IsEditar= false;
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
                ((ContabilLancamentoCabecalhoViewModel)this.DataContext).salvarAtualizarContabilLancamentoCabecalho();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((ContabilLancamentoCabecalhoViewModel)this.DataContext).atualizarListaContabilLancamentoCabecalho(0);
                ((ContabilLancamentoCabecalhoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarContabilLote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilLancamentoCabecalhoViewModel)DataContext).pesquisarContabilLote();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
