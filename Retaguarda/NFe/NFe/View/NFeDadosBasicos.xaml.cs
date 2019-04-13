using NFe.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NFe.View
{
    /// <summary>
    /// Interaction logic for NFeDadosBasicos.xaml
    /// </summary>
    public partial class NFeDadosBasicos : UserControl
    {
        public NFeDadosBasicos()
        {
            InitializeComponent();
        }

        private void btPesquisarProduto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((NFeViewModel)DataContext).PesquisarOperacaoFiscal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
    }
}
