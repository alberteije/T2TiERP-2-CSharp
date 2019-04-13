using System;
using System.Windows;
using System.Windows.Controls;
using GEDClient.ViewModel.GED;

namespace GEDClient.View.GED
{
    /// <summary>
    /// Interaction logic for GedTipoDocumento.xaml
    /// </summary>
    public partial class GedTipoDocumento : UserControl
    {
        public GedTipoDocumento()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((GedTipoDocumentoViewModel)this.DataContext).IsEditar= false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((GedTipoDocumentoViewModel)this.DataContext).salvarAtualizarGedTipoDocumento();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((GedTipoDocumentoViewModel)this.DataContext).atualizarListaGedTipoDocumento(0);
                ((GedTipoDocumentoViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
