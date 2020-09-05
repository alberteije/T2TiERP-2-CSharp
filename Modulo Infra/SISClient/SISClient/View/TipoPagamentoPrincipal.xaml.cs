using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for TipoPagamentoPrincipal.xaml
    /// </summary>
    public partial class TipoPagamentoPrincipal : UserControl
    {
        private TipoPagamentoViewModel viewModel;
        public TipoPagamentoPrincipal()
        {
            InitializeComponent();
            viewModel = new TipoPagamentoViewModel();
            this.DataContext = viewModel;
        }
    }
}
