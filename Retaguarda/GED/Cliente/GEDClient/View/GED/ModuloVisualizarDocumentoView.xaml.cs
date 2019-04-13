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
    /// Interaction logic for ModuloVisualizarDocumentoView.xaml
    /// </summary>
    public partial class ModuloVisualizarDocumentoView : UserControl
    {
        private GEDClientViewModel gedClientViewModel;

        public ModuloVisualizarDocumentoView()
        {
            InitializeComponent();
            GEDClientViewModel gedClientViewModel = new GEDClientViewModel();
            this.DataContext = gedClientViewModel;
            this.gedClientViewModel = gedClientViewModel;
        }

        public void carregarDocumento(int idDocumento)
        {
            gedClientViewModel.carregarModuloVisualizarDocumento(idDocumento);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.visualizarDocumento();
        }
    }
}
