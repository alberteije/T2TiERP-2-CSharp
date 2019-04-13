using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsRecebimentoDetalhePrincipal.xaml
    /// </summary>
    public partial class WmsRecebimentoDetalhePrincipal : UserControl
    {
        private WmsRecebimentoDetalheViewModel viewModel;
        public WmsRecebimentoDetalhePrincipal()
        {
            InitializeComponent();
            viewModel = new WmsRecebimentoDetalheViewModel();
            this.DataContext = viewModel;
        }
    }
}
