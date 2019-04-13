namespace PafEcf.View
{
	partial class VendasPeriodo
    {
		private System.Windows.Forms.GroupBox RadioGroup2;
		internal System.Windows.Forms.RadioButton cbGerarSintegra;
        internal System.Windows.Forms.RadioButton cbGerarSped;
		private System.Windows.Forms.TabControl TabControl1;
		private System.Windows.Forms.TabPage PaginaSintegra;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.ComboBox ComboBoxConvenio;
		internal System.Windows.Forms.ComboBox ComboBoxNaturezaInformacoes;
		internal System.Windows.Forms.ComboBox ComboBoxFinalidadeArquivo;
		private System.Windows.Forms.TabPage PaginaSped;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.ComboBox ComboBoxVersaoLeiauteSped;
		internal System.Windows.Forms.ComboBox ComboBoxFinalidadeArquivoSped;
		internal System.Windows.Forms.ComboBox ComboBoxPerfilSped;
		// Required designer variable.
		private System.ComponentModel.IContainer components = null;

		// Clean up any resources being used.
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.RadioGroup2 = new System.Windows.Forms.GroupBox();
            this.cbGerarSintegra = new System.Windows.Forms.RadioButton();
            this.cbGerarSped = new System.Windows.Forms.RadioButton();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.PaginaSintegra = new System.Windows.Forms.TabPage();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.ComboBoxConvenio = new System.Windows.Forms.ComboBox();
            this.ComboBoxNaturezaInformacoes = new System.Windows.Forms.ComboBox();
            this.ComboBoxFinalidadeArquivo = new System.Windows.Forms.ComboBox();
            this.PaginaSped = new System.Windows.Forms.TabPage();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.ComboBoxVersaoLeiauteSped = new System.Windows.Forms.ComboBox();
            this.ComboBoxFinalidadeArquivoSped = new System.Windows.Forms.ComboBox();
            this.ComboBoxPerfilSped = new System.Windows.Forms.ComboBox();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.panPeriodo = new System.Windows.Forms.Panel();
            this.mkeDataFim = new System.Windows.Forms.MaskedTextBox();
            this.mkeDataIni = new System.Windows.Forms.MaskedTextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.RadioGroup2.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.PaginaSintegra.SuspendLayout();
            this.PaginaSped.SuspendLayout();
            this.panPeriodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.SuspendLayout();
            // 
            // RadioGroup2
            // 
            this.RadioGroup2.Controls.Add(this.cbGerarSintegra);
            this.RadioGroup2.Controls.Add(this.cbGerarSped);
            this.RadioGroup2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RadioGroup2.ForeColor = System.Drawing.Color.Black;
            this.RadioGroup2.Location = new System.Drawing.Point(72, 12);
            this.RadioGroup2.Name = "RadioGroup2";
            this.RadioGroup2.Size = new System.Drawing.Size(405, 72);
            this.RadioGroup2.TabIndex = 0;
            this.RadioGroup2.TabStop = false;
            this.RadioGroup2.Text = "Tipo de Filtro:";
            // 
            // cbGerarSintegra
            // 
            this.cbGerarSintegra.AutoSize = true;
            this.cbGerarSintegra.Location = new System.Drawing.Point(12, 18);
            this.cbGerarSintegra.Name = "cbGerarSintegra";
            this.cbGerarSintegra.Size = new System.Drawing.Size(327, 17);
            this.cbGerarSintegra.TabIndex = 0;
            this.cbGerarSintegra.Text = "Gerar arquivo no layout do Convênio 57/95 - Sintegra";
            this.cbGerarSintegra.Click += new System.EventHandler(this.cbGerarSintegra_Click);
            // 
            // cbGerarSped
            // 
            this.cbGerarSped.AutoSize = true;
            this.cbGerarSped.Location = new System.Drawing.Point(12, 38);
            this.cbGerarSped.Name = "cbGerarSped";
            this.cbGerarSped.Size = new System.Drawing.Size(388, 17);
            this.cbGerarSped.TabIndex = 1;
            this.cbGerarSped.Text = "Gerar arquivo no layout do Ato COTEPE/ICMS 09/08 - SPED Fiscal";
            this.cbGerarSped.Click += new System.EventHandler(this.cbGerarSped_Click);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.PaginaSintegra);
            this.TabControl1.Controls.Add(this.PaginaSped);
            this.TabControl1.Location = new System.Drawing.Point(72, 95);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(405, 178);
            this.TabControl1.TabIndex = 0;
            // 
            // PaginaSintegra
            // 
            this.PaginaSintegra.Controls.Add(this.Label3);
            this.PaginaSintegra.Controls.Add(this.Label4);
            this.PaginaSintegra.Controls.Add(this.Label5);
            this.PaginaSintegra.Controls.Add(this.ComboBoxConvenio);
            this.PaginaSintegra.Controls.Add(this.ComboBoxNaturezaInformacoes);
            this.PaginaSintegra.Controls.Add(this.ComboBoxFinalidadeArquivo);
            this.PaginaSintegra.Location = new System.Drawing.Point(4, 22);
            this.PaginaSintegra.Name = "PaginaSintegra";
            this.PaginaSintegra.Size = new System.Drawing.Size(397, 152);
            this.PaginaSintegra.TabIndex = 0;
            this.PaginaSintegra.Text = "Informações Sintegra";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(6, 5);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(107, 13);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Código do Convênio:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(6, 52);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(138, 13);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "Natureza das Informações:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(6, 99);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(114, 13);
            this.Label5.TabIndex = 2;
            this.Label5.Text = "Finalidade do Arquivo:";
            // 
            // ComboBoxConvenio
            // 
            this.ComboBoxConvenio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxConvenio.FormattingEnabled = true;
            this.ComboBoxConvenio.Items.AddRange(new object[] {
            "1 - Convênio 57/95 Versão 31/99 Alt. 30/02",
            "2 - Convênio 57/95 Versão 69/02 Alt. 142/02",
            "3 - Convênio 57/95 Alt. 76/03"});
            this.ComboBoxConvenio.Location = new System.Drawing.Point(6, 22);
            this.ComboBoxConvenio.Name = "ComboBoxConvenio";
            this.ComboBoxConvenio.Size = new System.Drawing.Size(379, 21);
            this.ComboBoxConvenio.TabIndex = 0;
            // 
            // ComboBoxNaturezaInformacoes
            // 
            this.ComboBoxNaturezaInformacoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxNaturezaInformacoes.FormattingEnabled = true;
            this.ComboBoxNaturezaInformacoes.Items.AddRange(new object[] {
            "1 - Interestaduais - Somente operações sujeitas a Substituição Tributária",
            "2 - Interestaduais - Operações com ou sem Substituição Tributária",
            "3 - Totalidade das operações do informante"});
            this.ComboBoxNaturezaInformacoes.Location = new System.Drawing.Point(6, 68);
            this.ComboBoxNaturezaInformacoes.Name = "ComboBoxNaturezaInformacoes";
            this.ComboBoxNaturezaInformacoes.Size = new System.Drawing.Size(379, 21);
            this.ComboBoxNaturezaInformacoes.TabIndex = 1;
            // 
            // ComboBoxFinalidadeArquivo
            // 
            this.ComboBoxFinalidadeArquivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFinalidadeArquivo.FormattingEnabled = true;
            this.ComboBoxFinalidadeArquivo.Items.AddRange(new object[] {
            "1 - Normal",
            "2 - Retificação total de arquivo",
            "3 - Retificação aditiva de arquivo",
            "5 - Desfazimento"});
            this.ComboBoxFinalidadeArquivo.Location = new System.Drawing.Point(6, 115);
            this.ComboBoxFinalidadeArquivo.Name = "ComboBoxFinalidadeArquivo";
            this.ComboBoxFinalidadeArquivo.Size = new System.Drawing.Size(379, 21);
            this.ComboBoxFinalidadeArquivo.TabIndex = 2;
            // 
            // PaginaSped
            // 
            this.PaginaSped.Controls.Add(this.Label6);
            this.PaginaSped.Controls.Add(this.Label7);
            this.PaginaSped.Controls.Add(this.Label8);
            this.PaginaSped.Controls.Add(this.ComboBoxVersaoLeiauteSped);
            this.PaginaSped.Controls.Add(this.ComboBoxFinalidadeArquivoSped);
            this.PaginaSped.Controls.Add(this.ComboBoxPerfilSped);
            this.PaginaSped.Location = new System.Drawing.Point(4, 22);
            this.PaginaSped.Name = "PaginaSped";
            this.PaginaSped.Size = new System.Drawing.Size(397, 152);
            this.PaginaSped.TabIndex = 0;
            this.PaginaSped.Text = "Informações SPED Fiscal";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(6, 5);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(97, 13);
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Versão do Leiaute:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(6, 52);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(114, 13);
            this.Label7.TabIndex = 1;
            this.Label7.Text = "Finalidade do Arquivo:";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(6, 99);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(175, 13);
            this.Label8.TabIndex = 2;
            this.Label8.Text = "Perfil de Apresentação do Arquivo:";
            // 
            // ComboBoxVersaoLeiauteSped
            // 
            this.ComboBoxVersaoLeiauteSped.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxVersaoLeiauteSped.FormattingEnabled = true;
            this.ComboBoxVersaoLeiauteSped.Items.AddRange(new object[] {
            "001 - Versão 100 Ato COTEPE 01/01/2008",
            "002 - Versão 101 Ato COTEPE 01/01/2009",
            "003 - Versão 102 Ato COTEPE 01/01/2010",
            "004 - Versão 103 Ato COTEPE 01/01/2011"});
            this.ComboBoxVersaoLeiauteSped.Location = new System.Drawing.Point(6, 22);
            this.ComboBoxVersaoLeiauteSped.Name = "ComboBoxVersaoLeiauteSped";
            this.ComboBoxVersaoLeiauteSped.Size = new System.Drawing.Size(379, 21);
            this.ComboBoxVersaoLeiauteSped.TabIndex = 0;
            // 
            // ComboBoxFinalidadeArquivoSped
            // 
            this.ComboBoxFinalidadeArquivoSped.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFinalidadeArquivoSped.FormattingEnabled = true;
            this.ComboBoxFinalidadeArquivoSped.Items.AddRange(new object[] {
            "0 - Remessa do arquivo original",
            "1 - Remessa do arquivo substituto"});
            this.ComboBoxFinalidadeArquivoSped.Location = new System.Drawing.Point(6, 68);
            this.ComboBoxFinalidadeArquivoSped.Name = "ComboBoxFinalidadeArquivoSped";
            this.ComboBoxFinalidadeArquivoSped.Size = new System.Drawing.Size(379, 21);
            this.ComboBoxFinalidadeArquivoSped.TabIndex = 1;
            // 
            // ComboBoxPerfilSped
            // 
            this.ComboBoxPerfilSped.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPerfilSped.FormattingEnabled = true;
            this.ComboBoxPerfilSped.Items.AddRange(new object[] {
            "A - Perfil A",
            "B - Perfil B",
            "C - Perfil C"});
            this.ComboBoxPerfilSped.Location = new System.Drawing.Point(6, 115);
            this.ComboBoxPerfilSped.Name = "ComboBoxPerfilSped";
            this.ComboBoxPerfilSped.Size = new System.Drawing.Size(379, 21);
            this.ComboBoxPerfilSped.TabIndex = 2;
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::PafEcf.Properties.Resources.cancelar16;
            this.botaoCancela.Location = new System.Drawing.Point(357, 291);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 25;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // panPeriodo
            // 
            this.panPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panPeriodo.Controls.Add(this.mkeDataFim);
            this.panPeriodo.Controls.Add(this.mkeDataIni);
            this.panPeriodo.Controls.Add(this.Label1);
            this.panPeriodo.Controls.Add(this.Label2);
            this.panPeriodo.Location = new System.Drawing.Point(72, 290);
            this.panPeriodo.Name = "panPeriodo";
            this.panPeriodo.Size = new System.Drawing.Size(279, 57);
            this.panPeriodo.TabIndex = 23;
            // 
            // mkeDataFim
            // 
            this.mkeDataFim.Location = new System.Drawing.Point(154, 28);
            this.mkeDataFim.Mask = "##/##/####";
            this.mkeDataFim.Name = "mkeDataFim";
            this.mkeDataFim.Size = new System.Drawing.Size(75, 20);
            this.mkeDataFim.TabIndex = 5;
            // 
            // mkeDataIni
            // 
            this.mkeDataIni.Location = new System.Drawing.Point(41, 28);
            this.mkeDataIni.Mask = "##/##/####";
            this.mkeDataIni.Name = "mkeDataIni";
            this.mkeDataIni.Size = new System.Drawing.Size(75, 20);
            this.mkeDataIni.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(38, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Data Inicial:";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(151, 12);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Data Final:";
            // 
            // Image1
            // 
            this.Image1.Image = global::PafEcf.Properties.Resources.telaRegistradora01;
            this.Image1.Location = new System.Drawing.Point(12, 12);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 22;
            this.Image1.TabStop = false;
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::PafEcf.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(357, 324);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 24;
            this.botaoConfirma.Text = "&Confirma (F12)";
            this.botaoConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoConfirma.Click += new System.EventHandler(this.botaoConfirma_Click);
            // 
            // FVendasPeriodo
            // 
            this.ClientSize = new System.Drawing.Size(490, 360);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.panPeriodo);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.RadioGroup2);
            this.Controls.Add(this.TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(251, 387);
            this.Name = "FVendasPeriodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendas do Período";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FVendasPeriodo_KeyDown);
            this.RadioGroup2.ResumeLayout(false);
            this.RadioGroup2.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.PaginaSintegra.ResumeLayout(false);
            this.PaginaSintegra.PerformLayout();
            this.PaginaSped.ResumeLayout(false);
            this.PaginaSped.PerformLayout();
            this.panPeriodo.ResumeLayout(false);
            this.panPeriodo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.Button botaoCancela;
        private System.Windows.Forms.Panel panPeriodo;
        private System.Windows.Forms.MaskedTextBox mkeDataFim;
        private System.Windows.Forms.MaskedTextBox mkeDataIni;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.PictureBox Image1;
        private System.Windows.Forms.Button botaoConfirma;

	}
}
