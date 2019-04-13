using System.Windows;
using Microsoft.Windows.Controls.Ribbon;
using Cadastros.View;
using Cadastros.ViewModel;
using Cadastros.View;

namespace Cadastros.View
{

    public partial class CadastrosMenu : RibbonWindow
    {
        ViewModelBase ViewModel = new ViewModelBase();
        public static Window JanelaLogin;
        public static Window JanelaSpedFiscal;
        public static Window JanelaSintegra;
        public static Window JanelaSpedContribuicoes;

        public CadastrosMenu()
        {
            InitializeComponent();
            dockModulo.Children.Clear();
            dockModulo.Children.Add(new CadastrosPrincipal());
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


        private void BotaoEstadoCivil_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new EstadoCivilPrincipal(), "Estado Civil");
        }

        private void BotaoPessoa_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new PessoaPrincipal(), "Pessoa");
        }

        private void BotaoAtividade_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new AtividadeForCliPrincipal(), "Atividade Cliente/Fornecedor");
        }

        private void BotaoSituacao_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new SituacaoForCliPrincipal(), "Situação Cliente/Fornecedor");
        }

        private void BotaoCliente_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new ClientePrincipal(), "Cliente");
        }

        private void BotaoFornecedor_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new FornecedorPrincipal(), "Fornecedor");
        }

        private void BotaoTransportadora_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new TransportadoraPrincipal(), "Transportadora");
        }

        private void BotaoTipoAdmissao_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new TipoAdmissaoPrincipal(), "Tipo Admissão");
        }

        private void BotaoTipoRelacionamento_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new TipoRelacionamentoPrincipal(), "Tipo Relacionamento");
        }

        private void BotaoSituacaoColaborador_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new SituacaoColaboradorPrincipal(), "Situação Colaborador");
        }

        private void BotaoTipoDesligamento_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new TipoDesligamentoPrincipal(), "Tipo Desligamento");
        }

        private void BotaoTipoColaborador_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new TipoColaboradorPrincipal(), "Tipo Colaborador");
        }

        private void BotaoCargo_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new CargoPrincipal(), "Cargo");
        }

        private void BotaoNivelFormacao_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoColaborador_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new ColaboradorPrincipal(), "Colaborador");
        }

        private void BotaoContador_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new ContadorPrincipal(), "Contador");
        }

        private void BotaoSindicato_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new SindicatoPrincipal(), "Sindicato");
        }

        private void BotaoConvenio_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new ConvenioPrincipal(), "Convênio");
        }

        private void BotaoSetor_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new SetorPrincipal(), "Setor");
        }

        private void BotaoAlmoxarifado_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new AlmoxarifadoPrincipal(), "Almoxarifado");
        }

        private void BotaoOperadoraPlanoSaude_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new OperadoraPlanoSaudePrincipal(), "Operadora Plano Saúde");
        }

        private void BotaoOperadoracartao_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new OperadoraCartaoPrincipal(), "Operadora Cartão");
        }

        private void BotaoPais_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new PaisPrincipal(), "País");
        }

        private void BotaoEstado_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoMunicipio_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoCep_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new CepPrincipal(), "CEP");
        }

        private void BotaoMarca_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new ProdutoMarcaPrincipal(), "Produto Marca");
        }

        private void BotaoNcm_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new NcmPrincipal(), "NCM");
        }

        private void BotaoUnidade_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new UnidadeProdutoPrincipal(), "Produto Unidade");
        }

        private void BotaoGrupo_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new ProdutoGrupoPrincipal(), "Produto Grupo");
        }

        private void BotaoSubGrupo_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new ProdutoSubGrupoPrincipal(), "Produto Subgrupo");
        }

        private void BotaoProduto_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new ProdutoPrincipal(), "Produto");
        }

        private void BotaoBanco_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaPagina(new BancoPrincipal(), "Banco");
        }

        private void BotaoAgencia_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoContaCaixa_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new ContaCaixaPrincipal(), "Conta/Caixa");
        }

        private void BotaoTalonario_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new TalonarioChequePrincipal(), "Talonário");
        }

        private void BotaoCheque_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new ChequePrincipal(), "Cheque");
        }

        private void BotaoTipoItemSped_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoSpedPis439_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoSpedPis4310_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoSpedPis4313_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoSpedPis4314_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoSpedPis4315_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoSpedPis4316_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoCategoriaTrabalhoSefip_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoCodigoMovimentacaoSefip_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new SefipCodigoMovimentacaoPrincipal(), "Sefip Código Movimentação");
        }

        private void BotaoCodigoRecolhimentoSefip_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BotaoTipoCreditoPis_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new TipoCreditoPisPrincipal(), "Tipo Crédito Pis");
        }

        private void BotaoBaseCreditoPis_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new BaseCreditoPisPrincipal(), "Base Crédito Pis");
        }

        private void BotaoCstCofins_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new CstCofinsPrincipal(), "CST Cofins");
        }

        private void BotaoCstIcmsA_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new CstIcmsAPrincipal(), "CST ICMS A");
        }

        private void BotaoCstIcmsB_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new CstIcmsBPrincipal(), "CST ICMS B");
        }

        private void BotaoCstIpi_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new CstIpiPrincipal(), "CST IPI");
        }

        private void BotaoCstPis_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new CstPisPrincipal(), "CST Pis");
        }

        private void BotaoCbo_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new CboPrincipal(), "CBO");
        }

        private void BotaoCfop_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new CfopPrincipal(), "CFOP");
        }

        private void BotaoGps_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new CodigoGpsPrincipal(), "Código GPS");
        }

        private void BotaoSalarioMinimo_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new SalarioMinimoPrincipal(), "Salário Mínimo");
        }

        private void BotaoSituacaoDocumento_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new SituacaoDocumentoPrincipal(), "Situação Documento");
        }

        private void BotaoCsosnA_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new CsosnAPrincipal(), "CSOSN A");
        }

        private void BotaoCsosnB_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new CsosnBPrincipal(), "CSOSN B");
        }

        private void BotaoFeriados_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.NovaPagina(new FeriadosPrincipal(), "Feriados");
        }



    }
}
