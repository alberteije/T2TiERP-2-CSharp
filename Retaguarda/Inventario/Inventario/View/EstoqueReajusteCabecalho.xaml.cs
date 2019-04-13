using Cadastros.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EstoqueClient.View.Estoque
{
    /// <summary>
    /// Interaction logic for EstoqueReajusteCabecalho.xaml
    /// </summary>
    public partial class EstoqueReajusteCabecalho : UserControl
    {
        public EstoqueReajusteCabecalho()
        {
            InitializeComponent();
        }
       

		private void btPesquisarColaborador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((EstoqueReajusteCabecalhoViewModel)DataContext).pesquisarColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
