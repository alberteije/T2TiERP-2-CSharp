
using System.IO;
using System.Text;
namespace ProjetoSpedContabil
{

    public class TACBrSPEDContabil
    {

        public TBloco_0 Bloco_0;

        private string Arquivo;

        private System.DateTime FDT_INI;           // / Data inicial das informa??es contidas no arquivo
        private System.DateTime FDT_FIN;           // / Data final das informa??es contidas no arquivo

        private string FPath;            // / Path do arquivo a ser gerado
        private string FDelimitador;     // / Caracter delimitador de campos
        private bool FTrimString;         // / Retorna a string sem espa?os em branco iniciais e finais
        private string FCurMascara;      // / Mascara para valores tipo currency


        public TACBrSPEDContabil()
        {
            Bloco_0 = new TBloco_0();

            /*
		  FBloco_I = new TBloco_I();
		  FBloco_J = new TBloco_J();
		  FBloco_9 = new TBloco_9();
		
		  FBloco_I.Bloco_0 = FBloco_0;
		  FBloco_J.Bloco_0 = FBloco_0;
		  FBloco_9.Bloco_0 = FBloco_0;
		
		
		  FPath = Path.GetDirectoryName( ParamStr(0) );
		  FDelimitador = "|";
		  FCurMascara  = """.00";
		  FTrimString  = true;
             * */
        }

        private void LimpaRegistros()
        {
            Bloco_0.LimpaRegistros();
            /*
		  FBloco_I.LimpaRegistros();
		  FBloco_J.LimpaRegistros();
		  FBloco_9.LimpaRegistros();
             */
        }

        public void SaveFileTXT()
        {
            StringBuilder sb = new StringBuilder("");

            sb.AppendLine(Bloco_0.WriteRegistro0000());
            sb.AppendLine(Bloco_0.WriteRegistro0001());
            sb.AppendLine(Bloco_0.WriteRegistro0990());

            TextWriter tw = new StreamWriter("C:\\T2Ti\\Arquivos\\SpedContabil.txt");
            tw.Write(sb.ToString());
            tw.Close();

            /*
              try {
                IniciaGeracao();
		
                WriteBloco_I();
                WriteBloco_J();
                WriteBloco_9();
		
                TotalizarTermos();
		
                } finally {
                  LimpaRegistros();
                  FACBrTXT.Conteudo.Clear();
                  FInicializado = false ;
              }*/
        }

        public void WriteBloco_0()
        {
            WriteRegistro0000();
            WriteRegistro0001();
            /*
            WriteRegistro0007();
            WriteRegistro0035();
            WriteRegistro0020();
            WriteRegistro0150();
            // WriteRegistro0180;
            */ 
            WriteRegistro0990();
        }


        protected void WriteRegistro0000()
        {
            /*
               using(Bloco_9.Registro9900.New){
                  REG_BLC = "0000";
                  QTD_REG_BLC = 1;
               }
             */
            Bloco_0.WriteRegistro0000();
        }



        protected void WriteRegistro0001()
        {
            /*
               using(Bloco_9.Registro9900.New){
                  REG_BLC = "0001";
                  QTD_REG_BLC = 1;
               }
             */
            Bloco_0.WriteRegistro0001();
        }

        protected void WriteRegistro0990()
        {
            /*
               using(Bloco_9.Registro9900.New){
                  REG_BLC = "0990";
                  QTD_REG_BLC = 1;
               }
             */
            Bloco_0.WriteRegistro0990();
        }

