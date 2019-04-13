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
using ComprasClient.ViewModel.Compras;
using ExportarParaArquivo.Control;
using ComprasClient.ViewModel;

namespace ComprasClient.View.Compras
{
    /// <summary>
    /// Interaction logic for Requisicao.xaml
    /// </summary>
    public partial class Requisicao : UserControl
    {
        private RequisicaoViewModel viewModel;
        public Requisicao()
        {
            InitializeComponent();
            viewModel = new RequisicaoViewModel();
            this.DataContext = viewModel;
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            ((RequisicaoViewModel)this.DataContext).exportarDataGrid(
                (ExportarParaArquivo.Formato)((ButtonExport)sender).ExportFileFormat,
                (DataGrid)((ButtonExport)sender).ExportDataGridSource);

        }

        private void btPesquisarColaborador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((RequisicaoViewModel)this.DataContext).pesquisarColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btPesquisarTipoRequisicao_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((RequisicaoViewModel)this.DataContext).pesquisarTipoRequisicao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            ((RequisicaoViewModel)this.DataContext).incluir();
        }


        private void btIncluirProduto_Click(object sender, RoutedEventArgs e)
        {
            ((RequisicaoViewModel)this.DataContext).incluirProduto();
        }

        private void btExcluirProduto_Click(object sender, RoutedEventArgs e)
        {
            ((RequisicaoViewModel)this.DataContext).excluirProduto();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            ((RequisicaoViewModel)this.DataContext).cancelarOperacao();
        }

        private void btConfirmar_Click(object sender, RoutedEventArgs e)
        {
            ((RequisicaoViewModel)this.DataContext).executaOperacao();
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            ((RequisicaoViewModel)this.DataContext).excluir();
        }

        private void btAlterar_Click(object sender, RoutedEventArgs e)
        {
            ((RequisicaoViewModel)this.DataContext).alterar();
        }

        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            ((RequisicaoViewModel)this.DataContext).pesquisar();
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectedItem = dataGrid.Items[0];
            int offset = ((RequisicaoViewModel)DataContext).selectedItem.Id - 1;

            string ConsultaSQL =
                            "select   CR.*, CTR.NOME, VPC.NOME from COMPRA_REQUISICAO CR " +
                            " INNER  JOIN COMPRA_TIPO_REQUISICAO CTR ON (CR.ID_COMPRA_TIPO_REQUISICAO = CTR.ID) "+
                            " INNER JOIN VIEW_PESSOA_COLABORADOR VPC ON (CR.ID_COLABORADOR = VPC.ID) " +
                            " limit " + ERPViewModelBase.QUANTIDADE_PAGINA + " offset " + offset;

            ((ERPViewModelBase)DataContext).exibirRelatorio("CompraRequisicao", "Requisicao Compra", ConsultaSQL);

        }
    }
}
