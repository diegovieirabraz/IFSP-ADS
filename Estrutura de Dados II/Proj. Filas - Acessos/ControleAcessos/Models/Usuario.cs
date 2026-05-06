using System.Collections.Generic;
using System.Linq;

namespace ControleAcessos.Models;

public class Usuario
{
    private readonly List<Ambiente> _ambientes = new();

    public Usuario(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; }

    public string Nome { get; }

    public IReadOnlyCollection<Ambiente> Ambientes => _ambientes.AsReadOnly();

    public bool ConcederPermissao(Ambiente ambiente)
    {
        if (_ambientes.Any(a => a.Id == ambiente.Id))
        {
            return false;
        }

        _ambientes.Add(ambiente);
        return true;
    }

    public bool RevogarPermissao(Ambiente ambiente)
    {
        Ambiente? existente = _ambientes.FirstOrDefault(a => a.Id == ambiente.Id);
        if (existente == null)
        {
            return false;
        }

        _ambientes.Remove(existente);
        return true;
    }

    internal bool PossuiPermissaoPara(int ambienteId) => _ambientes.Any(a => a.Id == ambienteId);

    internal void DefinirPermissoes(IEnumerable<Ambiente> ambientes)
    {
        _ambientes.Clear();
        foreach (Ambiente ambiente in ambientes)
        {
            if (_ambientes.All(a => a.Id != ambiente.Id))
            {
                _ambientes.Add(ambiente);
            }
        }
    }

    internal void RemoverPermissaoPorId(int ambienteId)
    {
        Ambiente? existente = _ambientes.FirstOrDefault(a => a.Id == ambienteId);
        if (existente != null)
        {
            _ambientes.Remove(existente);
        }
    }
}
