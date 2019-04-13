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
    /// Interaction logic for FiscalLivroPrincipal.xaml
    /// </summary>
    public partial class FiscalLivroPrincipal : UserControl
    {
        private FiscalLivroViewModel viewModel;
        public FiscalLivroPrincipal()
        {
            InitializeComponent();
            viewModel = new FiscalLivroViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FiscalLivroSelected != null)
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
                viewModel.FiscalLivroSelected = new FiscalLivroDTO();
                viewModel.FiscalLivroSelected.ListaFiscalTermo = new List<FiscalTermoDTO>();

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
                if (viewModel.FiscalLivroSelected != null)
                {
                    viewModel.excluirFiscalLivro();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFiscalLivro(0);
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
