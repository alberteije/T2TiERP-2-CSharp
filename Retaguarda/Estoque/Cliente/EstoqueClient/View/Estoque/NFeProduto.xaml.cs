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

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for NFeDestinatario.xaml
    /// </summary>
    public partial class NFeProduto : UserControl
    {
        public NFeProduto()
        {
            InitializeComponent();
        }

        private void btPesquisarProduto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((EstoqueViewModel)DataContext).pesquisarProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal aux;
                if(decimal.TryParse(tbQuantidade.Text, out aux))
                    ((EstoqueViewModel)DataContext).incluirProduto(aux);
                else
                    ((EstoqueViewModel)DataContext).incluirProduto(1);

                dataGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void tbQuantidade_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal aux;
            if (decimal.TryParse(tbQuantidade.Text, out aux))
                tbValorTotal.Text =  (aux * decimal.Parse(tbValor.Text)).ToString();
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(dataGrid.SelectedIndex >= 0)
                {
                    ((EstoqueViewModel)DataContext).excluirProduto(dataGrid.SelectedIndex);
                    dataGrid.Items.Refresh();
                }else
                    MessageBox.Show("Selecione um produto a ser excluído.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}
