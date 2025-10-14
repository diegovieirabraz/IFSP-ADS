using System;

namespace Proj_Listas_GerenciamentoDeProjetos
{
    public class Tarefa
    {
        public int Id { get; private set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public int Prioridade { get; set; }

        public string Status { get; private set; } = "Aberta";

        public DateTime DataCriacao { get; private set; } = DateTime.Now;
        public DateTime? DataConclusao { get; private set; }

        public Tarefa(int id, string titulo, string descricao, int prioridade)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = "Aberta";
            DataCriacao = DateTime.Now;
            DataConclusao = null;
        }

        public void Concluir()
        {
            if (Status == "Fechada") return;
            Status = "Fechada";
            DataConclusao = DateTime.Now;
        }

        public void Cancelar()
        {
            if (Status == "Cancelada") return;
            Status = "Cancelada";
            DataConclusao = null;
        }

        public void Reabrir()
        {
            if (Status == "Aberta") return;
            Status = "Aberta";
            DataConclusao = null;
        }

        public override string ToString()
        {
            var pri = Prioridade switch
            {
                1 => "Alta",
                2 => "Média",
                3 => "Baixa",
                _ => "?"
            };

            var conc = DataConclusao.HasValue
                ? DataConclusao.Value.ToString("dd/MM/yyyy HH:mm")
                : "-";

            return $"[#{Id}] {Titulo} | Pri: {pri} | Status: {Status} | " +
                   $"Criada: {DataCriacao:dd/MM/yyyy HH:mm} | Conclusão: {conc}";
        }
    }
}
