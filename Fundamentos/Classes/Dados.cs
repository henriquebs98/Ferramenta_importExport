using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportExport
{
    class Dados
    {
        #region ... Propriedades ...
        public static int QtdeReajustes { get; set; }
        #endregion

        #region ... Métodos ...
        public static ArrayList ImportarDeCsv(string nomeArquivo)
        {
            // Variáveis
            //ArrayList funcionarios = new ArrayList();
            //StreamReader sr = new StreamReader(nomeArquivo);
            //string linhaDados = "";
            var funcionarios = new ArrayList();
            var sr = new StreamReader(nomeArquivo);
            var linhaDados = "";

            linhaDados = sr.ReadLine(); // Lê (e despreza) o cabeçalho

            while ((linhaDados = sr.ReadLine()) != null)    // enquanto há dados!!!
            {
                var campos = linhaDados.Split(';');

                var novoFunc = new Funcionario();
                novoFunc.ID = Convert.ToInt32(campos[0]);
                novoFunc.PrimeiroNome = campos[1];
                novoFunc.SobreNome = campos[2];
                novoFunc.DataAdmissao =
                    Convert.ToDateTime(campos[5], new CultureInfo("en-US"));
                novoFunc.SalarioAtual = Convert.ToDecimal(campos[7]);

                funcionarios.Add(novoFunc);
            }

            sr.Close(); // Fechar o leitor!

            return funcionarios;
        }

        public static void AjustarSalarios(ArrayList funcionarios)
        {
            QtdeReajustes = 0;

            foreach (Funcionario func in funcionarios)
            {
                if (func.DataAdmissao.Year <= 2003)
                {
                    func.NovoSalario = func.SalarioAtual * 1.1m;
                    //QtdeReajustes = QtdeReajustes + 1;
                    //QtdeReajustes += 1;
                    QtdeReajustes++;
                }
            }
        }

        public static void ExportarParaCsv(string nomeArquivo, ArrayList funcionarios)
        {
            var sw = new StreamWriter(nomeArquivo, false);  // arquivo será sobrescrito
            var sb = new StringBuilder();   // facilita concatenar múltiplas strings
            var linhaDados = "EMPLOYEE_ID;FIRST_NAME;LAST_NAME;HIRE_DATE;SALARY;NEW_SALARY";

            sw.WriteLine(linhaDados);   // grava o cabeçalho do arquivo

            foreach (Funcionario func in funcionarios)
            {
                if (func.NovoSalario != null)   // Funcionários com aumento?
                {
                    linhaDados = string.Format("{0};{1};{2};{3:MM/dd/yyyy};{4:#,##0.00};{5:#,##0.00}",
                                        func.ID,            // {0}
                                        func.PrimeiroNome,  // {1}
                                        func.SobreNome,     // {2}
                                        func.DataAdmissao,  // {3}
                                        func.SalarioAtual,  // {4}
                                        func.NovoSalario    // {5}
                                    );

						  #region Contatenando com StringBuilder
						  //sb.Clear();
						  //sb.Append(func.ID);
						  //sb.Append(';');
						  //sb.Append(func.PrimeiroNome);
						  //sb.Append(';');
						  //sb.Append(func.SobreNome);
						  //sb.Append(';');
						  //sb.Append(func.DataAdmissao.ToString("MM/dd/yyyy", new CultureInfo("en-US")));
						  //sb.Append(';');
						  //sb.Append(func.SalarioAtual.ToString("#,##0.00", new CultureInfo("en-US")));
						  //sb.Append(';');
						  //sb.Append(
						  //    Convert.ToDecimal(func.NovoSalario)
						  //        .ToString("#,##0.00", new CultureInfo("en-US"))); 
						  #endregion

                    //linhaDados = sb.ToString(); // devolve string concatenada!!!

                    sw.WriteLine(linhaDados);
                }
            }

            //linhaDados = string.Format("Total: {0} - {1,6:N2} %",
            //                QtdeReajustes,  // {0}
            //                (double)QtdeReajustes / (double)funcionarios.Count * 100);// {1}
            linhaDados = string.Format("Total: {0} - {1,6:P2}",
                            QtdeReajustes,  // {0}
                            (double)QtdeReajustes / (double)funcionarios.Count);// {1}
            sw.WriteLine(linhaDados);

            sw.Close(); // fechar gravador de stream APÓS o laço!!!
        } 
        #endregion
    }
}