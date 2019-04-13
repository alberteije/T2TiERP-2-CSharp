using System.Windows;
using System.Windows.Controls;
using FluxoCaixaClient.View.FluxoCaixa;
using Microsoft.Windows.Controls.Ribbon;
using FluxoCaixaClient.ViewModel.FluxoCaixa;

namespace FluxoCaixaClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        FluxoCaixaViewModel viewModel = new FluxoCaixaViewModel();
        public static Window JanelaLogin;


        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new FluxoCaixaPrincipal());
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

        private void BotaoFluxoCaixa_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new FluxoCaixaView(), "Fluxo Caixa");
        }


    }
}
