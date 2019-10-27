using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportExport
{
	public partial class FuncionariosForm : Form
	{
		public FuncionariosForm( )
		{
			InitializeComponent( );
		}

		#region Campos/Atributos
		private ArrayList funcionarios = new ArrayList( );
		#endregion

		#region Constantes
		private const string arquivoParaImportar = "\\funcionarios.csv";
		private const string arquivoParaExportar = "\\funcionarios_com_aumento.csv";
		#endregion

		private void importarDadosButton_Click( object sender , EventArgs e )
		{
			#region ... Importa dados do arquivo CSV ...
			try
			{
				//funcionarios = Dados.ImportarDeCsv(Application.StartupPath + arquivoParaImportar);
				ofd.Title = "Selecione um arquivo CSV para importar...";
				ofd.Filter = "Arquivos CSV|*.csv";
				ofd.FileName = "funcionarios.csv";  // Sugestão de nome de arquivo
				ofd.InitialDirectory = 
					Environment.GetEnvironmentVariable( "USERPROFILE" ) + "\\Desktop";
				//ofd.InitialDirectory = Application.StartupPath;

				//if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				//{
				//    funcionarios = Dados.ImportarDeCsv(ofd.FileName);
				//}
				//else
				//{
				//    return;
				//}
				if ( ofd.ShowDialog( ) == System.Windows.Forms.DialogResult.Cancel ) return;

				funcionarios = Dados.ImportarDeCsv( ofd.FileName );
			}
			catch ( FileNotFoundException )
			{
				MessageBox.Show( text: "Arquivo CSV [" + ofd.FileName + "] não encontrado!" ,
									 caption: "Exceção - Arquivo Inexistente" ,
									 buttons: MessageBoxButtons.OK ,
									 icon: MessageBoxIcon.Error );
				return;
			}
			catch ( FormatException )
			{
				MessageBox.Show( text: "Falha na importação do arquivo CSV [" + ofd.FileName + "]!" ,
				caption: "Exceção - Dados Incorretos" ,
				buttons: MessageBoxButtons.OK ,
				icon: MessageBoxIcon.Error );
				return;
			}
			catch ( Exception ex )
			{
				MessageBox.Show( text: "Ocorreu exceção " + ex.Message ,
									 caption: "Exceção Geral" ,
									 buttons: MessageBoxButtons.OK ,
									 icon: MessageBoxIcon.Error );

				Debug.WriteLine( ex.ToString( ) );
				return;
			}
			#endregion

			#region ... Data-Binding (Vinculação de Dados) ...
			funcionariosDataGridView.DataSource = funcionarios;
			#endregion

			#region ... Customizações das colunas do DataGridView ...
			// Coluna 0 - ID
			funcionariosDataGridView.Columns[ 0 ].DefaultCellStyle.Alignment
				 = DataGridViewContentAlignment.MiddleRight;

			// Coluna 1 - PrimeiroNome
			funcionariosDataGridView.Columns[ 1 ].DefaultCellStyle.Alignment
				 = DataGridViewContentAlignment.MiddleLeft;
			funcionariosDataGridView.Columns[ 1 ].HeaderText = "Nome";

			// Coluna 2 - SobreNome
			funcionariosDataGridView.Columns[ 2 ].DefaultCellStyle.Alignment
				 = DataGridViewContentAlignment.MiddleLeft;

			// Coluna 3 - DataAdmissao
			funcionariosDataGridView.Columns[ 3 ].DefaultCellStyle.Alignment
				 = DataGridViewContentAlignment.MiddleCenter;
			funcionariosDataGridView.Columns[ 3 ].HeaderText = "Admissão";

			// Coluna 4 - SalarioAtual
			funcionariosDataGridView.Columns[ 4 ].DefaultCellStyle.Alignment
				 = DataGridViewContentAlignment.MiddleRight;
			funcionariosDataGridView.Columns[ 4 ].DefaultCellStyle.Format = "#,##0.00";
			funcionariosDataGridView.Columns[ 4 ].DefaultCellStyle.FormatProvider
					  = new CultureInfo( "en-US" );

			// Coluna 5 - NovoSalario
			funcionariosDataGridView.Columns[ 5 ].DefaultCellStyle.Alignment
				 = DataGridViewContentAlignment.MiddleRight;
			funcionariosDataGridView.Columns[ 5 ].DefaultCellStyle.Format = "#,##0.00";
			funcionariosDataGridView.Columns[ 5 ].DefaultCellStyle.FormatProvider
					  = new CultureInfo( "en-US" );
			funcionariosDataGridView.Columns[ 5 ].DefaultCellStyle.NullValue = "---";
			#endregion

			#region ... Habilita a função de Ajustar Salário ...
			ajustarSalariosButton.Enabled = true;
			exportarDadosButton.Enabled = false;
			#endregion
		}

		private void ajustarSalariosButton_Click( object sender , EventArgs e )
		{
			#region ... Aplica aumento salarial conforme regra de negócio ...
			Dados.AjustarSalarios( funcionarios );
			#endregion

			#region ... Sinaliza na UI (User Interface) quais salários sofreram aumento ...
			for ( int i = 0 ; i < funcionarios.Count ; i++ )
			{
				var func = ( Funcionario ) funcionarios[ i ];

				if ( func.NovoSalario != null )
				{
					funcionariosDataGridView.Rows[ i ]
						 .Cells[ 5 ].Style.ForeColor = Color.Red;
				}
			}
			#endregion

			#region ... Habilita a função Exportar Dados ...
			exportarDadosButton.Enabled = true;
			#endregion

			#region ... Quantidade de funcionários com aumento ...
			MessageBox.Show( string.Format( "A qtde de funcionários com reajuste foi: {0}" ,
									  Dados.QtdeReajustes ) );
			#endregion
		}

		private void exportarDadosButton_Click( object sender , EventArgs e )
		{
			#region ... Exporta dados para o arquivo CSV ...
			//var nomeArquivo = Application.StartupPath + arquivoParaExportar;
			//Dados.ExportarParaCsv(nomeArquivo, funcionarios);

			sfd.Title = "Informe o arquivo CSV para exportar";
			sfd.Filter = "Arquivos CSV|*.csv";
			sfd.InitialDirectory = 
				Environment.GetEnvironmentVariable( "USERPROFILE" ) + "\\Desktop";
			//sfd.FileName = string.Format("funcionarios_com_aumento_{0}.csv",
			//                    DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
			sfd.FileName = 
				string.Format( "funcionarios_com_aumento_{0:yyyy-MM-dd_HH-mm-ss}.csv" , 
										DateTime.Now );

			if ( sfd.ShowDialog( ) == System.Windows.Forms.DialogResult.OK )
			{
				Dados.ExportarParaCsv( sfd.FileName , funcionarios );
			}
			else
			{
				return;
			}
			#endregion

			#region ... Feedback para o usuário ...
			MessageBox.Show( "Exportação concluída!" );
			#endregion

			#region ... Abre o arquivo CSV gerado no Excel ...
			//Process.Start( "excel" , sfd.FileName );
			var f = new EscolherExportacaoForm( );
			var resp = f.ShowDialog( );

			if ( resp == DialogResult.OK )
			{
				if ( f.ExcelRadioButton.Checked == true )
				{
					Process.Start( "excel" , sfd.FileName );
				}
				else
				{
					Process.Start( "notepad" , sfd.FileName );
				}
			}
			#endregion
		}
	}
}
