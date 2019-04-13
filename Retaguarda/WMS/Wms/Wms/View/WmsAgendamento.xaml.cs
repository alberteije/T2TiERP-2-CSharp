using System.Win		
		private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((WmsAgendamentoViewModel)DataContext).Pesquisar();
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
    /// Interaction logic for WmsAgendamento.xaml
    /// </summary>
    public partial class WmsAgendamento : UserControl
    {
        public WmsAgendamento()
        {
            InitializeComponent();
        }
    }
}
