using System.Windows.Controls;
using Cadastros.ViewModel;

namespace Comissoes.View
{
    /// <summary>
    /// Interaction logic for ComissaoObjetivo.xaml
    /// </summary>
    public partial class ComissaoObjetivoLista : UserControl
    {
        public ComissaoObjetivoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
