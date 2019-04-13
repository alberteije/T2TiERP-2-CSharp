/********************************************************************************
Title: T2TiPDV
Description: Encerra um movimento aberto.

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


using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using PafEcf.DTO;
using System.Collections.Generic;
using PafEcf.Controller;
using PafEcf.Util;


namespace PafEcf.View
{

    public partial class EncerraMovimento : Form
    {

        private static DataTable DTFechamento;
        private static DataTable DTResumo;
        public static bool FechouMovimento;

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

            LabelTurno.Text = Sessao.Instance.Movimento.EcfTurno.Descricao;
            LabelTerminal.Text = Sessao.Instance.Movimento.EcfCaixa.Nome;
            LabelOperador.Text = Sessao.Instance.Movimento.EcfOperador.Login;
            LabelImpressora.Text = Sessao.Instance.Movimento.EcfImpressora.Identificacao;

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

            //Tabela Resumo
            DTResumo = new DataTable("RESUMO");
            DTResumo.Columns.Add("TIPO_PAGAMENTO", typeof(string));
            DTResumo.Columns.Add("CALCULADO", typeof(decimal));
            DTResumo.Columns.Add("DECLARADO", typeof(decimal));
            DTResumo.Columns.Add("DIFERENCA", typeof(decimal));
            dataSet.Tables.Add(DTResumo);
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
                EcfFechamentoDTO Fechamento = new EcfFechamentoDTO();
                Fechamento.IdEcfMovimento = Sessao.Instance.Movimento.Id;
                Fechamento.TipoPagamento = ComboTipoPagamento.Text;
                Fechamento.Valor = Convert.ToDecimal(edtValor.Text);

                EcfFechamentoController.GravaEcfFechamento(Fechamento);

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
                EcfFechamentoDTO EcfFechamentoParaExclusao = new EcfFechamentoDTO();
                EcfFechamentoParaExclusao.Id = Convert.ToInt32(Registro["ID"]);
                EcfFechamentoController.ExcluiEcfFechamento(EcfFechamentoParaExclusao);
                TotalizaFechamento();
            }
            ComboTipoPagamento.Focus();
        }

        public void TotalizaFechamento()
        {
            string Filtro = "IdEcfMovimento = " + Sessao.Instance.Movimento.Id;
            IList<EcfFechamentoDTO> ListaFechamento = EcfFechamentoController.ConsultaEcfFechamentoLista(Filtro);
            if (ListaFechamento != null)
            {
                if (ListaFechamento.Count > 0)
                    GridValores.DataSource = EcfFechamentoController.ConsultaEcfFechamentoLista(Filtro);
            }

            decimal Total = 0;
            foreach (DataRow Registro in DTFechamento.Rows)
            {
                Total = Total + Convert.ToDecimal(Registro["VALOR"]);
            }
            edtTotal.Text = Total.ToString("0.00");
        }

        #endregion Dados de Fechamento

        #region Confirmação e Encerramento do Movimento

        private void Confirma()
        {
            try
            {
                EcfOperadorDTO Operador = new EcfOperadorDTO();
                EcfOperadorDTO Gerente = new EcfOperadorDTO();

                //  verifica se senha do operador esta correta
                Operador = EcfFuncionarioController.Usuario(LabelOperador.Text, editSenhaOperador.Text);
                if (Operador != null)
                {
                    //  verifica se senha do gerente esta correta
                    Gerente = EcfFuncionarioController.Usuario(editLoginGerente.Text, editSenhaGerente.Text);
                    if (Gerente != null)
                    {
                        if ((Gerente.EcfFuncionario.NivelAutorizacao == "G") || (Gerente.EcfFuncionario.NivelAutorizacao == "S"))
                        {
                            // encerra movimento
                            Sessao.Instance.Movimento.DataFechamento = DataModule.ACBrECF.DataHora;
                            Sessao.Instance.Movimento.HoraFechamento = DataModule.ACBrECF.DataHora.ToString("hh:mm:ss");
                            Sessao.Instance.Movimento.StatusMovimento = "F";

                            EcfMovimentoController.GravaEcfMovimento(Sessao.Instance.Movimento);

                            CargaPDV FCargaPDV = new CargaPDV();
                            CargaPDV.Procedimento = "EXPORTA_MOVIMENTO";
                            FCargaPDV.ShowDialog();

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
                DataModule.ACBrECF.AbreRelatorioGerencial(Sessao.Instance.Configuracao.EcfRelatorioGerencial.X.Value);
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));
                DataModule.ACBrECF.LinhaRelatorioGerencial("             FECHAMENTO DE CAIXA                ");
                DataModule.ACBrECF.PulaLinhas(1);
                DataModule.ACBrECF.LinhaRelatorioGerencial("DATA DE ABERTURA  : " + Sessao.Instance.Movimento.DataAbertura);
                DataModule.ACBrECF.LinhaRelatorioGerencial("HORA DE ABERTURA  : " + Sessao.Instance.Movimento.HoraAbertura);
                DataModule.ACBrECF.LinhaRelatorioGerencial("DATA DE FECHAMENTO: " + Sessao.Instance.Movimento.DataFechamento);
                DataModule.ACBrECF.LinhaRelatorioGerencial("HORA DE FECHAMENTO: " + Sessao.Instance.Movimento.HoraFechamento);
                DataModule.ACBrECF.LinhaRelatorioGerencial(Sessao.Instance.Movimento.EcfCaixa.Nome + "  OPERADOR: " + Sessao.Instance.Movimento.EcfOperador.Login);
                DataModule.ACBrECF.LinhaRelatorioGerencial("MOVIMENTO: " + Convert.ToString(Sessao.Instance.Movimento.Id));
                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('=', 48));
                DataModule.ACBrECF.PulaLinhas(1);

                Suprimento = Sessao.Instance.Movimento.TotalSuprimento.Value.ToString("0.00");
                Sangria = Sessao.Instance.Movimento.TotalSangria.Value.ToString("0.00");
                NaoFiscal = Sessao.Instance.Movimento.TotalNaoFiscal.Value.ToString("0.00");
                TotalVenda = Sessao.Instance.Movimento.TotalVenda.Value.ToString("0.00");
                Desconto = Sessao.Instance.Movimento.TotalDesconto.Value.ToString("0.00");
                Acrescimo = Sessao.Instance.Movimento.TotalAcrescimo.Value.ToString("0.00");
                Recebido = Sessao.Instance.Movimento.TotalRecebido.Value.ToString("0.00");
                Troco = Sessao.Instance.Movimento.TotalTroco.Value.ToString("0.00");
                Cancelado = Sessao.Instance.Movimento.TotalCancelado.Value.ToString("0.00");
                TotalFinal = Sessao.Instance.Movimento.TotalFinal.Value.ToString("0.00");

                DataModule.ACBrECF.LinhaRelatorioGerencial("SUPRIMENTO...: " + Suprimento);
                DataModule.ACBrECF.LinhaRelatorioGerencial("SANGRIA......: " + Sangria);
                DataModule.ACBrECF.LinhaRelatorioGerencial("NAO FISCAL...: " + NaoFiscal);
                DataModule.ACBrECF.LinhaRelatorioGerencial("TOTAL VENDA..: " + TotalVenda);
                DataModule.ACBrECF.LinhaRelatorioGerencial("DESCONTO.....: " + Desconto);
                DataModule.ACBrECF.LinhaRelatorioGerencial("ACRESCIMO....: " + Acrescimo);
                DataModule.ACBrECF.LinhaRelatorioGerencial("RECEBIDO.....: " + Recebido);
                DataModule.ACBrECF.LinhaRelatorioGerencial("TROCO........: " + Troco);
                DataModule.ACBrECF.LinhaRelatorioGerencial("CANCELADO....: " + Cancelado);
                DataModule.ACBrECF.LinhaRelatorioGerencial("TOTAL FINAL..: " + TotalFinal);
                DataModule.ACBrECF.PulaLinhas(3);
                DataModule.ACBrECF.LinhaRelatorioGerencial("                 CALCULADO  DECLARADO  DIFERENCA");

                TotCalculado = 0;
                TotDeclarado = 0;
                TotDiferenca = 0;

                DataModule.ACBrECF.LinhaRelatorioGerencial(new string('-', 48));

                Calculado = TotCalculado.ToString("0.00");
                Declarado = TotDeclarado.ToString("0.00");
                Diferenca = TotDiferenca.ToString("0.00");

                DataModule.ACBrECF.LinhaRelatorioGerencial("TOTAL.........:" + Calculado + Declarado + Diferenca);
                DataModule.ACBrECF.PulaLinhas(4);
                DataModule.ACBrECF.LinhaRelatorioGerencial("    ________________________________________    ");
                DataModule.ACBrECF.LinhaRelatorioGerencial("                 VISTO DO CAIXA                 ");
                DataModule.ACBrECF.PulaLinhas(3);
                DataModule.ACBrECF.LinhaRelatorioGerencial("    ________________________________________    ");
                DataModule.ACBrECF.LinhaRelatorioGerencial("               VISTO DO SUPERVISOR              ");

                DataModule.ACBrECF.FechaRelatorio();
                PAFUtil.GravarR06("RG");
                Application.DoEvents();

            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        #endregion Impressão do Fechamento

    }

}
