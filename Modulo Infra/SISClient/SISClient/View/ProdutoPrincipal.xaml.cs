using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for ProdutoPrincipal.xaml
    /// </summary>
    public partial class ProdutoPrincipal : UserControl
    {
        private ProdutoViewModel viewModel;
        public ProdutoPrincipal()
        {
            InitializeComponent();
            viewModel = new ProdutoViewModel();
            this.DataContext = viewModel;
        }
    }
}
