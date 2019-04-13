using System;
using System.Windows;
using System.Windows.Controls;
using EstoqueClient.EstoqueServiceReference;
using System.Collections.Generic;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for EstoqueContagemCabecalhoPrincipal.xaml
    /// </summary>
    public partial class EstoqueContagemCabecalhoPrincipal : UserControl
    {
        private EstoqueContagemCabecalhoViewModel viewModel;
        public EstoqueContagemCabecalhoPrincipal()
        {
            InitializeComponent();
            viewModel = new EstoqueContagemCabecalhoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.EstoqueContagemCabecalhoSelected != null)
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
                viewModel.EstoqueContagemCabecalhoSelected = new EstoqueContagemCabecalhoDTO();
                viewModel.EstoqueContagemCabecalhoSelected.listaContagemDetalhe = new List<EstoqueContagemDetalheDTO>();

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
                if (viewModel.EstoqueContagemCabecalhoSelected != null)
                {
                    viewModel.excluirEstoqueContagemCabecalho();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaEstoqueContagemCabecalho(0);
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
