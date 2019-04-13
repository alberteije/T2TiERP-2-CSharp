using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsRuaPrincipal.xaml
    /// </summary>
    public partial class WmsRuaPrincipal : UserControl
    {
        private WmsRuaViewModel viewModel;
        public WmsRuaPrincipal()
        {
            InitializeComponent();
            viewModel = new WmsRuaViewModel();
            this.DataContext = viewModel;
        }
    }
}
