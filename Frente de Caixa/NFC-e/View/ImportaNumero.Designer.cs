namespace NFCe.View
{
	partial class ImportaNumero
    {
        private System.Windows.Forms.PictureBox Image1;
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
            this.labelEntrada = new System.Windows.Forms.Label();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.editEntrada = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Image1
            // 
            this.Image1.Image = global::NFCe.Properties.Resources.telaLupa06;
            this.Image1.Location = new System.Drawing.Point(9, 64);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 1;
            this.Image1.TabStop = false;
            // 
            // labelEntrada
            // 
            this.labelEntrada.AutoSize = true;
            this.labelEntrada.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelEntrada.ForeColor = System.Drawing.Color.Black;
            this.labelEntrada.Location = new System.Drawing.Point(73, 15);
            this.labelEntrada.Name = "labelEntrada";
            this.labelEntrada.Size = new System.Drawing.Size(39, 13);
            this.labelEntrada.TabIndex = 29;
            this.labelEntrada.Text = "Valor:";
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::NFCe.Properties.Resources.cancelar16;
            this.botaoCancela.Location = new System.Drawing.Point(209, 78);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 28;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::NFCe.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(75, 78);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 27;
            this.botaoConfirma.Text = "&Confirma (F12)";
            this.botaoConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoConfirma.Click += new System.EventHandler(this.botaoConfirma_Click);
            // 
            // editEntrada
            // 
            this.editEntrada.Location = new System.Drawing.Point(76, 34);
            this.editEntrada.Name = "editEntrada";
            this.editEntrada.Size = new System.Drawing.Size(253, 20);
            this.editEntrada.TabIndex = 26;
            this.editEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::NFCe.Properties.Resources.body;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // ImportaNumero
            // 
            this.ClientSize = new System.Drawing.Size(346, 119);
            this.Controls.Add(this.labelEntrada);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.editEntrada);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(330, 387);
            this.Name = "ImportaNumero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FImportaNumero";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FImportaNumero_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        internal System.Windows.Forms.Label labelEntrada;
        private System.Windows.Forms.Button botaoCancela;
        private System.Windows.Forms.Button botaoConfirma;
        private System.Windows.Forms.TextBox editEntrada;
        private System.Windows.Forms.PictureBox pictureBox1;

	}
}
