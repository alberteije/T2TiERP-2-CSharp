using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using PafEcf.Util;

namespace PafEcf.View
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
            string RegistraPreVenda = "";
            try
            {
                XmlDocument ArquivoXML = new XmlDocument();
                ArquivoXML.Load(Application.StartupPath + "\\ArquivoAuxiliar.xml");
                RegistraPreVenda = Biblioteca.Desencripta(ArquivoXML.GetElementsByTagName("registraPreVenda").Item(0).InnerText.Trim());
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (RegistraPreVenda == "REGISTRA")
                {
                    //  carrega pre-venda
                    if (listaMenuOperacoes.SelectedIndex == 0)
                    {
                        if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scAberto)
                        {
                            ImportaNumero FImportaNumero = new ImportaNumero();
                            FImportaNumero.Text = "Carrega Pre-Venda";
                            ImportaNumero.LabelEntrada.Text = "Informe o numero da Pre-Venda";
                            try
                            {
                                if (FImportaNumero.ShowDialog() == DialogResult.OK)
                                {
                                    this.Close();
                                    Caixa.CarregaPreVenda(ImportaNumero.EditEntrada.Text);
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

                }
                else
                {
                    MessageBox.Show("Sistema não está configurado para operações com Pré-Vendas.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                //  carrega dav
                if (listaMenuOperacoes.SelectedIndex == 1)
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
