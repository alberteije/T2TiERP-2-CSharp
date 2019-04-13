namespace NFCe.View
{
	partial class IniciaMovimento
    {
		private System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox editValorSuprimento;
		private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.DataGridView GridTurno;
		private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.GroupBox GroupBox4;
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
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.editValorSuprimento = new System.Windows.Forms.TextBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GridTurno = new System.Windows.Forms.DataGridView();
            this.DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HORA_INICIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HORA_FIM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.editLoginGerente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.editSenhaGerente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.editLoginOperador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editSenhaOperador = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.dataSet = new System.Data.DataSet();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTurno)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.editValorSuprimento);
            this.GroupBox2.Controls.Add(this.GroupBox3);
            this.GroupBox2.Controls.Add(this.GroupBox1);
            this.GroupBox2.Controls.Add(this.GroupBox4);
            this.GroupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(80, 10);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(659, 247);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Dados para abertura do movimento:";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(363, 31);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(177, 13);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Fundo de Caixa (Suprimento):";
            // 
            // editValorSuprimento
            // 
            this.editValorSuprimento.Location = new System.Drawing.Point(363, 50);
            this.editValorSuprimento.Name = "editValorSuprimento";
            this.editValorSuprimento.Size = new System.Drawing.Size(285, 20);
            this.editValorSuprimento.TabIndex = 1;
            this.editValorSuprimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.GridTurno);
            this.GroupBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupBox3.ForeColor = System.Drawing.Color.Black;
            this.GroupBox3.Location = new System.Drawing.Point(11, 21);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(346, 212);
            this.GroupBox3.TabIndex = 0;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Turno:";
            // 
            // GridTurno
            // 
            this.GridTurno.AllowUserToAddRows = false;
            this.GridTurno.AllowUserToDeleteRows = false;
            this.GridTurno.AllowUserToOrderColumns = true;
            this.GridTurno.AllowUserToResizeColumns = false;
            this.GridTurno.AllowUserToResizeRows = false;
            this.GridTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DESCRICAO,
            this.HORA_INICIO,
            this.HORA_FIM,
            this.ID});
            this.GridTurno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GridTurno.Location = new System.Drawing.Point(7, 19);
            this.GridTurno.MultiSelect = false;
            this.GridTurno.Name = "GridTurno";
            this.GridTurno.ReadOnly = true;
            this.GridTurno.Size = new System.Drawing.Size(333, 187);
            this.GridTurno.TabIndex = 0;
            this.GridTurno.Text = "Select columns";
            this.GridTurno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridTurno_KeyDown);
            // 
            // DESCRICAO
            // 
            this.DESCRICAO.DataPropertyName = "DESCRICAO";
            this.DESCRICAO.HeaderText = "Descrição";
            this.DESCRICAO.Name = "DESCRICAO";
            this.DESCRICAO.ReadOnly = true;
            this.DESCRICAO.Width = 80;
            // 
            // HORA_INICIO
            // 
            this.HORA_INICIO.DataPropertyName = "HORA_INICIO";
            this.HORA_INICIO.HeaderText = "Hora Início";
            this.HORA_INICIO.Name = "HORA_INICIO";
            this.HORA_INICIO.ReadOnly = true;
            // 
            // HORA_FIM
            // 
            this.HORA_FIM.DataPropertyName = "HORA_FIM";
            this.HORA_FIM.HeaderText = "Hora Fim";
            this.HORA_FIM.Name = "HORA_FIM";
            this.HORA_FIM.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.editLoginGerente);
            this.GroupBox1.Controls.Add(this.label10);
            this.GroupBox1.Controls.Add(this.editSenhaGerente);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(363, 162);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(285, 71);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Dados Gerente/Supervisor:";
            // 
            // editLoginGerente
            // 
            this.editLoginGerente.Location = new System.Drawing.Point(16, 43);
            this.editLoginGerente.Name = "editLoginGerente";
            this.editLoginGerente.PasswordChar = '*';
            this.editLoginGerente.Size = new System.Drawing.Size(120, 20);
            this.editLoginGerente.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(13, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Login:";
            // 
            // editSenhaGerente
            // 
            this.editSenhaGerente.Location = new System.Drawing.Point(153, 43);
            this.editSenhaGerente.Name = "editSenhaGerente";
            this.editSenhaGerente.PasswordChar = '*';
            this.editSenhaGerente.Size = new System.Drawing.Size(120, 20);
            this.editSenhaGerente.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(150, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Senha:";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.editLoginOperador);
            this.GroupBox4.Controls.Add(this.label1);
            this.GroupBox4.Controls.Add(this.editSenhaOperador);
            this.GroupBox4.Controls.Add(this.label2);
            this.GroupBox4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupBox4.ForeColor = System.Drawing.Color.Black;
            this.GroupBox4.Location = new System.Drawing.Point(363, 85);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(285, 71);
            this.GroupBox4.TabIndex = 2;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Dados Operador:";
            // 
            // editLoginOperador
            // 
            this.editLoginOperador.Location = new System.Drawing.Point(15, 40);
            this.editLoginOperador.Name = "editLoginOperador";
            this.editLoginOperador.PasswordChar = '*';
            this.editLoginOperador.Size = new System.Drawing.Size(120, 20);
            this.editLoginOperador.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Login:";
            // 
            // editSenhaOperador
            // 
            this.editSenhaOperador.Location = new System.Drawing.Point(152, 40);
            this.editSenhaOperador.Name = "editSenhaOperador";
            this.editSenhaOperador.PasswordChar = '*';
            this.editSenhaOperador.Size = new System.Drawing.Size(120, 20);
            this.editSenhaOperador.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(149, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Senha:";
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::NFCe.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(488, 268);
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
            this.botaoCancela.Location = new System.Drawing.Point(620, 268);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 4;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // Image1
            // 
            this.Image1.Image = global::NFCe.Properties.Resources.telaMonitor04;
            this.Image1.Location = new System.Drawing.Point(8, 247);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 5;
            this.Image1.TabStop = false;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "NewDataSet";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::NFCe.Properties.Resources.body;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 303);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(80, 249);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(660, 20);
            this.textBox1.TabIndex = 30;
            this.textBox1.Visible = false;
            // 
            // IniciaMovimento
            // 
            this.ClientSize = new System.Drawing.Size(751, 303);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(218, 386);
            this.Name = "IniciaMovimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicia Movimento do Terminal de Caixa";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FIniciaMovimento_KeyDown);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridTurno)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.Button botaoConfirma;
        private System.Windows.Forms.Button botaoCancela;
        private System.Windows.Forms.PictureBox Image1;
        private System.Windows.Forms.TextBox editLoginGerente;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox editSenhaGerente;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox editLoginOperador;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox editSenhaOperador;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HORA_INICIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HORA_FIM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Data.DataSet dataSet;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;

	}
}
