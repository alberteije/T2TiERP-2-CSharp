using System;
using System.Windows;
using System.Windows.Controls;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for Detalhe.xaml
    /// </summary>
    public partial class EstoqueContagemDetalhe : UserControl
    {
        public EstoqueContagemDetalhe()
        {
            InitializeComponent();
        }

		private void btPesquisarProduto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((EstoqueContagemCabecalhoViewModel)DataContext).pesquisarProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
