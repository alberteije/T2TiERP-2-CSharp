using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using ProjetoSpedContabil.ACBrECDBloco_I_NS;
using ProjetoSpedContabil.ACBrECDBloco_0_Class_NS;

namespace ProjetoSpedContabil
{
	
	  // / TBLOCO_I -
	  
	public class TBLOCO_I : TACBrSPED
	{
		
		
		  
		           // / BLOCO I - RegistroI001
		           // / BLOCO I - RegistroI010
		       // / BLOCO I - Lista de RegistroI012
		    
		       /*FRegistroI015: TRegistroI015List;  /// BLOCO I - Lista de RegistroI015*/// / BLOCO I - Lista de RegistroI020
		           // / BLOCO I - RegistroI030
		       // / BLOCO I - Lista de RegistroI050
		       // / BLOCO I - Lista de RegistroI075
		       // / BLOCO I - Lista de RegistroI100
		       // / BLOCO I - Lista de RegistroI150
		      
		      
		       // / BLOCO I - Lista de RegistroI350
		       // / BLOCO I - Lista de RegistroI500
		       // / BLOCO I - Lista de RegistroI510
		      
		           // / BLOCO I - FRegistroI990
		
		    private int FRegistroI015Count; 
		    private int FRegistroI051Count; 
		    private int FRegistroI052Count; 
		    private int FRegistroI053Count; 
		    private int FRegistroI151Count; 
		    private int FRegistroI155Count; 
		    private int FRegistroI250Count; 
		    private int FRegistroI310Count; 
		    private int FRegistroI355Count; 
		    private int FRegistroI555Count; 
		      // / Create
		// / Destroy
		
		
		    public TBloco_0 Bloco_0
		    {
		    	get
		    	{
		    		return FBloco_0;
		    	}
		    	set
		    	{
		    		FBloco_0 = value;
		    	}
		    }
		    
		
		
		    public TRegistroI001     RegistroI001
		    {
		    	get
		    	{
		    		return FRegistroI001;
		    	}
		    	set
		    	{
		    		FRegistroI001 = value;
		    	}
		    }
		    
		
		    public TRegistroI010     RegistroI010
		    {
		    	get
		    	{
		    		return FRegistroI010;
		    	}
		    	set
		    	{
		    		FRegistroI010 = value;
		    	}
		    }
		    
		
		    public TRegistroI012List RegistroI012
		    {
		    	get
		    	{
		    		return fRegistroI012;
		    	}
		    	set
		    	{
		    		fRegistroI012 = value;
		    	}
		    }
		    
		
		    // property RegistroI015: TRegistroI015List read fRegistroI015 write fRegistroI015;
		    public TRegistroI020List RegistroI020
		    {
		    	get
		    	{
		    		return fRegistroI020;
		    	}
		    	set
		    	{
		    		fRegistroI020 = value;
		    	}
		    }
		    
		
		    public TRegistroI030     RegistroI030
		    {
		    	get
		    	{
		    		return fRegistroI030;
		    	}
		    	set
		    	{
		    		fRegistroI030 = value;
		    	}
		    }
		    
		
		    public TRegistroI050List RegistroI050
		    {
		    	get
		    	{
		    		return fRegistroI050;
		    	}
		    	set
		    	{
		    		fRegistroI050 = value;
		    	}
		    }
		    
		
		    public TRegistroI075List RegistroI075
		    {
		    	get
		    	{
		    		return fRegistroI075;
		    	}
		    	set
		    	{
		    		fRegistroI075 = value;
		    	}
		    }
		    
		
		    public TRegistroI100List RegistroI100
		    {
		    	get
		    	{
		    		return fRegistroI100;
		    	}
		    	set
		    	{
		    		fRegistroI100 = value;
		    	}
		    }
		    
		
		    public TRegistroI150List RegistroI150
		    {
		    	get
		    	{
		    		return fRegistroI150;
		    	}
		    	set
		    	{
		    		fRegistroI150 = value;
		    	}
		    }
		    
		
		    public TRegistroI200List RegistroI200
		    {
		    	get
		    	{
		    		return fRegistroI200;
		    	}
		    	set
		    	{
		    		fRegistroI200 = value;
		    	}
		    }
		    
		
		    public TRegistroI300List RegistroI300
		    {
		    	get
		    	{
		    		return fRegistroI300;
		    	}
		    	set
		    	{
		    		fRegistroI300 = value;
		    	}
		    }
		    
		
		    public TRegistroI350List RegistroI350
		    {
		    	get
		    	{
		    		return fRegistroI350;
		    	}
		    	set
		    	{
		    		fRegistroI350 = value;
		    	}
		    }
		    
		
		    public TRegistroI500List RegistroI500
		    {
		    	get
		    	{
		    		return fRegistroI500;
		    	}
		    	set
		    	{
		    		fRegistroI500 = value;
		    	}
		    }
		    
		
		    public TRegistroI510List RegistroI510
		    {
		    	get
		    	{
		    		return fRegistroI510;
		    	}
		    	set
		    	{
		    		fRegistroI510 = value;
		    	}
		    }
		    
		
		    public TRegistroI550List RegistroI550
		    {
		    	get
		    	{
		    		return fRegistroI550;
		    	}
		    	set
		    	{
		    		fRegistroI550 = value;
		    	}
		    }
		    
		
		    public TRegistroI990     RegistroI990
		    {
		    	get
		    	{
		    		return FRegistroI990;
		    	}
		    	set
		    	{
		    		FRegistroI990 = value;
		    	}
		    }
		    
		
		
