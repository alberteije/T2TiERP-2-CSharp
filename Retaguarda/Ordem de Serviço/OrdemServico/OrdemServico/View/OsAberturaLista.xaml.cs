using System.Windows.Controls;
using Cadastros.ViewModel;

namespace OrdemServico.View
{
    /// <summary>
    /// Interaction logic for OsAbertura.xaml
    /// </summary>
    public partial class OsAberturaLista : UserControl
    {
        public OsAberturaLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
