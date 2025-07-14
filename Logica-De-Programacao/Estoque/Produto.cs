using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque
{
    internal class Produto
    {
        public string Nome;
        public double Preco;
        public int Quantidade;


        public Produto (string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco; 
            Quantidade = quantidade;

        }

        public double ValorTotalEmEstoque()
        {
            return Preco * Quantidade;
        }
        public override string ToString()
        {
            return Nome 
                + " $" 
                + Preco.ToString("F2")
                +", "
                +Quantidade
                +" unidades, Total: $ "
                +ValorTotalEmEstoque().ToString("F2");
        }
        public void AdicionarProdutos(int quantidade)
        {
             Quantidade += quantidade;
        }

        public void RemoverProduto(int quantidade)
        {
            Quantidade -= quantidade;
        }
    }
}
