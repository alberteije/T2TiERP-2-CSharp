using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsOrdemSeparacaoCab.xaml
    /// </summary>
    public partial class WmsOrdemSeparacaoCabLista : UserControl
    {
        public WmsOrdemSeparacaoCabLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
