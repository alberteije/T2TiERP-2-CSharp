using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for FuncionarioPrincipal.xaml
    /// </summary>
    public partial class FuncionarioPrincipal : UserControl
    {
        private FuncionarioViewModel viewModel;
        public FuncionarioPrincipal()
        {
            InitializeComponent();
            viewModel = new FuncionarioViewModel();
            this.DataContext = viewModel;
        }
    }
}
