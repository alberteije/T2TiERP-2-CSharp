using System.Windows;
using System.Windows.Controls;
using FolhaClient.View.Folha;
using Microsoft.Windows.Controls.Ribbon;
using FolhaClient.ViewModel.Folha;

namespace FolhaClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        public static Window JanelaInformativosGuias;

        FolhaViewModel viewModel = new FolhaViewModel();
        public static Window JanelaLogin;


        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new FolhaPrincipal());
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
            viewModel.novaPagina(new FolhaParametrosPrincipal(), "Parâmetros");
        }

        private void BotaoGuias_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new GuiasAcumuladasPrincipal(), "Guias Acumuladas");
        }

        private void BotaoPlano_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaPlanoSaudePrincipal(), "Plano Saúde");
        }

        private void BotaoEventos_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaEventoPrincipal(), "Eventos");
        }

        private void BotaoTipoAfastamento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaTipoAfastamentoPrincipal(), "Tipo Afastamento");
        }

        private void BotaoAfastamento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaAfastamentoPrincipal(), "Afastamentos");
        }

        private void BotaoFeriasColetivas_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaFeriasColetivasPrincipal(), "Férias Coletivas");
        }

        private void Botaoperiodo_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FeriasPeriodoAquisitivoPrincipal(), "Períodos Aquisitivos");
        }

        private void BotaoFechamento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaFechamentoPrincipal(), "Fechamento");
        }

        private void BotaoLancamento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaLancamentoCabecalhoPrincipal(), "Lançamentos");
        }

        private void BotaoHistoricoSalario_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaHistoricoSalarialPrincipal(), "Alteração Salarial");
        }

        private void BotaoVale_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaValeTransportePrincipal(), "Vale Transporte");
        }

        private void BotaoPpp_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaPppPrincipal(), "PPP");
        }

        private void BotaoInformativo_Click(object sender, RoutedEventArgs e)
        {
            InformativosGuiasPrincipal janela = new InformativosGuiasPrincipal();
            Window window = new Window()
            {
                Title = "EDI - Folha de Pagamento",
                ShowInTaskbar = false,
                Topmost = false,
                ResizeMode = ResizeMode.NoResize,
                Width = 910,
                Height = 440,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            };
            window.Content = janela;
            JanelaInformativosGuias = window;
            window.ShowDialog();
        }

        private void BotaoRescisao_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaRescisaoPrincipal(), "Rescisão");
        }

        private void BotaoServicos_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaInssServicoPrincipal(), "Serviços");
        }

        private void BotaoRetencoes_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FolhaInssPrincipal(), "Retenções");
        }


    }
}
