namespace NFCe.View
{
	partial class Caixa
    {
		internal System.Windows.Forms.Label labelDescontoAcrescimo;
		internal System.Windows.Forms.Label edtNVenda;
        internal System.Windows.Forms.Label edtNumeroNota;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caixa));
            this.editCodigo = new System.Windows.Forms.TextBox();
            this.labelDescricaoProduto = new System.Windows.Forms.Label();
            this.labelTotalGeral = new System.Windows.Forms.Label();
            this.labelMensagens = new System.Windows.Forms.Label();
            this.labelOperador = new System.Windows.Forms.Label();
            this.labelCaixa = new System.Windows.Forms.Label();
            this.labelDescontoAcrescimo = new System.Windows.Forms.Label();
            this.edtNVenda = new System.Windows.Forms.Label();
            this.edtNumeroNota = new System.Windows.Forms.Label();
            this.bobina = new System.Windows.Forms.ListBox();
            this.editQuantidade = new System.Windows.Forms.TextBox();
            this.editUnitario = new System.Windows.Forms.TextBox();
            this.editTotalItem = new System.Windows.Forms.TextBox();
            this.editSubTotal = new System.Windows.Forms.TextBox();
            this.PanelBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.botaoF1 = new System.Windows.Forms.Button();
            this.botaoF7 = new System.Windows.Forms.Button();
            this.botaoF2 = new System.Windows.Forms.Button();
            this.botaoF8 = new System.Windows.Forms.Button();
            this.botaoF3 = new System.Windows.Forms.Button();
            this.botaoF9 = new System.Windows.Forms.Button();
            this.botaoF4 = new System.Windows.Forms.Button();
            this.botaoF10 = new System.Windows.Forms.Button();
            this.botaoF5 = new System.Windows.Forms.Button();
            this.botaoF11 = new System.Windows.Forms.Button();
            this.botaoF6 = new System.Windows.Forms.Button();
            this.botaoF12 = new System.Windows.Forms.Button();
            this.imageProduto = new System.Windows.Forms.PictureBox();
            this.panelTitulo = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PanelBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // editCodigo
            // 
            this.editCodigo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.editCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editCodigo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCodigo.ForeColor = System.Drawing.Color.Black;
            this.editCodigo.Location = new System.Drawing.Point(489, 265);
            this.editCodigo.Name = "editCodigo";
            this.editCodigo.Size = new System.Drawing.Size(205, 26);
            this.editCodigo.TabIndex = 0;
            this.editCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.editCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editCodigoKeyDown);
            this.editCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editCodigoKeyPress);
            // 
            // labelDescricaoProduto
            // 
            this.labelDescricaoProduto.BackColor = System.Drawing.Color.Transparent;
            this.labelDescricaoProduto.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescricaoProduto.ForeColor = System.Drawing.Color.White;
            this.labelDescricaoProduto.Location = new System.Drawing.Point(42, 112);
            this.labelDescricaoProduto.Name = "labelDescricaoProduto";
            this.labelDescricaoProduto.Size = new System.Drawing.Size(941, 80);
            this.labelDescricaoProduto.TabIndex = 2;
            this.labelDescricaoProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalGeral
            // 
            this.labelTotalGeral.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalGeral.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold);
            this.labelTotalGeral.ForeColor = System.Drawing.Color.Yellow;
            this.labelTotalGeral.Location = new System.Drawing.Point(40, 648);
            this.labelTotalGeral.Name = "labelTotalGeral";
            this.labelTotalGeral.Size = new System.Drawing.Size(402, 46);
            this.labelTotalGeral.TabIndex = 3;
            this.labelTotalGeral.Text = "1.528,98";
            this.labelTotalGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMensagens
            // 
            this.labelMensagens.BackColor = System.Drawing.Color.Transparent;
            this.labelMensagens.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensagens.ForeColor = System.Drawing.Color.Yellow;
            this.labelMensagens.Location = new System.Drawing.Point(487, 648);
            this.labelMensagens.Name = "labelMensagens";
            this.labelMensagens.Size = new System.Drawing.Size(497, 46);
            this.labelMensagens.TabIndex = 4;
            this.labelMensagens.Text = "Todas as mensagens devem ser carregadas nesse local";
            this.labelMensagens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOperador
            // 
            this.labelOperador.BackColor = System.Drawing.Color.Transparent;
            this.labelOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.labelOperador.ForeColor = System.Drawing.Color.Black;
            this.labelOperador.Location = new System.Drawing.Point(834, 64);
            this.labelOperador.Name = "labelOperador";
            this.labelOperador.Size = new System.Drawing.Size(150, 13);
            this.labelOperador.TabIndex = 6;
            this.labelOperador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCaixa
            // 
            this.labelCaixa.BackColor = System.Drawing.Color.Transparent;
            this.labelCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.labelCaixa.ForeColor = System.Drawing.Color.Black;
            this.labelCaixa.Location = new System.Drawing.Point(834, 84);
            this.labelCaixa.Name = "labelCaixa";
            this.labelCaixa.Size = new System.Drawing.Size(150, 13);
            this.labelCaixa.TabIndex = 7;
            this.labelCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDescontoAcrescimo
            // 
            this.labelDescontoAcrescimo.BackColor = System.Drawing.Color.Transparent;
            this.labelDescontoAcrescimo.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold);
            this.labelDescontoAcrescimo.ForeColor = System.Drawing.Color.Red;
            this.labelDescontoAcrescimo.Location = new System.Drawing.Point(220, 620);
            this.labelDescontoAcrescimo.Name = "labelDescontoAcrescimo";
            this.labelDescontoAcrescimo.Size = new System.Drawing.Size(222, 18);
            this.labelDescontoAcrescimo.TabIndex = 8;
            this.labelDescontoAcrescimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtNVenda
            // 
            this.edtNVenda.BackColor = System.Drawing.Color.Transparent;
            this.edtNVenda.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtNVenda.ForeColor = System.Drawing.Color.Black;
            this.edtNVenda.Location = new System.Drawing.Point(838, 621);
            this.edtNVenda.Name = "edtNVenda";
            this.edtNVenda.Size = new System.Drawing.Size(150, 18);
            this.edtNVenda.TabIndex = 9;
            this.edtNVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtNumeroNota
            // 
            this.edtNumeroNota.BackColor = System.Drawing.Color.Transparent;
            this.edtNumeroNota.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtNumeroNota.ForeColor = System.Drawing.Color.Black;
            this.edtNumeroNota.Location = new System.Drawing.Point(627, 620);
            this.edtNumeroNota.Name = "edtNumeroNota";
            this.edtNumeroNota.Size = new System.Drawing.Size(200, 18);
            this.edtNumeroNota.TabIndex = 10;
            this.edtNumeroNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bobina
            // 
            this.bobina.BackColor = System.Drawing.Color.LightYellow;
            this.bobina.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bobina.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.bobina.ForeColor = System.Drawing.Color.Black;
            this.bobina.ItemHeight = 16;
            this.bobina.Location = new System.Drawing.Point(44, 234);
            this.bobina.Name = "bobina";
            this.bobina.Size = new System.Drawing.Size(400, 352);
            this.bobina.TabIndex = 1;
            this.bobina.TabStop = false;
            // 
            // editQuantidade
            // 
            this.editQuantidade.BackColor = System.Drawing.Color.WhiteSmoke;
            this.editQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editQuantidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editQuantidade.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editQuantidade.ForeColor = System.Drawing.Color.Black;
            this.editQuantidade.Location = new System.Drawing.Point(489, 365);
            this.editQuantidade.Name = "editQuantidade";
            this.editQuantidade.Size = new System.Drawing.Size(205, 26);
            this.editQuantidade.TabIndex = 44;
            this.editQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.editQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editQuantidade_KeyDown);
            this.editQuantidade.Leave += new System.EventHandler(this.editQuantidade_Leave);
            // 
            // editUnitario
            // 
            this.editUnitario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.editUnitario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editUnitario.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editUnitario.ForeColor = System.Drawing.Color.Black;
            this.editUnitario.Location = new System.Drawing.Point(489, 463);
            this.editUnitario.Name = "editUnitario";
            this.editUnitario.ReadOnly = true;
            this.editUnitario.Size = new System.Drawing.Size(205, 26);
            this.editUnitario.TabIndex = 45;
            this.editUnitario.TabStop = false;
            this.editUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // editTotalItem
            // 
            this.editTotalItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.editTotalItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTotalItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editTotalItem.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTotalItem.ForeColor = System.Drawing.Color.Black;
            this.editTotalItem.Location = new System.Drawing.Point(489, 563);
            this.editTotalItem.Name = "editTotalItem";
            this.editTotalItem.ReadOnly = true;
            this.editTotalItem.Size = new System.Drawing.Size(205, 26);
            this.editTotalItem.TabIndex = 46;
            this.editTotalItem.TabStop = false;
            this.editTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // editSubTotal
            // 
            this.editSubTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.editSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editSubTotal.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSubTotal.ForeColor = System.Drawing.Color.Black;
            this.editSubTotal.Location = new System.Drawing.Point(726, 563);
            this.editSubTotal.Name = "editSubTotal";
            this.editSubTotal.Size = new System.Drawing.Size(258, 26);
            this.editSubTotal.TabIndex = 47;
            this.editSubTotal.TabStop = false;
            this.editSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PanelBotoes
            // 
            this.PanelBotoes.BackColor = System.Drawing.Color.Transparent;
            this.PanelBotoes.Controls.Add(this.botaoF1);
            this.PanelBotoes.Controls.Add(this.botaoF7);
            this.PanelBotoes.Controls.Add(this.botaoF2);
            this.PanelBotoes.Controls.Add(this.botaoF8);
            this.PanelBotoes.Controls.Add(this.botaoF3);
            this.PanelBotoes.Controls.Add(this.botaoF9);
            this.PanelBotoes.Controls.Add(this.botaoF4);
            this.PanelBotoes.Controls.Add(this.botaoF10);
            this.PanelBotoes.Controls.Add(this.botaoF5);
            this.PanelBotoes.Controls.Add(this.botaoF11);
            this.PanelBotoes.Controls.Add(this.botaoF6);
            this.PanelBotoes.Controls.Add(this.botaoF12);
            this.PanelBotoes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelBotoes.Location = new System.Drawing.Point(14, 702);
            this.PanelBotoes.Name = "PanelBotoes";
            this.PanelBotoes.Size = new System.Drawing.Size(1000, 59);
            this.PanelBotoes.TabIndex = 48;
            // 
            // botaoF1
            // 
            this.botaoF1.BackColor = System.Drawing.Color.Transparent;
            this.botaoF1.FlatAppearance.BorderSize = 0;
            this.botaoF1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF1.ForeColor = System.Drawing.Color.Black;
            this.botaoF1.Image = global::NFCe.Properties.Resources._21botaoCliente;
            this.botaoF1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF1.Location = new System.Drawing.Point(1, 1);
            this.botaoF1.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF1.Name = "botaoF1";
            this.botaoF1.Size = new System.Drawing.Size(165, 26);
            this.botaoF1.TabIndex = 0;
            this.botaoF1.TabStop = false;
            this.botaoF1.Text = "F1 - Cliente";
            this.botaoF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF1.UseVisualStyleBackColor = false;
            this.botaoF1.Click += new System.EventHandler(this.botaoF1_Click);
            // 
            // botaoF7
            // 
            this.botaoF7.BackColor = System.Drawing.Color.Transparent;
            this.botaoF7.FlatAppearance.BorderSize = 0;
            this.botaoF7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF7.ForeColor = System.Drawing.Color.Black;
            this.botaoF7.Image = global::NFCe.Properties.Resources._21botaoEncerraVenda;
            this.botaoF7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF7.Location = new System.Drawing.Point(1, 29);
            this.botaoF7.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF7.Name = "botaoF7";
            this.botaoF7.Size = new System.Drawing.Size(165, 26);
            this.botaoF7.TabIndex = 16;
            this.botaoF7.TabStop = false;
            this.botaoF7.Text = "F7 - Encerra Venda";
            this.botaoF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF7.UseVisualStyleBackColor = false;
            this.botaoF7.Click += new System.EventHandler(this.botaoF7_Click);
            // 
            // botaoF2
            // 
            this.botaoF2.BackColor = System.Drawing.Color.Transparent;
            this.botaoF2.FlatAppearance.BorderSize = 0;
            this.botaoF2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF2.ForeColor = System.Drawing.Color.Black;
            this.botaoF2.Image = global::NFCe.Properties.Resources._21botaoMenuPrincipal;
            this.botaoF2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF2.Location = new System.Drawing.Point(168, 1);
            this.botaoF2.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF2.Name = "botaoF2";
            this.botaoF2.Size = new System.Drawing.Size(165, 26);
            this.botaoF2.TabIndex = 0;
            this.botaoF2.TabStop = false;
            this.botaoF2.Text = "F2 - Menu Principal";
            this.botaoF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF2.UseVisualStyleBackColor = false;
            this.botaoF2.Click += new System.EventHandler(this.botaoF2_Click);
            // 
            // botaoF8
            // 
            this.botaoF8.BackColor = System.Drawing.Color.Transparent;
            this.botaoF8.FlatAppearance.BorderSize = 0;
            this.botaoF8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF8.ForeColor = System.Drawing.Color.Black;
            this.botaoF8.Image = global::NFCe.Properties.Resources._21botaoCancelaItem;
            this.botaoF8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF8.Location = new System.Drawing.Point(168, 29);
            this.botaoF8.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF8.Name = "botaoF8";
            this.botaoF8.Size = new System.Drawing.Size(165, 26);
            this.botaoF8.TabIndex = 17;
            this.botaoF8.TabStop = false;
            this.botaoF8.Text = "F8 - Cancela Item";
            this.botaoF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF8.UseVisualStyleBackColor = false;
            this.botaoF8.Click += new System.EventHandler(this.botaoF8_Click);
            // 
            // botaoF3
            // 
            this.botaoF3.BackColor = System.Drawing.Color.Transparent;
            this.botaoF3.FlatAppearance.BorderSize = 0;
            this.botaoF3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF3.ForeColor = System.Drawing.Color.Black;
            this.botaoF3.Image = global::NFCe.Properties.Resources._21botaoMenuOperacoes;
            this.botaoF3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF3.Location = new System.Drawing.Point(335, 1);
            this.botaoF3.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF3.Name = "botaoF3";
            this.botaoF3.Size = new System.Drawing.Size(165, 26);
            this.botaoF3.TabIndex = 0;
            this.botaoF3.TabStop = false;
            this.botaoF3.Text = "F3 - Operações";
            this.botaoF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF3.UseVisualStyleBackColor = false;
            this.botaoF3.Click += new System.EventHandler(this.botaoF3_Click);
            // 
            // botaoF9
            // 
            this.botaoF9.BackColor = System.Drawing.Color.Transparent;
            this.botaoF9.FlatAppearance.BorderSize = 0;
            this.botaoF9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF9.ForeColor = System.Drawing.Color.Black;
            this.botaoF9.Image = global::NFCe.Properties.Resources._21botaoCancelaCupom;
            this.botaoF9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF9.Location = new System.Drawing.Point(335, 29);
            this.botaoF9.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF9.Name = "botaoF9";
            this.botaoF9.Size = new System.Drawing.Size(165, 26);
            this.botaoF9.TabIndex = 18;
            this.botaoF9.TabStop = false;
            this.botaoF9.Text = "F9 - Cancela Venda";
            this.botaoF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF9.UseVisualStyleBackColor = false;
            this.botaoF9.Click += new System.EventHandler(this.botaoF9_Click);
            // 
            // botaoF4
            // 
            this.botaoF4.BackColor = System.Drawing.Color.Transparent;
            this.botaoF4.FlatAppearance.BorderSize = 0;
            this.botaoF4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF4.ForeColor = System.Drawing.Color.Black;
            this.botaoF4.Image = global::NFCe.Properties.Resources._21botaoMenuFiscal;
            this.botaoF4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF4.Location = new System.Drawing.Point(502, 1);
            this.botaoF4.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF4.Name = "botaoF4";
            this.botaoF4.Size = new System.Drawing.Size(165, 26);
            this.botaoF4.TabIndex = 12;
            this.botaoF4.TabStop = false;
            this.botaoF4.Text = "F4-Status Operacional";
            this.botaoF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF4.UseVisualStyleBackColor = false;
            this.botaoF4.Click += new System.EventHandler(this.botaoF4_Click);
            // 
            // botaoF10
            // 
            this.botaoF10.BackColor = System.Drawing.Color.Transparent;
            this.botaoF10.FlatAppearance.BorderSize = 0;
            this.botaoF10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF10.ForeColor = System.Drawing.Color.Black;
            this.botaoF10.Image = global::NFCe.Properties.Resources._21botaoDesconto;
            this.botaoF10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF10.Location = new System.Drawing.Point(502, 29);
            this.botaoF10.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF10.Name = "botaoF10";
            this.botaoF10.Size = new System.Drawing.Size(165, 26);
            this.botaoF10.TabIndex = 19;
            this.botaoF10.TabStop = false;
            this.botaoF10.Text = "F10 - Desconto";
            this.botaoF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF10.UseVisualStyleBackColor = false;
            this.botaoF10.Click += new System.EventHandler(this.botaoF10_Click);
            // 
            // botaoF5
            // 
            this.botaoF5.BackColor = System.Drawing.Color.Transparent;
            this.botaoF5.FlatAppearance.BorderSize = 0;
            this.botaoF5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF5.ForeColor = System.Drawing.Color.Black;
            this.botaoF5.Image = global::NFCe.Properties.Resources._21botaoCalculadora;
            this.botaoF5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF5.Location = new System.Drawing.Point(669, 1);
            this.botaoF5.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF5.Name = "botaoF5";
            this.botaoF5.Size = new System.Drawing.Size(165, 26);
            this.botaoF5.TabIndex = 14;
            this.botaoF5.TabStop = false;
            this.botaoF5.Text = "F5 - Recuperar Venda";
            this.botaoF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF5.UseVisualStyleBackColor = false;
            this.botaoF5.Click += new System.EventHandler(this.botaoF5_Click);
            // 
            // botaoF11
            // 
            this.botaoF11.BackColor = System.Drawing.Color.Transparent;
            this.botaoF11.FlatAppearance.BorderSize = 0;
            this.botaoF11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF11.ForeColor = System.Drawing.Color.Black;
            this.botaoF11.Image = global::NFCe.Properties.Resources._21botaoGaveta;
            this.botaoF11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF11.Location = new System.Drawing.Point(669, 29);
            this.botaoF11.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF11.Name = "botaoF11";
            this.botaoF11.Size = new System.Drawing.Size(165, 26);
            this.botaoF11.TabIndex = 20;
            this.botaoF11.TabStop = false;
            this.botaoF11.Text = "F11 - Vendedor";
            this.botaoF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF11.UseVisualStyleBackColor = false;
            this.botaoF11.Click += new System.EventHandler(this.botaoF11_Click);
            // 
            // botaoF6
            // 
            this.botaoF6.BackColor = System.Drawing.Color.Transparent;
            this.botaoF6.FlatAppearance.BorderSize = 0;
            this.botaoF6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF6.ForeColor = System.Drawing.Color.Black;
            this.botaoF6.Image = global::NFCe.Properties.Resources._21botaoPesquisa;
            this.botaoF6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF6.Location = new System.Drawing.Point(836, 1);
            this.botaoF6.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF6.Name = "botaoF6";
            this.botaoF6.Size = new System.Drawing.Size(165, 26);
            this.botaoF6.TabIndex = 15;
            this.botaoF6.TabStop = false;
            this.botaoF6.Text = "F6 - Pesquisa Produto";
            this.botaoF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF6.UseVisualStyleBackColor = false;
            this.botaoF6.Click += new System.EventHandler(this.botaoF6_Click);
            // 
            // botaoF12
            // 
            this.botaoF12.BackColor = System.Drawing.Color.Transparent;
            this.botaoF12.FlatAppearance.BorderSize = 0;
            this.botaoF12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF12.ForeColor = System.Drawing.Color.Black;
            this.botaoF12.Image = global::NFCe.Properties.Resources._21botaoSair;
            this.botaoF12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF12.Location = new System.Drawing.Point(836, 29);
            this.botaoF12.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF12.Name = "botaoF12";
            this.botaoF12.Size = new System.Drawing.Size(165, 26);
            this.botaoF12.TabIndex = 21;
            this.botaoF12.TabStop = false;
            this.botaoF12.Text = "F12 - Sai do Caixa";
            this.botaoF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF12.UseVisualStyleBackColor = false;
            this.botaoF12.Click += new System.EventHandler(this.botaoF12_Click);
            // 
            // imageProduto
            // 
            this.imageProduto.BackColor = System.Drawing.Color.Transparent;
            this.imageProduto.ErrorImage = global::NFCe.Properties.Resources.padrao;
            this.imageProduto.Image = global::NFCe.Properties.Resources.padrao;
            this.imageProduto.InitialImage = global::NFCe.Properties.Resources.padrao;
            this.imageProduto.Location = new System.Drawing.Point(733, 252);
            this.imageProduto.Name = "imageProduto";
            this.imageProduto.Size = new System.Drawing.Size(244, 247);
            this.imageProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageProduto.TabIndex = 5;
            this.imageProduto.TabStop = false;
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.Transparent;
            this.panelTitulo.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTitulo.ForeColor = System.Drawing.Color.White;
            this.panelTitulo.Location = new System.Drawing.Point(270, 9);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(742, 23);
            this.panelTitulo.TabIndex = 49;
            this.panelTitulo.Text = "T2Ti.COM";
            this.panelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCliente
            // 
            this.labelCliente.BackColor = System.Drawing.Color.LightYellow;
            this.labelCliente.Location = new System.Drawing.Point(41, 589);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(401, 14);
            this.labelCliente.TabIndex = 50;
            this.labelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Caixa
            // 
            this.BackgroundImage = global::NFCe.Properties.Resources.Tela1024x768;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.PanelBotoes);
            this.Controls.Add(this.editSubTotal);
            this.Controls.Add(this.editTotalItem);
            this.Controls.Add(this.editUnitario);
            this.Controls.Add(this.editQuantidade);
            this.Controls.Add(this.labelTotalGeral);
            this.Controls.Add(this.labelMensagens);
            this.Controls.Add(this.imageProduto);
            this.Controls.Add(this.labelOperador);
            this.Controls.Add(this.labelCaixa);
            this.Controls.Add(this.labelDescontoAcrescimo);
            this.Controls.Add(this.edtNVenda);
            this.Controls.Add(this.edtNumeroNota);
            this.Controls.Add(this.bobina);
            this.Controls.Add(this.editCodigo);
            this.Controls.Add(this.labelDescricaoProduto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(89, 308);
            this.Name = "Caixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAF-ECF";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCaixa_KeyDown);
            this.PanelBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private System.Windows.Forms.FlowLayoutPanel PanelBotoes;
        private System.Windows.Forms.Button botaoF1;
        private System.Windows.Forms.Button botaoF2;
        private System.Windows.Forms.Button botaoF3;
        private System.Windows.Forms.Button botaoF4;
        private System.Windows.Forms.Button botaoF5;
        private System.Windows.Forms.Button botaoF6;
        private System.Windows.Forms.Button botaoF7;
        private System.Windows.Forms.Button botaoF8;
        private System.Windows.Forms.Button botaoF9;
        private System.Windows.Forms.Button botaoF10;
        private System.Windows.Forms.Button botaoF11;
        private System.Windows.Forms.Button botaoF12;
        public System.Windows.Forms.TextBox editCodigo;
        public System.Windows.Forms.Label labelOperador;
        public System.Windows.Forms.Label labelCaixa;
        public System.Windows.Forms.Label labelDescricaoProduto;
        public System.Windows.Forms.Label labelTotalGeral;
        public System.Windows.Forms.PictureBox imageProduto;
        public System.Windows.Forms.ListBox bobina;
        public System.Windows.Forms.TextBox editQuantidade;
        public System.Windows.Forms.TextBox editUnitario;
        public System.Windows.Forms.TextBox editTotalItem;
        public System.Windows.Forms.TextBox editSubTotal;
        public System.Windows.Forms.Label panelTitulo;
        public System.Windows.Forms.Label labelMensagens;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Timer timer1;

	}
}