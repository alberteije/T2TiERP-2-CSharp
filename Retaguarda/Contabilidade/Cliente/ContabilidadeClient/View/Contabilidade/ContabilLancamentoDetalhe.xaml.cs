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

namespace ContabilidadeClient.View.Contabilidade
{
    /// <summary>
    /// Interaction logic for Detalhe.xaml
    /// </summary>
    public partial class ContabilLancamentoDetalhe : UserControl
    {
        public ContabilLancamentoDetalhe()
        {
            InitializeComponent();
        }


        private void btPesquisarContabilHistorico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilLancamentoCabecalhoViewModel)DataContext).pesquisarContabilHistorico();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisarContabilConta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ContabilLancamentoCabecalhoViewModel)DataContext).pesquisarContabilConta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
