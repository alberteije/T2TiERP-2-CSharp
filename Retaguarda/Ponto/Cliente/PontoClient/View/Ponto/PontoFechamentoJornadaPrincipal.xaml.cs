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
using PontoClient.ViewModel.Ponto;

namespace PontoClient.View.Ponto
{
    /// <summary>
    /// Interaction logic for PontoFechamentoJornadaPrincipal.xaml
    /// </summary>
    public partial class PontoFechamentoJornadaPrincipal : UserControl
    {
        private PontoFechamentoJornadaViewModel viewModel;
        public PontoFechamentoJornadaPrincipal()
        {
            InitializeComponent();
            viewModel = new PontoFechamentoJornadaViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
        }

    }
}