		    public Integer RegistroI015Count
		    {
		    	get
		    	{
		    		return FRegistroI015Count;
		    	}
		    	set
		    	{
		    		FRegistroI015Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroI051Count
		    {
		    	get
		    	{
		    		return FRegistroI051Count;
		    	}
		    	set
		    	{
		    		FRegistroI051Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroI052Count
		    {
		    	get
		    	{
		    		return FRegistroI052Count;
		    	}
		    	set
		    	{
		    		FRegistroI052Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroI053Count
		    {
		    	get
		    	{
		    		return FRegistroI053Count;
		    	}
		    	set
		    	{
		    		FRegistroI053Count = value;
		    	}
		    }
		        
		
		    public Integer RegistroI151Count
		    {
		    	get
		    	{
		    		return FRegistroI151Count;
		    	}
		    	set
		    	{
		    		FRegistroI151Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroI155Count
		    {
		    	get
		    	{
		    		return FRegistroI155Count;
		    	}
		    	set
		    	{
		    		FRegistroI155Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroI250Count
		    {
		    	get
		    	{
		    		return FRegistroI250Count;
		    	}
		    	set
		    	{
		    		FRegistroI250Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroI310Count
		    {
		    	get
		    	{
		    		return FRegistroI310Count;
		    	}
		    	set
		    	{
		    		FRegistroI310Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroI355Count
		    {
		    	get
		    	{
		    		return FRegistroI355Count;
		    	}
		    	set
		    	{
		    		FRegistroI355Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroI555Count
		    {
		    	get
		    	{
		    		return FRegistroI555Count;
		    	}
		    	set
		    	{
		    		FRegistroI555Count = value;
		    	}
		    }
		    
		
		
		//  TBLOCO_I 
		
		public  TBLOCO_I()
		{
		
		  FRegistroI001 = new TRegistroI001();
		  FRegistroI010 = new TRegistroI010();
		  FRegistroI012 = new TRegistroI012List();
		  FRegistroI020 = new TRegistroI020List();
		  FRegistroI030 = new TRegistroI030();
		  FRegistroI050 = new TRegistroI050List();
		  FRegistroI075 = new TRegistroI075List();
		  FRegistroI100 = new TRegistroI100List();
		  FRegistroI150 = new TRegistroI150List();
		  FRegistroI200 = new TRegistroI200List();
		  FRegistroI300 = new TRegistroI300List();
		  FRegistroI350 = new TRegistroI350List();
		  FRegistroI500 = new TRegistroI500List();
		  FRegistroI510 = new TRegistroI510List();
		  FRegistroI550 = new TRegistroI550List();
		  FRegistroI990 = new TRegistroI990();
		
		  FRegistroI015Count = 0;
		  FRegistroI051Count = 0;
		  FRegistroI052Count = 0;
		  FRegistroI053Count = 0;
		  FRegistroI151Count = 0;
		  FRegistroI155Count = 0;
		  FRegistroI250Count = 0;
		  FRegistroI310Count = 0;
		  FRegistroI355Count = 0;
		  FRegistroI555Count = 0;
		
		  FRegistroI990.QTD_LIN_I = 0;
		}
		
		
		
		private void LimpaRegistros()
		{
		
		  FRegistroI012.Clear();
		  FRegistroI020.Clear();
		  FRegistroI050.Clear();
		  FRegistroI075.Clear();
		  FRegistroI100.Clear();
		  FRegistroI150.Clear();
		  FRegistroI200.Clear();
		  FRegistroI300.Clear();
		  FRegistroI350.Clear();
		  FRegistroI510.Clear();
		  FRegistroI550.Clear();
		
		  FRegistroI015Count = 0;
		  FRegistroI051Count = 0;
		  FRegistroI052Count = 0;
		  FRegistroI053Count = 0;  
		  FRegistroI151Count = 0;
		  FRegistroI155Count = 0;
		  FRegistroI250Count = 0;
		  FRegistroI310Count = 0;
		  FRegistroI355Count = 0;
		  FRegistroI555Count = 0;
		
		  FRegistroI990.QTD_LIN_I = 0;
		}
		
		
		
		protected void WriteRegistroI001()
		{
		
		  if( Assigned(FRegistroI001) )
		  {
		     using(FRegistroI001){
		       Check(((IND_DAD == 0) || (IND_DAD == 1)), "(I-I001) Na abertura do bloco, deve ser informado o n?mero 0 ou 1!");
		       // /
		       
		       AppendText( LFill("I001") +
		            LFill(IND_DAD, 1) 
		            );
		       // /
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		protected void WriteRegistroI010()
		{
		
		  if( Assigned(FRegistroI010) )
		  {
		     using(FRegistroI010){
		       // / Checagem das informa??es que formar?o o registro
		       // /
		       if( DT_INI >= EncodeDate(2014,01,01) )
		         Check(((IND_ESC == "G") || (IND_ESC == "R") || (IND_ESC == "A") || (IND_ESC == "B") || (IND_ESC == "Z") || (IND_ESC == "S")), "(I-I010) No Indicador da forma de escritura??o cont?bil, deve ser informado: G ou R ou A ou B ou Z ou S!");
		       else
		         Check(((IND_ESC == "G") || (IND_ESC == "R") || (IND_ESC == "A") || (IND_ESC == "B") || (IND_ESC == "Z")), "(I-I010) No Indicador da forma de escritura??o cont?bil, deve ser informado: G ou R ou A ou B ou Z!");
		       // /
		       
		       AppendText( LFill("I010") +
		            LFill(IND_ESC, 1) +
		            LFill(COD_VER_LC) 
		            );
		       // /
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		protected void WriteRegistroI012()
		{
		 int intFor;
		  if( Assigned(FRegistroI012) )
		  {
		     for( intFor = 0;intFor <= FRegistroI012.Count - 1;intFor++)
		     {
		       using(FRegistroI012.Items[intFor]){
		          // / Checagem das informa??es que formar?o o registro
		          Check(((TIPO == "0") || (TIPO == "1")), "(I-I012) No Tipo de Escritura??o do livro, deve ser informado: 0 ou 1!");
		          // /
		          
		          AppendText( LFill("I012") +
		               LFill(NUM_ORD) +
		               LFill(NAT_LIVR) +
		               LFill(TIPO, 1) +
		               RFill(COD_HASH_AUX,40) 
		               );
		       }
		       //  Registros Filhos
		       WriteRegistroI015(FRegistroI012.Items[intFor]);
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		private void WriteRegistroI015( TRegistroI012 RegI012)
		{
		 int intFor;
		  if( Assigned(RegI012.RegistroI015) )
		  {
		     for( intFor = 0;intFor <= RegI012.RegistroI015.Count - 1;intFor++)
		     {
		        using(RegI012.RegistroI015.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I015") +
		                LFill(COD_CTA_RES) 
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		     FRegistroI015Count = FRegistroI015Count + RegI012.RegistroI015.Count;
		  }
		}
		
		
		
		protected void WriteRegistroI020()
		{
		 int intFor;
		  if( Assigned(FRegistroI020) )
		  {
		     for( intFor = 0;intFor <= FRegistroI020.Count - 1;intFor++)
		     {
		        using(FRegistroI020.Items[intFor]){
		           // / Checagem das informa??es que formar?o o registro
		           Check(CAMPO != "", "(I-I020) O nome do campo adicional ? obrigat?rio!");
		           Check(((TIPO_DADO == "N") || (TIPO_DADO == "C")), "(I-I020) Na Indica??o do tipo de dado, deve ser informado: N ou C!");
		           // /
		           
		           AppendText( LFill("I020") +
		                LFill(REG_COD, 4) +
		                LFill(NUM_AD) +
		                LFill(CAMPO) +
		                LFill(DESCRICAO) +
		                LFill(TIPO_DADO, 1)
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		protected void WriteRegistroI030()
		{
		 string strLinha;
		  if( Assigned(FRegistroI030) )
		  {
		     using(FRegistroI030){
		       // / Layout 3 a partir da escritura??o ano calend?rio 2014
		       if( DT_INI >= EncodeDate(2014,01,01) )
		         {
		           strLinha = LFill("I030") +
		                       LFill("TERMO DE ABERTURA") +
		                       LFill(NUM_ORD) +
		                       LFill(NAT_LIVR) +
		                       LFill("[*******]") +
		                       LFill(NOME) +
		                       LFill(NIRE) +
		                       LFill(CNPJ) +
		                       LFill(DT_ARQ) +
		                       LFill(DT_ARQ_CONV, "ddmmyyyy" ) +          
		                       LFill(DESC_MUN) +
		                       LFill(DT_EX_SOCIAL, "ddmmyyyy" );         }
		       // / Layout 2 a partir da escritura??o ano calend?rio 2013
		       else if( DT_INI >= EncodeDate(2013,01,01) )
		         {
		           strLinha = LFill("I030") +
		                       LFill("TERMO DE ABERTURA") +
		                       LFill(NUM_ORD) +
		                       LFill(NAT_LIVR) +
		                       LFill("[*******]") +
		                       LFill(NOME) +
		                       LFill(NIRE, 11) +
		                       LFill(CNPJ) +
		                       LFill(DT_ARQ) +
		                       LFill(DT_ARQ_CONV, "ddmmyyyy" ) +
		                       LFill(DESC_MUN) +
		                       LFill(DT_EX_SOCIAL, "ddmmyyyy" ) +
		                       LFill(NOME_AUDITOR) +
		                       LFill(COD_CVM_AUDITOR) +
		                       LFill("") +
		                       LFill("");
		         }
		       else
		         {
		           strLinha = LFill("I030") +
		                       LFill("TERMO DE ABERTURA") +
		                       LFill(NUM_ORD) +
		                       LFill(NAT_LIVR) +
		                       LFill("[*******]") +
		                       LFill(NOME) +
		                       LFill(NIRE, 11) +
		                       LFill(CNPJ) +
		                       LFill(DT_ARQ) +
		                       LFill(DT_ARQ_CONV, "ddmmyyyy" ) +
		                       LFill(DESC_MUN) +
		                       LFill("") +
		                       LFill("");
		         }
		       
		       AppendText( strLinha);
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		protected void WriteRegistroI050()
		{
		 int intFor;
		  if( Assigned(FRegistroI050) )
		  {
		     for( intFor = 0;intFor <= FRegistroI050.Count - 1;intFor++)
		     {
		        using(FRegistroI050.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I050") +
		                LFill(DT_ALT) +
		                LFill(COD_NAT, 2) +
		                LFill(IND_CTA, 1) +
		                LFill(NIVEL) +
		                LFill(COD_CTA) +
		                LFill(COD_CTA_SUP) +
		                LFill(CTA) 
		                );
		        }
		        //  Registros Filhos
		        WriteRegistroI051(FRegistroI050.Items[intFor]);
		        WriteRegistroI052(FRegistroI050.Items[intFor]);
		        WriteRegistroI053(FRegistroI050.Items[intFor]);
		
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		private void WriteRegistroI051( TRegistroI050 RegI050)
		{
		 int intFor;
		  if( Assigned(RegI050.RegistroI051) )
		  {
		     for( intFor = 0;intFor <= RegI050.RegistroI051.Count - 1;intFor++)
		     {
		        using(RegI050.RegistroI051.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I051") +
		                LFill(COD_PLAN_REF, 1) +
		                LFill(COD_CCUS) +
		                LFill(COD_CTA_REF) 
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		     FRegistroI051Count = FRegistroI051Count + RegI050.RegistroI051.Count;
		  }
		}
		
		
		
		private void WriteRegistroI052( TRegistroI050 RegI050)
		{
		 int intFor;
		  if( Assigned(RegI050.RegistroI052) )
		  {
		     for( intFor = 0;intFor <= RegI050.RegistroI052.Count - 1;intFor++)
		     {
		        using(RegI050.RegistroI052.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I052") +
		                LFill(COD_CCUS) +
		                LFill(COD_AGL) 
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		     FRegistroI052Count = FRegistroI052Count + RegI050.RegistroI052.Count;
		  }
		
		}
		
		
		
		private void WriteRegistroI053( TRegistroI050 RegI050)
		{
		 int intFor;
		
		  if( Assigned(RegI050.RegistroI053) )
		  {
		     for( intFor = 0;intFor <= RegI050.RegistroI053.Count - 1;intFor++)
		     {
		        using(RegI050.RegistroI053.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I053") +
						LFill(COD_IDT) +
		                LFill(COD_CNT_CORR) +
		                LFill(NAT_SUB_CNT)
						);
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		     FRegistroI053Count = FRegistroI053Count + RegI050.RegistroI053.Count;
		  }  
		}
		
		
		
		protected void WriteRegistroI075()
		{
		 int intFor;
		  if( Assigned(RegistroI075) )
		  {
		     for( intFor = 0;intFor <= RegistroI075.Count - 1;intFor++)
		     {
		        using(RegistroI075.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I075") +
		                LFill(COD_HIST) +
		                LFill(DESCR_HIST)
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		protected void WriteRegistroI100()
		{
		 int intFor;
		  if( Assigned(RegistroI100) )
		  {
		     for( intFor = 0;intFor <= RegistroI100.Count - 1;intFor++)
		     {
		        using(RegistroI100.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I100") +
		                LFill(DT_ALT) +
		                LFill(COD_CCUS) +
		                LFill(CCUS)
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }                    
		}
		
		
		
		protected void WriteRegistroI150()
		{
		 int intFor;
		  if( Assigned(RegistroI150) )
		  {
		     for( intFor = 0;intFor <= RegistroI150.Count - 1;intFor++)
		     {
		        using(RegistroI150.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I150") +
		                LFill(DT_INI) +
		                LFill(DT_FIN) 
		                );
		        }
		        //  Registro Filho
		        WriteRegistroI151(RegistroI150.Items[intFor]);
		        WriteRegistroI155(RegistroI150.Items[intFor]);
		
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		private void WriteRegistroI151( TRegistroI150 RegI150)
		{
		 int intFor;
		  if( Assigned(RegI150.RegistroI151) )
		  {
		     for( intFor = 0;intFor <= RegI150.RegistroI151.Count - 1;intFor++)
		     {
		        using(RegI150.RegistroI151.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I151") +
		                LFill(ASSIM_DIG) 
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		     FRegistroI151Count = FRegistroI151Count + RegI150.RegistroI151.Count;
		  }
		}
		
		
		
		private void WriteRegistroI155( TRegistroI150 RegI150)
		{
		 int intFor;
		  if( Assigned(RegI150.RegistroI155) )
		  {
		     for( intFor = 0;intFor <= RegI150.RegistroI155.Count - 1;intFor++)
		     {
		        using(RegI150.RegistroI155.Items[intFor]){
		           Check(((IND_DC_INI == "D") || (IND_DC_INI == "C") || (IND_DC_INI == "")), "(I-I155) No Indicador da situa??o do saldo inicial, deve ser informado: D ou C ou nulo!");
		           Check(((IND_DC_FIN == "D") || (IND_DC_FIN == "C") || (IND_DC_FIN == "")), "(I-I155) No Indicador da situa??o do saldo inicial, deve ser informado: D ou C ou nulo!");
		           // /
		           
		           AppendText( LFill("I155") +
		                LFill(COD_CTA) +
		                LFill(COD_CCUS) +
		                LFill(VL_SLD_INI, 19, 2) +
		                LFill(IND_DC_INI, 0) +
		                LFill(VL_DEB, 19, 2) +
		                LFill(VL_CRED, 19, 2) +
		                LFill(VL_SLD_FIN, 19, 2) +
		                LFill(IND_DC_FIN, 0) 
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		     FRegistroI155Count = FRegistroI155Count + RegI150.RegistroI155.Count;
		  }
		}
		
		
		
		protected void WriteRegistroI200()
		{
		 int intFor;
		  if( Assigned(FRegistroI200) )
		  {
		     for( intFor = 0;intFor <= FRegistroI200.Count - 1;intFor++)
		     {
		        using(FRegistroI200.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I200") +
		                LFill(NUM_LCTO) +
		                LFill(DT_LCTO) +
		                LFill(VL_LCTO, 19, 2) +
		                LFill(IND_LCTO) 
		                );
		        }
		        //  Registro Filho
		        WriteRegistroI250(FRegistroI200.Items[intFor]);
		
		        FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		private void WriteRegistroI250( TRegistroI200 RegI200)
		{
		 int intFor;
		  if( Assigned(RegI200.RegistroI250) )
		  {
		     for( intFor = 0;intFor <= RegI200.RegistroI250.Count - 1;intFor++)
		     {
		        using(RegI200.RegistroI250.Items[intFor]){
		           // / Checagem das informa??es que formar?o o registro
		           Check(((IND_DC == "D") || (IND_DC == "C")), "(I-I250) Indicador da natureza da partida, deve ser informado: D ou C!");
		           // /
		           
		           AppendText( LFill("I250") +
		                LFill(COD_CTA) +
		                LFill(COD_CCUS) +
		                LFill(VL_DC, 19, 2) +
		                LFill(IND_DC) +
		                LFill(NUM_ARQ) +
		                LFill(COD_HIST_PAD) +
		                LFill(HIST) +
		                LFill(COD_PART) 
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		     FRegistroI250Count = FRegistroI250Count + RegI200.RegistroI250.Count;
		  }
		}
		
		
		
		
		protected void WriteRegistroI300()
		{
		 int intFor;
		  if( Assigned(FRegistroI300) )
		  {
		     for( intFor = 0;intFor <= FRegistroI300.Count - 1;intFor++)
		     {
		        using(FRegistroI300.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I300") +
		                LFill(DT_BCTE) 
		                );
		        }
		        //  Registro Filho
		        WriteRegistroI310(FRegistroI300.Items[intFor]);
		
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		private void WriteRegistroI310( TRegistroI300 RegI300)
		{
		 int intFor;
		  if( Assigned(RegI300.RegistroI310) )
		  {
		     for( intFor = 0;intFor <= RegI300.RegistroI310.Count - 1;intFor++)
		     {
		        using(RegI300.RegistroI310.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I310") +
		                LFill(COD_CTA) +
		                LFill(COD_CCUS) +
		                LFill(VAL_DEBD, 19, 2) +
		                LFill(VAL_CRED, 19, 2) 
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		     FRegistroI310Count = FRegistroI310Count + RegI300.RegistroI310.Count;
		  }
		}
		
		
		
		protected void WriteRegistroI350()
		{
		 int intFor;
		  if( Assigned(FRegistroI350) )
		  {
		     for( intFor = 0;intFor <= FRegistroI350.Count - 1;intFor++)
		     {
		        using(FRegistroI350.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I350") +
		                LFill(DT_RES) 
		                );
		        }
		        //  Registro Filho
		        WriteRegistroI355(FRegistroI350.Items[intFor]);
		
		        FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		private void WriteRegistroI355( TRegistroI350 RegI350)
		{
		 int intFor;
		  if( Assigned(RegI350.RegistroI355) )
		  {
		     for( intFor = 0;intFor <= RegI350.RegistroI355.Count - 1;intFor++)
		     {
		        using(RegI350.RegistroI355.Items[intFor]){
		           // / Checagem das informa??es que formar?o o registro
		           Check(((IND_DC == "D") || (IND_DC == "C") || (IND_DC == "")), "(I-I355) No Indicador da situa??o do saldo inicial, deve ser informado: D ou C ou nulo!");
		           Check(((IND_DC == "D") || (IND_DC == "C") || (IND_DC == "")), "(I-I355) No Indicador da situa??o do saldo inicial, deve ser informado: D ou C ou nulo!");
		           // /
		           
		           AppendText( LFill("I355") +
		                LFill(COD_CTA) +
		                LFill(COD_CCUS) +
		                LFill(VL_CTA, 19, 2) +
		                LFill(IND_DC, 0) 
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		     FRegistroI355Count = FRegistroI355Count + RegI350.RegistroI355.Count;
		  }
		}
		
		
		
		protected void WriteRegistroI500()
		{
		 int intFor;
		  if( Assigned(FRegistroI500) )
		  {
		     for( intFor = 0;intFor <= FRegistroI500.Count - 1;intFor++)
		     {
		        using(FRegistroI500.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I500") +
		                LFill(TAM_FONTE, 2)
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		
		protected void WriteRegistroI510()
		{
		 int intFor;
		  if( Assigned(FRegistroI510) )
		  {
		     for( intFor = 0;intFor <= FRegistroI510.Count - 1;intFor++)
		     {
		        using(FRegistroI510.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I510") +
		                RFill(NM_CAMPO,16," ") +
		                RFill(DESC_CAMPO, 50, " ") +
		                LFill(TIPO_CAMPO) +
		                LFill(TAM_CAMPO, 3) +
		                LFill(DEC_CAMPO, 2) +
		                LFill(COL_CAMPO, 3)
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		protected void WriteRegistroI550()
		{
		 int intFor;
		  if( Assigned(FRegistroI550) )
		  {
		     for( intFor = 0;intFor <= FRegistroI550.Count - 1;intFor++)
		     {
		        using(FRegistroI550.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I550") +
		                RFill(RZ_CONT) 
		                );
		        }
		        //  Registro Filho
		        WriteRegistroI555(FRegistroI550.Items[intFor]);
		
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		  }
		}
		
		
		
		private void WriteRegistroI555( TRegistroI550 RegI550)
		{
		 int intFor;
		  if( Assigned(RegI550.RegistroI555) )
		  {
		     for( intFor = 0;intFor <= RegI550.RegistroI555.Count - 1;intFor++)
		     {
		        using(RegI550.RegistroI555.Items[intFor]){
		           // /
		           
		           AppendText( LFill("I555") +
		                RFill(RZ_CONT_TOT) 
		                );
		        }
		       FRegistroI990.QTD_LIN_I = FRegistroI990.QTD_LIN_I + 1;
		     }
		     FRegistroI555Count = FRegistroI555Count + RegI550.RegistroI555.Count;
		  }
		}
		
		
		
		protected void WriteRegistroI990()
		{
		 string strLinha;
		  if( Assigned(FRegistroI990) )
		  {
		     using(FRegistroI990){
		       QTD_LIN_I = QTD_LIN_I + 1;
		       // /
		       strLinha= LFill("I990") +
		            LFill(QTD_LIN_I, 0);
		       
		       AppendText(strLinha);
		     }
		  }
		}
		
		
	}
	
	public static class ACBrECDBloco_I_Class 
	{
		
		
		
		
		
		public  ()
		{
		
		  FRegistroI001.Dispose();
		  FRegistroI010.Dispose();
		  FRegistroI012.Dispose();
		  FRegistroI020.Dispose();
		  FRegistroI030.Dispose();
		  FRegistroI050.Dispose();
		  FRegistroI075.Dispose();
		  FRegistroI100.Dispose();
		  FRegistroI150.Dispose();
		  FRegistroI200.Dispose();
		  FRegistroI300.Dispose();
		  FRegistroI350.Dispose();
		  FRegistroI500.Dispose();
		  FRegistroI510.Dispose();
		  FRegistroI550.Dispose();
		
		  FRegistroI990.Dispose();
		  base.Destroy;
		}
		
		
		
	}
	
}
