using ExportarParaArquivo.Control;
using T2TiCte.Servico;
using NFe.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NFe.View
{
    /// <summary>
    /// Interaction logic for NFeView.xaml
    /// </summary>
    public partial class NFeView : UserControl
    {
        NFeViewModel NfeViewModel = new NFeViewModel();

        public NFeView()
        {
            InitializeComponent();
            DataContext = NfeViewModel;
            NfeViewModel.CarregarTabLista();
        }

        private void carregarViewDados()
        {
            try
            {
                tabDados.Content = new NFeDados();
                tabDados.IsSelected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
