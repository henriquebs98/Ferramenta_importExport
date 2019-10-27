using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ImportExport
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main( )
		{
			Application.EnableVisualStyles( );
			Application.SetCompatibleTextRenderingDefault( false );

			CarregaSplashForm( );

			Application.Run( new PrincipalForm( ) );
		}

		private static void CarregaSplashForm( )
		{
			var f = new SplashForm( );
			f.Show( );
			f.Refresh( );				// Força a (re)pintura da janela e seus componentes
			Thread.Sleep( 3000 );	// Pausa execução por 3s
			f.Close( );
		}
	}
}
