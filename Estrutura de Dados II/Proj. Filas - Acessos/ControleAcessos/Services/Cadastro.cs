using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ControleAcessos.Models;

namespace ControleAcessos.Services;

public class Cadastro
{
    private readonly List<Usuario> _usuarios = new();
    private readonly List<Ambiente> _ambientes = new();
    private readonly string _dataFilePath;
    private readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public Cadastro(string dataFilePath)
    {
        _dataFilePath = dataFilePath;
        string? directory = Path.GetDirectoryName(_dataFilePath);
        if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        Download();
    }

    public IReadOnlyCollection<Usuario> Usuarios => _usuarios.AsReadOnly();

    public IReadOnlyCollection<Ambiente> Ambientes => _ambientes.AsReadOnly();

    public bool AdicionarUsuario(int id, string nome)
    {
        if (_usuarios.Any(u => u.Id == id))
        {
            return false;
        }

        _usuarios.Add(new Usuario(id, nome));
        return true;
    }

    public bool RemoverUsuario(int id)
    {
        Usuario? usuario = PesquisarUsuario(id);
        if (usuario == null || usuario.Ambientes.Any())
        {
            return false;
        }

        _usuarios.Remove(usuario);
        return true;
    }

    public Usuario? PesquisarUsuario(int id) => _usuarios.FirstOrDefault(u => u.Id == id);

    public bool AdicionarAmbiente(int id, string nome)
    {
        if (_ambientes.Any(a => a.Id == id))
        {
            return false;
        }

        _ambientes.Add(new Ambiente(id, nome));
        return true;
    }

    public bool RemoverAmbiente(int id)
    {
        Ambiente? ambiente = PesquisarAmbiente(id);
        if (ambiente == null)
        {
            return false;
        }

        foreach (Usuario usuario in _usuarios)
        {
            usuario.RemoverPermissaoPorId(id);
        }

        _ambientes.Remove(ambiente);
        return true;
    }

    public Ambiente? PesquisarAmbiente(int id) => _ambientes.FirstOrDefault(a => a.Id == id);

    public bool ConcederPermissao(int usuarioId, int ambienteId)
    {
        Usuario? usuario = PesquisarUsuario(usuarioId);
        Ambiente? ambiente = PesquisarAmbiente(ambienteId);
        if (usuario == null || ambiente == null)
        {
            return false;
        }

        return usuario.ConcederPermissao(ambiente);
    }

    public bool RevogarPermissao(int usuarioId, int ambienteId)
    {
        Usuario? usuario = PesquisarUsuario(usuarioId);
        Ambiente? ambiente = PesquisarAmbiente(ambienteId);
        if (usuario == null || ambiente == null)
        {
            return false;
        }

        return usuario.RevogarPermissao(ambiente);
    }

    public Log? ProcessarAcesso(int ambienteId, int usuarioId)
    {
        Usuario? usuario = PesquisarUsuario(usuarioId);
        Ambiente? ambiente = PesquisarAmbiente(ambienteId);
        if (usuario == null || ambiente == null)
        {
            return null;
        }

        bool autorizado = usuario.PossuiPermissaoPara(ambiente.Id);
        var log = new Log(DateTime.Now, usuario, autorizado);
        ambiente.RegistrarLog(log);
        return log;
    }

    public IEnumerable<Log> ConsultarLogs(int ambienteId, LogFilter filtro)
    {
        Ambiente? ambiente = PesquisarAmbiente(ambienteId);
        if (ambiente == null)
        {
            return Enumerable.Empty<Log>();
        }

        IEnumerable<Log> logs = ambiente.Logs;
        return filtro switch
        {
            LogFilter.Authorized => logs.Where(l => l.TipoAcesso).ToList(),
            LogFilter.Denied => logs.Where(l => !l.TipoAcesso).ToList(),
            _ => logs.ToList()
        };
    }

