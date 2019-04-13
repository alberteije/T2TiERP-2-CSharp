using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GEDClient.ViewModel.GED;

namespace GEDClient.View.GED
{
    /// <summary>
    /// Interaction logic for ModuloIncluirDocumentoView.xaml
    /// </summary>
    public partial class ModuloIncluirDocumentoView : UserControl
    {
        private GEDClientViewModel gedClientViewModel;
        public int? idDocumento { get; set; }
        public ModuloIncluirDocumentoView()
        {
            InitializeComponent();
            GEDClientViewModel gedClientViewModel = new GEDClientViewModel();
            this.DataContext = gedClientViewModel;
            this.gedClientViewModel = gedClientViewModel;
            gedClientViewModel.carregarModuloIncluirDocumento();
        }

        public int? incluirDocumento()
        {
            int? idDocumentoAux = gedClientViewModel.incluirDocumento();
            idDocumento = idDocumentoAux;
            return idDocumentoAux;
        }

        private void btGravarDocumento_Click(object sender, RoutedEventArgs e)
        {
            this.incluirDocumento();
        }

        private void btScanner_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.digitalizar();
        }

        private void btBrowse_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.browse();
        }
    }
}
