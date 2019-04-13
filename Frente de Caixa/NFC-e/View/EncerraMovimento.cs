/********************************************************************************
Title: T2TiNFCe
Description: Encerra um movimento aberto.

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
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using NFCe.DTO;
using System.Collections.Generic;
using NFCe.Controller;
using NFCe.Util;
using System.Drawing.Printing;


namespace NFCe.View
{

    public partial class EncerraMovimento : Form
    {

        private static DataTable DTFechamento;
        public static bool FechouMovimento;
        String TextoParaImpressao = "";

        #region Infra

        public EncerraMovimento()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            ConfiguraDataSet();
            FormCreate();
            ComboTipoPagamento.Focus();
        }

        public void FormCreate()
        {
            FechouMovimento = false;

            LabelTurno.Text = Sessao.Instance.Movimento.NfceTurno.Descricao;
            LabelTerminal.Text = Sessao.Instance.Movimento.NfceCaixa.Nome;
            LabelOperador.Text = Sessao.Instance.Movimento.NfceOperador.Login;

            for (int i = 0; i <= Sessao.Instance.ListaTipoPagamento.Count - 1; i++)
                ComboTipoPagamento.Items.Add(Sessao.Instance.ListaTipoPagamento[i].Descricao);
            ComboTipoPagamento.SelectedIndex = 0;

            TotalizaFechamento();
        }

        private void ConfiguraDataSet()
        {
            // Tabela Fechamento
            DTFechamento = new DataTable("FECHAMENTO");
            DTFechamento.Columns.Add("TIPO_PAGAMENTO", typeof(string));
            DTFechamento.Columns.Add("VALOR", typeof(decimal));
            DTFechamento.Columns.Add("ID", typeof(int));
            dataSet.Tables.Add(DTFechamento);

            GridValores.DataSource = dataSet;
            GridValores.DataMember = dataSet.Tables["FECHAMENTO"].TableName;

            //definimos os cabeçalhos da Grid
            GridValores.Columns[0].HeaderText = "Tipo Pagamento";
            GridValores.Columns[0].ReadOnly = true;
            GridValores.Columns[1].HeaderText = "Valor";
            GridValores.Columns[1].ReadOnly = true;
            GridValores.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GridValores.Columns[2].Visible = false;
        }

        private void editSenhaGerente_Leave(object sender, EventArgs e)
        {
            botaoConfirma.Focus();
        }

        private void edtValor_Leave(object sender, EventArgs e)
        {
            if (edtValor.Text.Trim() == "")
                editSenhaOperador.Focus();
        }

        private void FEncerraMovimento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FechouMovimento)
            {
                Sessao.Instance.Movimento = null;
            }
        }

        private void FEncerraMovimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                botaoConfirma.PerformClick();
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botaoConfirma_Click(object sender, EventArgs e)
        {
            Confirma();
        }

        private void editSenhaOperador_Leave(object sender, EventArgs e)
        {
            editLoginGerente.Focus();
        }
        
        #endregion Infra

        #region Dados de Fechamento

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (ComboTipoPagamento.Text.Trim() == "")
            {
                MessageBox.Show("Informe uma forma de Pagamento valida!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ComboTipoPagamento.Focus();
                return;
            }

            if (Convert.ToDecimal(edtValor.Text) <= 0)
            {
                MessageBox.Show("Informe um Valor valido!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                edtValor.Focus();
                return;
            }

            try
            {
                NfceFechamentoDTO Fechamento = new NfceFechamentoDTO();
                Fechamento.IdNfceMovimento = Sessao.Instance.Movimento.Id;
                Fechamento.TipoPagamento = ComboTipoPagamento.Text;
                Fechamento.Valor = Convert.ToDecimal(edtValor.Text);

                NfceFechamentoController.GravaNfceFechamento(Fechamento);

                TotalizaFechamento();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
            edtValor.Clear();
            ComboTipoPagamento.Focus();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (DTFechamento.Rows.Count > 0)
            {
                DataRow Registro = DTFechamento.Rows[GridValores.CurrentRow.Index];
                NfceFechamentoDTO EcfFechamentoParaExclusao = new NfceFechamentoDTO();
                EcfFechamentoParaExclusao.Id = Convert.ToInt32(Registro["ID"]);
                NfceFechamentoController.ExcluiNfceFechamento(EcfFechamentoParaExclusao);
                TotalizaFechamento();
            }
            ComboTipoPagamento.Focus();
        }

        public void TotalizaFechamento()
        {
            DTFechamento.Rows.Clear();

            string Filtro = "IdNfceMovimento = " + Sessao.Instance.Movimento.Id;
            IList<NfceFechamentoDTO> ListaFechamento = NfceFechamentoController.ConsultaNfceFechamentoLista(Filtro);
            if (ListaFechamento != null)
            {
                for (int i = 0; i <= ListaFechamento.Count - 1; i++ )
                {
                    DataRow Registro = DTFechamento.NewRow();
                    Registro["ID"] = ListaFechamento[i].Id;
                    Registro["TIPO_PAGAMENTO"] = ListaFechamento[i].TipoPagamento;
                    Registro["VALOR"] = ListaFechamento[i].Valor.Value.ToString("N2");
                    DTFechamento.Rows.Add(Registro);
                }
            }

            decimal Total = 0;
            foreach (DataRow Registro in DTFechamento.Rows)
            {
                Total = Total + Convert.ToDecimal(Registro["VALOR"]);
            }
            edtTotal.Text = Total.ToString("N2");
        }

        #endregion Dados de Fechamento

        #region Confirmação e Encerramento do Movimento

        private void Confirma()
        {
            try
            {
                NfceOperadorDTO Operador = new NfceOperadorDTO();
                NfceOperadorDTO Gerente = new NfceOperadorDTO();

                //  verifica se senha do operador esta correta
                Operador = NfceOperadorController.Usuario(LabelOperador.Text, editSenhaOperador.Text);
                if (Operador != null)
                {
                    //  verifica se senha do gerente esta correta
                    Gerente = NfceOperadorController.Usuario(editLoginGerente.Text, editSenhaGerente.Text);
                    if (Gerente != null)
                    {
                        if ((Gerente.NivelAutorizacao == "G") || (Gerente.NivelAutorizacao == "S"))
                        {
                            // encerra movimento
                            Sessao.Instance.Movimento.DataFechamento = DateTime.Now;
                            Sessao.Instance.Movimento.HoraFechamento = DateTime.Now.ToString("hh:mm:ss");
                            Sessao.Instance.Movimento.StatusMovimento = "F";

                            NfceMovimentoController.GravaNfceMovimento(Sessao.Instance.Movimento);

                            ImprimeFechamento();

                            MessageBox.Show("Movimento encerrado com sucesso.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                            FechouMovimento = true;

                            botaoConfirma.DialogResult = DialogResult.OK;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Gerente ou Supervisor: nivel de acesso incorreto.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            editLoginGerente.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gerente ou Supervisor: dados incorretos.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        editLoginGerente.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Operador: dados incorretos.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    editSenhaOperador.Focus();
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        #endregion Confirmação e Encerramento do Movimento

        #region Impressão do Fechamento

        public void ImprimeFechamento()
        {
            string Calculado, Declarado, Diferenca;
            decimal TotCalculado, TotDeclarado, TotDiferenca;
            string Suprimento, Sangria, NaoFiscal, TotalVenda, Desconto, Acrescimo, Recebido, Troco, Cancelado, TotalFinal;

            try
            {
                textBox1.Text += new string('=', 48) + "\r\n";
                textBox1.Text += "             FECHAMENTO DE CAIXA                " + "\r\n";
                textBox1.Text += " \r\n";
                textBox1.Text += "DATA DE ABERTURA  : " + Sessao.Instance.Movimento.DataAbertura + "\r\n";
                textBox1.Text += "HORA DE ABERTURA  : " + Sessao.Instance.Movimento.HoraAbertura + "\r\n";
                textBox1.Text += "DATA DE FECHAMENTO: " + Sessao.Instance.Movimento.DataFechamento + "\r\n";
                textBox1.Text += "HORA DE FECHAMENTO: " + Sessao.Instance.Movimento.HoraFechamento + "\r\n";
                textBox1.Text += Sessao.Instance.Movimento.NfceCaixa.Nome + "  OPERADOR: " + Sessao.Instance.Movimento.NfceOperador.Login + "\r\n";
                textBox1.Text += "MOVIMENTO: " + Convert.ToString(Sessao.Instance.Movimento.Id) + "\r\n";
                textBox1.Text += new string('=', 48) + "\r\n";
                textBox1.Text += " \r\n";
    
                Suprimento = Sessao.Instance.Movimento.TotalSuprimento == null ? "0.00" : Sessao.Instance.Movimento.TotalSuprimento.Value.ToString("N2");
                Sangria = Sessao.Instance.Movimento.TotalSangria == null ? "0.00" : Sessao.Instance.Movimento.TotalSangria.Value.ToString("N2");
                NaoFiscal = Sessao.Instance.Movimento.TotalNaoFiscal == null ? "0.00" : Sessao.Instance.Movimento.TotalNaoFiscal.Value.ToString("N2");
                TotalVenda = Sessao.Instance.Movimento.TotalVenda == null ? "0.00" : Sessao.Instance.Movimento.TotalVenda.Value.ToString("N2");
                Desconto = Sessao.Instance.Movimento.TotalDesconto == null ? "0.00" : Sessao.Instance.Movimento.TotalDesconto.Value.ToString("N2");
                Acrescimo = Sessao.Instance.Movimento.TotalAcrescimo == null ? "0.00" : Sessao.Instance.Movimento.TotalAcrescimo.Value.ToString("N2");
                Recebido = Sessao.Instance.Movimento.TotalRecebido == null ? "0.00" : Sessao.Instance.Movimento.TotalRecebido.Value.ToString("N2");
                Troco = Sessao.Instance.Movimento.TotalTroco == null ? "0.00" : Sessao.Instance.Movimento.TotalTroco.Value.ToString("N2");
                Cancelado = Sessao.Instance.Movimento.TotalCancelado == null ? "0.00" : Sessao.Instance.Movimento.TotalCancelado.Value.ToString("N2");
                TotalFinal = Sessao.Instance.Movimento.TotalFinal == null ? "0.00" : Sessao.Instance.Movimento.TotalFinal.Value.ToString("N2");

                textBox1.Text += "SUPRIMENTO...: " + Suprimento + "\r\n";
                textBox1.Text += "SANGRIA......: " + Sangria + "\r\n";
                textBox1.Text += "NAO FISCAL...: " + NaoFiscal + "\r\n";
                textBox1.Text += "TOTAL VENDA..: " + TotalVenda + "\r\n";
                textBox1.Text += "DESCONTO.....: " + Desconto + "\r\n";
                textBox1.Text += "ACRESCIMO....: " + Acrescimo + "\r\n";
                textBox1.Text += "RECEBIDO.....: " + Recebido + "\r\n";
                textBox1.Text += "TROCO........: " + Troco + "\r\n";
                textBox1.Text += "CANCELADO....: " + Cancelado + "\r\n";
                textBox1.Text += "TOTAL FINAL..: " + TotalFinal + "\r\n";

                textBox1.Text += " \r\n";
                textBox1.Text += " \r\n";
                textBox1.Text += " \r\n";

                textBox1.Text += "       VALORES DECLARADOS PARA FECHAMENTO" + "\r\n";

                textBox1.Text += new string('=', 48) + "\r\n";
                textBox1.Text += " \r\n";

                TotCalculado = 0;
                TotDeclarado = 0;
                TotDiferenca = 0;

                Calculado = TotCalculado.ToString("N2");
                Declarado = TotDeclarado.ToString("N2");
                Diferenca = TotDiferenca.ToString("N2");

                textBox1.Text += "TOTAL.........:" + Calculado + Declarado + Diferenca + "\r\n";

                textBox1.Text += " \r\n";
                textBox1.Text += " \r\n";
                textBox1.Text += " \r\n";
                textBox1.Text += " \r\n";
                
                textBox1.Text += "    ________________________________________    " + "\r\n";
                textBox1.Text += "                 VISTO DO CAIXA                 " + "\r\n";

                textBox1.Text += " \r\n";
                textBox1.Text += " \r\n";
                textBox1.Text += " \r\n";

                textBox1.Text += "    ________________________________________    " + "\r\n";
                textBox1.Text += "               VISTO DO SUPERVISOR              " + "\r\n";

                // Instância um PrintDocument
                PrintDocument oPrintDocument = new PrintDocument();

                // Mecanismo de impressão
                oPrintDocument.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                // Texto para impressão
                string fQuebra = Environment.NewLine;
                TextoParaImpressao = textBox1.Text + fQuebra;
                oPrintDocument.Print();
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //variaveis usadas para definir as configurações da impressão
            float linhasPorPagina = 0;
            float yPosicao = 0;
            int contador = 0;
            float margemEsquerda = 10;
            float margemSuperior = 10;
            Font fonteImpressao = new Font(textBox1.Font.Name, textBox1.Font.Size, textBox1.Font.Style, textBox1.Font.Unit);
            SolidBrush mCaneta = new SolidBrush(Color.Black);

            // Define o numero de linhas por pagina, usando MarginBounds.
            linhasPorPagina = e.MarginBounds.Height / fonteImpressao.GetHeight(e.Graphics);

            yPosicao = margemSuperior + (contador * fonteImpressao.GetHeight(e.Graphics));
            e.Graphics.DrawString(TextoParaImpressao, fonteImpressao, mCaneta, margemEsquerda, yPosicao, new StringFormat());

            e.HasMorePages = false;

            //libera recursos 
            mCaneta.Dispose();
        }

        #endregion Impressão do Fechamento

    }

}
