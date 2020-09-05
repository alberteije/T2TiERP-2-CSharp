using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for Produto.xaml
    /// </summary>
    public partial class ProdutoLista : UserControl
    {
        public ProdutoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
