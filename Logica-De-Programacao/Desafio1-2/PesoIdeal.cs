using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_2
{
    internal class PesoIdeal
    {
        public double altura;
        public int sexo;

        public double CalcularPesoIdeal()
        {
           
            if (sexo == 1)
            {
                return 72.7 * altura - 58;
            }
            else if (sexo == 2)
            {
                return 62.1 * altura - 44.7;
            }
            else
            {
                throw new ArgumentException("Sexo Invalido ");
            }
        }
    }
}
