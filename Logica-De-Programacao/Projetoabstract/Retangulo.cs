using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetoabstract
{
    internal class Retangulo : Forma
    {
        private double baseR;
        private double altura;

        public double Base
        {
            get { return baseR; }
            set { baseR = value; }
        }

        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }

        public override void CalcularArea()
        {
            this.Area = baseR * altura;
        }

        public override void CalcularPerimetro()
        {
            this.Perimetro = (2 * baseR) + (2 * altura);
        }
    }
}
