using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for Vendedor.xaml
    /// </summary>
    public partial class VendedorLista : UserControl
    {
        public VendedorLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
