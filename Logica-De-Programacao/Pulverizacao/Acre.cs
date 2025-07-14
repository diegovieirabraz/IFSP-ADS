using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulverizacao
{
    internal class Acre
    {
        public int Tipo;
        public double Area;
        public double CustoPorAcre;

        public Acre(int tipo, double area) 
        { 
            Tipo = tipo;
            Area = area;
            CustoPorAcre = CalcularCustoPorAcre();
        }

        public double CalcularCustoPorAcre()
        {
            switch (Tipo)
            {
                case 1: return CustoPorAcre = 50.00;
                case 2: return CustoPorAcre = 100.00;
                case 3: return CustoPorAcre = 150.00;
                case 4: return CustoPorAcre = 250.00;
                default: return 0.0;
            }
        }

        public double CalcularCusto()
        {
            double custoInicial = CustoPorAcre * Area;

            if (Area > 1000)
            {
                custoInicial *= 0.95;
            }
            
            if (custoInicial > 750.00)
            {
                custoInicial = 750 + ((custoInicial - 750) * 0.90);
            }
            return custoInicial;
        }
    }
}
