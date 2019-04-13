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
using SAT;
using System.Runtime.InteropServices;

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
                // Consultar SAT
                if (listaMenuOperacoes.SelectedIndex == 0)
                {
                    IntPtr ptr = ComunicacaoSAT.ConsultarSAT(Sessao.GerarNumeroSessao());
                    string mensagem = TratarRetornoSAT.TratarRetornoConsultarSAT(Marshal.PtrToStringAnsi(ptr));
                    MessageBox.Show(mensagem, "Consultar SAT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Bloquear SAT
                if (listaMenuOperacoes.SelectedIndex == 1)
                {
                    IntPtr ptr = ComunicacaoSAT.BloquearSAT(Sessao.GerarNumeroSessao(), Sessao.CodigoAtivacao());
                    string mensagem = TratarRetornoSAT.TratarRetornoConsultarSAT(Marshal.PtrToStringAnsi(ptr));
                    MessageBox.Show(mensagem, "Bloquear SAT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Desbloquear SAT
                if (listaMenuOperacoes.SelectedIndex == 2)
                {
                    IntPtr ptr = ComunicacaoSAT.DesbloquearSAT(Sessao.GerarNumeroSessao(), Sessao.CodigoAtivacao());
                    string mensagem = TratarRetornoSAT.TratarRetornoConsultarSAT(Marshal.PtrToStringAnsi(ptr));
                    MessageBox.Show(mensagem, "Desbloquear SAT", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
