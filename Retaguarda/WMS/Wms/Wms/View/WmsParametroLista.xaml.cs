using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsParametro.xaml
    /// </summary>
    public partial class WmsParametroLista : UserControl
    {
        public WmsParametroLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
