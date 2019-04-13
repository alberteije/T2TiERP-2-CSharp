namespace PafEcf.View
{
	partial class Splash
    {
		private System.Windows.Forms.PictureBox imgOperadoras;
		private System.Windows.Forms.PictureBox imgECF;
		private System.Windows.Forms.PictureBox imgBanco;
		internal System.Windows.Forms.Label lbMensagem;
		private System.Windows.Forms.PictureBox imgTEF;
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
            this.imgOperadoras = new System.Windows.Forms.PictureBox();
            this.imgECF = new System.Windows.Forms.PictureBox();
            this.imgBanco = new System.Windows.Forms.PictureBox();
            this.lbMensagem = new System.Windows.Forms.Label();
            this.imgTEF = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgOperadoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgECF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTEF)).BeginInit();
            this.SuspendLayout();
            // 
            // imgOperadoras
            // 
            this.imgOperadoras.BackColor = System.Drawing.Color.Transparent;
            this.imgOperadoras.Image = global::PafEcf.Properties.Resources.imgOperadoras;
            this.imgOperadoras.InitialImage = global::PafEcf.Properties.Resources.imgOperadoras;
            this.imgOperadoras.Location = new System.Drawing.Point(543, 213);
            this.imgOperadoras.Name = "imgOperadoras";
            this.imgOperadoras.Size = new System.Drawing.Size(142, 28);
            this.imgOperadoras.TabIndex = 1;
            this.imgOperadoras.TabStop = false;
            // 
            // imgECF
            // 
            this.imgECF.BackColor = System.Drawing.Color.Transparent;
            this.imgECF.Image = global::PafEcf.Properties.Resources.imgECF;
            this.imgECF.InitialImage = global::PafEcf.Properties.Resources.imgECF;
            this.imgECF.Location = new System.Drawing.Point(292, 67);
            this.imgECF.Name = "imgECF";
            this.imgECF.Size = new System.Drawing.Size(120, 120);
            this.imgECF.TabIndex = 2;
            this.imgECF.TabStop = false;
            // 
            // imgBanco
            // 
            this.imgBanco.BackColor = System.Drawing.Color.Transparent;
            this.imgBanco.Image = global::PafEcf.Properties.Resources.imgBanco;
            this.imgBanco.InitialImage = global::PafEcf.Properties.Resources.imgBanco;
            this.imgBanco.Location = new System.Drawing.Point(39, 70);
            this.imgBanco.Name = "imgBanco";
            this.imgBanco.Size = new System.Drawing.Size(130, 111);
            this.imgBanco.TabIndex = 3;
            this.imgBanco.TabStop = false;
            // 
            // lbMensagem
            // 
            this.lbMensagem.BackColor = System.Drawing.Color.Transparent;
            this.lbMensagem.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lbMensagem.ForeColor = System.Drawing.Color.White;
            this.lbMensagem.Location = new System.Drawing.Point(6, 231);
            this.lbMensagem.Name = "lbMensagem";
            this.lbMensagem.Size = new System.Drawing.Size(70, 15);
            this.lbMensagem.TabIndex = 4;
            // 
            // imgTEF
            // 
            this.imgTEF.BackColor = System.Drawing.Color.Transparent;
            this.imgTEF.Image = global::PafEcf.Properties.Resources.imgTEF;
            this.imgTEF.InitialImage = global::PafEcf.Properties.Resources.imgTEF;
            this.imgTEF.Location = new System.Drawing.Point(524, 64);
            this.imgTEF.Name = "imgTEF";
            this.imgTEF.Size = new System.Drawing.Size(120, 123);
            this.imgTEF.TabIndex = 5;
            this.imgTEF.TabStop = false;
            // 
            // FSplash
            // 
            this.BackgroundImage = global::PafEcf.Properties.Resources.imgPrincipal;
            this.ClientSize = new System.Drawing.Size(692, 252);
            this.Controls.Add(this.imgOperadoras);
            this.Controls.Add(this.imgECF);
            this.Controls.Add(this.imgBanco);
            this.Controls.Add(this.lbMensagem);
            this.Controls.Add(this.imgTEF);
            this.Location = new System.Drawing.Point(254, 442);
            this.Name = "FSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAF-ECF Bem vindo";
            ((System.ComponentModel.ISupportInitialize)(this.imgOperadoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgECF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTEF)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


    }
}
