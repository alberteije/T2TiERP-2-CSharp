using Cadastros.ViewModel;
using System.Windows.Controls;

namespace Comissoes.View
{
    /// <summary>
    /// Interaction logic for ComissaoPerfil.xaml
    /// </summary>
    public partial class ComissaoPerfilLista : UserControl
    {
        public ComissaoPerfilLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
