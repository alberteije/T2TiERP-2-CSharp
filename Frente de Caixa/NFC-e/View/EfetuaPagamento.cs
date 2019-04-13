/********************************************************************************
Title: T2TiNFCe
Description: Janela para selecionar as formas de pagamento e finalizar a venda

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
using NFCe.Controller;
using NFCe.Util;
using NFCe.DTO;
using System.Data;
using System.Threading;

namespace NFCe.View
{

    public partial class EfetuaPagamento : Form
    {

        public static List<NfeFormaPagamentoDTO> ListaTotalTipoPagamento;
        private static decimal SaldoRestante, TotalVenda, Desconto, Acrescimo, TotalReceber, TotalRecebido, Troco;
        private static bool PodeFechar;
        public static DataTable DTValores;

        public EfetuaPagamento()
        {
            InitializeComponent();
        }

        private void FEfetuaPagamento_Shown(object sender, EventArgs e)
        {
            TotalVenda = 0;
            Desconto = 0;
            Acrescimo = 0;
            TotalReceber = 0;
            TotalRecebido = 0;
            Troco = 0;

            // preenche valores nas variaveis
            TotalVenda = Sessao.Instance.VendaAtual.ValorTotalProdutos.Value;
            Acrescimo = Sessao.Instance.VendaAtual.ValorDespesasAcessorias.Value;
            Desconto = Sessao.Instance.VendaAtual.ValorDesconto.Value;
            TotalReceber = Biblioteca.TruncaValor(TotalVenda + Acrescimo - Desconto, Constantes.DECIMAIS_VALOR);
            SaldoRestante = TotalReceber;

            PodeFechar = true;

            AtualizaLabelsValores();

            if (SaldoRestante > 0)
                editValorPago.Text = SaldoRestante.ToString("0.00");
            else
                editValorPago.Text = "0.00";

            // lista que vai acumular os meios de pagamento
            ListaTotalTipoPagamento = new List<NfeFormaPagamentoDTO>();

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
            DTValores.Columns.Add("INDICE_LISTA", typeof(int)); //8

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
            botaoSim.PerformClick();
        }

        // controle das teclas digitadas na Grid
        public void GridValoresKeyDown(object sender, KeyEventArgs e)
        {
            DataRow Registro = DTValores.Rows[GridValores.CurrentRow.Index];
            if (e.KeyCode == Keys.Delete)
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
            NfceTipoPagamentoDTO TipoPagamento = Sessao.Instance.ListaTipoPagamento[ComboTipoPagamento.SelectedIndex];
            ValorInformado = Biblioteca.TruncaValor(Convert.ToDecimal(editValorPago.Text), Constantes.DECIMAIS_VALOR);

            NfeFormaPagamentoDTO TotalTipoPagamento = new NfeFormaPagamentoDTO();

            GroupBox3.Enabled = false;

            DataRow Registro = DTValores.NewRow();
            Registro["DESCRICAO"] = ComboTipoPagamento.Text;
            decimal valor = Convert.ToDecimal(editValorPago.Text);
            Registro["VALOR"] = Convert.ToDecimal(valor.ToString("0.00"));

            TotalRecebido = Biblioteca.TruncaValor(TotalRecebido + Convert.ToDecimal(editValorPago.Text), Constantes.DECIMAIS_VALOR);
            Troco = Biblioteca.TruncaValor(TotalRecebido - TotalReceber, Constantes.DECIMAIS_VALOR);
            if (Troco < 0)
                Troco = 0;

            VerificaSaldoRestante();

            TotalTipoPagamento.IdNfeCabecalho = Sessao.Instance.VendaAtual.Id;
            //TotalTipoPagamento.IdNfceTipoPagamento = TipoPagamento.Id;
            TotalTipoPagamento.Valor = Biblioteca.TruncaValor(Convert.ToDecimal(editValorPago.Text), Constantes.DECIMAIS_VALOR);
            TotalTipoPagamento.Forma = TipoPagamento.Codigo;
            TotalTipoPagamento.Estorno = "N";
            TotalTipoPagamento.NfceTipoPagamento = TipoPagamento;

            if (TipoPagamento.GeraParcelas == "N")
                Sessao.Instance.VendaAtual.IndicadorFormaPagamento = 0;  //a vista
            else
                Sessao.Instance.VendaAtual.IndicadorFormaPagamento = 1; //a prazo

            ListaTotalTipoPagamento.Add(TotalTipoPagamento);

            // guarda o índice da lista
            Registro["INDICE_LISTA"] = ListaTotalTipoPagamento.Count - 1;
            DTValores.Rows.Add(Registro);

            PanelConfirmaValores.Visible = false;
            PanelConfirmaValores.SendToBack();
            if (SaldoRestante > 0)
                editValorPago.Text = SaldoRestante.ToString("0.00");
            else
                editValorPago.Text = "0.00";

            GroupBox3.Enabled = true;
            ComboTipoPagamento.Focus();

            VerificaSaldoRestante();
            if (SaldoRestante <= 0)
                FinalizaVenda();
        }

        public void FinalizaVenda()
        {
            // grava os pagamentos no banco de dados
            NfeFormaPagamentoController.GravaNfeFormaPagamentoLista(ListaTotalTipoPagamento);

            // conclui o encerramento da venda - grava dados de cabecalho no banco
            Sessao.Instance.VendaAtual.ValorTotal = TotalReceber;
            Sessao.Instance.VendaAtual.Troco = Troco;

            Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
            Caixa.ConcluiEncerramentoVenda();

            PodeFechar = true;
            this.Close();
        }

        public void CancelaOperacao()
        {
            this.Close();
        }

        private void ComboTipoPagamento_Leave(object sender, EventArgs e)
        {
            NfceTipoPagamentoDTO TipoPagamento = Sessao.Instance.ListaTipoPagamento[ComboTipoPagamento.SelectedIndex];

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
                    */
                }                
            }
        }

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

    

}
