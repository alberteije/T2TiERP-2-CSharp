using System.Win		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WmsOrdemSeparacaoCabViewModel)DataContext).Pesquisar();
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
    /// Interaction logic for WmsOrdemSeparacaoCab.xaml
    /// </summary>
    public partial class WmsOrdemSeparacaoCab : UserControl
    {
        public WmsOrdemSeparacaoCab()
        {
            InitializeComponent();
        }
    }
}
