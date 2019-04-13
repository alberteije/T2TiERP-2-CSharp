using BalcaoPAF.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BalcaoPAF.View
{
    /// <summary>
    /// Interaction logic for DavCabecalho.xaml
    /// </summary>
    public partial class DavCabecalho : UserControl
    {
        public DavCabecalho()
        {
            InitializeComponent();
        }

    	private void btPesquisarPessoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((DavCabecalhoViewModel)DataContext).PesquisarPessoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}		




