using System.Win		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WmsParametroViewModel)DataContext).Pesquisar();
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
    /// Interaction logic for WmsParametro.xaml
    /// </summary>
    public partial class WmsParametro : UserControl
    {
        public WmsParametro()
        {
            InitializeComponent();
        }
    }
}
