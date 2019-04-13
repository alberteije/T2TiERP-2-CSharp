using Cadastros.ViewModel;
using System.Windows.Controls;

namespace OrdemServico.View
{
    /// <summary>
    /// Interaction logic for OsStatusPrincipal.xaml
    /// </summary>
    public partial class OsStatusPrincipal : UserControl
    {
        private OsStatusViewModel viewModel;
        public OsStatusPrincipal()
        {
            InitializeComponent();
            viewModel = new OsStatusViewModel();
            this.DataContext = viewModel;
        }
    }
}
