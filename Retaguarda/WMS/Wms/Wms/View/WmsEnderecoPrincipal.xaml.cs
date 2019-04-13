using System.Windows.Controls;
using Cadastros.ViewModel;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for WmsEnderecoPrincipal.xaml
    /// </summary>
    public partial class WmsEnderecoPrincipal : UserControl
    {
        private WmsRuaViewModel viewModel;
        public WmsEnderecoPrincipal()
        {
            InitializeComponent();
            viewModel = new WmsRuaViewModel();
            this.DataContext = viewModel;
        }
    }
}
