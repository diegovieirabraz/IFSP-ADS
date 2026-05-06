using System;
using System.Collections.Generic;

namespace PROJETO_TRANSPORTE___PILHA
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sistema = new SistemaDeTransporte();
            string opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("===== SISTEMA DE TRANSPORTE =====");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Cadastrar garagem");
                Console.WriteLine("3 - Iniciar jornada");
                Console.WriteLine("4 - Liberar viagem");
                Console.WriteLine("5 - Listar viagens");
                Console.WriteLine("6 - Encerrar jornada");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("=================================");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine() ?? string.Empty;

                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarVeiculo(sistema);
                        break;
                    case "2":
                        CadastrarGaragem(sistema);
                        break;
                    case "3":
                        IniciarJornada(sistema);
                        break;
                    case "4":
                        LiberarViagem(sistema);
                        break;
                    case "5":
                        ListarViagens(sistema);
                        break;
                    case "6":
                        EncerrarJornada(sistema);
                        break;
                    case "0":
                        Console.WriteLine("Encerrando aplicação...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (opcao != "0")
                {
                    Console.WriteLine();
                    Console.Write("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != "0");
        }

        private static void CadastrarVeiculo(SistemaDeTransporte sistema)
        {
            Console.WriteLine("=== Cadastro de Veículo ===");
            Console.Write("Informe a capacidade de passageiros: ");

            if (!int.TryParse(Console.ReadLine(), out int capacidade) || capacidade <= 0)
            {
                Console.WriteLine("Capacidade inválida.");
                return;
            }

            var veiculo = sistema.CadastrarVeiculo(capacidade);
            Console.WriteLine($"Veículo cadastrado com sucesso. ID: {veiculo.Id}");

            if (sistema.Garagens.Count == 0)
            {
                Console.WriteLine("Nenhuma garagem cadastrada ainda. Veículo ficará sem garagem.");
                return;
            }

            Console.Write("Deseja alocar o veículo em uma garagem? (S/N): ");
            var resp = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
            if (resp == "S")
            {
                Console.WriteLine("Garagens disponíveis:");
                foreach (var g in sistema.Garagens)
                    Console.WriteLine($"ID: {g.Id} - Nome: {g.Nome}");

                Console.Write("Informe o ID da garagem: ");
                if (int.TryParse(Console.ReadLine(), out int idGaragem))
                {
                    if (sistema.AlocarVeiculoEmGaragem(veiculo.Id, idGaragem, out string erro))
                        Console.WriteLine("Veículo alocado na garagem com sucesso.");
                    else
                        Console.WriteLine($"Erro ao alocar veículo: {erro}");
                }
                else
                {
                    Console.WriteLine("ID de garagem inválido. Veículo ficará sem garagem.");
                }
            }
        }

        private static void CadastrarGaragem(SistemaDeTransporte sistema)
        {
            Console.WriteLine("=== Cadastro de Garagem ===");
            Console.Write("Informe o nome da garagem: ");
            var nome = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido.");
                return;
            }

            var garagem = sistema.CadastrarGaragem(nome);
            Console.WriteLine($"Garagem cadastrada com sucesso. ID: {garagem.Id}");
        }

        private static void IniciarJornada(SistemaDeTransporte sistema)
        {
            Console.WriteLine("=== Iniciar Jornada ===");

            if (sistema.IniciarJornada())
                Console.WriteLine("Jornada iniciada com sucesso.");
            else
                Console.WriteLine("Jornada já estava iniciada.");
        }

        private static void EncerrarJornada(SistemaDeTransporte sistema)
        {
            Console.WriteLine("=== Encerrar Jornada ===");

            if (sistema.EncerrarJornada())
            {
                Console.WriteLine("Jornada encerrada com sucesso.");
                Console.WriteLine($"Total de viagens: {sistema.QuantidadeDeViagens()}");
                Console.WriteLine($"Total de passageiros transportados: {sistema.QuantidadeDePassageiros()}");
            }
            else
            {
                Console.WriteLine("Nenhuma jornada ativa para encerrar.");
            }
        }

        private static void LiberarViagem(SistemaDeTransporte sistema)
        {
            Console.WriteLine("=== Liberar Viagem ===");

            if (!sistema.JornadaIniciada)
            {
                Console.WriteLine("Jornada ainda não foi iniciada.");
                return;
            }

            if (sistema.Garagens.Count < 2)
            {
                Console.WriteLine("É necessário ter pelo menos duas garagens cadastradas.");
                return;
            }

            Console.WriteLine("Garagens disponíveis:");
            foreach (var g in sistema.Garagens)
                Console.WriteLine($"ID: {g.Id} - Nome: {g.Nome} (Veículos: {g.QuantidadeVeiculos})");

            Console.Write("Informe o ID da garagem de ORIGEM: ");
            if (!int.TryParse(Console.ReadLine(), out int idOrigem))
            {
                Console.WriteLine("ID de origem inválido.");
                return;
            }

            Console.Write("Informe o ID da garagem de DESTINO: ");
            if (!int.TryParse(Console.ReadLine(), out int idDestino))
            {
                Console.WriteLine("ID de destino inválido.");
                return;
            }

            Console.Write("Informe a quantidade de passageiros: ");
            if (!int.TryParse(Console.ReadLine(), out int passageiros) || passageiros <= 0)
            {
                Console.WriteLine("Quantidade de passageiros inválida.");
                return;
            }

            var viagem = sistema.LiberarViagem(idOrigem, idDestino, passageiros, out string erro);

            if (viagem == null)
            {
                Console.WriteLine($"Não foi possível liberar a viagem: {erro}");
                return;
            }

            Console.WriteLine("Viagem liberada com sucesso:");
            Console.WriteLine(viagem);
        }

        private static void ListarViagens(SistemaDeTransporte sistema)
        {
            Console.WriteLine("=== Lista de Viagens ===");

            var viagens = sistema.ListarViagens();
            if (viagens.Count == 0)
            {
                Console.WriteLine("Nenhuma viagem registrada.");
                return;
            }

            foreach (var v in viagens)
                Console.WriteLine(v);

            Console.WriteLine();
            Console.WriteLine($"Total de viagens: {sistema.QuantidadeDeViagens()}");
            Console.WriteLine($"Total de passageiros: {sistema.QuantidadeDePassageiros()}");
        }
    }
}
