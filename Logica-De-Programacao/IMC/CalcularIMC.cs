using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC
{
    internal class CalcularIMC
    {
        private double _peso;
        private double _altura;

        public CalcularIMC(double peso, double altura)
        {
            _peso = peso;
            _altura = altura;
        }

        public string TabelaIMC()
        {
            double indice = _peso / (_altura * _altura);

            if (indice < 20)
            {
                return "Abaixo do peso.";
            }
            if ((indice >= 20) && (indice < 25))
            {
                return "Peso normal";
            }
            if ((indice >= 25) && (indice < 30))
            {
                return "Sobre peso";
            }
            if ((indice >= 30) && (indice < 40))
            {
                return "Obeso";
            }
            else
            {
                return "Obesidade mórbida";
            }
        }

    }
}
