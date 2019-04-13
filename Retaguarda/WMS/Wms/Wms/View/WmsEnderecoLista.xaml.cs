using System.Windows.Controls;
using Cadastros.ViewModel;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for WmsEndereco.xaml
    /// </summary>
    public partial class WmsEnderecoLista : UserControl
    {
        public WmsEnderecoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
