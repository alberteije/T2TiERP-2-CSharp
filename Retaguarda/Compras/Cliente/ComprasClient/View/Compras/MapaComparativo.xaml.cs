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
using ComprasClient.ViewModel.Compras;

namespace ComprasClient.View.Compras
{
    /// <summary>
    /// Interaction logic for MapaComparativo.xaml
    /// </summary>
    public partial class MapaComparativo : UserControl
    {
        private MapaComparativoViewModel viewModel;

        public MapaComparativo()
        {
            InitializeComponent();
            viewModel = new MapaComparativoViewModel();
            this.DataContext = viewModel;
        }

        private void btConfirmarPedido_Click(object sender, RoutedEventArgs e)
        {
            ((MapaComparativoViewModel)this.DataContext).incluir();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            ((MapaComparativoViewModel)this.DataContext).cancelarOperacao();
        }

        private void btConfirmar_Click(object sender, RoutedEventArgs e)
        {
            ((MapaComparativoViewModel)this.DataContext).executarOperacao();
        }

        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            ((MapaComparativoViewModel)this.DataContext).pesquisar();
        }
    }
}
