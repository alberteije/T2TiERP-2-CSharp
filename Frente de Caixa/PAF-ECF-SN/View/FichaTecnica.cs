/********************************************************************************
Title: T2TiPDV
Description: Janela para cadastros de produtos produzidos pelo estabelecimento.

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


using System.Collections.Generic;
using System.Windows.Forms;
using PafEcf.Controller;
using System;
using PafEcf.Util;
using PafEcf.DTO;

namespace PafEcf.View
{

    public partial class FichaTecnica : Form
    {

        private static List<ProdutoDTO> ListaProduto;
        private static List<FichaTecnicaDTO> ListaComposicao;

        public FichaTecnica()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            ListaProduto = new List<ProdutoDTO>();
            ListaComposicao = new List<FichaTecnicaDTO>();
            GridPrincipal.AutoGenerateColumns = false;
            GridComposicao.AutoGenerateColumns = false;
            EditLocaliza.Focus();
        }

        private void SpeedButton1_Click(object sender, System.EventArgs e)
        {
            string ProcurePor = "%" + EditLocaliza.Text + "%";
            string Filtro = "Ippt = " + Biblioteca.QuotedStr("P");
            Filtro = Filtro + " and Nome like " + Biblioteca.QuotedStr(ProcurePor);
            ListaProduto = (List<ProdutoDTO>)ProdutoController.ConsultaProdutoLista(Filtro);
            GridPrincipal.DataSource = ListaProduto;
            if (ListaProduto.Count > 0)
                GridPrincipal.Focus();
        }

        private void EditLocaliza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                SpeedButton1.PerformClick();
        }

        private void CarregarFichaTecnica()
        {
            try
            {
                string Filtro = "IdProduto = " + ListaProduto[GridPrincipal.CurrentRow.Index].Id.ToString();
                ListaComposicao = (List<FichaTecnicaDTO>)FichaTecnicaController.ConsultaFichaTecnicaLista(Filtro);
                GridComposicao.DataSource = ListaComposicao;
            }
            catch (Exception eError)
            {
                Log.write(eError.ToString());
            }
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FFichaTecnica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        private void GridPrincipal_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CarregarFichaTecnica();
        }
    }

}
