using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsRecebimentoCabecalho.xaml
    /// </summary>
    public partial class WmsRecebimentoCabecalhoLista : UserControl
    {
        public WmsRecebimentoCabecalhoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
