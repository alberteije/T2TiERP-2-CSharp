using System;
using System.Windows;
using System.Windows.Controls;
using EstoqueClient.EstoqueServiceReference;
using System.Collections.Generic;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for RequisicaoInternaCabecalhoPrincipal.xaml
    /// </summary>
    public partial class RequisicaoInternaCabecalhoPrincipal : UserControl
    {
        private RequisicaoInternaCabecalhoViewModel viewModel;
        public RequisicaoInternaCabecalhoPrincipal()
        {
            InitializeComponent();
            viewModel = new RequisicaoInternaCabecalhoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.RequisicaoInternaCabecalhoSelected != null)
                    viewModel.IsEditar = true;
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
                viewModel.RequisicaoInternaCabecalhoSelected = new RequisicaoInternaCabecalhoDTO();
                viewModel.RequisicaoInternaCabecalhoSelected.ListaRequisicaoInternaDetalhe = new List<RequisicaoInternaDetalheDTO>();
				
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
                if (viewModel.RequisicaoInternaCabecalhoSelected != null)
                {
                    viewModel.excluirRequisicaoInternaCabecalho();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaRequisicaoInternaCabecalho(0);
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
