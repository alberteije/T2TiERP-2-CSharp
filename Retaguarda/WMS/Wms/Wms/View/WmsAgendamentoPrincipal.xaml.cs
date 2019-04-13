using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsAgendamentoPrincipal.xaml
    /// </summary>
    public partial class WmsAgendamentoPrincipal : UserControl
    {
        private WmsAgendamentoViewModel viewModel;
        public WmsAgendamentoPrincipal()
        {
            InitializeComponent();
            viewModel = new WmsAgendamentoViewModel();
            this.DataContext = viewModel;
        }
    }
}
