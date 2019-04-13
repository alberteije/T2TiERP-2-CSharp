using System.Windows.Controls;
using Cadastros.ViewModel;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for PcpOpCabecalhoPrincipal.xaml
    /// </summary>
    public partial class PcpOpCabecalhoPrincipal : UserControl
    {
        private PcpOpCabecalhoViewModel viewModel;
        public PcpOpCabecalhoPrincipal()
        {
            InitializeComponent();
            viewModel = new PcpOpCabecalhoViewModel();
            this.DataContext = viewModel;
        }
    }
}
