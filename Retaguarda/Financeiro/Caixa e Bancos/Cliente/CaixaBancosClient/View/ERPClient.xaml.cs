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
using System.Windows.Shapes;
using CaixaBancosClient.View.CaixaBancos;
using Microsoft.Windows.Controls.Ribbon;
using CaixaBancosClient.ViewModel.CaixaBancos;
using CloseableTabItemDemo;

namespace CaixaBancosClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        CaixaBancosViewModel viewModel = new CaixaBancosViewModel();
        public static Window JanelaLogin;

        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new CaixaBancosPrincipal());
            doLogin();
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tem Certeza Que Deseja Sair do Sistema?", "Sair do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void doLogin() 
        {
            Login janela = new Login();
            Window window = new Window()
            {
                Title = "Login",
                ShowInTaskbar = false,
                Topmost = false,
                ResizeMode = ResizeMode.NoResize,
                Width = 525,
                Height = 222,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            };
            window.Content = janela;
            JanelaLogin = window;
            window.ShowDialog();

            if (Login.logado == false)
            {
                MessageBox.Show("Aplicação será Encerrada.", "Informação do Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Shutdown();
            }
        }

        private void BotaoPlanoNaturezaFinanceira_Click(object sender, RoutedEventArgs e)
        {
            //viewModel.novaPagina(new PlanoNaturezaFinanceiraPrincipal(), "Plano Natureza Financeira");
        }

        private void BotaoNaturezaFinanceira_Click(object sender, RoutedEventArgs e)
        {
            //viewModel.novaPagina(new NaturezaFinanceiraPrincipal(), "Natureza Financeira");
        }

        private void BotaoMovimento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new MovimentoPrincipal(), "Movimento de Caixa/Banco");
        }

    }
}
