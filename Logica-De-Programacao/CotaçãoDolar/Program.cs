using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotaçãoDolar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conversao conversao = new Conversao();

            Console.WriteLine("Qual é a cotação do dólar? ");
            conversao.cotacao = double.Parse(Console.ReadLine());

            Console.WriteLine("Quantos dólares você vai comprar? ");
            conversao.reais = double.Parse(Console.ReadLine());

            Console.WriteLine("Valor a ser pago em reais = R$" + conversao.total().ToString("F2"));

            Console.ReadLine();
        }
    }
}
