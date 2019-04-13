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
    /// Interaction logic for VendaCabecalho.xaml
    /// </summary>
    public partial class VendaCabecalho : UserControl
    {
        public VendaCabecalho()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((VendaCabecalhoViewModel)this.DataContext).IsEditar= false;
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
                ((VendaCabecalhoViewModel)this.DataContext).salvarAtualizarVendaCabecalho();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((VendaCabecalhoViewModel)this.DataContext).atualizarListaVendaCabecalho(0);
                ((VendaCabecalhoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
		
		private void btPesquisarOrcamentoPedidoVendaCab_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((VendaCabecalhoViewModel)DataContext).pesquisarOrcamentoPedidoVendaCab();
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
                ((VendaCabecalhoViewModel)DataContext).pesquisarCondicoesPagamento();
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
                ((VendaCabecalhoViewModel)DataContext).pesquisarVendedor();
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
                ((VendaCabecalhoViewModel)DataContext).pesquisarCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarTipoNotaFiscal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((VendaCabecalhoViewModel)DataContext).pesquisarTipoNotaFiscal();
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
                ((VendaCabecalhoViewModel)DataContext).pesquisarTransportadora();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
