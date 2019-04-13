using System;
using System.Windows;
using System.Windows.Controls;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for EstoqueReajusteCabecalho.xaml
    /// </summary>
    public partial class EstoqueReajusteCabecalho : UserControl
    {
        public EstoqueReajusteCabecalho()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((EstoqueReajusteCabecalhoViewModel)this.DataContext).IsEditar= false;
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
                ((EstoqueReajusteCabecalhoViewModel)this.DataContext).salvarAtualizarEstoqueReajusteCabecalho();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((EstoqueReajusteCabecalhoViewModel)this.DataContext).atualizarListaEstoqueReajusteCabecalho(0);
                ((EstoqueReajusteCabecalhoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarColaborador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((EstoqueReajusteCabecalhoViewModel)DataContext).pesquisarColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
