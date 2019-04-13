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
    /// Interaction logic for PontoMarcacaoPrincipal.xaml
    /// </summary>
    public partial class PontoMarcacaoPrincipal : UserControl
    {
        private ViewPontoMarcacaoViewModel viewModel;
        private PontoMarcacaoViewModel marcacaoViewModel;
        public PontoMarcacaoPrincipal()
        {
            InitializeComponent();
            viewModel = new ViewPontoMarcacaoViewModel();
            marcacaoViewModel = new PontoMarcacaoViewModel();
            this.DataContext = viewModel;
        }

        private void btImportar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents (.txt)|*.txt";
                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    marcacaoViewModel.importarArquivo(dlg.FileName);
                    viewModel.atualizarListaViewPontoMarcacao(0);
                    MessageBox.Show("Arquivo Processado com Sucesso!", "Informação do sistema");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btConfirmar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.salvarAtualizarPontoMarcacao();
                MessageBox.Show("Dados Confirmados com Sucesso!", "Informação do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btProcessar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.ViewPontoMarcacaoSelected == null)
                {
                    MessageBox.Show("Selecione um elemento na grid.", "Alerta do sistema");
                }
                else
                {
                    viewModel.processarFechamento();
                    MessageBox.Show("Dados Confirmados com Sucesso!", "Informação do sistema");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }

        }

    }
}
