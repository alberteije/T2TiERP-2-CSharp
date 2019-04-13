/********************************************************************************
Title: T2TiNFCe
Description: Tela que aparece ap?s efetuarem todos os pagamentos.

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


using NFCe.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NFCe.View
{

    public partial class FechaEfetuaPagamento : Form
    {
        EfetuaPagamento FEfetuaPagamento;

        public FechaEfetuaPagamento(EfetuaPagamento pFEfetuaPagamento)
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            this.FEfetuaPagamento = pFEfetuaPagamento;
            label1.Text = "Enter ou ESC para continuar";
            Timer1.Enabled = true;
        }

        private void FFechaEfetuaPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.Enter))
            {
                this.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (label1.ForeColor == Color.Black)
            {
                label1.ForeColor = Color.Red;
            }
            else
            {
                label1.ForeColor = Color.Black;
            }
        }
    }

}
