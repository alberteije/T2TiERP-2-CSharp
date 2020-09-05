using System.Windows;
using Microsoft.Windows.Controls.Ribbon;
using SIS.View;
using SISClient.ViewModel;

namespace SISClient.View
{

    public partial class SISMenu : RibbonWindow
    {
        public static Window JanelaInformativosGuias;

        ViewModelBase ViewModel = new ViewModelBase();
        public static Window JanelaLogin;


        public SISMenu()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new SISPrincipal());
            DoLogin();
        }

        private void DoLogin()
        {
            Login Janela = new Login();
            Window Window = new Window()
            {
                Title = "Login",
                ShowInTaskbar = false,
                Topmost = false,
                ResizeMode = ResizeMode.NoResize,
                Width = 525,
                Height = 222,
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
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tem Certeza Que Deseja Sair do Sistema?", "Sair do Sistema", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void BotaoCargo_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new CargoPrincipal(), "Cargo");
        }

        private void BotaoSituacaoVendedor_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new SituacaoVendedorPrincipal(), "Situação Vendedor");
        }

        private void BotaoCategoriaProduto_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new CategoriaProdutoPrincipal(), "Categoria Produto");
        }

        private void BotaoTipoPagamento_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new TipoPagamentoPrincipal(), "Tipo Pagamento");
        }

        private void BotaoLocalVenda_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new LocalVendaPrincipal(), "Local Venda");
        }

        private void BotaoFuncionario_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new FuncionarioPrincipal(), "Funcionário");
        }

        private void BotaoProduto_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new ProdutoPrincipal(), "Produto");
        }

        private void BotaoVendedor_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new VendedorPrincipal(), "Vendedor");
        }



    }
}
