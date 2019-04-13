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
using Microsoft.Windows.Controls.Ribbon;
using ConciliacaoContabilClient.ViewModel.ConciliacaoContabil;
using ConciliacaoContabilClient.View.ConciliacaoContabil;
using System.Diagnostics;

namespace ConciliacaoContabilClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        ConciliacaoContabilViewModel viewModel = new ConciliacaoContabilViewModel();
        public static Window JanelaLogin;

        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new ConciliacaoContabilPrincipal());
            doLogin();
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

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tem Certeza Que Deseja Sair do Sistema?", "Sair do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void BotaoConciliacaoBancaria_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContaCaixaPrincipal(), "Conciliação Bancária");
        }

        private void BotaoConciliacaoCliente_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ClientePrincipal(), "Conciliação Cliente");
        }

        private void BotaoConciliacaoFornecedor_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FornecedorPrincipal(), "Conciliação Fornecedor");
        }

        private void BotaoConciliacaoContas_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilLancamentoCabecalhoPrincipal(), "Conciliação Contas");
        }


    }
}
