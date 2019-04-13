using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsParametroPrincipal.xaml
    /// </summary>
    public partial class WmsParametroPrincipal : UserControl
    {
        private WmsParametroViewModel viewModel;
        public WmsParametroPrincipal()
        {
            InitializeComponent();
            viewModel = new WmsParametroViewModel();
            this.DataContext = viewModel;
        }
    }
}
