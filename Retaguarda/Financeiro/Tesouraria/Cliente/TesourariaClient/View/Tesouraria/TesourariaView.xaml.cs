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
using TesourariaClient.ViewModel.Tesouraria;
using ExportarParaArquivo.Control;

namespace TesourariaClient.View.Tesouraria
{
    /// <summary>
    /// Interaction logic for TesourariaView.xaml
    /// </summary>
    public partial class TesourariaView : UserControl
    {
        public TesourariaView()
        {
            InitializeComponent();
            DataContext = new TesourariaViewModel();
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            ((TesourariaViewModel)DataContext).exportarDataGrid((ExportarParaArquivo.Formato)(
                (ButtonExport)sender).ExportFileFormat,
                (DataGrid)((ButtonExport)sender).ExportDataGridSource);
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {

            string texto = ((TextBox)sender).Text;
            if (texto != null && texto.Length > 2 && texto.Split('/').Length == 1)
                ((TextBox)sender).Text = texto.Substring(0, 2) + "/" + texto.Substring(2);
        }

        private void btPesquisarResumo_Click(object sender, RoutedEventArgs e)
        {
            ((TesourariaViewModel)DataContext).pesquisarResumo();
        }
    }
}
