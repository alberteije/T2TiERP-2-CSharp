namespace NFCe.View
{
	partial class ImportaProduto
    {
		private System.Windows.Forms.PictureBox Image1;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.DataGridView GridPrincipal;
		private System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button SpeedButton1;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.GridPrincipal = new System.Windows.Forms.DataGridView();
            this.GTIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_UNIDADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_VALOR_VENDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_QTD_ESTOQUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_IPPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_IAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_ECF_ICMS_ST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_CODIGO_INTERNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_ESTOQUE_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_ESTOQUE_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.EditLocaliza = new System.Windows.Forms.TextBox();
            this.SpeedButton1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Image1
            // 
            this.Image1.Image = global::NFCe.Properties.Resources.botaoPesquisa;
            this.Image1.Location = new System.Drawing.Point(9, 296);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 0;
            this.Image1.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(68, 320);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(0, 13);
            this.Label2.TabIndex = 1;
            // 
            // GridPrincipal
            // 
            this.GridPrincipal.AllowUserToAddRows = false;
            this.GridPrincipal.AllowUserToDeleteRows = false;
            this.GridPrincipal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GTIN,
            this.GridPrincipal_NOME,
            this.GridPrincipal_UNIDADE,
            this.GridPrincipal_VALOR_VENDA,
            this.GridPrincipal_QTD_ESTOQUE,
            this.GridPrincipal_IPPT,
            this.GridPrincipal_IAT,
            this.GridPrincipal_ECF_ICMS_ST,
            this.GridPrincipal_CODIGO_INTERNO,
            this.GridPrincipal_ESTOQUE_MIN,
            this.GridPrincipal_ESTOQUE_MAX});
            this.GridPrincipal.Font = new System.Drawing.Font("Tahoma", 8F);
            this.GridPrincipal.Location = new System.Drawing.Point(68, 10);
            this.GridPrincipal.Name = "GridPrincipal";
            this.GridPrincipal.ReadOnly = true;
            this.GridPrincipal.Size = new System.Drawing.Size(613, 231);
            this.GridPrincipal.TabIndex = 1;
            this.GridPrincipal.Text = "Select columns";
            this.GridPrincipal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridPrincipal_KeyDown);
            // 
            // GTIN
            // 
            this.GTIN.DataPropertyName = "GTIN";
            this.GTIN.HeaderText = "GTIN";
            this.GTIN.Name = "GTIN";
            this.GTIN.ReadOnly = true;
            this.GTIN.Width = 110;
            // 
            // GridPrincipal_NOME
            // 
            this.GridPrincipal_NOME.DataPropertyName = "Nome";
            this.GridPrincipal_NOME.HeaderText = "Descrição da Mercadoria ou Serviço";
            this.GridPrincipal_NOME.Name = "GridPrincipal_NOME";
            this.GridPrincipal_NOME.ReadOnly = true;
            this.GridPrincipal_NOME.Width = 300;
            // 
            // GridPrincipal_UNIDADE
            // 
            this.GridPrincipal_UNIDADE.DataPropertyName = "UnidadeProduto";
            this.GridPrincipal_UNIDADE.HeaderText = "Unidade";
            this.GridPrincipal_UNIDADE.Name = "GridPrincipal_UNIDADE";
            this.GridPrincipal_UNIDADE.ReadOnly = true;
            // 
            // GridPrincipal_VALOR_VENDA
            // 
            this.GridPrincipal_VALOR_VENDA.DataPropertyName = "ValorVenda";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.GridPrincipal_VALOR_VENDA.DefaultCellStyle = dataGridViewCellStyle1;
            this.GridPrincipal_VALOR_VENDA.HeaderText = "Valor Unitário";
            this.GridPrincipal_VALOR_VENDA.Name = "GridPrincipal_VALOR_VENDA";
            this.GridPrincipal_VALOR_VENDA.ReadOnly = true;
            // 
            // GridPrincipal_QTD_ESTOQUE
            // 
            this.GridPrincipal_QTD_ESTOQUE.DataPropertyName = "QtdeEstoque";
            this.GridPrincipal_QTD_ESTOQUE.HeaderText = "Qtde. Estoque";
            this.GridPrincipal_QTD_ESTOQUE.Name = "GridPrincipal_QTD_ESTOQUE";
            this.GridPrincipal_QTD_ESTOQUE.ReadOnly = true;
            // 
            // GridPrincipal_IPPT
            // 
            this.GridPrincipal_IPPT.DataPropertyName = "IPPT";
            this.GridPrincipal_IPPT.HeaderText = "IPPT";
            this.GridPrincipal_IPPT.Name = "GridPrincipal_IPPT";
            this.GridPrincipal_IPPT.ReadOnly = true;
            // 
            // GridPrincipal_IAT
            // 
            this.GridPrincipal_IAT.DataPropertyName = "IAT";
            this.GridPrincipal_IAT.HeaderText = "IAT";
            this.GridPrincipal_IAT.Name = "GridPrincipal_IAT";
            this.GridPrincipal_IAT.ReadOnly = true;
            // 
            // GridPrincipal_ECF_ICMS_ST
            // 
            this.GridPrincipal_ECF_ICMS_ST.DataPropertyName = "ECFICMS";
            this.GridPrincipal_ECF_ICMS_ST.HeaderText = "Situação Tributária";
            this.GridPrincipal_ECF_ICMS_ST.Name = "GridPrincipal_ECF_ICMS_ST";
            this.GridPrincipal_ECF_ICMS_ST.ReadOnly = true;
            // 
            // GridPrincipal_CODIGO_INTERNO
            // 
            this.GridPrincipal_CODIGO_INTERNO.DataPropertyName = "CodigoInterno";
            this.GridPrincipal_CODIGO_INTERNO.HeaderText = "Código Interno";
            this.GridPrincipal_CODIGO_INTERNO.Name = "GridPrincipal_CODIGO_INTERNO";
            this.GridPrincipal_CODIGO_INTERNO.ReadOnly = true;
            // 
            // GridPrincipal_ESTOQUE_MIN
            // 
            this.GridPrincipal_ESTOQUE_MIN.DataPropertyName = "EstoqueMinimo";
            this.GridPrincipal_ESTOQUE_MIN.HeaderText = "Estoque Mínimo";
            this.GridPrincipal_ESTOQUE_MIN.Name = "GridPrincipal_ESTOQUE_MIN";
            this.GridPrincipal_ESTOQUE_MIN.ReadOnly = true;
            // 
            // GridPrincipal_ESTOQUE_MAX
            // 
            this.GridPrincipal_ESTOQUE_MAX.DataPropertyName = "EstoqueMaximo";
            this.GridPrincipal_ESTOQUE_MAX.HeaderText = "Estoque Máximo";
            this.GridPrincipal_ESTOQUE_MAX.Name = "GridPrincipal_ESTOQUE_MAX";
            this.GridPrincipal_ESTOQUE_MAX.ReadOnly = true;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel1.Controls.Add(this.EditLocaliza);
            this.Panel1.Controls.Add(this.SpeedButton1);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(68, 247);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(613, 58);
            this.Panel1.TabIndex = 0;
            // 
            // EditLocaliza
            // 
            this.EditLocaliza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EditLocaliza.Location = new System.Drawing.Point(10, 27);
            this.EditLocaliza.Name = "EditLocaliza";
            this.EditLocaliza.Size = new System.Drawing.Size(485, 20);
            this.EditLocaliza.TabIndex = 0;
            // 
            // SpeedButton1
            // 
            this.SpeedButton1.BackColor = System.Drawing.Color.White;
            this.SpeedButton1.Location = new System.Drawing.Point(497, 27);
            this.SpeedButton1.Name = "SpeedButton1";
            this.SpeedButton1.Size = new System.Drawing.Size(105, 21);
            this.SpeedButton1.TabIndex = 5;
            this.SpeedButton1.Text = "Localiza (F2)";
            this.SpeedButton1.UseVisualStyleBackColor = false;
            this.SpeedButton1.Click += new System.EventHandler(this.SpeedButton1_Click);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(7, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(79, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Procura por:";
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::NFCe.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(429, 317);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 3;
            this.botaoConfirma.Text = "&Confirma (F12)";
            this.botaoConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoConfirma.Click += new System.EventHandler(this.botaoConfirma_Click);
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::NFCe.Properties.Resources.cancelar16;
            this.botaoCancela.Location = new System.Drawing.Point(561, 317);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 4;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::NFCe.Properties.Resources.body;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 351);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // ImportaProduto
            // 
            this.ClientSize = new System.Drawing.Size(692, 351);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.GridPrincipal);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(226, 359);
            this.Name = "ImportaProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Localiza Produto";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FImportaProduto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.Button botaoConfirma;
        private System.Windows.Forms.Button botaoCancela;
        public System.Windows.Forms.TextBox EditLocaliza;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_UNIDADE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_VALOR_VENDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_QTD_ESTOQUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_IPPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_IAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_ECF_ICMS_ST;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_CODIGO_INTERNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_ESTOQUE_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_ESTOQUE_MAX;
        private System.Windows.Forms.PictureBox pictureBox1;

	}
}
