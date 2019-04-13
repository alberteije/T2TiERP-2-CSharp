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
using ContratosClient.ViewModel.Contratos;
using ContratosClient.ContratosReference;
using GEDClient.View.GED;

namespace ContratosClient.View.Contratos
{
    /// <summary>
    /// Interaction logic for ContratoPrincipal.xaml
    /// </summary>
    public partial class ContratoPrincipal : UserControl
    {
        private ContratoViewModel viewModel;
        public ContratoPrincipal()
        {
            InitializeComponent();
            viewModel = new ContratoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.ContratoSelected != null)
                {
                    ModuloVisualizarDocumentoView view = new ModuloVisualizarDocumentoView();
                    ((Contrato)tabContrato.Content).TabGED.Content = view;

                    if (viewModel.ContratoSelected.Numero != null && viewModel.ContratoSelected.Numero.Length > 0)
                        view.carregarDocumento(int.Parse(viewModel.ContratoSelected.Numero));

                    viewModel.IsEditar = true;
                }
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
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
                ((Contrato)tabContrato.Content).TabGED.Content = new ModuloIncluirDocumentoView();
                viewModel.ContratoSelected = new ContratoDTO();
                viewModel.ContratoSelected.ListaContratoHistFaturamento = new List<ContratoHistFaturamentoDTO>();
                viewModel.ContratoSelected.ListaContratoHistoricoReajuste = new List<ContratoHistoricoReajusteDTO>();
                viewModel.ContratoSelected.ListaContratoPrevFaturamento = new List<ContratoPrevFaturamentoDTO>();
                viewModel.IsEditar = true;
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
                if (viewModel.ContratoSelected != null)
                {
                    viewModel.excluirContrato();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaContrato(0);
                }                
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
