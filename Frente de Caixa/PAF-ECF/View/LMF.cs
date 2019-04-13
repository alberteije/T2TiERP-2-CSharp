/* *******************************************************************************
  Title: T2TiPDV
  Description: Janela que gera arquivo da Memória da fita detalhe.

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
  ******************************************************************************* */


using System;
using System.Windows.Forms;
using PafEcf.Util;

namespace PafEcf.View
{

    public partial class LMF : Form
    {

        public LMF()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            this.cbPeriododeData.Checked = true;
            comboBoxTipoLeitura.SelectedIndex = 0;
        }

        private void LMF_Activated(object sender, EventArgs e)
        {
            mkeDataIni.Text = DataModule.ACBrECF.DataHora.ToString("dd/MM/yyyy");
            mkeDataFim.Text = DataModule.ACBrECF.DataHora.ToString("dd/MM/yyyy");
            editFim.Text = DataModule.ACBrECF.NumCOO;
            comboBoxTipoLeitura.Focus();
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                Confirma();
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        private void mkeDataFim_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(mkeDataFim.Text) < Convert.ToDateTime(mkeDataIni.Text))
            {
                MessageBox.Show("Data Final deve ser Maior que Data Inicial", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mkeDataFim.Focus();
            }
        }

        private void editFim_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(editFim.Text) < Convert.ToInt32(editInicio.Text))
            {
                MessageBox.Show("COO Final deve ser Maior que COO Inicial", "Informação do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mkeDataFim.Focus();
            }
        }

        private void cbPeriododeData_Click(object sender, EventArgs e)
        {
            panCOO.Enabled = false;
            panCOO.BorderStyle = BorderStyle.None;
            panPeriodo.Enabled = true;
            panPeriodo.BorderStyle = BorderStyle.Fixed3D;
        }

        private void cbIntervalodeCOO_Click(object sender, EventArgs e)
        {
            panCOO.Enabled = true;
            panCOO.BorderStyle = BorderStyle.Fixed3D;
            panPeriodo.Enabled = false;
            panPeriodo.BorderStyle = BorderStyle.None;
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
            //Completa
            if (comboBoxTipoLeitura.SelectedIndex == 0)
            {
                if (MessageBox.Show("Deseja imprimir a LMFC - Leitura Memória Fiscal Completa?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Por data
                    if (cbPeriododeData.Checked)
                    {
                        try
                        {
                            DataModule.ACBrECF.LeituraMemoriaFiscal(Convert.ToDateTime(mkeDataIni.Text), Convert.ToDateTime(mkeDataFim.Text));
                        }
                        catch (Exception eError)
                        {
                            Log.write(eError.ToString());
                        }
                    }

                    // Por redução
                    else if (cbIntervalodeCRZ.Checked)
                    {
                        try
                        {
                            DataModule.ACBrECF.LeituraMemoriaFiscal(Convert.ToInt32(editInicio.Text), Convert.ToInt32(editFim.Text));
                        }
                        catch (Exception eError)
                        {
                            Log.write(eError.ToString());
                        }
                    }
                }
            }


            //Simplificada
            if (comboBoxTipoLeitura.SelectedIndex == 1)
            {
                if (MessageBox.Show("Deseja imprimir a LMFS - Leitura Memória Fiscal Simplificada?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Por data
                    if (cbPeriododeData.Checked)
                    {
                        try
                        {
                            DataModule.ACBrECF.LeituraMemoriaFiscal(Convert.ToDateTime(mkeDataIni.Text), Convert.ToDateTime(mkeDataFim.Text), true);
                        }
                        catch (Exception eError)
                        {
                            Log.write(eError.ToString());
                        }
                    }

                    // Por redução
                    else if (cbIntervalodeCRZ.Checked)
                    {
                        try
                        {
                            DataModule.ACBrECF.LeituraMemoriaFiscal(Convert.ToInt32(editInicio.Text), Convert.ToInt32(editFim.Text), true);
                        }
                        catch (Exception eError)
                        {
                            Log.write(eError.ToString());
                        }
                    }
                }
            }

        }

		
    }

}
