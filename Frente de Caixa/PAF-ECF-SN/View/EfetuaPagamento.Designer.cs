namespace PafEcf.View
{
	partial class EfetuaPagamento
    {
		private System.Windows.Forms.PictureBox Image1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Button botaoCancela;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.DataGridView GridValores;
		private System.Windows.Forms.Button botaoConfirma;
		private System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.Panel Bevel7;
        private System.Windows.Forms.Panel Bevel6;
		private System.Windows.Forms.Panel Bevel4;
		private System.Windows.Forms.Panel Bevel3;
        private System.Windows.Forms.Panel Bevel2;
		private System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.ComboBox ComboTipoPagamento;
		private System.Windows.Forms.Panel PanelConfirmaValores;
		internal System.Windows.Forms.Label LabelConfirmaValores;
		private System.Windows.Forms.Button botaoNao;
		private System.Windows.Forms.Button botaoSim;
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.botaoCancela = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GridValores = new System.Windows.Forms.DataGridView();
            this.botaoConfirma = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Bevel3 = new System.Windows.Forms.Panel();
            this.labelAcrescimo = new System.Windows.Forms.Label();
            this.labelDescricaoAcrescimo = new System.Windows.Forms.Label();
            this.Bevel7 = new System.Windows.Forms.Panel();
            this.labelAindaFalta = new System.Windows.Forms.Label();
            this.labelDescricaoAindaFalta = new System.Windows.Forms.Label();
            this.Bevel6 = new System.Windows.Forms.Panel();
            this.labelTroco = new System.Windows.Forms.Label();
            this.labelDescricaoTroco = new System.Windows.Forms.Label();
            this.Bevel4 = new System.Windows.Forms.Panel();
            this.labelTotalReceber = new System.Windows.Forms.Label();
            this.labelDescricaoTotalReceber = new System.Windows.Forms.Label();
            this.Bevel5 = new System.Windows.Forms.Panel();
            this.labelTotalRecebido = new System.Windows.Forms.Label();
            this.labelDescricaoTotalRecebido = new System.Windows.Forms.Label();
            this.Bevel1 = new System.Windows.Forms.Panel();
            this.labelDescricaoTotalVenda = new System.Windows.Forms.Label();
            this.labelTotalVenda = new System.Windows.Forms.Label();
            this.Bevel2 = new System.Windows.Forms.Panel();
            this.labelDesconto = new System.Windows.Forms.Label();
            this.labelDescricaoDesconto = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.editValorPago = new System.Windows.Forms.TextBox();
            this.ComboTipoPagamento = new System.Windows.Forms.ComboBox();
            this.PanelConfirmaValores = new System.Windows.Forms.Panel();
            this.LabelConfirmaValores = new System.Windows.Forms.Label();
            this.botaoNao = new System.Windows.Forms.Button();
            this.botaoSim = new System.Windows.Forms.Button();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.dataSet = new System.Data.DataSet();
            this.acBrTEFD = new ACBrFramework.TEFD.ACBrTEFD();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridValores)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.Bevel3.SuspendLayout();
            this.Bevel7.SuspendLayout();
            this.Bevel6.SuspendLayout();
            this.Bevel4.SuspendLayout();
            this.Bevel5.SuspendLayout();
            this.Bevel1.SuspendLayout();
            this.Bevel2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.PanelConfirmaValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(75, 399);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(140, 16);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "F2-Fechamento Rápido";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(251, 399);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(112, 16);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "F5-Remover Valor";
            // 
            // botaoCancela
            // 
            this.botaoCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botaoCancela.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoCancela.ForeColor = System.Drawing.Color.Black;
            this.botaoCancela.Image = global::PafEcf.Properties.Resources.cancelar16;
            this.botaoCancela.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botaoCancela.Location = new System.Drawing.Point(529, 396);
            this.botaoCancela.Name = "botaoCancela";
            this.botaoCancela.Size = new System.Drawing.Size(120, 25);
            this.botaoCancela.TabIndex = 3;
            this.botaoCancela.Text = "Ca&ncela (ESC)";
            this.botaoCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoCancela.Click += new System.EventHandler(this.BotaoCancela_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.GridValores);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(375, 96);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(275, 283);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Valores informados:";
            // 
            // GridValores
            // 
            this.GridValores.AllowUserToAddRows = false;
            this.GridValores.AllowUserToDeleteRows = false;
            this.GridValores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridValores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridValores.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.GridValores.Location = new System.Drawing.Point(5, 26);
            this.GridValores.MultiSelect = false;
            this.GridValores.Name = "GridValores";
            this.GridValores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GridValores.RowHeadersVisible = false;
            this.GridValores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridValores.Size = new System.Drawing.Size(264, 247);
            this.GridValores.TabIndex = 0;
            this.GridValores.Text = "Select columns";
            this.GridValores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridValoresKeyDown);
            // 
            // botaoConfirma
            // 
            this.botaoConfirma.Font = new System.Drawing.Font("Tahoma", 8F);
            this.botaoConfirma.ForeColor = System.Drawing.Color.Black;
            this.botaoConfirma.Image = global::PafEcf.Properties.Resources.confirmar16;
            this.botaoConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botaoConfirma.Location = new System.Drawing.Point(397, 396);
            this.botaoConfirma.Name = "botaoConfirma";
            this.botaoConfirma.Size = new System.Drawing.Size(120, 25);
            this.botaoConfirma.TabIndex = 1;
            this.botaoConfirma.Text = "&Finaliza (F12)";
            this.botaoConfirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoConfirma.Click += new System.EventHandler(this.botaoConfirma_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Bevel3);
            this.GroupBox2.Controls.Add(this.Bevel7);
            this.GroupBox2.Controls.Add(this.Bevel6);
            this.GroupBox2.Controls.Add(this.Bevel4);
            this.GroupBox2.Controls.Add(this.Bevel5);
            this.GroupBox2.Controls.Add(this.Bevel1);
            this.GroupBox2.Controls.Add(this.Bevel2);
            this.GroupBox2.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(71, 96);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(291, 283);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Resumo da venda:";
            // 
            // Bevel3
            // 
            this.Bevel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel3.Controls.Add(this.labelAcrescimo);
            this.Bevel3.Controls.Add(this.labelDescricaoAcrescimo);
            this.Bevel3.Location = new System.Drawing.Point(6, 102);
            this.Bevel3.Name = "Bevel3";
            this.Bevel3.Size = new System.Drawing.Size(279, 29);
            this.Bevel3.TabIndex = 0;
            // 
            // labelAcrescimo
            // 
            this.labelAcrescimo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelAcrescimo.ForeColor = System.Drawing.Color.Blue;
            this.labelAcrescimo.Location = new System.Drawing.Point(146, 5);
            this.labelAcrescimo.Name = "labelAcrescimo";
            this.labelAcrescimo.Size = new System.Drawing.Size(130, 18);
            this.labelAcrescimo.TabIndex = 5;
            this.labelAcrescimo.Text = "0.00";
            this.labelAcrescimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDescricaoAcrescimo
            // 
            this.labelDescricaoAcrescimo.AutoSize = true;
            this.labelDescricaoAcrescimo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelDescricaoAcrescimo.ForeColor = System.Drawing.Color.Blue;
            this.labelDescricaoAcrescimo.Location = new System.Drawing.Point(0, 5);
            this.labelDescricaoAcrescimo.Name = "labelDescricaoAcrescimo";
            this.labelDescricaoAcrescimo.Size = new System.Drawing.Size(98, 19);
            this.labelDescricaoAcrescimo.TabIndex = 4;
            this.labelDescricaoAcrescimo.Text = "Acréscimo:";
            // 
            // Bevel7
            // 
            this.Bevel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel7.Controls.Add(this.labelAindaFalta);
            this.Bevel7.Controls.Add(this.labelDescricaoAindaFalta);
            this.Bevel7.Location = new System.Drawing.Point(6, 210);
            this.Bevel7.Name = "Bevel7";
            this.Bevel7.Size = new System.Drawing.Size(279, 29);
            this.Bevel7.TabIndex = 0;
            // 
            // labelAindaFalta
            // 
            this.labelAindaFalta.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelAindaFalta.ForeColor = System.Drawing.Color.Blue;
            this.labelAindaFalta.Location = new System.Drawing.Point(146, 5);
            this.labelAindaFalta.Name = "labelAindaFalta";
            this.labelAindaFalta.Size = new System.Drawing.Size(130, 18);
            this.labelAindaFalta.TabIndex = 13;
            this.labelAindaFalta.Text = "0.00";
            this.labelAindaFalta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDescricaoAindaFalta
            // 
            this.labelDescricaoAindaFalta.AutoSize = true;
            this.labelDescricaoAindaFalta.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelDescricaoAindaFalta.ForeColor = System.Drawing.Color.Blue;
            this.labelDescricaoAindaFalta.Location = new System.Drawing.Point(0, 5);
            this.labelDescricaoAindaFalta.Name = "labelDescricaoAindaFalta";
            this.labelDescricaoAindaFalta.Size = new System.Drawing.Size(139, 19);
            this.labelDescricaoAindaFalta.TabIndex = 12;
            this.labelDescricaoAindaFalta.Text = "Saldo Restante:";
            // 
            // Bevel6
            // 
            this.Bevel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel6.Controls.Add(this.labelTroco);
            this.Bevel6.Controls.Add(this.labelDescricaoTroco);
            this.Bevel6.Location = new System.Drawing.Point(6, 247);
            this.Bevel6.Name = "Bevel6";
            this.Bevel6.Size = new System.Drawing.Size(279, 29);
            this.Bevel6.TabIndex = 0;
            // 
            // labelTroco
            // 
            this.labelTroco.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelTroco.ForeColor = System.Drawing.Color.Red;
            this.labelTroco.Location = new System.Drawing.Point(146, 5);
            this.labelTroco.Name = "labelTroco";
            this.labelTroco.Size = new System.Drawing.Size(130, 18);
            this.labelTroco.TabIndex = 10;
            this.labelTroco.Text = "0.00";
            this.labelTroco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDescricaoTroco
            // 
            this.labelDescricaoTroco.AutoSize = true;
            this.labelDescricaoTroco.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelDescricaoTroco.ForeColor = System.Drawing.Color.Red;
            this.labelDescricaoTroco.Location = new System.Drawing.Point(0, 5);
            this.labelDescricaoTroco.Name = "labelDescricaoTroco";
            this.labelDescricaoTroco.Size = new System.Drawing.Size(61, 19);
            this.labelDescricaoTroco.TabIndex = 11;
            this.labelDescricaoTroco.Text = "Troco:";
            // 
            // Bevel4
            // 
            this.Bevel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel4.Controls.Add(this.labelTotalReceber);
            this.Bevel4.Controls.Add(this.labelDescricaoTotalReceber);
            this.Bevel4.Location = new System.Drawing.Point(6, 139);
            this.Bevel4.Name = "Bevel4";
            this.Bevel4.Size = new System.Drawing.Size(279, 29);
            this.Bevel4.TabIndex = 0;
            // 
            // labelTotalReceber
            // 
            this.labelTotalReceber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalReceber.ForeColor = System.Drawing.Color.Blue;
            this.labelTotalReceber.Location = new System.Drawing.Point(146, 5);
            this.labelTotalReceber.Name = "labelTotalReceber";
            this.labelTotalReceber.Size = new System.Drawing.Size(130, 18);
            this.labelTotalReceber.TabIndex = 6;
            this.labelTotalReceber.Text = "0.00";
            this.labelTotalReceber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDescricaoTotalReceber
            // 
            this.labelDescricaoTotalReceber.AutoSize = true;
            this.labelDescricaoTotalReceber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelDescricaoTotalReceber.ForeColor = System.Drawing.Color.Blue;
            this.labelDescricaoTotalReceber.Location = new System.Drawing.Point(0, 5);
            this.labelDescricaoTotalReceber.Name = "labelDescricaoTotalReceber";
            this.labelDescricaoTotalReceber.Size = new System.Drawing.Size(145, 19);
            this.labelDescricaoTotalReceber.TabIndex = 7;
            this.labelDescricaoTotalReceber.Text = "Total a Receber:";
            // 
            // Bevel5
            // 
            this.Bevel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel5.Controls.Add(this.labelTotalRecebido);
            this.Bevel5.Controls.Add(this.labelDescricaoTotalRecebido);
            this.Bevel5.Location = new System.Drawing.Point(6, 174);
            this.Bevel5.Name = "Bevel5";
            this.Bevel5.Size = new System.Drawing.Size(279, 29);
            this.Bevel5.TabIndex = 0;
            // 
            // labelTotalRecebido
            // 
            this.labelTotalRecebido.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalRecebido.ForeColor = System.Drawing.Color.Green;
            this.labelTotalRecebido.Location = new System.Drawing.Point(146, 5);
            this.labelTotalRecebido.Name = "labelTotalRecebido";
            this.labelTotalRecebido.Size = new System.Drawing.Size(130, 18);
            this.labelTotalRecebido.TabIndex = 8;
            this.labelTotalRecebido.Text = "0.00";
            this.labelTotalRecebido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDescricaoTotalRecebido
            // 
            this.labelDescricaoTotalRecebido.AutoSize = true;
            this.labelDescricaoTotalRecebido.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelDescricaoTotalRecebido.ForeColor = System.Drawing.Color.Green;
            this.labelDescricaoTotalRecebido.Location = new System.Drawing.Point(0, 5);
            this.labelDescricaoTotalRecebido.Name = "labelDescricaoTotalRecebido";
            this.labelDescricaoTotalRecebido.Size = new System.Drawing.Size(138, 19);
            this.labelDescricaoTotalRecebido.TabIndex = 9;
            this.labelDescricaoTotalRecebido.Text = "Total Recebido:";
            // 
            // Bevel1
            // 
            this.Bevel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel1.Controls.Add(this.labelDescricaoTotalVenda);
            this.Bevel1.Controls.Add(this.labelTotalVenda);
            this.Bevel1.Location = new System.Drawing.Point(6, 30);
            this.Bevel1.Name = "Bevel1";
            this.Bevel1.Size = new System.Drawing.Size(279, 29);
            this.Bevel1.TabIndex = 0;
            // 
            // labelDescricaoTotalVenda
            // 
            this.labelDescricaoTotalVenda.AutoSize = true;
            this.labelDescricaoTotalVenda.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelDescricaoTotalVenda.ForeColor = System.Drawing.Color.Blue;
            this.labelDescricaoTotalVenda.Location = new System.Drawing.Point(0, 5);
            this.labelDescricaoTotalVenda.Name = "labelDescricaoTotalVenda";
            this.labelDescricaoTotalVenda.Size = new System.Drawing.Size(114, 19);
            this.labelDescricaoTotalVenda.TabIndex = 0;
            this.labelDescricaoTotalVenda.Text = "Total Venda:";
            // 
            // labelTotalVenda
            // 
            this.labelTotalVenda.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalVenda.ForeColor = System.Drawing.Color.Blue;
            this.labelTotalVenda.Location = new System.Drawing.Point(146, 5);
            this.labelTotalVenda.Name = "labelTotalVenda";
            this.labelTotalVenda.Size = new System.Drawing.Size(130, 18);
            this.labelTotalVenda.TabIndex = 1;
            this.labelTotalVenda.Text = "0.00";
            this.labelTotalVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Bevel2
            // 
            this.Bevel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bevel2.Controls.Add(this.labelDesconto);
            this.Bevel2.Controls.Add(this.labelDescricaoDesconto);
            this.Bevel2.Location = new System.Drawing.Point(6, 65);
            this.Bevel2.Name = "Bevel2";
            this.Bevel2.Size = new System.Drawing.Size(279, 29);
            this.Bevel2.TabIndex = 0;
            // 
            // labelDesconto
            // 
            this.labelDesconto.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelDesconto.ForeColor = System.Drawing.Color.Red;
            this.labelDesconto.Location = new System.Drawing.Point(146, 5);
            this.labelDesconto.Name = "labelDesconto";
            this.labelDesconto.Size = new System.Drawing.Size(130, 18);
            this.labelDesconto.TabIndex = 3;
            this.labelDesconto.Text = "0.00";
            this.labelDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDescricaoDesconto
            // 
            this.labelDescricaoDesconto.AutoSize = true;
            this.labelDescricaoDesconto.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelDescricaoDesconto.ForeColor = System.Drawing.Color.Red;
            this.labelDescricaoDesconto.Location = new System.Drawing.Point(0, 5);
            this.labelDescricaoDesconto.Name = "labelDescricaoDesconto";
            this.labelDescricaoDesconto.Size = new System.Drawing.Size(90, 19);
            this.labelDescricaoDesconto.TabIndex = 2;
            this.labelDescricaoDesconto.Text = "Desconto:";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.editValorPago);
            this.GroupBox3.Controls.Add(this.ComboTipoPagamento);
            this.GroupBox3.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.GroupBox3.ForeColor = System.Drawing.Color.Black;
            this.GroupBox3.Location = new System.Drawing.Point(71, 12);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(579, 73);
            this.GroupBox3.TabIndex = 4;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Forma de pagamento e valor:";
            // 
            // editValorPago
            // 
            this.editValorPago.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editValorPago.Location = new System.Drawing.Point(305, 28);
            this.editValorPago.Name = "editValorPago";
            this.editValorPago.Size = new System.Drawing.Size(258, 33);
            this.editValorPago.TabIndex = 1;
            this.editValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.editValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editValorPago_KeyPress);
            this.editValorPago.Leave += new System.EventHandler(this.editValorPago_Leave);
            // 
            // ComboTipoPagamento
            // 
            this.ComboTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboTipoPagamento.Font = new System.Drawing.Font("Tahoma", 16F);
            this.ComboTipoPagamento.ForeColor = System.Drawing.Color.Black;
            this.ComboTipoPagamento.FormattingEnabled = true;
            this.ComboTipoPagamento.Location = new System.Drawing.Point(11, 29);
            this.ComboTipoPagamento.Name = "ComboTipoPagamento";
            this.ComboTipoPagamento.Size = new System.Drawing.Size(278, 33);
            this.ComboTipoPagamento.TabIndex = 0;
            this.ComboTipoPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboTipoPagamento_KeyPress);
            this.ComboTipoPagamento.Leave += new System.EventHandler(this.ComboTipoPagamento_Leave);
            // 
            // PanelConfirmaValores
            // 
            this.PanelConfirmaValores.BackColor = System.Drawing.Color.Gray;
            this.PanelConfirmaValores.Controls.Add(this.LabelConfirmaValores);
            this.PanelConfirmaValores.Controls.Add(this.botaoNao);
            this.PanelConfirmaValores.Controls.Add(this.botaoSim);
            this.PanelConfirmaValores.Location = new System.Drawing.Point(71, 391);
            this.PanelConfirmaValores.Name = "PanelConfirmaValores";
            this.PanelConfirmaValores.Size = new System.Drawing.Size(579, 31);
            this.PanelConfirmaValores.TabIndex = 3;
            this.PanelConfirmaValores.Visible = false;
            // 
            // LabelConfirmaValores
            // 
            this.LabelConfirmaValores.AutoSize = true;
            this.LabelConfirmaValores.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.LabelConfirmaValores.ForeColor = System.Drawing.Color.White;
            this.LabelConfirmaValores.Location = new System.Drawing.Point(7, 6);
            this.LabelConfirmaValores.Name = "LabelConfirmaValores";
            this.LabelConfirmaValores.Size = new System.Drawing.Size(99, 19);
            this.LabelConfirmaValores.TabIndex = 5;
            this.LabelConfirmaValores.Text = "Pergunta...";
            // 
            // botaoNao
            // 
            this.botaoNao.BackColor = System.Drawing.Color.White;
            this.botaoNao.Image = global::PafEcf.Properties.Resources.cancelar16;
            this.botaoNao.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botaoNao.Location = new System.Drawing.Point(481, 3);
            this.botaoNao.Name = "botaoNao";
            this.botaoNao.Size = new System.Drawing.Size(90, 24);
            this.botaoNao.TabIndex = 0;
            this.botaoNao.Text = "&Não";
            this.botaoNao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoNao.UseVisualStyleBackColor = false;
            this.botaoNao.Click += new System.EventHandler(this.botaoNao_Click);
            // 
            // botaoSim
            // 
            this.botaoSim.BackColor = System.Drawing.Color.White;
            this.botaoSim.Image = global::PafEcf.Properties.Resources.confirmar16;
            this.botaoSim.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.botaoSim.Location = new System.Drawing.Point(385, 3);
            this.botaoSim.Name = "botaoSim";
            this.botaoSim.Size = new System.Drawing.Size(90, 24);
            this.botaoSim.TabIndex = 1;
            this.botaoSim.Text = "&Sim";
            this.botaoSim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoSim.UseVisualStyleBackColor = false;
            this.botaoSim.Click += new System.EventHandler(this.botaoSim_Click);
            // 
            // Image1
            // 
            this.Image1.Image = global::PafEcf.Properties.Resources.telaCarrinho02;
            this.Image1.Location = new System.Drawing.Point(12, 12);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(48, 48);
            this.Image1.TabIndex = 0;
            this.Image1.TabStop = false;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "NewDataSet";
            // 
            // acBrTEFD
            // 
            this.acBrTEFD.ArqLOG = "";
            this.acBrTEFD.AutoAtivar = true;
            this.acBrTEFD.AutoEfetuarPagamento = false;
            this.acBrTEFD.AutoFinalizarCupom = true;
            this.acBrTEFD.CHQEmGerencial = false;
            this.acBrTEFD.EsperaSleep = 250;
            this.acBrTEFD.EsperaSTS = 7;
            this.acBrTEFD.ExibirMsgAutenticacao = true;
            this.acBrTEFD.GPAtual = ACBrFramework.TEFD.TefTipo.TefDial;
            this.acBrTEFD.MultiplosCartoes = false;
            this.acBrTEFD.NumeroMaximoCartoes = 0;
            this.acBrTEFD.NumVias = 2;
            this.acBrTEFD.PathBackup = "C:\\Arquivos de programas\\Microsoft Visual Studio 10.0\\Common7\\IDE\\TEF";
            this.acBrTEFD.TEFAuttar.ArqReq = "C:\\Auttar_TefIP\\req\\intpos.001";
            this.acBrTEFD.TEFAuttar.ArqResp = "C:\\Auttar_TefIP\\resp\\intpos.001";
            this.acBrTEFD.TEFAuttar.ArqSTS = "C:\\Auttar_TefIP\\resp\\intpos.sts";
            this.acBrTEFD.TEFAuttar.ArqTemp = "C:\\Auttar_TefIP\\req\\intpos.tmp";
            this.acBrTEFD.TEFAuttar.AutoAtivarGP = true;
            this.acBrTEFD.TEFAuttar.EsperaSTS = 7;
            this.acBrTEFD.TEFAuttar.GPExeName = "C:\\Arquivos de programas\\Auttar\\IntegradorTEF-IP.exe";
            this.acBrTEFD.TEFAuttar.Habilitado = false;
            this.acBrTEFD.TEFAuttar.Name = "TEFAuttar";
            this.acBrTEFD.TEFAuttar.NumVias = 2;
            this.acBrTEFD.TEFCliSiTef.CodigoLoja = "";
            this.acBrTEFD.TEFCliSiTef.EnderecoIP = "";
            this.acBrTEFD.TEFCliSiTef.Habilitado = false;
            this.acBrTEFD.TEFCliSiTef.Name = "CliSiTef";
            this.acBrTEFD.TEFCliSiTef.NumeroTerminal = "";
            this.acBrTEFD.TEFCliSiTef.OperacaoADM = 110;
            this.acBrTEFD.TEFCliSiTef.OperacaoATV = 111;
            this.acBrTEFD.TEFCliSiTef.OperacaoCHQ = 1;
            this.acBrTEFD.TEFCliSiTef.OperacaoCNC = 200;
            this.acBrTEFD.TEFCliSiTef.OperacaoCRT = 0;
            this.acBrTEFD.TEFCliSiTef.OperacaoReImpressao = 112;
            this.acBrTEFD.TEFCliSiTef.Operador = "";
            this.acBrTEFD.TEFCliSiTef.ParametrosAdicionais = new string[0];
            this.acBrTEFD.TEFCliSiTef.Restricoes = "";
            this.acBrTEFD.TEFCrediShop.ArqReq = "C:\\tef_cshp\\req\\intpos.001";
            this.acBrTEFD.TEFCrediShop.ArqResp = "C:\\tef_cshp\\resp\\intpos.001";
            this.acBrTEFD.TEFCrediShop.ArqSTS = "C:\\tef_cshp\\resp\\intpos.sts";
            this.acBrTEFD.TEFCrediShop.ArqTemp = "C:\\tef_cshp\\req\\intpos.tmp";
            this.acBrTEFD.TEFCrediShop.AutoAtivarGP = true;
            this.acBrTEFD.TEFCrediShop.EsperaSTS = 7;
            this.acBrTEFD.TEFCrediShop.GPExeName = "C:\\tef_cshp\\vpos_tef.exe";
            this.acBrTEFD.TEFCrediShop.Habilitado = false;
            this.acBrTEFD.TEFCrediShop.Name = "CrediShop";
            this.acBrTEFD.TEFCrediShop.NumVias = 2;
            this.acBrTEFD.TEFDial.ArqReq = "C:\\TEF_DIAL\\req\\intpos.001";
            this.acBrTEFD.TEFDial.ArqResp = "C:\\TEF_DIAL\\resp\\intpos.001";
            this.acBrTEFD.TEFDial.ArqSTS = "C:\\TEF_DIAL\\resp\\intpos.sts";
            this.acBrTEFD.TEFDial.ArqTemp = "C:\\TEF_DIAL\\req\\intpos.tmp";
            this.acBrTEFD.TEFDial.AutoAtivarGP = true;
            this.acBrTEFD.TEFDial.EsperaSTS = 7;
            this.acBrTEFD.TEFDial.GPExeName = "C:\\TEF_DIAL\\tef_dial.exe";
            this.acBrTEFD.TEFDial.Habilitado = false;
            this.acBrTEFD.TEFDial.Name = "TEF_DIAL";
            this.acBrTEFD.TEFDial.NumVias = 2;
            this.acBrTEFD.TEFDisc.ArqReq = "C:\\TEF_Disc\\req\\intpos.001";
            this.acBrTEFD.TEFDisc.ArqResp = "C:\\TEF_Disc\\resp\\intpos.001";
            this.acBrTEFD.TEFDisc.ArqSTS = "C:\\TEF_Disc\\resp\\intpos.sts";
            this.acBrTEFD.TEFDisc.ArqTemp = "C:\\TEF_Disc\\req\\intpos.tmp";
            this.acBrTEFD.TEFDisc.AutoAtivarGP = true;
            this.acBrTEFD.TEFDisc.EsperaSTS = 7;
            this.acBrTEFD.TEFDisc.GPExeName = "C:\\TEF_Disc\\tef_Disc.exe";
            this.acBrTEFD.TEFDisc.Habilitado = false;
            this.acBrTEFD.TEFDisc.Name = "TEF_Disc";
            this.acBrTEFD.TEFDisc.NumVias = 2;
            this.acBrTEFD.TEFFoxWin.ArqReq = "C:\\FwTEF\\req\\intpos.001";
            this.acBrTEFD.TEFFoxWin.ArqResp = "C:\\FwTEF\\rsp\\intpos.001";
            this.acBrTEFD.TEFFoxWin.ArqSTS = "C:\\FwTEF\\rsp\\intpos.sts";
            this.acBrTEFD.TEFFoxWin.ArqTemp = "C:\\FwTEF\\req\\intpos.tmp";
            this.acBrTEFD.TEFFoxWin.AutoAtivarGP = true;
            this.acBrTEFD.TEFFoxWin.EsperaSTS = 7;
            this.acBrTEFD.TEFFoxWin.GPExeName = "C:\\FwTEF\\bin\\FwTEF.exe";
            this.acBrTEFD.TEFFoxWin.Habilitado = false;
            this.acBrTEFD.TEFFoxWin.Name = "FwTEF";
            this.acBrTEFD.TEFFoxWin.NumVias = 2;
            this.acBrTEFD.TEFGood.ArqReq = "C:\\good\\getreq.dat";
            this.acBrTEFD.TEFGood.ArqResp = "C:\\good\\getresp.dat";
            this.acBrTEFD.TEFGood.ArqSTS = "C:\\good\\getstat.dat";
            this.acBrTEFD.TEFGood.ArqTemp = "C:\\good\\gettemp.dat";
            this.acBrTEFD.TEFGood.AutoAtivarGP = true;
            this.acBrTEFD.TEFGood.EsperaSTS = 7;
            this.acBrTEFD.TEFGood.GPExeName = "C:\\good\\GETGoodMed.exe";
            this.acBrTEFD.TEFGood.Habilitado = false;
            this.acBrTEFD.TEFGood.Name = "GoodCard";
            this.acBrTEFD.TEFGood.NumVias = 2;
            this.acBrTEFD.TEFGPU.ArqReq = "C:\\TEF_GPU\\req\\intpos.001";
            this.acBrTEFD.TEFGPU.ArqResp = "C:\\TEF_GPU\\resp\\intpos.001";
            this.acBrTEFD.TEFGPU.ArqSTS = "C:\\TEF_GPU\\resp\\intpos.sts";
            this.acBrTEFD.TEFGPU.ArqTemp = "C:\\TEF_GPU\\req\\intpos.tmp";
            this.acBrTEFD.TEFGPU.AutoAtivarGP = true;
            this.acBrTEFD.TEFGPU.EsperaSTS = 7;
            this.acBrTEFD.TEFGPU.GPExeName = "C:\\TEF_GPU\\GPU.exe";
            this.acBrTEFD.TEFGPU.Habilitado = false;
            this.acBrTEFD.TEFGPU.Name = "TEF_GPU";
            this.acBrTEFD.TEFGPU.NumVias = 2;
            this.acBrTEFD.TEFHiper.ArqReq = "C:\\HiperTEF\\req\\IntPos.001";
            this.acBrTEFD.TEFHiper.ArqResp = "C:\\HiperTEF\\resp\\IntPos.001";
            this.acBrTEFD.TEFHiper.ArqSTS = "C:\\HiperTEF\\resp\\IntPos.sts";
            this.acBrTEFD.TEFHiper.ArqTemp = "c:\\HiperTEF\\req\\IntPos.tmp";
            this.acBrTEFD.TEFHiper.AutoAtivarGP = true;
            this.acBrTEFD.TEFHiper.EsperaSTS = 7;
            this.acBrTEFD.TEFHiper.GPExeName = "C:\\HiperTEF\\HiperTEF.exe";
            this.acBrTEFD.TEFHiper.Habilitado = false;
            this.acBrTEFD.TEFHiper.Name = "HiperTEF";
            this.acBrTEFD.TEFHiper.NumVias = 2;
            this.acBrTEFD.TEFPetrocard.ArqReq = "C:\\CardTech\\req\\intpos.001";
            this.acBrTEFD.TEFPetrocard.ArqResp = "C:\\CardTech\\resp\\intpos.001";
            this.acBrTEFD.TEFPetrocard.ArqSTS = "C:\\CardTech\\resp\\intpos.sts";
            this.acBrTEFD.TEFPetrocard.ArqTemp = "C:\\CardTech\\req\\intpos.tmp";
            this.acBrTEFD.TEFPetrocard.AutoAtivarGP = true;
            this.acBrTEFD.TEFPetrocard.EsperaSTS = 7;
            this.acBrTEFD.TEFPetrocard.GPExeName = "C:\\CardTech\\sac.exe";
            this.acBrTEFD.TEFPetrocard.Habilitado = false;
            this.acBrTEFD.TEFPetrocard.Name = "PetroCard";
            this.acBrTEFD.TEFPetrocard.NumVias = 2;
            this.acBrTEFD.TrocoMaximo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.acBrTEFD.OnAguardaResp += new System.EventHandler<ACBrFramework.TEFD.AguardaRespEventArgs>(this.acBrTEFD_OnAguardaResp);
            this.acBrTEFD.OnExibeMensagem += new System.EventHandler<ACBrFramework.TEFD.ExibeMensagemEventArgs>(this.acBrTEFD_OnExibeMensagem);
            this.acBrTEFD.OnBloqueiaMouseTeclado += new System.EventHandler<ACBrFramework.TEFD.BloqueiaMouseTecladoEventArgs>(this.acBrTEFD_OnBloqueiaMouseTeclado);
            this.acBrTEFD.OnRestauraFocoAplicacao += new System.EventHandler<ACBrFramework.TEFD.ExecutaAcaoEventArgs>(this.acBrTEFD_OnRestauraFocoAplicacao);
            this.acBrTEFD.OnComandaECF += new System.EventHandler<ACBrFramework.TEFD.ComandaECFEventArgs>(this.acBrTEFD_OnComandaECF);
            this.acBrTEFD.OnComandaECFPagamento += new System.EventHandler<ACBrFramework.TEFD.ComandaECFPagamentoEventArgs>(this.acBrTEFD_OnComandaECFPagamento);
            this.acBrTEFD.OnComandaECFAbreVinculado += new System.EventHandler<ACBrFramework.TEFD.ComandaECFAbreVinculadoEventArgs>(this.acBrTEFD_OnComandaECFAbreVinculado);
            this.acBrTEFD.OnComandaECFImprimeVia += new System.EventHandler<ACBrFramework.TEFD.ComandaECFImprimeViaEventArgs>(this.acBrTEFD_OnComandaECFImprimeVia);
            this.acBrTEFD.OnInfoECF += new System.EventHandler<ACBrFramework.TEFD.InfoECFEventArgs>(this.acBrTEFD_OnInfoECF);
            this.acBrTEFD.OnAntesFinalizarRequisicao += new System.EventHandler<ACBrFramework.TEFD.AntesFinalizarRequisicaoEventArgs>(this.acBrTEFD_OnAntesFinalizarRequisicao);
            this.acBrTEFD.OnAntesCancelarTransacao += new System.EventHandler<ACBrFramework.TEFD.AntesCancelarTransacaoEventArgs>(this.acBrTEFD_OnAntesCancelarTransacao);
            // 
            // FEfetuaPagamento
            // 
            this.ClientSize = new System.Drawing.Size(663, 435);
            this.Controls.Add(this.PanelConfirmaValores);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.botaoCancela);
            this.Controls.Add(this.botaoConfirma);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(157, 498);
            this.Name = "FEfetuaPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Efetua Pagamento para Encerrar Venda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FEfetuaPagamento_FormClosing);
            this.Shown += new System.EventHandler(this.FEfetuaPagamento_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FEfetuaPagamento_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridValores)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.Bevel3.ResumeLayout(false);
            this.Bevel3.PerformLayout();
            this.Bevel7.ResumeLayout(false);
            this.Bevel7.PerformLayout();
            this.Bevel6.ResumeLayout(false);
            this.Bevel6.PerformLayout();
            this.Bevel4.ResumeLayout(false);
            this.Bevel4.PerformLayout();
            this.Bevel5.ResumeLayout(false);
            this.Bevel5.PerformLayout();
            this.Bevel1.ResumeLayout(false);
            this.Bevel1.PerformLayout();
            this.Bevel2.ResumeLayout(false);
            this.Bevel2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.PanelConfirmaValores.ResumeLayout(false);
            this.PanelConfirmaValores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.TextBox editValorPago;
        private System.Windows.Forms.Panel Bevel1;
        internal System.Windows.Forms.Label labelDescricaoTotalVenda;
        internal System.Windows.Forms.Label labelAindaFalta;
        internal System.Windows.Forms.Label labelDescricaoAindaFalta;
        internal System.Windows.Forms.Label labelDescricaoTroco;
        internal System.Windows.Forms.Label labelTroco;
        internal System.Windows.Forms.Label labelDescricaoTotalRecebido;
        internal System.Windows.Forms.Label labelTotalRecebido;
        internal System.Windows.Forms.Label labelDescricaoTotalReceber;
        internal System.Windows.Forms.Label labelTotalReceber;
        internal System.Windows.Forms.Label labelTotalVenda;
        internal System.Windows.Forms.Label labelAcrescimo;
        internal System.Windows.Forms.Label labelDescricaoDesconto;
        internal System.Windows.Forms.Label labelDescricaoAcrescimo;
        internal System.Windows.Forms.Label labelDesconto;
        private System.Windows.Forms.Panel Bevel5;
        private System.Data.DataSet dataSet;
        private ACBrFramework.TEFD.ACBrTEFD acBrTEFD;

	}
}
