using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConciliacaoContabilClient.ServicoConciliacaoContabilReference;
using ConciliacaoContabilClient.ViewModel.ConciliacaoContabil;

namespace ConciliacaoContabilClient.View.ConciliacaoContabil
{
    /// <summary>
    /// Interaction logic for ContaCaixaPrincipal.xaml
    /// </summary>
    public partial class ContaCaixaPrincipal : UserControl
    {
        private ConciliaContaCaixaViewModel viewModel;
        public ContaCaixaPrincipal()
        {
            InitializeComponent();
            viewModel = new ConciliaContaCaixaViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.ContaCaixaSelected != null)
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
