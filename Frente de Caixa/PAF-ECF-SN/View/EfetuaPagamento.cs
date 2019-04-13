/********************************************************************************
Title: T2TiPDV
Description: Janela para selecionar as formas de pagamento e finalizar a venda

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
********************************************************************************/

/********************************************************************************
  Operacoes TEF Discado:

	ATV		Verifica se o Gerenciador Padr?o está atiDTO
	ADM		Permite o acionamento da Solu??o TEF Discado para execu??o das fun??es administrativas
	CHQ		Pedido de autorizacao para transacao por meio de cheque
	CRT		Pedido de autorizacao para transacao por meio de cartao
	CNC		Cancelamento de venda efetuada por qualquer meio de pagamento
	CNF		Confirmacao da venda e impressão de cupom
	NCN		não confirmacao da venda e/ou da impressão.
********************************************************************************/



using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PafEcf.Controller;
using PafEcf.Util;
using PafEcf.DTO;
using System.Data;

using System.Threading;
using ACBrFramework.ECF;
using ACBrFramework.TEFD;

namespace PafEcf.View
{

    public partial class EfetuaPagamento : Form
    {

        public static List<EcfTotalTipoPagamentoDTO> ListaTotalTipoPagamento;
        private static decimal SaldoRestante, TotalVenda, Desconto, Acrescimo, TotalReceber, TotalRecebido, Troco;
        private static bool TransacaoComTef, ImpressaoOK, CupomCancelado, PodeFechar, StatusTransacao, SegundoCartaoCancelado;
        private static int IndiceTransacaoTef, QuantidadeCartao;
        public static DataTable DTValores;
        public static ACBrFramework.TEFD.ACBrTEFD ACBrTEFD;

        public EfetuaPagamento()
        {
            InitializeComponent();
            //
            ACBrTEFD = this.acBrTEFD;
        }

        private void FEfetuaPagamento_Shown(object sender, EventArgs e)
        {
            TotalVenda = 0;
            Desconto = 0;
            Acrescimo = 0;
            TotalReceber = 0;
            TotalRecebido = 0;
            Troco = 0;
            QuantidadeCartao = 0;

            if (Sessao.Instance.VendaAtual.TaxaAcrescimo > 0)
                Sessao.Instance.VendaAtual.Acrescimo = Biblioteca.TruncaValor(Sessao.Instance.VendaAtual.TaxaAcrescimo / 100 * Sessao.Instance.VendaAtual.ValorVenda, Constantes.DECIMAIS_VALOR);
            if (Sessao.Instance.VendaAtual.TaxaDesconto > 0)
                Sessao.Instance.VendaAtual.Desconto = Biblioteca.TruncaValor(Sessao.Instance.VendaAtual.TaxaDesconto / 100 * Sessao.Instance.VendaAtual.ValorVenda, Constantes.DECIMAIS_VALOR);

            // preenche valores nas variaveis
            TotalVenda = Sessao.Instance.VendaAtual.ValorVenda.Value;
            Acrescimo = Sessao.Instance.VendaAtual.Acrescimo.Value;
            Desconto = Sessao.Instance.VendaAtual.Desconto.Value;
            TotalReceber = Biblioteca.TruncaValor(TotalVenda + Acrescimo - Desconto, Constantes.DECIMAIS_VALOR);
            SaldoRestante = TotalReceber;

            SegundoCartaoCancelado = false;
            TransacaoComTef = false;
            CupomCancelado = false;
            PodeFechar = true;
            IndiceTransacaoTef = -1;

            AtualizaLabelsValores();

            if (SaldoRestante > 0)
                editValorPago.Text = SaldoRestante.ToString("0.00");
            else
                editValorPago.Text = "0.00";

            // lista que vai acumular os meios de pagamento
            ListaTotalTipoPagamento = new List<EcfTotalTipoPagamentoDTO>();

            // tela padrão
            TelaPadrao();
        }

        public void AtualizaLabelsValores()
        {
            labelTotalVenda.Text = TotalVenda.ToString("###,###,##0.00");
            labelAcrescimo.Text = Acrescimo.ToString("###,###,##0.00");
            labelDesconto.Text = Desconto.ToString("###,###,##0.00");
            labelTotalReceber.Text = TotalReceber.ToString("###,###,##0.00");
            labelTotalRecebido.Text = TotalRecebido.ToString("###,###,##0.00");
            if (SaldoRestante > 0)
                labelAindaFalta.Text = SaldoRestante.ToString("###,###,##0.00");
            else
                labelAindaFalta.Text = "0.00";
            labelTroco.Text = Troco.ToString("###,###,##0.00");
        }

        private void FEfetuaPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((PodeFechar) && (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scVendaEmAndamento))
            {
                e.Cancel = false;
                return;
            }
            if ((PodeFechar) && (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scAberto))
            {
                FechaEfetuaPagamento FFechaEfetuaPagamento = new FechaEfetuaPagamento(this);
                FFechaEfetuaPagamento.SetBounds(this.Left + 8, this.Top + this.Height - 55, 663, 47);
                FFechaEfetuaPagamento.ShowDialog();
                return;
            }
            e.Cancel = PodeFechar;
        }

