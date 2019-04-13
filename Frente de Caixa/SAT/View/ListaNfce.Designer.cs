namespace NFCe.View
{
    partial class ListaNfce
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label2 = new System.Windows.Forms.Label();
            this.GridPrincipal = new System.Windows.Forms.DataGridView();
            this.GridPrincipal_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_NUMERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_VALOR_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_SERIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_CHAVE_ACESSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_DATA_HORA_EMISSAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.EditLocaliza = new System.Windows.Forms.TextBox();
            this.SpeedButton1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(74, 320);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(0, 13);
            this.Label2.TabIndex = 32;
            // 
            // GridPrincipal
            // 
            this.GridPrincipal.AllowUserToAddRows = false;
            this.GridPrincipal.AllowUserToDeleteRows = false;
            this.GridPrincipal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridPrincipal_ID,
            this.GridPrincipal_NUMERO,
            this.GridPrincipal_VALOR_TOTAL,
            this.GridPrincipal_SERIE,
            this.GridPrincipal_CHAVE_ACESSO,
            this.GridPrincipal_DATA_HORA_EMISSAO});
            this.GridPrincipal.Font = new System.Drawing.Font("Tahoma", 8F);
            this.GridPrincipal.Location = new System.Drawing.Point(74, 10);
            this.GridPrincipal.Name = "GridPrincipal";
            this.GridPrincipal.ReadOnly = true;
            this.GridPrincipal.Size = new System.Drawing.Size(613, 231);
            this.GridPrincipal.TabIndex = 33;
            this.GridPrincipal.Text = "Select columns";
            this.GridPrincipal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridPrincipal_KeyDown);
            // 
            // GridPrincipal_ID
            // 
            this.GridPrincipal_ID.DataPropertyName = "Id";
            this.GridPrincipal_ID.HeaderText = "Id";
            this.GridPrincipal_ID.Name = "GridPrincipal_ID";
            this.GridPrincipal_ID.ReadOnly = true;
            this.GridPrincipal_ID.Width = 50;
            // 
            // GridPrincipal_NUMERO
            // 
            this.GridPrincipal_NUMERO.DataPropertyName = "Numero";
            this.GridPrincipal_NUMERO.HeaderText = "Número";
            this.GridPrincipal_NUMERO.Name = "GridPrincipal_NUMERO";
            this.GridPrincipal_NUMERO.ReadOnly = true;
            // 
            // GridPrincipal_VALOR_TOTAL
            // 
            this.GridPrincipal_VALOR_TOTAL.DataPropertyName = "ValorTotal";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.GridPrincipal_VALOR_TOTAL.DefaultCellStyle = dataGridViewCellStyle1;
            this.GridPrincipal_VALOR_TOTAL.HeaderText = "Valor Total";
            this.GridPrincipal_VALOR_TOTAL.Name = "GridPrincipal_VALOR_TOTAL";
            this.GridPrincipal_VALOR_TOTAL.ReadOnly = true;
            this.GridPrincipal_VALOR_TOTAL.Width = 120;
            // 
            // GridPrincipal_SERIE
            // 
            this.GridPrincipal_SERIE.DataPropertyName = "Serie";
            this.GridPrincipal_SERIE.HeaderText = "Série";
            this.GridPrincipal_SERIE.Name = "GridPrincipal_SERIE";
            this.GridPrincipal_SERIE.ReadOnly = true;
            // 
            // GridPrincipal_CHAVE_ACESSO
            // 
            this.GridPrincipal_CHAVE_ACESSO.DataPropertyName = "ChaveAcesso";
            this.GridPrincipal_CHAVE_ACESSO.HeaderText = "Chave Acesso";
            this.GridPrincipal_CHAVE_ACESSO.Name = "GridPrincipal_CHAVE_ACESSO";
            this.GridPrincipal_CHAVE_ACESSO.ReadOnly = true;
            // 
            // GridPrincipal_DATA_HORA_EMISSAO
            // 
            this.GridPrincipal_DATA_HORA_EMISSAO.DataPropertyName = "DataHoraEmissao";
            this.GridPrincipal_DATA_HORA_EMISSAO.HeaderText = "Data/Hora Emissão";
            this.GridPrincipal_DATA_HORA_EMISSAO.Name = "GridPrincipal_DATA_HORA_EMISSAO";
            this.GridPrincipal_DATA_HORA_EMISSAO.ReadOnly = true;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel1.Controls.Add(this.EditLocaliza);
            this.Panel1.Controls.Add(this.SpeedButton1);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(74, 247);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(613, 58);
            this.Panel1.TabIndex = 31;
            // 
            // EditLocaliza
            // 
            this.EditLocaliza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EditLocaliza.Location = new System.Drawing.Point(10, 27);
            this.EditLocaliza.Name = "EditLocaliza";
            this.EditLocaliza.Size = new System.Drawing.Size(485, 20);
            this.EditLocaliza.TabIndex = 0;
            // 
            // SpeedButton1
            // 
            this.SpeedButton1.BackColor = System.Drawing.Color.White;
            this.SpeedButton1.Location = new System.Drawing.Point(497, 27);
            this.SpeedButton1.Name = "SpeedButton1";
            this.SpeedButton1.Size = new System.Drawing.Size(105, 21);
            this.SpeedButton1.TabIndex = 5;
            this.SpeedButton1.Text = "Localiza (F2)";
            this.SpeedButton1.UseVisualStyleBackColor = false;
            this.SpeedButton1.Click += new System.EventHandler(this.SpeedButton1_Click);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(7, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(79, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Procura por:";
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::NFCe.Properties.Resources.confirmar16;
            this.botaoConfirma.Location = new System.Drawing.Point(435, 317);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 34;
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
            this.botaoCancela.Location = new System.Drawing.Point(567, 317);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 35;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.botaoCancela_Click);
            // 
            // Image1
            // 
            this.Image1.Image = global::NFCe.Properties.Resources.botaoPesquisa;
            this.Image1.Location = new System.Drawing.Point(8, 296);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 30;
            this.Image1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::NFCe.Properties.Resources.body;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 351);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // ListaNfce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 351);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.GridPrincipal);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "ListaNfce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recupera Venda";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListaNfce_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridPrincipal)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botaoConfirma;
        private System.Windows.Forms.Button botaoCancela;
        private System.Windows.Forms.PictureBox Image1;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.DataGridView GridPrincipal;
        private System.Windows.Forms.Panel Panel1;
        public System.Windows.Forms.TextBox EditLocaliza;
        private System.Windows.Forms.Button SpeedButton1;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_NUMERO;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_VALOR_TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_SERIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_CHAVE_ACESSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_DATA_HORA_EMISSAO;
    }
}