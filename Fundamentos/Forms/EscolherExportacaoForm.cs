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
    public partial class EscolherExportacaoForm : Form
    {
        public EscolherExportacaoForm()
        {
            InitializeComponent();
        }

		  private void Fechar_Click( object sender , EventArgs e )
		  {
			  this.Close( );
		  }
    }
}
