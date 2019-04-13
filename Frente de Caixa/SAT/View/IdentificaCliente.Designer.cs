namespace NFCe.View
{
	partial class IdentificaCliente
    {
		private System.Windows.Forms.PictureBox Image1;
		private System.Windows.Forms.Panel panPeriodo;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox editCpfCnpj;
		internal System.Windows.Forms.TextBox editNome;
		internal System.Windows.Forms.TextBox editEndereco;
		private System.Windows.Forms.Button botaoLocaliza;
		private System.Windows.Forms.Button botaoConfirma;
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
            this.panPeriodo = new System.Windows.Forms.Panel();
            this.editIDCliente = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.editEndereco = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.editCpfCnpj = new System.Windows.Forms.TextBox();
            this.editNome = new System.Windows.Forms.TextBox();
            this.botaoLocaliza = new System.Windows.Forms.Button();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panPeriodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panPeriodo
            // 
            this.panPeriodo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panPeriodo.Controls.Add(this.editIDCliente);
            this.panPeriodo.Controls.Add(this.Label2);
            this.panPeriodo.Controls.Add(this.Label4);
            this.panPeriodo.Controls.Add(this.editEndereco);
            this.panPeriodo.Location = new System.Drawing.Point(71, 10);
            this.panPeriodo.Name = "panPeriodo";
            this.panPeriodo.Size = new System.Drawing.Size(513, 111);
            this.panPeriodo.TabIndex = 0;
            // 
            // editIDCliente
            // 
            this.editIDCliente.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.editIDCliente.ForeColor = System.Drawing.Color.Black;
            this.editIDCliente.Location = new System.Drawing.Point(20, 29);
            this.editIDCliente.Name = "editIDCliente";
            this.editIDCliente.Size = new System.Drawing.Size(62, 20);
            this.editIDCliente.TabIndex = 5;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(17, 58);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(65, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Endereço:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(17, 12);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(20, 13);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "ID";
            // 
            // editEndereco
            // 
            this.editEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editEndereco.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.editEndereco.ForeColor = System.Drawing.Color.Black;
            this.editEndereco.Location = new System.Drawing.Point(20, 77);
            this.editEndereco.Name = "editEndereco";
            this.editEndereco.Size = new System.Drawing.Size(481, 20);
            this.editEndereco.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(156, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(63, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "CPF/CNPJ:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(281, 20);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(42, 13);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Nome:";
            // 
            // editCpfCnpj
            // 
            this.editCpfCnpj.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.editCpfCnpj.ForeColor = System.Drawing.Color.Black;
            this.editCpfCnpj.Location = new System.Drawing.Point(159, 39);
            this.editCpfCnpj.Name = "editCpfCnpj";
            this.editCpfCnpj.Size = new System.Drawing.Size(113, 20);
            this.editCpfCnpj.TabIndex = 0;
            this.editCpfCnpj.Leave += new System.EventHandler(this.editCpfCnpj_Leave);
            // 
            // editNome
            // 
            this.editNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editNome.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.editNome.ForeColor = System.Drawing.Color.Black;
            this.editNome.Location = new System.Drawing.Point(284, 39);
            this.editNome.Name = "editNome";
            this.editNome.Size = new System.Drawing.Size(281, 20);
            this.editNome.TabIndex = 1;
            // 
            // botaoLocaliza
            // 
            this.botaoLocaliza.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoLocaliza.ForeColor = System.Drawing.Color.Black;
            this.botaoLocaliza.Image = global::NFCe.Properties.Resources._21botaoPesquisa1;
            this.botaoLocaliza.Location = new System.Drawing.Point(87, 134);
            this.botaoLocaliza.Name = "botaoLocaliza";
            this.botaoLocaliza.Size = new System.Drawing.Size(120, 25);
            this.botaoLocaliza.TabIndex = 1;
            this.botaoLocaliza.Text = "&Localiza (F11)";
            this.botaoLocaliza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoLocaliza.Click += new System.EventHandler(this.botaoLocaliza_Click);
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::NFCe.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(269, 134);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 2;
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
            this.botaoCancela.Location = new System.Drawing.Point(451, 134);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 3;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // Image1
            // 
            this.Image1.Image = global::NFCe.Properties.Resources.telaHomem09;
            this.Image1.Location = new System.Drawing.Point(8, 115);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 0;
            this.Image1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::NFCe.Properties.Resources.body;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 169);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // IdentificaCliente
            // 
            this.ClientSize = new System.Drawing.Size(592, 169);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.editCpfCnpj);
            this.Controls.Add(this.editNome);
            this.Controls.Add(this.botaoLocaliza);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.panPeriodo);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(245, 307);
            this.Name = "IdentificaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identificação do Cliente";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FIdentificaCliente_KeyDown);
            this.panPeriodo.ResumeLayout(false);
            this.panPeriodo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        internal System.Windows.Forms.TextBox editIDCliente;
        private System.Windows.Forms.PictureBox pictureBox1;

	}
}
