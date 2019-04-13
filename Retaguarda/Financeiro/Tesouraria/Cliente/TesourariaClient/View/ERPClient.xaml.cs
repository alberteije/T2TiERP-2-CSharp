using System.Windows;
using System.Windows.Controls;
using TesourariaClient.View.Tesouraria;
using Microsoft.Windows.Controls.Ribbon;
using TesourariaClient.ViewModel.Tesouraria;

namespace TesourariaClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        TesourariaViewModel viewModel = new TesourariaViewModel();
        public static Window JanelaLogin;


        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new TesourariaPrincipal());
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

        private void BotaoResumoTesouraria_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new TesourariaView(), "Resumo Tesouraria");
        }


    }
}

/// EXERCICIO
/// Implemente a janela custódia de cheques utilizando a tabela fin_cheque_recebido