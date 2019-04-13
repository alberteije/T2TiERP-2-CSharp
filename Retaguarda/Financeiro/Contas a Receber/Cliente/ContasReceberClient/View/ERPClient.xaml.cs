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
using ContasReceberClient.View.ContasReceber;
using Microsoft.Windows.Controls.Ribbon;
using ContasReceberClient.ViewModel.ContasReceber;
using CloseableTabItemDemo;

namespace ContasReceberClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        ContasReceberViewModel viewModel = new ContasReceberViewModel();
        public static Window JanelaLogin;
        public static Window JanelaEDI;

        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new ContasReceberPrincipal());
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
            viewModel.novaPagina(new PlanoNaturezaFinanceiraPrincipal(), "Plano Natureza Financeira");
        }

        private void BotaoNaturezaFinanceira_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new NaturezaFinanceiraPrincipal(), "Natureza Financeira");
        }

        private void BotaoStatusParcela_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FinStatusParcelaPrincipal(), "Status Parcela");
        }

        private void BotaoTipoRecebimento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FinTipoRecebimentoPrincipal(), "Tipo Recebimento");
        }

        private void BotaoConfiguracaoBoletos_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FinConfiguracaoBoletoPrincipal(), "Configuração Boletos");
        }

        private void BotaoLancamentoReceber_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FinLancamentoReceberPrincipal(), "Lançamentos a Receber");
        }

        private void BotaoRecebimento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ViewFinLancamentoReceberPrincipal(), "Recebimento");
        }

        private void BotaoEdi_Click(object sender, RoutedEventArgs e)
        {
            EdiPrincipal janela = new EdiPrincipal();
            Window window = new Window()
            {
                Title = "EDI - Processa Retorno",
                ShowInTaskbar = false,
                Topmost = false,
                ResizeMode = ResizeMode.NoResize,
                Width = 510,
                Height = 340,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            };
            window.Content = janela;
            JanelaEDI = window;
            window.ShowDialog();
        }


    }
}

/// EXERCICIO
/// Implemente a janela de mesclagem, onde dois lançamentos a receber se tornam um novo
/// 

/// EXERCICIO
/// Implemente a janela de cobrança usando as tabelas fin_cobranca e fin_cobranca_parcela_receber
/// 
