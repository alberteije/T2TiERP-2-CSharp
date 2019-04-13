using System;
using System.Windows;
using System.Windows.Controls;
using AdministrativoClient.ViewModel.Administrativo;
using AdministrativoClient.ServicoAdministrativoReference;

namespace AdministrativoClient.View.Administrativo
{
    /// <summary>
    /// Interaction logic for UsuarioPrincipal.xaml
    /// </summary>
    public partial class UsuarioPrincipal : UserControl
    {
        private UsuarioViewModel viewModel;
        public UsuarioPrincipal()
        {
            InitializeComponent();
            viewModel = new UsuarioViewModel();
            this.DataContext = viewModel;
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.UsuarioSelected != null)
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
                viewModel.UsuarioSelected = new UsuarioDTO();
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
                if (viewModel.UsuarioSelected != null)
                {
                    viewModel.excluirUsuario();
                    MessageBox.Show("Exclusão efetuada com sucesso!", "Informação do sistema");

                    viewModel.atualizarListaUsuario(0);
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
