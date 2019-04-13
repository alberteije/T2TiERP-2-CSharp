using System;
using System.Windows;
using System.Windows.Controls;
using ContasPagarClient.ViewModel.ContasPagar;
using ContasPagarClient.ContasPagarService;
using System.Collections.Generic;

namespace ContasPagarClient.View.ContasPagar
{
    /// <summary>
    /// Interaction logic for ViewFinLancamentoPagarPrincipal.xaml
    /// </summary>
    public partial class ViewFinLancamentoPagarPrincipal : UserControl
    {
        private ViewFinLancamentoPagarViewModel viewModel;
        public ViewFinLancamentoPagarPrincipal()
        {
            InitializeComponent();
            viewModel = new ViewFinLancamentoPagarViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.ViewFinLancamentoPagarSelected != null)
                {
                    this.criarListas(viewModel.ViewFinLancamentoPagarSelected);
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

        private void criarListas(ViewFinLancamentoPagarDTO lancamento)
        {
            try
            {
                if (lancamento.ListaFinParcelaPagamento == null)
                    lancamento.ListaFinParcelaPagamento = new List<FinParcelaPagamentoDTO>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}
