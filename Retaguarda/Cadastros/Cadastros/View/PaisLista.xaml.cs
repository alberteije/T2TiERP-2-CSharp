using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for Pais.xaml
    /// </summary>
    public partial class PaisLista : UserControl
    {
        public PaisLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
