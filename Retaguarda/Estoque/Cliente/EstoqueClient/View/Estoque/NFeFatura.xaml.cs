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
using EstoqueClient.EstoqueServiceReference;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for NFeDestinatario.xaml
    /// </summary>
    public partial class NFeFatura: UserControl
    {
        public NFeFatura()
        {
            InitializeComponent();
        }


        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedItem != null)
                {
                    ((EstoqueViewModel)DataContext).excluirCupomVinculado(dataGrid.SelectedIndex);
                    dataGrid.Items.Refresh();
                }
                else
                    MessageBox.Show("Selecione um cupom fiscal a ser excluído.", "Alerta do sistema");
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
                NFeDuplicataDTO duplicata = new NFeDuplicataDTO();

                duplicata.dataVencimento = dpDuplicataData.SelectedDate;
                duplicata.numero = tbDuplicataNumero.Text;

                decimal aux;
                if (decimal.TryParse(tbDuplicataValor.Text, out aux))
                    duplicata.valor = aux;
                else
                    duplicata.valor = null;

                ((EstoqueViewModel)DataContext).incluirDuplicata(duplicata);

                tbDuplicataNumero.Clear();
                tbDuplicataValor.Clear();
                dpDuplicataData.SelectedDate = null;

                dataGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btExcluir_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedItem != null)
                {
                    ((EstoqueViewModel)DataContext).excluirDuplicata(dataGrid.SelectedIndex);
                    dataGrid.Items.Refresh();
                }
                else
                    MessageBox.Show("Selecione uma duplicata a ser excluída.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}
