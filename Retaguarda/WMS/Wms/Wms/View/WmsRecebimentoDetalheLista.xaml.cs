using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsRecebimentoDetalhe.xaml
    /// </summary>
    public partial class WmsRecebimentoDetalheLista : UserControl
    {
        public WmsRecebimentoDetalheLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
