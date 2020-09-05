using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for SituacaoVendedorPrincipal.xaml
    /// </summary>
    public partial class SituacaoVendedorPrincipal : UserControl
    {
        private SituacaoVendedorViewModel viewModel;
        public SituacaoVendedorPrincipal()
        {
            InitializeComponent();
            viewModel = new SituacaoVendedorViewModel();
            this.DataContext = viewModel;
        }
    }
}
