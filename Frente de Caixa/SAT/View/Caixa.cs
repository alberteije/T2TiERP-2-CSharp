/********************************************************************************
Title: T2TiNFCe
Description: Tela principal da NFC-e.

The MIT License

Copyright: Copyright (C) 2015 T2Ti.COM

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

The author may be contacted at:
t2ti.com@gmail.com

@author T2Ti.COM
@version 1.0
********************************************************************************/



using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NFCe.DTO;
using NFCe.Controller;
using NFCe.Util;
using System.IO;
using System.Drawing;
using System.Xml;
using NFe.Classes;
using NFe.Classes.Informacoes;
using NFe.Classes.Informacoes.Cobranca;
using NFe.Classes.Informacoes.Destinatario;
using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Informacoes.Pagamento;
using NFe.Classes.Informacoes.Total;
using NFe.Classes.Informacoes.Transporte;
using NFe.Classes.Servicos.Tipos;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using NFe.Utils;
using NFe.Utils.Assinatura;
using NFe.Utils.NFe;
using NFe.AppTeste;
using System.Reflection;
using System.Diagnostics;
using SAT.DTO;
using SAT;
using System.Runtime.InteropServices;
using NFe.Impressao.NFCe.FastReports;


namespace NFCe.View
{
    public partial class Caixa : Form
    {

        #region Variáveis

        private static ConfiguracaoApp _configuracoes;
        private static string _protocolo;
        private const string ArquivoConfiguracao = @"\configuracao.xml";
        private static NFe.Classes.NFe _nfe;


        public static int ItemCupom;
        public static decimal SubTotal, TotalGeral, Desconto, Acrescimo, ValorICMS;
        public static string Filtro;
        public static bool BalancaLePeso;

        public static NfeDetalheDTO VendaDetalhe;
        public static DavCabecalhoDTO DavCabecalho;
        public static NfeConfiguracaoDTO ObjetoNfeConfiguracao;

        public static Label LabelMensagens { get; set; }
        public static Label LabelCaixa { get; set; }
        public static Label LabelOperador { get; set; }
        public static Label LabelCliente { get; set; }
        public static TextBox EditQuantidade { get; set; }
        public static TextBox EditCodigo { get; set; }
        public static TextBox EditUnitario { get; set; }
        public static TextBox EditTotalItem { get; set; }
        public static TextBox EditSubTotal { get; set; }
        public static Label LabelTotalGeral { get; set; }
        public static Label LabelDescricaoProduto { get; set; }
        public static Label LabelDescontoAcrescimo { get; set; }
        public static Label EdtNVenda { get; set; }
        public static Label EdtNumeroNota { get; set; }
        public static PictureBox ImageProduto { get; set; }
        public static ListBox Bobina { get; set; }

        #endregion Variáveis

        #region Infra

        public Caixa()
        {
            InitializeComponent();
            //
            LabelCaixa = this.labelCaixa;
            LabelOperador = this.labelOperador;
            LabelCliente = this.labelCliente;
            LabelMensagens = this.labelMensagens;
            EditQuantidade = this.editQuantidade;
            EditCodigo = this.editCodigo;
            EditUnitario = this.editUnitario;
            EditTotalItem = this.editTotalItem;
            EditSubTotal = this.editSubTotal;
            LabelTotalGeral = this.labelTotalGeral;
            LabelDescricaoProduto = this.labelDescricaoProduto;
            LabelDescontoAcrescimo = this.labelDescontoAcrescimo;
            EdtNVenda = this.edtNVenda;
            EdtNumeroNota = this.edtNumeroNota;
            ImageProduto = this.imageProduto;
            Bobina = this.bobina;
            //
            _configuracoes = new ConfiguracaoApp();
            //
            FormCreate();
        }

        public void FormCreate()
        {
            DesabilitaControlesVenda();

            Sessao.Instance.PopulaObjetosPrincipais();
            Sessao.Instance.MenuAberto = false;
            Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scFechado;

            ConfiguraConstantes();
            ConfiguraLayout();
            ConfiguraResolucao();

            ExecutaOutrosProcedimentosDeAbertura();

            ObjetoNfeConfiguracao = NfeConfiguracaoController.ConsultaNfeConfiguracao("ID=1");
            ConfiguraNfe();
            ConfiguraSAT();

            BalancaLePeso = false;
        }

