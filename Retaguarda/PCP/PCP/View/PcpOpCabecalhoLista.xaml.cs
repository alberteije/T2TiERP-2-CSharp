using System.Windows.Controls;
using Cadastros.ViewModel;

namespace Cadastros.View
{
    /// <summary>
    /// Interaction logic for PcpOpCabecalho.xaml
    /// </summary>
    public partial class PcpOpCabecalhoLista : UserControl
    {
        public PcpOpCabecalhoLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
