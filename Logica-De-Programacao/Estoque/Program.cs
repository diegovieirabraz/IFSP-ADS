using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Digite o nome do produto");
            string Nome = Console.ReadLine();

            Console.WriteLine("Digite o preço");
            double Preco = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantidade");
            int Quantidade = int.Parse(Console.ReadLine());

            Produto p = new Produto(Nome, Preco, Quantidade);

            Console.WriteLine("Dados do produto: " + p);

            Console.WriteLine("Digite a quantidade de produtos que vai se adicionado ao estoque.");
            int quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantidade de produtos que vai se subtraido do estoque.");
            int quantidade1 = int.Parse(Console.ReadLine());

            p.AdicionarProdutos(quantidade);
            p.RemoverProduto(quantidade1);

            Console.WriteLine("Dados do produto: " + p);

            Console.ReadLine();

        }
    }
}