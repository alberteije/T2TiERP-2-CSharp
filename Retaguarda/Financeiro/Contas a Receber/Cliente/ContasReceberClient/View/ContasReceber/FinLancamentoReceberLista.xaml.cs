using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel;
using ExportarParaArquivo.Control;
using ContasReceberClient.ViewModel.ContasReceber;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for FinLancamentoReceber.xaml
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
    public partial class FinLancamentoReceberLista : UserControl
    {
        public FinLancamentoReceberLista()
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
            int offset = ((FinLancamentoReceberViewModel)DataContext).FinLancamentoReceberSelected.Id - 1;

            string ConsultaSQL =
			"select "+
			"  LR.ID, LR.QUANTIDADE_PARCELA, LR.VALOR_A_RECEBER AS VALOR_LANCAMENTO, LR.DATA_LANCAMENTO, LR.NUMERO_DOCUMENTO, "+
			"  PR.ID as ID_PARCELA_RECEBER, PR.NUMERO_PARCELA, PR.DATA_VENCIMENTO, PR.VALOR AS VALOR_PARCELA, PR.TAXA_JURO, PR.VALOR_JURO, PR.TAXA_MULTA, PR.VALOR_MULTA, PR.TAXA_DESCONTO, PR.VALOR_DESCONTO, "+
			"  DOC.SIGLA_DOCUMENTO, "+
			"  P.NOME as NOME_FORNECEDOR, "+
			"  S.ID, S.SITUACAO as SITUACAO_PARCELA, S.DESCRICAO as DESCRICAO_SITUACAO_PARCELA, "+
			"  CC.ID AS ID_CONTA_CAIXA, CC.NOME AS NOME_CONTA_CAIXA	from FIN_LANCAMENTO_RECEBER LR INNER "+
			" JOIN FIN_PARCELA_RECEBER PR ON (PR.ID_FIN_LANCAMENTO_RECEBER = LR.ID) "+
			" INNER JOIN CLIENTE C ON (LR.ID_CLIENTE = C.ID) "+
			" INNER JOIN FIN_DOCUMENTO_ORIGEM DOC ON (LR.ID_FIN_DOCUMENTO_ORIGEM = DOC.ID) "+
			" INNER JOIN FIN_STATUS_PARCELA S ON (PR.ID_FIN_STATUS_PARCELA = S.ID) "+
			" INNER JOIN PESSOA P ON (C.ID_PESSOA = P.ID) "+
			" INNER JOIN CONTA_CAIXA CC ON (PR.ID_CONTA_CAIXA = CC.ID) limit " + ERPViewModelBase.QUANTIDADE_PAGINA + " offset " + offset;

            ((ERPViewModelBase)DataContext).exibirRelatorio("FinLancamentoReceber", "Lançamentos Receber", ConsultaSQL);
        }
    }
}
