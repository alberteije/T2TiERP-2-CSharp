using System.Windows;
using GEDClient.View.GED;
using Microsoft.Windows.Controls.Ribbon;
using GEDClient.ViewModel.GED;

namespace GEDClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        GEDClientViewModel viewModel = new GEDClientViewModel();
        public static Window JanelaLogin;

        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new GEDPrincipal());
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

        private void BotaoTipoDocumento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new GedTipoDocumentoPrincipal(), "Tipo Documento");
        }

        private void BotaoDocumento_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new GedDocumentoPrincipal(), "Documento");
        }

    }
}
