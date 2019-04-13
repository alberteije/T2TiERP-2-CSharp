namespace NFCe.View
{
	partial class MovimentoAberto
    {
		private System.Windows.Forms.PictureBox Image1;
		private System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.Panel Bevel2;
		private System.Windows.Forms.Panel Bevel4;
		private System.Windows.Forms.Panel Bevel1;
		internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label LabelTurno;
        internal System.Windows.Forms.Label LabelTerminal;
		private System.Windows.Forms.Panel Bevel5;
		private System.Windows.Forms.Panel Bevel6;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label LabelData;
		internal System.Windows.Forms.Label LabelHora;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.Panel Bevel3;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label LabelOperador;
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
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Bevel2 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Bevel4 = new System.Windows.Forms.Panel();
            this.Bevel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.LabelTurno = new System.Windows.Forms.Label();
            this.LabelTerminal = new System.Windows.Forms.Label();
            this.Bevel5 = new System.Windows.Forms.Panel();
            this.Label5 = new System.Windows.Forms.Label();
            this.LabelData = new System.Windows.Forms.Label();
            this.Bevel6 = new System.Windows.Forms.Panel();
            this.Label6 = new System.Windows.Forms.Label();
            this.LabelHora = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.editSenhaOperador = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Bevel3 = new System.Windows.Forms.Panel();
            this.LabelOperador = new System.Windows.Forms.Label();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.Bevel2.SuspendLayout();
            this.Bevel1.SuspendLayout();
            this.Bevel5.SuspendLayout();
            this.Bevel6.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.Bevel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Image1
            // 
            this.Image1.Image = global::NFCe.Properties.Resources.telaMonitor04;
            this.Image1.Location = new System.Drawing.Point(8, 204);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 0;
            this.Image1.TabStop = false;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(80, 10);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(603, 206);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Movimento aberto - confirme dados para acessar movimento:";
            // 
            // Bevel2
            // 
            this.Bevel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel2.Controls.Add(this.Label2);
            this.Bevel2.Location = new System.Drawing.Point(93, 61);
            this.Bevel2.Name = "Bevel2";
            this.Bevel2.Size = new System.Drawing.Size(577, 25);
            this.Bevel2.TabIndex = 0;
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
            this.Bevel4.Location = new System.Drawing.Point(93, 103);
            this.Bevel4.Name = "Bevel4";
            this.Bevel4.Size = new System.Drawing.Size(577, 10);
            this.Bevel4.TabIndex = 0;
            // 
            // Bevel1
            // 
            this.Bevel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel1.Controls.Add(this.Label1);
            this.Bevel1.Location = new System.Drawing.Point(93, 29);
            this.Bevel1.Name = "Bevel1";
            this.Bevel1.Size = new System.Drawing.Size(577, 25);
            this.Bevel1.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(2, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Turno:";
            // 
            // LabelTurno
            // 
            this.LabelTurno.AutoSize = true;
            this.LabelTurno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LabelTurno.ForeColor = System.Drawing.Color.Gray;
            this.LabelTurno.Location = new System.Drawing.Point(165, 36);
            this.LabelTurno.Name = "LabelTurno";
            this.LabelTurno.Size = new System.Drawing.Size(43, 13);
            this.LabelTurno.TabIndex = 3;
            this.LabelTurno.Text = "Turno:";
            // 
            // LabelTerminal
            // 
            this.LabelTerminal.AutoSize = true;
            this.LabelTerminal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LabelTerminal.ForeColor = System.Drawing.Color.Gray;
            this.LabelTerminal.Location = new System.Drawing.Point(165, 68);
            this.LabelTerminal.Name = "LabelTerminal";
            this.LabelTerminal.Size = new System.Drawing.Size(60, 13);
            this.LabelTerminal.TabIndex = 4;
            this.LabelTerminal.Text = "Terminal:";
            // 
            // Bevel5
            // 
            this.Bevel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel5.Controls.Add(this.Label5);
            this.Bevel5.Controls.Add(this.LabelData);
            this.Bevel5.Location = new System.Drawing.Point(90, 137);
            this.Bevel5.Name = "Bevel5";
            this.Bevel5.Size = new System.Drawing.Size(176, 25);
            this.Bevel5.TabIndex = 6;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(3, 6);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(74, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Data Inicio:";
            // 
            // LabelData
            // 
            this.LabelData.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LabelData.ForeColor = System.Drawing.Color.Gray;
            this.LabelData.Location = new System.Drawing.Point(83, 6);
            this.LabelData.Name = "LabelData";
            this.LabelData.Size = new System.Drawing.Size(78, 13);
            this.LabelData.TabIndex = 2;
            this.LabelData.Text = "01/01/2000";
            // 
            // Bevel6
            // 
            this.Bevel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel6.Controls.Add(this.Label6);
            this.Bevel6.Controls.Add(this.LabelHora);
            this.Bevel6.Location = new System.Drawing.Point(90, 176);
            this.Bevel6.Name = "Bevel6";
            this.Bevel6.Size = new System.Drawing.Size(176, 25);
            this.Bevel6.TabIndex = 0;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(3, 6);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(74, 13);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "Hora Inicio:";
            // 
            // LabelHora
            // 
            this.LabelHora.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LabelHora.ForeColor = System.Drawing.Color.Gray;
            this.LabelHora.Location = new System.Drawing.Point(83, 6);
            this.LabelHora.Name = "LabelHora";
            this.LabelHora.Size = new System.Drawing.Size(58, 13);
            this.LabelHora.TabIndex = 3;
            this.LabelHora.Text = "00:00:00";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.editSenhaOperador);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Bevel3);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(276, 132);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(394, 71);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Dados Para Login:";
            // 
            // editSenhaOperador
            // 
            this.editSenhaOperador.Location = new System.Drawing.Point(215, 37);
            this.editSenhaOperador.Name = "editSenhaOperador";
            this.editSenhaOperador.PasswordChar = '*';
            this.editSenhaOperador.Size = new System.Drawing.Size(168, 20);
            this.editSenhaOperador.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(212, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Senha:";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(13, 18);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(66, 13);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Operador:";
            // 
            // Bevel3
            // 
            this.Bevel3.Controls.Add(this.LabelOperador);
            this.Bevel3.Location = new System.Drawing.Point(14, 36);
            this.Bevel3.Name = "Bevel3";
            this.Bevel3.Size = new System.Drawing.Size(182, 21);
            this.Bevel3.TabIndex = 0;
            // 
            // LabelOperador
            // 
            this.LabelOperador.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LabelOperador.ForeColor = System.Drawing.Color.Gray;
            this.LabelOperador.Location = new System.Drawing.Point(5, 4);
            this.LabelOperador.Name = "LabelOperador";
            this.LabelOperador.Size = new System.Drawing.Size(66, 13);
            this.LabelOperador.TabIndex = 1;
            this.LabelOperador.Text = "Operador:";
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::NFCe.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(418, 222);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 1;
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
            this.botaoCancela.Location = new System.Drawing.Point(550, 222);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 2;
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
            this.pictureBox1.Size = new System.Drawing.Size(64, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // MovimentoAberto
            // 
            this.ClientSize = new System.Drawing.Size(692, 256);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.LabelTurno);
            this.Controls.Add(this.LabelTerminal);
            this.Controls.Add(this.Bevel5);
            this.Controls.Add(this.Bevel6);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Bevel1);
            this.Controls.Add(this.Bevel2);
            this.Controls.Add(this.Bevel4);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(299, 182);
            this.Name = "MovimentoAberto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimento Aberto - Confirme Dados";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.Bevel2.ResumeLayout(false);
            this.Bevel1.ResumeLayout(false);
            this.Bevel5.ResumeLayout(false);
            this.Bevel6.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.Bevel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox editSenhaOperador;
        private System.Windows.Forms.PictureBox pictureBox1;

	}
}
