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
using PatrimonioClient.ViewModel.Patrimonio;
using PatrimonioClient.ServicoPatrimonioReference;

namespace PatrimonioClient.View.Patrimonio
{
    /// <summary>
    /// Interaction logic for PatrimBemPrincipal.xaml
    /// </summary>
    public partial class PatrimBemPrincipal : UserControl
    {
        private PatrimBemViewModel viewModel;
        public PatrimBemPrincipal()
        {
            InitializeComponent();
            viewModel = new PatrimBemViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.PatrimBemSelected != null)
                {
                    this.criarListasBem(viewModel.PatrimBemSelected);
                    viewModel.IsEditar = true;
                }
                else
                    MessageBox.Show("Selecione um elemento na lista.", "Alerta do sistema");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void criarListasBem(PatrimBemDTO bem)
        {
            try
            {
                if(bem.ListaPatrimDepreciacaoBem == null)
                    bem.ListaPatrimDepreciacaoBem = new List<PatrimDepreciacaoBemDTO>();
                if (bem.ListaPatrimDocumentoBem == null)
                    bem.ListaPatrimDocumentoBem = new List<PatrimDocumentoBemDTO>();
                if (bem.ListaPatrimMovimentacaoBem == null)
                    bem.ListaPatrimMovimentacaoBem = new List<PatrimMovimentacaoBemDTO>();
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
                PatrimBemDTO bem = new PatrimBemDTO();
                this.criarListasBem(bem);
                viewModel.PatrimBemSelected = bem;
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
                if (viewModel.PatrimBemSelected != null)
                {
                    viewModel.excluirPatrimBem();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaPatrimBem(0);
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
