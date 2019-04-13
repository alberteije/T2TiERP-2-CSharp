using System.Windows;
using System.Windows.Controls;
using ContabilidadeClient.View.Contabilidade;
using Microsoft.Windows.Controls.Ribbon;
using ContabilidadeClient.ViewModel.Contabilidade;

namespace ContabilidadeClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        public static Window JanelaDfc;
        public static Window JanelaBalanco;
        public static Window JanelaEmissaoLivros;

        ContabilidadeViewModel viewModel = new ContabilidadeViewModel();
        public static Window JanelaLogin;

        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new ContabilidadePrincipal());
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

        private void BotaoRegistroCartorio_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new RegistroCartorioPrincipal(), "Registro Cartório");
        }

        private void BotaoParametros_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilParametrosPrincipal(), "Parâmetros");
        }

        private void BotaoIndices_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilIndicePrincipal(), "Índices");
        }

        private void BotaoHistoricos_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilHistoricoPrincipal(), "Históricos");
        }

        private void BotaoAidfAimdf_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new AidfAimdfPrincipal(), "AIFD/AIMDF");
        }

        private void BotaoFap_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FapPrincipal(), "FAP");
        }

        private void BotaoPlanoContas_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PlanoContaPrincipal(), "Plano Conta");
        }

        private void BotaoPlanoContasSped_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PlanoContaRefSpedPrincipal(), "Plano Conta Sped");
        }

        private void BotaoConta_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilContaPrincipal(), "Conta Contábil");
        }

        private void BotaoFechamento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilFechamentoPrincipal(), "Fechamento");
        }

        private void BotaoLancamentoPadrao_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilLancamentoPadraoPrincipal(), "Lançamento Padrão");
        }

        private void BotaoLoteLancamento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilLotePrincipal(), "Lançamento Lote");
        }

        private void BotaoLancamentoOrcado_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilLancamentoOrcadoPrincipal(), "Lançamento Orçado");
        }

        private void BotaoLancamentoContabil_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilLancamentoCabecalhoPrincipal(), "Lançamento Contábil");
        }

        private void BotaoDre_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilDreCabecalhoPrincipal(), "DRE");
        }

        private void BotaoDfc_Click(object sender, RoutedEventArgs e)
        {
            ContabilDfcPrincipal janela = new ContabilDfcPrincipal();
            Window window = new Window()
            {
                Title = "DFC - Demonstração do Fluxo de Caixa",
                ShowInTaskbar = false,               
                Topmost = false,                      
                ResizeMode = ResizeMode.NoResize,
                Width = 710,
                Height = 220,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            };
            window.Content = janela;
            JanelaDfc = window;
            window.ShowDialog();
        }

        private void BotaoBalanco_Click(object sender, RoutedEventArgs e)
        {
            ContabilBalancoPatrimonialPrincipal janela = new ContabilBalancoPatrimonialPrincipal();
            Window window = new Window()
            {
                Title = "Balanço Patrimonial",
                ShowInTaskbar = false,               
                Topmost = false,                      
                ResizeMode = ResizeMode.NoResize,
                Width = 710,
                Height = 220,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            };
            window.Content = janela;
            JanelaBalanco = window;
            window.ShowDialog();
        }

        private void BotaoEncerramento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilEncerramentoExeCabPrincipal(), "Encerramento Exercício");
        }

        private void BotaoLivrosTermos_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContabilLivroPrincipal(), "Livros");
        }

        private void BotaoEmissaoLivros_Click(object sender, RoutedEventArgs e)
        {
            ContabilEmissaoLivrosPrincipal janela = new ContabilEmissaoLivrosPrincipal();
            Window window = new Window()
            {
                Title = "Livros Contábeis",
                ShowInTaskbar = false,               
                Topmost = false,                      
                ResizeMode = ResizeMode.NoResize,
                Width = 710,
                Height = 220,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            };
            window.Content = janela;
            JanelaEmissaoLivros = window;
            window.ShowDialog();
        }


    }
}
