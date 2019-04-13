using T2TiCte.Servico;
using NFe.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NFe.View
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
                    ((NFeViewModel)DataContext).ExcluirDuplicata(dataGrid.SelectedIndex);
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
                NfeDuplicataDTO Duplicata = new NfeDuplicataDTO();

                Duplicata.DataVencimento = dpDuplicataData.SelectedDate;
                Duplicata.Numero = tbDuplicataNumero.Text;

                decimal aux;
                if (decimal.TryParse(tbDuplicataValor.Text, out aux))
                    Duplicata.Valor = aux;
                else
                    Duplicata.Valor = null;

                ((NFeViewModel)DataContext).IncluirDuplicata(Duplicata);

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
                    ((NFeViewModel)DataContext).ExcluirDuplicata(dataGrid.SelectedIndex);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

              /// EXERCICIO: implemente esse método de acordo com a necessidade do seu cliente
              ///  01-Pergunte se ele quer lançar no contas a receber após a emissão da nota
              ///  02-Deixe uma opção na tela para mandar os dados para o financeiro
              ///  03-Deixe a opção de capturar esses dados no financeiro apenas
              ///  04-Realize o lançamento sem que o usuário da NF-e saiba o que está ocorrendo e deixe o restante a cargo do profissional do setor financeiro
              ///
              ///  Corrija as informações estáticas que estão no código.
              ///  
              ///  Segue o algoritmo

                        /*

              if MessageBox('Deseja gerar os lançamentos para o contas a Receber?') = Yes
              {
                LancamentoReceber = new LancamentoReceber();

                LancamentoReceber.IdCliente = EditDestinatarioId;
                LancamentoReceber.IdFinDocumentoOrigem = 32; 
                LancamentoReceber.QuantidadeParcela = 1;
                LancamentoReceber.ValorTotal = EditValorTotalNota.Value;
                LancamentoReceber.ValorAReceber = EditValorTotalNota.Value;
                LancamentoReceber.DataLancamento = now;
                LancamentoReceber.NumeroDocumento = "NF-e: " + EditNumeroNfe.text;
                LancamentoReceber.PrimeiroVencimento = now;
                LancamentoReceber.IntervaloEntreParcelas = 30;

                for (i = 0; i < LancamentoReceber.QuantidadeParcela; i++)
                {
                  ParcelaReceber = new ParcelaReceber();
                  ParcelaReceber.NumeroParcela = i+1;
                  ParcelaReceber.IdContaCaixa = 1; 
                  ParcelaReceber.IdFinStatusParcela = 1;
                  ParcelaReceber.DataEmissao = now;
                  ParcelaReceber.DataVencimento = LancamentoReceber.PrimeiroVencimento + (LancamentoReceber.IntervaloEntreParcelas * i);
                  ParcelaReceber.Valor = LancamentoReceber.ValorAReceber / LancamentoReceber.QuantidadeParcela;

                  LancamentoReceber.ListaParcelaReceber.Add(ParcelaReceber);
                }
    
                SalvarLancamentoReceber(LancamentoReceber);
              }
             */
        }
    }
}
