using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;
using ContasReceberClient.ContasReceberService;
using System.Collections.Generic;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for FinLancamentoReceberPrincipal.xaml
    /// </summary>
    public partial class FinLancamentoReceberPrincipal : UserControl
    {
        private FinLancamentoReceberViewModel viewModel;
        public FinLancamentoReceberPrincipal()
        {
            InitializeComponent();
            viewModel = new FinLancamentoReceberViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FinLancamentoReceberSelected != null)
                {
                    this.criarListas(viewModel.FinLancamentoReceberSelected);
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

        private void criarListas(FinLancamentoReceberDTO lancamento)
        {
            try
            {
                if (lancamento.ListaFinParcelaReceber == null)
                    lancamento.ListaFinParcelaReceber = new List<FinParcelaReceberDTO>();
                if (lancamento.ListaNaturezaFinanceira == null)
                    lancamento.ListaNaturezaFinanceira = new List<FinLctoReceberNtFinanceiraDTO>();
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
                FinLancamentoReceberDTO lancamento = new FinLancamentoReceberDTO();
                this.criarListas(lancamento);
                viewModel.FinLancamentoReceberSelected = lancamento;
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
                if (viewModel.FinLancamentoReceberSelected != null)
                {
                    viewModel.excluirFinLancamentoReceber();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFinLancamentoReceber(0);
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
