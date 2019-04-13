using System.Windows.Controls;
using Cadastros.ViewModel;

namespace OrdemServico.View
{
    /// <summary>
    /// Interaction logic for OsEquipamento.xaml
    /// </summary>
    public partial class OsEquipamentoLista : UserControl
    {
        public OsEquipamentoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
