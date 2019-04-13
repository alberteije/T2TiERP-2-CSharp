using System.Win		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WmsRecebimentoCabecalhoViewModel)DataContext).Pesquisar();
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
    /// Interaction logic for WmsRecebimentoCabecalho.xaml
    /// </summary>
    public partial class WmsRecebimentoCabecalho : UserControl
    {
        public WmsRecebimentoCabecalho()
        {
            InitializeComponent();
        }
    }
}
