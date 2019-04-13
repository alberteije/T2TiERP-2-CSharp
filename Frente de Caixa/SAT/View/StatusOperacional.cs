using NFCe.DTO;
using NFCe.Util;
using SAT;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NFCe.View
{
    public partial class StatusOperacional : Form
    {

        public static bool Confirmou;
        public static string IdSelecionado;
        public string Operacao;
        private static List<NfeCabecalhoDTO> ListaNfe;
        public static ComboBox ComboBoxProcedimento { get; set; }

        public StatusOperacional()
        {
            InitializeComponent();
        }

        private void botaoCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListaNfce_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                botaoCancela.PerformClick();
        }
  
        private void ListaNfce_Load(object sender, EventArgs e)
        {
            IntPtr ptr = ComunicacaoSAT.ConsultarStatusOperacional(Sessao.GerarNumeroSessao(), Sessao.CodigoAtivacao());
            string mensagem = TratarRetornoSAT.TratarRetornoStatusOperacional(Marshal.PtrToStringAnsi(ptr));
            textBoxStatusOperacional.Text = mensagem;
        }


    }
}
