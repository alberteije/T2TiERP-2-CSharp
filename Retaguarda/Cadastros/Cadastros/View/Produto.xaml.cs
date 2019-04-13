using Cadastros.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Cadastros.View
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

        
        private void btPesquisarProdutoSubGrupo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ProdutoViewModel)DataContext).PesquisarProdutoSubGrupo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarProdutoMarca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ProdutoViewModel)DataContext).PesquisarProdutoMarca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarTributGrupoTributario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ProdutoViewModel)DataContext).PesquisarTributGrupoTributario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarAlmoxarifado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ProdutoViewModel)DataContext).PesquisarAlmoxarifado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarUnidadeProduto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ProdutoViewModel)DataContext).PesquisarUnidadeProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarTributIcmsCustomCab_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ProdutoViewModel)DataContext).PesquisarTributIcmsCustomCab();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}
