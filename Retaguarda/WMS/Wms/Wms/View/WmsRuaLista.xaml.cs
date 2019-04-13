using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsRua.xaml
    /// </summary>
    public partial class WmsRuaLista : UserControl
    {
        public WmsRuaLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
