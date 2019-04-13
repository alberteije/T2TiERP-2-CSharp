using System.Windows;
using Microsoft.Windows.Controls.Ribbon;
using Cadastros.View;
using Cadastros.ViewModel;
using Wms.View;

namespace Cadastros.View
{

    public partial class Menu : RibbonWindow
    {
        ViewModelBase ViewModel = new ViewModelBase();
        public static Window JanelaLogin;
        public static Window JanelaModal;

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

        private void BotaoColeta_Click(object sender, RoutedEventArgs e)
        {
            WmsColetaPrincipal janela = new WmsColetaPrincipal();
            Window window = new Window()
            {
                Title = "Coleta de Dados via Arquivo TXT",
                ShowInTaskbar = false,
                Topmost = false,
                ResizeMode = ResizeMode.NoResize,
                Width = 510,
                Height = 390,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
            };
            window.Content = janela;
            JanelaModal = window;
            window.ShowDialog();
        }

        private void BotaoParametros_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO
            /// Implemente a janela de Parâmetros - cadastro simples
        }

        private void BotaoEnderecos_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new WmsEnderecoPrincipal(), "Cadastro dos Endereços");
        }

        private void BotaoAgendamento_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO
            /// Implemente a janela de Agendamento - cadastro simples
        }

        private void BotaoRecebimento_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO
            /// Implemente a janela de Recebimento - cadastro mestre-detalhe
        }

        private void BotaoArmazenamento_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO
            /// Aproveite a tela do Recebimento para fazer o armazenamento
            /// Pode ser na mesma janela ou em outra. Atenção para:

            ///  Como realizar o cálculo correto de armazenagem nas caixas sem os tamanhos
            ///  dos itens? Onde persistir esse dado?
            ///
            ///  Com base no tamanho do volume recebido, calcule quantos cabem nas
            ///  caixas e realize o armazenamento, fornecendo opção para o usuário
            ///  escolher Rua, Estante e Caixa (Endereço Completo)
        }

        private void BotaoOrdemSeparacao_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO
            /// Implemente a janela de Ordem de Separação - cadastro mestre-detalhe
        }

        private void BotaoExpedicao_Click(object sender, RoutedEventArgs e)
        {
            /// EXERCICIO
            /// Aproveite a tela do Ordem de Separação para fazer a expedição
            /// Pode ser na mesma janela ou em outra. Atenção para:

            ///  Será o momento certo de realizar o "desarmazenamento"?
            ///
            ///  E o estoque? Deve-se dar baixa no estoque nesse momento?
            ///  Imagine um mercado como o "Atacadão" ou "Açaí Atacadista"
            ///  Os itens saem do armazem e vão para a loja, que se encontra no mesmo
            ///  prédio ou até mesmo em outro prédio.
        }



    }
}
