using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjFilaMedicamento
{
    public class Medicamentos
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Laboratorio { get; set; } = string.Empty;
        public Queue<Lote> Lotes { get; set; } = new Queue<Lote>();

        public Medicamentos() { }

        public Medicamentos(int id, string nome, string laboratorio)
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
        }

   
        public int QtdeDisponivel()
        {
            return Lotes.Sum(l => l.Qtde);
        }

    
        public void Comprar(Lote lote)
        {
            if (lote == null || lote.Qtde <= 0)
            {
                Console.WriteLine("Lote inválido.");
                return;
            }

            Lotes.Enqueue(lote);
        }

        
        public bool Vender(int qtde)
        {
            if (qtde <= 0)
                return false;

            int disponivel = QtdeDisponivel();

            if (disponivel < qtde)
                return false; 

            int restante = qtde;

            while (restante > 0 && Lotes.Count > 0)
            {
                var primeiro = Lotes.Peek();

                if (primeiro.Qtde > restante)
                {
                   
                    primeiro.Qtde -= restante;
                    restante = 0;
                }
                else
                {
                    
                    restante -= primeiro.Qtde;
                    Lotes.Dequeue();
                }
            }

            return true;
        }

        public override string ToString()
        {
            return $"{Id}-{Nome}-{Laboratorio}-{QtdeDisponivel()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not Medicamentos outro)
                return false;

            return this.Id == outro.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
