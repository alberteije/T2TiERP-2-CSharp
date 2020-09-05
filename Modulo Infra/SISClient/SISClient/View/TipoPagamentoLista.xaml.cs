using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for TipoPagamento.xaml
    /// </summary>
    public partial class TipoPagamentoLista : UserControl
    {
        public TipoPagamentoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
