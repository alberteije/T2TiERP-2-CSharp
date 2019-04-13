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
    /// Interaction logic for FreteVenda.xaml
    /// </summary>
    public partial class FreteVenda : UserControl
    {
        public FreteVenda()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FreteVendaViewModel)this.DataContext).IsEditar= false;
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
                ((FreteVendaViewModel)this.DataContext).salvarAtualizarFreteVenda();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((FreteVendaViewModel)this.DataContext).atualizarListaFreteVenda(0);
                ((FreteVendaViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
		
		private void btPesquisarVendaCabecalho_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FreteVendaViewModel)DataContext).pesquisarVendaCabecalho();
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
                ((FreteVendaViewModel)DataContext).pesquisarTransportadora();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
