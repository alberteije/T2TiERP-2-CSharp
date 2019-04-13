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
using System.Diagnostics;

namespace PontoClient.View.Ponto
{
    /// <summary>
    /// Interaction logic for PontoPrincipal.xaml
    /// </summary>
    public partial class PontoRegistroPrincipal : UserControl
    {
        private PontoMarcacaoViewModel viewModelPontoMarcacao;
        private UsuarioViewModel viewModelUsuario;
        public PontoRegistroPrincipal()
        {
            InitializeComponent();
            viewModelPontoMarcacao = new PontoMarcacaoViewModel();
            viewModelUsuario = new UsuarioViewModel();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            ERPClient.JanelaRegistroPonto.Close();
        }

        private void btGerar_Click(object sender, RoutedEventArgs e)
        {
            if (viewModelUsuario.login(textBoxUsuario.Text, textBoxSenha.Text))
            {
                viewModelPontoMarcacao.registrar();
                MessageBox.Show("Registro Efetuado com Sucesso!", "Informação do Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Login e/ou Senha Incorretos", "Erro no Login", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxUsuario.Focus();
            }

        }

        
    }
}
