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
using ExportarParaArquivo.Control;
using EstoqueClient.EstoqueServiceReference;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for EstoqueView.xaml
    /// </summary>
    public partial class NFeView : UserControl
    {
        EstoqueViewModel estoqueViewModel = new EstoqueViewModel();

        public NFeView()
        {
            InitializeComponent();
            DataContext = estoqueViewModel;
            estoqueViewModel.carregarTabLista();
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                estoqueViewModel.exportarDataGrid((ExportarParaArquivo.Formato)(
            (ButtonExport)sender).ExportFileFormat,
            (DataGrid)((ButtonExport)sender).ExportDataGridSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void carregarViewDados()
        {
            try
            {
                tabDados.Content = new NFeDados();
                tabDados.IsSelected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                estoqueViewModel.nfeSelected = new NFeCabecalhoDTO();
                estoqueViewModel.carregarTabDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (estoqueViewModel.nfeSelected != null)
                {
                    estoqueViewModel.carregarTabDados();
                }
                else
                    MessageBox.Show("Selecione a NF-e para consulta", "Informação do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btImportar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                estoqueViewModel.importarNFe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
