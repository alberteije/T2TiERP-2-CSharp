using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for OperadoraPlanoSaudePrincipal.xaml
    /// </summary>
    public partial class OperadoraPlanoSaudePrincipal : UserControl
    {
        private OperadoraPlanoSaudeViewModel viewModel;
        public OperadoraPlanoSaudePrincipal()
        {
            InitializeComponent();
            viewModel = new OperadoraPlanoSaudeViewModel();
            this.DataContext = viewModel;
        }
    }
}
