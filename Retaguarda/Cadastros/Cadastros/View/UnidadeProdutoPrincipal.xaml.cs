using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for UnidadeProdutoPrincipal.xaml
    /// </summary>
    public partial class UnidadeProdutoPrincipal : UserControl
    {
        private UnidadeProdutoViewModel viewModel;
        public UnidadeProdutoPrincipal()
        {
            InitializeComponent();
            viewModel = new UnidadeProdutoViewModel();
            this.DataContext = viewModel;
        }
    }
}
