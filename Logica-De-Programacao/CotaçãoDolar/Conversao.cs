using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotaçãoDolar
{
    internal class Conversao
    {
        public double cotacao;
        public double reais;

        public double total()
        {
            return cotacao * reais;
        }
    }
}
