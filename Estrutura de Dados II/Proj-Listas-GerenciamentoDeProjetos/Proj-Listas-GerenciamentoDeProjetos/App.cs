using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_Listas_GerenciamentoDeProjetos
{
    public static class App
    {
        private static readonly Projetos _repo = new();
        private static int _seqProjeto = 1;
        private static int _seqTarefa = 1;

        public static void Run()
        {
            while (true)
            {
                MostrarMenu();
                Console.Write("Opção: ");
                var opc = Console.ReadLine();

                try
                {
                    switch (opc)
                    {
                        case "0": return;
                        case "1": AdicionarProjeto(); break;
                        case "2": PesquisarProjetoMostrarTarefasEPorStatus(); break;
                        case "3": RemoverProjetoSeSemTarefas(); break;
                        case "4": AdicionarTarefaEmProjeto(); break;
                        case "5": AlterarStatusTarefaEmProjeto("Fechada"); break;
                        case "6": AlterarStatusTarefaEmProjeto("Cancelada"); break;
                        case "7": AlterarStatusTarefaEmProjeto("Aberta"); break;
                        case "8": ListarTarefasDeProjeto(); break;
                        case "9": FiltrarEmProjeto(); break;
                        case "10": FiltrarEmTodosProjetos(); break;
                        case "11": ResumoGeral(); break;
                        default: Console.WriteLine("Opção inválida."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }

                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        private static void MostrarMenu()
        {
            Console.Clear();

            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar projeto");
            Console.WriteLine("2. Pesquisar projeto (mostrar tarefas por status e totais)");
            Console.WriteLine("3. Remover projeto (apenas se sem tarefas)");
            Console.WriteLine("4. Adicionar tarefa em projeto");
            Console.WriteLine("5. Concluir tarefa");
            Console.WriteLine("6. Cancelar tarefa");
            Console.WriteLine("7. Reabrir tarefa");
            Console.WriteLine("8. Listar tarefas de um projeto");
            Console.WriteLine("9. Filtrar tarefas por status ou prioridade em um projeto");
            Console.WriteLine("10. Filtrar tarefas por status ou prioridade em TODOS os projetos");
            Console.WriteLine("11. Resumo geral");

        }

        #region Helpers de Entrada

        private static int LerInt(string prompt, Func<int, bool>? validar = null, string? msgErro = null)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (int.TryParse(s, out var v) && (validar == null || validar(v)))
                    return v;
                Console.WriteLine(msgErro ?? "Valor inválido. Tente novamente.");
            }
        }

        private static string LerStringObrigatoria(string prompt, int maxLen = 200)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrWhiteSpace(s) && s.Length <= maxLen) return s;
                Console.WriteLine("Valor inválido.");
            }
        }

        private static int LerPrioridade()
        {
            Console.WriteLine("Prioridade: 1 = Alta, 2 = Média, 3 = Baixa");
            return LerInt("Informe a prioridade: ", v => v is 1 or 2 or 3, "Use 1, 2 ou 3.");
        }

        private static string LerStatus()
        {
            Console.WriteLine("Status: Aberta | Fechada | Cancelada");
            while (true)
            {
                Console.Write("Informe o status: ");
                var s = (Console.ReadLine() ?? "").Trim();
                if (new[] { "Aberta", "Fechada", "Cancelada" }.Contains(s, StringComparer.OrdinalIgnoreCase))
                    return CultureStatus(s);
                Console.WriteLine("Status inválido.");
            }

            static string CultureStatus(string s)
            {
                s = s.ToLower();
                if (s == "aberta") return "Aberta";
                if (s == "fechada") return "Fechada";
                return "Cancelada";
            }
        }

        private static Projeto? SelecionarProjeto()
        {
            if (!_repo.Itens.Any())
            {
                Console.WriteLine("Não há projetos cadastrados.");
                return null;
            }

            Console.WriteLine("\nProjetos existentes:");
            foreach (var p in _repo.Itens)
                Console.WriteLine(p);

            var id = LerInt("Informe o ID do projeto: ");
            var proj = _repo.Buscar(id);
            if (proj == null) Console.WriteLine("Projeto não encontrado.");
            return proj;
        }

        private static Tarefa? SelecionarTarefa(Projeto proj)
        {
            if (!proj.Tarefas.Any())
            {
                Console.WriteLine("Projeto não possui tarefas.");
                return null;
            }

            Console.WriteLine($"\nTarefas do projeto #{proj.Id} - {proj.Nome}:");
            foreach (var t in proj.Tarefas.OrderBy(t => t.Id))
                Console.WriteLine(t);

            var id = LerInt("Informe o ID da tarefa: ");
            var tarefa = proj.BuscarTarefa(id);
            if (tarefa == null) Console.WriteLine("Tarefa não encontrada.");
            return tarefa;
        }

        #endregion

        #region Opções

        private static void AdicionarProjeto()
        {
            var nome = LerStringObrigatoria("Nome do projeto: ", 120);
            var p = new Projeto(_seqProjeto++, nome);
            _repo.Adicionar(p);
            Console.WriteLine($"Projeto criado: {p}");
        }

        private static void PesquisarProjetoMostrarTarefasEPorStatus()
        {
            var proj = SelecionarProjeto();
            if (proj == null) return;

            Console.WriteLine($"\n{proj}");

            void MostrarPor(string status)
            {
                var lista = proj.TarefasPorStatus(status);
                Console.WriteLine($"\nTarefas [{status}] ({lista.Count}):");
                foreach (var t in lista) Console.WriteLine(t);
            }

            MostrarPor("Aberta");
            MostrarPor("Fechada");
            MostrarPor("Cancelada");
        }

        private static void RemoverProjetoSeSemTarefas()
        {
            var proj = SelecionarProjeto();
            if (proj == null) return;

            if (proj.Tarefas.Any())
            {
                Console.WriteLine("Não é possível remover: projeto possui tarefas.");
                return;
            }

            var ok = _repo.Remover(proj);
            Console.WriteLine(ok ? "Projeto removido." : "Não foi possível remover.");
        }

        private static void AdicionarTarefaEmProjeto()
        {
            var proj = SelecionarProjeto();
            if (proj == null) return;

            var titulo = LerStringObrigatoria("Título: ", 120);
            var descricao = LerStringObrigatoria("Descrição: ", 400);
            var prioridade = LerPrioridade();

            var tarefa = new Tarefa(_seqTarefa++, titulo, descricao, prioridade);
            proj.AdicionarTarefa(tarefa);
            Console.WriteLine($"Tarefa adicionada: {tarefa}");
        }

        private static void AlterarStatusTarefaEmProjeto(string alvo)
        {
            var proj = SelecionarProjeto();
            if (proj == null) return;

            var tarefa = SelecionarTarefa(proj);
            if (tarefa == null) return;

            switch (alvo)
            {
                case "Fechada": tarefa.Concluir(); break;
                case "Cancelada": tarefa.Cancelar(); break;
                case "Aberta": tarefa.Reabrir(); break;
            }

            Console.WriteLine($"Tarefa atualizada: {tarefa}");
        }

        private static void ListarTarefasDeProjeto()
        {
            var proj = SelecionarProjeto();
            if (proj == null) return;

            if (!proj.Tarefas.Any())
            {
                Console.WriteLine("Sem tarefas.");
                return;
            }

            Console.WriteLine($"\nTarefas do projeto #{proj.Id} - {proj.Nome}:");
            foreach (var t in proj.Tarefas.OrderBy(t => t.Id))
                Console.WriteLine(t);
        }

        private static void FiltrarEmProjeto()
        {
            var proj = SelecionarProjeto();
            if (proj == null) return;

            Console.WriteLine("Filtrar por: 1) Status  2) Prioridade");
            var tipo = LerInt("Opção: ", v => v is 1 or 2, "Escolha 1 ou 2.");

            List<Tarefa> resultado;
            if (tipo == 1)
            {
                var status = LerStatus();
                resultado = proj.TarefasPorStatus(status);
                Console.WriteLine($"\nTarefas do projeto filtradas por status [{status}] ({resultado.Count}):");
            }
            else
            {
                var prioridade = LerPrioridade();
                resultado = proj.TarefasPorPrioridade(prioridade);
                var priTxt = prioridade switch { 1 => "Alta", 2 => "Média", 3 => "Baixa", _ => "?" };
                Console.WriteLine($"\nTarefas do projeto filtradas por prioridade [{priTxt}] ({resultado.Count}):");
            }

            foreach (var t in resultado) Console.WriteLine(t);
        }

        private static void FiltrarEmTodosProjetos()
        {
            if (!_repo.Itens.Any())
            {
                Console.WriteLine("Não há projetos.");
                return;
            }

            Console.WriteLine("Filtrar em TODOS os projetos por: 1) Status  2) Prioridade");
            var tipo = LerInt("Opção: ", v => v is 1 or 2, "Escolha 1 ou 2.");

            IEnumerable<Tarefa> resultado;
            if (tipo == 1)
            {
                var status = LerStatus();
                resultado = _repo.Itens.SelectMany(p => p.Tarefas).Where(t => t.Status == status);
                Console.WriteLine($"\nTarefas (TODOS os projetos) por status [{status}]:");
            }
            else
            {
                var prioridade = LerPrioridade();
                resultado = _repo.Itens.SelectMany(p => p.Tarefas).Where(t => t.Prioridade == prioridade);
                var priTxt = prioridade switch { 1 => "Alta", 2 => "Média", 3 => "Baixa", _ => "?" };
                Console.WriteLine($"\nTarefas (TODOS os projetos) por prioridade [{priTxt}]:");
            }

            foreach (var t in resultado) Console.WriteLine(t);
        }

        private static void ResumoGeral()
        {
            var projetos = _repo.Listar();
            var totalProjetos = projetos.Count;
            var todasTarefas = projetos.SelectMany(p => p.Tarefas).ToList();

            var abertas = todasTarefas.Count(t => t.Status == "Aberta");
            var fechadas = todasTarefas.Count(t => t.Status == "Fechada");
            var canceladas = todasTarefas.Count(t => t.Status == "Cancelada");

            // % concluídas em relação às abertas+fechadas (ignorando canceladas)
            var baseCalculo = abertas + fechadas;
            var percConcluidas = baseCalculo == 0 ? 0 : (fechadas * 100.0 / baseCalculo);

            Console.WriteLine("\n===== RESUMO GERAL =====");
            Console.WriteLine($"Projetos: {totalProjetos}");
            Console.WriteLine($"Tarefas Abertas: {abertas}");
            Console.WriteLine($"Tarefas Fechadas: {fechadas}");
            Console.WriteLine($"Tarefas Canceladas: {canceladas}");
            Console.WriteLine($"% Concluídas (sobre Abertas+Fechadas): {percConcluidas:0.00}%");
        }

        #endregion
    }
}
