namespace PafEcf.View
{
	partial class ValorReal
    {
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
            this.editEntrada = new System.Windows.Forms.TextBox();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.labelEntrada = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.SuspendLayout();
            // 
            // editEntrada
            // 
            this.editEntrada.Location = new System.Drawing.Point(79, 38);
            this.editEntrada.Name = "editEntrada";
            this.editEntrada.Size = new System.Drawing.Size(253, 20);
            this.editEntrada.TabIndex = 0;
            this.editEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::PafEcf.Properties.Resources.cancelar16;
            this.botaoCancela.Location = new System.Drawing.Point(212, 82);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 24;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // Image1
            // 
            this.Image1.Image = global::PafEcf.Properties.Resources.telaDinheiro05;
            this.Image1.Location = new System.Drawing.Point(12, 12);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 22;
            this.Image1.TabStop = false;
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::PafEcf.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(78, 82);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 23;
            this.botaoConfirma.Text = "&Confirma (F12)";
            this.botaoConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoConfirma.Click += new System.EventHandler(this.botaoConfirma_Click);
            // 
            // labelEntrada
            // 
            this.labelEntrada.AutoSize = true;
            this.labelEntrada.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelEntrada.ForeColor = System.Drawing.Color.Black;
            this.labelEntrada.Location = new System.Drawing.Point(76, 19);
            this.labelEntrada.Name = "labelEntrada";
            this.labelEntrada.Size = new System.Drawing.Size(39, 13);
            this.labelEntrada.TabIndex = 25;
            this.labelEntrada.Text = "Valor:";
            // 
            // FValorReal
            // 
            this.ClientSize = new System.Drawing.Size(346, 119);
            this.Controls.Add(this.labelEntrada);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.editEntrada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(330, 387);
            this.Name = "FValorReal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FValorReal";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FValorReal_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.TextBox editEntrada;
        private System.Windows.Forms.Button botaoCancela;
        private System.Windows.Forms.PictureBox Image1;
        private System.Windows.Forms.Button botaoConfirma;
        internal System.Windows.Forms.Label labelEntrada;

	}
}
