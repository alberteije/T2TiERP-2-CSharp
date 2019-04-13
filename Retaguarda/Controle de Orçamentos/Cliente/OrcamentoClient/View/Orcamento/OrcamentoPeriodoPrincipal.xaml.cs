using System;
using System.Windows;
using System.Windows.Controls;
using OrcamentoClient.ViewModel.Orcamento;
using OrcamentoClient.OrcamentoReference;

namespace OrcamentoClient.View.Orcamento
{
    /// <summary>
    /// Interaction logic for OrcamentoPeriodoPrincipal.xaml
    /// </summary>
    public partial class OrcamentoPeriodoPrincipal : UserControl
    {
        private OrcamentoPeriodoViewModel viewModel;
        public OrcamentoPeriodoPrincipal()
        {
            InitializeComponent();
            viewModel = new OrcamentoPeriodoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.OrcamentoPeriodoSelected != null)
                    viewModel.IsEditar = true;
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
