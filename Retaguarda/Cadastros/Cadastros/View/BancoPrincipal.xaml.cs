using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for BancoPrincipal.xaml
    /// </summary>
    public partial class BancoPrincipal : UserControl
    {
        private BancoViewModel viewModel;
        public BancoPrincipal()
        {
            InitializeComponent();
            viewModel = new BancoViewModel();
            this.DataContext = viewModel;
        }
    }
}
