using System;
using System.Windows;
using System.Windows.Controls;
using EstoqueClient.EstoqueServiceReference;
using System.Collections.Generic;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for EstoqueReajusteCabecalhoPrincipal.xaml
    /// </summary>
    public partial class EstoqueReajusteCabecalhoPrincipal : UserControl
    {
        private EstoqueReajusteCabecalhoViewModel viewModel;
        public EstoqueReajusteCabecalhoPrincipal()
        {
            InitializeComponent();
            viewModel = new EstoqueReajusteCabecalhoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.EstoqueReajusteCabecalhoSelected != null)
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
                viewModel.EstoqueReajusteCabecalhoSelected = new EstoqueReajusteCabecalhoDTO();
                viewModel.EstoqueReajusteCabecalhoSelected.ListaEstoqueReajusteDetalhe = new List<EstoqueReajusteDetalheDTO>();

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
                if (viewModel.EstoqueReajusteCabecalhoSelected != null)
                {
                    viewModel.excluirEstoqueReajusteCabecalho();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaEstoqueReajusteCabecalho(0);
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
