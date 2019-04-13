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
using CaixaBancosClient.ViewModel.CaixaBancos;
using CaixaBancosClient.ViewModel;

namespace CaixaBancosClient.View.CaixaBancos
{
    /// <summary>
    /// Interaction logic for CaixaBancosClient.xaml
    /// </summary>
    public partial class MovimentoPrincipal : UserControl
    {
        private CaixaBancosViewModel caixaBancosViewModel;
        public MovimentoPrincipal()
        {
            InitializeComponent();
            caixaBancosViewModel = new CaixaBancosViewModel();
            DataContext = caixaBancosViewModel;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {

            string texto = ((TextBox)sender).Text;
            if (texto != null && texto.Length > 2 && texto.Split('/').Length == 1)
                ((TextBox)sender).Text = texto.Substring(0, 2) + "/" + texto.Substring(2);
        }

        private void btPesquisarMovimento_Click(object sender, RoutedEventArgs e)
        {
            caixaBancosViewModel.pesquisarMovimento();
        }

        private void btFecharMovimento_Click(object sender, RoutedEventArgs e)
        {
            caixaBancosViewModel.fecharMovimento();
        }

        private void btPesquisarContaCaixa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((CaixaBancosViewModel)DataContext).pesquisarContaCaixa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectedItem = dataGrid.Items[0];
            int offset = ((CaixaBancosViewModel)DataContext).fechamentoCaixaBancoAtual.Id - 1;

            string ConsultaSQL = "select * from VIEW_FIN_MOVIMENTO_CAIXA_BANCO limit " + ERPViewModelBase.QUANTIDADE_PAGINA + " offset " + offset;

            ((ERPViewModelBase)DataContext).exibirRelatorio("FinMovimentoCaixaBanco", "Movimento Caixa/Banco", ConsultaSQL);
        }
    }
}
