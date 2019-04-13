using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsEstantePrincipal.xaml
    /// </summary>
    public partial class WmsEstantePrincipal : UserControl
    {
        private WmsEstanteViewModel viewModel;
        public WmsEstantePrincipal()
        {
            InitializeComponent();
            viewModel = new WmsEstanteViewModel();
            this.DataContext = viewModel;
        }
    }
}
