using System.Collections.Generic;
using System.Linq;

namespace ControleAcessos.Models;

public class Ambiente
{
    private readonly Queue<Log> _logs = new();

    public Ambiente(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; }

    public string Nome { get; }

    public IEnumerable<Log> Logs => _logs.ToArray();

    public void RegistrarLog(Log log)
    {
        if (_logs.Count >= 100)
        {
            _logs.Dequeue();
        }

        _logs.Enqueue(log);
    }

    internal void RecarregarLogs(IEnumerable<Log> logs)
    {
        _logs.Clear();
        foreach (Log log in logs.OrderBy(l => l.DtAcesso))
        {
            RegistrarLog(log);
        }
    }
}
