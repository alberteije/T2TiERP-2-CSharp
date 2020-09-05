using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for VendedorPrincipal.xaml
    /// </summary>
    public partial class VendedorPrincipal : UserControl
    {
        private VendedorViewModel viewModel;
        public VendedorPrincipal()
        {
            InitializeComponent();
            viewModel = new VendedorViewModel();
            this.DataContext = viewModel;
        }
    }
}
