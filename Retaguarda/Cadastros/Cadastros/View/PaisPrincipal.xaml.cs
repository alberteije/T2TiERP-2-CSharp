using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for PaisPrincipal.xaml
    /// </summary>
    public partial class PaisPrincipal : UserControl
    {
        private PaisViewModel viewModel;
        public PaisPrincipal()
        {
            InitializeComponent();
            viewModel = new PaisViewModel();
            this.DataContext = viewModel;
        }
    }
}
