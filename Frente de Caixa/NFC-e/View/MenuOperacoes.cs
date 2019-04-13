using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using NFCe.Util;

namespace NFCe.View
{
    public partial class MenuOperacoes : Form
    {
        public MenuOperacoes()
        {
            InitializeComponent();
            listaMenuOperacoes.Focus();
            listaMenuOperacoes.SelectedIndex = 0;
        }

        private void listaMenuOperacoes_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                // carrega dav
                if (listaMenuOperacoes.SelectedIndex == 0)
                {
                    if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scAberto)
                    {
                        ImportaNumero FImportaNumero = new ImportaNumero();
                        FImportaNumero.Text = "Carrega DAV";
                        ImportaNumero.LabelEntrada.Text = "Informe o numero do DAV";
                        try
                        {
                            if (FImportaNumero.ShowDialog() == DialogResult.OK)
                            {
                                this.Close();
                                Caixa.CarregaDAV(ImportaNumero.EditEntrada.Text);
                            }
                        }
                        catch (Exception eError)
                        {
                            Log.write(eError.ToString());
                        }
                    } //  if StatusCaixa = 0 then
                    else
                        MessageBox.Show("Já existe uma venda em andamento.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // seleciona certificado
                if (listaMenuOperacoes.SelectedIndex == 1)
                {
                    Caixa.SelecionarCertificadoDigital();
                }

                // verifica o status do serviço
                if (listaMenuOperacoes.SelectedIndex == 2)
                {
                    Caixa.ConsultarStatusServico();
                }
            }
        }

        private void FMenuOperacoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FMenuOperacoes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sessao.Instance.MenuAberto = false;
        }

    }
}
