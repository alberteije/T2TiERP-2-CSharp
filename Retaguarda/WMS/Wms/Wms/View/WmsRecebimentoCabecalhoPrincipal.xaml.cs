using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsRecebimentoCabecalhoPrincipal.xaml
    /// </summary>
    public partial class WmsRecebimentoCabecalhoPrincipal : UserControl
    {
        private WmsRecebimentoCabecalhoViewModel viewModel;
        public WmsRecebimentoCabecalhoPrincipal()
        {
            InitializeComponent();
            viewModel = new WmsRecebimentoCabecalhoViewModel();
            this.DataContext = viewModel;
        }
    }
}
