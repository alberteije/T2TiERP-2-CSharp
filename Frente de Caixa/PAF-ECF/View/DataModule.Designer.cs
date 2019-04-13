namespace PafEcf.View
{
    partial class DataModule
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
            this.aCBrECF = new ACBrFramework.ECF.ACBrECF();
            this.aCBrPAF = new ACBrFramework.PAF.ACBrPAF();
            this.aCBrEAD = new ACBrFramework.EAD.ACBrEAD();
            this.aCBrSpedFiscal = new ACBrFramework.Sped.ACBrSpedFiscal();
            this.aCBrBAL = new ACBrFramework.BAL.ACBrBAL();
            this.aCBrSintegra = new ACBrFramework.Sintegra.ACBrSintegra();
            this.aCBrAAC = new ACBrFramework.AAC.ACBrAAC();
            this.SuspendLayout();
            // 
            // aCBrECF
            // 
            this.aCBrECF.AAC = null;
            this.aCBrECF.AguardaImpressao = false;
            this.aCBrECF.ArqLOG = "";
            this.aCBrECF.ArredondaItemMFD = false;
            this.aCBrECF.ArredondaPorQtd = false;
            this.aCBrECF.ComandoLog = "";
            this.aCBrECF.DecimaisPreco = 3;
            this.aCBrECF.DecimaisQtd = 3;
            this.aCBrECF.DescricaoGrande = false;
            this.aCBrECF.EAD = null;
            this.aCBrECF.GavetaSinalInvertido = false;
            this.aCBrECF.IgnorarTagsFormatacao = false;
            this.aCBrECF.IntervaloAposComando = 100;
            this.aCBrECF.LinhasEntreCupons = 7;
            this.aCBrECF.MaxLinhasBuffer = 0;
            this.aCBrECF.MemoParams = new string[] {
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
            this.aCBrECF.Modelo = ACBrFramework.ECF.ModeloECF.Nenhum;
            this.aCBrECF.Operador = "";
            this.aCBrECF.PaginaDeCodigo = 0;
            this.aCBrECF.PausaRelatorio = 5;
            this.aCBrECF.RFD = null;
            // 
            // aCBrPAF
            // 
            this.aCBrPAF.AAC = null;
            this.aCBrPAF.AssinarArquivo = true;
            this.aCBrPAF.CurMascara = "";
            this.aCBrPAF.Delimitador = "";
            this.aCBrPAF.EAD = this.aCBrEAD;
            this.aCBrPAF.Path = "C:\\Arquivos de programas\\Microsoft Visual Studio 10.0\\Common7\\IDE\\";
            this.aCBrPAF.TrimString = true;
            // 
            // aCBrSpedFiscal
            // 
            this.aCBrSpedFiscal.Arquivo = "";
            this.aCBrSpedFiscal.CurMascara = "#0.00";
            this.aCBrSpedFiscal.Delimitador = "|";
            this.aCBrSpedFiscal.DT_FIN = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
            this.aCBrSpedFiscal.DT_INI = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
            this.aCBrSpedFiscal.LinhasBuffer = 1000;
            this.aCBrSpedFiscal.Path = "C:\\Arquivos de programas\\Microsoft Visual Studio 10.0\\Common7\\IDE\\";
            this.aCBrSpedFiscal.TrimString = true;
            // 
            // aCBrBAL
            // 
            this.aCBrBAL.Modelo = ACBrFramework.BAL.ModeloBal.Nenhum;
            this.aCBrBAL.MonitoraBalanca = false;
            this.aCBrBAL.Porta = "COM1";
            // 
            // aCBrSintegra
            // 
            this.aCBrSintegra.Ativo = true;
            this.aCBrSintegra.FileName = "";
            this.aCBrSintegra.Informa88C = false;
            this.aCBrSintegra.Informa88EAN = false;
            this.aCBrSintegra.Informa88SME = false;
            this.aCBrSintegra.Informa88SMS = false;
            this.aCBrSintegra.InformaSapiMG = false;
            this.aCBrSintegra.VersaoValidador = ACBrFramework.Sintegra.VersaoValidador.V524;
            // 
            // aCBrAAC
            // 
            this.aCBrAAC.ArqLOG = "";
            this.aCBrAAC.CriarBAK = true;
            this.aCBrAAC.EfetuarFlush = true;
            this.aCBrAAC.GravarConfigApp = true;
            this.aCBrAAC.GravarDadosPAF = true;
            this.aCBrAAC.GravarDadosSH = true;
            this.aCBrAAC.GravarTodosECFs = true;
            this.aCBrAAC.NomeArquivoAuxiliar = "";
            this.aCBrAAC.Params = new string[0];
            // 
            // DataModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DataModule";
            this.ResumeLayout(false);

        }

        #endregion

        public ACBrFramework.ECF.ACBrECF aCBrECF;
        public ACBrFramework.PAF.ACBrPAF aCBrPAF;
        public ACBrFramework.Sped.ACBrSpedFiscal aCBrSpedFiscal;
        public ACBrFramework.BAL.ACBrBAL aCBrBAL;
        public ACBrFramework.Sintegra.ACBrSintegra aCBrSintegra;
        public ACBrFramework.AAC.ACBrAAC aCBrAAC;
        public ACBrFramework.EAD.ACBrEAD aCBrEAD;




    }
}
