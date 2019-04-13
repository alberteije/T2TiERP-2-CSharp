using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for UnidadeProduto.xaml
    /// </summary>
    public partial class UnidadeProdutoLista : UserControl
    {
        public UnidadeProdutoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
