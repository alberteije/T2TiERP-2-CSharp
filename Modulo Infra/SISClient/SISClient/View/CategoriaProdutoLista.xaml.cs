using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for CategoriaProduto.xaml
    /// </summary>
    public partial class CategoriaProdutoLista : UserControl
    {
        public CategoriaProdutoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
