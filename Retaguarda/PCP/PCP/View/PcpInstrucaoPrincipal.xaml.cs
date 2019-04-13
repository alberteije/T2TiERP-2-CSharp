using System.Windows.Controls;
using Cadastros.ViewModel;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for PcpInstrucaoPrincipal.xaml
    /// </summary>
    public partial class PcpInstrucaoPrincipal : UserControl
    {
        private PcpInstrucaoViewModel viewModel;
        public PcpInstrucaoPrincipal()
        {
            InitializeComponent();
            viewModel = new PcpInstrucaoViewModel();
            this.DataContext = viewModel;
        }
    }
}
