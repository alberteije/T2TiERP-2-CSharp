using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsOrdemSeparacaoCabPrincipal.xaml
    /// </summary>
    public partial class WmsOrdemSeparacaoCabPrincipal : UserControl
    {
        private WmsOrdemSeparacaoCabViewModel viewModel;
        public WmsOrdemSeparacaoCabPrincipal()
        {
            InitializeComponent();
            viewModel = new WmsOrdemSeparacaoCabViewModel();
            this.DataContext = viewModel;
        }
    }
}
