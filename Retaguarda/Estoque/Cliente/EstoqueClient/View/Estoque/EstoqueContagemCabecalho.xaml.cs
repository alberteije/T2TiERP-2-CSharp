using System;
using System.Windows;
using System.Windows.Controls;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for EstoqueContagemCabecalho.xaml
    /// </summary>
    public partial class EstoqueContagemCabecalho : UserControl
    {
        public EstoqueContagemCabecalho()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((EstoqueContagemCabecalhoViewModel)this.DataContext).IsEditar= false;
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
                ((EstoqueContagemCabecalhoViewModel)this.DataContext).salvarAtualizarEstoqueContagemCabecalho();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((EstoqueContagemCabecalhoViewModel)this.DataContext).atualizarListaEstoqueContagemCabecalho(0);
                ((EstoqueContagemCabecalhoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
