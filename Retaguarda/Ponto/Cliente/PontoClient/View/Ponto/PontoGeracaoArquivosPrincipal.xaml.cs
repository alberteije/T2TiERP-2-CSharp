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
using PontoClient.ViewModel.Ponto;
using PontoClient.ServicoPontoReference;

namespace PontoClient.View.Ponto
{
    /// <summary>
    /// Interaction logic for PontoGeracaoArquivosPrincipal.xaml
    /// </summary>
    public partial class PontoGeracaoArquivosPrincipal : UserControl
    {
        private ViewPontoMarcacaoViewModel viewModel;
        public PontoGeracaoArquivosPrincipal()
        {
            InitializeComponent();
            viewModel = new ViewPontoMarcacaoViewModel();
            this.DataContext = viewModel;
        }

        private void btAfdt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ViewPontoMarcacaoViewModel)DataContext).gerarAFDT(datePickerInicial.Text, datePickerFinal.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btAcjef_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((ViewPontoMarcacaoViewModel)DataContext).gerarACJEF(datePickerInicial.Text, datePickerFinal.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
