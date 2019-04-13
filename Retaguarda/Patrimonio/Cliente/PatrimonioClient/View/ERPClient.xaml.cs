using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PatrimonioClient.View.Patrimonio;
using Microsoft.Windows.Controls.Ribbon;
using PatrimonioClient.ViewModel.Patrimonio;

namespace PatrimonioClient.View
{
    /// <summary>
    /// Interaction logic for ERPClient.xaml
    /// </summary>
    public partial class ERPClient : RibbonWindow
    {
        PatrimonioViewModel viewModel = new PatrimonioViewModel();
        public static Window JanelaLogin;

        public ERPClient()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new PatrimonioPrincipal());
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

        private void BotaoTaxaDepreciacao_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PatrimTaxaDepreciacaoPrincipal(), "Taxa de Depreciação");
        }

        private void BotaoIndicesAtualizacao_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PatrimIndiceAtualizacaoPrincipal(), "Índice de Atualização");
        }

        private void BotaoTipoAquisicaoBem_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PatrimTipoAquisicaoBemPrincipal(), "Tipo de Aquisição");
        }

        private void BotaoTipoMovimentacaoBem_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PatrimTipoMovimentacaoPrincipal(), "Tipo de Movimentação");
        }

        private void BotaoEstadoConservacaoBem_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PatrimEstadoConservacaoPrincipal(), "Estado de Conservação");
        }

        private void BotaoGrupo_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PatrimGrupoBemPrincipal(), "Grupo do Bem");
        }

        private void BotaoBem_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PatrimBemPrincipal(), "Bem Patrimonial");
        }

        private void BotaoSeguradora_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new SeguradoraPrincipal(), "Seguradora");
        }

        private void BotaoApolice_Click(object sender, RoutedEventArgs e)
        {
            viewModel.novaPagina(new PatrimApoliceSeguroPrincipal(), "Apólice Seguro");
        }

    }
}
