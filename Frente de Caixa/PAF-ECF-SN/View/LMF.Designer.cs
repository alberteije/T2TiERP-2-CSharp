namespace PafEcf.View
{
    partial class LMF
    {
		private System.Windows.Forms.PictureBox Image1;
		private System.Windows.Forms.GroupBox RadioGroup2;
		internal System.Windows.Forms.RadioButton cbPeriododeData;
		internal System.Windows.Forms.RadioButton cbIntervalodeCRZ;
		private System.Windows.Forms.Panel panPeriodo;
		internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Panel panCOO;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox editInicio;
		internal System.Windows.Forms.TextBox editFim;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LMF));
            this.RadioGroup2 = new System.Windows.Forms.GroupBox();
            this.cbPeriododeData = new System.Windows.Forms.RadioButton();
            this.cbIntervalodeCRZ = new System.Windows.Forms.RadioButton();
            this.panPeriodo = new System.Windows.Forms.Panel();
            this.mkeDataFim = new System.Windows.Forms.MaskedTextBox();
            this.mkeDataIni = new System.Windows.Forms.MaskedTextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.panCOO = new System.Windows.Forms.Panel();
            this.editInicio = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.editFim = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.comboBoxTipoLeitura = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RadioGroup2.SuspendLayout();
            this.panPeriodo.SuspendLayout();
            this.panCOO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.SuspendLayout();
            // 
            // RadioGroup2
            // 
            this.RadioGroup2.Controls.Add(this.cbPeriododeData);
            this.RadioGroup2.Controls.Add(this.cbIntervalodeCRZ);
            this.RadioGroup2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RadioGroup2.ForeColor = System.Drawing.Color.Black;
            this.RadioGroup2.Location = new System.Drawing.Point(80, 56);
            this.RadioGroup2.Name = "RadioGroup2";
            this.RadioGroup2.Size = new System.Drawing.Size(449, 48);
            this.RadioGroup2.TabIndex = 1;
            this.RadioGroup2.TabStop = false;
            this.RadioGroup2.Text = "Tipo de Filtro:";
            // 
            // cbPeriododeData
            // 
            this.cbPeriododeData.Location = new System.Drawing.Point(14, 18);
            this.cbPeriododeData.Name = "cbPeriododeData";
            this.cbPeriododeData.Size = new System.Drawing.Size(128, 24);
            this.cbPeriododeData.TabIndex = 0;
            this.cbPeriododeData.Text = "Período de Data";
            this.cbPeriododeData.Click += new System.EventHandler(this.cbPeriododeData_Click);
            // 
            // cbIntervalodeCRZ
            // 
            this.cbIntervalodeCRZ.Location = new System.Drawing.Point(251, 18);
            this.cbIntervalodeCRZ.Name = "cbIntervalodeCRZ";
            this.cbIntervalodeCRZ.Size = new System.Drawing.Size(127, 24);
            this.cbIntervalodeCRZ.TabIndex = 1;
            this.cbIntervalodeCRZ.Text = "Intervalo de CRZ";
            this.cbIntervalodeCRZ.Click += new System.EventHandler(this.cbIntervalodeCOO_Click);
            // 
            // panPeriodo
            // 
            this.panPeriodo.Controls.Add(this.mkeDataFim);
            this.panPeriodo.Controls.Add(this.mkeDataIni);
            this.panPeriodo.Controls.Add(this.Label1);
            this.panPeriodo.Controls.Add(this.Label2);
            this.panPeriodo.Location = new System.Drawing.Point(80, 120);
            this.panPeriodo.Name = "panPeriodo";
            this.panPeriodo.Size = new System.Drawing.Size(217, 55);
            this.panPeriodo.TabIndex = 2;
            // 
            // mkeDataFim
            // 
            this.mkeDataFim.Location = new System.Drawing.Point(114, 28);
            this.mkeDataFim.Mask = "##/##/####";
            this.mkeDataFim.Name = "mkeDataFim";
            this.mkeDataFim.Size = new System.Drawing.Size(75, 20);
            this.mkeDataFim.TabIndex = 5;
            this.mkeDataFim.Leave += new System.EventHandler(this.mkeDataFim_Leave);
            // 
            // mkeDataIni
            // 
            this.mkeDataIni.Location = new System.Drawing.Point(14, 28);
            this.mkeDataIni.Mask = "##/##/####";
            this.mkeDataIni.Name = "mkeDataIni";
            this.mkeDataIni.Size = new System.Drawing.Size(75, 20);
            this.mkeDataIni.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(11, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Data Inicial:";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(111, 12);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Data Final:";
            // 
            // panCOO
            // 
            this.panCOO.Controls.Add(this.editInicio);
            this.panCOO.Controls.Add(this.Label3);
            this.panCOO.Controls.Add(this.editFim);
            this.panCOO.Controls.Add(this.Label4);
            this.panCOO.Enabled = false;
            this.panCOO.Location = new System.Drawing.Point(312, 120);
            this.panCOO.Name = "panCOO";
            this.panCOO.Size = new System.Drawing.Size(217, 55);
            this.panCOO.TabIndex = 3;
            // 
            // editInicio
            // 
            this.editInicio.Location = new System.Drawing.Point(19, 28);
            this.editInicio.Name = "editInicio";
            this.editInicio.Size = new System.Drawing.Size(80, 20);
            this.editInicio.TabIndex = 0;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(16, 12);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(61, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Primeiro:";
            // 
            // editFim
            // 
            this.editFim.Location = new System.Drawing.Point(120, 28);
            this.editFim.Name = "editFim";
            this.editFim.Size = new System.Drawing.Size(80, 20);
            this.editFim.TabIndex = 1;
            this.editFim.Leave += new System.EventHandler(this.editFim_Leave);
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(117, 12);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(50, 13);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "Ultimo:";
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::PafEcf.Properties.Resources.cancelar16;
            this.botaoCancela.Location = new System.Drawing.Point(413, 194);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 23);
            this.botaoCancela.TabIndex = 5;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // Image1
            // 
            this.Image1.Image = global::PafEcf.Properties.Resources.telaRegistradora01;
            this.Image1.Location = new System.Drawing.Point(12, 8);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 0;
            this.Image1.TabStop = false;
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::PafEcf.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(279, 194);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 23);
            this.botaoConfirma.TabIndex = 4;
            this.botaoConfirma.Text = "&Confirma (F12)";
            this.botaoConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoConfirma.Click += new System.EventHandler(this.botaoConfirma_Click);
            // 
            // comboBoxTipoLeitura
            // 
            this.comboBoxTipoLeitura.FormattingEnabled = true;
            this.comboBoxTipoLeitura.Items.AddRange(new object[] {
            "Completa",
            "Simplificada"});
            this.comboBoxTipoLeitura.Location = new System.Drawing.Point(80, 26);
            this.comboBoxTipoLeitura.Name = "comboBoxTipoLeitura";
            this.comboBoxTipoLeitura.Size = new System.Drawing.Size(449, 21);
            this.comboBoxTipoLeitura.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tipo de Leitura:";
            // 
            // LMF
            // 
            this.ClientSize = new System.Drawing.Size(546, 228);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxTipoLeitura);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.RadioGroup2);
            this.Controls.Add(this.panPeriodo);
            this.Controls.Add(this.panCOO);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.botaoCancela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(245, 307);
            this.Name = "LMF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LMF - Leitura Memória Fiscal Completa e Simplificada";
            this.Activated += new System.EventHandler(this.LMF_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            this.RadioGroup2.ResumeLayout(false);
            this.panPeriodo.ResumeLayout(false);
            this.panPeriodo.PerformLayout();
            this.panCOO.ResumeLayout(false);
            this.panCOO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.MaskedTextBox mkeDataFim;
        private System.Windows.Forms.MaskedTextBox mkeDataIni;
        private System.Windows.Forms.ComboBox comboBoxTipoLeitura;
        private System.Windows.Forms.Label label5;


    }
}
