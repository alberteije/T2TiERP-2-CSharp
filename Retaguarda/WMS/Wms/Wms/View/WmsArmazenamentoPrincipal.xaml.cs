using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsArmazenamentoPrincipal.xaml
    /// </summary>
    public partial class WmsArmazenamentoPrincipal : UserControl
    {
        private WmsArmazenamentoViewModel viewModel;
        public WmsArmazenamentoPrincipal()
        {
            InitializeComponent();
            viewModel = new WmsArmazenamentoViewModel();
            this.DataContext = viewModel;
        }
    }
}
