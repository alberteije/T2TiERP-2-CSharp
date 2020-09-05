using System.Windows.Controls;
using System.Windows;
using SISClient.ViewModel;
using System;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for Produto.xaml
    /// </summary>
    public partial class Produto : UserControl
    {
        public Produto()
        {
            InitializeComponent();
        }

        private void btPesquisarCategoriaProduto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ProdutoViewModel)DataContext).PesquisarCategoriaProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
