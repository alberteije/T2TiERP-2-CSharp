using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ConciliacaoContabilClient.View.ConciliacaoContabil
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

    }
}
