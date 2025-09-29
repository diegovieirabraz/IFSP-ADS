// Arquivo: Program.cs
using Proj_Lista_Agenda;
using System;

class Program
{
    static Contatos minhaAgenda = new Contatos();

    static void Main(string[] args)
    {
        int opcao;
        do
        {
            ExibirMenu();
            // Validação de entrada
            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Digite um número.");
                Console.Write("Escolha uma opção: ");
            }

            switch (opcao)
            {
                case 1:
                    AdicionarContato();
                    break;
                case 2:
                    PesquisarContato();
                    break;
                case 3:
                    AlterarContato();
                    break;
                case 4:
                    RemoverContato();
                    break;
                case 5:
                    ListarContatos();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
            if (opcao != 0) PressioneEnterParaContinuar();

        } while (opcao != 0);
    }

    static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("| 0. Sair                            |");
        Console.WriteLine("| 1. Adicionar contato               |");
        Console.WriteLine("| 2. Pesquisar contato               |");
        Console.WriteLine("| 3. Alterar contato                 |");
        Console.WriteLine("| 4. Remover contato                 |");
        Console.WriteLine("| 5. Listar contatos                 |");
        Console.WriteLine("--------------------------------------");
        Console.Write("Escolha uma opção: ");
    }

    static void AdicionarContato()
    {
        Console.Clear();
        Console.WriteLine("--- Adicionar Novo Contato ---");

        Contato novoContato = new Contato();

        Console.Write("Email: ");
        novoContato.Email = Console.ReadLine();

        Console.Write("Nome: ");
        novoContato.Nome = Console.ReadLine();

        Console.Write("Dia de Nascimento: ");
        int dia = int.Parse(Console.ReadLine());
        Console.Write("Mês de Nascimento: ");
        int mes = int.Parse(Console.ReadLine());
        Console.Write("Ano de Nascimento: ");
        int ano = int.Parse(Console.ReadLine());
        novoContato.DtNasc.setData(dia, mes, ano);

        string adicionarOutroTelefone;
        do
        {
            Console.WriteLine("\nAdicionando Telefone:");
            Console.Write("Tipo (Celular, Casa, Trabalho): ");
            string tipo = Console.ReadLine();
            Console.Write("Número: ");
            string numero = Console.ReadLine();
            Console.Write("É o telefone principal? (S/N): ");
            bool principal = Console.ReadLine().ToUpper() == "S";

            novoContato.adicionarTelefone(new Telefone(tipo, numero, principal));

            Console.Write("\nDeseja adicionar outro telefone? (S/N): ");
            adicionarOutroTelefone = Console.ReadLine();

        } while (adicionarOutroTelefone.ToUpper() == "S");


        if (minhaAgenda.adicionar(novoContato))
        {
            Console.WriteLine("\nContato adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nErro: Já existe um contato com este email.");
        }
    }

    static void PesquisarContato()
    {
        Console.Clear();
        Console.WriteLine("--- Pesquisar Contato ---");
        Console.Write("Digite o email do contato a ser pesquisado: ");
        string email = Console.ReadLine();

        Contato contatoBusca = new Contato(email);
        Contato contatoEncontrado = minhaAgenda.pesquisar(contatoBusca);

        if (contatoEncontrado != null)
        {
            Console.WriteLine("\n--- Contato Encontrado ---");
            Console.WriteLine(contatoEncontrado.ToString());
        }
        else
        {
            Console.WriteLine("\nContato não encontrado.");
        }
    }

    static void AlterarContato()
    {
        Console.Clear();
        Console.WriteLine("--- Alterar Contato ---");
        Console.Write("Digite o email do contato que deseja alterar: ");
        string email = Console.ReadLine();

        Contato contatoParaAlterar = new Contato(email);
        Contato contatoExistente = minhaAgenda.pesquisar(contatoParaAlterar);

        if (contatoExistente == null)
        {
            Console.WriteLine("\nContato não encontrado.");
            return;
        }

        Console.WriteLine("\nDigite os novos dados (deixe em branco para não alterar):");

        Console.Write($"Novo nome ({contatoExistente.Nome}): ");
        string novoNome = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoNome))
        {
            contatoParaAlterar.Nome = novoNome;
        }
        else
        {
            contatoParaAlterar.Nome = contatoExistente.Nome;
        }

        Console.Write($"Novo dia de nascimento ({contatoExistente.DtNasc.Dia}): ");
        string novoDiaStr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoDiaStr))
        {
            contatoParaAlterar.DtNasc.Dia = int.Parse(novoDiaStr);
        }
        else
        {
            contatoParaAlterar.DtNasc.Dia = contatoExistente.DtNasc.Dia;
        }
        // ... Lógica similar para Mês e Ano ...
        contatoParaAlterar.DtNasc.Mes = contatoExistente.DtNasc.Mes;
        contatoParaAlterar.DtNasc.Ano = contatoExistente.DtNasc.Ano;


        if (minhaAgenda.alterar(contatoParaAlterar))
        {
            Console.WriteLine("\nContato alterado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nErro ao alterar o contato.");
        }
    }

    static void RemoverContato()
    {
        Console.Clear();
        Console.WriteLine("--- Remover Contato ---");
        Console.Write("Digite o email do contato a ser removido: ");
        string email = Console.ReadLine();

        Contato contatoParaRemover = new Contato(email);

        if (minhaAgenda.remover(contatoParaRemover))
        {
            Console.WriteLine("\nContato removido com sucesso!");
        }
        else
        {
            Console.WriteLine("\nContato não encontrado.");
        }
    }

    static void ListarContatos()
    {
        Console.Clear();
        Console.WriteLine("--- Lista de Contatos ---");

        if (minhaAgenda.Agenda.Count == 0)
        {
            Console.WriteLine("Nenhum contato na agenda.");
        }
        else
        {
            foreach (Contato contato in minhaAgenda.Agenda)
            {
                Console.WriteLine(contato.ToString());
                Console.WriteLine("--------------------");
            }
        }
    }

    static void PressioneEnterParaContinuar()
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
    }
}