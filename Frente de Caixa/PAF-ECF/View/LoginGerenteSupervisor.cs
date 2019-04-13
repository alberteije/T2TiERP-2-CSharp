/********************************************************************************
Title: T2TiPDV
Description: Janela para controle de login do gerente/supervisor.

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
using PafEcf.DTO;
using PafEcf.Controller;
using PafEcf.Util;

namespace PafEcf.View
{

    public partial class LoginGerenteSupervisor : Form
    {

        public static bool LoginOK;
        public static string GerenteOuSupervisor;

        public LoginGerenteSupervisor()
        {
            InitializeComponent();
            LoginOK = false;
            editLoginGerente.Focus();
        }

        private void botaoConfirma_Click(object sender, EventArgs e)
        {
            Confirma();
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FLoginGerenteSupervisor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                botaoConfirma.PerformClick();
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        private void Confirma()
        {
            string GerenteOuSupervisor = "";
            try
            {
                //  verifica se senha do gerente/supervisor esta correta
                EcfOperadorDTO Operador = EcfFuncionarioController.Usuario(editLoginGerente.Text, editSenhaGerente.Text);
                if (Operador != null)
                {
                    if (GerenteOuSupervisor != "")
                    {
                        if (Operador.EcfFuncionario.NivelAutorizacao == GerenteOuSupervisor)
                            LoginOK = true;
                        else
                            LoginOK = false;
                    }
                    else
                    {
                        if ((Operador.EcfFuncionario.NivelAutorizacao == "G") || (Operador.EcfFuncionario.NivelAutorizacao == "S"))
                            LoginOK = true;
                        else
                            LoginOK = false;
                    }
                }
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

    }

}
