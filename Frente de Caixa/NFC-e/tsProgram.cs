using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NFCe.View;

namespace NFCe
{
	static class tsProgram
	{
		[STAThread]
		static void Main( string[] args )
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run(new Caixa());
		}
	}
}