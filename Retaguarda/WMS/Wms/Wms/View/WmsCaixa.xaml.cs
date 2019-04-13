using System.Win		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WmsCaixaViewModel)DataContext).Pesquisar();
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
    /// Interaction logic for WmsCaixa.xaml
    /// </summary>
    public partial class WmsCaixa : UserControl
    {
        public WmsCaixa()
        {
            InitializeComponent();
        }
    }
}