    public void Upload()
    {
        var state = new PersistedState
        {
            Usuarios = _usuarios.Select(u => new UsuarioData
            {
                Id = u.Id,
                Nome = u.Nome,
                AmbienteIds = u.Ambientes.Select(a => a.Id).ToList()
            }).ToList(),
            Ambientes = _ambientes.Select(a => new AmbienteData
            {
                Id = a.Id,
                Nome = a.Nome,
                Logs = a.Logs.Select(log => new LogData
                {
                    DtAcesso = log.DtAcesso,
                    UsuarioId = log.Usuario.Id,
                    UsuarioNome = log.Usuario.Nome,
                    TipoAcesso = log.TipoAcesso
                }).ToList()
            }).ToList()
        };

        string json = JsonSerializer.Serialize(state, _jsonOptions);
        File.WriteAllText(_dataFilePath, json);
    }

    public void Download()
    {
        if (!File.Exists(_dataFilePath))
        {
            return;
        }

        try
        {
            string json = File.ReadAllText(_dataFilePath);
            PersistedState? state = JsonSerializer.Deserialize<PersistedState>(json, _jsonOptions);
            if (state == null)
            {
                return;
            }

            _usuarios.Clear();
            _ambientes.Clear();

            foreach (AmbienteData? ambienteData in state.Ambientes ?? new List<AmbienteData>())
            {
                if (ambienteData == null)
                {
                    continue;
                }

                _ambientes.Add(new Ambiente(ambienteData.Id, ambienteData.Nome ?? string.Empty));
            }

            Dictionary<int, Ambiente> ambienteById = _ambientes.ToDictionary(a => a.Id);

            foreach (UsuarioData? usuarioData in state.Usuarios ?? new List<UsuarioData>())
            {
                if (usuarioData == null)
                {
                    continue;
                }

                _usuarios.Add(new Usuario(usuarioData.Id, usuarioData.Nome ?? string.Empty));
            }

            Dictionary<int, Usuario> usuariosById = _usuarios.ToDictionary(u => u.Id);

            foreach (UsuarioData usuarioData in state.Usuarios ?? Enumerable.Empty<UsuarioData>())
            {
                if (!usuariosById.TryGetValue(usuarioData.Id, out Usuario? usuario))
                {
                    continue;
                }

                IEnumerable<Ambiente> ambientesPermitidos = (usuarioData.AmbienteIds ?? new List<int>())
                    .Select(id => ambienteById.TryGetValue(id, out Ambiente? ambiente) ? ambiente : null)
                    .Where(a => a != null)!
                    .Cast<Ambiente>();
                usuario.DefinirPermissoes(ambientesPermitidos);
            }

            Dictionary<int, Usuario> logUsuarios = new(usuariosById);

            foreach (AmbienteData ambienteData in state.Ambientes ?? Enumerable.Empty<AmbienteData>())
            {
                if (!ambienteById.TryGetValue(ambienteData.Id, out Ambiente? ambiente))
                {
                    continue;
                }

                IEnumerable<Log> logs = (ambienteData.Logs ?? new List<LogData>())
                    .Select(logData =>
                    {
                        if (!logUsuarios.TryGetValue(logData.UsuarioId, out Usuario? usuario))
                        {
                            usuario = new Usuario(logData.UsuarioId, logData.UsuarioNome ?? $"Usuário {logData.UsuarioId}");
                            logUsuarios[usuario.Id] = usuario;
                        }

                        return new Log(logData.DtAcesso, usuario, logData.TipoAcesso);
                    });

                ambiente.RecarregarLogs(logs);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Falha ao carregar dados: {ex.Message}");
        }
    }

    private class PersistedState
    {
        public List<UsuarioData>? Usuarios { get; set; }

        public List<AmbienteData>? Ambientes { get; set; }
    }

    private class UsuarioData
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public List<int>? AmbienteIds { get; set; }
    }

    private class AmbienteData
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public List<LogData>? Logs { get; set; }
    }

    private class LogData
    {
        public DateTime DtAcesso { get; set; }

        public int UsuarioId { get; set; }

        public string? UsuarioNome { get; set; }

        public bool TipoAcesso { get; set; }
    }
}
