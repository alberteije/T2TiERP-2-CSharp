using System.Windows;
using System.Windows.Controls;
using ExportarParaArquivo.Control;
using FluxoCaixaClient.ViewModel.FluxoCaixa;
using System;

namespace FluxoCaixaClient.View.FluxoCaixa
{
    /// <summary>
    /// Interaction logic for FluxoCaixaView.xaml
    /// </summary>
    public partial class FluxoCaixaView : UserControl
    {
        public FluxoCaixaView()
        {
            InitializeComponent();
            DataContext = new FluxoCaixaViewModel();
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            ((FluxoCaixaViewModel)DataContext).exportarDataGrid((ExportarParaArquivo.Formato)(
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
            try
            {
                if (((FluxoCaixaViewModel)DataContext).contaCaixaSelected == null)
                    MessageBox.Show("Selecione a conta caixa");
                else
                    ((FluxoCaixaViewModel)DataContext).pesquisarResumo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btPesquisarContaCaixa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FluxoCaixaViewModel)DataContext).pesquisarContaCaixa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}
