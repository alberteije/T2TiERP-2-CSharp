using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ContabilidadeClient.ServicoContabilidadeReference;

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for ContabilLancamentoCabecalhoPrincipal.xaml
    /// </summary>
    public partial class ContabilLancamentoCabecalhoPrincipal : UserControl
    {
        private ContabilLancamentoCabecalhoViewModel viewModel;
        public ContabilLancamentoCabecalhoPrincipal()
        {
            InitializeComponent();
            viewModel = new ContabilLancamentoCabecalhoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.ContabilLancamentoCabecalhoSelected != null)
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
                viewModel.ContabilLancamentoCabecalhoSelected = new ContabilLancamentoCabecalhoDTO();
                viewModel.ContabilLancamentoCabecalhoSelected.ListaContabilLancamentoDetalhe = new List<ContabilLancamentoDetalheDTO>();

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
                if (viewModel.ContabilLancamentoCabecalhoSelected != null)
                {
                    viewModel.excluirContabilLancamentoCabecalho();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaContabilLancamentoCabecalho(0);
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
