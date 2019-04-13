using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for AtividadeForCliPrincipal.xaml
    /// </summary>
    public partial class AtividadeForCliPrincipal : UserControl
    {
        private AtividadeForCliViewModel viewModel;
        public AtividadeForCliPrincipal()
        {
            InitializeComponent();
            viewModel = new AtividadeForCliViewModel();
            this.DataContext = viewModel;
        }
    }
}
