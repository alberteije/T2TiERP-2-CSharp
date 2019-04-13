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
using ProjetoSpedContabil.ACBrECDBloco_9_NS;
using ProjetoSpedContabil.ACBrECDBloco_0_Class_NS;

namespace ProjetoSpedContabil
{
	
	  // / TBloco_9 -
	  
	public class TBloco_9 : TACBrSPED
	{
		
		
		  
		           // / BLOCO 9 - Registro9001
		       // / BLOCO 9 - Lista de Registro9900
		           // / BLOCO 9 - FRegistro9990
		           // / BLOCO 9 - Registro9999
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
		    
		
		
		    public TRegistro9001     Registro9001
		    {
		    	get
		    	{
		    		return FRegistro9001;
		    	}
		    	set
		    	{
		    		FRegistro9001 = value;
		    	}
		    }
		    
		
		    public TRegistro9900List Registro9900
		    {
		    	get
		    	{
		    		return FRegistro9900;
		    	}
		    	set
		    	{
		    		FRegistro9900 = value;
		    	}
		    }
		    
		
		    public TRegistro9990     Registro9990
		    {
		    	get
		    	{
		    		return FRegistro9990;
		    	}
		    	set
		    	{
		    		FRegistro9990 = value;
		    	}
		    }
		    
		
		    public TRegistro9999     Registro9999
		    {
		    	get
		    	{
		    		return FRegistro9999;
		    	}
		    	set
		    	{
		    		FRegistro9999 = value;
		    	}
		    }
		    
		public  TBloco_9()
		{
		
		  FRegistro9001 = new TRegistro9001();
		  FRegistro9900 = new TRegistro9900List();
		  FRegistro9990 = new TRegistro9990();
		  FRegistro9999 = new TRegistro9999();
		
		  FRegistro9990.QTD_LIN_9 = 0;
		}
		
		
		
		private void LimpaRegistros()
		{
		
		  FRegistro9900.Clear();
		
		  FRegistro9990.QTD_LIN_9 = 0;
		}
		
		
		
		protected void WriteRegistro9001()
		{
		
		  if( Assigned(FRegistro9001) )
		  {
		     using(FRegistro9001){
		       Check(((IND_DAD == 0) || (IND_DAD == 1)), "(9-9001) Na abertura do bloco, deve ser informado o n?mero 0 ou 1!");
		       // /
		       
		       AppendText( LFill("9001") +
		            LFill(IND_DAD, 1) 
		            );
		       // /
		       FRegistro9990.QTD_LIN_9 = FRegistro9990.QTD_LIN_9 + 1;
		     }
		  }
		}
		
		
		
		protected void WriteRegistro9900()
		{
		 int intFor;
		  if( Assigned(FRegistro9900) )
		  {
		     for( intFor = 0;intFor <= FRegistro9900.Count - 1;intFor++)
		     {
		        using(FRegistro9900.Items[intFor]){
		           
		           AppendText( LFill("9900") +
		                LFill(REG_BLC) +
		                LFill(QTD_REG_BLC, 0) 
		                );
		        }
		     }
		     FRegistro9990.QTD_LIN_9 = FRegistro9990.QTD_LIN_9 + FRegistro9900.Count + 2;
		  }
		}
		
		
		
		protected void WriteRegistro9990()
		{
		
		  if( Assigned(FRegistro9990) )
		  {
		     using(FRegistro9990){
		        
		        AppendText( LFill("9990") +
		             LFill(QTD_LIN_9, 0) 
		             );
		     }
		  }
		}
		
		
		
		protected void WriteRegistro9999()
		{
		
		  if( Assigned(Registro9999) )
		  {
		     using(FRegistro9999){
		        
		        AppendText( LFill("9999") +
		             LFill(QTD_LIN, 0)
		             );
		     }
		  }
		}
		
		
	}
	
	public static class ACBrECDBloco_9_Class 
	{
		
		
		
		
		
		public  ()
		{
		
		  FRegistro9001.Dispose();
		  FRegistro9900.Dispose();
		  FRegistro9990.Dispose();
		  FRegistro9999.Dispose();
		  base.Destroy;
		}
		
		
		
	}
	
}
