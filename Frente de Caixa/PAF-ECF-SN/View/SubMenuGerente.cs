using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PafEcf.Util;

namespace PafEcf.View
{
    public partial class FSubMenuGerente : Form
    {
        public FSubMenuGerente()
        {
            InitializeComponent();
            listaGerente.Focus();
            listaGerente.SelectedIndex = 0;
        }

        private void listaGerente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }


            if (e.KeyCode == Keys.Enter)
            {
                //  inicia movimento
                if (listaGerente.SelectedIndex == 0)
                    Caixa.IniciaMovimento();
                //  encerra movimento
                if (listaGerente.SelectedIndex == 1)
                    Caixa.EncerraMovimento();
                //  suprimento
                if (listaGerente.SelectedIndex == 3)
                    Caixa.Suprimento();
                //  sangria
                if (listaGerente.SelectedIndex == 4)
                    Caixa.Sangria();
                //  Reducao Z
                if (listaGerente.SelectedIndex == 6)
                {
                    if (MessageBox.Show("Tem Certeza Que Deseja Executar a Reducao Z?" + "\r" + "\r" + "O Movimento da Impressora será Suspenso no dia de Hoje.", "Reducao Z", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            ECFUtil.ReducaoZ();
                        }
                        finally
                        {
                            Caixa.TelaPadrao();
                        }
                    }
                }

                //  consultar cliente
                if (listaGerente.SelectedIndex == 8)
                {
                    ImportaCliente FImportaCliente = new ImportaCliente();
                    ImportaCliente.QuemChamou = "SUBMENU";
                    FImportaCliente.ShowDialog();
                }
                //  funções administrativas do TEF
                if (listaGerente.SelectedIndex == 10)
                {
                    
                    EfetuaPagamento FEfetuaPagamento = new EfetuaPagamento();
                    try
                    {
                        EfetuaPagamento.ACBrTEFD.Initializar(ACBrFramework.TEFD.TefTipo.TefDial);
                        EfetuaPagamento.ACBrTEFD.ADM(ACBrFramework.TEFD.TefTipo.TefDial);
                    }
                    catch (Exception eError)
                    {
                        Log.write(eError.ToString());
                        MessageBox.Show("Problemas no GP TEFDIAL.", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    FEfetuaPagamento.Dispose();
                    
                }
                //  Importar Tabelas com Dispositivo (pen-drive)
                if (listaGerente.SelectedIndex == 12)
                {
                    PenDrive FPenDrive = new PenDrive();
                    PenDrive.Rotina = "IMPORTA";
                    FPenDrive.ShowDialog();
                }

                //  Exportar Tabelas com Dispositivo (pen-drive)
                if (listaGerente.SelectedIndex == 13)
                {
                    PenDrive FPenDrive = new PenDrive();
                    PenDrive.Rotina = "EXPORTA";
                    FPenDrive.ShowDialog();
                }

            }

        }
    }
}
