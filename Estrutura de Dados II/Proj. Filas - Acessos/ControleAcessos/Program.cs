using System.Linq;
using ControleAcessos.Models;
using ControleAcessos.Services;

string dataFile = Path.Combine(AppContext.BaseDirectory, "cadastro.json");
var cadastro = new Cadastro(dataFile);

Console.CancelKeyPress += (_, e) =>
{
    cadastro.Upload();
    e.Cancel = false;
};

RunMenu();

void RunMenu()
{
    bool running = true;
    while (running)
    {
        ShowMenu();
        Console.Write("Opção: ");
        if (!int.TryParse(Console.ReadLine(), out int option))
        {
            Console.WriteLine("Opção inválida.");
            continue;
        }

        try
        {
            switch (option)
            {
                case 0:
                    cadastro.Upload();
                    Console.WriteLine("Dados salvos. Encerrando...");
                    running = false;
                    break;
                case 1:
                    AddUser();
                    break;
                case 2:
                    RemoveUser();
                    break;
                case 3:
                    SearchUser();
                    break;
                case 4:
                    AddEnvironment();
                    break;
                case 5:
                    RemoveEnvironment();
                    break;
                case 6:
                    SearchEnvironment();
                    break;
                case 7:
                    GrantPermission();
                    break;
                case 8:
                    RevokePermission();
                    break;
                case 9:
                    RegisterAccess();
                    break;
                case 10:
                    ShowLogs();
                    break;
                default:
                    Console.WriteLine("Escolha uma opção entre 0 e 10.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}

void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("=== Controle de Acessos ===");
    Console.WriteLine("1 - Adicionar usuário");
    Console.WriteLine("2 - Remover usuário");
    Console.WriteLine("3 - Pesquisar usuário");
    Console.WriteLine("4 - Adicionar ambiente");
    Console.WriteLine("5 - Remover ambiente");
    Console.WriteLine("6 - Pesquisar ambiente");
    Console.WriteLine("7 - Conceder permissão");
    Console.WriteLine("8 - Revogar permissão");
    Console.WriteLine("9 - Registrar acesso");
    Console.WriteLine("10 - Consultar logs");
    Console.WriteLine("0 - Sair");
}

void AddUser()
{
    int id = PromptInt("ID do usuário: ");
    Console.Write("Nome do usuário: ");
    string? nome = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(nome))
    {
        Console.WriteLine("Nome não pode ser vazio.");
        return;
    }

    bool added = cadastro.AdicionarUsuario(id, nome.Trim());
    Console.WriteLine(added ? "Usuário cadastrado." : "Já existe usuário com este ID.");
}

void RemoveUser()
{
    int id = PromptInt("ID do usuário a remover: ");
    bool removed = cadastro.RemoverUsuario(id);
    Console.WriteLine(removed
        ? "Usuário removido."
        : "Usuário inexistente ou com permissões pendentes.");
}

void SearchUser()
{
    int id = PromptInt("ID do usuário: ");
    Usuario? usuario = cadastro.PesquisarUsuario(id);
    if (usuario == null)
    {
        Console.WriteLine("Usuário não encontrado.");
        return;
    }

    Console.WriteLine($"Usuário: {usuario.Id} - {usuario.Nome}");
    if (!usuario.Ambientes.Any())
    {
        Console.WriteLine("Sem permissões.");
        return;
    }

    Console.WriteLine("Permissões:");
    foreach (Ambiente ambiente in usuario.Ambientes)
    {
        Console.WriteLine($" - {ambiente.Id} - {ambiente.Nome}");
    }
}

void AddEnvironment()
{
    int id = PromptInt("ID do ambiente: ");
    Console.Write("Nome do ambiente: ");
    string? nome = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(nome))
    {
        Console.WriteLine("Nome não pode ser vazio.");
        return;
    }

    bool added = cadastro.AdicionarAmbiente(id, nome.Trim());
    Console.WriteLine(added ? "Ambiente cadastrado." : "Já existe ambiente com este ID.");
}

void RemoveEnvironment()
{
    int id = PromptInt("ID do ambiente a remover: ");
    bool removed = cadastro.RemoverAmbiente(id);
    Console.WriteLine(removed ? "Ambiente removido." : "Ambiente não encontrado.");
}

void SearchEnvironment()
{
    int id = PromptInt("ID do ambiente: ");
    Ambiente? ambiente = cadastro.PesquisarAmbiente(id);
    if (ambiente == null)
    {
        Console.WriteLine("Ambiente não encontrado.");
        return;
    }

    Console.WriteLine($"Ambiente: {ambiente.Id} - {ambiente.Nome}");
    Console.WriteLine($"Total de logs armazenados: {ambiente.Logs.Count()}");
}

void GrantPermission()
{
    int userId = PromptInt("ID do usuário: ");
    int ambienteId = PromptInt("ID do ambiente: ");
    bool concedido = cadastro.ConcederPermissao(userId, ambienteId);
    Console.WriteLine(concedido ? "Permissão concedida." : "Falha ao conceder (IDs inválidos ou permissão já existente).");
}

void RevokePermission()
{
    int userId = PromptInt("ID do usuário: ");
    int ambienteId = PromptInt("ID do ambiente: ");
    bool revogado = cadastro.RevogarPermissao(userId, ambienteId);
    Console.WriteLine(revogado ? "Permissão revogada." : "Falha ao revogar (IDs inválidos ou permissão inexistente).");
}

void RegisterAccess()
{
    int userId = PromptInt("ID do usuário: ");
    int ambienteId = PromptInt("ID do ambiente: ");
    var result = cadastro.ProcessarAcesso(ambienteId, userId);
    if (result == null)
    {
        Console.WriteLine("Usuário ou ambiente não encontrado.");
        return;
    }

    string status = result.TipoAcesso ? "AUTORIZADO" : "NEGADO";
    Console.WriteLine($"Acesso {status} às {result.DtAcesso:dd/MM/yyyy HH:mm:ss}.");
}

void ShowLogs()
{
    int ambienteId = PromptInt("ID do ambiente: ");
    Console.WriteLine("Filtrar por:");
    Console.WriteLine("1 - Autorizados");
    Console.WriteLine("2 - Negados");
    Console.WriteLine("3 - Todos");
    Console.Write("Opção: ");
    string? input = Console.ReadLine();
    LogFilter filtro = input switch
    {
        "1" => LogFilter.Authorized,
        "2" => LogFilter.Denied,
        _ => LogFilter.All
    };

    IEnumerable<Log> logs = cadastro.ConsultarLogs(ambienteId, filtro);
    if (!logs.Any())
    {
        Console.WriteLine("Nenhum log encontrado ou ambiente inexistente.");
        return;
    }

    foreach (Log log in logs)
    {
        string status = log.TipoAcesso ? "Autorizado" : "Negado";
        Console.WriteLine($"{log.DtAcesso:dd/MM/yyyy HH:mm:ss} - {log.Usuario.Nome} ({log.Usuario.Id}) - {status}");
    }
}

int PromptInt(string message)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            return value;
        }
        Console.WriteLine("Valor inválido. Tente novamente.");
    }
}
