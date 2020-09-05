using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for LocalVenda.xaml
    /// </summary>
    public partial class LocalVendaLista : UserControl
    {
        public LocalVendaLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
