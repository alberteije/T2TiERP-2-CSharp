using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ContabilidadeClient.ServicoContabilidadeReference;
using ContabilidadeClient.ViewModel.Contabilidade;

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for ContabilLivroPrincipal.xaml
    /// </summary>
    public partial class ContabilLivroPrincipal : UserControl
    {
        private ContabilLivroViewModel viewModel;
        public ContabilLivroPrincipal()
        {
            InitializeComponent();
            viewModel = new ContabilLivroViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.ContabilLivroSelected != null)
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
                viewModel.ContabilLivroSelected = new ContabilLivroDTO();
                viewModel.ContabilLivroSelected.ListaContabilTermo = new List<ContabilTermoDTO>();

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
                if (viewModel.ContabilLivroSelected != null)
                {
                    viewModel.excluirContabilLivro();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaContabilLivro(0);
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
