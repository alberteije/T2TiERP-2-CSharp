using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsExpedicao.xaml
    /// </summary>
    public partial class WmsExpedicaoLista : UserControl
    {
        public WmsExpedicaoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
