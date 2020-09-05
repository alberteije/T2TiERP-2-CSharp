using System;
using System.Windows;
using System.Windows.Controls;
using SISClient.ViewModel;

namespace SISClient.View
{

    public partial class Login : UserControl
    {
        public static Boolean Logado;
        private UsuarioViewModel ViewModelUsuario;

        public Login()
        {
            InitializeComponent();
            ViewModelUsuario = new UsuarioViewModel();
            Logado = false;
            textBoxLogin.Focus();
        }

        private void btConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModelUsuario.Login(textBoxLogin.Text, textBoxSenha.Password))
            {
                Logado = true;
                SISMenu.JanelaLogin.Close();
            }
            else
            {
                MessageBox.Show("Login e/ou Senha Incorretos", "Erro no Login", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxLogin.Focus();
            }
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            SISMenu.JanelaLogin.Close();
        }

        
    }
}
