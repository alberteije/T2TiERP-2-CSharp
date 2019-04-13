namespace NFCe.View
{
	partial class DescontoAcrescimo
    {
		private System.Windows.Forms.PictureBox Image1;
		internal System.Windows.Forms.TextBox EditEntrada;
		internal System.Windows.Forms.ComboBox ComboOperacao;
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
            this.EditEntrada = new System.Windows.Forms.TextBox();
            this.ComboOperacao = new System.Windows.Forms.ComboBox();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // EditEntrada
            // 
            this.EditEntrada.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.EditEntrada.ForeColor = System.Drawing.Color.Black;
            this.EditEntrada.Location = new System.Drawing.Point(81, 51);
            this.EditEntrada.Name = "EditEntrada";
            this.EditEntrada.Size = new System.Drawing.Size(246, 20);
            this.EditEntrada.TabIndex = 1;
            this.EditEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ComboOperacao
            // 
            this.ComboOperacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboOperacao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ComboOperacao.ForeColor = System.Drawing.Color.Black;
            this.ComboOperacao.FormattingEnabled = true;
            this.ComboOperacao.Items.AddRange(new object[] {
            "Desconto em Dinheiro",
            "Desconto Percentual",
            "Acréscimo em Dinheiro",
            "Acréscimo Percentual",
            "",
            "Cancelar Desconto ou Acréscimo"});
            this.ComboOperacao.Location = new System.Drawing.Point(81, 15);
            this.ComboOperacao.Name = "ComboOperacao";
            this.ComboOperacao.Size = new System.Drawing.Size(246, 21);
            this.ComboOperacao.TabIndex = 0;
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::NFCe.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(81, 87);
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
            this.botaoCancela.Location = new System.Drawing.Point(207, 87);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 3;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // Image1
            // 
            this.Image1.Image = global::NFCe.Properties.Resources.telaDinheiro03;
            this.Image1.Location = new System.Drawing.Point(9, 68);
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
            this.pictureBox1.Size = new System.Drawing.Size(64, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // DescontoAcrescimo
            // 
            this.ClientSize = new System.Drawing.Size(342, 123);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.EditEntrada);
            this.Controls.Add(this.ComboOperacao);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(330, 387);
            this.Name = "DescontoAcrescimo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FDescontoAcrescimo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FDescontoAcrescimo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.PictureBox pictureBox1;

	}
}
