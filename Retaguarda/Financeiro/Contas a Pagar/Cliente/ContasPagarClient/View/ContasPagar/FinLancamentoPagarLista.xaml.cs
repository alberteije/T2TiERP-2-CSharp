using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ViewModel;
using ExportarParaArquivo.Control;
using ContasPagarClient.ViewModel.ContasPagar;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for FinLancamentoPagar.xaml
	/// 
	/// The MIT License
	///
	/// Copyright: Copyright (C) 2010 T2Ti.COM
	///
	/// Permission is hereby granted, free of charge, to any person
	/// obtaining a copy of this software and associated documentation
	/// files (the "Software"), to deal in the Software without
	/// restriction, including without limitation the rights to use,
	/// copy, modify, merge, publish, distribute, sublicense, and/or sell
	/// copies of the Software, and to permit persons to whom the
	/// Software is furnished to do so, subject to the following
	/// conditions:
	///
	/// The above copyright notice and this permission notice shall be
	/// included in all copies or substantial portions of the Software.
	///
	/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
	/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
	/// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
	/// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
	/// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
	/// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
	/// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
	/// OTHER DEALINGS IN THE SOFTWARE.
	///
	///        The author may be contacted at:
	///            t2ti.com@gmail.com
	///
	/// Autor: Albert Eije (t2ti.com@gmail.com)
	/// Version: 1.0
    /// </summary>
    public partial class FinLancamentoPagarLista : UserControl
    {
        public FinLancamentoPagarLista()
        {
            InitializeComponent();
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ERPViewModelBase)DataContext).exportarDataGrid((ExportarParaArquivo.Formato)(
            (ButtonExport)sender).ExportFileFormat,
            (DataGrid)((ButtonExport)sender).ExportDataGridSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectedItem = dataGrid.Items[0];
            int offset = ((FinLancamentoPagarViewModel)DataContext).FinLancamentoPagarSelected.Id - 1;

            string ConsultaSQL =
			"select "+
			"  LP.ID, LP.QUANTIDADE_PARCELA, LP.VALOR_A_PAGAR AS VALOR_LANCAMENTO, LP.DATA_LANCAMENTO, LP.NUMERO_DOCUMENTO, "+
			"  PP.ID as ID_PARCELA_PAGAR, PP.NUMERO_PARCELA, PP.DATA_VENCIMENTO, PP.VALOR AS VALOR_PARCELA, PP.TAXA_JURO, PP.VALOR_JURO, PP.TAXA_MULTA, PP.VALOR_MULTA, PP.TAXA_DESCONTO, PP.VALOR_DESCONTO, "+
			"  DOC.SIGLA_DOCUMENTO, "+
			"  P.NOME as NOME_FORNECEDOR, "+
			"  S.ID, S.SITUACAO as SITUACAO_PARCELA, S.DESCRICAO as DESCRICAO_SITUACAO_PARCELA, "+
			"  CC.ID AS ID_CONTA_CAIXA, CC.NOME AS NOME_CONTA_CAIXA from FIN_LANCAMENTO_PAGAR LP INNER "+
			" JOIN FIN_PARCELA_PAGAR PP ON (PP.ID_FIN_LANCAMENTO_PAGAR = LP.ID) "+
			" INNER JOIN FORNECEDOR F ON (LP.ID_FORNECEDOR = F.ID) "+
			" INNER JOIN FIN_DOCUMENTO_ORIGEM DOC ON (LP.ID_FIN_DOCUMENTO_ORIGEM = DOC.ID) "+
			" INNER JOIN FIN_STATUS_PARCELA S ON (PP.ID_FIN_STATUS_PARCELA = S.ID) "+
			" INNER JOIN PESSOA P ON (F.ID_PESSOA = P.ID) "+
			" INNER JOIN CONTA_CAIXA CC ON (PP.ID_CONTA_CAIXA = CC.ID) limit " + ERPViewModelBase.QUANTIDADE_PAGINA + " offset " + offset;

            ((ERPViewModelBase)DataContext).exibirRelatorio("FinLancamentoPagar", "Lançamentos Pagar", ConsultaSQL);
        }
    }
}
