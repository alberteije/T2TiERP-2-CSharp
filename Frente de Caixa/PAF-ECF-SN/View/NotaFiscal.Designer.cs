namespace PafEcf.View
{
	partial class NotaFiscal
    {
		private System.Windows.Forms.PictureBox Image1;
		private System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox editCodigo;
		private System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.ComboBox cmbNomeVendedor;
        private System.Windows.Forms.GroupBox GroupBox6;
        private System.Windows.Forms.GroupBox GroupBox5;
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
            this.editCodigo = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.editTotalItem = new System.Windows.Forms.TextBox();
            this.editUnitario = new System.Windows.Forms.TextBox();
            this.editQuantidade = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.editCpfCnpj = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.EditNome = new System.Windows.Forms.TextBox();
            this.editCodigoCliente = new System.Windows.Forms.TextBox();
            this.EditHoraEmissao = new System.Windows.Forms.MaskedTextBox();
            this.EditDataEmissao = new System.Windows.Forms.DateTimePicker();
            this.editCodigoVendedor = new System.Windows.Forms.TextBox();
            this.EditNumeroNF = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.cmbNomeVendedor = new System.Windows.Forms.ComboBox();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.GridItens = new System.Windows.Forms.DataGridView();
            this.GridPrincipal_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_UNIDADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrincipal_VALOR_VENDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.botaoESC = new System.Windows.Forms.Button();
            this.botaoF12 = new System.Windows.Forms.Button();
            this.botaoF10 = new System.Windows.Forms.Button();
            this.botaoF8 = new System.Windows.Forms.Button();
            this.botaoF6 = new System.Windows.Forms.Button();
            this.botaoF1 = new System.Windows.Forms.Button();
            this.PanelBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.labelDescricaoProduto = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridItens)).BeginInit();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.PanelBotoes.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // editCodigo
            // 
            this.editCodigo.BackColor = System.Drawing.Color.White;
            this.editCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editCodigo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCodigo.ForeColor = System.Drawing.Color.Black;
            this.editCodigo.Location = new System.Drawing.Point(9, 35);
            this.editCodigo.Name = "editCodigo";
            this.editCodigo.Size = new System.Drawing.Size(171, 27);
            this.editCodigo.TabIndex = 0;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.editTotalItem);
            this.GroupBox1.Controls.Add(this.editUnitario);
            this.GroupBox1.Controls.Add(this.editQuantidade);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.editCodigo);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(59, 195);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(551, 68);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Digite os Produtos:";
            // 
            // editTotalItem
            // 
            this.editTotalItem.BackColor = System.Drawing.Color.White;
            this.editTotalItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editTotalItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTotalItem.ForeColor = System.Drawing.Color.Black;
            this.editTotalItem.Location = new System.Drawing.Point(427, 35);
            this.editTotalItem.Name = "editTotalItem";
            this.editTotalItem.Size = new System.Drawing.Size(118, 27);
            this.editTotalItem.TabIndex = 6;
            this.editTotalItem.Text = "0,00";
            this.editTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // editUnitario
            // 
            this.editUnitario.BackColor = System.Drawing.Color.White;
            this.editUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editUnitario.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editUnitario.ForeColor = System.Drawing.Color.Black;
            this.editUnitario.Location = new System.Drawing.Point(308, 35);
            this.editUnitario.Name = "editUnitario";
            this.editUnitario.Size = new System.Drawing.Size(108, 27);
            this.editUnitario.TabIndex = 5;
            this.editUnitario.Text = "0,00";
            this.editUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // editQuantidade
            // 
            this.editQuantidade.BackColor = System.Drawing.Color.White;
            this.editQuantidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editQuantidade.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editQuantidade.ForeColor = System.Drawing.Color.Black;
            this.editQuantidade.Location = new System.Drawing.Point(189, 35);
            this.editQuantidade.Name = "editQuantidade";
            this.editQuantidade.Size = new System.Drawing.Size(108, 27);
            this.editQuantidade.TabIndex = 4;
            this.editQuantidade.Text = "0,000";
            this.editQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(10, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(132, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "&Código do Produto:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(187, 16);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(87, 16);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Quantidade:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(305, 16);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(101, 16);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Valor Unitário:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(423, 16);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(83, 16);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Valor Total:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.editCpfCnpj);
            this.GroupBox2.Controls.Add(this.label17);
            this.GroupBox2.Controls.Add(this.label16);
            this.GroupBox2.Controls.Add(this.EditNome);
            this.GroupBox2.Controls.Add(this.editCodigoCliente);
            this.GroupBox2.Controls.Add(this.EditHoraEmissao);
            this.GroupBox2.Controls.Add(this.EditDataEmissao);
            this.GroupBox2.Controls.Add(this.editCodigoVendedor);
            this.GroupBox2.Controls.Add(this.EditNumeroNF);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.Label11);
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.Label12);
            this.GroupBox2.Controls.Add(this.Label13);
            this.GroupBox2.Controls.Add(this.cmbNomeVendedor);
            this.GroupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(59, 8);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(725, 121);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Digitação de Notas Fiscais";
            // 
            // editCpfCnpj
            // 
            this.editCpfCnpj.Location = new System.Drawing.Point(509, 93);
            this.editCpfCnpj.Mask = "###.###.###-##";
            this.editCpfCnpj.Name = "editCpfCnpj";
            this.editCpfCnpj.Size = new System.Drawing.Size(204, 22);
            this.editCpfCnpj.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(510, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 16);
            this.label17.TabIndex = 12;
            this.label17.Text = "CPF/CNPJ:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(130, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 16);
            this.label16.TabIndex = 11;
            this.label16.Text = "Nome Destinatário:";
            // 
            // EditNome
            // 
            this.EditNome.BackColor = System.Drawing.Color.White;
            this.EditNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EditNome.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditNome.ForeColor = System.Drawing.Color.Black;
            this.EditNome.Location = new System.Drawing.Point(129, 92);
            this.EditNome.Name = "EditNome";
            this.EditNome.Size = new System.Drawing.Size(359, 23);
            this.EditNome.TabIndex = 10;
            // 
            // editCodigoCliente
            // 
            this.editCodigoCliente.BackColor = System.Drawing.Color.White;
            this.editCodigoCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editCodigoCliente.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCodigoCliente.ForeColor = System.Drawing.Color.Black;
            this.editCodigoCliente.Location = new System.Drawing.Point(14, 92);
            this.editCodigoCliente.Name = "editCodigoCliente";
            this.editCodigoCliente.Size = new System.Drawing.Size(101, 23);
            this.editCodigoCliente.TabIndex = 9;
            this.editCodigoCliente.Text = "0";
            this.editCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EditHoraEmissao
            // 
            this.EditHoraEmissao.Location = new System.Drawing.Point(613, 43);
            this.EditHoraEmissao.Mask = "##:##:##";
            this.EditHoraEmissao.Name = "EditHoraEmissao";
            this.EditHoraEmissao.Size = new System.Drawing.Size(100, 22);
            this.EditHoraEmissao.TabIndex = 8;
            // 
            // EditDataEmissao
            // 
            this.EditDataEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EditDataEmissao.Location = new System.Drawing.Point(482, 42);
            this.EditDataEmissao.Name = "EditDataEmissao";
            this.EditDataEmissao.Size = new System.Drawing.Size(110, 22);
            this.EditDataEmissao.TabIndex = 7;
            // 
            // editCodigoVendedor
            // 
            this.editCodigoVendedor.BackColor = System.Drawing.Color.White;
            this.editCodigoVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editCodigoVendedor.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCodigoVendedor.ForeColor = System.Drawing.Color.Black;
            this.editCodigoVendedor.Location = new System.Drawing.Point(113, 42);
            this.editCodigoVendedor.Name = "editCodigoVendedor";
            this.editCodigoVendedor.Size = new System.Drawing.Size(61, 23);
            this.editCodigoVendedor.TabIndex = 6;
            this.editCodigoVendedor.Text = "0";
            this.editCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EditNumeroNF
            // 
            this.EditNumeroNF.BackColor = System.Drawing.Color.White;
            this.EditNumeroNF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EditNumeroNF.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditNumeroNF.ForeColor = System.Drawing.Color.Black;
            this.EditNumeroNF.Location = new System.Drawing.Point(13, 42);
            this.EditNumeroNF.Name = "EditNumeroNF";
            this.EditNumeroNF.Size = new System.Drawing.Size(84, 23);
            this.EditNumeroNF.TabIndex = 5;
            this.EditNumeroNF.Text = "0";
            this.EditNumeroNF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(11, 73);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(104, 16);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Có&digo Cliente:";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(11, 22);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(62, 16);
            this.Label11.TabIndex = 1;
            this.Label11.Text = "Número:";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(113, 22);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(152, 16);
            this.Label9.TabIndex = 2;
            this.Label9.Text = "Vendedor/Funcionario";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(480, 22);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(99, 16);
            this.Label12.TabIndex = 3;
            this.Label12.Text = "Data Emissão:";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(614, 22);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(99, 16);
            this.Label13.TabIndex = 4;
            this.Label13.Text = "Hora Emissão:";
            // 
            // cmbNomeVendedor
            // 
            this.cmbNomeVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNomeVendedor.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cmbNomeVendedor.ForeColor = System.Drawing.Color.Black;
            this.cmbNomeVendedor.FormattingEnabled = true;
            this.cmbNomeVendedor.Location = new System.Drawing.Point(174, 41);
            this.cmbNomeVendedor.Name = "cmbNomeVendedor";
            this.cmbNomeVendedor.Size = new System.Drawing.Size(294, 24);
            this.cmbNomeVendedor.TabIndex = 2;
            // 
            // GroupBox6
            // 
            this.GroupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox6.Controls.Add(this.GridItens);
            this.GroupBox6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.GroupBox6.ForeColor = System.Drawing.Color.Black;
            this.GroupBox6.Location = new System.Drawing.Point(58, 264);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(725, 177);
            this.GroupBox6.TabIndex = 3;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Produtos Lançados:";
            // 
            // GridItens
            // 
            this.GridItens.AllowUserToAddRows = false;
            this.GridItens.AllowUserToDeleteRows = false;
            this.GridItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridPrincipal_ID,
            this.GridPrincipal_NOME,
            this.GridPrincipal_UNIDADE,
            this.GridPrincipal_VALOR_VENDA});
            this.GridItens.Font = new System.Drawing.Font("Tahoma", 8F);
            this.GridItens.Location = new System.Drawing.Point(8, 18);
            this.GridItens.MultiSelect = false;
            this.GridItens.Name = "GridItens";
            this.GridItens.ReadOnly = true;
            this.GridItens.Size = new System.Drawing.Size(711, 153);
            this.GridItens.TabIndex = 104;
            this.GridItens.Text = "Select columns";
            // 
            // GridPrincipal_ID
            // 
            this.GridPrincipal_ID.DataPropertyName = "Id";
            this.GridPrincipal_ID.HeaderText = "Código";
            this.GridPrincipal_ID.Name = "GridPrincipal_ID";
            this.GridPrincipal_ID.ReadOnly = true;
            // 
            // GridPrincipal_NOME
            // 
            this.GridPrincipal_NOME.DataPropertyName = "Nome";
            this.GridPrincipal_NOME.HeaderText = "Nome";
            this.GridPrincipal_NOME.Name = "GridPrincipal_NOME";
            this.GridPrincipal_NOME.ReadOnly = true;
            this.GridPrincipal_NOME.Width = 405;
            // 
            // GridPrincipal_UNIDADE
            // 
            this.GridPrincipal_UNIDADE.DataPropertyName = "UnidadeProduto";
            this.GridPrincipal_UNIDADE.HeaderText = "Unidade";
            this.GridPrincipal_UNIDADE.Name = "GridPrincipal_UNIDADE";
            this.GridPrincipal_UNIDADE.ReadOnly = true;
            this.GridPrincipal_UNIDADE.Width = 57;
            // 
            // GridPrincipal_VALOR_VENDA
            // 
            this.GridPrincipal_VALOR_VENDA.DataPropertyName = "ValorVenda";
            this.GridPrincipal_VALOR_VENDA.HeaderText = "Preço de Venda";
            this.GridPrincipal_VALOR_VENDA.Name = "GridPrincipal_VALOR_VENDA";
            this.GridPrincipal_VALOR_VENDA.ReadOnly = true;
            this.GridPrincipal_VALOR_VENDA.Width = 148;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox5.Controls.Add(this.label10);
            this.GroupBox5.Controls.Add(this.label14);
            this.GroupBox5.Controls.Add(this.label15);
            this.GroupBox5.Controls.Add(this.label8);
            this.GroupBox5.Controls.Add(this.label7);
            this.GroupBox5.Controls.Add(this.label6);
            this.GroupBox5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.GroupBox5.ForeColor = System.Drawing.Color.Black;
            this.GroupBox5.Location = new System.Drawing.Point(616, 134);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(168, 128);
            this.GroupBox5.TabIndex = 5;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Resumo da Operação:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(86, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "0,00";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(86, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 16);
            this.label14.TabIndex = 8;
            this.label14.Text = "0,00";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(86, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 16);
            this.label15.TabIndex = 7;
            this.label15.Text = "0,00";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(6, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Total:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(6, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Desconto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(6, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Sub-Total:";
            // 
            // Image1
            // 
            this.Image1.Image = global::PafEcf.Properties.Resources.telaDocumento04;
            this.Image1.Location = new System.Drawing.Point(4, 12);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(51, 56);
            this.Image1.TabIndex = 0;
            this.Image1.TabStop = false;
            // 
            // botaoESC
            // 
            this.botaoESC.BackColor = System.Drawing.Color.Transparent;
            this.botaoESC.FlatAppearance.BorderSize = 0;
            this.botaoESC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoESC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoESC.ForeColor = System.Drawing.Color.Black;
            this.botaoESC.Image = global::PafEcf.Properties.Resources._21botaoSair;
            this.botaoESC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoESC.Location = new System.Drawing.Point(621, 1);
            this.botaoESC.Margin = new System.Windows.Forms.Padding(1);
            this.botaoESC.Name = "botaoESC";
            this.botaoESC.Size = new System.Drawing.Size(100, 26);
            this.botaoESC.TabIndex = 21;
            this.botaoESC.TabStop = false;
            this.botaoESC.Text = "ESC - Sair";
            this.botaoESC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoESC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoESC.UseVisualStyleBackColor = false;
            // 
            // botaoF12
            // 
            this.botaoF12.BackColor = System.Drawing.Color.Transparent;
            this.botaoF12.FlatAppearance.BorderSize = 0;
            this.botaoF12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF12.ForeColor = System.Drawing.Color.Black;
            this.botaoF12.Image = global::PafEcf.Properties.Resources._21botaoMenuFiscal;
            this.botaoF12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF12.Location = new System.Drawing.Point(509, 1);
            this.botaoF12.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF12.Name = "botaoF12";
            this.botaoF12.Size = new System.Drawing.Size(110, 26);
            this.botaoF12.TabIndex = 15;
            this.botaoF12.TabStop = false;
            this.botaoF12.Text = "F12 - Gravar";
            this.botaoF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF12.UseVisualStyleBackColor = false;
            // 
            // botaoF10
            // 
            this.botaoF10.BackColor = System.Drawing.Color.Transparent;
            this.botaoF10.FlatAppearance.BorderSize = 0;
            this.botaoF10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF10.ForeColor = System.Drawing.Color.Black;
            this.botaoF10.Image = global::PafEcf.Properties.Resources._21botaoDesconto;
            this.botaoF10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF10.Location = new System.Drawing.Point(377, 1);
            this.botaoF10.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF10.Name = "botaoF10";
            this.botaoF10.Size = new System.Drawing.Size(130, 26);
            this.botaoF10.TabIndex = 20;
            this.botaoF10.TabStop = false;
            this.botaoF10.Text = "F10 - Desconto";
            this.botaoF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF10.UseVisualStyleBackColor = false;
            // 
            // botaoF8
            // 
            this.botaoF8.BackColor = System.Drawing.Color.Transparent;
            this.botaoF8.FlatAppearance.BorderSize = 0;
            this.botaoF8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF8.ForeColor = System.Drawing.Color.Black;
            this.botaoF8.Image = global::PafEcf.Properties.Resources._21botaoCancelaCupom;
            this.botaoF8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF8.Location = new System.Drawing.Point(225, 1);
            this.botaoF8.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF8.Name = "botaoF8";
            this.botaoF8.Size = new System.Drawing.Size(150, 26);
            this.botaoF8.TabIndex = 17;
            this.botaoF8.TabStop = false;
            this.botaoF8.Text = "F8 - Cancela Item";
            this.botaoF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF8.UseVisualStyleBackColor = false;
            // 
            // botaoF6
            // 
            this.botaoF6.BackColor = System.Drawing.Color.Transparent;
            this.botaoF6.FlatAppearance.BorderSize = 0;
            this.botaoF6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF6.ForeColor = System.Drawing.Color.Black;
            this.botaoF6.Image = global::PafEcf.Properties.Resources._21botaoCliente;
            this.botaoF6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF6.Location = new System.Drawing.Point(113, 1);
            this.botaoF6.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF6.Name = "botaoF6";
            this.botaoF6.Size = new System.Drawing.Size(110, 26);
            this.botaoF6.TabIndex = 0;
            this.botaoF6.TabStop = false;
            this.botaoF6.Text = "F6 - Cliente";
            this.botaoF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF6.UseVisualStyleBackColor = false;
            // 
            // botaoF1
            // 
            this.botaoF1.BackColor = System.Drawing.Color.Transparent;
            this.botaoF1.FlatAppearance.BorderSize = 0;
            this.botaoF1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoF1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoF1.ForeColor = System.Drawing.Color.Black;
            this.botaoF1.Image = global::PafEcf.Properties.Resources._21botaoPesquisa;
            this.botaoF1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF1.Location = new System.Drawing.Point(1, 1);
            this.botaoF1.Margin = new System.Windows.Forms.Padding(1);
            this.botaoF1.Name = "botaoF1";
            this.botaoF1.Size = new System.Drawing.Size(110, 26);
            this.botaoF1.TabIndex = 0;
            this.botaoF1.TabStop = false;
            this.botaoF1.Text = "F1 - Produto";
            this.botaoF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoF1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botaoF1.UseVisualStyleBackColor = false;
            // 
            // PanelBotoes
            // 
            this.PanelBotoes.BackColor = System.Drawing.Color.Transparent;
            this.PanelBotoes.Controls.Add(this.botaoF1);
            this.PanelBotoes.Controls.Add(this.botaoF6);
            this.PanelBotoes.Controls.Add(this.botaoF8);
            this.PanelBotoes.Controls.Add(this.botaoF10);
            this.PanelBotoes.Controls.Add(this.botaoF12);
            this.PanelBotoes.Controls.Add(this.botaoESC);
            this.PanelBotoes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelBotoes.Location = new System.Drawing.Point(59, 447);
            this.PanelBotoes.Name = "PanelBotoes";
            this.PanelBotoes.Size = new System.Drawing.Size(724, 28);
            this.PanelBotoes.TabIndex = 49;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox3.BackColor = System.Drawing.Color.White;
            this.GroupBox3.Controls.Add(this.labelDescricaoProduto);
            this.GroupBox3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.GroupBox3.ForeColor = System.Drawing.Color.Black;
            this.GroupBox3.Location = new System.Drawing.Point(59, 136);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(551, 57);
            this.GroupBox3.TabIndex = 4;
            this.GroupBox3.TabStop = false;
            // 
            // labelDescricaoProduto
            // 
            this.labelDescricaoProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescricaoProduto.BackColor = System.Drawing.Color.Teal;
            this.labelDescricaoProduto.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.labelDescricaoProduto.ForeColor = System.Drawing.Color.Black;
            this.labelDescricaoProduto.Location = new System.Drawing.Point(4, 5);
            this.labelDescricaoProduto.Name = "labelDescricaoProduto";
            this.labelDescricaoProduto.Size = new System.Drawing.Size(543, 47);
            this.labelDescricaoProduto.TabIndex = 0;
            this.labelDescricaoProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FNotaFiscal
            // 
            this.ClientSize = new System.Drawing.Size(791, 484);
            this.Controls.Add(this.PanelBotoes);
            this.Controls.Add(this.Image1);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(140, 471);
            this.Name = "FNotaFiscal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digitação de Notas Fiscais";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridItens)).EndInit();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.PanelBotoes.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.Button botaoESC;
        private System.Windows.Forms.Button botaoF12;
        private System.Windows.Forms.Button botaoF10;
        private System.Windows.Forms.Button botaoF8;
        private System.Windows.Forms.Button botaoF6;
        private System.Windows.Forms.Button botaoF1;
        private System.Windows.Forms.FlowLayoutPanel PanelBotoes;
        private System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label labelDescricaoProduto;
        private System.Windows.Forms.DataGridView GridItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_UNIDADE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrincipal_VALOR_VENDA;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox editQuantidade;
        internal System.Windows.Forms.TextBox editUnitario;
        internal System.Windows.Forms.TextBox editTotalItem;
        internal System.Windows.Forms.TextBox editCodigoVendedor;
        internal System.Windows.Forms.TextBox EditNumeroNF;
        private System.Windows.Forms.MaskedTextBox EditHoraEmissao;
        private System.Windows.Forms.DateTimePicker EditDataEmissao;
        internal System.Windows.Forms.TextBox editCodigoCliente;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox EditNome;
        private System.Windows.Forms.MaskedTextBox editCpfCnpj;
        internal System.Windows.Forms.Label label17;


    }
}
