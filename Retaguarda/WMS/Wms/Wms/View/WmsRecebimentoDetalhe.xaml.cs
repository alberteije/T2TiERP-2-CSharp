using System.Win		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WmsRecebimentoDetalheViewModel)DataContext).Pesquisar();
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
                ((WmsRecebimentoDetalheViewModel)DataContext).Pesquisar();
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
    /// Interaction logic for WmsRecebimentoDetalhe.xaml
    /// </summary>
    public partial class WmsRecebimentoDetalhe : UserControl
    {
        public WmsRecebimentoDetalhe()
        {
            InitializeComponent();
        }
    }
}
