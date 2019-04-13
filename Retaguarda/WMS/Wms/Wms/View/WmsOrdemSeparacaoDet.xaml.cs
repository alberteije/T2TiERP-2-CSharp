using System.Win		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WmsOrdemSeparacaoDetViewModel)DataContext).Pesquisar();
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
                ((WmsOrdemSeparacaoDetViewModel)DataContext).Pesquisar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

dows.Controls;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsOrdemSeparacaoDet.xaml
    /// </summary>
    public partial class WmsOrdemSeparacaoDet : UserControl
    {
        public WmsOrdemSeparacaoDet()
        {
            InitializeComponent();
        }
    }
}
