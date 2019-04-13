using System.Windows.Controls;
using Cadastros.ViewModel;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for PcpInstrucao.xaml
    /// </summary>
    public partial class PcpInstrucaoLista : UserControl
    {
        public PcpInstrucaoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
