using System.Windows;
using ContratosClient.View.Contratos;
using ContratosClient.ViewModel.Contratos;
using Microsoft.Windows.Controls.Ribbon;

namespace ContratosClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        ContratosViewModel viewModel = new ContratosViewModel();
        public static Window JanelaLogin;

        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new ContratosPrincipal());
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

        private void BotaoTipoServico_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContratoTipoServicoPrincipal(), "Tipo Serviço");
        }

        private void BotaoTipoContrato_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new TipoContratoPrincipal(), "Tipo Contrato");
        }

        private void BotaoSolicitacaoServico_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContratoSolicitacaoServicoPrincipal(), "Solicitação do Serviço");
        }

        private void BotaoContrato_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new ContratoPrincipal(), "Contrato");
        }

    }
}
