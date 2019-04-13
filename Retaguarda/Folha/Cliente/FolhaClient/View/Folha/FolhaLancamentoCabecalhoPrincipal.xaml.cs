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
using FolhaClient.ViewModel.Folha;
using FolhaClient.ServicoFolhaReference;

namespace FolhaClient.View.Folha
{
    /// <summary>
    /// Interaction logic for FolhaLancamentoCabecalhoPrincipal.xaml
    /// </summary>
    public partial class FolhaLancamentoCabecalhoPrincipal : UserControl
    {
        private FolhaLancamentoCabecalhoViewModel viewModel;
        public FolhaLancamentoCabecalhoPrincipal()
        {
            InitializeComponent();
            viewModel = new FolhaLancamentoCabecalhoViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FolhaLancamentoCabecalhoSelected != null)
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
                viewModel.FolhaLancamentoCabecalhoSelected = new FolhaLancamentoCabecalhoDTO();
                viewModel.FolhaLancamentoCabecalhoSelected.ListaFolhaLancamentoDetalhe = new List<FolhaLancamentoDetalheDTO>();

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
                if (viewModel.FolhaLancamentoCabecalhoSelected != null)
                {
                    viewModel.excluirFolhaLancamentoCabecalho();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFolhaLancamentoCabecalho(0);
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
