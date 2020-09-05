using System.Windows.Controls;
using System.Windows;
using SISClient.ViewModel;
using System;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for Funcionario.xaml
    /// </summary>
    public partial class Funcionario : UserControl
    {
        public Funcionario()
        {
            InitializeComponent();
        }

        private void btPesquisarCargo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((FuncionarioViewModel)DataContext).PesquisarCargo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
