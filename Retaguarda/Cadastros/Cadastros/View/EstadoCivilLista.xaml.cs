using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for EstadoCivil.xaml
    /// </summary>
    public partial class EstadoCivilLista : UserControl
    {
        public EstadoCivilLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