        /*
		
        protected void WriteRegistroI001()
        {
		
           using(Bloco_9.Registro9900.New){
              REG_BLC = "I001";
              QTD_REG_BLC = 1;
           }
           Bloco_I.WriteRegistroI001();
        }
		
		
		
        protected void WriteRegistroI010()
        {
		
           using(Bloco_9.Registro9900.New){
              REG_BLC = "I010";
              QTD_REG_BLC = 1;
           }
           Bloco_I.WriteRegistroI010();
        }
		
		
		
        protected void WriteRegistroI012()
        {
		
          Bloco_I.WriteRegistroI012();
		  
          if( Bloco_I.RegistroI012.Count > 0 )
          {
            using(Bloco_9.Registro9900.New){
               REG_BLC = "I012";
               QTD_REG_BLC = Bloco_I.RegistroI012.Count;
            }
          }
          if( Bloco_I.RegistroI015Count > 0 )
          {
            using(Bloco_9.Registro9900.New){
               REG_BLC = "I015";
               QTD_REG_BLC = Bloco_I.RegistroI015Count;
            }
          }
        }
		
		
		
        protected void WriteRegistroI020()
        {
		
           if( Bloco_I.RegistroI020.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I020";
                 QTD_REG_BLC = Bloco_I.RegistroI020.Count;
              }
           }
           Bloco_I.WriteRegistroI020();
        }
		
		
		
        protected void WriteRegistroI030()
        {
		
           //  Total de linhas do arquivo
           Bloco_I.RegistroI030.QTD_LIN = Bloco_0.Registro0990.QTD_LIN_0 +
                                           Bloco_I.RegistroI990.QTD_LIN_I +
                                           Bloco_J.RegistroJ990.QTD_LIN_J +
                                           Bloco_9.Registro9990.QTD_LIN_9;
           using(Bloco_9.Registro9900.New){
              REG_BLC = "I030";
              QTD_REG_BLC = 1;
           }
           Bloco_I.WriteRegistroI030();
        }
		
		
		
        protected void WriteRegistroI050()
        {
		
           Bloco_I.WriteRegistroI050();
           if( Bloco_I.RegistroI050.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I050";
                 QTD_REG_BLC = Bloco_I.RegistroI050.Count;
              }
           }
           if( Bloco_I.RegistroI051Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I051";
                 QTD_REG_BLC = Bloco_I.RegistroI051Count;
              }
           }
           if( Bloco_I.RegistroI052Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I052";
                 QTD_REG_BLC = Bloco_I.RegistroI052Count;
              }
           }
        }
		
		
		
        protected void WriteRegistroI075()
        {
		
           if( Bloco_I.RegistroI075.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I075";
                 QTD_REG_BLC = Bloco_I.RegistroI075.Count;
              }
           }
           Bloco_I.WriteRegistroI075();
        }
		
		
		
        protected void WriteRegistroI100()
        {
		
           if( Bloco_I.RegistroI100.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I100";
                 QTD_REG_BLC = Bloco_I.RegistroI100.Count;
              }
           }
           Bloco_I.WriteRegistroI100();
        }
		
		
		
        protected void WriteRegistroI150()
        {
		
           Bloco_I.WriteRegistroI150();
           if( Bloco_I.RegistroI150.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I150";
                 QTD_REG_BLC = Bloco_I.RegistroI150.Count;
              }
           }
           if( Bloco_I.RegistroI151Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I151";
                 QTD_REG_BLC = Bloco_I.RegistroI151Count;
              }
           }
           if( Bloco_I.RegistroI155Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I155";
                 QTD_REG_BLC = Bloco_I.RegistroI155Count;
              }
           }
        }
		
		
		
        protected void WriteRegistroI200()
        {
		
           Bloco_I.WriteRegistroI200();
           if( Bloco_I.RegistroI200.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I200";
                 QTD_REG_BLC = Bloco_I.RegistroI200.Count;
              }
           }
           if( Bloco_I.RegistroI250Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I250";
                 QTD_REG_BLC = Bloco_I.RegistroI250Count;
              }
           }
        }
		
		
		
        protected void WriteRegistroI300()
        {
		
           Bloco_I.WriteRegistroI300();
           if( Bloco_I.RegistroI300.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I300";
                 QTD_REG_BLC = Bloco_I.RegistroI300.Count;
              }
           }
           if( Bloco_I.RegistroI310Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I310";
                 QTD_REG_BLC = Bloco_I.RegistroI310Count;
              }
           }
        }
		
		
		
        protected void WriteRegistroI350()
        {
		
           Bloco_I.WriteRegistroI350();
           if( Bloco_I.RegistroI350.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I350";
                 QTD_REG_BLC = Bloco_I.RegistroI350.Count;
              }
           }
           if( Bloco_I.RegistroI355Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I355";
                 QTD_REG_BLC = Bloco_I.RegistroI355Count;
              }
           }
        }
		
		
		
        protected void WriteRegistroI500()
        {
		
           if( Bloco_I.RegistroI500.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I500";
                 QTD_REG_BLC = Bloco_I.RegistroI500.Count;
              }
           }
           Bloco_I.WriteRegistroI500();
        }
		
		
		
		
        protected void WriteRegistroI510()
        {
		
           if( Bloco_I.RegistroI510.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I510";
                 QTD_REG_BLC = Bloco_I.RegistroI510.Count;
              }
           }
           Bloco_I.WriteRegistroI510();
        }
		
		
		
        protected void WriteRegistroI550()
        {
		
           if( Bloco_I.RegistroI550.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I550";
                 QTD_REG_BLC = Bloco_I.RegistroI550.Count;
              }
           }
		
           if( Bloco_I.RegistroI555Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "I555";
                 QTD_REG_BLC = Bloco_I.RegistroI555Count;
              }
           }
		
           Bloco_I.WriteRegistroI550();
        }
		
		
		
        protected void WriteRegistroI990()
        {
		
           using(Bloco_9.Registro9900.New){
              REG_BLC = "I990";
              QTD_REG_BLC = 1;
           }
           Bloco_I.WriteRegistroI990();
        }
		
		
		
        protected void WriteRegistroJ001()
        {
		
           using(Bloco_9.Registro9900.New){
              REG_BLC = "J001";
              QTD_REG_BLC = 1;
           }
           Bloco_J.WriteRegistroJ001();
        }
		
		
		
        protected void WriteRegistroJ005()
        {
		
           Bloco_J.WriteRegistroJ005();
           if( Bloco_J.RegistroJ005.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "J005";
                 QTD_REG_BLC = Bloco_J.RegistroJ005.Count;
              }
           }
           if( Bloco_J.RegistroJ100Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "J100";
                 QTD_REG_BLC = Bloco_J.RegistroJ100Count;
              }
           }
           if( Bloco_J.RegistroJ150Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "J150";
                 QTD_REG_BLC = Bloco_J.RegistroJ150Count;
              }
           }
           if( Bloco_J.RegistroJ200Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "J200";
                 QTD_REG_BLC = Bloco_J.RegistroJ200Count;
              }
           }
           if( Bloco_J.RegistroJ210Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "J210";
                 QTD_REG_BLC = Bloco_J.RegistroJ210Count;
              }
           }
           if( Bloco_J.RegistroJ215Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "J215";
                 QTD_REG_BLC = Bloco_J.RegistroJ215Count;
              }
           }
        }
		
		
		
        protected void WriteRegistroJ800()
        {
		
           if( Bloco_J.RegistroJ800.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "J800";
                 QTD_REG_BLC = Bloco_J.RegistroJ800.Count;
              }
           }
           Bloco_J.WriteRegistroJ800();
        }
		
		
		
        protected void WriteRegistroJ900()
        {
		
           using(Bloco_9.Registro9900.New){
              REG_BLC = "J900";
              QTD_REG_BLC = 1;
           }
           Bloco_J.WriteRegistroJ900();
        }
		
		
		
        protected void WriteRegistroJ930()
        {
		
           if( Bloco_J.RegistroJ930.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "J930";
                 QTD_REG_BLC = Bloco_J.RegistroJ930.Count;
              }
           }
           Bloco_J.WriteRegistroJ930();
        }
		
		
		
        protected void WriteRegistroJ935()
        {
		
           if( Bloco_J.RegistroJ935.Count > 0 )
           {
              using(Bloco_9.Registro9900.New){
                 REG_BLC = "J935";
                 QTD_REG_BLC = Bloco_J.RegistroJ935.Count;
              }
           }
           Bloco_J.WriteRegistroJ935();
        }
		
		
		
        protected void WriteRegistroJ990()
        {
		
           using(Bloco_9.Registro9900.New){
              REG_BLC = "J990";
              QTD_REG_BLC = 1;
           }
           Bloco_J.WriteRegistroJ990();
        }
		
		
		
        protected void WriteRegistro9001()
        {
		
           using(Bloco_9.Registro9900.New){
              REG_BLC = "9001";
              QTD_REG_BLC = 1;
           }
           Bloco_9.WriteRegistro9001();
        }
		
		
		
        protected void WriteRegistro9900()
        {
		
           using(Bloco_9.Registro9900){
              using(New){
                 REG_BLC = "9900";
                 QTD_REG_BLC = Bloco_9.Registro9900.Count + 2;
              }
              using(New){
                 REG_BLC = "9990";
                 QTD_REG_BLC = 1;
              }
              using(New){
                 REG_BLC = "9999";
                 QTD_REG_BLC = 1;
              }
           }
           Bloco_9.WriteRegistro9900();
        }
		
		
		
        protected void WriteRegistro9990()
        {
		
           Bloco_9.WriteRegistro9990();
        }
		
		
		
        protected void WriteRegistro9999()
        {
		
           Bloco_9.Registro9999.QTD_LIN = Bloco_9.Registro9999.QTD_LIN + Bloco_0.Registro0990.QTD_LIN_0 +
                                                                          Bloco_I.RegistroI990.QTD_LIN_I +
                                                                          Bloco_J.RegistroJ990.QTD_LIN_J +
                                                                          Bloco_9.Registro9990.QTD_LIN_9;
           Bloco_9.WriteRegistro9999();
        }
		
		
		
        private string GetAbout()
        {
		
        string Result;
		
           Result = "ACBrSpedContabil Ver: " + CACBrSpedContabil_Versao;
        return Result;
        }
		
		
		
        private void SetAbout( constString Value)
        {
		
         // 
        }
		
		
		
        private int GetLinhasBuffer()
        {
		
        int Result;
		
           Result = FACBrTXT.LinhasBuffer ;
        return Result;
        }
		
		
		
        private void SetLinhasBuffer( constInteger Value)
        {
		
           FACBrTXT.LinhasBuffer = Value ;
        }
		
		
		
        private void InicializaBloco( TACBrSPED Bloco)
        {
		
           Bloco.NomeArquivo  = FACBrTXT.NomeArquivo;
           Bloco.LinhasBuffer = FACBrTXT.LinhasBuffer;
           Bloco.Gravado      = false ;
           if( ! Assigned(Bloco.Conteudo) )
             Bloco.Conteudo = new RichTextBox();
           Bloco.Conteudo.Clear();
        }
		
		
		
        public void IniciaGeracao()
        {
         int intFor;
          if( FInicializado ) return;
		  
          if( (Arquivo.Trim() == "") || (FPath.Trim() == "") )
              throw new Exception( ACBrStr("Caminho ou nome do arquivo n?o informado!"));
		
          FACBrTXT.NomeArquivo = FPath + Arquivo ;
          FACBrTXT.;    //  Apaga o Arquivo e limpa mem?ria
		
          InicializaBloco( Bloco_0 ) ;
          InicializaBloco( Bloco_I ) ;
          InicializaBloco( Bloco_J ) ;
          InicializaBloco( Bloco_9 ) ;
		
          // / Prepara??o para totaliza??es de registros.
          Bloco_0.Registro0990.QTD_LIN_0 = 0;
          Bloco_I.RegistroI990.QTD_LIN_I = 0;
          Bloco_J.RegistroJ990.QTD_LIN_J = 0;
          Bloco_9.Registro9990.QTD_LIN_9 = 0;
          Bloco_9.Registro9999.QTD_LIN   = 0;
		
          for( intFor = 0;intFor <= Bloco_9.Registro9900.Count - 1;intFor++)
          {
             Bloco_9.Registro9900.Items[intFor] = null;
             Bloco_9.Registro9900.Items[intFor].Dispose();
          }
		  
          Bloco_9.Registro9900.Clear();
		
          FInicializado = true;
        }
		
		
		
		
		
		
        private void SetArquivo( constansistring Value)
        {
		
          FArquivo = Value;
        }
		
		
		
        public void WriteBloco_I()
        {
		
          if( Bloco_I.Gravado ) return;
		
          if( ! Bloco_I.Gravado )
            WriteBloco_0();
		
          WriteRegistroI001();
          WriteRegistroI010();
          WriteRegistroI012();
          WriteRegistroI020();
          WriteRegistroI030();
          WriteRegistroI050();
          WriteRegistroI075();
          WriteRegistroI100();
          WriteRegistroI150();
          WriteRegistroI200();
          WriteRegistroI300();
          WriteRegistroI350();
          WriteRegistroI500();
          WriteRegistroI510();
          WriteRegistroI550();
          WriteRegistroI990();
		
          Bloco_I.WriteBuffer;
          Bloco_I.Conteudo.Clear();
          Bloco_I.Gravado = true;
        }
		
		
		
        public void WriteBloco_J()
        {
		
          if( Bloco_J.Gravado ) return;
		
          if( ! Bloco_J.Gravado )
            WriteBloco_I();
		
          WriteRegistroJ001();
          WriteRegistroJ005();
          WriteRegistroJ800();
          WriteRegistroJ900();
          WriteRegistroJ930();
          WriteRegistroJ935();
          WriteRegistroJ990();
		
          Bloco_J.WriteBuffer;
          Bloco_J.Conteudo.Clear();
          Bloco_J.Gravado = true;
        }
		
		
		
        public void WriteBloco_9()
        {
		
          if( Bloco_9.Gravado ) return;
		
          if( ! Bloco_9.Gravado )
            WriteBloco_J();
		
          WriteRegistro9001();
          WriteRegistro9900();
          WriteRegistro9990();
          WriteRegistro9999();
		
          Bloco_9.WriteBuffer;
          Bloco_9.Conteudo.Clear();
          Bloco_9.Gravado = true;
        }
		
		
		
        private TStringList GetConteudo()
        {
		
        TStringList Result;
		
          Result = FACBrTXT.Conteudo;
        return Result;
        }
		
		
		
        private void TotalizarTermos()
        {
         TFileStream fs;
           byte sByte, sByteNew;
           int iInc, iEnd, iCont, iIni ;
           string sTotal, sChar ;
          sTotal = FACBrTXT.LFill(Bloco_9.Registro9999.QTD_LIN, 9, false);
          sChar = "";
          iCont=0;
          fs = new TFileStream(FACBrTXT.NomeArquivo, fmOpenReadWrite || fmShareExclusive );
		
        // ******************************************************************************
        //  iEnd : soma a quantidade de vezes que encontra o caracter '[' dentro do
        //  arquivo, no momento que enontra 2 vezes encerra a altera??o dos totalizadores
        //  do arquivo e encerra o la?o de repeti??o.
        // ******************************************************************************
          try {
            iEnd = 0;
            while( iEnd != 2 )
            {
              fs.Position = iCont;
              fs.sByte.Read( 1, 0, 1);
              if( (Chr(sByte) == "[") )
              {
                fs.Position = iCont;
                iIni = iCont;
                sChar = "";
		
                for( iInc = 1;iInc <= 9;iInc++)
                {
                  fs.Position = iCont;
                  fs.sByte.Read( 1, 0, 1);
                  sChar = sChar + Chr(sByte);
                  iCont++;
                }
		
                if( (sChar == "[*******]") )
                {
                  for( iInc = 1;iInc <= 9;iInc++)
                  {
                    fs.Position = iIni;
                    sByteNew = Ord(sTotal[iInc]);
                    fs.(sByteNew,1);
                    iIni++;
                  }
                  iEnd++;
                }
              }
              iCont++;
            }
            } finally {
            {
              FreeAndNil(fs);
            }
          }
        }
		
		
    }
	
    public static class ACBrSpedContabil 
    {
		
		
        private const string CACBrSpedContabil_Versao =  "0.04a" ;  public TACBrSPED TACBrSPEDPrected;  //ACBrSpedContabil - Sitema Publico de Escritura??o Digital Contabil ///  TACBrSPEDContabil 
		
		
		
		
		
        // $IFNDEF FPC
         // $R ACBr_SPEDContabil.dcr
        // $ENDIF
		
        public void Register()
        {
		
          RegisterComponents("ACBrTXT", [TACBrSPEDContabil]);
        }
		
		
		
        public  ()
        {
		
          FACBrTXT.Dispose();
		
          FBloco_0.Dispose();
          FBloco_I.Dispose();
          FBloco_J.Dispose();
          FBloco_9.Dispose();
          base.Destroy;
        }
		
		
    */
    }

}
//initialization
//   // {$I ACBrSpedContabil.lrs}
//// $endif
//
//
