using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsArmazenamento.xaml
    /// </summary>
    public partial class WmsArmazenamentoLista : UserControl
    {
        public WmsArmazenamentoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
