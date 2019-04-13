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
using EscritaFiscalClient.View.EscritaFiscal;
using Microsoft.Windows.Controls.Ribbon;
using EscritaFiscalClient.ViewModel.EscritaFiscal;
using CloseableTabItemDemo;

namespace EscritaFiscalClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        EscritaFiscalViewModel viewModel = new EscritaFiscalViewModel();
        public static Window JanelaInformativosGuias;
        public static Window JanelaLogin;

        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new EscritaFiscalPrincipal());
            doLogin();
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tem Certeza Que Deseja Sair do Sistema?", "Sair do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void BotaoRegistroCartorio_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new RegistroCartorioPrincipal(), "Registro Cartório");
        }

        private void BotaoParametros_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FiscalParametroPrincipal(), "Parâmetros");
        }

        private void BotaoTipoNotaFiscal_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new TipoNotaFiscalPrincipal(), "Tipo Nota Fiscal");
        }

        private void BotaoSimplesNacional_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new SimplesNacionalCabecalhoPrincipal(), "Tabela Simples Nacional");
        }

        private void BotaoLivrosTermos_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FiscalLivroPrincipal(), "Livros e Termos");
        }

        private void BotaoEntradas_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO:
            /// Aproveite a janela de entrada de nota do módulo controle de estoque
            /// Faça as adaptações que achar necessárias
        }

        private void BotaoSaidas_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO:
            ///  Analise junto ao contador quais dados são necessários para contabilização
            ///  das saídas e construa a janela de acordo com a necessidade
        }

        private void BotaoApuracao_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FiscalApuracaoIcmsPrincipal(), "Apuração ICMS");
        }

        private void BotaoInformativos_Click(object sender, RoutedEventArgs e)
        {
            InformativosGuiasPrincipal janela = new InformativosGuiasPrincipal();
            Window window = new Window()
            {
                Title = "Informativos e Guias",
                ShowInTaskbar = false,               
                Topmost = false,                      
                ResizeMode = ResizeMode.NoResize,
                Width = 710,
                Height = 260,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            };
            window.Content = janela;
            JanelaInformativosGuias = window;
            window.ShowDialog();
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

    }
}
