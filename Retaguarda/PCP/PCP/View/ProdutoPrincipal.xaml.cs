using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
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
