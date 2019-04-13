using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for EstadoCivilPrincipal.xaml
    /// </summary>
    public partial class EstadoCivilPrincipal : UserControl
    {
        private EstadoCivilViewModel viewModel;
        public EstadoCivilPrincipal()
        {
            InitializeComponent();
            viewModel = new EstadoCivilViewModel();
            this.DataContext = viewModel;
        }
    }
}
