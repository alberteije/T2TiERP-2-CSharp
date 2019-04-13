namespace PafEcf.View
{
	partial class RegistrosPAF
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
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.panPeriodo = new System.Windows.Forms.Panel();
            this.mkeDataFim = new System.Windows.Forms.MaskedTextBox();
            this.mkeDataIni = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.panPeriodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Image1
            // 
            this.Image1.Image = global::PafEcf.Properties.Resources.telaRegistradora01;
            this.Image1.Location = new System.Drawing.Point(13, 10);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 20;
            this.Image1.TabStop = false;
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::PafEcf.Properties.Resources.cancelar16;
            this.botaoCancela.Location = new System.Drawing.Point(414, 85);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 24;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::PafEcf.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(280, 85);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 23;
            this.botaoConfirma.Text = "&Confirma (F12)";
            this.botaoConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoConfirma.Click += new System.EventHandler(this.botaoConfirma_Click);
            // 
            // panPeriodo
            // 
            this.panPeriodo.Controls.Add(this.mkeDataFim);
            this.panPeriodo.Controls.Add(this.mkeDataIni);
            this.panPeriodo.Controls.Add(this.label5);
            this.panPeriodo.Controls.Add(this.label6);
            this.panPeriodo.Location = new System.Drawing.Point(313, 12);
            this.panPeriodo.Name = "panPeriodo";
            this.panPeriodo.Size = new System.Drawing.Size(217, 55);
            this.panPeriodo.TabIndex = 25;
            // 
            // mkeDataFim
            // 
            this.mkeDataFim.Location = new System.Drawing.Point(114, 28);
            this.mkeDataFim.Mask = "##/##/####";
            this.mkeDataFim.Name = "mkeDataFim";
            this.mkeDataFim.Size = new System.Drawing.Size(75, 20);
            this.mkeDataFim.TabIndex = 5;
            // 
            // mkeDataIni
            // 
            this.mkeDataIni.Location = new System.Drawing.Point(14, 28);
            this.mkeDataIni.Mask = "##/##/####";
            this.mkeDataIni.Name = "mkeDataIni";
            this.mkeDataIni.Size = new System.Drawing.Size(75, 20);
            this.mkeDataIni.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(11, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Data Inicial:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(111, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Data Final:";
            // 
            // RegistrosPAF
            // 
            this.ClientSize = new System.Drawing.Size(546, 122);
            this.Controls.Add(this.panPeriodo);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.botaoConfirma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(308, 368);
            this.Name = "RegistrosPAF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registros do PAF";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FEstoque_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.panPeriodo.ResumeLayout(false);
            this.panPeriodo.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.PictureBox Image1;
        private System.Windows.Forms.Button botaoCancela;
        private System.Windows.Forms.Button botaoConfirma;
        private System.Windows.Forms.Panel panPeriodo;
        private System.Windows.Forms.MaskedTextBox mkeDataFim;
        private System.Windows.Forms.MaskedTextBox mkeDataIni;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;

	}
}
