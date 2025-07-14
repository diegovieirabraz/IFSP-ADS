using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrimeiroProjeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Triangulo x = new Triangulo();
            Triangulo y = new Triangulo();

            Console.WriteLine("Escreva o lado do triangulo X: ");
            x.a = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            x.b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.c = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Escreva o lado do triangulo Y: ");
            y.a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.c = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double areax = x.CalcularTriangulo();
            double areay = y.CalcularTriangulo();

            Console.WriteLine("A area do triangulo X: " + areax.ToString("f2"));
            Console.WriteLine("A area do triangulo Y: " + areay.ToString("f2"));

            Console.ReadLine();
            

        }
    }
}
