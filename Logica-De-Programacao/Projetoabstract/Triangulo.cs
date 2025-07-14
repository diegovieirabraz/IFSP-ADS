using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projetoabstract
{
    internal class Triangulo : Forma
    {
        private double baseT;
        private double altura;
        private double ladoA;
        private double ladoB;
        private double ladoC;

        public double BaseT
        {
            get
            { return baseT; }
            set
            { baseT = value; }
        }

        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }

        public double LadoA
        {
            get { return ladoA; }
            set { ladoA = value; }
        }

        public double LadoB
        {
            get { return ladoB; }
            set { ladoB = value; }
        }
        public double LadoC
        {
            get { return ladoC; }
            set { ladoC = value; }
        }
        public override void CalcularArea()
        {
            this.Area = (baseT * altura) / 2;
        }

        public override void CalcularPerimetro()
        {
            this.Perimetro = ladoA + ladoB + ladoC;
        }

    }

}
