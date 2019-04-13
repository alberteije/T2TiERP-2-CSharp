using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsEstante.xaml
    /// </summary>
    public partial class WmsEstanteLista : UserControl
    {
        public WmsEstanteLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
