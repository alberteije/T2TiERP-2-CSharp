using System;
using System.Windows;
using System.Windows.Controls;
using ContasReceberClient.ViewModel.ContasReceber;
using ContasReceberClient.ContasReceberService;
using System.Collections.Generic;

namespace ContasReceberClient.View.ContasReceber
{
    /// <summary>
    /// Interaction logic for ViewFinLancamentoReceberPrincipal.xaml
    /// </summary>
    public partial class ViewFinLancamentoReceberPrincipal : UserControl
    {
        private ViewFinLancamentoReceberViewModel viewModel;
        public ViewFinLancamentoReceberPrincipal()
        {
            InitializeComponent();
            viewModel = new ViewFinLancamentoReceberViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.ViewFinLancamentoReceberSelected != null)
                {
                    this.criarListas(viewModel.ViewFinLancamentoReceberSelected);
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

        private void criarListas(ViewFinLancamentoReceberDTO lancamento)
        {
            try
            {
                if (lancamento.ListaFinParcelaRecebimento == null)
                    lancamento.ListaFinParcelaRecebimento = new List<FinParcelaRecebimentoDTO>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}
