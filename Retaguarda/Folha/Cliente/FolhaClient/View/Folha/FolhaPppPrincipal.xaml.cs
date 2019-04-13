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
    /// Interaction logic for FolhaPppPrincipal.xaml
    /// </summary>
    public partial class FolhaPppPrincipal : UserControl
    {
        private FolhaPppViewModel viewModel;
        public FolhaPppPrincipal()
        {
            InitializeComponent();
            viewModel = new FolhaPppViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.FolhaPppSelected != null)
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
                FolhaPppDTO ppp = new FolhaPppDTO();
                this.criarListas(ppp);
                viewModel.FolhaPppSelected = ppp;
                viewModel.IsEditar = true;

                viewModel.FolhaPppSelected = new FolhaPppDTO();
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
                if (viewModel.FolhaPppSelected != null)
                {
                    viewModel.excluirFolhaPpp();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaFolhaPpp(0);
                }                
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void criarListas(FolhaPppDTO ppp)
        {
            try
            {
                if (ppp.ListaFolhaPppCat == null)
                    ppp.ListaFolhaPppCat = new List<FolhaPppCatDTO>();
                if (ppp.ListaFolhaPppAtividade == null)
                    ppp.ListaFolhaPppAtividade = new List<FolhaPppAtividadeDTO>();
                if (ppp.ListaFolhaPppFatorRisco == null)
                    ppp.ListaFolhaPppFatorRisco = new List<FolhaPppFatorRiscoDTO>();
                if (ppp.ListaFolhaPppExameMedico == null)
                    ppp.ListaFolhaPppExameMedico = new List<FolhaPppExameMedicoDTO>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
