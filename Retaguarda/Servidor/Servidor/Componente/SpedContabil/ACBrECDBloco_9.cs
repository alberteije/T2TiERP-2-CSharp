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
using ProjetoSpedContabil.ACBrECDBlocos_NS;

namespace ProjetoSpedContabil
{
	
	 // / Registro 9001 - ABERTURA DO BLOCO 9
	
	 
	public class TRegistro9001 : TOpenBlocos
	{
		
		
	}
	
	
	 // / Registro 9900 - REGISTROS DO ARQUIVO
	
	 
	public class TRegistro9900 
	{
		
		
		   private string fREG_BLC;       // / Registro que ser? totalizado no pr?ximo campo.
		   private int fQTD_REG_BLC; // / Total de registros do tipo informado no campo anterior.
		 
		   public String REG_BLC
		   {
		   	get
		   	{
		   		return fREG_BLC;
		   	}
		   	set
		   	{
		   		fREG_BLC = value;
		   	}
		   }
		   
		
		   public Integer QTD_REG_BLC
		   {
		   	get
		   	{
		   		return fQTD_REG_BLC;
		   	}
		   	set
		   	{
		   		fQTD_REG_BLC = value;
		   	}
		   }
		   
		
	}
	
	
	  // / Registro 9900 - Lista
	
	  
	public class TRegistro9900List : TObjectList
	{
		
		// / GetItem
		// / SetItem
		
		
		    property Items[Index: Integer]: TRegistro9900 read GetItem write SetItem;
		private TRegistro9900 GetItem( int Index)
		{
		
		TRegistro9900 Result;
		
		  Result = TRegistro9900(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistro9900 New()
		{
		
		TRegistro9900 Result;
		
		  Result = new TRegistro9900();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistro9900 Value)
		{
		
		  Put(Index, Value);
		}
		
		
	}
	
	
	 // / Registro 9990 - ENCERRAMENTO DO BLOCO 9
	
	 
	public class TRegistro9990 
	{
		
		
		   private int fQTD_LIN_9; // / Quantidade total de linhas do arquivo digital.
		 
		   public Integer QTD_LIN_9
		   {
		   	get
		   	{
		   		return fQTD_LIN_9;
		   	}
		   	set
		   	{
		   		fQTD_LIN_9 = value;
		   	}
		   }
		   
		
	}
	
	
	 // / Registro 9999 - ENCERRAMENTO DO ARQUIVO DIGITAL
	
	 
	public class TRegistro9999 
	{
		
		
		   private int fQTD_LIN; // / Quantidade total de linhas do arquivo digital.
		 
		   public Integer QTD_LIN
		   {
		   	get
		   	{
		   		return fQTD_LIN;
		   	}
		   	set
		   	{
		   		fQTD_LIN = value;
		   	}
		   }
		   
		
	}
	
	public static class ACBrECDBloco_9 
	{
		
		
		
		
		
	}
	
}
