using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    internal class Triangulo
    {
        public double lado1;
        public double lado2;
        public double lado3;

        public String TipoTriangulo()
        {
            if (((lado1 + lado2) > lado3) && ((lado2 + lado3) > lado1) && (lado1 + lado3) > lado2)
            {
                if(lado1 == lado2 && lado2 == lado3)
                {
                    return "Este é um triangulo equilátero";
                }
                else if (lado1 == lado2 || lado2 == lado3 || lado3 == lado1)
                {
                    return "Este é um triangulo isósceles";
                }
                else
                {
                    return "Este é um triangulo escaleno";
                }
            }
            else
            {
                return "Estas medidas não formam um triangulo";
            }

        }

    }
}
