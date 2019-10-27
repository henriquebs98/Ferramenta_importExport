using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportExport
{
	public partial class PrincipalForm : Form
	{
		public PrincipalForm( )
		{
			InitializeComponent( );
		}

		private void funcionáriosToolStripMenuItem_Click( object sender , EventArgs e )
		{
			var f = new FuncionariosForm( );
			f.MdiParent = this;	// instância corrente do PrincipalForm
			f.Show( );
		}

		private void sobreToolStripMenuItem_Click( object sender , EventArgs e )
		{
			var f = new SobreForm( );
			f.ShowDialog( );
		}

		private void PrincipalForm_FormClosing( object sender , FormClosingEventArgs e )
		{
			//var dr = MessageBox.Show(
			//								"Deseja realmente sair?" ,
			//								"Ferramenta Import/Export" ,
			//								MessageBoxButtons.YesNo ,
			//								MessageBoxIcon.Question ,
			//								MessageBoxDefaultButton.Button2 ); 
			var dr = MessageBox.Show(
											text: "Deseja realmente sair?" ,
											caption: "Ferramenta Import/Export" ,
											buttons: MessageBoxButtons.YesNo ,
											icon: MessageBoxIcon.Question ,
											defaultButton: MessageBoxDefaultButton.Button2 );

			if ( dr == DialogResult.No )
			{
				e.Cancel = true;	// Cancela/interrompe o fechamento do Form
			}
		}

		private void sairToolStripMenuItem_Click( object sender , EventArgs e )
		{
			//this.Close( );
			Close( );
		}

		// Arquivo | Sobre
		private void toolStripButton1_Click( object sender , EventArgs e )
		{
			sobreToolStripMenuItem.PerformClick( );	// Dispara programaticamente o evento Click
		}

		// Cadastros | Funcionários
		private void toolStripButton2_Click( object sender , EventArgs e )
		{
			funcionáriosToolStripMenuItem.PerformClick( );
		}

		// Arquivo | Sair
		private void toolStripButton3_Click( object sender , EventArgs e )
		{
			sairToolStripMenuItem.PerformClick( );
		}
	}
}
