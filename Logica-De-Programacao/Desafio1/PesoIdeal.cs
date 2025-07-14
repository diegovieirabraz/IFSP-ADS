using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal class PesoIdeal
    {
        public double Altura { get; set; }
        public int Sexo { get; set; }

        public PesoIdeal(double altura, int sexo)
        {
            Altura = altura;
            Sexo = sexo;
        }

        public double CalcularPesoIdeal()
        {
            if (Sexo == 1)
            {
                return 72.7 * Altura - 58;
            }
            else if (Sexo == 2)
            {
                return 62.1 * Altura - 44.7;
            }
            else
            {
                throw new ArgumentException("Sexo Invalido ");
            }
        }
    }
}