        private void TelaPadrao()
        {
            for (int i = 0; i <= Sessao.Instance.ListaTipoPagamento.Count - 1; i++)
                ComboTipoPagamento.Items.Add(Sessao.Instance.ListaTipoPagamento[i].Descricao);
            ComboTipoPagamento.SelectedIndex = 0;

            // Configura Grid
            DTValores = new DataTable("VALORES");
            DTValores.Columns.Add("DESCRICAO", typeof(string)); //0
            DTValores.Columns.Add("VALOR", typeof(decimal)); //1
            DTValores.Columns.Add("ID", typeof(int)); //2
            //os campos abaixo serão utilizados caso seja necessario cancelar uma transacao TEF
            DTValores.Columns.Add("TEF", typeof(string)); //3
            DTValores.Columns.Add("NSU", typeof(string)); //4
            DTValores.Columns.Add("REDE", typeof(string)); //5
            DTValores.Columns.Add("DATA_HORA_TRANSACAO", typeof(string)); //6
            DTValores.Columns.Add("INDICE_TRANSACAO", typeof(int)); //7
            DTValores.Columns.Add("INDICE_LISTA", typeof(int)); //8
            DTValores.Columns.Add("FINALIZACAO", typeof(string)); //9

            dataSet.Tables.Add(DTValores);

            GridValores.DataSource = dataSet;
            GridValores.DataMember = dataSet.Tables[0].ToString();

            //definimos os cabeçalhos da Grid
            GridValores.Columns[0].HeaderText = "Descrição";
            GridValores.Columns[0].ReadOnly = true;
            GridValores.Columns[1].HeaderText = "Valor";
            GridValores.Columns[1].ReadOnly = true;
            GridValores.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //nao exibe as colunas abaixo
            GridValores.Columns[2].Visible = false;
            GridValores.Columns[3].Visible = false;
            GridValores.Columns[4].Visible = false;
            GridValores.Columns[5].Visible = false;
            GridValores.Columns[6].Visible = false;
            GridValores.Columns[7].Visible = false;
            GridValores.Columns[8].Visible = false;
            GridValores.Columns[9].Visible = false;

            ComboTipoPagamento.Focus();
        }

        private void FEfetuaPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (GridValores.RowCount == 0)
                {
                    if (MessageBox.Show("Confirma valores e encerra venda por fechamento rapido?", "Finalizar venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FechamentoRapido();
                    }
                }
                else
                {
                    MessageBox.Show("Ja existem valores informados. Impossivel utilizar Fechamento Rapido.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ComboTipoPagamento.Focus();
                }
            }

            if (e.KeyCode == Keys.F12)
                botaoConfirma.PerformClick();

            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();

            if (e.KeyCode == Keys.F5)
            {
                if (GridValores.RowCount > 0)
                    GridValores.Focus();
                else
                {
                    MessageBox.Show("Não existem valores informados para serem removidos.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ComboTipoPagamento.Focus();
                }
            }

        }

        public void FechamentoRapido()
        {
            StatusTransacao = true;
            botaoSim.PerformClick();
        }

        // controle das teclas digitadas na Grid
        public void GridValoresKeyDown(object sender, KeyEventArgs e)
        {
            DataRow Registro = DTValores.Rows[GridValores.CurrentRow.Index];
            if (e.KeyCode == Keys.Delete)
            {
                if (Registro["TEF"].ToString() == "S")
                    MessageBox.Show("Operacao não permitida.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (MessageBox.Show("Deseja remover o valor selecionado?", "Remover ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TotalRecebido = Biblioteca.TruncaValor(TotalRecebido - Convert.ToDecimal(DTValores.Columns["VALOR"].ToString()), Constantes.DECIMAIS_VALOR);
                        Troco = Biblioteca.TruncaValor(TotalRecebido - TotalReceber, Constantes.DECIMAIS_VALOR);
                        if (Troco < 0)
                            Troco = 0;

                        ListaTotalTipoPagamento.RemoveAt(Convert.ToInt32(Registro["INDICE_LISTA"]));

                        DTValores.Rows.RemoveAt(GridValores.CurrentRow.Index);
                        VerificaSaldoRestante();
                        if (SaldoRestante > 0)
                            editValorPago.Text = SaldoRestante.ToString("###,###,##0.00");
                        else
                            editValorPago.Text = "0.00";
                    }
                    ComboTipoPagamento.Focus();
                }
            }
            if (e.KeyCode == Keys.Enter)
                ComboTipoPagamento.Focus();
        }

        private void BotaoCancela_Click(object sender, EventArgs e)
        {
            CancelaOperacao();
        }

