using Cadastros.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for Cargo.xaml
    /// </summary>
    public partial class Cargo : UserControl
    {
        public Cargo()
        {
            InitializeComponent();
        }

        private void btPesquisarCbo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((CargoViewModel)DataContext).PesquisarCbo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
