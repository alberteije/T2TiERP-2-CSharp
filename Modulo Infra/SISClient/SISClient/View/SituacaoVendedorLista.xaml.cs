using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for SituacaoVendedor.xaml
    /// </summary>
    public partial class SituacaoVendedorLista : UserControl
    {
        public SituacaoVendedorLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
