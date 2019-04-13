using System;
using System.Windows;
using System.Windows.Controls;
using OrcamentoClient.ViewModel.Orcamento;

namespace OrcamentoClient.View.Orcamento
{
    /// <summary>
    /// Interaction logic for OrcamentoPeriodo.xaml
    /// </summary>
    public partial class OrcamentoPeriodo : UserControl
    {
        public OrcamentoPeriodo()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OrcamentoPeriodoViewModel)this.DataContext).IsEditar= false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
