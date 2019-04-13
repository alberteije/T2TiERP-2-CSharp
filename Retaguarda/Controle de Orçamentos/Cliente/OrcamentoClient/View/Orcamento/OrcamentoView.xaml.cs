using System.Windows.Controls;
using OrcamentoClient.ViewModel.Orcamento;

namespace OrcamentoClient.View.Orcamento
{
    public partial class OrcamentoView : UserControl
    {
        OrcamentoViewModel orcamentoViewModel = new OrcamentoViewModel();

        public OrcamentoView()
        {
            InitializeComponent();
            DataContext = orcamentoViewModel;
        }

    }
}
