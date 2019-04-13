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
	
	  // / Registro I001 - ABERTURA DO BLOCO I
	
	  
	public class TRegistroI001 : TOpenBlocos
	{
		
		
	}
	
	
	  
	public class TRegistroI010 
	{
		
		
		    private string fIND_ESC;    // / Indicador da forma de escritura??o cont?bil:G - Livro Di?rio (Completo sem escritura??o auxiliar);R - Livro Di?rio com Escritura??o Resumida (com escritura??o auxiliar);A - Livro Di?rio Auxiliar ao Di?rio com Escritura??o Resumida;B - Livro Balancetes Di?rios e Balan?os;Z - Raz?o Auxiliar (Livro Cont?bil Auxiliar conforme leiaute definido nos registros I500 a I555).
		    private string fCOD_VER_LC; // / C?digo da Vers?o do Leiaute Cont?bil (preencher com 1.00).
		  
		    public String IND_ESC
		    {
		    	get
		    	{
		    		return fIND_ESC;
		    	}
		    	set
		    	{
		    		fIND_ESC = value;
		    	}
		    }
		    
		
		    public String COD_VER_LC
		    {
		    	get
		    	{
		    		return fCOD_VER_LC;
		    	}
		    	set
		    	{
		    		fCOD_VER_LC = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I012 - LIVROS AUXILIARES AO DI?RIO
	
	  
	public class TRegistroI012 
	{
		
		
		    private string fNUM_ORD;        // / N?mero de ordem do instrumento associado.
		    private string fNAT_LIVR;       // / Natureza do livro associado; finalidade a que se destina o instrumento.
		    private string fTIPO;           // / Tipo de escritura??o do livro associado: 0 ? digital (inclu?dos no Sped) 1 ? outros.
		    private string fCOD_HASH_AUX;   // / C?digo Hash do arquivo correspondente ao livro auxiliar utilizado na assinatura digital.
		       /*/ BLOCO I - Lista de RegistroI051 (FILHO)*/ // / Create
		// / Destroy
		
		
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
		    
		
		    public String NAT_LIVR
		    {
		    	get
		    	{
		    		return fNAT_LIVR;
		    	}
		    	set
		    	{
		    		fNAT_LIVR = value;
		    	}
		    }
		    
		
		    public String TIPO
		    {
		    	get
		    	{
		    		return fTIPO;
		    	}
		    	set
		    	{
		    		fTIPO = value;
		    	}
		    }
		    
		
		    public String COD_HASH_AUX
		    {
		    	get
		    	{
		    		return fCOD_HASH_AUX;
		    	}
		    	set
		    	{
		    		fCOD_HASH_AUX = value;
		    	}
		    }
		    
		
		
		    // / Registros FILHOS
		    public TRegistroI015List RegistroI015
		    {
		    	get
		    	{
		    		return FRegistroI015;
		    	}
		    	set
		    	{
		    		FRegistroI015 = value;
		    	}
		    }
		    
		
		//  TRegistroI012 
		
		public  TRegistroI012()
		{
		
		  FRegistroI015 = new TRegistroI015List();
		}
		
		
		
	}
	
	
	  // / Registro I012 - Lista
	
	  
	public class TRegistroI012List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI012 read GetItem write SetItem;
		private TRegistroI012 GetItem( int Index)
		{
		
		TRegistroI012 Result;
		
		  Result = TRegistroI012(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI012 New()
		{
		
		TRegistroI012 Result;
		
		  Result = new TRegistroI012();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI012 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I015 - IDENTIFICA??O  DAS  CONTAS  DA  ESCRITURA??O  RESUMIDA  A
	  // /                 QUE SE REFERE A ESCRITURA??O AUXILIAR
	
	  
	public class TRegistroI015 
	{
		
		
		    private string fCOD_CTA_RES;    // / C?digo da(s) conta(s) anal?tica(s) do Livro Di?rio com Escritura??o Resumida (R) que recebe os lan?amentos globais.
		  
		    public String COD_CTA_RES
		    {
		    	get
		    	{
		    		return fCOD_CTA_RES;
		    	}
		    	set
		    	{
		    		fCOD_CTA_RES = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I015 - Lista
	
	  
	public class TRegistroI015List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI015 read GetItem write SetItem;
		
		//  TRegistroI015List 
		
		private TRegistroI015 GetItem( int Index)
		{
		
		TRegistroI015 Result;
		
		  Result = TRegistroI015(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI015 New()
		{
		
		TRegistroI015 Result;
		
		  Result = new TRegistroI015();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI015 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I020 - CAMPOS ADICIONAIS
	
	  
	public class TRegistroI020 
	{
		
		
		    private string fREG_COD;     // / C?digo do registro que recepciona o campo adicional.
		    private string fNUM_AD;      // / N?mero seq?encial do campo adicional.
		    private string fCAMPO;       // / Nome do campo adicional.
		    private string fDESCRICAO;   // / Descri??o do campo adicional.
		    private string fTIPO_DADO;   // / Indica??o do tipo de dado (N: num?rico; C: caractere).
		  
		    public String REG_COD
		    {
		    	get
		    	{
		    		return fREG_COD;
		    	}
		    	set
		    	{
		    		fREG_COD = value;
		    	}
		    }
		    
		
		    public String NUM_AD
		    {
		    	get
		    	{
		    		return fNUM_AD;
		    	}
		    	set
		    	{
		    		fNUM_AD = value;
		    	}
		    }
		    
		
		    public String CAMPO
		    {
		    	get
		    	{
		    		return fCAMPO;
		    	}
		    	set
		    	{
		    		fCAMPO = value;
		    	}
		    }
		    
		
		    public String DESCRICAO
		    {
		    	get
		    	{
		    		return fDESCRICAO;
		    	}
		    	set
		    	{
		    		fDESCRICAO = value;
		    	}
		    }
		    
		
		    public String TIPO_DADO
		    {
		    	get
		    	{
		    		return fTIPO_DADO;
		    	}
		    	set
		    	{
		    		fTIPO_DADO = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I020 - Lista
	
	  
	public class TRegistroI020List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI020 read GetItem write SetItem;
		
		//  TRegistroI020List 
		
		private TRegistroI020 GetItem( int Index)
		{
		
		TRegistroI020 Result;
		
		  Result = TRegistroI020(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI020 New()
		{
		
		TRegistroI020 Result;
		
		  Result = new TRegistroI020();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI020 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I030 - TERMO DE ABERTURA DO LIVRO
	
	  
	public class TRegistroI030 
	{
		
		
		    private string fNUM_ORD;     // / N?mero de ordem do instrumento de escritura??o.
		    private string fNAT_LIVR;    // / Natureza do livro; finalidade a que se destina o instrumento.
		    private int fQTD_LIN;        // / Quantidade total de linhas do arquivo digital.
		    private string fNOME;        // / Nome empresarial.
		    private string fNIRE;        // / N?mero de Identifica??o do Registro de Empresas da Junta Comercial.
		    private string fCNPJ;        // / N?mero de inscri??o no CNPJ .
		    private System.DateTime fDT_ARQ;       // / Data do arquivamento dos atos constitutivos.
		    private System.DateTime fDT_ARQ_CONV;  // / Data de arquivamento do ato de convers?o de sociedade simples em sociedade empres?ria.
		    private string fDESC_MUN;    // / Munic?pio.
		    private System.DateTime fDT_EX_SOCIAL;  // / Data de encerramento do exerc?cio social
		    private string fNOME_AUDITOR;     // / Nome do auditor independente
		    private string fCOD_CVM_AUDITOR;  // / Registro do auditor independente na CVM
		  
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
		    
		
		    public String NAT_LIVR
		    {
		    	get
		    	{
		    		return fNAT_LIVR;
		    	}
		    	set
		    	{
		    		fNAT_LIVR = value;
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
		    
		
		    public String NIRE
		    {
		    	get
		    	{
		    		return fNIRE;
		    	}
		    	set
		    	{
		    		fNIRE = value;
		    	}
		    }
		    
		
		    public String CNPJ
		    {
		    	get
		    	{
		    		return fCNPJ;
		    	}
		    	set
		    	{
		    		fCNPJ = value;
		    	}
		    }
		    
		
		    public TDateTime DT_ARQ
		    {
		    	get
		    	{
		    		return fDT_ARQ;
		    	}
		    	set
		    	{
		    		fDT_ARQ = value;
		    	}
		    }
		    
		
		    public TDateTime DT_ARQ_CONV
		    {
		    	get
		    	{
		    		return fDT_ARQ_CONV;
		    	}
		    	set
		    	{
		    		fDT_ARQ_CONV = value;
		    	}
		    }
		    
		
		    public String DESC_MUN
		    {
		    	get
		    	{
		    		return fDESC_MUN;
		    	}
		    	set
		    	{
		    		fDESC_MUN = value;
		    	}
		    }
		    
		
		    public TDateTime DT_EX_SOCIAL
		    {
		    	get
		    	{
		    		return fDT_EX_SOCIAL;
		    	}
		    	set
		    	{
		    		fDT_EX_SOCIAL = value;
		    	}
		    }
		    
		
		    public String NOME_AUDITOR
		    {
		    	get
		    	{
		    		return fNOME_AUDITOR;
		    	}
		    	set
		    	{
		    		fNOME_AUDITOR = value;
		    	}
		    }
		    
		
		    public string COD_CVM_AUDITOR
		    {
		    	get
		    	{
		    		return fCOD_CVM_AUDITOR;
		    	}
		    	set
		    	{
		    		fCOD_CVM_AUDITOR = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I050 - PLANO DE CONTAS
	
	  
	public class TRegistroI050 
	{
		
		
		    private System.DateTime fDT_ALT;       // / Data da inclus?o/altera??o.
		    private string fCOD_NAT;     // / C?digo da natureza da conta/grupo de contas, conforme tabela publicada pelo Sped.
		    private string fIND_CTA;     // / Indicador do tipo de conta: S - Sint?tica (grupo de contas);A - Anal?tica (conta).
		    private string fNIVEL;       // / N?vel da conta anal?tica/grupo de contas.
		    private string fCOD_CTA;     // / C?digo da conta anal?tica/grupo de contas.
		    private string fCOD_CTA_SUP; // / C?digo da conta sint?tica /grupo de contas de n?vel imediatamente superior.
		    private string fCTA;         // / Nome da conta anal?tica/grupo de contas.
		
		       // / BLOCO I - Lista de RegistroI051 (FILHO)
		       // / BLOCO I - Lista de RegistroI052 (FILHO)
		       /*/ BLOCO I - Lista de RegistroI053 (FILHO)    ///*/ // / Create
		// / Destroy
		
		
		    public TDateTime DT_ALT
		    {
		    	get
		    	{
		    		return fDT_ALT;
		    	}
		    	set
		    	{
		    		fDT_ALT = value;
		    	}
		    }
		    
		
		    public String COD_NAT
		    {
		    	get
		    	{
		    		return fCOD_NAT;
		    	}
		    	set
		    	{
		    		fCOD_NAT = value;
		    	}
		    }
		    
		
		    public String IND_CTA
		    {
		    	get
		    	{
		    		return fIND_CTA;
		    	}
		    	set
		    	{
		    		fIND_CTA = value;
		    	}
		    }
		    
		
		    public String NIVEL
		    {
		    	get
		    	{
		    		return fNIVEL;
		    	}
		    	set
		    	{
		    		fNIVEL = value;
		    	}
		    }
		    
		
		    public String COD_CTA
		    {
		    	get
		    	{
		    		return fCOD_CTA;
		    	}
		    	set
		    	{
		    		fCOD_CTA = value;
		    	}
		    }
		    
		
		    public String COD_CTA_SUP
		    {
		    	get
		    	{
		    		return fCOD_CTA_SUP;
		    	}
		    	set
		    	{
		    		fCOD_CTA_SUP = value;
		    	}
		    }
		    
		
		    public String CTA
		    {
		    	get
		    	{
		    		return fCTA;
		    	}
		    	set
		    	{
		    		fCTA = value;
		    	}
		    }
		    
		
		
		    // / Registros FILHOS
		    public TRegistroI051List RegistroI051
		    {
		    	get
		    	{
		    		return FRegistroI051;
		    	}
		    	set
		    	{
		    		FRegistroI051 = value;
		    	}
		    }
		    
		
		    public TRegistroI052List RegistroI052
		    {
		    	get
		    	{
		    		return FRegistroI052;
		    	}
		    	set
		    	{
		    		FRegistroI052 = value;
		    	}
		    }
		    
		
		    public TRegistroI053List RegistroI053
		    {
		    	get
		    	{
		    		return FRegistroI053;
		    	}
		    	set
		    	{
		    		FRegistroI053 = value;
		    	}
		    }
		    
		
		public  TRegistroI050()
		{
		
		   FRegistroI051 = new TRegistroI051List();
		   FRegistroI052 = new TRegistroI052List();
		   FRegistroI053 = new TRegistroI053List();
		}
		
		
		
	}
	
	
	  // / Registro I050 - Lista
	
	  
	public class TRegistroI050List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI050 read GetItem write SetItem;
		
		//  TRegistroI050List 
		
		private TRegistroI050 GetItem( int Index)
		{
		
		TRegistroI050 Result;
		
		  Result = TRegistroI050(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI050 New()
		{
		
		TRegistroI050 Result;
		
		  Result = new TRegistroI050();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI050 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I051 - PLANO DE CONTAS REFERENCIAL
	
	  
	public class TRegistroI051 
	{
		
		
		    private string fCOD_PLAN_REF;    // / C?digo da institui??o respons?vel pela manuten??o do plano de contas referencial.
		    private string fCOD_CCUS;       // / C?digo do centro de custo.
		    private string fCOD_CTA_REF;    // / C?digo da conta de acordo com o plano de contas referencial, conforme tabela publicada pelos ?rg?os indicados no campo 02- COD_ENT_REF.
		  
		    // property COD_ENT_REF: String read fCOD_ENT_REF write fCOD_ENT_REF;
		    public String COD_PLAN_REF
		    {
		    	get
		    	{
		    		return fCOD_PLAN_REF;
		    	}
		    	set
		    	{
		    		fCOD_PLAN_REF = value;
		    	}
		    }
		    
		
		    public String COD_CCUS
		    {
		    	get
		    	{
		    		return fCOD_CCUS;
		    	}
		    	set
		    	{
		    		fCOD_CCUS = value;
		    	}
		    }
		    
		
		    public String COD_CTA_REF
		    {
		    	get
		    	{
		    		return fCOD_CTA_REF;
		    	}
		    	set
		    	{
		    		fCOD_CTA_REF = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I051 - Lista
	
	  
	public class TRegistroI051List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI051 read GetItem write SetItem;
		
		//  TRegistroI051List 
		
		private TRegistroI051 GetItem( int Index)
		{
		
		TRegistroI051 Result;
		
		  Result = TRegistroI051(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI051 New()
		{
		
		TRegistroI051 Result;
		
		  Result = new TRegistroI051();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI051 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I052 - INDICA??O DOS C?DIGOS DE AGLUTINA??O
	
	  
	public class TRegistroI052 
	{
		
		
		    private string fCOD_CCUS; // / C?digo do centro de custo.
		    private string fCOD_AGL;  // / C?digo de aglutina??o utilizado no Balan?o Patrimonial e na Demonstra??o de Resultado do Exerc?cio no Bloco J (somente para as contas anal?ticas).
		  
		    public String COD_CCUS
		    {
		    	get
		    	{
		    		return fCOD_CCUS;
		    	}
		    	set
		    	{
		    		fCOD_CCUS = value;
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
		    
		
	}
	
	
	  // / Registro I052 - Lista
	
	  
	public class TRegistroI052List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI052 read GetItem write SetItem;
		
		//  TRegistroI052List 
		
		private TRegistroI052 GetItem( int Index)
		{
		
		TRegistroI052 Result;
		
		  Result = TRegistroI052(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI052 New()
		{
		
		TRegistroI052 Result;
		
		  Result = new TRegistroI052();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI052 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I053 - SUBCONTAS CORRELATAS
	
	  
	public class TRegistroI053 
	{
		
		
		    private string fCOD_CNT_CORR; // / C?digo de identifica??o do grupo de conta-subconta(a)
		    private string fNAT_SUB_CNT;  // / C?digo da subconta correlata (deve estar no plano de contas e s? pode estar relacionada a um ?nico grupo)
		    private string fCOD_IDT;      // / Natureza da subconta correlata (conforme tabela de natureza da subconta publicada no Sped )
		  
		    public String COD_IDT
		    {
		    	get
		    	{
		    		return fCOD_IDT;
		    	}
		    	set
		    	{
		    		fCOD_CNT_CORR = value;
		    	}
		    }
		    
		
		    public String COD_CNT_CORR
		    {
		    	get
		    	{
		    		return fCOD_CNT_CORR;
		    	}
		    	set
		    	{
		    		fCOD_CNT_CORR = value;
		    	}
		    }
		    
		
		    public String NAT_SUB_CNT 
		    {
		    	get
		    	{
		    		return fNAT_SUB_CNT;
		    	}
		    	set
		    	{
		    		fNAT_SUB_CNT = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I053 - Lista
	
	  
	public class TRegistroI053List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI053 read GetItem write SetItem;
		
		
		//  TRegistroI053List 
		
		private TRegistroI053 GetItem( int Index)
		{
		
		TRegistroI053 Result;
		
		  Result = TRegistroI053(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI053 New()
		{
		
		TRegistroI053 Result;
		
		  Result = new TRegistroI053();
		  
		  AppendText(Result);      
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI053 Value)
		{
		
		  Put(Index, Value);
		}
		
		
	}
	
	
	  // / Registro I075 - TABELA DE HIST?RICO PADRONIZADO
	
	  
	public class TRegistroI075 
	{
		
		
		    private string fCOD_HIST;    // / C?digo do hist?rico padronizado.
		    private string fDESCR_HIST;  // / Descri??o do hist?rico padronizado.
		  
		    public String COD_HIST
		    {
		    	get
		    	{
		    		return fCOD_HIST;
		    	}
		    	set
		    	{
		    		fCOD_HIST = value;
		    	}
		    }
		    
		
		    public String DESCR_HIST
		    {
		    	get
		    	{
		    		return fDESCR_HIST;
		    	}
		    	set
		    	{
		    		fDESCR_HIST = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I075 - Lista
	
	  
	public class TRegistroI075List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI075 read GetItem write SetItem;
		
		//  TRegistroI075List 
		
		private TRegistroI075 GetItem( int Index)
		{
		
		TRegistroI075 Result;
		
		  Result = TRegistroI075(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI075 New()
		{
		
		TRegistroI075 Result;
		
		  Result = new TRegistroI075();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI075 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I100 - CENTRO DE CUSTOS
	
	  
	public class TRegistroI100 
	{
		
		
		    private System.DateTime fDT_ALT;       // / Data da inclus?o/altera??o.
		    private string fCOD_CCUS;    // / C?digo do centro de custos.
		    private string fCCUS;        // / Nome do centro de custos.
		  
		    public TdateTime DT_ALT
		    {
		    	get
		    	{
		    		return fDT_ALT;
		    	}
		    	set
		    	{
		    		fDT_ALT = value;
		    	}
		    }
		    
		
		    public String COD_CCUS
		    {
		    	get
		    	{
		    		return fCOD_CCUS;
		    	}
		    	set
		    	{
		    		fCOD_CCUS = value;
		    	}
		    }
		    
		
		    public String CCUS
		    {
		    	get
		    	{
		    		return fCCUS;
		    	}
		    	set
		    	{
		    		fCCUS = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I100 - Lista
	
	  
	public class TRegistroI100List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI100 read GetItem write SetItem;
		
		//  TRegistroI100List 
		
		private TRegistroI100 GetItem( int Index)
		{
		
		TRegistroI100 Result;
		
		  Result = TRegistroI100(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI100 New()
		{
		
		TRegistroI100 Result;
		
		  Result = new TRegistroI100();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI100 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I150 - SALDOS PERI?DICOS ? IDENTIFICA??O DO PER?ODO
	
	  
	public class TRegistroI150 
	{
		
		
		    private System.DateTime fDT_INI; // / Data de in?cio do per?odo.
		    private System.DateTime fDT_FIN; // / Data de fim do per?odo.
		
		       // / BLOCO I - Lista de RegistroI151 (FILHO)
		       /*/ BLOCO I - Lista de RegistroI155 (FILHO)*/ // / Create
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
		    
		
		    // / Registros FILHOS
		    public TRegistroI151List RegistroI151
		    {
		    	get
		    	{
		    		return FRegistroI151;
		    	}
		    	set
		    	{
		    		FRegistroI151 = value;
		    	}
		    }
		    
		
		    public TRegistroI155List RegistroI155
		    {
		    	get
		    	{
		    		return FRegistroI155;
		    	}
		    	set
		    	{
		    		FRegistroI155 = value;
		    	}
		    }
		    
		
		public  TRegistroI150()
		{
		
		   FRegistroI151 = new TRegistroI151List();
		   FRegistroI155 = new TRegistroI155List();
		}
		
		
		
	}
	
	
	  // / Registro I150 - Lista
	
	  
	public class TRegistroI150List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI150 read GetItem write SetItem;
		
		//  TRegistroI150List 
		
		private TRegistroI150 GetItem( int Index)
		{
		
		TRegistroI150 Result;
		
		  Result = TRegistroI150(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI150 New()
		{
		
		TRegistroI150 Result;
		
		  Result = new TRegistroI150();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI150 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I151 - ASSINATURA  DIGITAL  DOS  ARQUIVOS  QUE  CONT?M  AS
	  // /                 FICHAS DE LAN?AMENTO UTILIZADOS NO PER?ODO (IN RFB 926/09)
	
	  
	public class TRegistroI151 
	{
		
		
		    private string fASSIM_DIG; // / Transcri??o da assinatura digital utilizada no arquivo contendo o conjunto de fichas de lan?amento
		  
		    public String ASSIM_DIG
		    {
		    	get
		    	{
		    		return fASSIM_DIG;
		    	}
		    	set
		    	{
		    		fASSIM_DIG = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I151 - Lista
	
	  
	public class TRegistroI151List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI151 read GetItem write SetItem;
		
		//  TRegistroI151List 
		
		private TRegistroI151 GetItem( int Index)
		{
		
		TRegistroI151 Result;
		
		  Result = TRegistroI151(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI151 New()
		{
		
		TRegistroI151 Result;
		
		  Result = new TRegistroI151();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI151 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I155 - DETALHE DOS SALDOS PERI?DICOS
	
	  
	public class TRegistroI155 
	{
		
		
		    private string fCOD_CTA;     // / C?digo da conta anal?tica.
		    private string fCOD_CCUS;    // / C?digo do centro de custos.
		    private decimal fVL_SLD_INI;    // / Valor do saldo inicial do per?odo.
		    private string fIND_DC_INI;  // / Indicador da situa??o do saldo inicial:D - Devedor;C - Credor.
		    private decimal fVL_DEB;        // / Valor total dos d?bitos no per?odo.
		    private decimal fVL_CRED;       // / Valor total dos cr?ditos no per?odo.
		    private decimal fVL_SLD_FIN;    // / Valor do saldo final do per?odo.
		    private string fIND_DC_FIN;  // / Indicador da situa??o do saldo final: D - Devedor; C - Credor.
		  
		    public String COD_CTA
		    {
		    	get
		    	{
		    		return fCOD_CTA;
		    	}
		    	set
		    	{
		    		fCOD_CTA = value;
		    	}
		    }
		    
		
		    public String COD_CCUS
		    {
		    	get
		    	{
		    		return fCOD_CCUS;
		    	}
		    	set
		    	{
		    		fCOD_CCUS = value;
		    	}
		    }
		    
		
		    public Currency VL_SLD_INI
		    {
		    	get
		    	{
		    		return fVL_SLD_INI;
		    	}
		    	set
		    	{
		    		fVL_SLD_INI = value;
		    	}
		    }
		    
		
		    public String IND_DC_INI
		    {
		    	get
		    	{
		    		return fIND_DC_INI;
		    	}
		    	set
		    	{
		    		fIND_DC_INI = value;
		    	}
		    }
		    
		
		    public Currency VL_DEB
		    {
		    	get
		    	{
		    		return fVL_DEB;
		    	}
		    	set
		    	{
		    		fVL_DEB = value;
		    	}
		    }
		    
		
		    public Currency VL_CRED
		    {
		    	get
		    	{
		    		return fVL_CRED;
		    	}
		    	set
		    	{
		    		fVL_CRED = value;
		    	}
		    }
		    
		
		    public Currency VL_SLD_FIN
		    {
		    	get
		    	{
		    		return fVL_SLD_FIN;
		    	}
		    	set
		    	{
		    		fVL_SLD_FIN = value;
		    	}
		    }
		    
		
		    public String IND_DC_FIN
		    {
		    	get
		    	{
		    		return fIND_DC_FIN;
		    	}
		    	set
		    	{
		    		fIND_DC_FIN = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I155 - Lista
	
	  
	public class TRegistroI155List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI155 read GetItem write SetItem;
		
		//  TRegistroI155List 
		
		private TRegistroI155 GetItem( int Index)
		{
		
		TRegistroI155 Result;
		
		  Result = TRegistroI155(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI155 New()
		{
		
		TRegistroI155 Result;
		
		  Result = new TRegistroI155();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI155 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  //  Registro I200 - Lan?amentos Cont?beis
	
	  
	public class TRegistroI200 
	{
		
		
		    private string fNUM_LCTO;        //  N?mero de identifica??o do lan?amento
		    private System.DateTime fDT_LCTO;         //  Data do lan?amento
		    private decimal fVL_LCTO;           //  Valor do Lan?amento
		    private string fIND_LCTO;        //  Indicador do tipo do lan?amento
		
		      /*/ BLOCO I - Lista de RegistroI250 (FILHO)*/ // / Create
		// / Destroy
		
		
		    public String NUM_LCTO
		    {
		    	get
		    	{
		    		return fNUM_LCTO;
		    	}
		    	set
		    	{
		    		fNUM_LCTO = value;
		    	}
		    }
		    
		
		    public TDateTime DT_LCTO
		    {
		    	get
		    	{
		    		return fDT_LCTO;
		    	}
		    	set
		    	{
		    		fDT_LCTO = value;
		    	}
		    }
		    
		
		    public Currency VL_LCTO
		    {
		    	get
		    	{
		    		return fVL_LCTO;
		    	}
		    	set
		    	{
		    		fVL_LCTO = value;
		    	}
		    }
		    
		
		    public String IND_LCTO
		    {
		    	get
		    	{
		    		return fIND_LCTO;
		    	}
		    	set
		    	{
		    		fIND_LCTO = value;
		    	}
		    }
		    
		
		    public TRegistroI250List RegistroI250
		    {
		    	get
		    	{
		    		return fRegistroI250;
		    	}
		    	set
		    	{
		    		fRegistroI250 = value;
		    	}
		    }
		    
		
		//  TRegistroI200
		
		public  TRegistroI200()
		{
		
		  fRegistroI250 = new TRegistroI250List();
		}
		
		
		
	}
	
	
	  
	public class TRegistroI200List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI200 read GetItem write SetItem;
		
		//  TRegistroI200List
		
		private TRegistroI200 GetItem( int Index)
		{
		
		TRegistroI200 Result;
		
		  Result = TRegistroI200(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI200 New()
		{
		
		TRegistroI200 Result;
		
		  Result = new TRegistroI200();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, TRegistroI200 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  //  Registro I250 - Partidas do Lan?amentos
	
	  
	public class TRegistroI250 
	{
		
		
		    private string fCOD_CTA; 
		    private string fCOD_CCUS; 
		    private decimal fVL_DC; 
		    private string fIND_DC; 
		    private string fNUM_ARQ; 
		    private string fCOD_HIST_PAD; 
		    private string fHIST; 
		    private string fCOD_PART; 
		  
		    public String COD_CTA
		    {
		    	get
		    	{
		    		return fCOD_CTA;
		    	}
		    	set
		    	{
		    		fCOD_CTA = value;
		    	}
		    }
		    
		
		    public String COD_CCUS
		    {
		    	get
		    	{
		    		return fCOD_CCUS;
		    	}
		    	set
		    	{
		    		fCOD_CCUS = value;
		    	}
		    }
		    
		
		    public Currency VL_DC
		    {
		    	get
		    	{
		    		return fVL_DC;
		    	}
		    	set
		    	{
		    		fVL_DC = value;
		    	}
		    }
		    
		
		    public String IND_DC
		    {
		    	get
		    	{
		    		return fIND_DC;
		    	}
		    	set
		    	{
		    		fIND_DC = value;
		    	}
		    }
		    
		
		    public String  NUM_ARQ
		    {
		    	get
		    	{
		    		return fNUM_ARQ;
		    	}
		    	set
		    	{
		    		fNUM_ARQ = value;
		    	}
		    }
		    
		
		    public String  COD_HIST_PAD
		    {
		    	get
		    	{
		    		return fCOD_HIST_PAD;
		    	}
		    	set
		    	{
		    		fCOD_HIST_PAD = value;
		    	}
		    }
		    
		
		    public String HIST
		    {
		    	get
		    	{
		    		return fHIST;
		    	}
		    	set
		    	{
		    		fHIST = value;
		    	}
		    }
		    
		
		    public String COD_PART
		    {
		    	get
		    	{
		    		return fCOD_PART;
		    	}
		    	set
		    	{
		    		fCOD_PART = value;
		    	}
		    }
		    
		
	}
	
	
	  //  Registro I250 - lista
	
	  
	public class TRegistroI250List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI250 read GetItem write SetItem;
		
		//  TRegistroI250List
		
		private TRegistroI250 GetItem( int index)
		{
		
		TRegistroI250 Result;
		
		  Result = TRegistroI250( inherited Items[index]);
		return Result;
		}
		
		
		
		public TRegistroI250 New()
		{
		
		TRegistroI250 Result;
		
		   Result = new TRegistroI250();
		   
		   AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, TRegistroI250 Value)
		{
		
		   Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I300 - BALANCETES DI?RIOS ? IDENTIFICA??O DA DATA
	
	  
	public class TRegistroI300 
	{
		
		
		    private System.DateTime fDT_BCTE; // / Data do Balancete.
		
		       /*/ BLOCO I - Lista de RegistroI310 (FILHO)*/ // / Create
		// / Destroy
		
		
		    public TDateTime DT_BCTE
		    {
		    	get
		    	{
		    		return fDT_BCTE;
		    	}
		    	set
		    	{
		    		fDT_BCTE = value;
		    	}
		    }
		    
		
		    // / Registros FILHOS
		    public TRegistroI310List RegistroI310
		    {
		    	get
		    	{
		    		return FRegistroI310;
		    	}
		    	set
		    	{
		    		FRegistroI310 = value;
		    	}
		    }
		    
		
		
		public  TRegistroI300()
		{
		
		   FRegistroI310 = new TRegistroI310List();
		}
		
		
		
	}
	
	
	  // / Registro I300 - Lista
	
	  
	public class TRegistroI300List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI300 read GetItem write SetItem;
		
		//  TRegistroI300List 
		
		private TRegistroI300 GetItem( int Index)
		{
		
		TRegistroI300 Result;
		
		  Result = TRegistroI300(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI300 New()
		{
		
		TRegistroI300 Result;
		
		  Result = new TRegistroI300();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI300 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I310 - DETALHE DO BALANCETE DI?RIO
	
	  
	public class TRegistroI310 
	{
		
		
		    private string fCOD_CTA;     // / C?digo da conta anal?tica debitada/creditada.
		    private string fCOD_CCUS;    // / C?digo do centro de custos.
		    private decimal fVAL_DEBD;    // / Total dos d?bitos do dia.
		    private decimal fVAL_CRED;    // / Total dos cr?ditos do dia.
		  
		    public String COD_CTA
		    {
		    	get
		    	{
		    		return fCOD_CTA;
		    	}
		    	set
		    	{
		    		fCOD_CTA = value;
		    	}
		    }
		    
		
		    public String COD_CCUS
		    {
		    	get
		    	{
		    		return fCOD_CCUS;
		    	}
		    	set
		    	{
		    		fCOD_CCUS = value;
		    	}
		    }
		    
		
		    public Currency VAL_DEBD
		    {
		    	get
		    	{
		    		return fVAL_DEBD;
		    	}
		    	set
		    	{
		    		fVAL_DEBD = value;
		    	}
		    }
		    
		
		    public Currency VAL_CRED
		    {
		    	get
		    	{
		    		return fVAL_CRED;
		    	}
		    	set
		    	{
		    		fVAL_CRED = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I310 - Lista
	
	  
	public class TRegistroI310List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI310 read GetItem write SetItem;
		
		//  TRegistroI310List 
		
		private TRegistroI310 GetItem( int Index)
		{
		
		TRegistroI310 Result;
		
		  Result = TRegistroI310(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI310 New()
		{
		
		TRegistroI310 Result;
		
		  Result = new TRegistroI310();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI310 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I350 - SALDO DAS CONTAS DE RESULTADO ANTES DO ENCERRAMENTO ? IDENTIFICA??O DA DATA
	
	  
	public class TRegistroI350 
	{
		
		
		    private System.DateTime fDT_RES; // / Data da apura??o do resultado.
		
		       /*/ BLOCO I - Lista de RegistroI355 (FILHO)*/ // / Create
		// / Destroy
		
		
		    public TDateTime DT_RES
		    {
		    	get
		    	{
		    		return fDT_RES;
		    	}
		    	set
		    	{
		    		fDT_RES = value;
		    	}
		    }
		    
		
		    // / Registros FILHOS
		    public TRegistroI355List RegistroI355
		    {
		    	get
		    	{
		    		return FRegistroI355;
		    	}
		    	set
		    	{
		    		FRegistroI355 = value;
		    	}
		    }
		    
		
		public  TRegistroI350()
		{
		
		   FRegistroI355 = new TRegistroI355List();
		}
		
		
		
	}
	
	
	  // / Registro I350 - Lista
	
	  
	public class TRegistroI350List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI350 read GetItem write SetItem;
		
		//  TRegistroI350List 
		
		private TRegistroI350 GetItem( int Index)
		{
		
		TRegistroI350 Result;
		
		  Result = TRegistroI350(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI350 New()
		{
		
		TRegistroI350 Result;
		
		  Result = new TRegistroI350();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI350 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I355 - DETALHE DOS SALDOS DAS CONTAS DE RESULTADO ANTES DO ENCERRAMENTO
	
	  
	public class TRegistroI355 
	{
		
		
		    private string fCOD_CTA;     // / C?digo da conta anal?tica de resultado.
		    private string fCOD_CCUS;    // / C?digo do centro de custos.
		    private decimal fVL_CTA;    // / Valor do saldo final antes do lan?amento de encerramento.
		    private string fIND_DC;  // / Indicador da situa??o do saldo final: D - Devedor; C - Credor.
		
		  
		    public String COD_CTA
		    {
		    	get
		    	{
		    		return fCOD_CTA;
		    	}
		    	set
		    	{
		    		fCOD_CTA = value;
		    	}
		    }
		    
		
		    public String COD_CCUS
		    {
		    	get
		    	{
		    		return fCOD_CCUS;
		    	}
		    	set
		    	{
		    		fCOD_CCUS = value;
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
		    
		
		    public String IND_DC
		    {
		    	get
		    	{
		    		return fIND_DC;
		    	}
		    	set
		    	{
		    		fIND_DC = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I355 - Lista
	
	  
	public class TRegistroI355List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI355 read GetItem write SetItem;
		
		//  TRegistroI355List 
		
		private TRegistroI355 GetItem( int Index)
		{
		
		TRegistroI355 Result;
		
		  Result = TRegistroI355(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI355 New()
		{
		
		TRegistroI355 Result;
		
		  Result = new TRegistroI355();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI355 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I500 - PAR?METROS DE IMPRESS?O E VISUALIZA??O DO LIVRO RAZ?O AUXILIAR COM LEIAUTE PARAMETRIZ?VEL
	
	  
	public class TRegistroI500 
	{
		
		
		    private int fTAM_FONTE;        // / Tamanho da fonte.
		  
		    public Integer TAM_FONTE
		    {
		    	get
		    	{
		    		return fTAM_FONTE;
		    	}
		    	set
		    	{
		    		fTAM_FONTE = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I500 - Lista
	
	  
	public class TRegistroI500List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI500 read GetItem write SetItem;
		
		//  TRegistroI500List 
		
		private TRegistroI500 GetItem( int Index)
		{
		
		TRegistroI500 Result;
		
		  Result = TRegistroI500(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI500 New()
		{
		
		TRegistroI500 Result;
		
		  Result = new TRegistroI500();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI500 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I510 - DEFINI??O DE CAMPOS DO LIVRO RAZ?O AUXILIAR COM LEIAUTE PARAMETRIZ?VEL
	
	  
	public class TRegistroI510 
	{
		
		
		    private string fNM_CAMPO;      // /Nome do campo, sem espa?os em branco ou caractere especial.
		    private string fDESC_CAMPO;    // /Descri??o do campo que ser? utilizado na visualiza??o do Livro Auxiliar.
		    private string fTIPO_CAMPO;    // /Tipo do campo: "N" - num?rico; "C" - caractere.
		    private int fTAM_CAMPO;        // /Tamanho do campo.
		    private int fDEC_CAMPO;         // /Quantidade de casas decimais para campos tipo "N".
		    private int fCOL_CAMPO;        // /Largura da coluna no relat?rio (em quantidade de caracteres).
		  
		    public String NM_CAMPO
		    {
		    	get
		    	{
		    		return fNM_CAMPO;
		    	}
		    	set
		    	{
		    		fNM_CAMPO = value;
		    	}
		    }
		    
		
		    public String DESC_CAMPO
		    {
		    	get
		    	{
		    		return fDESC_CAMPO;
		    	}
		    	set
		    	{
		    		fDESC_CAMPO = value;
		    	}
		    }
		    
		
		    public String TIPO_CAMPO
		    {
		    	get
		    	{
		    		return fTIPO_CAMPO;
		    	}
		    	set
		    	{
		    		fTIPO_CAMPO = value;
		    	}
		    }
		    
		
		    public Integer TAM_CAMPO
		    {
		    	get
		    	{
		    		return fTAM_CAMPO;
		    	}
		    	set
		    	{
		    		fTAM_CAMPO = value;
		    	}
		    }
		    
		
		    public Integer DEC_CAMPO
		    {
		    	get
		    	{
		    		return fDEC_CAMPO;
		    	}
		    	set
		    	{
		    		fDEC_CAMPO = value;
		    	}
		    }
		    
		
		    public Integer COL_CAMPO
		    {
		    	get
		    	{
		    		return fCOL_CAMPO;
		    	}
		    	set
		    	{
		    		fCOL_CAMPO = value;
		    	}
		    }
		    
		
	}
	
	
	  // / Registro I510 - Lista
	
	  
	public class TRegistroI510List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI510 read GetItem write SetItem;
		
		//  TRegistroI510List 
		
		private TRegistroI510 GetItem( int Index)
		{
		
		TRegistroI510 Result;
		
		  Result = TRegistroI510(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI510 New()
		{
		
		TRegistroI510 Result;
		
		  Result = new TRegistroI510();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, constTRegistroI510 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	  //  Registro I550 - DETALHES DO LIVRO RAZ?O AUXILIAR COM LEIAUTE PARAMETRIZ?VEL
	
	  
	public class TRegistroI550 
	{
		
		
		    private string fRZ_CONT;        //  Conte?do dos campos mencionados no Registro I510.
		
		      /*/ BLOCO I - Lista de RegistroI555 (FILHO)*/ // / Create
		// / Destroy
		
		
		    public String RZ_CONT
		    {
		    	get
		    	{
		    		return fRZ_CONT;
		    	}
		    	set
		    	{
		    		fRZ_CONT = value;
		    	}
		    }
		    
		
		
		    public TRegistroI555List RegistroI555
		    {
		    	get
		    	{
		    		return fRegistroI555;
		    	}
		    	set
		    	{
		    		fRegistroI555 = value;
		    	}
		    }
		    
		
		//  TRegistroI550
		
		public  TRegistroI550()
		{
		
		  fRegistroI555 = new TRegistroI555List();
		}
		
		
		
	}
	
	
	  
	public class TRegistroI550List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI550 read GetItem write SetItem;
		
		//  TRegistroI550List
		
		private TRegistroI550 GetItem( int Index)
		{
		
		TRegistroI550 Result;
		
		  Result = TRegistroI550(Inherited Items[Index]);
		return Result;
		}
		
		
		
		public TRegistroI550 New()
		{
		
		TRegistroI550 Result;
		
		  Result = new TRegistroI550();
		  
		  AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, TRegistroI550 Value)
		{
		
		  Put(Index, Value);
		}
		
		
		
	}
	
	
	
	   //  Registro I555 - TOTAIS NO LIVRO RAZ?O AUXILIAR COM LEIAUTE PARAMETRIZ?VEL
	
	  
	public class TRegistroI555 
	{
		
		
		    private string fRZ_CONT_TOT; 
		  
		    public String RZ_CONT_TOT
		    {
		    	get
		    	{
		    		return fRZ_CONT_TOT;
		    	}
		    	set
		    	{
		    		fRZ_CONT_TOT = value;
		    	}
		    }
		    
		
	}
	
	
	  //  Registro I555 - lista
	
	  
	public class TRegistroI555List : TObjectList
	{
		
		
		
		    property Items[Index: Integer]: TRegistroI555 read GetItem write SetItem;
		
		//  TRegistroI555List
		
		private TRegistroI555 GetItem( int index)
		{
		
		TRegistroI555 Result;
		
		  Result = TRegistroI555( inherited Items[index]);
		return Result;
		}
		
		
		
		public TRegistroI555 New()
		{
		
		TRegistroI555 Result;
		
		   Result = new TRegistroI555();
		   
		   AppendText(Result);
		return Result;
		}
		
		
		
		private void SetItem( int Index, TRegistroI555 Value)
		{
		
		   Put(Index, Value);
		}
		
		
		
	}
	
	
	  // / Registro I990 - ENCERRAMENTO DO BLOCO I
	
	  
	public class TRegistroI990 
	{
		
		
		    private int fQTD_LIN_I;    // / Quantidade total de linhas do Bloco I
		  
		    public Integer QTD_LIN_I
		    {
		    	get
		    	{
		    		return FQTD_LIN_I;
		    	}
		    	set
		    	{
		    		FQTD_LIN_I = value;
		    	}
		    }
		    
		
	}
	
	public static class ACBrECDBloco_I 
	{
		
		
		// / Registro I010 - IDENTIFICA??O DA ESCRITURA??O CONT?BIL
		
		
		public  ()
		{
		
		  FRegistroI051.Dispose();
		  FRegistroI052.Dispose();
		  FRegistroI053.Dispose();
		  base.Destroy;
		}
		
		
		
		public  ()
		{
		
		  FRegistroI151.Dispose();
		  FRegistroI155.Dispose();
		  base.Destroy;
		}
		
		
		
		public  ()
		{
		
		  fRegistroI250.Dispose();
		  base.Destroy;
		}
		
		
		
		public  ()
		{
		
		  FRegistroI310.Dispose();
		  base.Destroy;
		}
		
		
		
		public  ()
		{
		
		  FRegistroI355.Dispose();
		  base.Destroy;
		}
		
		
		
		public  ()
		{
		
		  fRegistroI555.Dispose();
		  base.Destroy;
		}
		
		
		
		public  ()
		{
		
		  FRegistroI015.Dispose();
		  base.Destroy;
		}
		
		
		
	}
	
}
