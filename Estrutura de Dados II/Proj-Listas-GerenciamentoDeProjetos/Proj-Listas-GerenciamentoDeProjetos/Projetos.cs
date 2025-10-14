using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_Listas_GerenciamentoDeProjetos
{
    public class Projetos
    {
        public List<Projeto> Itens { get; } = new();

        public bool Adicionar(Projeto p)
        {
            if (Itens.Any(x => x.Id == p.Id)) return false;
            Itens.Add(p);
            return true;
        }

        public bool Remover(Projeto p)
        {
            var alvo = Itens.FirstOrDefault(x => x.Id == p.Id);
            if (alvo == null) return false;
            return Itens.Remove(alvo);
        }

        public Projeto? Buscar(int projetoId) => Itens.FirstOrDefault(x => x.Id == projetoId);

        public List<Projeto> Listar() => Itens.ToList();
    }
}
