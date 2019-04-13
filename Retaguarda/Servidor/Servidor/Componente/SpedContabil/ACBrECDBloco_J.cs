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
	
	  // / Registro J001 - ABERTURA DO BLOCO J
	
	  
	public class TRegistroJ001 : TOpenBlocos
	{
		
		
	}
	
	
	  
	public class TRegistroJ005 
	{
		
		
		    private System.DateTime fDT_INI;    // / Data inicial das demonstra??es cont?beis.
		    private System.DateTime fDT_FIN;    // / Data final das demonstra??es cont?beis.
		    private int fID_DEM;      // / Identifica??o das demonstra??es: 1 - demonstra??es cont?beis do empres?rio ou sociedade empres?ria a que se refere a escritura??o; 2 - demonstra??es consolidadas ou de outros empres?rios ou sociedades empres?rias.
		    private string fCAB_DEM;      // / Cabe?alho das demonstra??es.
		
		       // / BLOCO J - Lista de RegistroJ100 (FILHO)
		       // / BLOCO J - Lista de RegistroJ150 (FILHO)
		       // / BLOCO J - Lista de RegistroJ200 (FILHO)
		       /*/ BLOCO J - Lista de RegistroJ210 (FILHO)*/ // / Create
		// / Destroy
		
		    public TDateTime DT_INI
		    {
		    	get
		    	{
		    		return fDT_INI;
		    	}
		    	set
		    	{
		    		fDT_INI = value;
		    	}
		    }
		    
		
		    public TDateTime DT_FIN
		    {
		    	get
		    	{
		    		return fDT_FIN;
		    	}
		    	set
		    	{
		    		fDT_FIN = value;
		    	}
		    }
		    
		
		    public Integer ID_DEM
		    {
		    	get
		    	{
		    		return fID_DEM;
		    	}
		    	set
		    	{
		    		fID_DEM = value;
		    	}
		    }
		    
		
		    public String CAB_DEM
		    {
		    	get
		    	{
		    		return fCAB_DEM;
		    	}
		    	set
		    	{
		    		fCAB_DEM = value;
		    	}
		    }
		    
		
		    // / Registros FILHOS
		    public TRegistroJ100List RegistroJ100
		    {
		    	get
		    	{
		    		return FRegistroJ100;
		    	}
		    	set
		    	{
		    		FRegistroJ100 = value;
		    	}
		    }
		    
		
		    public TRegistroJ150List RegistroJ150
		    {
		    	get
		    	{
		    		return FRegistroJ150;
		    	}
		    	set
		    	{
		    		FRegistroJ150 = value;
		    	}
		    }
		    
		
		    public TRegistroJ200List RegistroJ200
		    {
		    	get
		    	{
		    		return FRegistroJ200;
		    	}
		    	set
		    	{
		    		FRegistroJ200 = value;
		    	}
		    }
		    
		
		    public TRegistroJ210List RegistroJ210
		    {
		    	get
		    	{
		    		return FRegistroJ210;
		    	}
		    	set
		    	{
		    		FRegistroJ210 = value;
		    	}
		    }
		    
		
		//  TRegistroJ005 
		
		public  TRegistroJ005()
		{
		
		   FRegistroJ100 = new TRegistroJ100List();
		   FRegistroJ150 = new TRegistroJ150List();
		   FRegistroJ200 = new TRegistroJ200List();
		   FRegistroJ210 = new TRegistroJ210List();
		}
		
		
		
	}
	
	
	  // / Registro J005 - Lista
	
	  
	public class TRegistroJ005List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroJ005 read GetItem write SetItem;
		private TRegistroJ005 GetItem( int Index)
		{
		
		TRegistroJ005 Result;
		
		  Result = TRegistroJ005(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroJ005 New()
		{
		
		TRegistroJ005 Result;
		
		  Result = new TRegistroJ005();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroJ005 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro J100 ? BALAN?O PATRIMONIAL
	
	  
	public class TRegistroJ100 
	{
		
		
		    private string fCOD_AGL;        // / C?digo de aglutina??o das contas, atribu?do pelo empres?rio ou sociedade empres?ria.
		    private string fNIVEL_AGL;      // / N?vel do C?digo de aglutina??o (mesmo conceito do plano de contas - Registro I050).
		    private string fIND_GRP_BAL;    // / Indicador de grupo do balan?o: 1 - Ativo; 2 - Passivo e Patrim?nio L?quido;
		    private string fDESCR_COD_AGL;  // / Descri??o do C?digo de aglutina??o.
		    private decimal fVL_CTA;       // / Valor total do C?digo de aglutina??o no Balan?o Patrimonial no exerc?cio informado, ou de per?odo definido em norma espec?fica.
		    private string fIND_DC_BAL;     // / Indicador da situa??o do saldo informado no campo anterior: D - Devedor; C - Credor.
		    private decimal fVL_CTA_INI;   // / Valor inicial do c?digo de aglutina??o no Balan?o Patrimonial no exerc?cio informado, ou de per?odo definido em norma espec?fica.
		    private string fIND_DC_BAL_INI; // / Indicador da situa??o do saldo inicial informado no campo anterior: D - Devedor; C ? Credor.
		  
		    public String COD_AGL
		    {
		    	get
		    	{
		    		return fCOD_AGL;
		    	}
		    	set
		    	{
		    		fCOD_AGL = value;
		    	}
		    }
		    
		
		    public String NIVEL_AGL
		    {
		    	get
		    	{
		    		return fNIVEL_AGL;
		    	}
		    	set
		    	{
		    		fNIVEL_AGL = value;
		    	}
		    }
		    
		
		    public String IND_GRP_BAL
		    {
		    	get
		    	{
		    		return fIND_GRP_BAL;
		    	}
		    	set
		    	{
		    		fIND_GRP_BAL = value;
		    	}
		    }
		    
		
		    public String DESCR_COD_AGL
		    {
		    	get
		    	{
		    		return fDESCR_COD_AGL;
		    	}
		    	set
		    	{
		    		fDESCR_COD_AGL = value;
		    	}
		    }
		    
		
		    public Currency VL_CTA
		    {
		    	get
		    	{
		    		return fVL_CTA;
		    	}
		    	set
		    	{
		    		fVL_CTA = value;
		    	}
		    }
		    
		
		    public String IND_DC_BAL
		    {
		    	get
		    	{
		    		return fIND_DC_BAL;
		    	}
		    	set
		    	{
		    		fIND_DC_BAL = value;
		    	}
		    }
		    
		
		    public Currency VL_CTA_INI
		    {
		    	get
		    	{
		    		return fVL_CTA_INI;
		    	}
		    	set
		    	{
		    		fVL_CTA_INI = value;
		    	}
		    }
		    
		
		    public String IND_DC_BAL_INI
		    {
		    	get
		    	{
		    		return fIND_DC_BAL_INI;
		    	}
		    	set
		    	{
		    		fIND_DC_BAL_INI = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro J100 - Lista
	
	  
	public class TRegistroJ100List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroJ100 read GetItem write SetItem;
		
		//  TRegistroJ100List 
		
		private TRegistroJ100 GetItem( int Index)
		{
		
		TRegistroJ100 Result;
		
		  Result = TRegistroJ100(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public bool LocalizaRegistro( string pCOD_AGL)
		{
		 int intFor;
		bool Result;
		
		   Result = false;
		   for( intFor = 0;intFor <= this.Count - 1;intFor++)
		   {
		      if( this.Items[intFor].COD_AGL == pCOD_AGL )
		      {
		         Result = true;
		         break;
		      }
		   }
		return Result;
		}
		
		
		
		public TRegistroJ100 New()
		{
		
		TRegistroJ100 Result;
		
		  Result = new TRegistroJ100();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroJ100 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro J150 ? DEMONSTRA??O DO RESULTADO DO EXERC?CIO
	
	  
	public class TRegistroJ150 
	{
		
		
		    private string fCOD_AGL;        // / C?digo de aglutina??o das contas, atribu?do pelo empres?rio ou sociedade empres?ria.
		    private string fNIVEL_AGL;      // / N?vel do C?digo de aglutina??o (mesmo conceito do plano de contas - Registro I050).
		    private string fDESCR_COD_AGL;  // / Descri??o do C?digo de aglutina??o.
		    private decimal fVL_CTA;           // / Valor total do C?digo de aglutina??o na Demonstra??o do Resultado do Exerc?cio no per?odo informado.
		    private string fIND_VL;             // / Indicador da situa??o do valor informado no campo anterior: D - Despesa ou valor que represente parcela redutora do lucro;R - Receita ou valor que represente incremento do lucro;P - Subtotal ou total positivo;N - Subtotal ou total negativo.
		    private decimal fVL_CTA_ULT_DRE;   // / Valor inicial total constante na Demonstra??o do Resultado do Exerc?cio do ?ltimo per?odo informado.
		    private string fIND_VL_ULT_DRE;     // / Indicador da situa??o do valor informado no campo anterior: D - Despesa ou valor que represente parcela redutora do lucro;R - Receita ou valor que represente incremento do lucro;P - Subtotal ou total positivo;N - Subtotal ou total negativo.
		  
		    public String COD_AGL
		    {
		    	get
		    	{
		    		return fCOD_AGL;
		    	}
		    	set
		    	{
		    		fCOD_AGL = value;
		    	}
		    }
		    
		
		    public String NIVEL_AGL
		    {
		    	get
		    	{
		    		return fNIVEL_AGL;
		    	}
		    	set
		    	{
		    		fNIVEL_AGL = value;
		    	}
		    }
		    
		
		    public String DESCR_COD_AGL
		    {
		    	get
		    	{
		    		return fDESCR_COD_AGL;
		    	}
		    	set
		    	{
		    		fDESCR_COD_AGL = value;
		    	}
		    }
		    
		
		    public Currency VL_CTA
		    {
		    	get
		    	{
		    		return fVL_CTA;
		    	}
		    	set
		    	{
		    		fVL_CTA = value;
		    	}
		    }
		    
		
		    public String IND_VL
		    {
		    	get
		    	{
		    		return fIND_VL;
		    	}
		    	set
		    	{
		    		fIND_VL = value;
		    	}
		    }
		    
		
		    public Currency VL_CTA_ULT_DRE
		    {
		    	get
		    	{
		    		return fVL_CTA_ULT_DRE;
		    	}
		    	set
		    	{
		    		fVL_CTA_ULT_DRE = value;
		    	}
		    }
		        
		
		    public String IND_VL_ULT_DRE
		    {
		    	get
		    	{
		    		return fIND_VL_ULT_DRE;
		    	}
		    	set
		    	{
		    		fIND_VL_ULT_DRE = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro J150 - Lista
	
	  
	public class TRegistroJ150List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroJ150 read GetItem write SetItem;
		
		//  TRegistroJ150List 
		
		private TRegistroJ150 GetItem( int Index)
		{
		
		TRegistroJ150 Result;
		
		  Result = TRegistroJ150(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public bool LocalizaRegistro( string pCOD_AGL)
		{
		 int intFor;
		bool Result;
		
		   Result = false;
		   for( intFor = 0;intFor <= this.Count - 1;intFor++)
		   {
		      if( this.Items[intFor].COD_AGL == pCOD_AGL )
		      {
		         Result = true;
		         break;
		      }
		   }
		return Result;
		}
		
		
		
		public TRegistroJ150 New()
		{
		
		TRegistroJ150 Result;
		
		  Result = new TRegistroJ150();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroJ150 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro J200 - TABELA DE HIST?RICO DE FATOS CONT?BEIS QUE MODIFICAM A CONTA LUCROS ACUMULADOS OU A CONTA PREJU?ZOS ACUMULADOS OU TODO O PATRIM?NIO L?QUIDO
	
	  
	public class TRegistroJ200 
	{
		
		
		    private string fCOD_HIST_FAT;    // / C?digo do hist?rico do fato cont?bil.
		    private string fDESC_FAT;  // / Descri??o do fato cont?bil.
		  
		    public String COD_HIST_FAT
		    {
		    	get
		    	{
		    		return fCOD_HIST_FAT;
		    	}
		    	set
		    	{
		    		fCOD_HIST_FAT = value;
		    	}
		    }
		    
		
		    public String DESC_FAT
		    {
		    	get
		    	{
		    		return fDESC_FAT;
		    	}
		    	set
		    	{
		    		fDESC_FAT = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro J200 - Lista
	
	  
	public class TRegistroJ200List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroJ200 read GetItem write SetItem;
		
		//  TRegistroJ200List 
		
		private TRegistroJ200 GetItem( int Index)
		{
		
		TRegistroJ200 Result;
		
		  Result = TRegistroJ200(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public bool LocalizaRegistro( string pCOD_HIST_FAT)
		{
		 int intFor;
		bool Result;
		
		   Result = false;
		   for( intFor = 0;intFor <= this.Count - 1;intFor++)
		   {
		      if( this.Items[intFor].COD_HIST_FAT == pCOD_HIST_FAT )
		      {
		         Result = true;
		         break;
		      }
		   }
		return Result;
		}
		
		
		
		public TRegistroJ200 New()
		{
		
		TRegistroJ200 Result;
		
		  Result = new TRegistroJ200();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroJ200 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro J210 ? DLPA ? DEMONSTRA??O DE LUCROS OU PREJU?ZOS ACUMULADOS/DMPL ? DEMONSTRA??O DE MUTA??ES DO PATRIM?NIO L?QUIDO
	  
	public class TRegistroJ210 
	{
		
		
		    private string fIND_TIP;        // / Indicador do tipo de demonstra??o: 0 ? DLPA, 1 ? DMPL
		    private string fCOD_AGL;        // / C?digo de aglutina??o das contas, atribu?do pelo empres?rio ou sociedade empres?ria.
		    private string fDESCR_COD_AGL;  // / Descri??o do C?digo de aglutina??o.
		    private decimal fVL_CTA;       // / Saldo final do c?digo de aglutina??o na demonstra??o do per?odo informado.
		    private string fIND_DC_CTA;     // / Indicador da situa??o do saldo FINAL informado no campo anterior: D - Devedor; C - Credor.
		    private decimal fVL_CTA_INI;   // / Saldo inicial do c?digo de aglutina??o na demonstra??o do per?odo informado
		    private string fIND_DC_CTA_INI; // / Indicador da situa??o do saldo inicial informado no campo anterior: D ? Devedor C ? Credor
		    
		       /*/*//*/ BLOCO J - Lista de RegistroJ215 (FILHO)*/ // / Create
		// / Destroy
		
		
		    public String IND_TIP
		    {
		    	get
		    	{
		    		return fIND_TIP;
		    	}
		    	set
		    	{
		    		fIND_TIP = value;
		    	}
		    }
		    
		
		    public String COD_AGL
		    {
		    	get
		    	{
		    		return fCOD_AGL;
		    	}
		    	set
		    	{
		    		fCOD_AGL = value;
		    	}
		    }
		    
		
		    public String DESCR_COD_AGL
		    {
		    	get
		    	{
		    		return fDESCR_COD_AGL;
		    	}
		    	set
		    	{
		    		fDESCR_COD_AGL = value;
		    	}
		    }
		    
		
		    public Currency VL_CTA
		    {
		    	get
		    	{
		    		return fVL_CTA;
		    	}
		    	set
		    	{
		    		fVL_CTA = value;
		    	}
		    }
		    
		
		    public String IND_DC_CTA
		    {
		    	get
		    	{
		    		return fIND_DC_CTA;
		    	}
		    	set
		    	{
		    		fIND_DC_CTA = value;
		    	}
		    }
		    
		
		    public Currency VL_CTA_INI
		    {
		    	get
		    	{
		    		return fVL_CTA_INI;
		    	}
		    	set
		    	{
		    		fVL_CTA_INI = value;
		    	}
		    }
		    
		
		    public String IND_DC_CTA_INI
		    {
		    	get
		    	{
		    		return fIND_DC_CTA_INI;
		    	}
		    	set
		    	{
		    		fIND_DC_CTA_INI = value;
		    	}
		    }
		    
		
		    // / Registros FILHOS
		    public TRegistroJ215List RegistroJ215
		    {
		    	get
		    	{
		    		return FRegistroJ215;
		    	}
		    	set
		    	{
		    		FRegistroJ215 = value;
		    	}
		    }
		    
		
		//  TRegistroJ210 
		
		public  TRegistroJ210()
		{
		
		  FRegistroJ215 = new TRegistroJ215List();
		}
		
		
		
	}
	
	
	  // / Registro J210 - Lista
	  
	public class TRegistroJ210List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroJ210 read GetItem write SetItem;
		
		//  TRegistroJ210List 
		
		private TRegistroJ210 GetItem( int Index)
		{
		
		TRegistroJ210 Result;
		
		  Result = TRegistroJ210(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public bool LocalizaRegistro( string pCOD_AGL)
		{
		 int intFor;
		bool Result;
		
		   Result = false;
		   for( intFor = 0;intFor <= this.Count - 1;intFor++)
		   {
		      if( this.Items[intFor].COD_AGL == pCOD_AGL )
		      {
		         Result = true;
		         break;
		      }
		   }
		return Result;
		}
		
		
		
		public TRegistroJ210 New()
		{
		
		TRegistroJ210 Result;
		
		  Result = new TRegistroJ210();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroJ210 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro J215 - FATO CONT?BIL QUE ALTERA A CONTA LUCROS ACUMULADOS OU A CONTA PREJU?ZOS ACUMULADOS OU TODO O PATRIM?NIO L?QUIDO
	  
	public class TRegistroJ215 
	{
		
		
		    private string fCOD_HIST_FAT;    // / C?digo do hist?rico do fato cont?bil.
		    private decimal fVL_FAT_CONT;   // / Valor do fato cont?bil.
		    private string fIND_DC_FAT;     // / Indicador de situa??o do saldo informado no campo anterior
		  
		    public String COD_HIST_FAT
		    {
		    	get
		    	{
		    		return fCOD_HIST_FAT;
		    	}
		    	set
		    	{
		    		fCOD_HIST_FAT = value;
		    	}
		    }
		    
		
		    public Currency VL_FAT_CONT
		    {
		    	get
		    	{
		    		return fVL_FAT_CONT;
		    	}
		    	set
		    	{
		    		fVL_FAT_CONT = value;
		    	}
		    }
		    
		
		    public String IND_DC_FAT
		    {
		    	get
		    	{
		    		return fIND_DC_FAT;
		    	}
		    	set
		    	{
		    		fIND_DC_FAT = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro J215 - Lista
	
	  
	public class TRegistroJ215List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroJ215 read GetItem write SetItem;
		
		//  TRegistroJ215List 
		
		private TRegistroJ215 GetItem( int Index)
		{
		
		TRegistroJ215 Result;
		
		  Result = TRegistroJ215(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroJ215 New()
		{
		
		TRegistroJ215 Result;
		
		  Result = new TRegistroJ215();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroJ215 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
		public bool LocalizaRegistro( string pCOD_HIST_FAT)
		{
		 int intFor;
		bool Result;
		
		   Result = false;
		   for( intFor = 0;intFor <= this.Count - 1;intFor++)
		   {
		      if( this.Items[intFor].COD_HIST_FAT == pCOD_HIST_FAT )
		      {
		         Result = true;
		         break;
		      }
		   }
		return Result;
		}
		
		
		
	}
	
	
	
	  // / Rregistro J800 ? OUTRAS INFORMA??ES
	
	  
	public class TRegistroJ800 
	{
		
		
		    private string fARQ_RTF;  // / Seq??ncia de bytes que representem um ?nico arquivo no formato RTF (Rich Text Format).
		  
		    public String ARQ_RTF
		    {
		    	get
		    	{
		    		return fARQ_RTF;
		    	}
		    	set
		    	{
		    		fARQ_RTF = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro J800 - Lista
	
	  
	public class TRegistroJ800List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroJ800 read GetItem write SetItem;
		
		//  TRegistroJ800List 
		
		private TRegistroJ800 GetItem( int Index)
		{
		
		TRegistroJ800 Result;
		
		  Result = TRegistroJ800(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroJ800 New()
		{
		
		TRegistroJ800 Result;
		
		  Result = new TRegistroJ800();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroJ800 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Rregistro J900 ? TERMO DE ENCERRAMENTO
	
	  
	public class TRegistroJ900 
	{
		
		
		    private string fNUM_ORD;        // / N?mero de ordem do instrumento de escritura??o.
		    private string fNAT_LIVRO;      // / Natureza do livro; finalidade a que se destinou o instrumento.
		    private string fNOME;           // / Nome empresarial.
		    private int fQTD_LIN;           // / Quantidade total de linhas do arquivo digital.
		    private System.DateTime fDT_INI_ESCR;     // / Data de inicio da escritura??o.
		    private System.DateTime fDT_FIN_ESCR;     // / Data de t?rmino da escritura??o.
		  
		    public String NUM_ORD
		    {
		    	get
		    	{
		    		return fNUM_ORD;
		    	}
		    	set
		    	{
		    		fNUM_ORD = value;
		    	}
		    }
		    
		
		    public String NAT_LIVRO
		    {
		    	get
		    	{
		    		return fNAT_LIVRO;
		    	}
		    	set
		    	{
		    		fNAT_LIVRO = value;
		    	}
		    }
		    
		
		    public String NOME
		    {
		    	get
		    	{
		    		return fNOME;
		    	}
		    	set
		    	{
		    		fNOME = value;
		    	}
		    }
		    
		
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
		    
		
		    public TDateTime DT_INI_ESCR
		    {
		    	get
		    	{
		    		return fDT_INI_ESCR;
		    	}
		    	set
		    	{
		    		fDT_INI_ESCR = value;
		    	}
		    }
		    
		
		    public TDateTime DT_FIN_ESCR
		    {
		    	get
		    	{
		    		return fDT_FIN_ESCR;
		    	}
		    	set
		    	{
		    		fDT_FIN_ESCR = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Rregistro J930 ? IDENTIFICA??O DOS SIGNAT?RIOS DA ESCRITURA??O
	
	  
	public class TRegistroJ930 
	{
		
		
		    private string fIDENT_NOM;      // / Nome do signat?rio.
		    private string fIDENT_CPF;      // / CPF.
		    private string fIDENT_QUALIF;   // / Qualifica??o do assinante, conforme tabela do Departamento Nacional de Registro do Com?rcio - DNRC.
		    private string fCOD_ASSIN;      // / C?digo de qualifica??o do assinante, conforme tabela do Departamento Nacional de Registro do Com?rcio - DNRC.
		    private string fIND_CRC;        // / N?mero de inscri??o do contabilista no Conselho Regional de Contabilidade.
		    private string fEMAIL;          // / Email do signat?rio
		    private string fFONE;           // / Telefone do signat?rio.
		    private string fUF_CRC;         // / Indica??o da unidade da federa??o que expediu o CRC.
		    private string fNUM_SEQ_CRC;    // / N?mero sequencial no seguinte formato: UF/ano/n?mero
		    private System.DateTime fDT_CRC;      // / Data de validade do CRC do contador
		  
		    public String IDENT_NOM
		    {
		    	get
		    	{
		    		return fIDENT_NOM;
		    	}
		    	set
		    	{
		    		fIDENT_NOM = value;
		    	}
		    }
		    
		
		    public String IDENT_CPF
		    {
		    	get
		    	{
		    		return fIDENT_CPF;
		    	}
		    	set
		    	{
		    		fIDENT_CPF = value;
		    	}
		    }
		    
		
		    public String IDENT_QUALIF
		    {
		    	get
		    	{
		    		return fIDENT_QUALIF;
		    	}
		    	set
		    	{
		    		fIDENT_QUALIF = value;
		    	}
		    }
		    
		
		    public String COD_ASSIN
		    {
		    	get
		    	{
		    		return fCOD_ASSIN;
		    	}
		    	set
		    	{
		    		fCOD_ASSIN = value;
		    	}
		    }
		    
		
		    public String IND_CRC
		    {
		    	get
		    	{
		    		return fIND_CRC;
		    	}
		    	set
		    	{
		    		fIND_CRC = value;
		    	}
		    }
		    
		
		    public String EMAIL
		    {
		    	get
		    	{
		    		return fEMAIL;
		    	}
		    	set
		    	{
		    		fEMAIL = value;
		    	}
		    }
		    
		
		    public String FONE
		    {
		    	get
		    	{
		    		return fFONE;
		    	}
		    	set
		    	{
		    		fFONE = value;
		    	}
		    }
		    
		
		    public String UF_CRC
		    {
		    	get
		    	{
		    		return fUF_CRC;
		    	}
		    	set
		    	{
		    		fUF_CRC = value;
		    	}
		    }
		    
		
		    public String NUM_SEQ_CRC
		    {
		    	get
		    	{
		    		return fNUM_SEQ_CRC;
		    	}
		    	set
		    	{
		    		fNUM_SEQ_CRC = value;
		    	}
		    }
		    
		
		    public TDateTime DT_CRC
		    {
		    	get
		    	{
		    		return fDT_CRC;
		    	}
		    	set
		    	{
		    		fDT_CRC = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro J930 - Lista
	
	  
	public class TRegistroJ930List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroJ930 read GetItem write SetItem;
		
		//  TRegistroJ930List 
		
		private TRegistroJ930 GetItem( int Index)
		{
		
		TRegistroJ930 Result;
		
		  Result = TRegistroJ930(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroJ930 New()
		{
		
		TRegistroJ930 Result;
		
		  Result = new TRegistroJ930();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroJ930 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Rregistro J935 ? IDENTIFICA??O DOS AUDITORES INDEPENDENTES
	
	  
	public class TRegistroJ935 
	{
		
		
		    private string FCOD_CVM_AUDITOR; 
		    private string FNOME_AUDITOR; //  Nome do auditor independente.
		//  Registro do auditor independente na CVM.
		
		
		  
		    public String NOME_AUDITOR
		    {
		    	get
		    	{
		    		return FNOME_AUDITOR;
		    	}
		    	set
		    	{
		    		SetNOME_AUDITOR(value);
		    	}
		    }
		    
		
		    public String COD_CVM_AUDITOR
		    {
		    	get
		    	{
		    		return FCOD_CVM_AUDITOR;
		    	}
		    	set
		    	{
		    		SetCOD_CVM_AUDITOR(value);
		    	}
		    }
		    
		
		//  TRegistroJ935 
		
		private void SetCOD_CVM_AUDITOR( constString Value)
		{
		
		  fCOD_CVM_AUDITOR = Value;
		}
		
		
		
		private void SetNOME_AUDITOR( constString Value)
		{
		
		  fNOME_AUDITOR = Value;
		}
		
		
		
	}
	
	
	  // / Registro J935 - Lista
	
	  
	public class TRegistroJ935List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroJ935 read GetItem write SetItem;
		
		//  TRegistroJ935List 
		
		private TRegistroJ935 GetItem( int Index)
		{
		
		TRegistroJ935 Result;
		
		  Result = TRegistroJ935(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroJ935 New()
		{
		
		TRegistroJ935 Result;
		
		  Result = new TRegistroJ935();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroJ935 Value)
		{
		
		  Put(Index, Value);
		}
		
		
	}
	
	
	  // / Registro J990 - ENCERRAMENTO DO BLOCO J
	
	  
	public class TRegistroJ990 
	{
		
		
		    private int fQTD_LIN_J;    // / Quantidade total de linhas do Bloco J
		  
		    public Integer QTD_LIN_J
		    {
		    	get
		    	{
		    		return FQTD_LIN_J;
		    	}
		    	set
		    	{
		    		FQTD_LIN_J = value;
		    	}
		    }
		    
		
	}
	
	public static class ACBrECDBloco_J 
	{
		
		
		// / Rregistro J005 ? DEMONSTRA??ES CONT?BEIS
		
		
		public  ()
		{
		
		  FRegistroJ100.Dispose();
		  FRegistroJ150.Dispose();
		  FRegistroJ200.Dispose();
		  FRegistroJ210.Dispose();
		  base.Destroy;
		}
		
		
		
		public  ()
		{
		
		  FRegistroJ215.Dispose();
		  base.Destroy;
		}
		
		
		
	}
	
}
