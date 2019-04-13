using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Comissoes.View
{
    /// <summary>
    /// Interaction logic for ComissaoPerfilPrincipal.xaml
    /// </summary>
    public partial class ComissaoPerfilPrincipal : UserControl
    {
        private ComissaoPerfilViewModel viewModel;
        public ComissaoPerfilPrincipal()
        {
            InitializeComponent();
            viewModel = new ComissaoPerfilViewModel();
            this.DataContext = viewModel;
        }
    }
}
