using System.Windows;
using System.Windows.Controls;
using Microsoft.Windows.Controls.Ribbon;
using EstoqueClient.View.Estoque;

namespace EstoqueClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        EstoqueViewModel viewModel = new EstoqueViewModel();
        public static Window JanelaLogin;

        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new EstoquePrincipal());
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

        private void BotaoNFe_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new NFeView(), "Entrada de Nota Fiscal");
        }

        private void BotaoContagem_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new EstoqueContagemCabecalhoPrincipal(), "Contagem de Produtos");
        }

        private void BotaoRequisicao_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new RequisicaoInternaCabecalhoPrincipal(), "Requisição Interna");
        }

        private void BotaoReajuste_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new EstoqueReajusteCabecalhoPrincipal(), "Reajuste de Preços");
        }

        private void BotaoFormacao_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("EXERCICIO: Implemente a janela de acordo com o que foi exibido na vídeo aula");

            /// EXERCICIO
            ///  Implemente a formação do preço de compra. Tome a formação do preço de venda
            ///  como base.

        }


        /// EXERCICIO
        /// Avaliação do estoque
        ///  PEPS e Custo Médio Ponderado Permanente.
        ///  Crie duas Views com os dados de entrada das NF-e e traga o custo da mercadoria
        ///  do item de acordo com a estratégia:
        ///  PEPS: Adotando esse critério para valoração dos estoques, a empresa atribuirá às mercadorias estocadas os custos mais recentes.
        ///  Custo Médio Ponderado Permanente: as mercadorias estocadas serão sempre valoradas pela média dos custos de aquisição, atualizados a cada compra efetuada.

    }
}
