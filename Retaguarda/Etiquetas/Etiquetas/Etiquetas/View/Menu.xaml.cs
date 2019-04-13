using System.Windows;
using Microsoft.Windows.Controls.Ribbon;
using Cadastros.View;
using Cadastros.ViewModel;
using Etiquetas.View;

namespace Cadastros.View
{

    public partial class Menu : RibbonWindow
    {
        ViewModelBase ViewModel = new ViewModelBase();
        public static Window JanelaLogin;
        public static Window JanelaSpedFiscal;
        public static Window JanelaSintegra;
        public static Window JanelaSpedContribuicoes;

        public Menu()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new Principal());
            DoLogin();
        }

        private void DoLogin()
        {
            /*
            Login Janela = new Login();
            Window Window = new Window()
            {
                Title = "Login",
                ShowInTaskbar = false,
                Topmost = false,
                ResizeMode = ResizeMode.NoResize,
                Width = 450,
                Height = 230,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            };
            Window.Content = Janela;
            JanelaLogin = Window;
            Window.ShowDialog();

            if (Login.Logado == false)
            {
                MessageBox.Show("Aplicação será Encerrada.", "Informação do Sistema", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Shutdown();
            }
             */ 
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tem Certeza Que Deseja Sair do Sistema?", "Sair do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void BotaoFormatoPapel_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO
            /// Implemente a janela de cadastro de formatos de papéis
        }

        private void BotaoLayout_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO
            /// Implemente a janela de cadastro de layouts
        }

        private void BotaoTemplate_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new EtiquetaTemplatePrincipal(), "Template");
        }


    }
}
