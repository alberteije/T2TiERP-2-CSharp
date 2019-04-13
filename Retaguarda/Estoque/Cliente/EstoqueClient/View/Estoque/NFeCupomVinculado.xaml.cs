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
    public partial class NFeCupomVinculado : UserControl
    {
        public NFeCupomVinculado()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NFeCupomFiscalDTO cupomVinculado = new NFeCupomFiscalDTO();

                cupomVinculado.modeloDocumentoFiscal = tbModeloDocumentoFiscal.Text;
                cupomVinculado.dataEmissaoCupom = dpDataEmissao.SelectedDate;
                int aux;
                if(int.TryParse(tbNrOrdemECF.Text, out aux))
                    cupomVinculado.numeroOrdemEcf = aux;
                else
                    cupomVinculado.numeroOrdemEcf = null;

                if(int.TryParse(tbNrCaixa.Text, out aux))
                    cupomVinculado.numeroCaixa = aux;
                else
                    cupomVinculado.numeroCaixa = null;

                if (int.TryParse(tbCOO.Text, out aux))
                    cupomVinculado.coo = aux;
                else
                    cupomVinculado.coo = null;

                cupomVinculado.numeroSerieEcf = tbNrSerieECF.Text;

                ((EstoqueViewModel)DataContext).incluirCupomVinculado(cupomVinculado);

                tbModeloDocumentoFiscal.Clear();
                dpDataEmissao.SelectedDate = null;
                tbNrOrdemECF.Clear();
                tbNrCaixa.Clear();
                tbCOO.Clear();
                tbNrSerieECF.Clear();

                dataGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");    
            }
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
    }
}
