using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsAgendamento.xaml
    /// </summary>
    public partial class WmsAgendamentoLista : UserControl
    {
        public WmsAgendamentoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
