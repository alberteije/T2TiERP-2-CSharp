using System.Win		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WmsArmazenamentoViewModel)DataContext).Pesquisar();
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
                ((WmsArmazenamentoViewModel)DataContext).Pesquisar();
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
    /// Interaction logic for WmsArmazenamento.xaml
    /// </summary>
    public partial class WmsArmazenamento : UserControl
    {
        public WmsArmazenamento()
        {
            InitializeComponent();
        }
    }
}
