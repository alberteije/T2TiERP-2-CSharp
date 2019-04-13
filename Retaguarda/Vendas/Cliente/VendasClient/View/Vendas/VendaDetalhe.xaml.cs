using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VendasClient.ViewModel.Vendas;

namespace VendasClient.View.Vendas
{
    /// <summary>
    /// Interaction logic for Detalhe.xaml
    /// </summary>
    public partial class VendaDetalhe : UserControl
    {
        public VendaDetalhe()
        {
            InitializeComponent();
        }

		private void btPesquisarVendaCabecalho_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //((VendaCabecalhoViewModel)DataContext).pesquisarVendaCabecalho();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarProduto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((VendaCabecalhoViewModel)DataContext).pesquisarProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
