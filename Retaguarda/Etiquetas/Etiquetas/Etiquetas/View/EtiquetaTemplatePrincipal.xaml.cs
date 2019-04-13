using System.Windows.Controls;
using Cadastros.ViewModel;

namespace Etiquetas.View
{
    /// <summary>
    /// Interaction logic for EtiquetaTemplatePrincipal.xaml
    /// </summary>
    public partial class EtiquetaTemplatePrincipal : UserControl
    {
        private EtiquetaTemplateViewModel viewModel;
        public EtiquetaTemplatePrincipal()
        {
            InitializeComponent();
            viewModel = new EtiquetaTemplateViewModel();
            this.DataContext = viewModel;
        }
    }
}
