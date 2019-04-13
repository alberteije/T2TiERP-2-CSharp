using NFe.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NFe.View
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
                ((NFeViewModel)DataContext).PesquisarProduto();
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
                    ((NFeViewModel)DataContext).IncluirProduto(aux);
                else
                    ((NFeViewModel)DataContext).IncluirProduto(1);

                dataGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void tbQuantidade_TextChanged(object sender, TextChangedEventArgs e)
        {
            //decimal aux;
            //if (decimal.TryParse(tbQuantidade.Text, out aux))
            //    tbValorTotal.Text =  (aux * decimal.Parse(tbValor.Text)).ToString();
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(dataGrid.SelectedIndex >= 0)
                {
                    ((NFeViewModel)DataContext).ExcluirProduto(dataGrid.SelectedIndex);
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
