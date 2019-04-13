using BalcaoPAF.ViewModel;
using System.Windows.Controls;

namespace BalcaoPAF.View
{
    /// <summary>
    /// Interaction logic for DavCabecalhoPrincipal.xaml
    /// </summary>
    public partial class DavCabecalhoPrincipal : UserControl
    {
        private DavCabecalhoViewModel viewModel;
        public DavCabecalhoPrincipal()
        {
            InitializeComponent();
            viewModel = new DavCabecalhoViewModel();
            this.DataContext = viewModel;
        }
    }
}
