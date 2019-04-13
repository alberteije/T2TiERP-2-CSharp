/* *******************************************************************************
  Title: T2TiPDV
  Description: Tela principal do PAF-ECF - Caixa.

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
  t2ti.com@gmail.com

  @author Albert Eije
  @version 1.0
  ******************************************************************************* */



using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using ConfiguraPAFECF.View;
using ConfiguraPAFECF.VO;
using ConfiguraPAFECF.Controller;
using System;

namespace PafEcf.View
{

    // TODO : Verifique se todos os controles da janela estão sendo tratados. Faça as devidas correções.

    public partial class FCaixa : Form
    {

        public FCaixa()
        {
            InitializeComponent();
            SetResolucao();
        }

        #region Controle do Mouse

        int x, y;

        private void MoverControle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ((Control)sender).Focus();
            ((Control)sender).BringToFront();
            x = ((Control)sender).Left - MousePosition.X;
            y = ((Control)sender).Top - MousePosition.Y;
        }

        private void MoverControle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ((Control)sender).Left = x + MousePosition.X;
            ((Control)sender).Top = y + MousePosition.Y;
        }

        #endregion Controle do Mouse


        #region Controle do Teclado

        private void FCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Alt && e.KeyCode == Keys.Down)
            {
                this.ActiveControl.Top = this.ActiveControl.Top + 1;
            }
            if (Control.ModifierKeys == Keys.Alt && e.KeyCode == Keys.Up)
            {
                this.ActiveControl.Top = this.ActiveControl.Top - 1;
            }
            if (Control.ModifierKeys == Keys.Alt && e.KeyCode == Keys.Left)
            {
                this.ActiveControl.Left = this.ActiveControl.Left - 1;
            }
            if (Control.ModifierKeys == Keys.Alt && e.KeyCode == Keys.Right)
            {
                this.ActiveControl.Left = this.ActiveControl.Left + 1;
            }
            //
            if (e.KeyCode == Keys.F12)
            {
                if (MessageBox.Show("Deseja salvar as alterações antes de fechar a janela?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GravarAlteracoes();
                }
                this.Close();
            }
        }

        #endregion Controle do Teclado


        #region Configuração dos Componentes

        private void CarregarImagemFundo_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void EditarPropriedades_Click(object sender, System.EventArgs e)
        {
            FPropriedades FPropriedades = new FPropriedades();
            FPropriedades.GridPropriedades.SelectedObject = ActiveControl;
            FPropriedades.Text = "Propridades do Controle [ " + ActiveControl.Name + " ]";
            FPropriedades.ShowDialog();
        }

        private void GravarAlteracoes()
        {
            List<PosicaoComponentesVO>  ListaPosicoes = new List<PosicaoComponentesVO>();
            
            foreach (Control c in this.Controls)
            {
                PosicaoComponentesVO PosicaoComponente = new PosicaoComponentesVO();

                PosicaoComponente.IdResolucao = FConfiguracao.Configuracao.ResolucaoVO.Id;
                PosicaoComponente.NomeComponente = c.Name;
                PosicaoComponente.Altura = c.Height;
                PosicaoComponente.Esquerda = c.Left;
                PosicaoComponente.Topo = c.Top;
                PosicaoComponente.Largura = c.Width;

                if (c is ListBox)
                    PosicaoComponente.TamanhoFonte = Convert.ToInt32((c as ListBox).Font.Size);
                if (c is Button)
                    PosicaoComponente.TamanhoFonte = Convert.ToInt32((c as Button).Font.Size);
                if (c is TextBox)
                    PosicaoComponente.TamanhoFonte = Convert.ToInt32((c as TextBox).Font.Size);
                if (c is Label)
                {
                    PosicaoComponente.TamanhoFonte = Convert.ToInt32((c as Label).Font.Size);
                    PosicaoComponente.TextoComponente = (c as Label).Text;
                }
                if (c is LinkLabel)
                {
                    PosicaoComponente.TamanhoFonte = Convert.ToInt32((c as LinkLabel).Font.Size);
                    PosicaoComponente.TextoComponente = (c as LinkLabel).Text;
                }
                ListaPosicoes.Add(PosicaoComponente);
            }

            new ConfiguracaoController().GravarPosicaoComponentes(ListaPosicoes);
        }

        public void SetResolucao()
        {
            //TODO: Conclua o método para posicionar os componentes na tela de acordo com o que está definido no banco de dados e configurar texto e fonte (tabela ECF_POSICAO_COMPONENTES)
            List<PosicaoComponentesVO> ListaPosicoes;

            string NomeComponente;
            ListaPosicoes = new ConfiguracaoController().VerificaPosicaoTamanho();
            PosicaoComponentesVO PosicaoComponente;

            foreach (Control c in this.Controls)
            {
                NomeComponente = c.Name;
                for (int i = 0; i <= ListaPosicoes.Count - 1; i++)
                {
                    PosicaoComponente = ListaPosicoes[i];
                    if (PosicaoComponente.NomeComponente == NomeComponente)
                    {
                        if (c is LinkLabel)
                            (c as LinkLabel).SetBounds(PosicaoComponente.Esquerda, PosicaoComponente.Topo, PosicaoComponente.Largura, PosicaoComponente.Altura);
                        if (c is ListBox)
                            (c as ListBox).SetBounds(PosicaoComponente.Esquerda, PosicaoComponente.Topo, PosicaoComponente.Largura, PosicaoComponente.Altura);
                        if (c is Button)
                            (c as Button).SetBounds(PosicaoComponente.Esquerda, PosicaoComponente.Topo, PosicaoComponente.Largura, PosicaoComponente.Altura);
                        if (c is TextBox)
                            (c as TextBox).SetBounds(PosicaoComponente.Esquerda, PosicaoComponente.Topo, PosicaoComponente.Largura, PosicaoComponente.Altura);
                        if (c is Label)
                            (c as Label).SetBounds(PosicaoComponente.Esquerda, PosicaoComponente.Topo, PosicaoComponente.Largura, PosicaoComponente.Altura);
                    }
                }
            }

        }
        


        #endregion Configuração dos Componentes





    }

}