        private void botaoConfirma_Click(object sender, EventArgs e)
        {
            VerificaSaldoRestante();
            // se não houver mais saldo no ECF é porque Ja devemos finalizar a venda
            if (SaldoRestante <= 0)
            {
                if (MessageBox.Show("Deseja finalizar a venda?", "Finalizar venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FinalizaVenda();
                }
                else
                {
                    if (TransacaoComTef)
                    {
                        ACBrTEFD.CancelarTransacoesPendentes();
                        Sessao.Instance.VendaAtual.CupomCancelado = "S";
                        Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
                        FechaVendaComProblemas();
                        PodeFechar = true;
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Valores informados não são suficientes para finalizar a venda.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ComboTipoPagamento.Focus();
            }
        }

        private void editValorPago_Leave(object sender, EventArgs e)
        {
            decimal ValorInformado;
            if (decimal.TryParse(editValorPago.Text, out ValorInformado))
            {

                if (ValorInformado > 0)
                {
                    VerificaSaldoRestante();
                    // se ainda tem saldo no ECF para pagamento
                    if (SaldoRestante > 0)
                    {
                        PanelConfirmaValores.Visible = true;
                        PanelConfirmaValores.BringToFront();
                        LabelConfirmaValores.Text = "Confirma forma de pagamento e valor?";
                        botaoSim.Focus();
                    }
                    else
                        MessageBox.Show("Todos os valores Ja foram recebidos. Finalize a venda.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Valor não pode ser menor ou igual a zero.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    editValorPago.Clear();
                    ComboTipoPagamento.Focus();
                }
            }
            else
            {
                MessageBox.Show("Valor inválido.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void VerificaSaldoRestante()
        {
            decimal RecebidoAteAgora = 0;

            foreach (DataRow Registro in DTValores.Rows)
            {
                RecebidoAteAgora = Biblioteca.TruncaValor(RecebidoAteAgora + Convert.ToDecimal(Registro["VALOR"]), Constantes.DECIMAIS_VALOR);
            }
            SaldoRestante = Biblioteca.TruncaValor(TotalReceber - RecebidoAteAgora, Constantes.DECIMAIS_VALOR);
            AtualizaLabelsValores();
        }

        private void botaoNao_Click(object sender, EventArgs e)
        {
            PanelConfirmaValores.Visible = false;
            ComboTipoPagamento.Focus();
        }

        private void botaoSim_Click(object sender, EventArgs e)
        {
            decimal ValorInformado;
            string Mensagem;
            EcfTipoPagamentoDTO TipoPagamento = Sessao.Instance.ListaTipoPagamento[ComboTipoPagamento.SelectedIndex];
            ValorInformado = Biblioteca.TruncaValor(Convert.ToDecimal(editValorPago.Text), Constantes.DECIMAIS_VALOR);

            if (((TipoPagamento.Descricao == "CONSULTA CHEQUE") || (TipoPagamento.Descricao == "CONSULTA CHQ TECBAN")) && (TransacaoComTef))
            {
                MessageBox.Show("Compra com Cartao e Cheque não permitida.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ComboTipoPagamento.Focus();
                PanelConfirmaValores.Visible = false;
                PanelConfirmaValores.SendToBack();
            }
            else
            {
                EcfTotalTipoPagamentoDTO TotalTipoPagamento = new EcfTotalTipoPagamentoDTO();

                if (((TransacaoComTef) || (TipoPagamento.Tef == "S")) && (ValorInformado > SaldoRestante))
                {
                    MessageBox.Show("Compra não permite troco.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ComboTipoPagamento.Focus();
                    PanelConfirmaValores.Visible = false;
                    PanelConfirmaValores.SendToBack();
                }
                else if ((TipoPagamento.Tef == "S") && (QuantidadeCartao >= Sessao.Instance.Configuracao.QuantidadeMaximaCartoes))
                {
                    MessageBox.Show("Ja foi utilizada a quantidade maxima de cartoes para efetuar pagamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ComboTipoPagamento.Focus();
                    PanelConfirmaValores.Visible = false;
                    PanelConfirmaValores.SendToBack();
                }
                else if ((TipoPagamento.Tef == "S") && (QuantidadeCartao >= Sessao.Instance.Configuracao.QuantidadeMaximaCartoes - 1) && (ValorInformado != SaldoRestante))
                {
                    Mensagem = "Multiplos Cartoes. Transacao suporta ate " + Convert.ToString(Sessao.Instance.Configuracao.QuantidadeMaximaCartoes) + " cartoes. Informe o valor exato para fechar a venda.";
                    MessageBox.Show(Mensagem, "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ComboTipoPagamento.Focus();
                    PanelConfirmaValores.Visible = false;
                    PanelConfirmaValores.SendToBack();
                }
                else
                {
                    GroupBox3.Enabled = false;
                    StatusTransacao = true;
                    if (TipoPagamento.Tef == "S")
                    {
                        try
                        {
                            try
                            {
                                ACBrTEFD.Initializar((ACBrFramework.TEFD.TefTipo)int.Parse(TipoPagamento.TefTipoGp));
                            }
                            catch (Exception eError)
                            {
                                Log.write(eError.ToString());
                                MessageBox.Show("GP para tipo de pagamento solicitado não instalado.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                StatusTransacao = false;
                            }
                            if ((TipoPagamento.Descricao == "CONSULTA CHEQUE") || (TipoPagamento.Descricao == "CONSULTA CHQ TECBAN"))
                                StatusTransacao = ACBrTEFD.CHQ(ValorInformado, TipoPagamento.Codigo);
                            else
                                StatusTransacao = ACBrTEFD.CRT(ValorInformado, TipoPagamento.Codigo, DataModule.ACBrECF.NumCOO);

                            if (StatusTransacao)
                            {
                                IndiceTransacaoTef++;

                                TotalTipoPagamento.Nsu = ACBrTEFD.RespostasPendentes[IndiceTransacaoTef].NSU;
                                TotalTipoPagamento.Rede = ACBrTEFD.RespostasPendentes[IndiceTransacaoTef].Rede;

                                if ((ACBrTEFD.RespostasPendentes[IndiceTransacaoTef].TipoTransacao >= 10) && (ACBrTEFD.RespostasPendentes[IndiceTransacaoTef].TipoTransacao <= 12))
                                    TotalTipoPagamento.CartaoDc = "C";
                                if ((ACBrTEFD.RespostasPendentes[IndiceTransacaoTef].TipoTransacao >= 20) && (ACBrTEFD.RespostasPendentes[IndiceTransacaoTef].TipoTransacao <= 25))
                                    TotalTipoPagamento.CartaoDc = "D";

                                QuantidadeCartao++;
                                TransacaoComTef = true;
                                PodeFechar = false;
                            }
                        }
                        catch (Exception eError)
                        {
                            Log.write(eError.ToString());
                        }
                    }

                    if (StatusTransacao)
                    {
                        DataRow Registro = DTValores.NewRow();
                        Registro["DESCRICAO"] = ComboTipoPagamento.Text;
                        decimal valor = Convert.ToDecimal(editValorPago.Text);
                        Registro["VALOR"] = Convert.ToDecimal(valor.ToString("0.00"));
                        if (TipoPagamento.Tef == "S")
                        {
                            Registro["TEF"] = "S";
                            Registro["NSU"] = TotalTipoPagamento.Nsu;
                            Registro["REDE"] = TotalTipoPagamento.Rede;
                            Registro["INDICE_TRANSACAO"] = IndiceTransacaoTef;
                        }

                        TotalRecebido = Biblioteca.TruncaValor(TotalRecebido + Convert.ToDecimal(editValorPago.Text), Constantes.DECIMAIS_VALOR);
                        Troco = Biblioteca.TruncaValor(TotalRecebido - TotalReceber, Constantes.DECIMAIS_VALOR);
                        if (Troco < 0)
                            Troco = 0;

                        VerificaSaldoRestante();

                        TotalTipoPagamento.IdEcfVendaCabecalho = Sessao.Instance.VendaAtual.Id;
                        TotalTipoPagamento.Valor = Biblioteca.TruncaValor(Convert.ToDecimal(editValorPago.Text), Constantes.DECIMAIS_VALOR);
                        TotalTipoPagamento.Estorno = "N";
                        TotalTipoPagamento.SerieEcf = Sessao.Instance.Configuracao.EcfImpressora.Serie;
                        TotalTipoPagamento.Coo = int.Parse(DataModule.ACBrECF.NumCOO);
                        TotalTipoPagamento.Ccf = int.Parse(DataModule.ACBrECF.NumCCF);
                        TotalTipoPagamento.Gnf = int.Parse(DataModule.ACBrECF.NumGNF);

                        TotalTipoPagamento.EcfTipoPagamento = TipoPagamento;

                        ListaTotalTipoPagamento.Add(TotalTipoPagamento);

                        // guarda o índice da lista
                        Registro["INDICE_LISTA"] = ListaTotalTipoPagamento.Count - 1;
                        DTValores.Rows.Add(Registro);
                    }
                    PanelConfirmaValores.Visible = false;
                    PanelConfirmaValores.SendToBack();
                    if (SaldoRestante > 0)
                        editValorPago.Text = SaldoRestante.ToString("0.00");
                    else
                        editValorPago.Text = "0.00";

                    GroupBox3.Enabled = true;
                    ComboTipoPagamento.Focus();
                }

                VerificaSaldoRestante();
                if (SaldoRestante <= 0)
                    FinalizaVenda();

                if (SegundoCartaoCancelado)
                {
                    MessageBox.Show("Cupom fiscal cancelado. será aberto noDTO cupom e deve-se informar novamente os pagamentos.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sessao.Instance.VendaAtual.CupomCancelado = "S";
                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
                    FechaVendaComProblemas();
                    PodeFechar = true;
                    this.Close();
                }
            }
        }

        public void FinalizaVenda()
        {
            ImpressaoOK = true;

            // subtotaliza o cupom
            SubTotalizaCupom();

            // manda os pagamentos para o ECF
            if (TransacaoComTef)
                OrdenaLista();

            for (int i = 0; i <= ListaTotalTipoPagamento.Count - 1; i++)
            {
                if (ListaTotalTipoPagamento[i].EcfTipoPagamento.Tef != "S")
                    DataModule.ACBrECF.EfetuaPagamento(ListaTotalTipoPagamento[i].EcfTipoPagamento.Codigo, ListaTotalTipoPagamento[i].Valor.Value);
            }

            // Descomente para bloquear teclado e mouse
            //BlockInput.Bloquear(true);

            // finaliza o cupom
            ACBrTEFD.FinalizarCupom();

            // imprime as transacoes pendentes - comprovantes nao fiscais vinculados
            ACBrTEFD.ImprimirTransacoesPendentes();

            // Descomente para bloquear teclado e mouse
            //BlockInput.Bloquear(false);

            if (ImpressaoOK)
            {
                // grava os pagamentos no banco de dados
                EcfTotalTipoPagamentoController.GravaEcfTotalTipoPagamentoLista(ListaTotalTipoPagamento);

                // conclui o encerramento da venda - grava dados de cabecalho no banco
                Sessao.Instance.VendaAtual.ValorFinal = TotalReceber;
                Sessao.Instance.VendaAtual.ValorRecebido = TotalRecebido;
                Sessao.Instance.VendaAtual.Troco = Troco;
                Sessao.Instance.VendaAtual.StatusVenda = "F";
                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
                Caixa.ConcluiEncerramentoVenda();

                //  usado quando a gaveta tem sinal invertido
                if (Sessao.Instance.Configuracao.GavetaSinalInvertido == "S")
                    DataModule.ACBrECF.GavetaSinalInvertido = true;

                if (Sessao.Instance.Configuracao.GavetaUtilizacao > 0)
                    DataModule.ACBrECF.AbreGaveta();

                PodeFechar = true;
                this.Close();
            }
            else
            {
                if (CupomCancelado)
                //ocorreu problema na impressao do comprovante do TEF. ECF Desligado.
                //Sistema pergunta ao usuário se o mesmo quer tentar novamente. Usuário responde não.
                //ECF agora está ligado e o sistema consegue cancelar o cupom.
                {
                    MessageBox.Show("Problemas no ECF. Cupom Fiscal Cancelado.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sessao.Instance.VendaAtual.CupomCancelado = "S";
                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
                    FechaVendaComProblemas();
                    PodeFechar = true;
                    this.Close();
                }
                else
                //ocorreu problema na impressao do comprovante do TEF. ECF Desligado.
                //Sistema pergunta ao usuário se o mesmo quer tentar novamente. Usuário responde não.
                //ECF continua desligado e o sistema não consegue cancelar o cupom.
                {
                    MessageBox.Show("Problemas no ECF. Aplicação funcionará apenas para consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                    FechaVendaComProblemas();
                    PodeFechar = true;
                    this.Close();
                }
            }

        }

        public void FechaVendaComProblemas()
        {
            // altera o status da venda para C
            Sessao.Instance.VendaAtual.StatusVenda = "C";
            Caixa.ConcluiEncerramentoVenda();

            // grava os pagamentos no banco de dados com o indicador de estorno
            for (int i = 0; i <= ListaTotalTipoPagamento.Count - 1; i++)
                ListaTotalTipoPagamento[i].Estorno = "S";
            EcfTotalTipoPagamentoController.GravaEcfTotalTipoPagamentoLista(ListaTotalTipoPagamento);
        }

        public void CancelaOperacao()
        {
            if (TransacaoComTef)
            {
                if (MessageBox.Show("Existem pagamentos no cartao. O cupom fiscal será cancelado. Deseja continuar?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ACBrTEFD.CancelarTransacoesPendentes();
                    if (CupomCancelado)
                    {
                        Sessao.Instance.VendaAtual.CupomCancelado = "S";
                        Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
                        FechaVendaComProblemas();
                        MessageBox.Show("Transacao com cartao cancelada. Cupom Fiscal Cancelado.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scSomenteConsulta;
                        FechaVendaComProblemas();
                        MessageBox.Show("Problemas no ECF. Aplicação funcionará apenas para consulta.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    PodeFechar = true;
                    this.Close();
                }
            }
            else
                this.Close();
        }

        private void ComboTipoPagamento_Leave(object sender, EventArgs e)
        {
            EcfTipoPagamentoDTO TipoPagamento = Sessao.Instance.ListaTipoPagamento[ComboTipoPagamento.SelectedIndex];

            if (TipoPagamento != null)
            {
                if (TipoPagamento.GeraParcelas == "S")
                {/* ALTERAR - PARCELAMENTO
                    VerificaSaldoRestante();
                    if (SaldoRestante > 0)
                    {
                        try
                        {
                            
                            FParcelamento FParcelamento = new FParcelamento();
                            FParcelamento.EditNome.Text = Sessao.Instance.VendaAtual.NomeCliente;
                            FParcelamento.editCPF.Text = Sessao.Instance.VendaAtual.CPFouCNPJCliente;
                            FParcelamento.editValorVenda.Text = labelTotalVenda.Text;
                            FParcelamento.editValorRecebido.Text = labelTotalRecebido.Text;
                            FParcelamento.editValorParcelar.Value = SaldoRestante;
                            FParcelamento.editVencimento.Text = (DateTime.Now).ToString("dd/MM/yyyy");

                            if (Sessao.Instance.VendaAtual.Desconto > 0)
                            {
                                FParcelamento.lblDesconto.Text = "Desconto";
                                FParcelamento.editDesconto.Value = Sessao.Instance.VendaAtual.Desconto;
                            }

                            if (Sessao.Instance.VendaAtual.Acrescimo > 0)
                            {
                                FParcelamento.lblDesconto.Text = "Acrescimo";
                                FParcelamento.editDesconto.Value = Sessao.Instance.VendaAtual.Acrescimo;
                            }

                            if ((FParcelamento.ShowDialog() == DialogResult.OK))
                            {
                                //  Depois de chamar a tela de parcelamento, se tudo deu certo finaliza a Venda.
                                editValorPago.Text = SaldoRestante.ToString();
                                botaoSim.PerformClick();
                            }
                            else
                                ComboTipoPagamento.Focus();
                        }
                        catch (Exception eError)
                        {
                            Log.write(eError.ToString());
                        }
                    }
                }
                else
                    if (TipoPagamento.GeraParcelas == "C")
                    {
                        VerificaSaldoRestante();
                        if (SaldoRestante > 0)
                        {
                            try
                            {
                                FCheques FCheques = new FCheques();
                                FCheques.EditNome.Text = Sessao.Instance.VendaAtual.NomeCliente;
                                FCheques.editCPF.Text = Sessao.Instance.VendaAtual.CPFouCNPJCliente;
                                FCheques.edValor.Text = labelTotalVenda.Text;

                                if ((FCheques.ShowDialog() == DialogResult.OK))
                                {
                                    //  Depois d chamar a tela de parcelamente, se tudo deu certo finaliza a Venda.
                                    editValorPago.Text = SaldoRestante.ToString();
                                    botaoSim.PerformClick();
                                }
                                else
                                    ComboTipoPagamento.Focus();
                            }
                            catch (Exception eError)
                            {
                                Log.write(eError.ToString());
                            }
                        }
                    */}
            }
        }

        public void SubTotalizaCupom()
        {
            if ((DataModule.ACBrECF.Estado.ToString() == "Venda"))
            {
                if (Sessao.Instance.VendaAtual.Desconto > 0)
                    ECFUtil.SubTotalizaCupom(Sessao.Instance.VendaAtual.Desconto * -1);
                else if (Sessao.Instance.VendaAtual.Acrescimo > 0)
                    ECFUtil.SubTotalizaCupom(Sessao.Instance.VendaAtual.Acrescimo);
                else
                    ECFUtil.SubTotalizaCupom(0);
            }
        }

        public void OrdenaLista()
        {
            List<EcfTotalTipoPagamentoDTO> ListaTotalTipoPagamentoLocal = ListaTotalTipoPagamento;
            ListaTotalTipoPagamentoLocal = ListaTotalTipoPagamento;
            ListaTotalTipoPagamento = new List<EcfTotalTipoPagamentoDTO>();

            // no primeiro laço insere na lista só quem nao tem TEF
            for (int i = 0; i <= ListaTotalTipoPagamentoLocal.Count - 1; i++)
            {
                if (ListaTotalTipoPagamentoLocal[i].EcfTipoPagamento.Tef == "N")
                    ListaTotalTipoPagamento.Add(ListaTotalTipoPagamentoLocal[i]);
            }

            // no segundo laço insere os pagamentos que tem tef
            for (int i = 0; i <= ListaTotalTipoPagamentoLocal.Count - 1; i++)
                if (ListaTotalTipoPagamentoLocal[i].EcfTipoPagamento.Tef == "S")
                    ListaTotalTipoPagamento.Add(ListaTotalTipoPagamentoLocal[i]);
        }

        #region Metodos do Componente ACBrTEFD

        private void acBrTEFD_OnAguardaResp(object sender, ACBrFramework.TEFD.AguardaRespEventArgs e)
        {
            String Msg = "";

            if ((ACBrTEFD.GPAtual == ACBrFramework.TEFD.TefTipo.CliSiTef) || (ACBrTEFD.GPAtual == ACBrFramework.TEFD.TefTipo.CliSiTef)) // É TEF dedicado?
            {
                if (e.Arquivo == "23")  // está aguardando Pin-Pad ?
                {
                    Msg = "Tecle ESC para cancelar.";
                }
            }
            else
                Msg = "Aguardando: " + e.Arquivo + " " + Convert.ToString(e.SegundosTimeout);

            if (Msg != "")
                Caixa.LabelMensagens.Text = Msg;
            Application.DoEvents();
        }

        private void acBrTEFD_OnAntesCancelarTransacao(object sender, ACBrFramework.TEFD.AntesCancelarTransacaoEventArgs e)
        {
            if ((DataModule.ACBrECF.Estado.ToString() == "Venda") || (DataModule.ACBrECF.Estado.ToString() == "Pagamento"))
            {
                ECFUtil.CancelaCupom();
                CupomCancelado = true;
            }
            else if ((DataModule.ACBrECF.Estado.ToString() == "Relatorio"))
            {
                DataModule.ACBrECF.FechaRelatorio();
                PAFUtil.GravarR06("CC");
            }
            else
                DataModule.ACBrECF.CorrigeEstadoErro(false);
        }

        private void acBrTEFD_OnAntesFinalizarRequisicao(object sender, ACBrFramework.TEFD.AntesFinalizarRequisicaoEventArgs e)
        {
        }

        private void acBrTEFD_OnBloqueiaMouseTeclado(object sender, ACBrFramework.TEFD.BloqueiaMouseTecladoEventArgs e)
        {
            e.Tratado = true;  //  Se "False" --> Deixa executar o codigo de Bloqueio do ACBrTEFD 
        }

        private void acBrTEFD_OnComandaECF(object sender, ACBrFramework.TEFD.ComandaECFEventArgs e)
        {
            string Mensagem = "";

            try
            {
                switch (e.Operacao)
                {
                    case ACBrFramework.TEFD.OperacaoECF.AbreGerencial:
                        {
                            DataModule.ACBrECF.AbreRelatorioGerencial();
                        }
                        break;

                    case ACBrFramework.TEFD.OperacaoECF.CancelaCupom:
                        {
                            ImpressaoOK = false;
                            try
                            {
                                ECFUtil.CancelaCupom();
                                CupomCancelado = true;
                            }
                            catch (Exception eError)
                            {
                                Log.write(eError.ToString());
                                CupomCancelado = false;
                            }
                        } break;

                    case ACBrFramework.TEFD.OperacaoECF.FechaCupom:
                        {
                            if (Sessao.Instance.VendaAtual.IdEcfPreVendaCabecalho > 0)
                                Mensagem = "PV" + new string('0', 10 - Convert.ToString(Sessao.Instance.VendaAtual.IdEcfPreVendaCabecalho).Length) + Convert.ToString(Sessao.Instance.VendaAtual.IdEcfPreVendaCabecalho);
                            if (Sessao.Instance.VendaAtual.IdEcfDav > 0)
                            {
                                Mensagem = "DAV" + new string('0', 10 - Convert.ToString(Sessao.Instance.VendaAtual.IdEcfDav).Length) + Convert.ToString(Sessao.Instance.VendaAtual.IdEcfDav);
                            }
                            Mensagem = Caixa.MD5 + Mensagem + "\r" + "\n";
                            try
                            {
                                if (Sessao.Instance.Configuracao.EcfEmpresa.Uf == "MG")
                                {
                                    Mensagem = Mensagem + "MINAS LEGAL:" +
                                             Sessao.Instance.Configuracao.EcfEmpresa.Cnpj.Substring(8, 1) + DataModule.ACBrECF.DataHora.ToString("ddMMyyyy");
                                    if (Sessao.Instance.VendaAtual.ValorFinal >= 1)
                                    {
                                        Mensagem = Mensagem + Sessao.Instance.VendaAtual.ValorFinal.Value.ToString("0.00");
                                    }
                                    Mensagem = Mensagem + "\r" + "\n";
                                }
                                ECFUtil.FechaCupom(Mensagem + Sessao.Instance.Configuracao.MensagemCupom);
                            }
                            catch (Exception eError)
                            {
                                Log.write(eError.ToString());
                            }
                        } break;

                    case ACBrFramework.TEFD.OperacaoECF.SubTotalizaCupom:
                        SubTotalizaCupom(); //DataModule.ACBrECF.SubtotalizaCupom(0); 
                        break;

                    case ACBrFramework.TEFD.OperacaoECF.FechaVinculado:
                        {
                            DataModule.ACBrECF.FechaRelatorio();
                            PAFUtil.GravarR06("CC");
                        } break;

                    case ACBrFramework.TEFD.OperacaoECF.PulaLinhas:
                        {
                            DataModule.ACBrECF.PulaLinhas(DataModule.ACBrECF.LinhasEntreCupons);
                            DataModule.ACBrECF.CortaPapel(true);
                            Thread.Sleep(200);
                        } break;
                }

                e.RetornoECF = true;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                e.RetornoECF = false;
            }

        }

        private void acBrTEFD_OnComandaECFAbreVinculado(object sender, ACBrFramework.TEFD.ComandaECFAbreVinculadoEventArgs e)
        {
            try
            {
                DataModule.ACBrECF.AbreCupomVinculado(e.COO, e.IndiceECF, e.Valor);
                e.RetornoECF = true;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                e.RetornoECF = false;
            }
        }

        private void acBrTEFD_OnComandaECFImprimeVia(object sender, ACBrFramework.TEFD.ComandaECFImprimeViaEventArgs e)
        {
            //* *** Se estiver usando ACBrECF... Lembre-se de configurar ***
            //ACBrECF1.MaxLinhasBuffer   := 3; // Os homologadores permitem no m?ximo
            // Impressao de 3 em 3 linhas
            //ACBrECF1.LinhasEntreCupons := 7; // (ajuste conforme o seu ECF)
            //NOTA: ACBrECF nao possui comando para imprimir a 2a via do CCD 
            try
            {
                switch (e.TipoRelatorio)
                {
                    case ACBrFramework.TEFD.TipoRelatorio.Gerencial:
                        DataModule.ACBrECF.LinhaRelatorioGerencial(e.ImagemComprovante);
                        break;
                    case ACBrFramework.TEFD.TipoRelatorio.Vinculado:
                        DataModule.ACBrECF.LinhaCupomVinculado(e.ImagemComprovante);
                        break;
                }
                e.RetornoECF = true;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                e.RetornoECF = false;
            }
        }

        private void acBrTEFD_OnComandaECFPagamento(object sender, ACBrFramework.TEFD.ComandaECFPagamentoEventArgs e)
        {
            try
            {
                DataModule.ACBrECF.EfetuaPagamento(e.IndiceECF, e.Valor);
                e.RetornoECF = true;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
                e.RetornoECF = false;
            }
        }

        private void acBrTEFD_OnExibeMensagem(object sender, ACBrFramework.TEFD.ExibeMensagemEventArgs e)
        {
            string OldMensagem;

            switch (e.Operacao)
            {
                case ACBrFramework.TEFD.OperacaoMensagem.OK:
                    MessageBox.Show(e.Mensagem, "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.ModalResult = ACBrFramework.TEFD.ModalResult.OK;
                    break;

                case ACBrFramework.TEFD.OperacaoMensagem.YesNo:
                    {
                        if (!DataModule.ACBrECF.Ativo)
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
                            }
                            DataModule.ACBrECF.CarregaAliquotas();
                            DataModule.ACBrECF.CarregaFormasPagamento();
                        }
                        e.ModalResult = MessageBox.Show(e.Mensagem, "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? ACBrFramework.TEFD.ModalResult.Yes : ACBrFramework.TEFD.ModalResult.No;
                    }
                    break;

                case ACBrFramework.TEFD.OperacaoMensagem.ExibirMsgOperador:
                    break;

                case ACBrFramework.TEFD.OperacaoMensagem.RemoverMsgOperador:
                    Caixa.LabelMensagens.Text = e.Mensagem;
                    break;

                case ACBrFramework.TEFD.OperacaoMensagem.ExibirMsgCliente:
                    break;

                case ACBrFramework.TEFD.OperacaoMensagem.RemoverMsgCliente:
                    Caixa.LabelMensagens.Text = e.Mensagem;
                    break;

                case ACBrFramework.TEFD.OperacaoMensagem.DestaqueVia:
                    {
                        OldMensagem = Caixa.LabelMensagens.Text;
                        try
                        {
                            Caixa.LabelMensagens.Text = e.Mensagem;

                            //  Aguardando 3 segundos 
                            Thread.Sleep(3000);

                        }
                        finally
                        {
                            Caixa.LabelMensagens.Text = OldMensagem;
                        }
                    }
                    break;
            }

            if ((e.ModalResult == ACBrFramework.TEFD.ModalResult.No) && (e.Mensagem == "Gostaria de continuar a transacao com outra(s) forma(s) de pagamento ?"))
            {
                SegundoCartaoCancelado = true;
            }
            Application.DoEvents();
        }

        private void acBrTEFD_OnInfoECF(object sender, ACBrFramework.TEFD.InfoECFEventArgs e)
        {
            switch (e.Operacao)
            {
                case ACBrFramework.TEFD.InfoECF.SubTotal:
                    e.Value = DataModule.ACBrECF.SubTotal - DataModule.ACBrECF.TotalPago;
                    break;

                case ACBrFramework.TEFD.InfoECF.EstadoECF:
                    {
                        switch (DataModule.ACBrECF.Estado)
                        {
                            case EstadoECF.Livre:
                                e.RetornoECF = RetornoECF.Livre;
                                break;

                            case EstadoECF.Venda:
                                e.RetornoECF = RetornoECF.VendaDeItens;
                                break;

                            case EstadoECF.Pagamento:
                                e.RetornoECF = RetornoECF.PagamentoOuSubTotal;
                                break;

                            case EstadoECF.Relatorio:
                                e.RetornoECF = RetornoECF.RelatorioGerencial;
                                break;

                            case EstadoECF.NaoFiscal:
                                e.RetornoECF = RetornoECF.RecebimentoNaoFiscal;
                                break;

                            default:
                                e.RetornoECF = RetornoECF.Outro;
                                break;
                        }
                    } break;
            }

        }

        private void acBrTEFD_OnRestauraFocoAplicacao(object sender, ExecutaAcaoEventArgs e)
        {
            this.Focus();
            e.Tratado = true;
        }

        #endregion Metodos do Componente ACBrTEFD

        #region Tab por Enter
        private void ComboTipoPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void editValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
        #endregion Tab por Enter

    }

    public class BlockInput
    {
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "BlockInput")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool Bloquear([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool fBlockIt);
    }

}
