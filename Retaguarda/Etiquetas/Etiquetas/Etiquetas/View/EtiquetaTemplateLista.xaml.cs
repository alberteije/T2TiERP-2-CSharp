using System.Windows.Controls;
using Cadastros.ViewModel;

namespace Etiquetas.View
{
    /// <summary>
    /// Interaction logic for EtiquetaTemplate.xaml
    /// </summary>
    public partial class EtiquetaTemplateLista : UserControl
    {
        public EtiquetaTemplateLista()
        {
            InitializeComponent();
			ViewModelBase.DataGridExportacao = this.dataGrid;
        }
    }
}
