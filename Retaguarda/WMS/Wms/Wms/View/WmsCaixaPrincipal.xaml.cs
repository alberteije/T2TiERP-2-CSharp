using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsCaixaPrincipal.xaml
    /// </summary>
    public partial class WmsCaixaPrincipal : UserControl
    {
        private WmsCaixaViewModel viewModel;
        public WmsCaixaPrincipal()
        {
            InitializeComponent();
            viewModel = new WmsCaixaViewModel();
            this.DataContext = viewModel;
        }
    }
}
