namespace NFCe.View
{
	partial class EncerraMovimento
    {
        private System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Panel Bevel3;
        internal System.Windows.Forms.Label LabelOperador;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.ComboBox ComboTipoPagamento;
		private System.Windows.Forms.Button btnAdicionar;
		private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.DataGridView GridValores;
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
            this.editSenhaOperador = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LabelTurno = new System.Windows.Forms.Label();
            this.LabelTerminal = new System.Windows.Forms.Label();
            this.Bevel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Bevel2 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Bevel4 = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.LabelOperador = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.editLoginGerente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.editSenhaGerente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label6 = new System.Windows.Forms.Label();
            this.edtTotal = new System.Windows.Forms.Label();
            this.edtValor = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.ComboTipoPagamento = new System.Windows.Forms.ComboBox();
            this.GridValores = new System.Windows.Forms.DataGridView();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.Bevel3 = new System.Windows.Forms.Panel();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.dataSet = new System.Data.DataSet();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GroupBox2.SuspendLayout();
            this.Bevel1.SuspendLayout();
            this.Bevel2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridValores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.editSenhaOperador);
            this.GroupBox2.Controls.Add(this.label9);
            this.GroupBox2.Controls.Add(this.LabelTurno);
            this.GroupBox2.Controls.Add(this.LabelTerminal);
            this.GroupBox2.Controls.Add(this.Bevel1);
            this.GroupBox2.Controls.Add(this.Bevel2);
            this.GroupBox2.Controls.Add(this.Bevel4);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.LabelOperador);
            this.GroupBox2.Controls.Add(this.GroupBox1);
            this.GroupBox2.Controls.Add(this.GroupBox3);
            this.GroupBox2.Controls.Add(this.Bevel3);
            this.GroupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(72, 12);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(602, 415);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Dados do movimento aberto:";
            // 
            // editSenhaOperador
            // 
            this.editSenhaOperador.Location = new System.Drawing.Point(15, 378);
            this.editSenhaOperador.Name = "editSenhaOperador";
            this.editSenhaOperador.PasswordChar = '*';
            this.editSenhaOperador.Size = new System.Drawing.Size(168, 20);
            this.editSenhaOperador.TabIndex = 13;
            this.editSenhaOperador.Leave += new System.EventHandler(this.editSenhaOperador_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Senha Operador:";
            // 
            // LabelTurno
            // 
            this.LabelTurno.AutoSize = true;
            this.LabelTurno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LabelTurno.ForeColor = System.Drawing.Color.Gray;
            this.LabelTurno.Location = new System.Drawing.Point(95, 26);
            this.LabelTurno.Name = "LabelTurno";
            this.LabelTurno.Size = new System.Drawing.Size(43, 13);
            this.LabelTurno.TabIndex = 9;
            this.LabelTurno.Text = "Turno:";
            // 
            // LabelTerminal
            // 
            this.LabelTerminal.AutoSize = true;
            this.LabelTerminal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LabelTerminal.ForeColor = System.Drawing.Color.Gray;
            this.LabelTerminal.Location = new System.Drawing.Point(95, 58);
            this.LabelTerminal.Name = "LabelTerminal";
            this.LabelTerminal.Size = new System.Drawing.Size(60, 13);
            this.LabelTerminal.TabIndex = 10;
            this.LabelTerminal.Text = "Terminal:";
            // 
            // Bevel1
            // 
            this.Bevel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel1.Controls.Add(this.Label1);
            this.Bevel1.Location = new System.Drawing.Point(13, 19);
            this.Bevel1.Name = "Bevel1";
            this.Bevel1.Size = new System.Drawing.Size(577, 25);
            this.Bevel1.TabIndex = 6;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(2, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Turno:";
            // 
            // Bevel2
            // 
            this.Bevel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel2.Controls.Add(this.Label2);
            this.Bevel2.Location = new System.Drawing.Point(13, 51);
            this.Bevel2.Name = "Bevel2";
            this.Bevel2.Size = new System.Drawing.Size(577, 25);
            this.Bevel2.TabIndex = 7;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(2, 6);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(63, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Terminal:";
            // 
            // Bevel4
            // 
            this.Bevel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel4.Location = new System.Drawing.Point(13, 124);
            this.Bevel4.Name = "Bevel4";
            this.Bevel4.Size = new System.Drawing.Size(577, 10);
            this.Bevel4.TabIndex = 8;
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(16, 90);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(66, 13);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Operador:";
            // 
            // LabelOperador
            // 
            this.LabelOperador.AutoSize = true;
            this.LabelOperador.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LabelOperador.ForeColor = System.Drawing.Color.Gray;
            this.LabelOperador.Location = new System.Drawing.Point(95, 90);
            this.LabelOperador.Name = "LabelOperador";
            this.LabelOperador.Size = new System.Drawing.Size(63, 13);
            this.LabelOperador.TabIndex = 2;
            this.LabelOperador.Text = "Operador:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.editLoginGerente);
            this.GroupBox1.Controls.Add(this.label10);
            this.GroupBox1.Controls.Add(this.editSenhaGerente);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(200, 333);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(392, 71);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Dados Gerente/Supervisor:";
            // 
            // editLoginGerente
            // 
            this.editLoginGerente.Location = new System.Drawing.Point(20, 40);
            this.editLoginGerente.Name = "editLoginGerente";
            this.editLoginGerente.PasswordChar = '*';
            this.editLoginGerente.Size = new System.Drawing.Size(168, 20);
            this.editLoginGerente.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(17, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Login:";
            // 
            // editSenhaGerente
            // 
            this.editSenhaGerente.Location = new System.Drawing.Point(207, 40);
            this.editSenhaGerente.Name = "editSenhaGerente";
            this.editSenhaGerente.PasswordChar = '*';
            this.editSenhaGerente.Size = new System.Drawing.Size(168, 20);
            this.editSenhaGerente.TabIndex = 5;
            this.editSenhaGerente.Leave += new System.EventHandler(this.editSenhaGerente_Leave);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(204, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Senha:";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.panel1);
            this.GroupBox3.Controls.Add(this.edtValor);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.Label8);
            this.GroupBox3.Controls.Add(this.ComboTipoPagamento);
            this.GroupBox3.Controls.Add(this.GridValores);
            this.GroupBox3.Controls.Add(this.btnRemover);
            this.GroupBox3.Controls.Add(this.btnAdicionar);
            this.GroupBox3.Location = new System.Drawing.Point(15, 151);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(577, 177);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Encerrantes";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Label6);
            this.panel1.Controls.Add(this.edtTotal);
            this.panel1.Location = new System.Drawing.Point(12, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 43);
            this.panel1.TabIndex = 7;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(3, 4);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(42, 13);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "Total ";
            // 
            // edtTotal
            // 
            this.edtTotal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtTotal.ForeColor = System.Drawing.Color.Blue;
            this.edtTotal.Location = new System.Drawing.Point(8, 17);
            this.edtTotal.Name = "edtTotal";
            this.edtTotal.Size = new System.Drawing.Size(134, 22);
            this.edtTotal.TabIndex = 5;
            this.edtTotal.Text = "Total ";
            this.edtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtValor
            // 
            this.edtValor.Location = new System.Drawing.Point(12, 100);
            this.edtValor.Name = "edtValor";
            this.edtValor.Size = new System.Drawing.Size(145, 20);
            this.edtValor.TabIndex = 6;
            this.edtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtValor.Leave += new System.EventHandler(this.edtValor_Leave);
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(9, 36);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(119, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "&Tipo de Documento";
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(9, 81);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(39, 13);
            this.Label8.TabIndex = 2;
            this.Label8.Text = "&Valor";
            // 
            // ComboTipoPagamento
            // 
            this.ComboTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipoPagamento.FormattingEnabled = true;
            this.ComboTipoPagamento.Location = new System.Drawing.Point(12, 52);
            this.ComboTipoPagamento.Name = "ComboTipoPagamento";
            this.ComboTipoPagamento.Size = new System.Drawing.Size(145, 21);
            this.ComboTipoPagamento.TabIndex = 0;
            // 
            // GridValores
            // 
            this.GridValores.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GridValores.Location = new System.Drawing.Point(285, 19);
            this.GridValores.Name = "GridValores";
            this.GridValores.ReadOnly = true;
            this.GridValores.Size = new System.Drawing.Size(282, 147);
            this.GridValores.TabIndex = 4;
            this.GridValores.Text = "Select columns";
            // 
            // btnRemover
            // 
            this.btnRemover.Image = global::NFCe.Properties.Resources.arrowleft_green16;
            this.btnRemover.Location = new System.Drawing.Point(169, 81);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(106, 28);
            this.btnRemover.TabIndex = 3;
            this.btnRemover.Text = "   &Remover";
            this.btnRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Image = global::NFCe.Properties.Resources.arrowright_green16;
            this.btnAdicionar.Location = new System.Drawing.Point(169, 47);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(106, 28);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "&Adicionar";
            this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // Bevel3
            // 
            this.Bevel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel3.Location = new System.Drawing.Point(13, 85);
            this.Bevel3.Name = "Bevel3";
            this.Bevel3.Size = new System.Drawing.Size(577, 25);
            this.Bevel3.TabIndex = 0;
            // 
            // Image1
            // 
            this.Image1.Image = global::NFCe.Properties.Resources.telaMonitor04;
            this.Image1.Location = new System.Drawing.Point(8, 419);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 3;
            this.Image1.TabStop = false;
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::NFCe.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(424, 439);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 4;
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
            this.botaoCancela.Location = new System.Drawing.Point(556, 439);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 5;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
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
            this.pictureBox1.Size = new System.Drawing.Size(64, 474);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(72, 419);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(604, 20);
            this.textBox1.TabIndex = 30;
            this.textBox1.Visible = false;
            // 
            // EncerraMovimento
            // 
            this.ClientSize = new System.Drawing.Size(687, 474);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(168, 398);
            this.Name = "EncerraMovimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encerra Movimento de Caixa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FEncerraMovimento_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FEncerraMovimento_KeyDown);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.Bevel1.ResumeLayout(false);
            this.Bevel2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridValores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.PictureBox Image1;
        private System.Windows.Forms.Button botaoConfirma;
        private System.Windows.Forms.Button botaoCancela;
        internal System.Windows.Forms.Label LabelTurno;
        internal System.Windows.Forms.Label LabelTerminal;
        private System.Windows.Forms.Panel Bevel1;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel Bevel2;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Panel Bevel4;
        internal System.Windows.Forms.Label edtTotal;
        private System.Windows.Forms.TextBox edtValor;
        private System.Windows.Forms.TextBox editSenhaOperador;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox editLoginGerente;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox editSenhaGerente;
        internal System.Windows.Forms.Label label7;
        private System.Data.DataSet dataSet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;

	}
}
