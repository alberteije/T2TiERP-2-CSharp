using NFe.ServidorReference;
using NFe.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NFe.View
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
                NfeCupomFiscalReferenciadoDTO CupomVinculado = new NfeCupomFiscalReferenciadoDTO();

                CupomVinculado.ModeloDocumentoFiscal = tbModeloDocumentoFiscal.Text;
                CupomVinculado.DataEmissaoCupom = dpDataEmissao.SelectedDate;
                int aux;
                if(int.TryParse(tbNrOrdemECF.Text, out aux))
                    CupomVinculado.NumeroOrdemEcf = aux;
                else
                    CupomVinculado.NumeroOrdemEcf = null;

                if(int.TryParse(tbNrCaixa.Text, out aux))
                    CupomVinculado.NumeroCaixa = aux;
                else
                    CupomVinculado.NumeroCaixa = null;

                if (int.TryParse(tbCOO.Text, out aux))
                    CupomVinculado.Coo = aux;
                else
                    CupomVinculado.Coo = null;

                CupomVinculado.NumeroSerieEcf = tbNrSerieECF.Text;

                ((NFeViewModel)DataContext).IncluirCupomVinculado(CupomVinculado);

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
                    ((NFeViewModel)DataContext).ExcluirCupomVinculado(dataGrid.SelectedIndex);
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
