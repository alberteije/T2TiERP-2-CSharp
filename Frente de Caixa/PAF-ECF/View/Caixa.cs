/* *******************************************************************************
  Title: T2TiPDV
  Description: Tela principal do PAF-ECF - Caixa.

  The MIT License

  Copyright: Copyright (C) 2014 T2Ti.COM

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
  alberteije@gmail.com

  @author T2Ti.COM
  @version 2.0
  ******************************************************************************* */



using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PafEcf.DTO;
using PafEcf.Controller;
using ACBrFramework.ECF;
using PafEcf.Util;
using System.IO;
using System.Drawing;
using System.Xml;
using PafEcf.ServidorReference;

namespace PafEcf.View
{
    public partial class Caixa : Form
    {

        #region Variáveis

        public static int ItemCupom;
        public static decimal SubTotal, TotalGeral, Desconto, Acrescimo, IbptFederal, IbptEstadual, IbptMunicipal;
        public static string Filtro, MD5, TipoDAV;
        public static bool BalancaLePeso;

        public static EcfVendaDetalheDTO VendaDetalhe;
        public static PreVendaCabecalhoDTO PreVenda;
        public static DavCabecalhoDTO DavCabecalho;

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
        public static Label EdtCOO { get; set; }
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
            EdtCOO = this.edtCOO;
            ImageProduto = this.imageProduto;
            Bobina = this.bobina;
            //
            FormCreate();
        }

