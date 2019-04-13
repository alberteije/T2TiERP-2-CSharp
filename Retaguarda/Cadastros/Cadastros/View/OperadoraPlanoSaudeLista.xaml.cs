using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for OperadoraPlanoSaude.xaml
    /// </summary>
    public partial class OperadoraPlanoSaudeLista : UserControl
    {
        public OperadoraPlanoSaudeLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
