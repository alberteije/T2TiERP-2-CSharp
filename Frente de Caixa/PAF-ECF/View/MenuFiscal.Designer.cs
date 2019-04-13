namespace PafEcf.View
{
	partial class MenuFiscal
    {
		private System.Windows.Forms.PictureBox Image1;
        private System.Windows.Forms.Panel panelMenuFiscal;
		private System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.Button btnLX;
        private System.Windows.Forms.Button btnLMF;
		private System.Windows.Forms.Button btnArquivoMF;
        private System.Windows.Forms.Button btnArqMFD;
        private System.Windows.Forms.Button btnRegistrosPaf;
		private System.Windows.Forms.Button btnIdentificacaoPafEcf;
		private System.Windows.Forms.Button btnVendasPeriodo;
		private System.Windows.Forms.Button btnIndiceTecnico;
		private System.Windows.Forms.Button btnParametrosConfig;
        private System.Windows.Forms.Panel Panel1;
		private System.Windows.Forms.Button botaoCancela;
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
            this.panelMenuFiscal = new System.Windows.Forms.Panel();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLX = new System.Windows.Forms.Button();
            this.btnLMF = new System.Windows.Forms.Button();
            this.btnArquivoMF = new System.Windows.Forms.Button();
            this.btnArqMFD = new System.Windows.Forms.Button();
            this.btnRegistrosPaf = new System.Windows.Forms.Button();
            this.btnIdentificacaoPafEcf = new System.Windows.Forms.Button();
            this.btnVendasPeriodo = new System.Windows.Forms.Button();
            this.btnIndiceTecnico = new System.Windows.Forms.Button();
            this.btnParametrosConfig = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenuFiscal
            // 
            this.panelMenuFiscal.Location = new System.Drawing.Point(547, 335);
            this.panelMenuFiscal.Name = "panelMenuFiscal";
            this.panelMenuFiscal.Size = new System.Drawing.Size(213, 362);
            this.panelMenuFiscal.TabIndex = 0;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnLX);
            this.GroupBox2.Controls.Add(this.btnLMF);
            this.GroupBox2.Controls.Add(this.btnArquivoMF);
            this.GroupBox2.Controls.Add(this.btnArqMFD);
            this.GroupBox2.Controls.Add(this.btnRegistrosPaf);
            this.GroupBox2.Controls.Add(this.btnIdentificacaoPafEcf);
            this.GroupBox2.Controls.Add(this.btnVendasPeriodo);
            this.GroupBox2.Controls.Add(this.btnIndiceTecnico);
            this.GroupBox2.Controls.Add(this.btnParametrosConfig);
            this.GroupBox2.Controls.Add(this.Panel1);
            this.GroupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(80, 10);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(433, 193);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Opções do Menu Fiscal";
            // 
            // btnLX
            // 
            this.btnLX.Location = new System.Drawing.Point(20, 30);
            this.btnLX.Name = "btnLX";
            this.btnLX.Size = new System.Drawing.Size(177, 25);
            this.btnLX.TabIndex = 0;
            this.btnLX.Text = "L&X";
            this.btnLX.Click += new System.EventHandler(this.btnLX_Click);
            // 
            // btnLMF
            // 
            this.btnLMF.Location = new System.Drawing.Point(20, 61);
            this.btnLMF.Name = "btnLMF";
            this.btnLMF.Size = new System.Drawing.Size(177, 25);
            this.btnLMF.TabIndex = 1;
            this.btnLMF.Text = "LM&F";
            this.btnLMF.Click += new System.EventHandler(this.btnLMFC_Click);
            // 
            // btnArquivoMF
            // 
            this.btnArquivoMF.Location = new System.Drawing.Point(20, 92);
            this.btnArquivoMF.Name = "btnArquivoMF";
            this.btnArquivoMF.Size = new System.Drawing.Size(177, 25);
            this.btnArquivoMF.TabIndex = 3;
            this.btnArquivoMF.Text = "Arq. &MF";
            this.btnArquivoMF.Click += new System.EventHandler(this.btnArquivoMF_Click);
            // 
            // btnArqMFD
            // 
            this.btnArqMFD.Location = new System.Drawing.Point(20, 123);
            this.btnArqMFD.Name = "btnArqMFD";
            this.btnArqMFD.Size = new System.Drawing.Size(177, 25);
            this.btnArqMFD.TabIndex = 4;
            this.btnArqMFD.Text = "A&rq. MFD";
            this.btnArqMFD.Click += new System.EventHandler(this.btnArqMFD_Click);
            // 
            // btnRegistrosPaf
            // 
            this.btnRegistrosPaf.Location = new System.Drawing.Point(230, 154);
            this.btnRegistrosPaf.Name = "btnRegistrosPaf";
            this.btnRegistrosPaf.Size = new System.Drawing.Size(177, 25);
            this.btnRegistrosPaf.TabIndex = 7;
            this.btnRegistrosPaf.Text = "Registros do &PAF-ECF";
            this.btnRegistrosPaf.Click += new System.EventHandler(this.btnRegistrosPaf_Click);
            // 
            // btnIdentificacaoPafEcf
            // 
            this.btnIdentificacaoPafEcf.Location = new System.Drawing.Point(230, 30);
            this.btnIdentificacaoPafEcf.Name = "btnIdentificacaoPafEcf";
            this.btnIdentificacaoPafEcf.Size = new System.Drawing.Size(177, 25);
            this.btnIdentificacaoPafEcf.TabIndex = 10;
            this.btnIdentificacaoPafEcf.Text = "Identi&ficação do PAF-ECF";
            this.btnIdentificacaoPafEcf.Click += new System.EventHandler(this.btnIdentificacaoPafEcf_Click);
            // 
            // btnVendasPeriodo
            // 
            this.btnVendasPeriodo.Location = new System.Drawing.Point(230, 61);
            this.btnVendasPeriodo.Name = "btnVendasPeriodo";
            this.btnVendasPeriodo.Size = new System.Drawing.Size(177, 25);
            this.btnVendasPeriodo.TabIndex = 11;
            this.btnVendasPeriodo.Text = "Ve&ndas do Período";
            this.btnVendasPeriodo.Click += new System.EventHandler(this.btnVendasPeriodo_Click);
            // 
            // btnIndiceTecnico
            // 
            this.btnIndiceTecnico.Location = new System.Drawing.Point(230, 92);
            this.btnIndiceTecnico.Name = "btnIndiceTecnico";
            this.btnIndiceTecnico.Size = new System.Drawing.Size(177, 25);
            this.btnIndiceTecnico.TabIndex = 12;
            this.btnIndiceTecnico.Text = "Tab. índice Técnico Prod&ução";
            this.btnIndiceTecnico.Click += new System.EventHandler(this.btnIndiceTecnico_Click);
            // 
            // btnParametrosConfig
            // 
            this.btnParametrosConfig.Location = new System.Drawing.Point(230, 123);
            this.btnParametrosConfig.Name = "btnParametrosConfig";
            this.btnParametrosConfig.Size = new System.Drawing.Size(177, 25);
            this.btnParametrosConfig.TabIndex = 13;
            this.btnParametrosConfig.Text = "Parâmetros de Confi&guração";
            this.btnParametrosConfig.Click += new System.EventHandler(this.btnParametrosConfig_Click);
            // 
            // Panel1
            // 
            this.Panel1.Location = new System.Drawing.Point(213, 30);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(4, 150);
            this.Panel1.TabIndex = 14;
            // 
            // Image1
            // 
            this.Image1.Image = global::PafEcf.Properties.Resources.telaRegistradora01;
            this.Image1.Location = new System.Drawing.Point(10, 10);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 0;
            this.Image1.TabStop = false;
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::PafEcf.Properties.Resources.cancelar16;
            this.botaoCancela.Location = new System.Drawing.Point(393, 213);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 3;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // MenuFiscal
            // 
            this.ClientSize = new System.Drawing.Size(536, 250);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.panelMenuFiscal);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.botaoCancela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(188, 429);
            this.Name = "MenuFiscal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Fiscal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FMenuFiscal_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

	}
}
