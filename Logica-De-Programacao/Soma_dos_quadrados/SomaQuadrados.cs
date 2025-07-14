using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soma_dos_quadrados
{
    internal class SomaQuadrados
    {
        private double _n1;
        private double _n2;
        private double _n3;

        public SomaQuadrados(double numero1, double numero2, double numero3) { 
           n1 = numero1;
           n2 = numero2;
           n3 = numero3;
        }

        public double n1
        {
            get { return _n1; }
            set { _n1 = value; }
        }
        public double n2
        {
            get { return _n2; }
            set { _n2 = value; }
        }
        public double n3
        {
            get { return _n3; }
            set { _n3 = value; }
        }

        public double CalcularSomaQuadrados()
        {
            return (n1 * n1) + (n2 * n2) + (n3 * n3); 
        }
    }
}
