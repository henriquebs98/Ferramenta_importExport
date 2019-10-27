using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportExport
{
    class Funcionario
    {
        public int ID { get; set; }
        public string PrimeiroNome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal SalarioAtual { get; set; }
        public decimal? NovoSalario { get; set; }
    }
}
