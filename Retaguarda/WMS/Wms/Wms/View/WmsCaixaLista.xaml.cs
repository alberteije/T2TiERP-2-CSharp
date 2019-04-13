using System.Windows.Controls;
using .ViewModel;

namespace 
{
    /// <summary>
    /// Interaction logic for WmsCaixa.xaml
    /// </summary>
    public partial class WmsCaixaLista : UserControl
    {
        public WmsCaixaLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
