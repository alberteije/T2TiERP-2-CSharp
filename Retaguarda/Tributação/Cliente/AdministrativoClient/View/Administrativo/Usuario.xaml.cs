using System;
using System.Windows;
using System.Windows.Controls;
using AdministrativoClient.ViewModel.Administrativo;

namespace AdministrativoClient.View.Administrativo
{
    /// <summary>
    /// Interaction logic for Usuario.xaml
    /// </summary>
    public partial class Usuario : UserControl
    {
        public Usuario()
        {
            InitializeComponent();
        }
        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((UsuarioViewModel)this.DataContext).IsEditar= false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((UsuarioViewModel)this.DataContext).salvarAtualizarUsuario();
                MessageBox.Show("Salvo com sucesso!", "Informação do sistema");
                ((UsuarioViewModel)this.DataContext).atualizarListaUsuario(0);
                ((UsuarioViewModel)this.DataContext).IsEditar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }

		private void btPesquisarPapel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((UsuarioViewModel)DataContext).pesquisarPapel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }
		
		private void btPesquisarColaborador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((UsuarioViewModel)DataContext).pesquisarColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta do sistema");
            }
        }


    }
}
