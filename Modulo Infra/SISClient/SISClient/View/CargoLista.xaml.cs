using System.Windows.Controls;
using SISClient.ViewModel;

namespace SIS.View
{
    /// <summary>
    /// Interaction logic for Cargo.xaml
    /// </summary>
    public partial class CargoLista : UserControl
    {
        public CargoLista()
        {
            InitializeComponent();
            ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
