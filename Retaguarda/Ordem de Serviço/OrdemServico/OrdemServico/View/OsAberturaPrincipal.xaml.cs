using System.Windows.Controls;
using Cadastros.ViewModel;

namespace OrdemServico.View
{
    /// <summary>
    /// Interaction logic for OsAberturaPrincipal.xaml
    /// </summary>
    public partial class OsAberturaPrincipal : UserControl
    {
        private OsAberturaViewModel viewModel;
        public OsAberturaPrincipal()
        {
            InitializeComponent();
            viewModel = new OsAberturaViewModel();
            this.DataContext = viewModel;
        }
    }
}