        public void FormCloseQuery()
        {

            if ((Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scAberto) || (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scSomenteConsulta) || (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scFechado))
            {
                if (MessageBox.Show("Tem Certeza Que Deseja Sair do Sistema?", "Sair do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataModule.ACBrECF.Desativar();
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Existe uma venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void FormCreate()
        {
            DataModule DataModule = new DataModule();
            Splash FSplash = new Splash();
            FSplash.Show();
            FSplash.Refresh();
            System.Threading.Thread.Sleep(2000);

            DesabilitaControlesVenda();

            Sessao.Instance.PopulaObjetosPrincipais();
            Sessao.Instance.MenuAberto = false;
            Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scFechado;

            ConfiguraConstantes();
            ConfiguraLayout();
            ConfiguraResolucao();

            try
            {
                ConfiguraACBr();
            }
            finally
            {
                Application.DoEvents();
                FSplash.Close();
                ExecutaOutrosProcedimentosDeAbertura();
            }
        }

        public void ExecutaOutrosProcedimentosDeAbertura()
        {
            try
            {
                VerificaEstadoImpressora();
                VerificaGPAtivo();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }

            MD5 = "MD-5:" + PAFUtil.GeraMD5();
            TelaPadrao();

            if (Sessao.Instance.Movimento != null)
            {
                MovimentoAberto FMovimentoAberto = new MovimentoAberto();
                FMovimentoAberto.ShowDialog();
            }

            //  só continua o procedimento caso o usuário não cancele a tela FMovimentoAberto
            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scUsuarioCancelouTelaMovimento)
            {
                HabilitaControlesVenda();
                try
                {
                    if (!PAFUtil.ECFAutorizado())
                    {
                        MessageBox.Show("ECF não autorizado - aplicação aberta apenas para consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                        labelMensagens.Text = "Terminal em Estado Somente Consulta";
                    }

                    if (!VerificaVendaAberta())
                    {
                        if (!PAFUtil.ConfereGT())
                        {
                            MessageBox.Show("Grande total invalido - entre em contato com a Software House.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                            labelMensagens.Text = "Terminal em Estado Somente Consulta";
                        }
                    }
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                    labelMensagens.Text = "Terminal em Estado Somente Consulta";
                }

            }

            if (Sessao.Instance.Configuracao.EcfConfiguracaoBalanca.Modelo > 0)
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

            try
            {
                if (DateTime.Now.ToString("dd/MM/yyyy") != DataModule.ACBrECF.DataHora.ToString("dd/MM/yyyy"))
                {
                    MessageBox.Show("Data do ECF diferente da data do computador - aplicação aberta apenas para consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                    labelMensagens.Text = "Data do ECF diferente da data do computador. Terminal em Estado Somente Consulta";
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }

            if (Sessao.Instance.Configuracao.EcfImpressora.Serie != DataModule.ACBrECF.NumSerie)
            {
                MessageBox.Show("Numero de Serie do ECF diferente do cadastrado no computador - aplicação aberta apenas para consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                labelMensagens.Text = "Numero de Serie do ECF diferente do cadastrado na base. Terminal em Estado Somente Consulta";
            }       
        }

        public void ConfiguraLayout()
        {
            panelTitulo.Text = Sessao.Instance.Configuracao.TituloTelaCaixa;

            if (File.Exists(Sessao.Instance.Configuracao.CaminhoImagensLayout + Sessao.Instance.Configuracao.EcfResolucao.ImagemTela))
            {
                Image ImagemFundo = Image.FromFile(Sessao.Instance.Configuracao.CaminhoImagensLayout + Sessao.Instance.Configuracao.EcfResolucao.ImagemTela);
                this.BackgroundImage = ImagemFundo;
            }
        }

        public void VerificaGPAtivo()
        {
            EfetuaPagamento FEfetuaPagamento = new EfetuaPagamento();
            try
            {
                //EfetuaPagamento.ACBrTEFD.Initializar(ACBrFramework.TEFD.TefTipo.TefDial);
            }
            catch (Exception eeError)
            {
                Log.write(eeError.ToString());
            }
            FEfetuaPagamento.Dispose();
        }

        public void VerificaEstadoImpressora()
        {
            string Estado = DataModule.ACBrECF.Estado.ToString();

            if (Estado == "Não Inicializada")
            {
                MessageBox.Show("Estado da impressora fiscal: não Inicializada. Aplicação será aberta para somente consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
            }
            if (Estado == "Desconhecido")
            {
                MessageBox.Show("Estado da impressora fiscal: Desconhecido. Aplicação será aberta para somente consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
            }
            if ((Estado == "Venda") || (Estado == "Pagamento"))
            {
                if (VendaController.ExisteVendaAberta())
                {
                    //  se por um acaso ocorrer de existir um cupom aberto no ecf e nenhuma venda com status 'A' no BD
                    MessageBox.Show("Existe um cupom aberto inconsistente. Cupom fiscal será cancelado.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ECFUtil.CancelaCupom();
                }
            }
            if (Estado == "RequerX")
            {
                if (MessageBox.Show("É necessario emitir uma Leitura X. Deseja fazer isso agora?", "Leitura X", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ECFUtil.LeituraX();
            }
            if (Estado == "RequerZ")
            {
                if (MessageBox.Show("É necessario emitir uma Reducao Z. Deseja fazer isso agora?", "Leitura Z", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ECFUtil.ReducaoZ();
            }
        }

        public void ConfiguraACBr()
        {
            DataModule.ACBrECF.Modelo = (ModeloECF)Convert.ToInt32(Sessao.Instance.Configuracao.EcfImpressora.ModeloAcbr);
            DataModule.ACBrECF.Device.Porta = Sessao.Instance.Configuracao.PortaEcf;
            DataModule.ACBrECF.Device.TimeOut = Sessao.Instance.Configuracao.TimeoutEcf.Value;
            DataModule.ACBrECF.IntervaloAposComando = Sessao.Instance.Configuracao.IntervaloEcf.Value;
            DataModule.ACBrECF.Device.Baud = Sessao.Instance.Configuracao.BitsPorSegundo.Value;
            try
            {
                DataModule.ACBrECF.Ativar();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                MessageBox.Show("ECF com problemas ou desligado. Aplicação será aberta para somente consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DesabilitaControlesVenda();
                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                TelaPadrao();
                return;
            }

            DataModule.ACBrECF.CarregaAliquotas();
            if (DataModule.ACBrECF.Aliquotas.Length <= 0)
            {
                MessageBox.Show("ECF sem aliquotas cadastradas. Aplicação será aberta para somente consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
            }

            DataModule.ACBrECF.CarregaFormasPagamento();
            if (DataModule.ACBrECF.FormasPagamento.Length <= 0)
            {
                MessageBox.Show("ECF sem formas de pagamento cadastradas. Aplicação será aberta para somente consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
            }
        }

        public void ConfiguraConstantes()
        {
            Constantes.DECIMAIS_QUANTIDADE = Sessao.Instance.Configuracao.DecimaisQuantidade.Value;
            Constantes.DECIMAIS_VALOR = Sessao.Instance.Configuracao.DecimaisValor.Value;
        }

        public void ConfiguraResolucao()
        {
            IList<EcfPosicaoComponentesDTO> ListaPosicoes = Sessao.Instance.Configuracao.EcfResolucao.ListaEcfPosicaoComponentes;

            string NomeComponente;
            EcfPosicaoComponentesDTO PosicaoComponente;

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

        public bool VerificaVendaAberta()
        {
            bool NovoCupom = false;

            Filtro = "StatusVenda = " + Biblioteca.QuotedStr("A");
            Sessao.Instance.VendaAtual = VendaController.ConsultaEcfVendaCabecalho(Filtro);

            if (Sessao.Instance.VendaAtual != null)
            {

                if (DataModule.ACBrECF.Estado.ToString() == "Livre")
                {
                    ECFUtil.AbreCupom();
                    NovoCupom = true;
                }

                ImprimeCabecalhoBobina();
                ParametrosIniciaisVenda();

                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scVendaRecuperadaDavPreVenda;

                labelMensagens.Text = "Venda recuperada em andamento..";

                for (int i = 0; i <= Sessao.Instance.VendaAtual.ListaEcfVendaDetalhe.Count - 1; i++)
                {
                    VendaDetalhe = Sessao.Instance.VendaAtual.ListaEcfVendaDetalhe[i];
                    ConsultaProduto(VendaDetalhe.Gtin, 2);
                    CompoeItemParaVenda();
                    ImprimeItemBobina();
                    SubTotal = SubTotal + VendaDetalhe.ValorTotal.Value;
                    TotalGeral = TotalGeral + VendaDetalhe.ValorTotal.Value;
                    AtualizaTotais();
                    if (NovoCupom)
                        ECFUtil.VendeItem(VendaDetalhe);
                }

                bobina.SelectedIndex = bobina.Items.Count - 1;
                editCodigo.Focus();
                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scVendaEmAndamento;
                return true;
            }
            else
            {
                return false;
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
                LabelMensagens.Text = "SAIDA Temporaria";
            else
                LabelMensagens.Text = "CAIXA ABERTO";

            if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento)
                LabelMensagens.Text = "Venda em andamento...";

            if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scSomenteConsulta)
                LabelMensagens.Text = "Terminal em Estado Somente Consulta";

            if (Sessao.Instance.Movimento != null)
            {
                LabelCaixa.Text = "Terminal: " + Sessao.Instance.Movimento.EcfCaixa.Nome;
                LabelOperador.Text = "Operador: " + Sessao.Instance.Movimento.EcfOperador.Login;
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
            EdtCOO.Text = "";

            SubTotal = 0;
            TotalGeral = 0;
            Desconto = 0;
            Acrescimo = 0;

            IbptFederal = 0;
            IbptEstadual = 0;
            IbptMunicipal = 0;

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
                AcionaMenuFiscal();

            //  F5 - Entrada de Dados de NF
            if (e.KeyCode == Keys.F5)
                EntradaDadosNF();

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
                CancelaCupom();

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
                if (Sessao.Instance.Configuracao.EcfConfiguracaoBalanca.Modelo > 0)
                {
                    try
                    {
                        BalancaLePeso = true;
                        DataModule.ACBrBAL.LePeso(Sessao.Instance.Configuracao.EcfConfiguracaoBalanca.Timeout.Value);
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
            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scSomenteConsulta)
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
            else
                MessageBox.Show("Terminal em Estado Somente Consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AcionaMenuOperacoes()
        {
            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scSomenteConsulta)
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
            else
                MessageBox.Show("Terminal em Estado Somente Consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AcionaMenuFiscal()
        {
            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scVendaEmAndamento)
            {
                Sessao.Instance.MenuAberto = true;
                MenuFiscal FMenuFiscal = new MenuFiscal();
                FMenuFiscal.ShowDialog();
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
                            ECFUtil.Suprimento(ValorSuprimento, Sessao.Instance.Configuracao.DescricaoSuprimento);

                            EcfSuprimentoDTO Suprimento = new EcfSuprimentoDTO();
                            Suprimento.IdEcfMovimento = Sessao.Instance.Movimento.Id;
                            Suprimento.DataSuprimento = DataModule.ACBrECF.DataHora;
                            Suprimento.Valor = ValorSuprimento;
                            EcfSuprimentoController.GravaEcfSuprimento(Suprimento);
                            Sessao.Instance.Movimento.TotalSuprimento = Sessao.Instance.Movimento.TotalSuprimento.Value + ValorSuprimento;
                            EcfMovimentoController.GravaEcfMovimento(Sessao.Instance.Movimento);
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
                            ECFUtil.Sangria(ValorSangria, Sessao.Instance.Configuracao.DescricaoSangria);

                            EcfSangriaDTO Sangria = new EcfSangriaDTO();
                            Sangria.IdEcfMovimento = Sessao.Instance.Movimento.Id;
                            Sangria.DataSangria = DataModule.ACBrECF.DataHora;
                            Sangria.Valor = ValorSangria;
                            EcfSangriaController.GravaEcfSangria(Sangria);
                            Sessao.Instance.Movimento.TotalSangria = Sessao.Instance.Movimento.TotalSangria.Value + ValorSangria;
                            EcfMovimentoController.GravaEcfMovimento(Sessao.Instance.Movimento);
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
            try
            {

                //  0-Desconto em Dinheiro
                //  1-Desconto Percentual
                //  2-Acrescimo em Dinheiro
                //  3-Acrescimo Percentual
                //  5-Cancela o Desconto ou Acrescimo

                int Operacao;
                decimal Valor;
                if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scSomenteConsulta)
                {
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
                                        Sessao.Instance.VendaAtual.TaxaAcrescimo = 0;
                                        Sessao.Instance.VendaAtual.TaxaDesconto = 0;
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
                                            if (Valor >= Sessao.Instance.VendaAtual.ValorVenda.Value)
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
                                                    Sessao.Instance.VendaAtual.TaxaDesconto = 100 - (((100 - Sessao.Instance.VendaAtual.TaxaDesconto) / 100) * ((100 - Valor) / 100)) * 100;

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
                                            else if (Valor >= Sessao.Instance.VendaAtual.ValorVenda)
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
                                                Sessao.Instance.VendaAtual.TaxaAcrescimo = (((100 + Valor) / 100) * ((100 + Sessao.Instance.VendaAtual.TaxaAcrescimo) / 100)) / 100;
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
                else
                    MessageBox.Show("Terminal em Estado Somente Consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }
        
        #endregion Procedimentos referentes ao Menu Principal e seus SubMenus

        #region Procedimentos referentes ao Menu Operacoes e seus SubMenus

        public static void CarregaPreVenda(string pNumero)
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Filtro = "from PreVendaCabecalhoDTO where Situacao = " + Biblioteca.QuotedStr("P") + " and Id=" + pNumero;
                    PreVenda = Servico.SelectObjetoPreVendaCabecalho(Filtro);

                    if (PreVenda != null)
                    {
                        if (PreVenda.ListaPreVendaDetalhe.Length > 0)
                        { 
                            IniciaVenda();
                            Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scVendaRecuperadaDavPreVenda;
                            Sessao.Instance.VendaAtual.IdEcfPreVendaCabecalho = PreVenda.Id;
                            for (int i = 0; i <= PreVenda.ListaPreVendaDetalhe.Length - 1; i++)
                            {
                                VendaDetalhe = new EcfVendaDetalheDTO();
                                VendaDetalhe.Produto = ProdutoController.ConsultaPorTipo(PreVenda.ListaPreVendaDetalhe[i].Produto.Id.ToString(), 4);

                                VendaDetalhe.Quantidade = PreVenda.ListaPreVendaDetalhe[i].Quantidade;
                                VendaDetalhe.ValorUnitario = PreVenda.ListaPreVendaDetalhe[i].ValorUnitario;
                                VendaDetalhe.ValorTotal = PreVenda.ListaPreVendaDetalhe[i].ValorTotal;
                                VendeItem();
                                SubTotal = SubTotal + VendaDetalhe.ValorTotal.Value;
                                TotalGeral = TotalGeral + VendaDetalhe.ValorTotal.Value;
                                AtualizaTotais();
                                if (PreVenda.ListaPreVendaDetalhe[i].Cancelado == "S")
                                {
                                    ECFUtil.CancelaItem(ItemCupom);

                                    VendaDetalhe.TotalizadorParcial = "Can-T";
                                    VendaDetalhe.Cancelado = "S";
                                    VendaDetalhe.Ccf = int.Parse(DataModule.ACBrECF.NumCCF);
                                    VendaDetalhe.Coo = int.Parse(DataModule.ACBrECF.NumCOO);
                                    VendaController.CancelaItemVenda(VendaDetalhe);

                                    Bobina.Items.Add(new string('*', 48));
                                    string DescricaoProduto = VendaDetalhe.Produto.DescricaoPdv.Length < 27 ? VendaDetalhe.Produto.DescricaoPdv : VendaDetalhe.Produto.DescricaoPdv.Substring(0, 27);
                                    Bobina.Items.Add(new string('0', 3 - Convert.ToString(ItemCupom).Length) + Convert.ToString(ItemCupom) + "  " + VendaDetalhe.Gtin + new string(' ', 14 - VendaDetalhe.Gtin.Length) + " " + DescricaoProduto);

                                    Bobina.Items.Add("ITEM CANCELADO");
                                    Bobina.Items.Add(new string('*', 48));

                                    SubTotal = SubTotal - VendaDetalhe.ValorTotal.Value;
                                    TotalGeral = TotalGeral - VendaDetalhe.ValorTotal.Value;

                                    //  cancela possíveis descontos ou acrescimos
                                    Bobina.SelectedIndex = Bobina.Items.Count - 1;
                                    AtualizaTotais();
                                }
                            }
                            Bobina.SelectedIndex = Bobina.Items.Count - 1;
                            EditCodigo.Focus();
                            Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scVendaEmAndamento;
                        }
                        else
                            MessageBox.Show("Pré-Venda sem itens.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Pre-Venda inexistente ou ja efetivada/mesclada.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.write(ex.ToString());
                throw ex;
            }
        }

        public static void CarregaDAV(string pNumero)
        {
            try
            {
                using (ServiceServidor Servico = new ServiceServidor())
                {
                    Filtro = "from DavCabecalhoDTO where Situacao = " + Biblioteca.QuotedStr("P") + " and Id=" + pNumero;
                    DavCabecalho = Servico.SelectObjetoDavCabecalho(Filtro);

                    if (DavCabecalho != null)
                    {
                        if (DavCabecalho.ListaDavDetalhe.Length > 0)
                        {
                            IniciaVenda();
                            Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scVendaRecuperadaDavPreVenda;
                            Sessao.Instance.VendaAtual.IdEcfDav = DavCabecalho.Id;
                            for (int i = 0; i <= DavCabecalho.ListaDavDetalhe.Length - 1; i++)
                            {
                                VendaDetalhe = new EcfVendaDetalheDTO();
                                VendaDetalhe.Produto = ProdutoController.ConsultaPorTipo(DavCabecalho.ListaDavDetalhe[i].Produto.Id.ToString(), 4);

                                VendaDetalhe.Quantidade = DavCabecalho.ListaDavDetalhe[i].Quantidade;
                                VendaDetalhe.ValorUnitario = DavCabecalho.ListaDavDetalhe[i].ValorUnitario;
                                VendaDetalhe.ValorTotal = DavCabecalho.ListaDavDetalhe[i].ValorTotal;
                                VendeItem();
                                SubTotal = SubTotal + VendaDetalhe.ValorTotal.Value;
                                TotalGeral = TotalGeral + VendaDetalhe.ValorTotal.Value;
                                AtualizaTotais();

                                /// EXERCÍCIO:
                                ///  Se for DAV para farmácia, imprima a descrição da fórmula
                                ///  Se for DAV-OS, imprima os dados do serviço

                                if (DavCabecalho.ListaDavDetalhe[i].Cancelado == "S")
                                {
                                    ECFUtil.CancelaItem(ItemCupom);

                                    VendaDetalhe.TotalizadorParcial = "Can-T";
                                    VendaDetalhe.Cancelado = "S";
                                    VendaDetalhe.Ccf = int.Parse(DataModule.ACBrECF.NumCCF);
                                    VendaDetalhe.Coo = int.Parse(DataModule.ACBrECF.NumCOO);
                                    VendaController.CancelaItemVenda(VendaDetalhe);

                                    Bobina.Items.Add(new string('*', 48));
                                    string DescricaoProduto = VendaDetalhe.Produto.DescricaoPdv.Length < 27 ? VendaDetalhe.Produto.DescricaoPdv : VendaDetalhe.Produto.DescricaoPdv.Substring(0, 27);
                                    Bobina.Items.Add(new string('0', 3 - Convert.ToString(ItemCupom).Length) + Convert.ToString(ItemCupom) + "  " + VendaDetalhe.Gtin + new string(' ', 14 - VendaDetalhe.Gtin.Length) + " " + DescricaoProduto);

                                    Bobina.Items.Add("ITEM CANCELADO");
                                    Bobina.Items.Add(new string('*', 48));

                                    SubTotal = SubTotal - VendaDetalhe.ValorTotal.Value;
                                    TotalGeral = TotalGeral - VendaDetalhe.ValorTotal.Value;

                                    //  cancela possíveis descontos ou acrescimos
                                    Bobina.SelectedIndex = Bobina.Items.Count - 1;
                                    AtualizaTotais();
                                }
                            }
                            Bobina.SelectedIndex = Bobina.Items.Count - 1;
                            EditCodigo.Focus();
                            Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scVendaEmAndamento;
                        }
                        else
                            MessageBox.Show("DAV sem itens.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("DAV inexistente ou ja efetivado/mesclado.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.write(ex.ToString());
                throw ex;
            }
        }

        #endregion Procedimentos referentes ao Menu Operacoes e seus SubMenus

        #region Procedimentos para controle da venda

        private static void InstanciaVendaAtual()
        {
            if (Sessao.Instance.VendaAtual == null)
                Sessao.Instance.VendaAtual = new EcfVendaCabecalhoDTO();
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
            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scSomenteConsulta)
            {
                InstanciaVendaAtual();
                IdentificaCliente FIdentificaCliente = new IdentificaCliente();
                FIdentificaCliente.ShowDialog();
                if (Sessao.Instance.VendaAtual.CpfCnpjCliente.Trim() != "")
                {
                    if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scAberto)
                    {
                        IniciaVenda();
                    }
                    DataModule.ACBrECF.IdentificaConsumidor(Sessao.Instance.VendaAtual.CpfCnpjCliente, Sessao.Instance.VendaAtual.NomeCliente, "");
                    LabelCliente.Text = "Cliente: " + Sessao.Instance.VendaAtual.NomeCliente + " - " + Sessao.Instance.VendaAtual.CpfCnpjCliente;
                }
            }
            else
            {
                ImportaCliente FImportaCliente = new ImportaCliente();
                ImportaCliente.QuemChamou = "CAIXA";
                FImportaCliente.ShowDialog();
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
                        EcfFuncionarioDTO Vendedor = EcfFuncionarioController.ConsultaFuncionario(Filtro);
                        if (Vendedor.Id != 0)
                        {
                            Sessao.Instance.VendaAtual.EcfFuncionario = new EcfFuncionarioDTO();
                            Sessao.Instance.VendaAtual.EcfFuncionario.Id = Vendedor.Id;
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
                if (!PAFUtil.ECFAutorizado())
                {
                    MessageBox.Show("ECF não autorizado - aplicação aberta apenas para consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                    LabelMensagens.Text = "Terminal em Estado Somente Consulta";
                    return;
                }
                else if (!PAFUtil.ConfereGT())
                {
                    MessageBox.Show("Grande total invalido - entre em contato com a Software House.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                    LabelMensagens.Text = "Terminal em Estado Somente Consulta";
                    return;
                }
                else
                {
                    try
                    {
                        DataModule.ACBrECF.TestaPodeAbrirCupom();
                    }
                    catch (Exception eError)
                    {
                        Log.write(eError.ToString());
                        TelaPadrao();
                        EditCodigo.Focus();
                        return;
                    }

                    //  instancia venda
                    InstanciaVendaAtual();

                    //  parametro para identificar o cliente na abertura do cupom (nota paulista)
                    if ((Sessao.Instance.Configuracao.PedeCpfCupom == "S") && (Sessao.Instance.VendaAtual.CpfCnpjCliente == ""))
                    {
                        IdentificaCliente();
                    }

                    ECFUtil.AbreCupom();

                    ImprimeCabecalhoBobina();
                    ParametrosIniciaisVenda();
                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scVendaEmAndamento;
                    LabelMensagens.Text = "Venda em andamento...";

                    Sessao.Instance.VendaAtual.EcfMovimento = Sessao.Instance.Movimento;
                    Sessao.Instance.VendaAtual.DataVenda = DataModule.ACBrECF.DataHora;
                    Sessao.Instance.VendaAtual.HoraVenda = DataModule.ACBrECF.DataHora.ToString("HH:mm:ss");
                    Sessao.Instance.VendaAtual.StatusVenda = "A";
                    Sessao.Instance.VendaAtual.Cfop = Sessao.Instance.Configuracao.CfopEcf.Value;
                    Sessao.Instance.VendaAtual.Coo = Convert.ToInt32(DataModule.ACBrECF.NumCOO);
                    Sessao.Instance.VendaAtual.Ccf = Convert.ToInt32(DataModule.ACBrECF.NumCCF);

                    Sessao.Instance.VendaAtual = VendaController.GravaEcfVendaCabecalho(Sessao.Instance.VendaAtual);
                    EditCodigo.Focus();
                    EditCodigo.SelectAll();

                    EdtNVenda.Text = "VENDA nº " + Convert.ToString(Sessao.Instance.VendaAtual.Id);
                    EdtCOO.Text = "CUPOM nº " + Convert.ToString(Sessao.Instance.VendaAtual.Coo);
                }
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
        }

        public static void ImprimeCabecalhoBobina()
        {
            try
            {
                Bobina.Items.Add(new string('-', 48));
                Bobina.Items.Add("               ** CUPOM FISCAL **               ");
                Bobina.Items.Add(new string('-', 48));
                Bobina.Items.Add("ITEM Codigo         Descricao                   ");
                Bobina.Items.Add("QTD.     UN      VL.UNIT.(R$) ST    VL.ITEM(R$)");
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
            string Estado;

            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scSomenteConsulta)
            {

                try
                {
                    Estado = DataModule.ACBrECF.Estado.ToString();
                    if ((Estado == "Requer Z") || (Estado == "Bloqueada"))
                    {
                        Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                        LabelMensagens.Text = "Terminal em Estado Somente Consulta";
                        if (Estado == "Requer Z")
                            MessageBox.Show("Impressora Requer Reducao Z!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Impressora Bloqueada Até o Final do Dia!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TelaPadrao();
                        EditCodigo.Focus();
                        return;
                    }
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                    LabelMensagens.Text = "Terminal em Estado Somente Consulta";
                    MessageBox.Show("Impressora Bloqueada ou Desligada  ou  Sem Papel  ou Fora de Linha!" + "\r" + "Caso a Impressora esteja ligada, com Papel e Em Linha" + "\r" + "Verifique se os cabos  estáo  devidamente  conectados.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TelaPadrao();
                    EditCodigo.Focus();
                    return;
                }

                try
                {
                    if (ECFUtil.ImpressoraOK())
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
                                VendaDetalhe = new EcfVendaDetalheDTO();
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

                                        VendeItem();

                                        Total = VendaDetalhe.ValorTotal.Value;
                                        EditTotalItem.Text = VendaDetalhe.ValorTotal.Value.ToString();

                                        SubTotal = SubTotal + VendaDetalhe.ValorTotal.Value;
                                        TotalGeral = TotalGeral + VendaDetalhe.ValorTotal.Value;
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
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }
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

            IdentificadorBalanca = Sessao.Instance.Configuracao.EcfConfiguracaoBalanca.Identificador;
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
                    if ((Quantidade <= 0) || (Quantidade > 999))
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
            if ((Quantidade <= 0) || (Quantidade > 999))
            {
                MessageBox.Show("Quantidade invalida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                editQuantidade.Text = "1";
            }
        }

        public static void VendeItem()
        {
            CompoeItemParaVenda();

            Filtro = "EcfIcmsSt = " + Biblioteca.QuotedStr(VendaDetalhe.EcfIcmsSt);
            EcfAliquotasDTO Aliquota = EcfAliquotasController.ConsultaEcfAliquotas(Filtro);

            if (Aliquota == null)
            {
                MessageBox.Show("Produto com ICMS não Definido!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EditUnitario.Text = "0";
                EditTotalItem.Text = "0";
                EditSubTotal.Text = "0";
                EditCodigo.Focus();
                EditCodigo.SelectAll();
                ItemCupom--;
                return;
            }

            if (VendaDetalhe.EcfIcmsSt == "")
            {
                MessageBox.Show("Produto com ICMS não Cadastrado na Impressora!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EditUnitario.Text = "0";
                EditTotalItem.Text = "0";
                EditSubTotal.Text = "0";
                EditCodigo.Focus();
                EditCodigo.SelectAll();
                ItemCupom--;
                return;
            }

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

            //  vende item
            ECFUtil.VendeItem(VendaDetalhe);

            // pega os dados para transparência de impostos
            Filtro = "Ncm = " + Biblioteca.QuotedStr(VendaDetalhe.Produto.Ncm);
            IbptDTO Ibpt = IbptController.ConsultaIbpt(Filtro);

            VendaDetalhe.Ccf = int.Parse(DataModule.ACBrECF.NumCCF);
            VendaDetalhe.Coo = int.Parse(DataModule.ACBrECF.NumCOO);
            // Pega o valor do item do ECF
            VendaDetalhe.ValorTotal = DataModule.ACBrECF.SubTotal - SubTotal;

            /// EXERCICIO: E se o item for importado?
            VendaDetalhe.ValorImpostoFederal = VendaDetalhe.ValorTotal * Ibpt.NacionalFederal / 100;
            VendaDetalhe.ValorImpostoEstadual = VendaDetalhe.ValorTotal * Ibpt.Estadual / 100;
            VendaDetalhe.ValorImpostoMunicipal = VendaDetalhe.ValorTotal * Ibpt.Municipal / 100;

            IbptFederal = IbptFederal + VendaDetalhe.ValorImpostoFederal.Value;
            IbptEstadual = IbptEstadual + VendaDetalhe.ValorImpostoEstadual.Value;
            IbptMunicipal = IbptMunicipal + VendaDetalhe.ValorImpostoMunicipal.Value;

            VendaDetalhe = VendaController.GravaEcfVendaDetalhe(VendaDetalhe);
            Sessao.Instance.VendaAtual.ListaEcfVendaDetalhe.Add(VendaDetalhe);
            ImprimeItemBobina();
            Bobina.SelectedIndex = Bobina.Items.Count - 1;
        }

        public static void CompoeItemParaVenda()
        {
            try
            {
                ItemCupom++;
                VendaDetalhe.Cfop = Sessao.Instance.Configuracao.CfopEcf.Value;
                VendaDetalhe.IdEcfVendaCabecalho = Sessao.Instance.VendaAtual.Id;
                VendaDetalhe.Cst = VendaDetalhe.Produto.Cst;
                VendaDetalhe.EcfIcmsSt = VendaDetalhe.Produto.EcfIcmsSt;
                VendaDetalhe.TaxaIcms = VendaDetalhe.Produto.TaxaIcms;
                VendaDetalhe.TotalizadorParcial = VendaDetalhe.Produto.TotalizadorParcial;

                if (VendaDetalhe.Produto.Gtin.Trim() == "")
                    VendaDetalhe.Gtin = VendaDetalhe.Produto.Id.ToString();
                else
                    VendaDetalhe.Gtin = VendaDetalhe.Produto.Gtin;

                VendaDetalhe.Item = ItemCupom;
                if (VendaDetalhe.Produto.Ippt == "T")
                    VendaDetalhe.MovimentaEstoque = "S";
                else
                    VendaDetalhe.MovimentaEstoque = "N";
                if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento)
                {
                    VendaDetalhe.Quantidade = Convert.ToDecimal(EditQuantidade.Text);
                    VendaDetalhe.ValorUnitario = Convert.ToDecimal(EditUnitario.Text);
                    VendaDetalhe.ValorTotal = Convert.ToDecimal(EditTotalItem.Text);
                    VendaDetalhe.TotalItem = Convert.ToDecimal(EditTotalItem.Text);
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
            Quantidade = VendaDetalhe.Quantidade.Value.ToString("###,##0.00");
            Unitario = VendaDetalhe.ValorUnitario.Value.ToString("###,##0.00");
            Total = VendaDetalhe.ValorTotal.Value.ToString("###,##0.00");
            string DescricaoProduto = VendaDetalhe.Produto.DescricaoPdv.Length < 27 ? VendaDetalhe.Produto.DescricaoPdv : VendaDetalhe.Produto.DescricaoPdv.Substring(0, 27);
            Bobina.Items.Add(new string('0', 3 - Convert.ToString(ItemCupom).Length) + Convert.ToString(ItemCupom) + "  " + VendaDetalhe.Gtin + new string(' ', 14 - VendaDetalhe.Gtin.Length) + " " + DescricaoProduto);

            Unidade = VendaDetalhe.Produto.UnidadeProduto.Sigla.Trim();

            Bobina.Items.Add(new string(' ', 8 - Quantidade.Length) + Quantidade + " " + new string(' ', 3 - Unidade.Length) + Unidade + " x " + new string(' ', 13 - Unitario.Length) + Unitario + " " + new string(' ', 5 - VendaDetalhe.EcfIcmsSt.Length) + VendaDetalhe.EcfIcmsSt + new string(' ', 14 - Total.Length) + Total);
        }

        public static void AtualizaTotais()
        {
            decimal DescontoAcrescimo;
            Sessao.Instance.VendaAtual.ValorVenda = SubTotal;
            Sessao.Instance.VendaAtual.Desconto = Desconto;
            Sessao.Instance.VendaAtual.Acrescimo = Acrescimo;

            Sessao.Instance.VendaAtual.ValorFinal = TotalGeral - Desconto + Acrescimo;
            DescontoAcrescimo = Acrescimo - Desconto;

            if (DescontoAcrescimo < 0)
            {
                LabelDescontoAcrescimo.Text = "Desconto: R$ " + (-DescontoAcrescimo).ToString("###,###,##0.00");
                LabelDescontoAcrescimo.ForeColor = Color.Red;
                Sessao.Instance.VendaAtual.Desconto = -DescontoAcrescimo;
                Sessao.Instance.VendaAtual.Acrescimo = 0;
            }
            else if (DescontoAcrescimo > 0)
            {
                LabelDescontoAcrescimo.Text = "Acrescimo: R$ " + DescontoAcrescimo.ToString("###,###,##0.00");
                LabelDescontoAcrescimo.ForeColor = Color.Blue;
                Sessao.Instance.VendaAtual.Desconto = 0;
                Sessao.Instance.VendaAtual.Acrescimo = DescontoAcrescimo;
            }
            else
            {
                LabelDescontoAcrescimo.Text = "";
                Sessao.Instance.VendaAtual.TaxaAcrescimo = 0;
                Sessao.Instance.VendaAtual.TaxaDesconto = 0;
                Acrescimo = 0;
                Desconto = 0;
            }

            if (((Sessao.Instance.VendaAtual.ValorFinal < Sessao.Instance.VendaAtual.ValorVenda) && (Sessao.Instance.VendaAtual.TaxaDesconto != 0) && (Desconto != ((1 - (Sessao.Instance.VendaAtual.ValorFinal / Sessao.Instance.VendaAtual.ValorVenda)) * 100))))
            {
                Sessao.Instance.VendaAtual.TaxaDesconto = (1 - (Sessao.Instance.VendaAtual.ValorFinal / Sessao.Instance.VendaAtual.ValorVenda)) * 100;
                Sessao.Instance.VendaAtual.TaxaAcrescimo = 0;
            }

            if (((Sessao.Instance.VendaAtual.ValorFinal > Sessao.Instance.VendaAtual.ValorVenda) && (Sessao.Instance.VendaAtual.TaxaAcrescimo != 0) && (Acrescimo != ((Sessao.Instance.VendaAtual.ValorFinal / Sessao.Instance.VendaAtual.ValorVenda) * 100) - 100)))
            {
                Sessao.Instance.VendaAtual.TaxaAcrescimo = ((Sessao.Instance.VendaAtual.ValorFinal / Sessao.Instance.VendaAtual.ValorVenda) * 100) - 100;
                Sessao.Instance.VendaAtual.TaxaDesconto = 0;
            }

            EditSubTotal.Text = Sessao.Instance.VendaAtual.ValorVenda.Value.ToString("###,###,##0.00");
            LabelTotalGeral.Text = Sessao.Instance.VendaAtual.ValorFinal.Value.ToString("###,###,##0.00");
        }

        public void IniciaEncerramentoVenda()
        {
            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scSomenteConsulta)
            {
                if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento)
                {
                    if (Sessao.Instance.VendaAtual.ListaEcfVendaDetalhe.Count > 0)
                    {
                        Sessao.Instance.VendaAtual.CupomCancelado = "N";
                        if (Sessao.Instance.VendaAtual.ValorFinal <= 0)
                        {
                            if (MessageBox.Show("Todos os itens foram cancelados." + "\r" + "\r" + "Deseja cancelar o cupom?", "Cancelar o cupom", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                CancelaCupom();
                            return;
                        }

                        EfetuaPagamento FEfetuaPagamento = new EfetuaPagamento();
                        FEfetuaPagamento.ShowDialog();
                        EdtNVenda.Text = "";
                        EdtCOO.Text = "";
                    }
                    else
                        MessageBox.Show("A venda não contem itens.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Não existe venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Terminal em Estado Somente Consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ConcluiEncerramentoVenda()
        {
            try
            {
                if (Sessao.Instance.VendaAtual.IdEcfPreVendaCabecalho != null)
                {
                    using (ServiceServidor Servico = new ServiceServidor())
                    {
                        PreVenda.Ccf = Sessao.Instance.VendaAtual.Ccf;
                        PreVenda.Situacao = "E";
                        Servico.SalvarAtualizarPreVendaCabecalho(PreVenda);
                    }
                }

                if (Sessao.Instance.VendaAtual.IdEcfDav != null)
                {
                    using (ServiceServidor Servico = new ServiceServidor())
                    {
                        DavCabecalho.NumeroEcf = DataModule.ACBrECF.NumECF;
                        DavCabecalho.Ccf = Sessao.Instance.VendaAtual.Ccf;
                        DavCabecalho.Coo = Sessao.Instance.VendaAtual.Coo;
                        DavCabecalho.Situacao = "E";
                        Servico.SalvarAtualizarDavCabecalho(DavCabecalho);
                    }
                }

                VendaController.GravaEcfVendaCabecalho(Sessao.Instance.VendaAtual);

                CargaPDV FCargaPDV = new CargaPDV();
                CargaPDV.Procedimento = "EXPORTA_VENDA";
                FCargaPDV.ShowDialog();
            }
            finally
            {
                PAFUtil.GravarIdUltimaVenda();
                TelaPadrao();
            }
        }

        public void CancelaCupom()
        {
            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scSomenteConsulta)
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
                                if ((Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento) || (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaRecuperadaDavPreVenda))
                                {
                                    if (MessageBox.Show("Deseja cancelar o cupom atual?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        ECFUtil.CancelaCupom();
                                        Sessao.Instance.VendaAtual.Ccf = int.Parse(DataModule.ACBrECF.NumCCF);
                                        Sessao.Instance.VendaAtual.Coo = int.Parse(DataModule.ACBrECF.NumCOO);
                                        Sessao.Instance.VendaAtual.ValorCancelado = Sessao.Instance.VendaAtual.ValorVenda.Value;
                                        Sessao.Instance.VendaAtual.StatusVenda = "C";
                                        Sessao.Instance.VendaAtual.CupomCancelado = "S";
                                        Sessao.Instance.VendaAtual.ValorFinal = 0;

                                        VendaController.CancelaVenda(Sessao.Instance.VendaAtual);

                                        CargaPDV FCargaPDV = new CargaPDV();
                                        CargaPDV.Procedimento = "EXPORTA_VENDA";
                                        FCargaPDV.ShowDialog();

                                        Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
                                        TelaPadrao();
                                    }
                                }
                                else if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scAberto)
                                {
                                    if (MessageBox.Show("Deseja cancelar o cupom anterior?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        ECFUtil.CancelaCupom();
                                        Filtro = "Id = " + PAFUtil.RecuperarIdUltimaVenda();
                                        Sessao.Instance.VendaAtual = VendaController.ConsultaEcfVendaCabecalho(Filtro);

                                        Sessao.Instance.VendaAtual.ValorCancelado = Sessao.Instance.VendaAtual.ValorVenda.Value;
                                        Sessao.Instance.VendaAtual.StatusVenda = "C";
                                        Sessao.Instance.VendaAtual.CupomCancelado = "S";
                                        Sessao.Instance.VendaAtual.ValorFinal = 0;

                                        VendaController.CancelaVenda(Sessao.Instance.VendaAtual);

                                        CargaPDV FCargaPDV = new CargaPDV();
                                        CargaPDV.Procedimento = "EXPORTA_VENDA";
                                        FCargaPDV.ShowDialog();

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
            else
                MessageBox.Show("Terminal em Estado Somente Consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CancelaItem()
        {
            int cancela;
            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scSomenteConsulta)
            {
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
                                        if (cancela <= Sessao.Instance.VendaAtual.ListaEcfVendaDetalhe.Count)
                                        {
                                            VendaDetalhe = Sessao.Instance.VendaAtual.ListaEcfVendaDetalhe[cancela - 1];

                                            if (VendaDetalhe.Cancelado != "S")
                                            {
                                                ECFUtil.CancelaItem(cancela);

                                                VendaDetalhe.TotalizadorParcial = "Can-T";
                                                VendaDetalhe.Cancelado = "S";
                                                VendaDetalhe.Ccf = int.Parse(DataModule.ACBrECF.NumCCF);
                                                VendaDetalhe.Coo = int.Parse(DataModule.ACBrECF.NumCOO);

                                                VendaController.CancelaItemVenda(VendaDetalhe);

                                                Bobina.Items.Add(new string('*', 48));
                                                string DescricaoProduto = VendaDetalhe.Produto.DescricaoPdv.Length < 27 ? VendaDetalhe.Produto.DescricaoPdv : VendaDetalhe.Produto.DescricaoPdv.Substring(0, 27);
                                                Bobina.Items.Add(new string('0', 3 - Convert.ToString(cancela).Length) + Convert.ToString(cancela) + "  " + VendaDetalhe.Gtin + new string(' ', 14 - VendaDetalhe.Gtin.Length) + " " + DescricaoProduto);

                                                Bobina.Items.Add("ITEM CANCELADO");
                                                Bobina.Items.Add(new string('*', 48));

                                                SubTotal = SubTotal - VendaDetalhe.ValorTotal.Value;
                                                TotalGeral = TotalGeral - VendaDetalhe.ValorTotal.Value;

                                                //  cancela possíveis descontos ou acrescimos
                                                Desconto = 0;
                                                Acrescimo = 0;
                                                Sessao.Instance.VendaAtual.TaxaAcrescimo = 0;
                                                Sessao.Instance.VendaAtual.TaxaDesconto = 0;
                                                Bobina.SelectedIndex = Bobina.Items.Count - 1;
                                                AtualizaTotais();
                                            }
                                            else
                                                MessageBox.Show("O item solicitado Ja foi cancelado.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
                MessageBox.Show("Terminal em Estado Somente Consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CancelaItem(int cancela)
        {
            try
            {
                if (cancela > 0)
                {
                    if (cancela <= Sessao.Instance.VendaAtual.ListaEcfVendaDetalhe.Count)
                    {
                        VendaDetalhe = Sessao.Instance.VendaAtual.ListaEcfVendaDetalhe[cancela - 1];

                        if (VendaDetalhe.Cancelado != "S")
                        {
                            ECFUtil.CancelaItem(cancela);

                            VendaDetalhe.TotalizadorParcial = "Can-T";
                            VendaDetalhe.Cancelado = "S";
                            VendaDetalhe.Ccf = int.Parse(DataModule.ACBrECF.NumCCF);
                            VendaDetalhe.Coo = int.Parse(DataModule.ACBrECF.NumCOO);

                            VendaController.CancelaItemVenda(VendaDetalhe);

                            Bobina.Items.Add(new string('*', 48));
                            string DescricaoProduto = VendaDetalhe.Produto.DescricaoPdv.Length < 27 ? VendaDetalhe.Produto.DescricaoPdv : VendaDetalhe.Produto.DescricaoPdv.Substring(0, 27);
                            Bobina.Items.Add(new string('0', 3 - Convert.ToString(cancela).Length) + Convert.ToString(cancela) + "  " + VendaDetalhe.Gtin + new string(' ', 14 - VendaDetalhe.Gtin.Length) + " " + DescricaoProduto);

                            Bobina.Items.Add("ITEM CANCELADO");
                            Bobina.Items.Add(new string('*', 48));

                            SubTotal = SubTotal - VendaDetalhe.ValorTotal.Value;
                            TotalGeral = TotalGeral - VendaDetalhe.ValorTotal.Value;

                            //  cancela possíveis descontos ou acrescimos
                            Desconto = 0;
                            Acrescimo = 0;
                            Sessao.Instance.VendaAtual.TaxaAcrescimo = 0;
                            Sessao.Instance.VendaAtual.TaxaDesconto = 0;

                            AtualizaTotais();
                        }
                        else
                            MessageBox.Show("O item solicitado Ja foi cancelado.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("O item solicitado não existe na venda atual.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
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

        public void EntradaDadosNF()
        {
            Tipos.StatusCaixa GuardaStatus;
            if (Sessao.Instance.Configuracao.PermiteLancarNfManual == "N")
            {
                MessageBox.Show("Lancamento de notas manuais não disponivel.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Sessao.Instance.StatusCaixa != Tipos.StatusCaixa.scVendaEmAndamento)
            {
                try
                {
                    GuardaStatus = Sessao.Instance.StatusCaixa;
                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scInformandoDadosNF;
                    NotaFiscal FNotaFiscal = new NotaFiscal();
                    FNotaFiscal.ShowDialog();
                    Sessao.Instance.StatusCaixa = GuardaStatus;
                }
                catch (Exception eError)
                {
                    Log.write(eError.ToString());
                }
            }
            else
                MessageBox.Show("Existe uma venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Procedimentos para controle da venda

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
            AcionaMenuFiscal();
        }

        private void botaoF5_Click(object sender, EventArgs e)
        {
            EntradaDadosNF();
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
            CancelaCupom();
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
            try
            {
                //  se houver conexão aberta, Fecha a conexão
                if (DataModule.ACBrBAL.Ativo)
                    DataModule.ACBrBAL.Desativar();

                //  configura porta de comunicacao
                DataModule.ACBrBAL.Modelo = (ACBrFramework.BAL.ModeloBal)Sessao.Instance.Configuracao.EcfConfiguracaoBalanca.Modelo;
                DataModule.ACBrBAL.Device.HandShake = (ACBrFramework.SerialHandShake)Sessao.Instance.Configuracao.EcfConfiguracaoBalanca.HandShake;
                DataModule.ACBrBAL.Device.Parity = (ACBrFramework.SerialParity)Sessao.Instance.Configuracao.EcfConfiguracaoBalanca.Parity;
                DataModule.ACBrBAL.Device.StopBits = (ACBrFramework.SerialStopBits)Sessao.Instance.Configuracao.EcfConfiguracaoBalanca.StopBits;
                DataModule.ACBrBAL.Device.DataBits = Sessao.Instance.Configuracao.EcfConfiguracaoBalanca.DataBits.Value;
                DataModule.ACBrBAL.Device.Baud = Sessao.Instance.Configuracao.EcfConfiguracaoBalanca.BaudRate.Value;
                DataModule.ACBrBAL.Device.Porta = Sessao.Instance.Configuracao.EcfConfiguracaoBalanca.Porta;
                //  Conecta com a balança
                DataModule.ACBrBAL.Ativar();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        public void ACBrBAL1LePeso(decimal Peso, string Resposta)
        {
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
                valid = Convert.ToInt32(DataModule.ACBrBAL.UltimoPesoLido); switch (valid)
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
        }

        #endregion Procedimentos para ler peso direto das balanças componente ACBrBal

      
    }

}
