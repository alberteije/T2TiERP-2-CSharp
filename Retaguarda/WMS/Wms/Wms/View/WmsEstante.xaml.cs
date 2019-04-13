using System.Win		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WmsEstanteViewModel)DataContext).Pesquisar();
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
    /// Interaction logic for WmsEstante.xaml
    /// </summary>
    public partial class WmsEstante : UserControl
    {
        public WmsEstante()
        {
            InitializeComponent();
        }
    }
}
