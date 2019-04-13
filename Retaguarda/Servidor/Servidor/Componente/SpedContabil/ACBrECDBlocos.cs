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

namespace ProjetoSpedContabil
{
	
	  // / ABERTURA DOS BLOCOS
	
	  
	public class TOpenBlocos 
	{
		
		
		    private int FIND_DAD; /*/ Indicador de movimento: 0- Bloco com dados informados, 1- Bloco sem dados informados.*/ // / Create
		
		    public Integer IND_DAD
		    {
		    	get
		    	{
		    		return FIND_DAD;
		    	}
		    	set
		    	{
		    		FIND_DAD = value;
		    	}
		    }
		     // / Propriedade que armazena o indicador de movimento
		public  TOpenBlocos()
		{
		
		   FIND_DAD = 1;
		}
		
		
	}
	
	public static class ACBrECDBlocos 
	{
		
		
		
		
		
	}
	
}
