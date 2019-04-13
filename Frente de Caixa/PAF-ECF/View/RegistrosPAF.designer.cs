namespace PafEcf.View
{
	partial class RegistrosPAF
    {
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
            this.editFim = new System.Windows.Forms.MaskedTextBox();
            this.panCodigo = new System.Windows.Forms.Panel();
            this.editInicio = new System.Windows.Forms.MaskedTextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.cbEstoqueTotal = new System.Windows.Forms.RadioButton();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.cbEstoqueParcial = new System.Windows.Forms.RadioButton();
            this.RadioGroup1 = new System.Windows.Forms.GroupBox();
            this.editNomeInicial = new System.Windows.Forms.TextBox();
            this.cbDescricaoMercadoria = new System.Windows.Forms.RadioButton();
            this.panDescricao = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.editNomeFinal = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.cbCodigoProduto = new System.Windows.Forms.RadioButton();
            this.RadioGroup2 = new System.Windows.Forms.GroupBox();
            this.panPeriodo = new System.Windows.Forms.Panel();
            this.mkeDataFim = new System.Windows.Forms.MaskedTextBox();
            this.mkeDataIni = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.RadioGroup1.SuspendLayout();
            this.panDescricao.SuspendLayout();
            this.RadioGroup2.SuspendLayout();
            this.panPeriodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // editFim
            // 
            this.editFim.Location = new System.Drawing.Point(114, 28);
            this.editFim.Name = "editFim";
            this.editFim.Size = new System.Drawing.Size(75, 20);
            this.editFim.TabIndex = 5;
            this.editFim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panCodigo
            // 
            this.panCodigo.Controls.Add(this.editFim);
            this.panCodigo.Controls.Add(this.editInicio);
            this.panCodigo.Controls.Add(this.Label1);
            this.panCodigo.Controls.Add(this.Label2);
            this.panCodigo.Location = new System.Drawing.Point(81, 209);
            this.panCodigo.Name = "panCodigo";
            this.panCodigo.Size = new System.Drawing.Size(217, 57);
            this.panCodigo.TabIndex = 21;
            // 
            // editInicio
            // 
            this.editInicio.Location = new System.Drawing.Point(14, 28);
            this.editInicio.Name = "editInicio";
            this.editInicio.Size = new System.Drawing.Size(75, 20);
            this.editInicio.TabIndex = 4;
            this.editInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(11, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Primeiro:";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(111, 12);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Último:";
            // 
            // Image1
            // 
            this.Image1.Image = global::PafEcf.Properties.Resources.telaRegistradora01;
            this.Image1.Location = new System.Drawing.Point(13, 10);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 20;
            this.Image1.TabStop = false;
            // 
            // cbEstoqueTotal
            // 
            this.cbEstoqueTotal.AutoSize = true;
            this.cbEstoqueTotal.Location = new System.Drawing.Point(12, 18);
            this.cbEstoqueTotal.Name = "cbEstoqueTotal";
            this.cbEstoqueTotal.Size = new System.Drawing.Size(117, 17);
            this.cbEstoqueTotal.TabIndex = 0;
            this.cbEstoqueTotal.Text = "a) Estoque Total";
            this.cbEstoqueTotal.Click += new System.EventHandler(this.cbEstoqueTotal_Click);
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::PafEcf.Properties.Resources.cancelar16;
            this.botaoCancela.Location = new System.Drawing.Point(414, 283);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 24;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // cbEstoqueParcial
            // 
            this.cbEstoqueParcial.AutoSize = true;
            this.cbEstoqueParcial.Location = new System.Drawing.Point(12, 42);
            this.cbEstoqueParcial.Name = "cbEstoqueParcial";
            this.cbEstoqueParcial.Size = new System.Drawing.Size(126, 17);
            this.cbEstoqueParcial.TabIndex = 1;
            this.cbEstoqueParcial.Text = "b) Estoque Parcial";
            this.cbEstoqueParcial.Click += new System.EventHandler(this.cbEstoqueParcial_Click);
            // 
            // RadioGroup1
            // 
            this.RadioGroup1.Controls.Add(this.cbEstoqueTotal);
            this.RadioGroup1.Controls.Add(this.cbEstoqueParcial);
            this.RadioGroup1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RadioGroup1.ForeColor = System.Drawing.Color.Black;
            this.RadioGroup1.Location = new System.Drawing.Point(80, 66);
            this.RadioGroup1.Name = "RadioGroup1";
            this.RadioGroup1.Size = new System.Drawing.Size(449, 70);
            this.RadioGroup1.TabIndex = 18;
            this.RadioGroup1.TabStop = false;
            this.RadioGroup1.Text = "Subcategoria:";
            // 
            // editNomeInicial
            // 
            this.editNomeInicial.Location = new System.Drawing.Point(19, 28);
            this.editNomeInicial.Name = "editNomeInicial";
            this.editNomeInicial.Size = new System.Drawing.Size(80, 20);
            this.editNomeInicial.TabIndex = 0;
            // 
            // cbDescricaoMercadoria
            // 
            this.cbDescricaoMercadoria.AutoSize = true;
            this.cbDescricaoMercadoria.Location = new System.Drawing.Point(251, 22);
            this.cbDescricaoMercadoria.Name = "cbDescricaoMercadoria";
            this.cbDescricaoMercadoria.Size = new System.Drawing.Size(164, 17);
            this.cbDescricaoMercadoria.TabIndex = 1;
            this.cbDescricaoMercadoria.Text = "Descrição da Mercadoria";
            this.cbDescricaoMercadoria.Click += new System.EventHandler(this.cbDescricaoMercadoria_Click);
            // 
            // panDescricao
            // 
            this.panDescricao.Controls.Add(this.editNomeInicial);
            this.panDescricao.Controls.Add(this.Label3);
            this.panDescricao.Controls.Add(this.editNomeFinal);
            this.panDescricao.Controls.Add(this.Label4);
            this.panDescricao.Enabled = false;
            this.panDescricao.Location = new System.Drawing.Point(313, 209);
            this.panDescricao.Name = "panDescricao";
            this.panDescricao.Size = new System.Drawing.Size(217, 57);
            this.panDescricao.TabIndex = 22;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(16, 12);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(61, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Parte 01:";
            // 
            // editNomeFinal
            // 
            this.editNomeFinal.Location = new System.Drawing.Point(120, 28);
            this.editNomeFinal.Name = "editNomeFinal";
            this.editNomeFinal.Size = new System.Drawing.Size(80, 20);
            this.editNomeFinal.TabIndex = 1;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(117, 12);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(75, 13);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "ou Parte 02:";
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::PafEcf.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(280, 283);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 23;
            this.botaoConfirma.Text = "&Confirma (F12)";
            this.botaoConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoConfirma.Click += new System.EventHandler(this.botaoConfirma_Click);
            // 
            // cbCodigoProduto
            // 
            this.cbCodigoProduto.AutoSize = true;
            this.cbCodigoProduto.Location = new System.Drawing.Point(14, 22);
            this.cbCodigoProduto.Name = "cbCodigoProduto";
            this.cbCodigoProduto.Size = new System.Drawing.Size(128, 17);
            this.cbCodigoProduto.TabIndex = 0;
            this.cbCodigoProduto.Text = "Código do Produto";
            this.cbCodigoProduto.Click += new System.EventHandler(this.cbCodigoProduto_Click);
            // 
            // RadioGroup2
            // 
            this.RadioGroup2.Controls.Add(this.cbCodigoProduto);
            this.RadioGroup2.Controls.Add(this.cbDescricaoMercadoria);
            this.RadioGroup2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RadioGroup2.ForeColor = System.Drawing.Color.Black;
            this.RadioGroup2.Location = new System.Drawing.Point(81, 145);
            this.RadioGroup2.Name = "RadioGroup2";
            this.RadioGroup2.Size = new System.Drawing.Size(449, 50);
            this.RadioGroup2.TabIndex = 19;
            this.RadioGroup2.TabStop = false;
            this.RadioGroup2.Text = "Tipo de Filtro:";
            // 
            // panPeriodo
            // 
            this.panPeriodo.Controls.Add(this.mkeDataFim);
            this.panPeriodo.Controls.Add(this.mkeDataIni);
            this.panPeriodo.Controls.Add(this.label5);
            this.panPeriodo.Controls.Add(this.label6);
            this.panPeriodo.Location = new System.Drawing.Point(313, 12);
            this.panPeriodo.Name = "panPeriodo";
            this.panPeriodo.Size = new System.Drawing.Size(217, 55);
            this.panPeriodo.TabIndex = 25;
            // 
            // mkeDataFim
            // 
            this.mkeDataFim.Location = new System.Drawing.Point(114, 28);
            this.mkeDataFim.Mask = "##/##/####";
            this.mkeDataFim.Name = "mkeDataFim";
            this.mkeDataFim.Size = new System.Drawing.Size(75, 20);
            this.mkeDataFim.TabIndex = 5;
            // 
            // mkeDataIni
            // 
            this.mkeDataIni.Location = new System.Drawing.Point(14, 28);
            this.mkeDataIni.Mask = "##/##/####";
            this.mkeDataIni.Name = "mkeDataIni";
            this.mkeDataIni.Size = new System.Drawing.Size(75, 20);
            this.mkeDataIni.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(11, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Data Inicial:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(111, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Data Final:";
            // 
            // RegistrosPAF
            // 
            this.ClientSize = new System.Drawing.Size(546, 318);
            this.Controls.Add(this.panPeriodo);
            this.Controls.Add(this.panCodigo);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.RadioGroup1);
            this.Controls.Add(this.panDescricao);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.RadioGroup2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(308, 368);
            this.Name = "RegistrosPAF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registros do PAF";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FEstoque_KeyDown);
            this.panCodigo.ResumeLayout(false);
            this.panCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.RadioGroup1.ResumeLayout(false);
            this.RadioGroup1.PerformLayout();
            this.panDescricao.ResumeLayout(false);
            this.panDescricao.PerformLayout();
            this.RadioGroup2.ResumeLayout(false);
            this.RadioGroup2.PerformLayout();
            this.panPeriodo.ResumeLayout(false);
            this.panPeriodo.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.MaskedTextBox editFim;
        private System.Windows.Forms.Panel panCodigo;
        private System.Windows.Forms.MaskedTextBox editInicio;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.PictureBox Image1;
        internal System.Windows.Forms.RadioButton cbEstoqueTotal;
        private System.Windows.Forms.Button botaoCancela;
        internal System.Windows.Forms.RadioButton cbEstoqueParcial;
        private System.Windows.Forms.GroupBox RadioGroup1;
        internal System.Windows.Forms.TextBox editNomeInicial;
        internal System.Windows.Forms.RadioButton cbDescricaoMercadoria;
        private System.Windows.Forms.Panel panDescricao;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox editNomeFinal;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Button botaoConfirma;
        internal System.Windows.Forms.RadioButton cbCodigoProduto;
        private System.Windows.Forms.GroupBox RadioGroup2;
        private System.Windows.Forms.Panel panPeriodo;
        private System.Windows.Forms.MaskedTextBox mkeDataFim;
        private System.Windows.Forms.MaskedTextBox mkeDataIni;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;

	}
}
