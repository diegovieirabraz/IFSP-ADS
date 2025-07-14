using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoSalario
{
    internal class Mensalista : Professor
    {
        double salarioTotalMensalista;

        public double SalarioTotalMensalista
        {
            get { return salarioTotalMensalista; }
        }

        public void CalcularsalarioMensalista()
        {
            salarioTotalMensalista = salarioBase + horaAtividade;
        }
    }
}
