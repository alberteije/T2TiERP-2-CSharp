using BalcaoPAF.ViewModel;
using System.Windows.Controls;

namespace BalcaoPAF.View
{
    /// <summary>
    /// Interaction logic for DavCabecalho.xaml
    /// </summary>
    public partial class DavCabecalhoLista : UserControl
    {
        public DavCabecalhoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
