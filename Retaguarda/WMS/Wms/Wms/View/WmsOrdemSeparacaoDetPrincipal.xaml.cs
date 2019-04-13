using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsOrdemSeparacaoDetPrincipal.xaml
    /// </summary>
    public partial class WmsOrdemSeparacaoDetPrincipal : UserControl
    {
        private WmsOrdemSeparacaoDetViewModel viewModel;
        public WmsOrdemSeparacaoDetPrincipal()
        {
            InitializeComponent();
            viewModel = new WmsOrdemSeparacaoDetViewModel();
            this.DataContext = viewModel;
        }
    }
}
