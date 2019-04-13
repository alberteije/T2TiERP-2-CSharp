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
using EscritaFiscalClient.ViewModel.EscritaFiscal;
using EscritaFiscalClient.ServicoEscritaFiscalReference;

namespace EscritaFiscalClient.View.EscritaFiscal
{
    /// <summary>
    /// Interaction logic for SimplesNacionalCabecalhoPrincipal.xaml
    /// </summary>
    public partial class SimplesNacionalCabecalhoPrincipal : UserControl
    {
        private SimplesNacionalCabecalhoViewModel viewModel;
        public SimplesNacionalCabecalhoPrincipal()
        {
            InitializeComponent();
            viewModel = new SimplesNacionalCabecalhoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.SimplesNacionalCabecalhoSelected != null)
                    viewModel.IsEditar = true;
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.SimplesNacionalCabecalhoSelected = new SimplesNacionalCabecalhoDTO();
                viewModel.SimplesNacionalCabecalhoSelected.ListaSimplesNacionalDetalhe = new List<SimplesNacionalDetalheDTO>();

                viewModel.IsEditar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.SimplesNacionalCabecalhoSelected != null)
                {
                    viewModel.excluirSimplesNacionalCabecalho();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaSimplesNacionalCabecalho(0);
                }                
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

    }
}
