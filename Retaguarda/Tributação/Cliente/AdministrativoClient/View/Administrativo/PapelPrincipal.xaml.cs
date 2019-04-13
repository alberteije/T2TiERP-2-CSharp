using System;
using System.Windows;
using System.Windows.Controls;
using AdministrativoClient.ViewModel.Administrativo;
using AdministrativoClient.ServicoAdministrativoReference;

namespace AdministrativoClient.View.Administrativo
{
    /// <summary>
    /// Interaction logic for PapelPrincipal.xaml
    /// </summary>
    public partial class PapelPrincipal : UserControl
    {
        private PapelViewModel viewModel;
        public PapelPrincipal()
        {
            InitializeComponent();
            viewModel = new PapelViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.PapelSelected != null)
                {
                    viewModel.IsEditar = true;
                    if (viewModel.PapelSelected.AcessoCompleto == "N")
                        viewModel.CarregarArquivoFuncoes();
                }
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
                viewModel.PapelSelected = new PapelDTO();
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
                if (viewModel.PapelSelected != null)
                {
                    viewModel.excluirPapel();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaPapel(0);
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
