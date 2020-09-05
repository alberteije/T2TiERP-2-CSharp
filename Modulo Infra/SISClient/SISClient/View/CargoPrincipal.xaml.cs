using System.Windows.Controls;
using SISClient.ViewModel;

namespace SIS.View
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
