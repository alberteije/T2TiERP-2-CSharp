using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NFCe.Controller;
using NFCe.Util;


namespace NFCe.View
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            listaMenuPrincipal.Focus();
            listaMenuPrincipal.SelectedIndex = 0;
        }

        private void listaMenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                //  chama submenu do supervisor
                if (listaMenuPrincipal.SelectedIndex == 0)
                {
                    LoginGerenteSupervisor FLoginGerenteSupervisor = new LoginGerenteSupervisor();
                    try
                    {
                        LoginGerenteSupervisor.GerenteOuSupervisor = "S";
                        if (FLoginGerenteSupervisor.ShowDialog() == DialogResult.OK)
                        {
                            if (LoginGerenteSupervisor.LoginOK)
                            {
                                SubMenuSupervisor FSubMenuSupervisor = new SubMenuSupervisor();
                                FSubMenuSupervisor.SetBounds(this.Left, this.Top + 198, 467, 212);
                                FSubMenuSupervisor.ShowDialog();
                            }
                            else
                                MessageBox.Show("Supervisor - dados incorretos.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    finally
                    {
                    }
                }

                //  chama submenu do gerente
                if (listaMenuPrincipal.SelectedIndex == 1)
                {
                    LoginGerenteSupervisor FLoginGerenteSupervisor = new LoginGerenteSupervisor();
                    try
                    {
                        LoginGerenteSupervisor.GerenteOuSupervisor = "G";
                        if (FLoginGerenteSupervisor.ShowDialog() == DialogResult.OK)
                        {
                            if (LoginGerenteSupervisor.LoginOK)
                            {
                                FSubMenuGerente FSubMenuGerente = new FSubMenuGerente();
                                FSubMenuGerente.SetBounds(this.Left, this.Top + 198, 467, 212);
                                FSubMenuGerente.ShowDialog();
                            }
                            else
                                MessageBox.Show("Gerente - dados incorretos.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    finally
                    {
                    }
                }

                //  saida temporaria
                if (listaMenuPrincipal.SelectedIndex == 2)
                {
                    if (Sessao.Instance.StatusCaixa == Tipos.StatusCaixa.scAberto)
                    {
                        if (MessageBox.Show("Deseja fechar o caixa temporariamente?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Sessao.Instance.Movimento.StatusMovimento = "T";
                            NfceMovimentoController.GravaNfceMovimento(Sessao.Instance.Movimento);
                            MovimentoAberto FMovimentoAberto = new MovimentoAberto();
                            FMovimentoAberto.ShowDialog();
                        }
                    }
                    else
                        MessageBox.Show("Status do caixa não permite saida temporaria.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


               
            }

        }

        private void FMenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sessao.Instance.MenuAberto = false;
        }
    }
}
