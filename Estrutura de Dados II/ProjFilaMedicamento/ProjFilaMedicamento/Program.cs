using ProjFilaMedicamento;
class Program
{
    static void Main(string[] args)
    {
        Medicamentos medicamentos = new Medicamentos();
        int opcao;

        do
        {
            Console.WriteLine("\n=== MENU MEDICAMENTOS ===");
            Console.WriteLine("0 - Finalizar processo");
            Console.WriteLine("1 - Cadastrar medicamento");
            Console.WriteLine("2 - Consultar medicamento (sintético)");
            Console.WriteLine("3 - Consultar medicamento (analítico)");
            Console.WriteLine("4 - Comprar medicamento (cadastrar lote)");
            Console.WriteLine("5 - Vender medicamento (abater do lote mais antigo)");
            Console.WriteLine("6 - Listar medicamentos (sintético)");
            Console.Write("Escolha uma opção: ");

            int.TryParse(Console.ReadLine(), out opcao);
            Console.WriteLine();

            switch (opcao)
            {
                case 0:
                    Console.WriteLine("Finalizando...");
                    break;

                case 1:
                    CadastrarMedicamento(medicamentos);
                    break;

                case 2:
                    ConsultarSintetico(medicamentos);
                    break;

                case 3:
                    ConsultarAnalitico(medicamentos);
                    break;

                case 4:
                    ComprarLote(medicamentos);
                    break;

                case 5:
                    VenderMedicamento(medicamentos);
                    break;

                case 6:
                    ListarSintetico(medicamentos);
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        } while (opcao != 0);
    }

    // ======= Funções de menu =======

    static void CadastrarMedicamento(Medicamentos medicamentos)
    {
        Console.Write("ID do medicamento: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Laboratório: ");
        string lab = Console.ReadLine() ?? string.Empty;

        var med = new Medicamentos(id, nome, lab);
        medicamentos.Adicionar(med);

        Console.WriteLine("Medicamento cadastrado.");
    }

    static void ConsultarSintetico(Medicamentos medicamentos)
    {
        Console.Write("Informe o ID do medicamento: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        var med = medicamentos.PesquisarPorId(id);

        if (med.Id == 0)
        {
            Console.WriteLine("Medicamento não encontrado.");
        }
        else
        {
            Console.WriteLine("Dados (sintético):");
            Console.WriteLine(med.ToString());
        }
    }

    static void ConsultarAnalitico(Medicamentos medicamentos)
    {
        Console.Write("Informe o ID do medicamento: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        var med = medicamentos.PesquisarPorId(id);

        if (med.Id == 0)
        {
            Console.WriteLine("Medicamento não encontrado.");
            return;
        }

        Console.WriteLine("Dados do medicamento:");
        Console.WriteLine(med.ToString());

        Console.WriteLine("Lotes:");
        if (med.Lotes.Count == 0)
        {
            Console.WriteLine("Nenhum lote cadastrado.");
        }
        else
        {
            foreach (var lote in med.Lotes)
                Console.WriteLine(lote.ToString());
        }
    }

    static void ComprarLote(Medicamentos medicamentos)
    {
        Console.Write("ID do medicamento: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        var med = medicamentos.PesquisarPorId(id);

        if (med.Id == 0)
        {
            Console.WriteLine("Medicamento não encontrado.");
            return;
        }

        Console.Write("ID do lote: ");
        int idLote = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Quantidade: ");
        int qtde = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Data vencimento (dd/MM/yyyy): ");
        DateTime venc = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("dd/MM/yyyy"));

        var lote = new Lote(idLote, qtde, venc);
        med.Comprar(lote);

        Console.WriteLine("Lote cadastrado.");
    }

    static void VenderMedicamento(Medicamentos medicamentos)
    {
        Console.Write("ID do medicamento: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        var med = medicamentos.PesquisarPorId(id);

        if (med.Id == 0)
        {
            Console.WriteLine("Medicamento não encontrado.");
            return;
        }

        Console.Write("Quantidade a vender: ");
        int qtde = int.Parse(Console.ReadLine() ?? "0");

        bool sucesso = med.Vender(qtde);

        if (sucesso)
            Console.WriteLine("Venda realizada com sucesso.");
        else
            Console.WriteLine("Não há quantidade suficiente para venda.");
    }

    static void ListarSintetico(Medicamentos medicamentos)
    {
        var lista = medicamentos.ListarTodos();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum medicamento cadastrado.");
            return;
        }

        Console.WriteLine("Lista de medicamentos (sintético):");
        foreach (var med in lista)
        {
            Console.WriteLine(med.ToString());