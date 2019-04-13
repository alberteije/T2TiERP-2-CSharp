using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsExpedicaoPrincipal.xaml
    /// </summary>
    public partial class WmsExpedicaoPrincipal : UserControl
    {
        private WmsExpedicaoViewModel viewModel;
        public WmsExpedicaoPrincipal()
        {
            InitializeComponent();
            viewModel = new WmsExpedicaoViewModel();
            this.DataContext = viewModel;
        }
    }
}
