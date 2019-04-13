/********************************************************************************
Title: T2TiNFCe
Description: Detecta um movimento aberto e solicita autenticacao.

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
using NFCe.DTO;
using NFCe.Controller;
using NFCe.Util;

namespace NFCe.View
{

    public partial class MovimentoAberto : Form
    {

        public MovimentoAberto()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            this.editSenhaOperador.Focus();
            LabelTurno.Text = Sessao.Instance.Movimento.NfceTurno.Descricao;
            LabelTerminal.Text = Sessao.Instance.Movimento.NfceCaixa.Nome;
            LabelOperador.Text = Sessao.Instance.Movimento.NfceOperador.Login;
            LabelData.Text = Sessao.Instance.Movimento.DataAbertura.ToString();
            LabelHora.Text = Sessao.Instance.Movimento.HoraAbertura;
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void botaoConfirmaClick(object Sender)
        {
            Confirma();
        }

        private void Confirma()
        {
            try
            {
                //  verifica se senha do operador esta correta
                NfceOperadorDTO Operador = NfceOperadorController.Usuario(LabelOperador.Text, editSenhaOperador.Text);
                if (Operador != null)
                {
                    Sessao.Instance.StatusCaixa = Tipos.StatusCaixa.scAberto;
                    if (Sessao.Instance.Movimento.StatusMovimento == "T")
                    {
                        Sessao.Instance.Movimento.StatusMovimento = "A";
                        NfceMovimentoController.GravaNfceMovimento(Sessao.Instance.Movimento);
                    }
                    this.Close();
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


        public void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Confirma();
            if (e.KeyCode == Keys.F12)
                Confirma();
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        private void botaoConfirma_Click(object sender, EventArgs e)
        {
            Confirma();
        }

    }

}
