using System.Windows;
using System.Windows.Controls;
using AdministrativoClient.View.Administrativo;
using Microsoft.Windows.Controls.Ribbon;
using AdministrativoClient.ViewModel.Administrativo;

namespace AdministrativoClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {

        AdministrativoViewModel viewModel = new AdministrativoViewModel();
        public static Window JanelaLogin;
        public static Window JanelaAtualizaBanco;


        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new AdministrativoPrincipal());
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

        private void BotaoOperacaoFiscal_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new TributOperacaoFiscalPrincipal(), "Operação Fiscal");
        }

        private void BotaoGrupoTributario_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new TributGrupoTributarioPrincipal(), "Grupo Tributário");
        }

        private void BotaoConfiguraTributacao_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new TributConfiguraOfGtPrincipal(), "Configura Tributação");
        }

        private void BotaoIcms_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new TributIcmsCustomCabPrincipal(), "ICMS Customizado");
        }

        private void BotaoIss_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new TributIssPrincipal(), "ISS");
        }

        private void BotaoAtualizaBd_Click(object sender, RoutedEventArgs e)
        {
            AtualizaBanco janela = new AtualizaBanco();
            Window window = new Window()
            {
                Title = "Atualiza Banco de Dados",
                ShowInTaskbar = false,
                Topmost = false,
                ResizeMode = ResizeMode.NoResize,
                Width = 510,
                Height = 268,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            };
            window.Content = janela;
            JanelaAtualizaBanco = window;
            window.ShowDialog();
        }

        private void BotaoUsuario_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new UsuarioPrincipal(), "Usuário");
        }

        private void BotaoAcesso_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PapelPrincipal(), "Controle de Acesso");
        }


    }
}
