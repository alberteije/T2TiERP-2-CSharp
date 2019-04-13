using Cadastros.ViewModel;
using System.Windows.Controls;

namespace OrdemServico.View
{
    /// <summary>
    /// Interaction logic for OsStatus.xaml
    /// </summary>
    public partial class OsStatusLista : UserControl
    {
        public OsStatusLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
