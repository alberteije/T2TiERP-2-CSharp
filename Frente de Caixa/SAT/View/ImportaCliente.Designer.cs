namespace NFCe.View
{
	partial class ImportaCliente
    {
        private System.Windows.Forms.DataGridView GridPrincipal;
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
            this.GridPrincipal = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_NOME_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_CPF_CNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_RG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_ORGAO_RG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_INSCRICAO_MUNICIPAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_DATA_CADASTRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.EditLocaliza = new System.Windows.Forms.TextBox();
            this.SpeedButton1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GridPrincipal
            // 
            this.GridPrincipal.AllowUserToAddRows = false;
            this.GridPrincipal.AllowUserToDeleteRows = false;
            this.GridPrincipal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.GridPrincipal_NOME,
            this.GridPrincipal_NOME_1,
            this.GridPrincipal_CPF_CNPJ,
            this.GridPrincipal_RG,
            this.GridPrincipal_ORGAO_RG,
            this.GridPrincipal_INSCRICAO_MUNICIPAL,
            this.GridPrincipal_DATA_CADASTRO});
            this.GridPrincipal.Font = new System.Drawing.Font("Tahoma", 8F);
            this.GridPrincipal.Location = new System.Drawing.Point(69, 10);
            this.GridPrincipal.MultiSelect = false;
            this.GridPrincipal.Name = "GridPrincipal";
            this.GridPrincipal.ReadOnly = true;
            this.GridPrincipal.Size = new System.Drawing.Size(613, 230);
            this.GridPrincipal.TabIndex = 1;
            this.GridPrincipal.Text = "Select columns";
            this.GridPrincipal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridPrincipal_KeyDown);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "Id";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // GridPrincipal_NOME
            // 
            this.GridPrincipal_NOME.DataPropertyName = "Nome";
            this.GridPrincipal_NOME.HeaderText = "Nome";
            this.GridPrincipal_NOME.Name = "GridPrincipal_NOME";
            this.GridPrincipal_NOME.ReadOnly = true;
            this.GridPrincipal_NOME.Width = 300;
            // 
            // GridPrincipal_NOME_1
            // 
            this.GridPrincipal_NOME_1.DataPropertyName = "IdSituacaoCliente";
            this.GridPrincipal_NOME_1.HeaderText = "Situação";
            this.GridPrincipal_NOME_1.Name = "GridPrincipal_NOME_1";
            this.GridPrincipal_NOME_1.ReadOnly = true;
            // 
            // GridPrincipal_CPF_CNPJ
            // 
            this.GridPrincipal_CPF_CNPJ.DataPropertyName = "CpfOuCnpj";
            this.GridPrincipal_CPF_CNPJ.HeaderText = "CPF/CNPJ";
            this.GridPrincipal_CPF_CNPJ.Name = "GridPrincipal_CPF_CNPJ";
            this.GridPrincipal_CPF_CNPJ.ReadOnly = true;
            // 
            // GridPrincipal_RG
            // 
            this.GridPrincipal_RG.DataPropertyName = "Rg";
            this.GridPrincipal_RG.HeaderText = "RG";
            this.GridPrincipal_RG.Name = "GridPrincipal_RG";
            this.GridPrincipal_RG.ReadOnly = true;
            // 
            // GridPrincipal_ORGAO_RG
            // 
            this.GridPrincipal_ORGAO_RG.DataPropertyName = "OrgaoRg";
            this.GridPrincipal_ORGAO_RG.HeaderText = "Órgão RG";
            this.GridPrincipal_ORGAO_RG.Name = "GridPrincipal_ORGAO_RG";
            this.GridPrincipal_ORGAO_RG.ReadOnly = true;
            // 
            // GridPrincipal_INSCRICAO_MUNICIPAL
            // 
            this.GridPrincipal_INSCRICAO_MUNICIPAL.DataPropertyName = "InscricaoMunicipal";
            this.GridPrincipal_INSCRICAO_MUNICIPAL.HeaderText = "Inscrição Municipal";
            this.GridPrincipal_INSCRICAO_MUNICIPAL.Name = "GridPrincipal_INSCRICAO_MUNICIPAL";
            this.GridPrincipal_INSCRICAO_MUNICIPAL.ReadOnly = true;
            // 
            // GridPrincipal_DATA_CADASTRO
            // 
            this.GridPrincipal_DATA_CADASTRO.DataPropertyName = "DataCadastro";
            this.GridPrincipal_DATA_CADASTRO.HeaderText = "Cliente Desde";
            this.GridPrincipal_DATA_CADASTRO.Name = "GridPrincipal_DATA_CADASTRO";
            this.GridPrincipal_DATA_CADASTRO.ReadOnly = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(69, 319);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(0, 13);
            this.Label2.TabIndex = 7;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel1.Controls.Add(this.EditLocaliza);
            this.Panel1.Controls.Add(this.SpeedButton1);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(69, 246);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(613, 58);
            this.Panel1.TabIndex = 5;
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
            this.botaoConfirma.Location = new System.Drawing.Point(430, 316);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 8;
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
            this.botaoCancela.Location = new System.Drawing.Point(562, 316);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 9;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // Image1
            // 
            this.Image1.Image = global::NFCe.Properties.Resources.botaoPesquisa;
            this.Image1.Location = new System.Drawing.Point(9, 296);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 6;
            this.Image1.TabStop = false;
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
            // ImportaCliente
            // 
            this.ClientSize = new System.Drawing.Size(692, 351);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.GridPrincipal);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(132, 490);
            this.Name = "ImportaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Localiza Cliente";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FImportaCliente_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.Button botaoConfirma;
        private System.Windows.Forms.Button botaoCancela;
        private System.Windows.Forms.PictureBox Image1;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Panel Panel1;
        public System.Windows.Forms.TextBox EditLocaliza;
        private System.Windows.Forms.Button SpeedButton1;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_NOME_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_CPF_CNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_RG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_ORGAO_RG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_INSCRICAO_MUNICIPAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_DATA_CADASTRO;
        private System.Windows.Forms.PictureBox pictureBox1;

	}
}
