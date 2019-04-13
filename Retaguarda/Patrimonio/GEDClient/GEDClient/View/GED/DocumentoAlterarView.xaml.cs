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
    /// Interaction logic for DocumentoAlterarView.xaml
    /// </summary>
    public partial class DocumentoAlterarView : UserControl
    {
        private GEDClientViewModel gedClientViewModel;
        public DocumentoAlterarView(GEDClientViewModel gedClientViewModel)
        {
            InitializeComponent();
            this.gedClientViewModel = gedClientViewModel;
            DataContext = gedClientViewModel;
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.carregarTabPrincipalDocumento();
        }

        private void btConfirmar_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.alterarDocumento();
            gedClientViewModel.carregarTabPrincipalDocumento();
        }

        private void btBrowse_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.browse();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.visualizarDocumento();
        }

        private void btScanner_Click(object sender, RoutedEventArgs e)
        {
            gedClientViewModel.digitalizar();
        }
    }
}
