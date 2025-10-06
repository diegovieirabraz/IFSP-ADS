using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BibliotecaConsole
{

    public class Emprestimo
    {
        public DateTime dtEmprestimo { get; set; }
        public DateTime? dtDevolucao { get; set; }

        public Emprestimo(DateTime emprestimo, DateTime? devolucao = null)
        {
            dtEmprestimo = emprestimo;
            dtDevolucao = devolucao;
        }

        public bool EstaAberto() => !dtDevolucao.HasValue;
        public override string ToString()
        {
            var dev = dtDevolucao.HasValue ? dtDevolucao.Value.ToString("dd/MM/yyyy HH:mm") : "(em aberto)";
            return $"Emp.: {dtEmprestimo:dd/MM/yyyy HH:mm} | Dev.: {dev}";
        }
    }


    public class Exemplar
    {
        public int tombo { get; private set; }
        public List<Emprestimo> emprestimos { get; private set; } = new();

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
        }

        public bool disponivel()
        {
            // disponível se não houver empréstimo em aberto
            return !emprestimos.Any(e => e.EstaAberto());
        }

        public int qtdeEmprestimos() => emprestimos.Count;

        public bool emprestar()
        {
            if (!disponivel()) return false;
            emprestimos.Add(new Emprestimo(DateTime.Now));
            return true;
        }

        public bool devolver()
        {
            var aberto = emprestimos.LastOrDefault(e => e.EstaAberto());
            if (aberto == null) return false;
            aberto.dtDevolucao = DateTime.Now;
            return true;
        }

        public override string ToString()
        {
            var status = disponivel() ? "Disponível" : "Emprestado";
            return $"Tombo: {tombo} | Status: {status} | Empréstimos: {qtdeEmprestimos()}";
        }
    }

    public class Livro
    {
        public int isbn { get; private set; }
        public string titulo { get; private set; }
        public string autor { get; private set; }
        public string editora { get; private set; }
        public List<Exemplar> exemplares { get; private set; } = new();

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
        }

        public void adicionarExemplar(Exemplar exemplar)
        {
            // evita tombo duplicado neste livro
            if (exemplares.Any(e => e.tombo == exemplar.tombo))
                throw new InvalidOperationException($"Já existe um exemplar com tombo {exemplar.tombo} para este livro.");
            exemplares.Add(exemplar);
        }

        public int qtdeExemplares() => exemplares.Count;

        public int qtdeDisponiveis() => exemplares.Count(e => e.disponivel());

        public int qtdeEmprestimos() => exemplares.Sum(e => e.qtdeEmprestimos());

        public double percDisponibilidade()
        {
            var total = qtdeExemplares();
            if (total == 0) return 0.0;
            return (double)qtdeDisponiveis() / total * 100.0;
        }

        public override string ToString()
        {
            return $"ISBN: {isbn} | Título: {titulo} | Autor: {autor} | Editora: {editora}";
        }
    }

   
    public class Livros
    {
        public List<Livro> acervo { get; private set; } = new();

        public void adicionar(Livro livro)
        {
            if (acervo.Any(l => l.isbn == livro.isbn))
                throw new InvalidOperationException($"Já existe um livro com ISBN {livro.isbn} no acervo.");
            acervo.Add(livro);
        }

        // pesquisar por "igualdade" simplificada: aqui buscamos por ISBN
        public Livro pesquisar(int isbn) => acervo.FirstOrDefault(l => l.isbn == isbn);

        // utilitário: por título (contém)
        public IEnumerable<Livro> pesquisarPorTitulo(string trecho)
            => acervo.Where(l => l.titulo.Contains(trecho, StringComparison.InvariantCultureIgnoreCase));
    }

    
    class Program
    {
        static readonly Livros biblioteca = new();

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            while (true)
            {
                MostrarMenu();
                Console.Write("Escolha: ");
                var opcao = Console.ReadLine();

                try
                {
                    switch (opcao)
                    {
                        case "0":
                            Console.WriteLine("Saindo...");
                            return;

                        case "1":
                            OpcaoAdicionarLivro();
                            break;

                        case "2":
                            OpcaoPesquisarLivroSintetico();
                            break;

                        case "3":
                            OpcaoPesquisarLivroAnalitico();
                            break;

                        case "4":
                            OpcaoAdicionarExemplar();
                            break;

                        case "5":
                            OpcaoRegistrarEmprestimo();
                            break;

                        case "6":
                            OpcaoRegistrarDevolucao();
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }

                Pausar();
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("| 0. Sair                            |");
            Console.WriteLine("| 1. Adicionar livro                 |");
            Console.WriteLine("| 2. Pesquisar livro (sintético)     |");
            Console.WriteLine("| 3. Pesquisar livro (analítico)     |");
            Console.WriteLine("| 4. Adicionar exemplar              |");
            Console.WriteLine("| 5. Registrar empréstimo            |");
            Console.WriteLine("| 6. Registrar devolução             |");
            Console.WriteLine("--------------------------------------");
        }

        
        static void OpcaoAdicionarLivro()
        {
            Console.WriteLine("=== Adicionar Livro ===");
            int isbn = LerInt("ISBN: ");
            string titulo = LerObrigatorio("Título: ");
            string autor = LerObrigatorio("Autor: ");
            string editora = LerObrigatorio("Editora: ");

            var livro = new Livro(isbn, titulo, autor, editora);
            biblioteca.adicionar(livro);

            Console.WriteLine("Livro adicionado com sucesso.");
        }

        
        static void OpcaoPesquisarLivroSintetico()
        {
            Console.WriteLine("=== Pesquisar Livro (Sintético) ===");
            int isbn = LerInt("Informe o ISBN: ");
            var livro = biblioteca.pesquisar(isbn);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            MostrarResumoLivro(livro);
        }

        static void OpcaoPesquisarLivroAnalitico()
        {
            Console.WriteLine("=== Pesquisar Livro (Analítico) ===");
            int isbn = LerInt("Informe o ISBN: ");
            var livro = biblioteca.pesquisar(isbn);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            MostrarResumoLivro(livro);
            Console.WriteLine("\n-- Exemplares --");
            if (livro.exemplares.Count == 0)
            {
                Console.WriteLine("Nenhum exemplar cadastrado.");
            }
            else
            {
                foreach (var ex in livro.exemplares.OrderBy(e => e.tombo))
                {
                    Console.WriteLine(ex.ToString());
                    if (ex.emprestimos.Count == 0)
                    {
                        Console.WriteLine("   (Sem histórico de empréstimos)");
                    }
                    else
                    {
                        foreach (var emp in ex.emprestimos)
                        {
                            Console.WriteLine("   - " + emp.ToString());
                        }
                    }
                }
            }
        }

        static void OpcaoAdicionarExemplar()
        {
            Console.WriteLine("=== Adicionar Exemplar ===");
            int isbn = LerInt("ISBN do livro: ");
            var livro = biblioteca.pesquisar(isbn);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            int tombo = LerInt("Tombo do exemplar: ");
            livro.adicionarExemplar(new Exemplar(tombo));
            Console.WriteLine("Exemplar adicionado com sucesso.");
        }

       
        static void OpcaoRegistrarEmprestimo()
        {
            Console.WriteLine("=== Registrar Empréstimo ===");
            int isbn = LerInt("ISBN do livro: ");
            var livro = biblioteca.pesquisar(isbn);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            if (livro.qtdeDisponiveis() == 0)
            {
                Console.WriteLine("Não há exemplares disponíveis para empréstimo.");
                return;
            }

            int tombo = LerInt("Tombo do exemplar: ");
            var ex = livro.exemplares.FirstOrDefault(e => e.tombo == tombo);
            if (ex == null)
            {
                Console.WriteLine("Exemplar não encontrado.");
                return;
            }

            if (ex.emprestar())
                Console.WriteLine("Empréstimo registrado com sucesso.");
            else
                Console.WriteLine("Exemplar não está disponível.");
        }

    
        static void OpcaoRegistrarDevolucao()
        {
            Console.WriteLine("=== Registrar Devolução ===");
            int isbn = LerInt("ISBN do livro: ");
            var livro = biblioteca.pesquisar(isbn);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            int tombo = LerInt("Tombo do exemplar: ");
            var ex = livro.exemplares.FirstOrDefault(e => e.tombo == tombo);
            if (ex == null)
            {
                Console.WriteLine("Exemplar não encontrado.");
                return;
            }

            if (ex.devolver())
                Console.WriteLine("Devolução registrada com sucesso.");
            else
                Console.WriteLine("Não há empréstimo em aberto para este exemplar.");
        }

        // Utilitários UI
        static void MostrarResumoLivro(Livro livro)
        {
            Console.WriteLine(livro.ToString());
            Console.WriteLine($"Total de exemplares: {livro.qtdeExemplares()}");
            Console.WriteLine($"Exemplares disponíveis: {livro.qtdeDisponiveis()}");
            Console.WriteLine($"Total de empréstimos: {livro.qtdeEmprestimos()}");
            Console.WriteLine($"% Disponibilidade: {livro.percDisponibilidade():0.##}%");
        }

        static int LerInt(string rotulo)
        {
            while (true)
            {
                Console.Write(rotulo);
                var s = Console.ReadLine();
                if (int.TryParse(s, out int valor)) return valor;
                Console.WriteLine("Valor inválido. Tente novamente.");
            }
        }

        static string LerObrigatorio(string rotulo)
        {
            while (true)
            {
                Console.Write(rotulo);
                var s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
                Console.WriteLine("Campo obrigatório.");
            }
        }

        static void Pausar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
