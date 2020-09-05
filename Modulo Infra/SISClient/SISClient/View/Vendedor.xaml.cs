using System.Windows.Controls;
using System.Windows;
using SISClient.ViewModel;
using System;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for Vendedor.xaml
    /// </summary>
    public partial class Vendedor : UserControl
    {
        public Vendedor()
        {
            InitializeComponent();
        }

		
		private void btPesquisarLocalVenda_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((VendedorViewModel)DataContext).PesquisarLocalVenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarTipoPagamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((VendedorViewModel)DataContext).PesquisarTipoPagamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarSituacaoVendedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((VendedorViewModel)DataContext).PesquisarSituacaoVendedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
    }
}
