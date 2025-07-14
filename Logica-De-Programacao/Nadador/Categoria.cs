using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadador
{
    internal class Categoria
    {
        private double idade;

        public Categoria(double Idade)
        {
            idade = Idade;
        }

        public string Classificacao()
        {
            if (idade < 5)
            {
                return "Idade não aceita";
            }
            if ((idade <= 7) && (idade >= 5))
            {
                return "Infantil A";
            }
            if ((idade >= 8) && (idade <= 10))
            {
                return "Infantil B";
            }
            if ((idade >= 11) && (idade <= 13))
            {
                return "Juvenil A";
            }
            if ((idade >= 14) && (idade <= 17))
            {
                return "Juvenil B";
            }
            else
            {
                return " Adulto";
            }
        }
    }
}
