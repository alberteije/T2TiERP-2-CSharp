namespace ConfiguraPAFECF.View
{
    partial class FDataModule
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.acBrECF = new ACBrFramework.ECF.ACBrECF();
            this.SuspendLayout();
            // 
            // acBrECF
            // 
            this.acBrECF.AAC = null;
            this.acBrECF.AguardaImpressao = false;
            this.acBrECF.ArqLOG = "";
            this.acBrECF.ArredondaItemMFD = false;
            this.acBrECF.ArredondaPorQtd = false;
            this.acBrECF.ComandoLog = "";
            this.acBrECF.DecimaisPreco = 3;
            this.acBrECF.DecimaisQtd = 3;
            this.acBrECF.DescricaoGrande = false;
            this.acBrECF.EAD = null;
            this.acBrECF.GavetaSinalInvertido = false;
            this.acBrECF.IgnorarTagsFormatacao = false;
            this.acBrECF.IntervaloAposComando = 100;
            this.acBrECF.LinhasEntreCupons = 7;
            this.acBrECF.MaxLinhasBuffer = 0;
            this.acBrECF.MemoParams = new string[] {
        "[Cabecalho]",
        "LIN000=<center><b>Nome da Empresa</b></center>",
        "LIN001=<center>Nome da Rua , 1234  -  Bairro</center>",
        "LIN002=<center>Cidade  -  UF  -  99999-999</center>",
        "LIN003=<center>CNPJ: 01.234.567/0001-22    IE: 012.345.678.90</center>",
        "LIN004=<table width=100%><tr><td align=left><code>Data</code> <code>Hora</code></" +
            "td><td align=right>COO: <b><code>NumCupom</code></b></td></tr></table>",
        "LIN005=<hr>",
        " ",
        "[Cabecalho_Item]",
        "LIN000=ITEM   CODIGO      DESCRICAO",
        "LIN001=QTD         x UNITARIO       Aliq     VALOR (R$)",
        "LIN002=<hr>",
        "MascaraItem=III CCCCCCCCCCCCCC DDDDDDDDDDDDDDDDDDDDDDDDDDDDDQQQQQQQQ UU x VVVVVVV" +
            "VVVVVV AAAAAA TTTTTTTTTTTTT",
        " ",
        "[Rodape]",
        "LIN000=<hr>",
        "LIN001=<table width=100%><tr><td align=left><code>Data</code> <code>Hora</code></" +
            "td><td align=right>Projeto ACBr: <b><code>ACBR</code></b></td></tr></table>",
        "LIN002=<center>Obrigado Volte Sempre</center>",
        "LIN003=<hr>",
        " ",
        "[Formato]",
        "Colunas=48",
        "HTML=1",
        "HTML_Title_Size=2",
        "HTML_Font=<font size=\"2\" face=\"Lucida Console\">"};
            this.acBrECF.Modelo = ACBrFramework.ECF.ModeloECF.Nenhum;
            this.acBrECF.Operador = "";
            this.acBrECF.PaginaDeCodigo = 0;
            this.acBrECF.PausaRelatorio = 5;
            this.acBrECF.RFD = null;
            // 
            // FDataModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FDataModule";
            this.ResumeLayout(false);

        }

        #endregion

        private ACBrFramework.ECF.ACBrECF acBrECF;

    }
}
