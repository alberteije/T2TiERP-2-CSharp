/********************************************************************************
Title: T2TiNFCe
Description: Janela utilizada para iniciar um novo movimento.

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
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NFCe.DTO;
using NFCe.Controller;

using NFCe.Util;
using System.Collections.Generic;
using System.Drawing.Printing;

namespace NFCe.View
{

    public partial class IniciaMovimento : Form
    {

        private static DataTable DTTurno;
        String TextoParaImpressao = "";

        public IniciaMovimento()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            //
            ConfiguraDataSet();
            GridTurno.Focus();
        }

        private void ConfiguraDataSet()
        {
            // Tabela Fechamento
            DTTurno = new DataTable("TURNO");
            DTTurno.Columns.Add("DESCRICAO", typeof(string));
            DTTurno.Columns.Add("HORA_INICIO", typeof(string));
            DTTurno.Columns.Add("HORA_FIM", typeof(string));
            DTTurno.Columns.Add("ID", typeof(int));
            dataSet.Tables.Add(DTTurno);

            GridTurno.DataSource = dataSet;
            GridTurno.DataMember = dataSet.Tables["TURNO"].TableName;
            CarregarTurnos();
        }

        private void CarregarTurnos()
        {
            DataRow Registro;
            List<NfceTurnoDTO> ListaTurnos = (List<NfceTurnoDTO>)NfceTurnoController.ConsultaNfceTurnoLista("Id > 0");
            for (int i = 0; i <= ListaTurnos.Count - 1; i++)
            {
                Registro = DTTurno.NewRow();
                Registro["DESCRICAO"] = ListaTurnos[i].Descricao;
                Registro["HORA_INICIO"] = ListaTurnos[i].HoraInicio;
                Registro["HORA_FIM"] = ListaTurnos[i].HoraFim;
                Registro["ID"] = Convert.ToInt32(ListaTurnos[i].Id);
                DTTurno.Rows.Add(Registro);
            }
        }

        private void FIniciaMovimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                botaoConfirma.PerformClick();
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        private void GridTurno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                editValorSuprimento.Focus();
        }


        private void botaoConfirma_Click(object sender, EventArgs e)
        {
            Confirma();
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Confirma()
        {
            try
            {
                // verifica se senha e o nivel do operador estáo corretos
                NfceOperadorDTO Operador = NfceOperadorController.Usuario(editLoginOperador.Text, editSenhaOperador.Text);
                if (Operador != null)
                {
                    // verifica se senha do gerente esta correta
                    NfceOperadorDTO Gerente = NfceOperadorController.Usuario(editLoginGerente.Text, editSenhaGerente.Text);
                    if (Gerente != null)
                    {
                        // verifica nivel de acesso do gerente/supervisor
                        if ((Gerente.NivelAutorizacao == "G") || (Gerente.NivelAutorizacao == "S"))
                        {
                            DataRow Registro = DTTurno.Rows[GridTurno.CurrentRow.Index];

                            // insere movimento
                            Sessao.Instance.Movimento = new NfceMovimentoDTO();
                            Sessao.Instance.Movimento.NfceTurno.Id = Convert.ToInt32(Registro["ID"]);
                            Sessao.Instance.Movimento.Empresa.Id = Sessao.Instance.Configuracao.Empresa.Id;
                            Sessao.Instance.Movimento.NfceOperador.Id = Operador.Id;
                            Sessao.Instance.Movimento.NfceCaixa.Id = Sessao.Instance.Configuracao.NfceCaixa.Id;
                            Sessao.Instance.Movimento.IdGerenteSupervisor = Gerente.Id;
                            Sessao.Instance.Movimento.DataAbertura = DateTime.Now;
                            Sessao.Instance.Movimento.HoraAbertura = DateTime.Now.ToString("hh:mm:ss");
                            if (editValorSuprimento.Text != "")
                                Sessao.Instance.Movimento.TotalSuprimento = Convert.ToDecimal(editValorSuprimento.Text);
                            Sessao.Instance.Movimento.StatusMovimento = "A";
                            Sessao.Instance.Movimento = NfceMovimentoController.GravaNfceMovimento(Sessao.Instance.Movimento);

                            // insere suprimento
                            if (editValorSuprimento.Text != "")
                            {
                                try
                                {
                                    NfceSuprimentoDTO Suprimento = new NfceSuprimentoDTO();
                                    Suprimento.IdNfceMovimento = Sessao.Instance.Movimento.Id;
                                    Suprimento.DataSuprimento = DateTime.Now;
                                    Suprimento.Valor = Convert.ToDecimal(editValorSuprimento.Text);
                                    NfceSuprimentoController.GravaNfceSuprimento(Suprimento);
                                }
                                catch (Exception eError)
                                {
                                    Log.write(eError.ToString());
                                }
                            }

                            if (Sessao.Instance.Movimento != null)
                            {
                                MessageBox.Show("Movimento aberto com sucesso.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
                                ImprimeAbertura();
                            }
                            Application.DoEvents();
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


        public void ImprimeAbertura()
        {
            textBox1.Clear();

            textBox1.Text += new string('=', 48) + "\r\n";
            textBox1.Text += " ABERTURA DE CAIXA " + "\r\n";
            textBox1.Text += " \r\n";
            textBox1.Text += "DATA DE ABERTURA  : " + Sessao.Instance.Movimento.DataAbertura + "\r\n";
            textBox1.Text += "HORA DE ABERTURA  : " + Sessao.Instance.Movimento.HoraAbertura + "\r\n";
            textBox1.Text += Sessao.Instance.Movimento.NfceCaixa.Nome + "  OPERADOR: " + Sessao.Instance.Movimento.NfceOperador.Login + "\r\n";
            textBox1.Text += "MOVIMENTO: " + Convert.ToString(Sessao.Instance.Movimento.Id) + "\r\n";
            textBox1.Text += new string('=', 48) + "\r\n";
            textBox1.Text += " \r\n";
            if (editValorSuprimento.Text != "")
                textBox1.Text += "SUPRIMENTO...: " + Convert.ToDecimal(editValorSuprimento.Text).ToString("0.00") + "\r\n";
            else
                textBox1.Text += "SUPRIMENTO...: 0.00" + "\r\n";
            textBox1.Text += " \r\n";
            textBox1.Text += " \r\n";
            textBox1.Text += " \r\n";
            textBox1.Text += " ________________________________________ " + "\r\n";
            textBox1.Text += " VISTO DO CAIXA " + "\r\n";
            textBox1.Text += " \r\n";
            textBox1.Text += " \r\n";
            textBox1.Text += " \r\n";
            textBox1.Text += " ________________________________________ " + "\r\n";
            textBox1.Text += " VISTO DO SUPERVISOR " + "\r\n";

            // Instância um PrintDocument
            PrintDocument oPrintDocument = new PrintDocument();

            // Mecanismo de impressão
            oPrintDocument.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            // Texto para impressão
            string fQuebra = Environment.NewLine;
            TextoParaImpressao = textBox1.Text + fQuebra;
            oPrintDocument.Print();
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
    }

}
