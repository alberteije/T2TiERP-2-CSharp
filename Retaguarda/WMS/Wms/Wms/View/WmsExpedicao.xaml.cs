using System.Win		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WmsExpedicaoViewModel)DataContext).Pesquisar();
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
                ((WmsExpedicaoViewModel)DataContext).Pesquisar();
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
    /// Interaction logic for WmsExpedicao.xaml
    /// </summary>
    public partial class WmsExpedicao : UserControl
    {
        public WmsExpedicao()
        {
            InitializeComponent();
        }
    }
}
