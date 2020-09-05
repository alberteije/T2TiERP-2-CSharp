using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for Funcionario.xaml
    /// </summary>
    public partial class FuncionarioLista : UserControl
    {
        public FuncionarioLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
