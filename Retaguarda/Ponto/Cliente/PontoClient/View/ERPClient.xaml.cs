using System.Windows;
using System.Windows.Controls;
using PontoClient.View.Ponto;
using Microsoft.Windows.Controls.Ribbon;
using PontoClient.ViewModel.Ponto;

namespace PontoClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        public static Window JanelaRegistroPonto;

        PontoViewModel viewModel = new PontoViewModel();
        public static Window JanelaLogin;

        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new PontoPrincipal());
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

        private void BotaoParametros_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PontoParametroPrincipal(), "Parâmetros");
        }

        private void BotaoHorarios_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PontoHorarioPrincipal(), "Horários");
        }

        private void BotaoEscala_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PontoEscalaPrincipal(), "Escala e Turma");
        }

        private void BotaoClassificacao_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PontoClassificacaoJornadaPrincipal(), "Classificação Jornada");
        }

        private void BotaoAbono_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PontoAbonoPrincipal(), "Abono");
        }

        private void BotaoRelogio_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PontoRelogioPrincipal(), "Relógio");
        }

        private void BotaoBanco_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PontoBancoHorasPrincipal(), "Banco de Horas");
        }

        private void BotaoTratamento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PontoMarcacaoPrincipal(), "Tratamento Arquivo AFD");
        }

        private void BotaoGeracao_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PontoGeracaoArquivosPrincipal(), "Geração de Arquivos");
        }

        private void BotaoEspelho_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PontoFechamentoJornadaPrincipal(), "Espelho Ponto Eletrônico");
        }

        private void BotaoMarcacao_Click(object sender, RoutedEventArgs e)
        {
            PontoRegistroPrincipal janela = new PontoRegistroPrincipal();
            Window window = new Window()
            {
                Title = "Registro de Ponto",
                ShowInTaskbar = false,
                Topmost = false,
                ResizeMode = ResizeMode.NoResize,
                Width = 410,
                Height = 220,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            };
            window.Content = janela;
            JanelaRegistroPonto = window;
            window.ShowDialog();
        }

    }
}
