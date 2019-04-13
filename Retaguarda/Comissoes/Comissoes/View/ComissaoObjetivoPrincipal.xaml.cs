using System.Windows.Controls;
using Cadastros.ViewModel;

namespace Comissoes.View
{
    /// <summary>
    /// Interaction logic for ComissaoObjetivoPrincipal.xaml
    /// </summary>
    public partial class ComissaoObjetivoPrincipal : UserControl
    {
        private ComissaoObjetivoViewModel viewModel;
        public ComissaoObjetivoPrincipal()
        {
            InitializeComponent();
            viewModel = new ComissaoObjetivoViewModel();
            this.DataContext = viewModel;
        }
    }
}
