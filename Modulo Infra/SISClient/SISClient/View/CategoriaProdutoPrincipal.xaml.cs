using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for CategoriaProdutoPrincipal.xaml
    /// </summary>
    public partial class CategoriaProdutoPrincipal : UserControl
    {
        private CategoriaProdutoViewModel viewModel;
        public CategoriaProdutoPrincipal()
        {
            InitializeComponent();
            viewModel = new CategoriaProdutoViewModel();
            this.DataContext = viewModel;
        }
    }
}
