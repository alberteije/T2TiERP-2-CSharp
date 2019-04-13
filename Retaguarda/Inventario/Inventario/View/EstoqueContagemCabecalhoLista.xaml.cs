using System.Windows.Controls;
using Cadastros.ViewModel;

namespace EstoqueClient.View.Estoque
{
    
    public partial class EstoqueContagemCabecalhoLista : UserControl
    {
        public EstoqueContagemCabecalhoLista()
        {
            InitializeComponent();
            ViewModelBase.DataGridExportacao = this.dataGrid;
        }
       
    }
}
