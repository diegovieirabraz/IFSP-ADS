using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularVolume
{
    internal class CalculoVolume
    {
        private double _comprimento;
        private double _largura;
        private double _altura;


        public CalculoVolume(double comprimento, double largura, double altura)
        {
            _comprimento = comprimento;
            _largura = largura;
            _altura = altura;
        }

        public double CalcularVolume()
        {
            return _comprimento * _largura * _altura;
        }
    }
}
