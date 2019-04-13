using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for AtividadeForCli.xaml
    /// </summary>
    public partial class AtividadeForCliLista : UserControl
    {
        public AtividadeForCliLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
