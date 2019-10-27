using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ImportExport
{
	public partial class SplashForm : Form
	{
		public SplashForm( )
		{
			InitializeComponent( );

			// Carrega as informações da versão
			label2.Text = string.Format( "Versão: {0}.{1}" ,
						Assembly.GetExecutingAssembly( ).GetName( ).Version.Major ,	// {0}
						Assembly.GetExecutingAssembly( ).GetName( ).Version.Minor	// {1}
					);
		}
	}
}
