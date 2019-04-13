/********************************************************************************
Title: T2TiNFCe
Description: Identifica um cliente não cadastrado para a venda. Permite chamar
a janela de pesquisa para importar um cliente cadastrado.

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

    public partial class IdentificaCliente : Form
    {

        public static TextBox EditCpfCnpj { get; set; }
        public static TextBox EditNome { get; set; }
        public static TextBox EditIDCliente { get; set; }
        
        ViewNfceClienteDTO Cliente;

        public IdentificaCliente()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            editIDCliente.Focus();
            Cliente = new ViewNfceClienteDTO();
            //
            EditCpfCnpj = this.editCpfCnpj;
            EditNome = this.editNome;
            EditIDCliente = this.editIDCliente;
        }

        private void FIdentificaCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
                botaoLocaliza.PerformClick();
            if (e.KeyCode == Keys.F12)
                botaoConfirma.PerformClick();
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        private void botaoLocaliza_Click(object sender, EventArgs e)
        {
            Localiza();
        }

        public void Localiza()
        {
            ImportaCliente FImportaCliente = new ImportaCliente();
            ImportaCliente.QuemChamou = "IDENTIFICA";
            FImportaCliente.ShowDialog();
        }

        private void editCpfCnpj_Leave(object sender, EventArgs e)
        {
            if (editCpfCnpj.Text.Trim() != "")
                LocalizaClienteNoBanco();
        }

        public void LocalizaClienteNoBanco()
        {
            Cliente = ViewNfceClienteController.ConsultaCliente("Cpf = " + Biblioteca.QuotedStr(editCpfCnpj.Text));
            if (Cliente != null)
            {
                editIDCliente.Text = Cliente.Id.ToString();
                editNome.Text = Cliente.Nome;
            }
        }

        public bool ValidaDados()
        {
            if (editCpfCnpj.Text.Length == 11)
                return Biblioteca.ValidaCPF(editCpfCnpj.Text);

            if (editCpfCnpj.Text.Length == 14)
                return Biblioteca.ValidaCNPJ(editCpfCnpj.Text);

            return false;
        }

        private void botaoConfirma_Click(object sender, EventArgs e)
        {
            Confirma();
        }

        private void Confirma()
        {
            if (ValidaDados())
            {
                Sessao.Instance.VendaAtual.NfeDestinatario.Nome = editNome.Text;
                Sessao.Instance.VendaAtual.NfeDestinatario.CpfCnpj = editCpfCnpj.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("CPF ou CNPJ Invalido!", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                editCpfCnpj.Focus();
            }
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
