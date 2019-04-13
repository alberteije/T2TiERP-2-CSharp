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
using OrcamentoClient.ViewModel.Orcamento;
using ExportarParaArquivo.Control;

namespace OrcamentoClient.View.Orcamento
{
    public partial class OrcamentoGrid : UserControl
    {
        public OrcamentoGrid()
        {
            InitializeComponent();
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoViewModel)DataContext).exportarDataGrid((ExportarParaArquivo.Formato)(
            (ButtonExport)sender).ExportFileFormat,
            (DataGrid)((ButtonExport)sender).ExportDataGridSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btConsultarOrcamentoDetalhe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedItem != null)
                    ((OrcamentoViewModel)DataContext).carregaViewOrcamentoDetalhe();
                else
                    MessageBox.Show("Selecione um item.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            ((OrcamentoViewModel)DataContext).carregaViewOrcamentoDetalhe();
        }
    }
}
