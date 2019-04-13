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
using ProjetoSpedContabil.ACBrECDBloco_J_NS;
using ProjetoSpedContabil.ACBrECDBloco_0_Class_NS;

namespace ProjetoSpedContabil
{
	
	  // / TBloco_J -
	  
	public class TBloco_J : TACBrSPED
	{
		
		
		  
		           // / BLOCO J - RegistroJ001
		       // / BLOCO J - Lista de RegistroJ005
		       // / BLOCO J - Lista de RegistroJ800
		           // / BLOCO J - RegistroJ900
		       // / BLOCO J - Lista de RegistroJ930
		       // / BLOCO J - Lista de RegistroJ935
		           // / BLOCO J - FRegistroJ990
		
		    private int FRegistroJ100Count; 
		    private int FRegistroJ150Count; 
		    private int FRegistroJ200Count; 
		    private int FRegistroJ210Count; 
		    private int FRegistroJ215Count; 
		
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
		    
		
		
		    public TRegistroJ001     RegistroJ001
		    {
		    	get
		    	{
		    		return fRegistroJ001;
		    	}
		    	set
		    	{
		    		fRegistroJ001 = value;
		    	}
		    }
		    
		
		    public TRegistroJ005List RegistroJ005
		    {
		    	get
		    	{
		    		return fRegistroJ005;
		    	}
		    	set
		    	{
		    		fRegistroJ005 = value;
		    	}
		    }
		    
		
		    public TRegistroJ800List RegistroJ800
		    {
		    	get
		    	{
		    		return fRegistroJ800;
		    	}
		    	set
		    	{
		    		fRegistroJ800 = value;
		    	}
		    }
		    
		
		    public TRegistroJ900     RegistroJ900
		    {
		    	get
		    	{
		    		return fRegistroJ900;
		    	}
		    	set
		    	{
		    		fRegistroJ900 = value;
		    	}
		    }
		    
		
		    public TRegistroJ930List RegistroJ930
		    {
		    	get
		    	{
		    		return fRegistroJ930;
		    	}
		    	set
		    	{
		    		fRegistroJ930 = value;
		    	}
		    }
		    
		
		    public TRegistroJ935List RegistroJ935
		    {
		    	get
		    	{
		    		return fRegistroJ935;
		    	}
		    	set
		    	{
		    		fRegistroJ935 = value;
		    	}
		    }
		    
		
		    public TRegistroJ990     RegistroJ990
		    {
		    	get
		    	{
		    		return fRegistroJ990;
		    	}
		    	set
		    	{
		    		fRegistroJ990 = value;
		    	}
		    }
		    
		
		    public Integer RegistroJ100Count
		    {
		    	get
		    	{
		    		return FRegistroJ100Count;
		    	}
		    	set
		    	{
		    		FRegistroJ100Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroJ150Count
		    {
		    	get
		    	{
		    		return FRegistroJ150Count;
		    	}
		    	set
		    	{
		    		FRegistroJ150Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroJ200Count
		    {
		    	get
		    	{
		    		return FRegistroJ200Count;
		    	}
		    	set
		    	{
		    		FRegistroJ200Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroJ210Count
		    {
		    	get
		    	{
		    		return FRegistroJ210Count;
		    	}
		    	set
		    	{
		    		FRegistroJ210Count = value;
		    	}
		    }
		    
		
		    public Integer RegistroJ215Count
		    {
		    	get
		    	{
		    		return FRegistroJ215Count;
		    	}
		    	set
		    	{
		    		FRegistroJ215Count = value;
		    	}
		    }
		    
		public  TBloco_J()
		{
		
		  FRegistroJ001 = new TRegistroJ001();
		  FRegistroJ005 = new TRegistroJ005List();
		  FRegistroJ800 = new TRegistroJ800List();
		  FRegistroJ900 = new TRegistroJ900();
		  FRegistroJ930 = new TRegistroJ930List();
		  FRegistroJ935 = new TRegistroJ935List();
		  FRegistroJ990 = new TRegistroJ990();
		  FRegistroJ100Count = 0;
		  FRegistroJ150Count = 0;
		  FRegistroJ200Count = 0;
		  FRegistroJ210Count = 0;
		  FRegistroJ215Count = 0;
		
		  FRegistroJ990.QTD_LIN_J = 0;
		}
		
		
		
		private void LimpaRegistros()
		{
		
		  FRegistroJ005.Clear();
		  FRegistroJ800.Clear();
		  FRegistroJ930.Clear();
		  FRegistroJ935.Clear();  
		
		  FRegistroJ990.QTD_LIN_J = 0;
		}
		
		
		
		protected void WriteRegistroJ001()
		{
		
		  if( Assigned(FRegistroJ001) )
		  {
		     using(FRegistroJ001){
		       Check(((IND_DAD == 0) || (IND_DAD == 1)), "(J-J001) Na abertura do bloco, deve ser informado o n?mero 0 ou 1!");
		       // /
		       
		       AppendText( LFill("J001") +
		            LFill(IND_DAD, 1) 
		            );
		       // /
		       FRegistroJ990.QTD_LIN_J = FRegistroJ990.QTD_LIN_J + 1;
		     }
		  }
		}
		
		
		
		protected void WriteRegistroJ005()
		{
		 int intFor;
		  if( Assigned(FRegistroJ005) )
		  {
		     for( intFor = 0;intFor <= FRegistroJ005.Count - 1;intFor++)
		     {
		        using(FRegistroJ005.Items[intFor]){
		           Check(((ID_DEM == 1) || (ID_DEM == 2)), "(J-J005) Na Identifica??o das demonstra??es, deve ser informado o n?mero 1 ou 2!");
		           // /
		           
		           AppendText( LFill("J005") +
		                LFill(DT_INI) +
		                LFill(DT_FIN) +
		                LFill(ID_DEM, 1) +
		                LFill(CAB_DEM) 
		                );
		        }
		        //  Registros Filhos
		        WriteRegistroJ100(FRegistroJ005.Items[intFor]);
		        WriteRegistroJ150(FRegistroJ005.Items[intFor]);
		        WriteRegistroJ200(FRegistroJ005.Items[intFor]);
		        WriteRegistroJ210(FRegistroJ005.Items[intFor]);
		
		        FRegistroJ990.QTD_LIN_J = FRegistroJ990.QTD_LIN_J + 1;
		     }
		  }
		}
		
		
		
		private void WriteRegistroJ100( TRegistroJ005 RegJ005)
		{
		 int intFor;
		  if( Assigned(RegJ005.RegistroJ100) )
		  {
		     for( intFor = 0;intFor <= RegJ005.RegistroJ100.Count - 1;intFor++)
		     {
		        using(RegJ005.RegistroJ100.Items[intFor]){
		           // /
		           Check(((IND_GRP_BAL == "1") || (IND_GRP_BAL == "2")), "(J-J100) No Indicador de grupo do balan?o, deve ser informado o n?mero 1 ou 2!");
		           Check(((IND_DC_BAL == "D") || (IND_DC_BAL == "C")), "(J-J100) No Indicador da situa??o do saldo, deve ser informado: D ou C!");
		           // / Layout 2 a partir da escritura??o ano calend?rio 2013
		           if( DT_INI >= EncodeDate(2013,01,01) )
		              Check(((IND_DC_BAL_INI == "D") || (IND_DC_BAL_INI == "C")), "(J-J100) No Indicador da situa??o do saldo inicial do c?digo de aglutina??o no Balan?a Patrimonial, deve ser informado: D ou C!");
		           // /
		           // / Layout 2 a partir da escritura??o ano calend?rio 2013
		           if( DT_INI >= EncodeDate(2013,01,01) )
		           {
		             
		             AppendText( LFill("J100") +
		                  LFill(COD_AGL) +
		                  LFill(NIVEL_AGL) +
		                  LFill(IND_GRP_BAL, 1) +
		                  LFill(DESCR_COD_AGL) +
		                  LFill(VL_CTA, 19, 2) +
		                  LFill(IND_DC_BAL, 1) +
		                  LFill(VL_CTA_INI, 19, 2) +
		                  LFill(IND_DC_BAL_INI) 
		                  );
		           }
		            else
		             {
		               
		               AppendText( LFill("J100") +
		                    LFill(COD_AGL) +
		                    LFill(NIVEL_AGL) +
		                    LFill(IND_GRP_BAL, 1) +
		                    LFill(DESCR_COD_AGL) +
		                    LFill(VL_CTA, 19, 2) +
		                    LFill(IND_DC_BAL, 1) 
		                    );
		             }
		        }
		        FRegistroJ990.QTD_LIN_J = FRegistroJ990.QTD_LIN_J + 1;
		     }
		     FRegistroJ100Count = FRegistroJ100Count + RegJ005.RegistroJ100.Count;
		  }
		}
		
		
		
		private void WriteRegistroJ150( TRegistroJ005 RegJ005)
		{
		 int intFor;
		  if( Assigned(RegJ005.RegistroJ150) )
		  {
		     for( intFor = 0;intFor <= RegJ005.RegistroJ150.Count - 1;intFor++)
		     {
		        using(RegJ005.RegistroJ150.Items[intFor]){
		           Check(((IND_VL == "D") || (IND_VL == "R") || (IND_VL == "P") || (IND_VL == "N")), "(J-J150) No Indicador da situa??o do valor, deve ser informado: D ou R ou P ou N!");
		           Check(((IND_VL_ULT_DRE == "D") || (IND_VL_ULT_DRE == "R") || (IND_VL_ULT_DRE == "P") || (IND_VL_ULT_DRE == "N")), "(J-J150) No Indicador da situa??o do saldo valor inicial, deve ser informado: D ou R ou P ou N!");
		           // /
		           
		           AppendText( LFill("J150") +
		                LFill(COD_AGL) +
		                LFill(NIVEL_AGL) +
		                LFill(DESCR_COD_AGL) +
		                LFill(VL_CTA, 19, 2) +
		                LFill(IND_VL, 1) +
		                LFill(VL_CTA_ULT_DRE, 19, 2) +
		                LFill(IND_VL_ULT_DRE, 1)
		                );
		
		        }
		        FRegistroJ990.QTD_LIN_J = FRegistroJ990.QTD_LIN_J + 1;
		     }
		     FRegistroJ150Count = FRegistroJ150Count + RegJ005.RegistroJ150.Count;
		  }
		}
		
		
		
		// Registro inclu?do a partir do layout 2
		private void WriteRegistroJ200( TRegistroJ005 RegJ005)
		{
		 int intFor;
		  if( Assigned(RegJ005.RegistroJ200) )
		  {
		     for( intFor = 0;intFor <= RegJ005.RegistroJ200.Count - 1;intFor++)
		     {
		        using(RegJ005.RegistroJ200.Items[intFor]){
		           // /
		           Check(((COD_HIST_FAT != "")), "(J-J200) C?digo do hist?rico do fato cont?bil deve ser informado!");
		           Check(((DESC_FAT != "")), "(J-J200) Descri??o do fato cont?bil deve ser informado!");
		           
		           AppendText( LFill("J200") +
		                LFill(COD_HIST_FAT) +
		                LFill(DESC_FAT) 
		                );
		
		        }
		        FRegistroJ990.QTD_LIN_J = FRegistroJ990.QTD_LIN_J + 1;
		     }
		     FRegistroJ200Count = FRegistroJ200Count + RegJ005.RegistroJ200.Count;
		  }
		}
		
		
		
		// / J210 - Layout 2 a partir da escritura??o ano calend?rio 2013
		private void WriteRegistroJ210( TRegistroJ005 RegJ005)
		{
		 int intFor;
		  if( Assigned(RegJ005.RegistroJ210) )
		  {
		     for( intFor = 0;intFor <= RegJ005.RegistroJ210.Count - 1;intFor++)
		     {
		        using(RegJ005.RegistroJ210.Items[intFor]){
		           // /
		           Check(((IND_TIP == "0") || (IND_TIP == "1")), "(J-J210) No Indicador do tipo de demonstra??o, deve ser informado o n?mero 0 ou 1!");
		           Check(((IND_DC_CTA == "D") || (IND_DC_CTA == "C")), "(J-J210) No Indicador da situa??o do saldo final informado no campo anterior, deve ser informado: D ou C!");
		           Check(((IND_DC_CTA_INI == "D") || (IND_DC_CTA_INI == "C")), "(J-J210) Indicador da situa??o do saldo inicial informado no campo anterior, deve ser informado: D ou C!");
		           // /
		           
		           AppendText( LFill("J210") +
		                LFill(IND_TIP) +
		                LFill(COD_AGL) +
		                LFill(DESCR_COD_AGL) +
		                LFill(VL_CTA, 19, 2) +
		                LFill(IND_DC_CTA) +
		                LFill(VL_CTA_INI, 19, 2) +
		                LFill(IND_DC_CTA_INI) 
		                );
		        }
		        WriteRegistroJ215(RegJ005.RegistroJ210.Items[intFor]);
		
		        FRegistroJ990.QTD_LIN_J = FRegistroJ990.QTD_LIN_J + 1;
		     }
		     FRegistroJ210Count = FRegistroJ210Count + RegJ005.RegistroJ210.Count;
		  }
		}
		
		
		
		private void WriteRegistroJ215( TRegistroJ210 RegJ210)
		{
		 int intFor;
		  if( Assigned(RegJ210.RegistroJ215) )
		  {
		     for( intFor = 0;intFor <= RegJ210.RegistroJ215.Count - 1;intFor++)
		     {
		        using(RegJ210.RegistroJ215.Items[intFor]){
		           // /
		           Check(((COD_HIST_FAT != "")), "(J-J215) C?digo do hist?rico do fato cont?bil deve ser informado!");
		           Check(((IND_DC_FAT == "D") || (IND_DC_FAT == "C") || (IND_DC_FAT == "P") || (IND_DC_FAT == "N")), "(J-J215) Indicador de situa??o do saldo informado, deve ser informado: D ou C ou P ou N!");
		
		           
		
		           AppendText( LFill("J215") +
		                LFill(COD_HIST_FAT) +
		                LFill(VL_FAT_CONT, 19, 2) +
		                LFill(IND_DC_FAT) 
		                );
		        }
		        FRegistroJ990.QTD_LIN_J = FRegistroJ990.QTD_LIN_J + 1;
		     }
		     FRegistroJ215Count = FRegistroJ215Count + RegJ210.RegistroJ215.Count;
		  }
		}
		
		
		
		protected void WriteRegistroJ800()
		{
		 int intFor;
		  if( Assigned(FRegistroJ800) )
		  {
		     for( intFor = 0;intFor <= FRegistroJ800.Count - 1;intFor++)
		     {
		        using(FRegistroJ800.Items[intFor]){
		           // /
		           
		           AppendText( LFill("J800") +
		                LFill(ARQ_RTF) +
		                LFill("J800FIM") 
		                );
		        }
		        FRegistroJ990.QTD_LIN_J = FRegistroJ990.QTD_LIN_J + 1;
		     }
		  }
		}
		
		
		
		protected void WriteRegistroJ900()
		{
		 string strLinha;
		  if( Assigned(FRegistroJ900) )
		  {
		     using(FRegistroJ900){
		       // /
		       strLinha = LFill("J900") +
		            LFill("TERMO DE ENCERRAMENTO") +
		            LFill(NUM_ORD) +
		            LFill(NAT_LIVRO) +
		            LFill(NOME) +
		            LFill("[*******]") +
		            LFill(DT_INI_ESCR) +
		            LFill(DT_FIN_ESCR);
		       // /
		       
		       AppendText(strLinha);              
		       FRegistroJ990.QTD_LIN_J = FRegistroJ990.QTD_LIN_J + 1;       
		     }
		  }
		}
		
		
		
		protected void WriteRegistroJ930()
		{
		 int intFor;
		  if( Assigned(FRegistroJ930) )
		  {
		     for( intFor = 0;intFor <= FRegistroJ930.Count - 1;intFor++)
		     {
		        using(FRegistroJ930.Items[intFor]){
		         // / Layout 2 a partir da escritura??o ano calend?rio 2013
		         if( DT_INI >= EncodeDate(2013,01,01) )
		         {
		             
		             AppendText( LFill("J930") +
		                  LFill(IDENT_NOM) +
		                  LFill(IDENT_CPF) +
		                  LFill(IDENT_QUALIF) +
		                  LFill(COD_ASSIN, 3) +
		                  LFill(IND_CRC) +
		                  LFill(EMAIL) +
		                  LFill(FONE) +
		                  LFill(UF_CRC) +
		                  LFill(NUM_SEQ_CRC) +
		                  LFill(DT_CRC) 
		                  );
		         }
		          else
		           {
		             
		             AppendText( LFill("J930") +
		                  LFill(IDENT_NOM) +
		                  LFill(IDENT_CPF) +
		                  LFill(IDENT_QUALIF) +
		                  LFill(COD_ASSIN, 3) +
		                  LFill(IND_CRC) 
		                  );
		
		           }
		        }
		        FRegistroJ990.QTD_LIN_J = FRegistroJ990.QTD_LIN_J + 1;
		     }
		  }
		}
		
		
		
		protected void WriteRegistroJ935()
		{
		 int intFor;
		  if( Assigned(FRegistroJ935) )
		  {
		     for( intFor = 0;intFor <= FRegistroJ935.Count - 1;intFor++)
		     {
		        using(FRegistroJ935.Items[intFor]){
		           
		           AppendText( LFill("J935") +
		                LFill(NOME_AUDITOR) +
		                LFill(COD_CVM_AUDITOR)
		                );
		        }
		        FRegistroJ990.QTD_LIN_J = FRegistroJ990.QTD_LIN_J + 1;
		     }
		  }  
		}
		
		
		
		protected void WriteRegistroJ990()
		{
		 string strLinha ;
		  if( Assigned(FRegistroJ990) )
		  {
		     using(FRegistroJ990){
		       QTD_LIN_J = QTD_LIN_J + 1;
		       // /
		       strLinha = LFill("J990") +
		            LFill(QTD_LIN_J, 0);            
		                   
		       AppendText(strLinha);
		     }
		  }
		}
		
		
	}
	
	public static class ACBrECDBloco_J_Class 
	{
		
		
		
		
		
		public  ()
		{
		
		  FRegistroJ001.Dispose();
		  FRegistroJ005.Dispose();
		  FRegistroJ800.Dispose();
		  FRegistroJ900.Dispose();
		  FRegistroJ930.Dispose();
		  FRegistroJ935.Dispose();  
		  FRegistroJ990.Dispose();
		  base.Destroy;
		}
		
		
		
	}
	
}
