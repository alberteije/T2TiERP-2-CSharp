using Cadastros.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for Pessoa.xaml
    /// </summary>
    public partial class Pessoa : UserControl
    {
        public Pessoa()
        {
            InitializeComponent();
        }

        private void CheckCliente_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked.Value)
                TabCliente.Visibility = Visibility.Visible;
            else
                TabCliente.Visibility = Visibility.Collapsed;
        }

        private void CheckFornecedor_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked.Value)
                TabFornecedor.Visibility = Visibility.Visible;
            else
                TabFornecedor.Visibility = Visibility.Collapsed;
        }

        private void CheckTransportadora_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked.Value)
                TabTransportadora.Visibility = Visibility.Visible;
            else
                TabTransportadora.Visibility = Visibility.Collapsed;
        }

    }
}
