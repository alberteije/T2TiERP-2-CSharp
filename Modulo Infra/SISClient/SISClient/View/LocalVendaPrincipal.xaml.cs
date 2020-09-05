using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{
    /// <summary>
    /// Interaction logic for LocalVendaPrincipal.xaml
    /// </summary>
    public partial class LocalVendaPrincipal : UserControl
    {
        private LocalVendaViewModel viewModel;
        public LocalVendaPrincipal()
        {
            InitializeComponent();
            viewModel = new LocalVendaViewModel();
            this.DataContext = viewModel;
        }
    }
}
