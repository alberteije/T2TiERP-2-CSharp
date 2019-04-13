using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ViewModel.ContasPagar;
using ContasPagarClient.ContasPagarService;
using System.Collections.Generic;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for FinLancamentoPagarPrincipal.xaml
    /// </summary>
    public partial class FinLancamentoPagarPrincipal : UserControl
    {
        private FinLancamentoPagarViewModel viewModel;
        public FinLancamentoPagarPrincipal()
        {
            InitializeComponent();
            viewModel = new FinLancamentoPagarViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FinLancamentoPagarSelected != null)
                {
                    this.criarListas(viewModel.FinLancamentoPagarSelected);
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

        private void criarListas(FinLancamentoPagarDTO lancamento)
        {
            try
            {
                if (lancamento.ListaFinParcelaPagar == null)
                    lancamento.ListaFinParcelaPagar = new List<FinParcelaPagarDTO>();
                if (lancamento.ListaNaturezaFinanceira == null)
                    lancamento.ListaNaturezaFinanceira = new List<FinLctoPagarNtFinanceiraDTO>();
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
                FinLancamentoPagarDTO lancamento = new FinLancamentoPagarDTO();
                this.criarListas(lancamento);
                viewModel.FinLancamentoPagarSelected = lancamento;
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
                if (viewModel.FinLancamentoPagarSelected != null)
                {
                    viewModel.excluirFinLancamentoPagar();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFinLancamentoPagar(0);
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
