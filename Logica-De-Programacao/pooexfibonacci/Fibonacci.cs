using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pooexfibonacci
{
    internal class Fibonacci
    {
        public int Sequecia(int n)
        {
            switch (n)
            {
                case 0 : return 0;
                case 1 : return 1;  
            }

            int n1 = 1, n2 = 1;

            for (int i = 3; i <= n; i++)
            {
                int nproximo = n1 + n2;
                n1 = n2;
                n2 = nproximo;
            }

            return n2;

        }
    }
}
