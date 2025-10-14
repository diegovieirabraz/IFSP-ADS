using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Proj_Listas_GerenciamentoDeProjetos
{
    public class Projeto
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public List<Tarefa> Tarefas { get; } = new();

        public Projeto(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionarTarefa(Tarefa t) => Tarefas.Add(t);

        public bool RemoverTarefa(Tarefa t) => Tarefas.Remove(t);

        public Tarefa? BuscarTarefa(int tarefaId) => Tarefas.FirstOrDefault(x => x.Id == tarefaId);

        public List<Tarefa> TarefasPorStatus(string status) =>
            Tarefas.Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();

        public List<Tarefa> TarefasPorPrioridade(int prioridade) =>
            Tarefas.Where(t => t.Prioridade == prioridade).ToList();

        public int TotalAbertas() => Tarefas.Count(t => t.Status == "Aberta");
        public int TotalFechadas() => Tarefas.Count(t => t.Status == "Fechada");

        public override string ToString()
            => $"Projeto [#{Id}] {Nome} | Tarefas: {Tarefas.Count} (Abertas: {TotalAbertas()}, Fechadas: {TotalFechadas()}, Canceladas: {Tarefas.Count(t => t.Status == "Cancelada")})";
    }
}
