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
    /// Interaction logic for OrcamentoPedidoVendaCab.xaml
    /// </summary>
    public partial class OrcamentoPedidoVendaCab : UserControl
    {
        public OrcamentoPedidoVendaCab()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoPedidoVendaCabViewModel)this.DataContext).IsEditar= false;
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
                ((OrcamentoPedidoVendaCabViewModel)this.DataContext).salvarAtualizarOrcamentoPedidoVendaCab();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((OrcamentoPedidoVendaCabViewModel)this.DataContext).atualizarListaOrcamentoPedidoVendaCab(0);
                ((OrcamentoPedidoVendaCabViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
		
		private void btPesquisarCondicoesPagamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoPedidoVendaCabViewModel)DataContext).pesquisarCondicoesPagamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoPedidoVendaCabViewModel)DataContext).pesquisarCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarTransportadora_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoPedidoVendaCabViewModel)DataContext).pesquisarTransportadora();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarVendedor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoPedidoVendaCabViewModel)DataContext).pesquisarVendedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}
