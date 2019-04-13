namespace PafEcf.View
{
	partial class FichaTecnica
    {
        private System.Windows.Forms.PictureBox Image1;
		private System.Windows.Forms.Panel TPanel1;
		internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.DataGridView GridPrincipal;
		private System.Windows.Forms.Panel Panel3;
		internal System.Windows.Forms.Label Label5;
		private System.Windows.Forms.Button SpeedButton1;
        internal System.Windows.Forms.TextBox EditLocaliza;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.DataGridView GridComposicao;
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
			//base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.TPanel1 = new System.Windows.Forms.Panel();
            this.GridPrincipal = new System.Windows.Forms.DataGridView();
            this.GridPrincipal_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_UNIDADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_VALOR_VENDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.EditLocaliza = new System.Windows.Forms.TextBox();
            this.SpeedButton1 = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.GridComposicao = new System.Windows.Forms.DataGridView();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.GridComposicao_ID_PRODUTO_FILHO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridComposicao_DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridComposicao_QUANTIDADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).BeginInit();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridComposicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.SuspendLayout();
            // 
            // TPanel1
            // 
            this.TPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TPanel1.Controls.Add(this.GridPrincipal);
            this.TPanel1.Controls.Add(this.Panel3);
            this.TPanel1.Controls.Add(this.Label2);
            this.TPanel1.Location = new System.Drawing.Point(80, 8);
            this.TPanel1.Name = "TPanel1";
            this.TPanel1.Size = new System.Drawing.Size(766, 233);
            this.TPanel1.TabIndex = 115;
            // 
            // GridPrincipal
            // 
            this.GridPrincipal.AllowUserToAddRows = false;
            this.GridPrincipal.AllowUserToDeleteRows = false;
            this.GridPrincipal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridPrincipal_ID,
            this.GridPrincipal_NOME,
            this.GridPrincipal_UNIDADE,
            this.GridPrincipal_VALOR_VENDA});
            this.GridPrincipal.Font = new System.Drawing.Font("Tahoma", 8F);
            this.GridPrincipal.Location = new System.Drawing.Point(9, 93);
            this.GridPrincipal.MultiSelect = false;
            this.GridPrincipal.Name = "GridPrincipal";
            this.GridPrincipal.ReadOnly = true;
            this.GridPrincipal.Size = new System.Drawing.Size(747, 132);
            this.GridPrincipal.TabIndex = 103;
            this.GridPrincipal.Text = "Select columns";
            this.GridPrincipal.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPrincipal_CellEnter);
            // 
            // GridPrincipal_ID
            // 
            this.GridPrincipal_ID.DataPropertyName = "Id";
            this.GridPrincipal_ID.HeaderText = "Código";
            this.GridPrincipal_ID.Name = "GridPrincipal_ID";
            this.GridPrincipal_ID.ReadOnly = true;
            // 
            // GridPrincipal_NOME
            // 
            this.GridPrincipal_NOME.DataPropertyName = "Nome";
            this.GridPrincipal_NOME.HeaderText = "Nome";
            this.GridPrincipal_NOME.Name = "GridPrincipal_NOME";
            this.GridPrincipal_NOME.ReadOnly = true;
            this.GridPrincipal_NOME.Width = 405;
            // 
            // GridPrincipal_UNIDADE
            // 
            this.GridPrincipal_UNIDADE.DataPropertyName = "UnidadeProduto";
            this.GridPrincipal_UNIDADE.HeaderText = "Unidade";
            this.GridPrincipal_UNIDADE.Name = "GridPrincipal_UNIDADE";
            this.GridPrincipal_UNIDADE.ReadOnly = true;
            this.GridPrincipal_UNIDADE.Width = 57;
            // 
            // GridPrincipal_VALOR_VENDA
            // 
            this.GridPrincipal_VALOR_VENDA.DataPropertyName = "ValorVenda";
            this.GridPrincipal_VALOR_VENDA.HeaderText = "Preço de Venda";
            this.GridPrincipal_VALOR_VENDA.Name = "GridPrincipal_VALOR_VENDA";
            this.GridPrincipal_VALOR_VENDA.ReadOnly = true;
            this.GridPrincipal_VALOR_VENDA.Width = 148;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel3.Controls.Add(this.EditLocaliza);
            this.Panel3.Controls.Add(this.SpeedButton1);
            this.Panel3.Controls.Add(this.Label5);
            this.Panel3.Location = new System.Drawing.Point(9, 28);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(747, 58);
            this.Panel3.TabIndex = 104;
            // 
            // EditLocaliza
            // 
            this.EditLocaliza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EditLocaliza.Location = new System.Drawing.Point(6, 27);
            this.EditLocaliza.Name = "EditLocaliza";
            this.EditLocaliza.Size = new System.Drawing.Size(633, 20);
            this.EditLocaliza.TabIndex = 0;
            this.EditLocaliza.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditLocaliza_KeyDown);
            // 
            // SpeedButton1
            // 
            this.SpeedButton1.BackColor = System.Drawing.Color.White;
            this.SpeedButton1.Location = new System.Drawing.Point(645, 27);
            this.SpeedButton1.Name = "SpeedButton1";
            this.SpeedButton1.Size = new System.Drawing.Size(93, 21);
            this.SpeedButton1.TabIndex = 7;
            this.SpeedButton1.Text = "Localiza (F2)";
            this.SpeedButton1.UseVisualStyleBackColor = false;
            this.SpeedButton1.Click += new System.EventHandler(this.SpeedButton1_Click);
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(5, 9);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(79, 13);
            this.Label5.TabIndex = 6;
            this.Label5.Text = "Procura p&or:";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(9, 4);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(747, 19);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Produtos de Produção Própria";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel2
            // 
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.GridComposicao);
            this.Panel2.Location = new System.Drawing.Point(80, 247);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(766, 227);
            this.Panel2.TabIndex = 6;
            // 
            // GridComposicao
            // 
            this.GridComposicao.AllowUserToAddRows = false;
            this.GridComposicao.AllowUserToDeleteRows = false;
            this.GridComposicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridComposicao_ID_PRODUTO_FILHO,
            this.Id,
            this.GridComposicao_DESCRICAO,
            this.GridComposicao_QUANTIDADE});
            this.GridComposicao.Font = new System.Drawing.Font("Tahoma", 8F);
            this.GridComposicao.Location = new System.Drawing.Point(7, 12);
            this.GridComposicao.MultiSelect = false;
            this.GridComposicao.Name = "GridComposicao";
            this.GridComposicao.ReadOnly = true;
            this.GridComposicao.Size = new System.Drawing.Size(749, 206);
            this.GridComposicao.TabIndex = 102;
            this.GridComposicao.Text = "Select columns";
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::PafEcf.Properties.Resources.cancelar16;
            this.botaoCancela.Location = new System.Drawing.Point(726, 491);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 13;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // Image1
            // 
            this.Image1.Image = global::PafEcf.Properties.Resources.telaRegistradora01;
            this.Image1.Location = new System.Drawing.Point(12, 8);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 0;
            this.Image1.TabStop = false;
            // 
            // GridComposicao_ID_PRODUTO_FILHO
            // 
            this.GridComposicao_ID_PRODUTO_FILHO.DataPropertyName = "IdProdutoFilho";
            this.GridComposicao_ID_PRODUTO_FILHO.HeaderText = "Código";
            this.GridComposicao_ID_PRODUTO_FILHO.Name = "GridComposicao_ID_PRODUTO_FILHO";
            this.GridComposicao_ID_PRODUTO_FILHO.ReadOnly = true;
            this.GridComposicao_ID_PRODUTO_FILHO.Width = 61;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // GridComposicao_DESCRICAO
            // 
            this.GridComposicao_DESCRICAO.DataPropertyName = "Descricao";
            this.GridComposicao_DESCRICAO.HeaderText = "Descrição";
            this.GridComposicao_DESCRICAO.Name = "GridComposicao_DESCRICAO";
            this.GridComposicao_DESCRICAO.ReadOnly = true;
            this.GridComposicao_DESCRICAO.Width = 400;
            // 
            // GridComposicao_QUANTIDADE
            // 
            this.GridComposicao_QUANTIDADE.DataPropertyName = "Quantidade";
            this.GridComposicao_QUANTIDADE.HeaderText = "Quantidade";
            this.GridComposicao_QUANTIDADE.Name = "GridComposicao_QUANTIDADE";
            this.GridComposicao_QUANTIDADE.ReadOnly = true;
            // 
            // FichaTecnica
            // 
            this.ClientSize = new System.Drawing.Size(861, 530);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.TPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(146, 302);
            this.Name = "FichaTecnica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabela Índice Técnico de Produção";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FFichaTecnica_KeyDown);
            this.TPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).EndInit();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridComposicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.Button botaoCancela;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_UNIDADE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_VALOR_VENDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridComposicao_ID_PRODUTO_FILHO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridComposicao_DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridComposicao_QUANTIDADE;

	}
}
