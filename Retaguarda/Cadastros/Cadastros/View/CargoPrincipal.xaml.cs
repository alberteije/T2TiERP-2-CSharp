using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for CargoPrincipal.xaml
    /// </summary>
    public partial class CargoPrincipal : UserControl
    {
        private CargoViewModel viewModel;
        public CargoPrincipal()
        {
            InitializeComponent();
            viewModel = new CargoViewModel();
            this.DataContext = viewModel;
        }
    }
}
