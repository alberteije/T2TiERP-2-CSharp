namespace NFCe.View
{
	partial class Parcelamento
    {
        private System.Windows.Forms.PictureBox Image1;
		private System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label3;
		private System.Windows.Forms.Button botaoLocalizaCliente;
		internal System.Windows.Forms.TextBox editNome;
		internal System.Windows.Forms.TextBox editCPF;
		private System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.NumericUpDown qtdParcelas;
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
            this.botaoLocalizaCliente = new System.Windows.Forms.Button();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.editNome = new System.Windows.Forms.TextBox();
            this.editCPF = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.Parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdParcelas = new System.Windows.Forms.NumericUpDown();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdParcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // botaoLocalizaCliente
            // 
            this.botaoLocalizaCliente.Location = new System.Drawing.Point(438, 34);
            this.botaoLocalizaCliente.Name = "botaoLocalizaCliente";
            this.botaoLocalizaCliente.Size = new System.Drawing.Size(27, 22);
            this.botaoLocalizaCliente.TabIndex = 2;
            // 
            // Image1
            // 
            this.Image1.Image = global::NFCe.Properties.Resources.telaDinheiro03;
            this.Image1.Location = new System.Drawing.Point(8, 413);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 0;
            this.Image1.TabStop = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.botaoLocalizaCliente);
            this.GroupBox1.Controls.Add(this.editNome);
            this.GroupBox1.Controls.Add(this.editCPF);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(75, 9);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(470, 74);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Dados do Cliente";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(8, 20);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(42, 13);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Nome";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(315, 19);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(63, 13);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "CPF/CNPJ";
            // 
            // editNome
            // 
            this.editNome.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.editNome.ForeColor = System.Drawing.Color.Black;
            this.editNome.Location = new System.Drawing.Point(8, 35);
            this.editNome.Name = "editNome";
            this.editNome.ReadOnly = true;
            this.editNome.Size = new System.Drawing.Size(302, 20);
            this.editNome.TabIndex = 0;
            // 
            // editCPF
            // 
            this.editCPF.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.editCPF.ForeColor = System.Drawing.Color.Black;
            this.editCPF.Location = new System.Drawing.Point(315, 35);
            this.editCPF.Name = "editCPF";
            this.editCPF.ReadOnly = true;
            this.editCPF.Size = new System.Drawing.Size(122, 20);
            this.editCPF.TabIndex = 1;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.textBox5);
            this.GroupBox2.Controls.Add(this.textBox4);
            this.GroupBox2.Controls.Add(this.textBox3);
            this.GroupBox2.Controls.Add(this.textBox2);
            this.GroupBox2.Controls.Add(this.textBox1);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.lblDesconto);
            this.GroupBox2.Controls.Add(this.Grid);
            this.GroupBox2.Controls.Add(this.qtdParcelas);
            this.GroupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(75, 83);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(470, 341);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Dados do parcelamento";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(327, 84);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(39, 84);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(327, 38);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(182, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(36, 22);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(94, 13);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Valor da Venda";
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(180, 65);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(91, 13);
            this.Label7.TabIndex = 1;
            this.Label7.Text = "Nº de Parcelas";
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(324, 65);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(93, 13);
            this.Label8.TabIndex = 2;
            this.Label8.Text = "1º Vencimento";
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(180, 22);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(94, 13);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Valor Recebido";
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(36, 65);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(99, 13);
            this.Label6.TabIndex = 4;
            this.Label6.Text = "Valor a Parcelar";
            // 
            // lblDesconto
            // 
            this.lblDesconto.Location = new System.Drawing.Point(324, 23);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(63, 13);
            this.lblDesconto.TabIndex = 5;
            this.lblDesconto.Text = "Desconto";
            // 
            // Grid
            // 
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parcela,
            this.Vencimento,
            this.Valor});
            this.Grid.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Grid.Location = new System.Drawing.Point(8, 122);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(454, 209);
            this.Grid.TabIndex = 0;
            this.Grid.Text = "Select columns";
            // 
            // Parcela
            // 
            this.Parcela.DataPropertyName = "Parcela";
            this.Parcela.HeaderText = "Parcela";
            this.Parcela.Name = "Parcela";
            // 
            // Vencimento
            // 
            this.Vencimento.DataPropertyName = "Vencimento";
            this.Vencimento.HeaderText = "Vencimento";
            this.Vencimento.Name = "Vencimento";
            this.Vencimento.Width = 103;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.Width = 93;
            // 
            // qtdParcelas
            // 
            this.qtdParcelas.Location = new System.Drawing.Point(180, 84);
            this.qtdParcelas.Name = "qtdParcelas";
            this.qtdParcelas.Size = new System.Drawing.Size(102, 20);
            this.qtdParcelas.TabIndex = 1;
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::NFCe.Properties.Resources.cancelar16;
            this.botaoCancela.Location = new System.Drawing.Point(426, 435);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 26;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::NFCe.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(292, 435);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 25;
            this.botaoConfirma.Text = "&Confirma (F12)";
            this.botaoConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::NFCe.Properties.Resources.body;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 469);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // Parcelamento
            // 
            this.ClientSize = new System.Drawing.Size(557, 469);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(206, 321);
            this.Name = "Parcelamento";
            this.Text = "Geração de Contas a Receber";
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtdParcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button botaoCancela;
        private System.Windows.Forms.Button botaoConfirma;
        private System.Windows.Forms.PictureBox pictureBox1;

	}
}
