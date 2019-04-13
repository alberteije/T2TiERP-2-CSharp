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

namespace 
{
    /// <summary>
    /// Interaction logic for Detalhe.xaml
    /// </summary>
    public partial class OsProdutoServico : UserControl
    {
        public OsProdutoServico()
        {
            InitializeComponent();
        }

		[EventoPesquisar]		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OsProdutoServicoViewModel)DataContext).Pesquisar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((OsProdutoServicoViewModel)DataContext).Pesquisar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
