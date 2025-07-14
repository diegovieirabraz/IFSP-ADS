using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Antecessor_sucessor
{
    internal class AntecessorSucessor
    {
        private double _numero;

        public AntecessorSucessor(double numero )
        {
            this.numero = numero;
        }

        public double numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        
         public double CalcularAntecessor()
        {
            return numero - 1;
        }

        public double CalcularSucessor()
        {
            return numero + 1;
        }
    }
}
