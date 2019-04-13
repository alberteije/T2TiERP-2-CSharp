using Cadastros.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Comissoes.View
{
    /// <summary>
    /// Interaction logic for ComissaoObjetivo.xaml
    /// </summary>
    public partial class ComissaoObjetivo : UserControl
    {
        public ComissaoObjetivo()
        {
            InitializeComponent();
        }
		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ComissaoObjetivoViewModel)DataContext).PesquisarProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


		
		private void btPesquisar2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ComissaoObjetivoViewModel)DataContext).PesquisarPerfil();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
        
    }

}
