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
using ConciliacaoClient.ViewModel.ConciliacaoBancaria;
using ExportarParaArquivo.Control;

namespace ConciliacaoClient.View.ConciliacaoBancaria
{
    /// <summary>
    /// Interaction logic for ConciliacaoBancaria.xaml
    /// </summary>
    public partial class ConciliacaoBancariaView : UserControl
    {
        public ConciliacaoBancariaView()
        {
            InitializeComponent();
            DataContext = new ConciliacaoBancariaViewModel();
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            string texto = ((TextBox)sender).Text;
            if (texto != null && texto.Length > 2 && texto.Split('/').Length == 1)
                ((TextBox)sender).Text = texto.Substring(0, 2) + "/" + texto.Substring(2);
        }

        private void btConciliarCheque_Click(object sender, RoutedEventArgs e)
        {
            ((ConciliacaoBancariaViewModel)DataContext).conciliarCheques();
        }

        private void btPesquisarMovimento_Click(object sender, RoutedEventArgs e)
        {
            ((ConciliacaoBancariaViewModel)DataContext).pesquisarExtrato();
        }

        private void btConciliarLancamentos_Click(object sender, RoutedEventArgs e)
        {
            ((ConciliacaoBancariaViewModel)DataContext).conciliarLançamentos();
        }

        private void btImportar_Click(object sender, RoutedEventArgs e)
        {
            ((ConciliacaoBancariaViewModel)DataContext).importarOFX();
        }

        private void btPesquisarContaCaixa_Click(object sender, RoutedEventArgs e)
        {
            ((ConciliacaoBancariaViewModel)DataContext).pesquisarContaCaixa();
        }
        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            ((ConciliacaoBancariaViewModel)DataContext).exportarDataGrid((ExportarParaArquivo.Formato)(
                (ButtonExport)sender).ExportFileFormat,
                (DataGrid)((ButtonExport)sender).ExportDataGridSource);
        }
    }
}
