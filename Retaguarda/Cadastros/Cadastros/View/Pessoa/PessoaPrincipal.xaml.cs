using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for PessoaPrincipal.xaml
    /// </summary>
    public partial class PessoaPrincipal : UserControl
    {
        private PessoaViewModel viewModel;
        public PessoaPrincipal()
        {
            InitializeComponent();
            viewModel = new PessoaViewModel();
            this.DataContext = viewModel;
        }
    }
}
