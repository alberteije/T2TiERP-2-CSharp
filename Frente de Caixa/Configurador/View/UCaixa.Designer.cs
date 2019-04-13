namespace PafEcf.View
{
	partial class FCaixa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCaixa));
            this.editCodigo = new System.Windows.Forms.TextBox();
            this.bobina = new System.Windows.Forms.ListBox();
            this.editQuantidade = new System.Windows.Forms.TextBox();
            this.editUnitario = new System.Windows.Forms.TextBox();
            this.editTotalItem = new System.Windows.Forms.TextBox();
            this.editSubTotal = new System.Windows.Forms.TextBox();
            this.panelTitulo = new System.Windows.Forms.Button();
            this.labelDescricaoProduto = new System.Windows.Forms.Button();
            this.imageProduto = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.labelOperador = new System.Windows.Forms.LinkLabel();
            this.labelCaixa = new System.Windows.Forms.LinkLabel();
            this.labelDescontoAcrescimo = new System.Windows.Forms.LinkLabel();
            this.edtCOO = new System.Windows.Forms.LinkLabel();
            this.edtNVenda = new System.Windows.Forms.LinkLabel();
            this.PanelBotoes = new System.Windows.Forms.Button();
            this.labelTotalGeral = new System.Windows.Forms.LinkLabel();
            this.labelMensagens = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CarregarImagemFundo = new System.Windows.Forms.ToolStripMenuItem();
            this.EditarPropriedades = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // editCodigo
            // 
            this.editCodigo.BackColor = System.Drawing.Color.Gainsboro;
            this.editCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editCodigo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCodigo.ForeColor = System.Drawing.Color.Black;
            this.editCodigo.Location = new System.Drawing.Point(489, 265);
            this.editCodigo.Name = "editCodigo";
            this.editCodigo.ReadOnly = true;
            this.editCodigo.Size = new System.Drawing.Size(205, 26);
            this.editCodigo.TabIndex = 0;
            this.editCodigo.Text = "1234567891011";
            this.editCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.editCodigo, "Código do produto");
            this.editCodigo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.editCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // bobina
            // 
            this.bobina.BackColor = System.Drawing.Color.LightYellow;
            this.bobina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bobina.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.bobina.ForeColor = System.Drawing.Color.Black;
            this.bobina.ItemHeight = 16;
            this.bobina.Items.AddRange(new object[] {
            "------------------------------------------------",
            "               ** CUPOM FISCAL **               ",
            "------------------------------------------------",
            "ITEM CÓDIGO         DESCRIÇÃO                   ",
            "QTD.     UN      VL.UNIT.(R$) ST    VL.ITEM(R$)",
            "------------------------------------------------"});
            this.bobina.Location = new System.Drawing.Point(44, 240);
            this.bobina.Name = "bobina";
            this.bobina.Size = new System.Drawing.Size(400, 354);
            this.bobina.TabIndex = 1;
            this.toolTip.SetToolTip(this.bobina, "Bobina");
            this.bobina.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.bobina.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // editQuantidade
            // 
            this.editQuantidade.BackColor = System.Drawing.Color.Gainsboro;
            this.editQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editQuantidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editQuantidade.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editQuantidade.ForeColor = System.Drawing.Color.Black;
            this.editQuantidade.Location = new System.Drawing.Point(489, 365);
            this.editQuantidade.Name = "editQuantidade";
            this.editQuantidade.ReadOnly = true;
            this.editQuantidade.Size = new System.Drawing.Size(205, 26);
            this.editQuantidade.TabIndex = 44;
            this.editQuantidade.Text = "0,00";
            this.editQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.editQuantidade, "Quantidade");
            this.editQuantidade.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.editQuantidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // editUnitario
            // 
            this.editUnitario.BackColor = System.Drawing.Color.Gainsboro;
            this.editUnitario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editUnitario.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editUnitario.ForeColor = System.Drawing.Color.Black;
            this.editUnitario.Location = new System.Drawing.Point(489, 463);
            this.editUnitario.Name = "editUnitario";
            this.editUnitario.ReadOnly = true;
            this.editUnitario.Size = new System.Drawing.Size(205, 26);
            this.editUnitario.TabIndex = 45;
            this.editUnitario.Text = "0,00";
            this.editUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.editUnitario, "Valor unitário do produto");
            this.editUnitario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.editUnitario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // editTotalItem
            // 
            this.editTotalItem.BackColor = System.Drawing.Color.Gainsboro;
            this.editTotalItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editTotalItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editTotalItem.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTotalItem.ForeColor = System.Drawing.Color.Black;
            this.editTotalItem.Location = new System.Drawing.Point(489, 563);
            this.editTotalItem.Name = "editTotalItem";
            this.editTotalItem.ReadOnly = true;
            this.editTotalItem.Size = new System.Drawing.Size(205, 26);
            this.editTotalItem.TabIndex = 46;
            this.editTotalItem.Text = "0,00";
            this.editTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.editTotalItem, "Valor total do produto");
            this.editTotalItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.editTotalItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // editSubTotal
            // 
            this.editSubTotal.BackColor = System.Drawing.Color.Gainsboro;
            this.editSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editSubTotal.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSubTotal.ForeColor = System.Drawing.Color.Black;
            this.editSubTotal.Location = new System.Drawing.Point(726, 563);
            this.editSubTotal.Name = "editSubTotal";
            this.editSubTotal.Size = new System.Drawing.Size(258, 26);
            this.editSubTotal.TabIndex = 47;
            this.editSubTotal.Text = "0,00";
            this.editSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.editSubTotal, "Valor subtotal do produto");
            this.editSubTotal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.editSubTotal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.Transparent;
            this.panelTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.panelTitulo.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTitulo.ForeColor = System.Drawing.Color.White;
            this.panelTitulo.Location = new System.Drawing.Point(270, 9);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(742, 23);
            this.panelTitulo.TabIndex = 51;
            this.panelTitulo.Text = "T2Ti PDV - T2Ti Tecnologia da Informação Ltda. (61) 3042.5277";
            this.toolTip.SetToolTip(this.panelTitulo, "Título da Janela");
            this.panelTitulo.UseCompatibleTextRendering = true;
            this.panelTitulo.UseVisualStyleBackColor = false;
            this.panelTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.panelTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // labelDescricaoProduto
            // 
            this.labelDescricaoProduto.BackColor = System.Drawing.Color.Transparent;
            this.labelDescricaoProduto.FlatAppearance.BorderSize = 0;
            this.labelDescricaoProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelDescricaoProduto.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescricaoProduto.ForeColor = System.Drawing.Color.White;
            this.labelDescricaoProduto.Location = new System.Drawing.Point(42, 112);
            this.labelDescricaoProduto.Name = "labelDescricaoProduto";
            this.labelDescricaoProduto.Size = new System.Drawing.Size(941, 80);
            this.labelDescricaoProduto.TabIndex = 52;
            this.labelDescricaoProduto.Text = "Descrição do Produto";
            this.toolTip.SetToolTip(this.labelDescricaoProduto, "Descrição do Produto");
            this.labelDescricaoProduto.UseCompatibleTextRendering = true;
            this.labelDescricaoProduto.UseVisualStyleBackColor = false;
            this.labelDescricaoProduto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.labelDescricaoProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // imageProduto
            // 
            this.imageProduto.BackColor = System.Drawing.Color.Transparent;
            this.imageProduto.FlatAppearance.BorderSize = 0;
            this.imageProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.imageProduto.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageProduto.ForeColor = System.Drawing.Color.White;
            this.imageProduto.Image = global::ConfiguraPAFECF.Properties.Resources.padrao;
            this.imageProduto.Location = new System.Drawing.Point(733, 252);
            this.imageProduto.Name = "imageProduto";
            this.imageProduto.Size = new System.Drawing.Size(244, 247);
            this.imageProduto.TabIndex = 53;
            this.toolTip.SetToolTip(this.imageProduto, "Imagem do produto");
            this.imageProduto.UseCompatibleTextRendering = true;
            this.imageProduto.UseVisualStyleBackColor = false;
            this.imageProduto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.imageProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // labelOperador
            // 
            this.labelOperador.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelOperador.BackColor = System.Drawing.Color.Transparent;
            this.labelOperador.DisabledLinkColor = System.Drawing.Color.Black;
            this.labelOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperador.ForeColor = System.Drawing.Color.Black;
            this.labelOperador.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
            this.labelOperador.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.labelOperador.LinkColor = System.Drawing.Color.Black;
            this.labelOperador.Location = new System.Drawing.Point(834, 64);
            this.labelOperador.Name = "labelOperador";
            this.labelOperador.Size = new System.Drawing.Size(150, 13);
            this.labelOperador.TabIndex = 55;
            this.labelOperador.TabStop = true;
            this.labelOperador.Text = "Operador";
            this.labelOperador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.labelOperador, "Nome do operador");
            this.labelOperador.VisitedLinkColor = System.Drawing.Color.Black;
            this.labelOperador.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.labelOperador.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // labelCaixa
            // 
            this.labelCaixa.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelCaixa.BackColor = System.Drawing.Color.Transparent;
            this.labelCaixa.DisabledLinkColor = System.Drawing.Color.Black;
            this.labelCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaixa.ForeColor = System.Drawing.Color.Black;
            this.labelCaixa.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.labelCaixa.LinkColor = System.Drawing.Color.Black;
            this.labelCaixa.Location = new System.Drawing.Point(834, 84);
            this.labelCaixa.Name = "labelCaixa";
            this.labelCaixa.Size = new System.Drawing.Size(150, 13);
            this.labelCaixa.TabIndex = 56;
            this.labelCaixa.TabStop = true;
            this.labelCaixa.Text = "Caixa";
            this.labelCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.labelCaixa, "Nome do terminal de caixa");
            this.labelCaixa.VisitedLinkColor = System.Drawing.Color.Black;
            this.labelCaixa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.labelCaixa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // labelDescontoAcrescimo
            // 
            this.labelDescontoAcrescimo.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelDescontoAcrescimo.BackColor = System.Drawing.Color.Transparent;
            this.labelDescontoAcrescimo.DisabledLinkColor = System.Drawing.Color.Black;
            this.labelDescontoAcrescimo.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescontoAcrescimo.ForeColor = System.Drawing.Color.Red;
            this.labelDescontoAcrescimo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.labelDescontoAcrescimo.LinkColor = System.Drawing.Color.Red;
            this.labelDescontoAcrescimo.Location = new System.Drawing.Point(182, 620);
            this.labelDescontoAcrescimo.Name = "labelDescontoAcrescimo";
            this.labelDescontoAcrescimo.Size = new System.Drawing.Size(260, 18);
            this.labelDescontoAcrescimo.TabIndex = 57;
            this.labelDescontoAcrescimo.TabStop = true;
            this.labelDescontoAcrescimo.Text = "Desconto / Acréscimo";
            this.labelDescontoAcrescimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.labelDescontoAcrescimo, "Valor do Desconto / Acréscimo");
            this.labelDescontoAcrescimo.VisitedLinkColor = System.Drawing.Color.Black;
            this.labelDescontoAcrescimo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.labelDescontoAcrescimo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // edtCOO
            // 
            this.edtCOO.ActiveLinkColor = System.Drawing.Color.Black;
            this.edtCOO.BackColor = System.Drawing.Color.Transparent;
            this.edtCOO.DisabledLinkColor = System.Drawing.Color.Black;
            this.edtCOO.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtCOO.ForeColor = System.Drawing.Color.Black;
            this.edtCOO.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.edtCOO.LinkColor = System.Drawing.Color.Black;
            this.edtCOO.Location = new System.Drawing.Point(627, 620);
            this.edtCOO.Name = "edtCOO";
            this.edtCOO.Size = new System.Drawing.Size(180, 18);
            this.edtCOO.TabIndex = 58;
            this.edtCOO.TabStop = true;
            this.edtCOO.Text = "COO";
            this.edtCOO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.edtCOO, "Número do COO");
            this.edtCOO.VisitedLinkColor = System.Drawing.Color.Black;
            this.edtCOO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.edtCOO.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // edtNVenda
            // 
            this.edtNVenda.ActiveLinkColor = System.Drawing.Color.Black;
            this.edtNVenda.BackColor = System.Drawing.Color.Transparent;
            this.edtNVenda.DisabledLinkColor = System.Drawing.Color.Black;
            this.edtNVenda.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtNVenda.ForeColor = System.Drawing.Color.Black;
            this.edtNVenda.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.edtNVenda.LinkColor = System.Drawing.Color.Black;
            this.edtNVenda.Location = new System.Drawing.Point(807, 620);
            this.edtNVenda.Name = "edtNVenda";
            this.edtNVenda.Size = new System.Drawing.Size(180, 18);
            this.edtNVenda.TabIndex = 59;
            this.edtNVenda.TabStop = true;
            this.edtNVenda.Text = "Número Venda";
            this.edtNVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.edtNVenda, "Número da venda");
            this.edtNVenda.VisitedLinkColor = System.Drawing.Color.Black;
            this.edtNVenda.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.edtNVenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // PanelBotoes
            // 
            this.PanelBotoes.BackColor = System.Drawing.Color.Transparent;
            this.PanelBotoes.BackgroundImage = global::ConfiguraPAFECF.Properties.Resources.PanelBotoes;
            this.PanelBotoes.FlatAppearance.BorderSize = 0;
            this.PanelBotoes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PanelBotoes.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelBotoes.ForeColor = System.Drawing.Color.White;
            this.PanelBotoes.Location = new System.Drawing.Point(14, 702);
            this.PanelBotoes.Name = "PanelBotoes";
            this.PanelBotoes.Size = new System.Drawing.Size(1000, 59);
            this.PanelBotoes.TabIndex = 60;
            this.toolTip.SetToolTip(this.PanelBotoes, "Panel de Botões");
            this.PanelBotoes.UseCompatibleTextRendering = true;
            this.PanelBotoes.UseVisualStyleBackColor = false;
            this.PanelBotoes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.PanelBotoes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // labelTotalGeral
            // 
            this.labelTotalGeral.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelTotalGeral.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalGeral.DisabledLinkColor = System.Drawing.Color.Black;
            this.labelTotalGeral.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalGeral.ForeColor = System.Drawing.Color.Yellow;
            this.labelTotalGeral.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.labelTotalGeral.LinkColor = System.Drawing.Color.Yellow;
            this.labelTotalGeral.Location = new System.Drawing.Point(40, 648);
            this.labelTotalGeral.Name = "labelTotalGeral";
            this.labelTotalGeral.Size = new System.Drawing.Size(402, 46);
            this.labelTotalGeral.TabIndex = 61;
            this.labelTotalGeral.TabStop = true;
            this.labelTotalGeral.Text = "0,00";
            this.labelTotalGeral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.labelTotalGeral, "Total geral da venda");
            this.labelTotalGeral.VisitedLinkColor = System.Drawing.Color.Black;
            this.labelTotalGeral.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.labelTotalGeral.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // labelMensagens
            // 
            this.labelMensagens.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelMensagens.BackColor = System.Drawing.Color.Transparent;
            this.labelMensagens.DisabledLinkColor = System.Drawing.Color.Black;
            this.labelMensagens.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensagens.ForeColor = System.Drawing.Color.Yellow;
            this.labelMensagens.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.labelMensagens.LinkColor = System.Drawing.Color.Yellow;
            this.labelMensagens.Location = new System.Drawing.Point(487, 648);
            this.labelMensagens.Name = "labelMensagens";
            this.labelMensagens.Size = new System.Drawing.Size(497, 46);
            this.labelMensagens.TabIndex = 62;
            this.labelMensagens.TabStop = true;
            this.labelMensagens.Text = "Todas as mensagens devem ser carregadas nesse local";
            this.labelMensagens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.labelMensagens, "Mensagens do sistema");
            this.labelMensagens.VisitedLinkColor = System.Drawing.Color.Black;
            this.labelMensagens.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseDown);
            this.labelMensagens.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoverControle_MouseMove);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CarregarImagemFundo,
            this.EditarPropriedades});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(218, 48);
            this.contextMenuStrip.Text = "Opções";
            // 
            // CarregarImagemFundo
            // 
            this.CarregarImagemFundo.Image = global::ConfiguraPAFECF.Properties.Resources.view_16;
            this.CarregarImagemFundo.Name = "CarregarImagemFundo";
            this.CarregarImagemFundo.Size = new System.Drawing.Size(217, 22);
            this.CarregarImagemFundo.Text = "Carregar Imagem de Fundo";
            this.CarregarImagemFundo.Click += new System.EventHandler(this.CarregarImagemFundo_Click);
            // 
            // EditarPropriedades
            // 
            this.EditarPropriedades.Image = global::ConfiguraPAFECF.Properties.Resources.tree_16;
            this.EditarPropriedades.Name = "EditarPropriedades";
            this.EditarPropriedades.Size = new System.Drawing.Size(217, 22);
            this.EditarPropriedades.Text = "Editar Propriedades";
            this.EditarPropriedades.Click += new System.EventHandler(this.EditarPropriedades_Click);
            // 
            // FCaixa
            // 
            this.BackgroundImage = global::ConfiguraPAFECF.Properties.Resources.Tela1024x768;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.labelMensagens);
            this.Controls.Add(this.labelTotalGeral);
            this.Controls.Add(this.PanelBotoes);
            this.Controls.Add(this.edtNVenda);
            this.Controls.Add(this.edtCOO);
            this.Controls.Add(this.labelDescontoAcrescimo);
            this.Controls.Add(this.labelCaixa);
            this.Controls.Add(this.labelOperador);
            this.Controls.Add(this.imageProduto);
            this.Controls.Add(this.labelDescricaoProduto);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.editSubTotal);
            this.Controls.Add(this.editTotalItem);
            this.Controls.Add(this.editUnitario);
            this.Controls.Add(this.editQuantidade);
            this.Controls.Add(this.bobina);
            this.Controls.Add(this.editCodigo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(89, 308);
            this.Name = "FCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAF-ECF";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCaixa_KeyDown);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public System.Windows.Forms.TextBox editCodigo;
        public System.Windows.Forms.ListBox bobina;
        public System.Windows.Forms.TextBox editQuantidade;
        public System.Windows.Forms.TextBox editUnitario;
        public System.Windows.Forms.TextBox editTotalItem;
        public System.Windows.Forms.TextBox editSubTotal;
        private System.Windows.Forms.Button panelTitulo;
        private System.Windows.Forms.Button labelDescricaoProduto;
        private System.Windows.Forms.Button imageProduto;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.LinkLabel labelOperador;
        private System.Windows.Forms.LinkLabel labelCaixa;
        private System.Windows.Forms.LinkLabel labelDescontoAcrescimo;
        private System.Windows.Forms.LinkLabel edtCOO;
        private System.Windows.Forms.LinkLabel edtNVenda;
        private System.Windows.Forms.Button PanelBotoes;
        private System.Windows.Forms.LinkLabel labelTotalGeral;
        private System.Windows.Forms.LinkLabel labelMensagens;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EditarPropriedades;
        private System.Windows.Forms.ToolStripMenuItem CarregarImagemFundo;

	}
}