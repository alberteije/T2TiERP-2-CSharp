using NFCe.Controller;
using NFCe.DTO;
using NFCe.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFCe.View
{
    public partial class ListaNfce : Form
    {

        public static bool Confirmou;
        public static string IdSelecionado;
        public string Operacao;
        private static List<NfeCabecalhoDTO> ListaNfe;
        public static ComboBox ComboBoxProcedimento { get; set; }

        public ListaNfce()
        {
            InitializeComponent();
            //
            ComboBoxProcedimento = this.comboBoxProcedimento;
            //
            EditLocaliza.Text = "999";
            EditLocaliza.Focus();
            ListaNfe = new List<NfeCabecalhoDTO>();
            GridPrincipal.AutoGenerateColumns = false;
            Confirmou = false;
        }

        private void ListaNfce_Activated(object sender, EventArgs e)
        {
            ComboBoxProcedimento.Items.Clear();
            if (Operacao == "RecuperarVenda")
            {
                ComboBoxProcedimento.Items.Add("Recuperar Venda");
            }
            else if (Operacao == "CancelaInutiliza")
            {
                ComboBoxProcedimento.Items.Add("Cancelar NFC-e");
                ComboBoxProcedimento.Items.Add("Inutilizar Número");
            }
            ComboBoxProcedimento.SelectedIndex = 0;
        }

        private void botaoConfirma_Click(object sender, EventArgs e)
        {
            Confirma();
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SpeedButton1_Click(object sender, EventArgs e)
        {
            Localiza();
        }

        private void ListaNfce_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                Localiza();
            if (e.KeyCode == Keys.F12)
                botaoConfirma.PerformClick();
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }

        public void Localiza()
        {
            string Filtro = "";
            string ProcurePor = "%" + EditLocaliza.Text + "%";

            if (ComboBoxProcedimento.Text == "Recuperar Venda")
                Filtro = "StatusNota < 4 AND Numero like " + Biblioteca.QuotedStr(ProcurePor);
            else if (ComboBoxProcedimento.Text == "Cancelar NFC-e")
                Filtro = "StatusNota = 4 AND Numero like " + Biblioteca.QuotedStr(ProcurePor);
            else if (ComboBoxProcedimento.Text == "Inutilizar Número")
                Filtro = "StatusNota < 4 AND Numero like " + Biblioteca.QuotedStr(ProcurePor);

            ListaNfe = (List<NfeCabecalhoDTO>)VendaController.ConsultaNfceVendaCabecalhoListaLimpa(Filtro);
            GridPrincipal.DataSource = ListaNfe;
            if (ListaNfe.Count > 0)
                GridPrincipal.Focus();
        }

        public void Confirma()
        {
            Confirmou = true;
            IdSelecionado = ListaNfe[GridPrincipal.CurrentRow.Index].Id.ToString();
            this.Close();
        }

        private void GridPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                EditLocaliza.Focus();
        }

        private void comboBoxProcedimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxProcedimento.Text != "Recuperar Venda")
                Localiza();
        }


    }
}
