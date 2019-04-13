using System.Windows.Controls;
using Cadastros.ViewModel;

namespace OrdemServico.View
{
    /// <summary>
    /// Interaction logic for OsEquipamentoPrincipal.xaml
    /// </summary>
    public partial class OsEquipamentoPrincipal : UserControl
    {
        private OsEquipamentoViewModel viewModel;
        public OsEquipamentoPrincipal()
        {
            InitializeComponent();
            viewModel = new OsEquipamentoViewModel();
            this.DataContext = viewModel;
        }
    }
}
