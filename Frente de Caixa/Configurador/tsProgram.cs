using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConfiguraPAFECF.View;

namespace ConfiguraPAFECF
{
	static class tsProgram
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main( string[] args )
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new FConfiguracao() );
		}
	}
}