        public void FormCloseQuery()
        {

            if ((Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scAberto) || (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scFechado))
            {
                if (MessageBox.Show("Tem Certeza Que Deseja Sair do Sistema?", "Sair do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Existe uma venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void ExecutaOutrosProcedimentosDeAbertura()
        {
            TelaPadrao();
            HabilitaControlesVenda();

            if (Sessao.Instance.Configuracao.NfceConfiguracaoBalanca.Modelo != null)
            {
                try
                {
                    ConectaComBalanca();
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                    MessageBox.Show("Balança não conectada ou desligada!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void ConfiguraLayout()
        {
            panelTitulo.Text = Sessao.Instance.Configuracao.TituloTelaCaixa;

            if (File.Exists(Sessao.Instance.Configuracao.CaminhoImagensLayout + Sessao.Instance.Configuracao.NfceResolucao.ImagemTela))
            {
                Image ImagemFundo = Image.FromFile(Sessao.Instance.Configuracao.CaminhoImagensLayout + Sessao.Instance.Configuracao.NfceResolucao.ImagemTela);
                this.BackgroundImage = ImagemFundo;
            }
        }

        public void ConfiguraNfe()
        {
            // Exercício: carregue as configurações a partir do banco de dados
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                _configuracoes = !File.Exists(path + ArquivoConfiguracao) ? new ConfiguracaoApp() : FuncoesXml.ArquivoXmlParaClasse<ConfiguracaoApp>(path + ArquivoConfiguracao);
                if (_configuracoes.CfgServico.TimeOut == 0)
                    _configuracoes.CfgServico.TimeOut = 100;//mínimo
            }
            catch (Exception ex)
            {
                if (!String.IsNullOrEmpty(ex.Message))
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ConfiguraSAT()
        {
            // Exercício: Crie uma tabela no banco de dados para armazenar as configurações do SAT
            SATConfiguracaoDTO ConfiguraSAT = new SATConfiguracaoDTO();

            ConfiguraSAT.Modelo = "cdecl";
            ConfiguraSAT.ArqLOG = "ACBrSAT.log";
            ConfiguraSAT.NomeDLL = "C:\\SAT\\SAT.DLL";
            ConfiguraSAT.ide_numeroCaixa = 1;
            ConfiguraSAT.ide_tpAmb = 0;
            ConfiguraSAT.ide_CNPJ = "11111111111111";
            ConfiguraSAT.emit_CNPJ = "11111111111111";
            ConfiguraSAT.emit_IE = "111.111.111.111";
            ConfiguraSAT.emit_IM = "123123";
            ConfiguraSAT.emit_cRegTrib = 0;

            ConfiguraSAT.SalvarCFe = true;
            ConfiguraSAT.SalvarCFeCanc = true;
            ConfiguraSAT.SalvarEnvio = true;
            ConfiguraSAT.ExtratoResumido = false;
        }

        public void ConfiguraConstantes()
        {
            Constantes.DECIMAIS_QUANTIDADE = Sessao.Instance.Configuracao.DecimaisQuantidade.Value;
            Constantes.DECIMAIS_VALOR = Sessao.Instance.Configuracao.DecimaisValor.Value;
        }

        public void ConfiguraResolucao()
        {
            IList<NfcePosicaoComponentesDTO> ListaPosicoes = Sessao.Instance.Configuracao.NfceResolucao.ListaNfcePosicaoComponentes;

            string NomeComponente;
            NfcePosicaoComponentesDTO PosicaoComponente;

            foreach (Control c in this.Controls)
            {
                NomeComponente = c.Name;
                for (int i = 0; i <= ListaPosicoes.Count - 1; i++)
                {
                    PosicaoComponente = ListaPosicoes[i];
                    if (PosicaoComponente.Nome == NomeComponente)
                    {
                        if (c is TextBox)
                            (c as TextBox).SetBounds(PosicaoComponente.Esquerda.Value, PosicaoComponente.Topo.Value, PosicaoComponente.Largura.Value, PosicaoComponente.Altura.Value);
                        else if (c is Label)
                            (c as Label).SetBounds(PosicaoComponente.Esquerda.Value, PosicaoComponente.Topo.Value, PosicaoComponente.Largura.Value, PosicaoComponente.Altura.Value);
                    }
                }
            }

        }

        public static void TelaPadrao()
        {
            Sessao.Instance.VendaAtual = null;

            if (Sessao.Instance.Movimento == null)
            {
                LabelMensagens.Text = "CAIXA FECHADO";
                IniciaMovimento(); //  se o caixa estiver fechado abre o iniciaMovimento
            }
            else if (Sessao.Instance.Movimento.StatusMovimento == "T")
                LabelMensagens.Text = "SAIDA TEMPORÁRIA";
            else
                LabelMensagens.Text = "CAIXA ABERTO";

            if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento)
                LabelMensagens.Text = "Venda em andamento...";

            if (Sessao.Instance.Movimento != null)
            {
                LabelCaixa.Text = "Terminal: " + Sessao.Instance.Movimento.NfceCaixa.Nome;
                LabelOperador.Text = "Operador: " + Sessao.Instance.Movimento.NfceOperador.Login;
            }

            EditQuantidade.Text = "1";
            EditCodigo.Text = "";
            EditUnitario.Text = "0,00";
            EditTotalItem.Text = "0,00";
            EditSubTotal.Text = "0,00";
            LabelTotalGeral.Text = "0,00";
            LabelDescricaoProduto.Text = "";
            LabelDescontoAcrescimo.Text = "";
            LabelCliente.Text = "";
            EdtNVenda.Text = "";
            EdtNumeroNota.Text = "";

            SubTotal = 0;
            TotalGeral = 0;
            ValorICMS = 0;
            Desconto = 0;
            Acrescimo = 0;

            Bobina.Items.Clear();

            if (Sessao.Instance.Configuracao.MarketingAtivo == "S")
            {
                //Exercício:  Implemente o Timer do Marketing
                //TimerMarketing.Enabled = true;
            }
            else
            {
                if (File.Exists(Sessao.Instance.Configuracao.CaminhoImagensProdutos + "padrao.png"))
                    ImageProduto.ImageLocation = Sessao.Instance.Configuracao.CaminhoImagensProdutos + "padrao.png";
                else
                    ImageProduto.ImageLocation = Application.StartupPath + "\\Imagens\\imgProdutos\\padrao.png";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (Sessao.Instance.Movimento != null)
            {
                MovimentoAberto FMovimentoAberto = new MovimentoAberto();
                FMovimentoAberto.ShowDialog();
            }
        }

        private void FCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            //  F1 - Identifica Cliente
            if (e.KeyCode == Keys.F1)
                IdentificaCliente();

            //  F2 - Menu Principal
            if (e.KeyCode == Keys.F2)
                AcionaMenuPrincipal();

            //  F3 - Menu Operacoes
            if (e.KeyCode == Keys.F3)
                AcionaMenuOperacoes();

            //  F4 - Menu Fiscal
            if (e.KeyCode == Keys.F4)
                ConsultaStatusOperacional();

            //  F5 - Entrada de Dados de NF
            if (e.KeyCode == Keys.F5)
                RecuperarVenda();

            //  F6 - Localiza Produto
            if (e.KeyCode == Keys.F6)
                LocalizaProduto();

            //  F7 - Encerra Venda
            if (e.KeyCode == Keys.F7)
                IniciaEncerramentoVenda();

            //  F8 - Cancela Item
            if (e.KeyCode == Keys.F8)
                CancelaItem();

            //  F9 - Cancela Cupom
            if (e.KeyCode == Keys.F9)
                CancelaVenda();

            //  F10 - Concede Desconto
            if (e.KeyCode == Keys.F10)
                DescontoOuAcrescimo();

            //  F11 - Identifica Vendedor
            if (e.KeyCode == Keys.F11)
                IdentificaVendedor();

            //  F12 - Sai do Caixa
            if (e.KeyCode == Keys.F12)
                FormCloseQuery();

            if (e.KeyCode == Keys.B && e.Modifiers == Keys.Shift)
            {
                if (Sessao.Instance.Configuracao.NfceConfiguracaoBalanca.Modelo > 0)
                {
                    try
                    {
                        BalancaLePeso = true;
                        // Exercício: Implementar controle com balanças
                        // ACBrBAL.LePeso(Sessao.Instance.Configuracao.NfceConfiguracaoBalanca.Timeout.Value);
                        editCodigo.Text = "";
                        editCodigo.Focus();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Balança não conectada ou desligada!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public void AcionaMenuPrincipal()
        {
            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scVendaEmAndamento)
            {
                if (!Sessao.Instance.MenuAberto)
                {
                    Sessao.Instance.MenuAberto = true;
                    MenuPrincipal FMenuPrincipal = new MenuPrincipal();
                    FMenuPrincipal.SetBounds(this.Left + 10, this.Top + 82, 213, 200);
                    FMenuPrincipal.ShowDialog();
                }
            }
            else
                MessageBox.Show("Existe uma venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AcionaMenuOperacoes()
        {
            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scVendaEmAndamento)
            {
                if (!Sessao.Instance.MenuAberto)
                {
                    Sessao.Instance.MenuAberto = true;
                    MenuOperacoes FMenuOperacoes = new MenuOperacoes();
                    FMenuOperacoes.SetBounds(this.Left + 10, this.Top + 82, 213, 200);
                    FMenuOperacoes.ShowDialog();
                }
            }
            else
                MessageBox.Show("Existe uma venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Infra

        #region Procedimentos referentes ao Menu Principal e seus SubMenus

        public static void IniciaMovimento()
        {
            try
            {
                if (Sessao.Instance.Movimento == null)
                {
                    IniciaMovimento FIniciaMovimento = new IniciaMovimento();
                    FIniciaMovimento.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ja existe um movimento aberto.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static void EncerraMovimento()
        {
            try
            {
                if (Sessao.Instance.Movimento == null)
                    MessageBox.Show("Não existe um movimento aberto.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    EncerraMovimento FEncerraMovimento = new EncerraMovimento();
                    FEncerraMovimento.ShowDialog();
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static void Suprimento()
        {
            decimal ValorSuprimento;
            if (Sessao.Instance.Movimento == null)
                MessageBox.Show("Não existe um movimento aberto.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ValorReal FValorReal = new ValorReal();
                FValorReal.Text = "Suprimento";
                ValorReal.LabelEntrada.Text = "Informe o valor do suprimento:";
                try
                {
                    if (FValorReal.ShowDialog() == DialogResult.OK)
                    {
                        if (decimal.TryParse(ValorReal.EditEntrada.Text, out ValorSuprimento))
                        {
                            NfceSuprimentoDTO Suprimento = new NfceSuprimentoDTO();
                            Suprimento.IdNfceMovimento = Sessao.Instance.Movimento.Id;
                            Suprimento.DataSuprimento = DateTime.Now;
                            Suprimento.Observacao = ValorReal.MemoObservacao.Text;
                            Suprimento.Valor = ValorSuprimento;
                            NfceSuprimentoController.GravaNfceSuprimento(Suprimento);
                            Sessao.Instance.Movimento.TotalSuprimento = Sessao.Instance.Movimento.TotalSuprimento.Value + ValorSuprimento;
                            NfceMovimentoController.GravaNfceMovimento(Sessao.Instance.Movimento);
                        }
                        else
                        {
                            MessageBox.Show("Valor inválido.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }
            }
        }

        public static void Sangria()
        {
            decimal ValorSangria;
            if (Sessao.Instance.Movimento == null)
                MessageBox.Show("Não existe um movimento aberto.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ValorReal FValorReal = new ValorReal();
                FValorReal.Text = "Sangria";
                ValorReal.LabelEntrada.Text = "Informe o valor do Sangria:";
                try
                {
                    if (FValorReal.ShowDialog() == DialogResult.OK)
                    {
                        if (decimal.TryParse(ValorReal.EditEntrada.Text, out ValorSangria))
                        {
                            NfceSangriaDTO Sangria = new NfceSangriaDTO();
                            Sangria.IdNfceMovimento = Sessao.Instance.Movimento.Id;
                            Sangria.DataSangria = DateTime.Now;
                            Sangria.Observacao = ValorReal.MemoObservacao.Text;
                            Sangria.Valor = ValorSangria;
                            NfceSangriaController.GravaNfceSangria(Sangria);
                            Sessao.Instance.Movimento.TotalSangria = Sessao.Instance.Movimento.TotalSangria.Value + ValorSangria;
                            NfceMovimentoController.GravaNfceMovimento(Sessao.Instance.Movimento);
                        }
                        else
                        {
                            MessageBox.Show("Valor inválido.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }
            }
        }

        private void DescontoOuAcrescimo()
        {
            // Exercício: observe se existe rejeição caso seja aplicado desconto e corrija.

            try
            {

                //  0-Desconto em Dinheiro
                //  1-Desconto Percentual
                //  2-Acrescimo em Dinheiro
                //  3-Acrescimo Percentual
                //  5-Cancela o Desconto ou Acrescimo

                int Operacao;
                decimal Valor;

                if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento)
                {
                    LoginGerenteSupervisor FLoginGerenteSupervisor = new LoginGerenteSupervisor();

                    if (FLoginGerenteSupervisor.ShowDialog() == DialogResult.OK)
                    {
                        if (LoginGerenteSupervisor.LoginOK)
                        {
                            DescontoAcrescimo FDescontoAcrescimo = new DescontoAcrescimo();
                            FDescontoAcrescimo.Text = "Desconto ou Acrescimo";

                            if (FDescontoAcrescimo.ShowDialog() == DialogResult.OK)
                            {
                                Operacao = FDescontoAcrescimo.ComboOperacao.SelectedIndex;
                                //  cancela desconto ou acrescimo
                                if (Operacao == 5)
                                {
                                    Acrescimo = 0;
                                    Desconto = 0;
                                    AtualizaTotais();
                                    return;
                                } //  if Operacao = 5 then

                                if (decimal.TryParse(FDescontoAcrescimo.EditEntrada.Text, out Valor))
                                {
                                    //  desconto em valor
                                    if (Operacao == 0)
                                    {
                                        if (Valor >= Sessao.Instance.VendaAtual.ValorTotalProdutos.Value)
                                            MessageBox.Show("Desconto não pode ser superior ou igual ao valor da venda.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                        {
                                            if (Valor <= 0)
                                                MessageBox.Show("Valor zerado ou negativo. Operacao não realizada.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            else
                                            {
                                                Desconto = Desconto + Valor;
                                                AtualizaTotais();
                                            }
                                        }
                                    } //  if Operacao = 0 then

                                    //  desconto em taxa
                                    if (Operacao == 1)
                                    {
                                        if (Valor > Convert.ToDecimal(99.99))
                                            MessageBox.Show("Desconto não pode ser superior a 100%.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                        {
                                            if (Valor <= 0)
                                                MessageBox.Show("Valor zerado ou negativo. Operacao não realizada.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            else
                                            {
                                                Desconto = Desconto + Biblioteca.TruncaValor(SubTotal * (Valor / 100), Constantes.DECIMAIS_VALOR);
                                                AtualizaTotais();
                                            }
                                        }
                                    } //  if Operacao = 1 then

                                    //  acrescimo em valor
                                    if (Operacao == 2)
                                    {
                                        if (Valor <= 0)
                                            MessageBox.Show("Valor zerado ou negativo. Operacao não realizada.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else if (Valor >= Sessao.Instance.VendaAtual.ValorTotalProdutos)
                                            MessageBox.Show("Valor do acrescimo não pode ser igual ou superior ao valor da venda!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                        {
                                            Acrescimo = Acrescimo + Valor;
                                            AtualizaTotais();
                                        }
                                    } //  if Operacao = 2 then

                                    //  acrescimo em taxa
                                    if (Operacao == 3)
                                    {
                                        if (Valor <= 0)
                                            MessageBox.Show("Valor zerado ou negativo. Operacao não realizada.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else if (Valor > Convert.ToDecimal(99.99))
                                            MessageBox.Show("Acrescimo não pode ser superior a 100%!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                        {
                                            Acrescimo = Acrescimo + Biblioteca.TruncaValor(SubTotal * (Valor / 100), Constantes.DECIMAIS_VALOR);
                                            AtualizaTotais();
                                        }
                                    } //  if Operacao = 3 then

                                }
                                else
                                {
                                    MessageBox.Show("Valor inválido.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                            MessageBox.Show("Login - dados incorretos.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Não existe venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }
        
        #endregion Procedimentos referentes ao Menu Principal e seus SubMenus

        #region Procedimentos referentes ao Menu Operacoes e seus SubMenus

        #endregion Procedimentos referentes ao Menu Operacoes e seus SubMenus

        #region Procedimentos para controle da venda

        private static void InstanciaVendaAtual()
        {
            if (Sessao.Instance.VendaAtual == null)
            {
                Sessao.Instance.VendaAtual = new NfeCabecalhoDTO();
                Sessao.Instance.VendaAtual.NfeDestinatario = new NfeDestinatarioDTO();
            }

            //Pega um número
            Filtro = "1=1";
            NfeNumeroDTO NfeNumero = NfeNumeroController.ConsultaNfeNumero(Filtro);

            //Gera a chave de acesso
            Sessao.Instance.VendaAtual.ChaveAcesso = Sessao.Instance.Configuracao.Empresa.CodigoIbgeUf +
                                              DateTime.Now.ToString("yy") +
                                              DateTime.Now.ToString("MM") +
                                              Sessao.Instance.Configuracao.Empresa.Cnpj +
                                              "65" +
                                              NfeNumero.Serie +
                                              NfeNumero.Numero.Value.ToString("000000000") +
                                              "1" +
                                              NfeNumero.Numero.Value.ToString("00000000");
            Sessao.Instance.VendaAtual.DigitoChaveAcesso = Biblioteca.Modulo11(Sessao.Instance.VendaAtual.ChaveAcesso);

            Sessao.Instance.VendaAtual.UfEmitente = Sessao.Instance.Configuracao.Empresa.CodigoIbgeUf;
            Sessao.Instance.VendaAtual.CodigoNumerico = NfeNumero.Numero.Value.ToString("00000000");
            Sessao.Instance.VendaAtual.NaturezaOperacao = "VENDA";
            Sessao.Instance.VendaAtual.CodigoModelo = "65";
            Sessao.Instance.VendaAtual.Serie = NfeNumero.Serie;
            Sessao.Instance.VendaAtual.Numero = NfeNumero.Numero.Value.ToString("000000000");
            Sessao.Instance.VendaAtual.DataHoraEmissao = DateTime.Now;
            Sessao.Instance.VendaAtual.DataHoraEntradaSaida = DateTime.Now;
            Sessao.Instance.VendaAtual.TipoOperacao = 1;
            Sessao.Instance.VendaAtual.CodigoMunicipio = Sessao.Instance.Configuracao.Empresa.CodigoIbgeCidade;
            Sessao.Instance.VendaAtual.FormatoImpressaoDanfe = 4;
            Sessao.Instance.VendaAtual.TipoEmissao = 1;
            Sessao.Instance.VendaAtual.IdEmpresa = Sessao.Instance.Configuracao.Empresa.Id;
            Sessao.Instance.VendaAtual.Ambiente = ObjetoNfeConfiguracao.WebserviceAmbiente;
            Sessao.Instance.VendaAtual.FinalidadeEmissao = 1;
            Sessao.Instance.VendaAtual.ProcessoEmissao = ObjetoNfeConfiguracao.ProcessoEmissao;
            Sessao.Instance.VendaAtual.VersaoProcessoEmissao = ObjetoNfeConfiguracao.VersaoProcessoEmissao;
            Sessao.Instance.VendaAtual.ConsumidorPresenca = 1;
        }

        private void LocalizaProduto()
        {
            ImportaProduto FImportaProduto = new ImportaProduto();
            FImportaProduto.ShowDialog();
            if((Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento) || (editCodigo.Text.Trim() != ""))
            {
                editCodigo.Focus();
                IniciaVendaDeItens();
            }
        }

        private static void IdentificaCliente()
        {
            InstanciaVendaAtual();
            IdentificaCliente FIdentificaCliente = new IdentificaCliente();
            FIdentificaCliente.ShowDialog();
            if (Sessao.Instance.VendaAtual.NfeDestinatario.CpfCnpj.Trim() != "")
            {
                if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scAberto)
                {
                    IniciaVenda();
                }
                LabelCliente.Text = "Cliente: " + Sessao.Instance.VendaAtual.NfeDestinatario.Nome + " - " + Sessao.Instance.VendaAtual.NfeDestinatario.CpfCnpj;
            }
        }

        public void IdentificaVendedor()
        {
            if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento)
            {
                ImportaNumero FImportaNumero = new ImportaNumero();
                FImportaNumero.Text = "Identifica Vendedor";
                ImportaNumero.LabelEntrada.Text = "Informe o codigo do vendedor";
                try
                {
                    if (FImportaNumero.ShowDialog() == DialogResult.OK)
                    {
                        Filtro = "Id = " + ImportaNumero.EditEntrada.Text;
                        VendedorDTO Vendedor = VendedorController.ConsultaVendedor(Filtro);
                        if (Vendedor.Id != 0)
                        {
                            Sessao.Instance.VendaAtual.IdVendedor = Vendedor.Id;
                        }
                        else
                            MessageBox.Show("Vendedor: codigo invalido ou inexistente.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }
            }
            else
                MessageBox.Show("Não existe venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void IniciaVenda()
        {
            Bobina.Items.Clear();

            if (Sessao.Instance.Movimento == null)
                MessageBox.Show("Não existe um movimento aberto.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                //  instancia venda
                InstanciaVendaAtual();

                ImprimeCabecalhoBobina();
                ParametrosIniciaisVenda();
                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scVendaEmAndamento;
                LabelMensagens.Text = "Venda em andamento...";

                Sessao.Instance.VendaAtual.IdNfceMovimento = Sessao.Instance.Movimento.Id;

                Sessao.Instance.VendaAtual = VendaController.GravaNfceVendaCabecalho(Sessao.Instance.VendaAtual);
                EditCodigo.Focus();
                EditCodigo.SelectAll();

                EdtNVenda.Text = "Venda nº " + Convert.ToString(Sessao.Instance.VendaAtual.Id);
                EdtNumeroNota.Text = "Cupom nº " + Convert.ToString(Sessao.Instance.VendaAtual.Numero);
            }
        }

        public static void ParametrosIniciaisVenda()
        {
            if (File.Exists(Sessao.Instance.Configuracao.CaminhoImagensProdutos + "padrao.png"))
                ImageProduto.ImageLocation = Sessao.Instance.Configuracao.CaminhoImagensProdutos + "padrao.png";
            else
                ImageProduto.ImageLocation = Application.StartupPath + "\\Imagens\\imgProdutos\\padrao.png";

            ItemCupom = 0;
            SubTotal = 0;
            TotalGeral = 0;
            ValorICMS = 0;
        }

        public static void ImprimeCabecalhoBobina()
        {
            try
            {
                Bobina.Items.Add(new string('-', 48));
                Bobina.Items.Add("               **     CUPOM     **               ");
                Bobina.Items.Add(new string('-', 48));
                Bobina.Items.Add("ITEM Codigo         Descricao                   ");
                Bobina.Items.Add("QTD.     UN      VL.UNIT.(R$)       VL.ITEM(R$)");
                Bobina.Items.Add(new string('-', 48));
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public void IniciaVendaDeItens()
        {
            decimal Unitario, Quantidade, Total;
            try
            {
                if (Sessao.Instance.Movimento == null)
                {
                    LabelMensagens.Text = "CAIXA FECHADO";
                    IniciaMovimento(); //  se o caixa estiver fechado abre o iniciaMovimento
                    return;
                }

                if (!Sessao.Instance.MenuAberto)
                {
                    if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scAberto)
                    {
                        IniciaVenda();
                    }
                    if (EditCodigo.Text.Trim() != "")
                    {
                        VendaDetalhe = new NfeDetalheDTO();
                        VendaDetalhe.NfeDetalheImpostoIcms = new NfeDetalheImpostoIcmsDTO();
                        DesmembraCodigoDigitado(EditCodigo.Text.Trim());
                        Application.DoEvents();

                        if (VendaDetalhe.Produto != null)
                        {
                            if (VendaDetalhe.Produto.ValorVenda.Value <= 0)
                            {
                                MessageBox.Show("Produto não pode ser vendido com valor Zerado ou negativo!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EditCodigo.Focus();
                                EditCodigo.SelectAll();
                                return;
                            }

                            LabelMensagens.Text = "Venda em andamento...";

                            decimal Qtde = Convert.ToDecimal(EditQuantidade.Text);
                            if ((VendaDetalhe.Produto.UnidadeProduto.PodeFracionar == "N") && (Qtde - Decimal.Truncate(Qtde) > 0))
                            {
                                MessageBox.Show("Produto não pode ser vendido com quantidade fracionada.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EditUnitario.Text = "0";
                                EditTotalItem.Text = "0";
                                EditQuantidade.Text = "1";
                                LabelDescricaoProduto.Text = "";
                                EditCodigo.Text = "";
                                EditCodigo.Focus();
                            }
                            else
                            {
                                EditUnitario.Text = Biblioteca.FormataFloat("V", VendaDetalhe.Produto.ValorVenda);
                                LabelDescricaoProduto.Text = VendaDetalhe.Produto.DescricaoPdv;
                                //  carrega imagem do produto
                                if (File.Exists(Sessao.Instance.Configuracao.CaminhoImagensProdutos + "padrao.png"))
                                    ImageProduto.ImageLocation = Sessao.Instance.Configuracao.CaminhoImagensProdutos + "padrao.png";
                                else
                                    ImageProduto.ImageLocation = Application.StartupPath + "\\Imagens\\imgProdutos\\padrao.png";
                                if (File.Exists(Sessao.Instance.Configuracao.CaminhoImagensProdutos + VendaDetalhe.Produto.Gtin + ".jpg"))
                                    ImageProduto.ImageLocation = Sessao.Instance.Configuracao.CaminhoImagensProdutos + VendaDetalhe.Produto.Gtin + ".jpg";

                                Unitario = Convert.ToDecimal(EditUnitario.Text);
                                Quantidade = Convert.ToDecimal(EditQuantidade.Text);

                                Total = Biblioteca.TruncaValor(Unitario * Quantidade, Constantes.DECIMAIS_VALOR);
                                EditTotalItem.Text = Total.ToString();

                                VendeItem();

                                SubTotal = SubTotal + VendaDetalhe.ValorTotal.Value;
                                TotalGeral = TotalGeral + VendaDetalhe.ValorTotal.Value;
                                ValorICMS = ValorICMS + VendaDetalhe.NfeDetalheImpostoIcms.ValorIcms.Value;
                                AtualizaTotais();
                                EditCodigo.Clear();
                                EditCodigo.Focus();
                                EditQuantidade.Text = "1";
                                Application.DoEvents();
                            }
                        }
                        else
                        {
                            MensagemDeProdutoNaoEncontrado();
                        }
                    }
                }

            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public void ConsultaProduto(string pCodigo, int pTipo)
        {
            VendaDetalhe.Produto = ProdutoController.ConsultaPorTipo(pCodigo, pTipo);
        }

        public void MensagemDeProdutoNaoEncontrado()
        {
            MessageBox.Show("Codigo não encontrado.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            EditUnitario.Text = "0";
            EditTotalItem.Text = "0";
            EditQuantidade.Text = "1";
            LabelDescricaoProduto.Text = "";
            EditCodigo.Focus();
            EditCodigo.SelectAll();
        }

        public void DesmembraCodigoDigitado(string CodigoDeBarraOuDescricaoOuIdProduto)
        {
            string IdentificadorBalanca, vCodDescrId;
            int LengthCodigo;
            Int64 ValorInformado;

            IdentificadorBalanca = Sessao.Instance.Configuracao.NfceConfiguracaoBalanca.Identificador;
            vCodDescrId = CodigoDeBarraOuDescricaoOuIdProduto;
            LengthCodigo = CodigoDeBarraOuDescricaoOuIdProduto.Length;

            if (Int64.TryParse(CodigoDeBarraOuDescricaoOuIdProduto, out ValorInformado))
            {
                try
                {
                    if ((LengthCodigo == 13) || (LengthCodigo == 14))
                    {
                        ConsultaProduto(vCodDescrId, 2);
                        if (VendaDetalhe.Produto.Id != 0)
                            return;
                    }
                    if ((LengthCodigo <= 4) && (BalancaLePeso == true))
                    {
                        ConsultaProduto(vCodDescrId, 1);
                        if (VendaDetalhe.Produto.Id != 0)
                            return;
                    }
                    else
                    {
                        ConsultaProduto(vCodDescrId, 4);
                        if (VendaDetalhe.Produto.Id != 0)
                            return;
                    }
                }
                finally
                {
                    BalancaLePeso = false;
                }

            }
            else
            {
                ImportaProduto FImportaProduto = new ImportaProduto();
                FImportaProduto.EditLocaliza.Text = vCodDescrId;
                FImportaProduto.ShowDialog();
            }
        }

        public void editCodigoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (editCodigo.Text.Trim() != "")
                    IniciaVendaDeItens();
                else
                    editQuantidade.Focus();
            }
        }

        public void editCodigoKeyPress(object sender, KeyPressEventArgs e)
        {
            decimal Quantidade;

            if (e.KeyChar == '*')
            {
                e.Handled = true;
                try
                {
                    Quantidade = Convert.ToDecimal(EditCodigo.Text);
                    if (Quantidade <= 0)
                    {
                        MessageBox.Show("Quantidade invalida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        editCodigo.Text = "";
                        editQuantidade.Text = "1";
                    }
                    else
                    {
                        editQuantidade.Text = Quantidade.ToString();
                        editCodigo.Text = "";
                    }
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                    MessageBox.Show("Quantidade invalida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    editCodigo.Text = "";
                    editQuantidade.Text = "1";
                }
            }

        }

        private void editQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                editCodigo.Focus();
            }
        }

        private void editQuantidade_Leave(object sender, EventArgs e)
        {
            decimal Quantidade;
            Quantidade = Convert.ToDecimal(editCodigo.Text);
            if (Quantidade <= 0) 
            {
                MessageBox.Show("Quantidade invalida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                editQuantidade.Text = "1";
            }
        }

        public static void VendeItem()
        {
            CompoeItemParaVenda();

            if (VendaDetalhe.Gtin == "")
            {
                MessageBox.Show("Produto com Codigo ou GTIN não Definido!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EditUnitario.Text = "0";
                EditTotalItem.Text = "0";
                EditSubTotal.Text = "0";
                EditCodigo.Focus();
                EditCodigo.SelectAll();
                ItemCupom--;
                return;
            }

            if (VendaDetalhe.Produto.DescricaoPdv == "")
            {
                MessageBox.Show("Produto com Descricao não Definida!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EditUnitario.Text = "0";
                EditTotalItem.Text = "0";
                EditSubTotal.Text = "0";
                EditCodigo.Focus();
                EditCodigo.SelectAll();
                ItemCupom--;
                return;
            }

            if (VendaDetalhe.Produto.UnidadeProduto.Sigla == "")
            {
                MessageBox.Show("Produto com Unidade não Definida!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EditUnitario.Text = "0";
                EditTotalItem.Text = "0";
                EditSubTotal.Text = "0";
                EditCodigo.Focus();
                EditCodigo.SelectAll();
                ItemCupom--;
                return;
            }

            // Imposto
            VendaDetalhe.NfeDetalheImpostoIcms.OrigemMercadoria = 0; //nacional
            VendaDetalhe.NfeDetalheImpostoIcms.CstIcms = "00"; //nacional
            VendaDetalhe.NfeDetalheImpostoIcms.ModalidadeBcIcms = 3; //valor da operação
            VendaDetalhe.NfeDetalheImpostoIcms.AliquotaIcms = VendaDetalhe.Produto.AliquotaIcmsPaf;
            VendaDetalhe.NfeDetalheImpostoIcms.BaseCalculoIcms = VendaDetalhe.ValorTotal;
            VendaDetalhe.NfeDetalheImpostoIcms.ValorIcms = VendaDetalhe.ValorTotal * VendaDetalhe.Produto.AliquotaIcmsPaf / 100;

            VendaDetalhe = VendaController.GravaNfceVendaDetalhe(VendaDetalhe);
            Sessao.Instance.VendaAtual.ListaNfeDetalhe.Add(VendaDetalhe);
            ImprimeItemBobina();
            Bobina.SelectedIndex = Bobina.Items.Count - 1;
        }

        public static void CompoeItemParaVenda()
        {
            try
            {
                ItemCupom++;
                VendaDetalhe.NumeroItem = ItemCupom;
                VendaDetalhe.Cfop = Sessao.Instance.Configuracao.Cfop;
                VendaDetalhe.IdNfeCabecalho = Sessao.Instance.VendaAtual.Id;
                VendaDetalhe.CodigoProduto = VendaDetalhe.Produto.Gtin;
                VendaDetalhe.Gtin = VendaDetalhe.Produto.Gtin;
                VendaDetalhe.NomeProduto = VendaDetalhe.Produto.Nome;
                VendaDetalhe.Ncm = VendaDetalhe.Produto.Ncm;
                VendaDetalhe.UnidadeComercial = VendaDetalhe.Produto.UnidadeProduto.Sigla;
                VendaDetalhe.UnidadeTributavel = VendaDetalhe.Produto.UnidadeProduto.Sigla;
                
                if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento)
                {
                    VendaDetalhe.QuantidadeComercial = Convert.ToDecimal(EditQuantidade.Text);
                    VendaDetalhe.QuantidadeTributavel = Convert.ToDecimal(EditQuantidade.Text);
                    VendaDetalhe.ValorUnitarioComercial = Convert.ToDecimal(EditUnitario.Text);
                    VendaDetalhe.ValorUnitarioTributavel = Convert.ToDecimal(EditUnitario.Text);
                    VendaDetalhe.ValorBrutoProduto = Biblioteca.TruncaValor(VendaDetalhe.QuantidadeComercial * Convert.ToDecimal(EditUnitario.Text), 2);
                    VendaDetalhe.ValorSubtotal = Convert.ToDecimal(EditTotalItem.Text);
                    // Exercício: implemente o desconto sobre o valor do item de acordo com a sua necessidade
                    VendaDetalhe.ValorDesconto = 0;
                    VendaDetalhe.ValorTotal = VendaDetalhe.ValorSubtotal - VendaDetalhe.ValorDesconto;
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public static void ImprimeItemBobina()
        {
            string Quantidade, Unitario, Total, Unidade;
            Quantidade = VendaDetalhe.QuantidadeComercial.Value.ToString("###,##0.00");
            Unitario = VendaDetalhe.ValorUnitarioComercial.Value.ToString("###,##0.00");
            Total = VendaDetalhe.ValorTotal.Value.ToString("###,##0.00");
            string DescricaoProduto = VendaDetalhe.Produto.DescricaoPdv.Length < 27 ? VendaDetalhe.Produto.DescricaoPdv : VendaDetalhe.Produto.DescricaoPdv.Substring(0, 27);
            Bobina.Items.Add(new string('0', 3 - Convert.ToString(ItemCupom).Length) + Convert.ToString(ItemCupom) + "  " + VendaDetalhe.Gtin + new string(' ', 14 - VendaDetalhe.Gtin.Length) + " " + DescricaoProduto);

            Unidade = VendaDetalhe.Produto.UnidadeProduto.Sigla.Trim();

            Bobina.Items.Add(new string(' ', 8 - Quantidade.Length) + Quantidade + " " + new string(' ', 3 - Unidade.Length) + Unidade + " x " + new string(' ', 13 - Unitario.Length) + Unitario + " " + new string(' ', 5) + new string(' ', 14 - Total.Length) + Total);
        }

        public static void AtualizaTotais()
        {
            decimal DescontoAcrescimo;
            Sessao.Instance.VendaAtual.ValorTotalProdutos = SubTotal;
            Sessao.Instance.VendaAtual.ValorDesconto = Desconto;
            Sessao.Instance.VendaAtual.ValorDespesasAcessorias = Acrescimo;

            Sessao.Instance.VendaAtual.ValorTotal = TotalGeral - Desconto + Acrescimo;
            Sessao.Instance.VendaAtual.BaseCalculoIcms = Sessao.Instance.VendaAtual.ValorTotal;
            Sessao.Instance.VendaAtual.ValorIcms = ValorICMS;
            DescontoAcrescimo = Acrescimo - Desconto;

            if (DescontoAcrescimo < 0)
            {
                LabelDescontoAcrescimo.Text = "Desconto: R$ " + (-DescontoAcrescimo).ToString("###,###,##0.00");
                LabelDescontoAcrescimo.ForeColor = Color.Red;
                Sessao.Instance.VendaAtual.ValorDesconto = -DescontoAcrescimo;
                Sessao.Instance.VendaAtual.ValorDespesasAcessorias = 0;
            }
            else if (DescontoAcrescimo > 0)
            {
                LabelDescontoAcrescimo.Text = "Acrescimo: R$ " + DescontoAcrescimo.ToString("###,###,##0.00");
                LabelDescontoAcrescimo.ForeColor = Color.Blue;
                Sessao.Instance.VendaAtual.ValorDesconto = 0;
                Sessao.Instance.VendaAtual.ValorDespesasAcessorias = DescontoAcrescimo;
            }
            else
            {
                LabelDescontoAcrescimo.Text = "";
                Acrescimo = 0;
                Desconto = 0;
            }

            EditSubTotal.Text = Sessao.Instance.VendaAtual.ValorTotalProdutos.Value.ToString("###,###,##0.00");
            LabelTotalGeral.Text = Sessao.Instance.VendaAtual.ValorTotal.Value.ToString("###,###,##0.00");
        }

        public void IniciaEncerramentoVenda()
        {
            if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento)
            {
                if (Sessao.Instance.VendaAtual.ListaNfeDetalhe.Count > 0)
                {
                    if (Sessao.Instance.VendaAtual.ValorTotal <= 0)
                    {
                        if (MessageBox.Show("Todos os itens foram cancelados." + "\r" + "\r" + "Deseja cancelar o cupom?", "Cancelar o cupom", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            CancelaVenda();
                        return;
                    }

                    EfetuaPagamento FEfetuaPagamento = new EfetuaPagamento();
                    FEfetuaPagamento.ShowDialog();
                    EdtNVenda.Text = "";
                    EdtNumeroNota.Text = "";
                }
                else
                    MessageBox.Show("A venda não contem itens.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Não existe venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ConcluiEncerramentoVenda()
        {
            try
            {
                VendaController.GravaNfceVendaCabecalho(Sessao.Instance.VendaAtual);

                string xmlEnvio = GerarXmlSAT();
                IntPtr ptr = ComunicacaoSAT.EnviarDadosVenda(Sessao.GerarNumeroSessao(), Sessao.CodigoAtivacao(), xmlEnvio);
                String retornoSAT = Marshal.PtrToStringAnsi(ptr);

                // Salva a string retornada pelo SAT num Arquivo [para consultas pelo desenvolvedor - não precisa fazer isso em produção]
                string nomeArquivoRetorno = @"C:\T2Ti\SAT\TXT\RETORNO_" + Sessao.Instance.VendaAtual.ChaveAcesso + Sessao.Instance.VendaAtual.DigitoChaveAcesso + ".txt";
                System.IO.File.WriteAllText(nomeArquivoRetorno, retornoSAT);

                // Trata o retorno
                Dictionary<string, string> map = TratarRetornoSAT.retornoVenda(retornoSAT);

                string nomeXmlRetorno = @"C:\T2Ti\SAT\XML\RETORNO_" + Sessao.Instance.VendaAtual.ChaveAcesso + Sessao.Instance.VendaAtual.DigitoChaveAcesso + ".xml";
                if (map["autorizado"] == "S")
                {
                    string xmlRetorno = map["arquivoCFe"];
                    System.IO.File.WriteAllText(nomeXmlRetorno, xmlRetorno);
                }

                // Impressão com ACBrPrinter
                // Exercício: Implemente a Impressão com seu Gerador Preferido - Observe a implementação do ZEUS para a NFC-e
                try
                {
                    Process ACBrPrinter = new Process();
                    ACBrPrinter.StartInfo.FileName = @"ACBrPrinter.exe";
                    ACBrPrinter.StartInfo.Arguments = " SAT " + nomeXmlRetorno + " Conexao.ini";
                    ACBrPrinter.Start();
                    ACBrPrinter.WaitForExit();
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }

            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
            finally
            {
                TelaPadrao();
            }
        }

        public void CancelaVenda()
        {
            if (Sessao.Instance.Movimento == null)
                MessageBox.Show("Não existe um movimento aberto.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                LoginGerenteSupervisor FLoginGerenteSupervisor = new LoginGerenteSupervisor();
                try
                {
                    if (FLoginGerenteSupervisor.ShowDialog() == DialogResult.OK)
                    {
                        if (LoginGerenteSupervisor.LoginOK)
                        {
                            if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento)
                            {
                                if (MessageBox.Show("Deseja cancelar a venda atual?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
                                    TelaPadrao();
                                }
                            }
                            else if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scAberto)
                            {
                                if (MessageBox.Show("Deseja cancelar a venda anterior?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    // Exercício: Altere os dados da venda no banco e dados.
                                    // Exercício: Realize os procedimentos de controle para que o cupom seja cancelado apenas uma vez.
                                    
                                    // Exercício: Implemente o cancelamento da venda e a impressão do Extrato do Cancelamento no componente SAT
                                    
                                    // *** ComunicacaoSAT.CancelarUltimaVenda;
                                    // *** ComunicacaoSAT.ImprimirExtratoCancelamento;
                                    
                                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
                                    TelaPadrao();
                                }
                            }
                        }
                        else
                            MessageBox.Show("Login - dados incorretos.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }
            }
        }

        public void CancelaItem()
        {
            int cancela;

            if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento)
            {
                LoginGerenteSupervisor FLoginGerenteSupervisor = new LoginGerenteSupervisor();
                try
                {
                    if (FLoginGerenteSupervisor.ShowDialog() == DialogResult.OK)
                    {
                        if (LoginGerenteSupervisor.LoginOK)
                        {

                            ImportaNumero FImportaNumero = new ImportaNumero();
                            FImportaNumero.Text = "Cancela Item";
                            ImportaNumero.LabelEntrada.Text = "Informe o código do item:";

                            if (FImportaNumero.ShowDialog() == DialogResult.OK)
                            {
                                cancela = Convert.ToInt32(ImportaNumero.EditEntrada.Text);
                                if (cancela > 0)
                                {
                                    if (cancela <= Sessao.Instance.VendaAtual.ListaNfeDetalhe.Count)
                                    {
                                        if (MessageBox.Show("Deseja realmente cancelar o item?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            VendaController.CancelaItemVenda(cancela);

                                            Bobina.Items.Add(new string('*', 48));
                                            string DescricaoProduto = VendaDetalhe.Produto.DescricaoPdv.Length < 27 ? VendaDetalhe.Produto.DescricaoPdv : VendaDetalhe.Produto.DescricaoPdv.Substring(0, 27);
                                            Bobina.Items.Add(new string('0', 3 - Convert.ToString(cancela).Length) + Convert.ToString(cancela) + "  " + VendaDetalhe.Gtin + new string(' ', 14 - VendaDetalhe.Gtin.Length) + " " + DescricaoProduto);

                                            Bobina.Items.Add("ITEM CANCELADO");
                                            Bobina.Items.Add(new string('*', 48));

                                            SubTotal = SubTotal - VendaDetalhe.ValorTotal.Value;
                                            TotalGeral = TotalGeral - VendaDetalhe.ValorTotal.Value;
                                            ValorICMS = ValorICMS - VendaDetalhe.NfeDetalheImpostoIcms.ValorIcms.Value;

                                            //  cancela possíveis descontos ou acrescimos
                                            Desconto = 0;
                                            Acrescimo = 0;
                                            Bobina.SelectedIndex = Bobina.Items.Count - 1;
                                            AtualizaTotais();
                                        }
                                    }
                                    else
                                        MessageBox.Show("O item solicitado não existe na venda atual.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("Informe um numero de item valido.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            MessageBox.Show("Login - dados incorretos.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }
            }
            else
                MessageBox.Show("Não existe venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void RecuperarVenda()
        {
            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scVendaEmAndamento)
            {
                try
                {
                    ListaNfce FListaNfce = new ListaNfce();
                    FListaNfce.Operacao = "RecuperarVenda";
                    FListaNfce.ShowDialog();

                    if (ListaNfce.Confirmou)
                    {
                        Filtro = "Id = " + ListaNfce.IdSelecionado;
                        Sessao.Instance.VendaAtual = VendaController.ConsultaNfceVendaCabecalho(Filtro);
                        if (Sessao.Instance.VendaAtual != null)
                        {
                            ImprimeCabecalhoBobina();
                            ParametrosIniciaisVenda();

                            Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scRecuperandoVenda;

                            LabelMensagens.Text = "Venda recuperada em andamento..";

                            for (int i = 0; i <= Sessao.Instance.VendaAtual.ListaNfeDetalhe.Count - 1; i++)
                            {
                                VendaDetalhe = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i];
                                ConsultaProduto(VendaDetalhe.Gtin, 2);
                                CompoeItemParaVenda();
                                ImprimeItemBobina();

                                if (VendaDetalhe.NfeDetalheImpostoIcms.Id == 0)
                                {
                                    // Imposto
                                    VendaDetalhe.NfeDetalheImpostoIcms.OrigemMercadoria = 0; //nacional
                                    VendaDetalhe.NfeDetalheImpostoIcms.CstIcms = "00"; //nacional
                                    VendaDetalhe.NfeDetalheImpostoIcms.ModalidadeBcIcms = 3; //valor da operação
                                    VendaDetalhe.NfeDetalheImpostoIcms.AliquotaIcms = VendaDetalhe.Produto.AliquotaIcmsPaf;
                                    VendaDetalhe.NfeDetalheImpostoIcms.BaseCalculoIcms = VendaDetalhe.ValorTotal;
                                    VendaDetalhe.NfeDetalheImpostoIcms.ValorIcms = VendaDetalhe.ValorTotal * VendaDetalhe.Produto.AliquotaIcmsPaf / 100;
                                }

                                SubTotal = SubTotal + VendaDetalhe.ValorTotal.Value;
                                TotalGeral = TotalGeral + VendaDetalhe.ValorTotal.Value;
                                ValorICMS = ValorICMS + VendaDetalhe.NfeDetalheImpostoIcms.ValorIcms.Value;
                                AtualizaTotais();
                            }

                            EdtNVenda.Text = "Venda nº " + Convert.ToString(Sessao.Instance.VendaAtual.Id);
                            EdtNumeroNota.Text = "Cupom nº " + Convert.ToString(Sessao.Instance.VendaAtual.Numero);

                            Bobina.SelectedIndex = Bobina.Items.Count - 1;
                            EditCodigo.Focus();
                            Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scVendaEmAndamento;
                        }
                    }
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }
            }
            else
                MessageBox.Show("Existe uma venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DesabilitaControlesVenda()
        {
            editCodigo.Enabled = false;
            editQuantidade.Enabled = false;
            editUnitario.Enabled = false;
            editTotalItem.Enabled = false;
            editSubTotal.Enabled = false;
            bobina.Enabled = false;
            PanelBotoes.Enabled = false;
        }

        public void HabilitaControlesVenda()
        {
            editCodigo.Enabled = true;
            editQuantidade.Enabled = true;
            editUnitario.Enabled = true;
            editTotalItem.Enabled = true;
            editSubTotal.Enabled = true;
            bobina.Enabled = true;
            PanelBotoes.Enabled = true;
        }
        
        #endregion Procedimentos para controle da venda

        #region Demais procedimentos para o SAT

        public static void ConsultaStatusOperacional()
        {
            StatusOperacional FStatusOperacional = new StatusOperacional();
            FStatusOperacional.ShowDialog();
        }

        public static string GerarXmlSAT()
        {
            infNFe InfNFe = new infNFe
            {
                versao = Auxiliar.VersaoServicoParaString(_configuracoes.CfgServico.VersaoNFeAutorizacao),
                ide = GetIdentificacao(),
                emit = GetEmitente(),
                transp = GetTransporte()
            };

           if (Sessao.Instance.VendaAtual.NfeDestinatario.CpfCnpj != null)
                InfNFe.dest = GetDestinatario();

            InfNFe.pag = GetPagamento(); 

            for (var i = 0; i < 1; i++)
            {
                InfNFe.det.Add(GetDetalhe(i, InfNFe.emit.CRT));
            }

            InfNFe.total = GetTotal();

            _nfe = new NFe.Classes.NFe();
            _nfe.infNFe = InfNFe;

            string nomeArquivoXml = @"C:\T2Ti\SAT\XML\" + Sessao.Instance.VendaAtual.ChaveAcesso + Sessao.Instance.VendaAtual.DigitoChaveAcesso + ".xml";
            _nfe.SalvarArquivoXml(nomeArquivoXml);

            // Exercício: ATENÇÃO: estude o componente ZEUS e faça a devida ataptação ou construa um novo componente para gerar o XML do SAT
            SAT_MIAU.ConverterNFCeParaSAT(nomeArquivoXml);

            XmlDocument ArquivoXML = new XmlDocument();
            ArquivoXML.Load(nomeArquivoXml);

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            ArquivoXML.WriteTo(xmlTextWriter);

            string xml = stringWriter.ToString();

            return xml;
        }

        protected static ide GetIdentificacao()
        {
            var ide = new ide
            {
                cUF = Estado.DF,
                natOp = "VENDA",
                indPag = IndicadorPagamento.ipVista,
                mod = ModeloDocumento.NFCe,
                serie = 1,
                nNF = int.Parse(Sessao.Instance.VendaAtual.Numero),
                tpNF = TipoNFe.tnSaida,
                cMunFG = 5300108,
                tpEmis = _configuracoes.CfgServico.tpEmis,
                tpImp = TipoImpressao.tiNFCe,
                cNF = Sessao.Instance.VendaAtual.CodigoNumerico,
                tpAmb = _configuracoes.CfgServico.tpAmb,
                finNFe = FinalidadeNFe.fnNormal,
                verProc = "3.000"
            };

            if (ide.tpEmis != TipoEmissao.teNormal)
            {
                ide.dhCont = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
                ide.xJust = "TESTE DE CONTIGÊNCIA PARA NFe/NFCe";
            }

            ide.idDest = DestinoOperacao.doInterna;
            ide.dhEmi = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"); 
            ide.procEmi = ProcessoEmissao.peAplicativoContribuinte;
            ide.indFinal = ConsumidorFinal.cfConsumidorFinal; 
            ide.indPres = PresencaComprador.pcPresencial; 

            return ide;
        }

        protected static emit GetEmitente()
        {
            var emit = _configuracoes.Emitente;
            emit.enderEmit = GetEnderecoEmitente();
            return emit;
        }

        protected static enderEmit GetEnderecoEmitente()
        {
            var enderEmit = _configuracoes.EnderecoEmitente;
            enderEmit.cPais = 1058;
            enderEmit.xPais = "BRASIL";
            return enderEmit;
        }

        protected static dest GetDestinatario()
        {
            dest dest = new dest(_configuracoes.CfgServico.VersaoNFeAutorizacao);
            dest.xNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"; //Sessao.Instance.VendaAtual.NfeDestinatario.Nome
            dest.indIEDest = indIEDest.NaoContribuinte;
            dest.email = Sessao.Instance.VendaAtual.NfeDestinatario.Email;
            dest.CPF = Sessao.Instance.VendaAtual.NfeDestinatario.CpfCnpj;
            //dest.enderDest = GetEnderecoDestinatario();

            return dest;
        }

        protected static enderDest GetEnderecoDestinatario()
        {
            var enderDest = new enderDest
            {
                xLgr = Sessao.Instance.VendaAtual.NfeDestinatario.Logradouro,
                nro = Sessao.Instance.VendaAtual.NfeDestinatario.Numero,
                xBairro = Sessao.Instance.VendaAtual.NfeDestinatario.Bairro,
                cMun = Sessao.Instance.VendaAtual.NfeDestinatario.CodigoMunicipio.Value,
                xMun = Sessao.Instance.VendaAtual.NfeDestinatario.NomeMunicipio,
                UF = Sessao.Instance.VendaAtual.NfeDestinatario.Uf,
                CEP = Sessao.Instance.VendaAtual.NfeDestinatario.Cep,
                cPais = 1058,
                xPais = "BRASIL"
            };
            return enderDest;
        }

        protected static det GetDetalhe(int i, CRT crt)
        {
            var det = new det
            {
                nItem = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].NumeroItem.Value,
                prod = GetProduto(i),
                imposto = new imposto
                {
                    vTotTrib = decimal.Parse(Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].NfeDetalheImpostoIcms.ValorIcms.Value.ToString("N2")),
                    ICMS = new ICMS
                    {
                        TipoICMS = crt == CRT.SimplesNacional ? InformarCSOSN(Csosnicms.Csosn102) : InformarICMS(Csticms.Cst00, i)
                    }
                }
            };

            return det;
        }

        protected static prod GetProduto(int i)
        {
            var p = new prod
            {
                cProd = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].Gtin,
                cEAN = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].Gtin,
                xProd = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].NomeProduto,
                NCM = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].Ncm,
                CFOP = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].Cfop.Value,
                uCom = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].UnidadeComercial,
                qCom = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].QuantidadeComercial.Value,
                vUnCom = decimal.Parse(Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].ValorUnitarioComercial.Value.ToString("N2")),
                vProd = decimal.Parse(Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].ValorTotal.Value.ToString("N2")),
                vDesc = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].ValorDesconto.Value,
                cEANTrib = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].Gtin,
                uTrib = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].UnidadeTributavel,
                qTrib = Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].QuantidadeTributavel.Value,
                vUnTrib = decimal.Parse(Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].ValorUnitarioTributavel.Value.ToString("N2")),
                indTot = IndicadorTotal.ValorDoItemCompoeTotalNF,
            };
            return p;
        }

        protected static ICMSBasico InformarICMS(Csticms CST, int i)
        {
            return new ICMSSN102
            {
                orig = OrigemMercadoria.OmNacional, CSOSN = Csosnicms.Csosn102
            };
            /*
            switch (CST)
            {
                case Csticms.Cst00:
                    return new ICMS00
                    {
                        CST = Csticms.Cst00,
                        modBC = DeterminacaoBaseIcms.DbiValorOperacao,
                        orig = OrigemMercadoria.OmNacional,
                        pICMS = decimal.Parse(Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].NfeDetalheImpostoIcms.AliquotaIcms.Value.ToString("N2")),
                        vBC = decimal.Parse(Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].NfeDetalheImpostoIcms.BaseCalculoIcms.Value.ToString("N2")),
                        vICMS = decimal.Parse(Sessao.Instance.VendaAtual.ListaNfeDetalhe[i].NfeDetalheImpostoIcms.ValorIcms.Value.ToString("N2")),
                    };
                //Outros casos aqui
             
            }

            return new ICMS10();
             * * */
        }

        protected static ICMSBasico InformarCSOSN(Csosnicms CST)
        {
            switch (CST)
            {
                case Csosnicms.Csosn101:
                    return new ICMSSN101
                    {
                        CSOSN = Csosnicms.Csosn101,
                        orig = OrigemMercadoria.OmNacional
                    };
                case Csosnicms.Csosn102:
                    return new ICMSSN102
                    {
                        CSOSN = Csosnicms.Csosn102,
                        orig = OrigemMercadoria.OmNacional
                    };
                //Outros casos aqui
                default:
                    return new ICMSSN201();
            }
        }

        protected static total GetTotal()
        {
            var icmsTot = new ICMSTot
            {
                vProd = decimal.Parse(Sessao.Instance.VendaAtual.ValorTotalProdutos.Value.ToString("N2")),
                vNF = decimal.Parse(Sessao.Instance.VendaAtual.ValorTotal.Value.ToString("N2")),
                vDesc = decimal.Parse(Sessao.Instance.VendaAtual.ValorDesconto.Value.ToString("N2")),
                vTotTrib = decimal.Parse(Sessao.Instance.VendaAtual.ValorIcms.Value.ToString("N2")),
                vBC = decimal.Parse(Sessao.Instance.VendaAtual.BaseCalculoIcms.Value.ToString("N2")),
                vICMS = decimal.Parse(Sessao.Instance.VendaAtual.ValorIcms.Value.ToString("N2")),
                vICMSDeson = 0
            };

            var t = new total { ICMSTot = icmsTot };
            return t;
        }

        protected static transp GetTransporte()
        {
            var t = new transp
            {
                modFrete = ModalidadeFrete.mfSemFrete //NFCe: Não pode ter frete
            };

            return t;
        }

        // Exercício: pegue os pagamentos utilizados na venda e informe para a NFCe  
        protected static List<pag> GetPagamento()
        {
            var p = new List<pag>
            {
                new pag {tPag = FormaPagamento.fpDinheiro, vPag = Biblioteca.TruncaValor(Sessao.Instance.VendaAtual.ValorTotal.Value, Constantes.DECIMAIS_VALOR)}
            };
            return p;
        }
        #endregion Demais procedimentos para o SAT

        #region Controle dos cliques nos botões de função
        private void botaoF1_Click(object sender, EventArgs e)
        {
            IdentificaCliente();
        }

        private void botaoF2_Click(object sender, EventArgs e)
        {
            AcionaMenuPrincipal();
        }

        private void botaoF3_Click(object sender, EventArgs e)
        {
            AcionaMenuOperacoes();
        }

        private void botaoF4_Click(object sender, EventArgs e)
        {
            ConsultaStatusOperacional();
        }

        private void botaoF5_Click(object sender, EventArgs e)
        {
            RecuperarVenda();
        }

        private void botaoF6_Click(object sender, EventArgs e)
        {
            LocalizaProduto();
        }

        private void botaoF7_Click(object sender, EventArgs e)
        {
            IniciaEncerramentoVenda();
        }

        private void botaoF8_Click(object sender, EventArgs e)
        {
            CancelaItem();
        }

        private void botaoF9_Click(object sender, EventArgs e)
        {
            CancelaVenda();
        }

        private void botaoF10_Click(object sender, EventArgs e)
        {
            DescontoOuAcrescimo();
        }

        private void botaoF11_Click(object sender, EventArgs e)
        {
            IdentificaVendedor();
        }

        private void botaoF12_Click(object sender, EventArgs e)
        {
            FormCloseQuery();
        }
        #endregion Controle dos cliques nos botões de função

        #region Procedimentos para ler peso direto das balanças componente ACBrBal

        public void ConectaComBalanca()
        {
            //Exercício: implemente a conexão com balanças

            /*
            try
            {
                //  se houver conexão aberta, Fecha a conexão
                if (ACBrBAL.Ativo)
                    ACBrBAL.Desativar();

                //  configura porta de comunicacao
                ACBrBAL.Modelo = (ACBrFramework.BAL.ModeloBal)Sessao.Instance.Configuracao.NfceConfiguracaoBalanca.Modelo;
                ACBrBAL.Device.HandShake = (ACBrFramework.SerialHandShake)Sessao.Instance.Configuracao.NfceConfiguracaoBalanca.HandShake;
                ACBrBAL.Device.Parity = (ACBrFramework.SerialParity)Sessao.Instance.Configuracao.NfceConfiguracaoBalanca.Parity;
                ACBrBAL.Device.StopBits = (ACBrFramework.SerialStopBits)Sessao.Instance.Configuracao.NfceConfiguracaoBalanca.StopBits;
                ACBrBAL.Device.DataBits = Sessao.Instance.Configuracao.NfceConfiguracaoBalanca.DataBits.Value;
                ACBrBAL.Device.Baud = Sessao.Instance.Configuracao.NfceConfiguracaoBalanca.BaudRate.Value;
                ACBrBAL.Device.Porta = Sessao.Instance.Configuracao.NfceConfiguracaoBalanca.Porta;
                //  Conecta com a balança
                ACBrBAL.Ativar();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
             * */
        }

        public void ACBrBAL1LePeso(decimal Peso, string Resposta)
        {
            /*
            int valid;
            editCodigo.Text = Peso.ToString("0.000") + "*";
            if (Peso > 0)
            {
                labelMensagens.Text = "Leitura da Balança OK !";
                editQuantidade.Text = Peso.ToString("0.000");
                editCodigo.Focus();
            }
            else
            {
                valid = Convert.ToInt32(ACBrBAL.UltimoPesoLido); switch (valid)
                {
                    case 0:
                        labelMensagens.Text = "Coloque o produto sobre a Balança!"; break;
                    case -1:
                        labelMensagens.Text = "Tente Nova Leitura"; break;
                    case -2:
                        labelMensagens.Text = "Peso negativo !"; break;
                    case -10:
                        labelMensagens.Text = "Sobrepeso !"; break;
                }
            }
             * */
        }

        #endregion Procedimentos para ler peso direto das balanças componente ACBrBal


    }

}
