using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsOrdemSeparacaoDet.xaml
    /// </summary>
    public partial class WmsOrdemSeparacaoDetLista : UserControl
    {
        public WmsOrdemSeparacaoDetLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
