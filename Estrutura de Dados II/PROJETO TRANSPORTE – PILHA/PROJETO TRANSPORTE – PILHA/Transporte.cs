using System;
using System.Collections.Generic;
using System.Linq;
using PROJETO_TRANSPORTE___PILHA;
namespace PROJETO_TRANSPORTE___PILHA
{
    public class Transporte
    {
        // Listas principais de dados
        public List<Veiculo> Frota { get; private set; }
        public List<Garagem> Garagens { get; private set; }
        public List<Viagem> Viagens { get; private set; }

        // Controle de estado
        public bool JornadaAtiva { get; private set; }

        public Transporte()
        {
            Frota = new List<Veiculo>();
            Garagens = new List<Garagem>();
            Viagens = new List<Viagem>();
            JornadaAtiva = false;
        }

        // --- MÉTODOS DE CADASTRO (Opções 1 e 2) ---
        public void CadastrarVeiculo(Veiculo v)
        {
            if (JornadaAtiva)
            {
                Console.WriteLine("Erro: Não é possível cadastrar veículos com a jornada ativa.");
                return;
            }
            Frota.Add(v);
            Console.WriteLine($"Veículo {v.Id} cadastrado com sucesso.");
        }

        public void CadastrarGaragem(Garagem g)
        {
            if (JornadaAtiva)
            {
                Console.WriteLine("Erro: Não é possível cadastrar garagens com a jornada ativa.");
                return;
            }
            Garagens.Add(g);
            Console.WriteLine($"Garagem {g.Nome} cadastrada com sucesso.");
        }

        // --- INICIAR JORNADA (Opção 3) ---
        public void IniciarJornada()
        {
            if (JornadaAtiva)
            {
                Console.WriteLine("A jornada já está iniciada.");
                return;
            }

            if (Garagens.Count == 0 || Frota.Count == 0)
            {
                Console.WriteLine("Erro: É necessário ter garagens e veículos cadastrados.");
                return;
            }

            // Lógica de Distribuição Alternada:
            // Percorre a frota e joga um carro em cada garagem sequencialmente
            // Ex: Carro 1 -> G1, Carro 2 -> G2, Carro 3 -> G1...
            for (int i = 0; i < Frota.Count; i++)
            {
                // O operador % (resto da divisão) faz o índice girar entre 0 e o total de garagens
                int indiceGaragem = i % Garagens.Count;
                Garagens[indiceGaragem].Estacionar(Frota[i]);
            }

            JornadaAtiva = true;
            Console.WriteLine("Jornada iniciada! Veículos distribuídos nas garagens.");
        }

        // --- ENCERRAR JORNADA (Opção 4) ---
        public void EncerrarJornada()
        {
            if (!JornadaAtiva)
            {
                Console.WriteLine("A jornada não está ativa.");
                return;
            }

            Console.WriteLine("--- RELATÓRIO DE ENCERRAMENTO ---");
            foreach (var veiculo in Frota)
            {
                Console.WriteLine($"Veículo {veiculo.Id}: Transportou {veiculo.TotalPassageirosTransportados} passageiros hoje.");
                // "Limpeza" para o dia seguinte
                veiculo.IniciarDia();
            }

            // Limpar as pilhas das garagens (todos devem sair para serem redistribuídos amanhã)
            foreach (var garagem in Garagens)
            {
                while (garagem.QtdeVeiculos() > 0)
                {
                    garagem.Sair(); // Esvazia a pilha
                }
            }

            // Limpar histórico de viagens do dia
            Viagens.Clear();

            JornadaAtiva = false;
            Console.WriteLine("--- Jornada Encerrada ---");
        }

        // --- LIBERAR VIAGEM (Opção 5) ---
        public bool RealizarViagem(Garagem origem, Garagem destino, int qtdePassageiros)
        {
            if (!JornadaAtiva)
            {
                Console.WriteLine("Erro: Inicie a jornada primeiro.");
                return false;
            }

            if (origem == destino)
            {
                Console.WriteLine("Erro: Origem e destino são iguais.");
                return false;
            }

            // Tenta tirar o carro da pilha de origem (POP)
            Veiculo veiculo = origem.Sair();

            if (veiculo == null)
            {
                Console.WriteLine($"Não há veículos disponíveis em {origem.Nome}.");
                return false;
            }

            if (qtdePassageiros > veiculo.Lotacao)
            {
                Console.WriteLine($"Erro: Lotação excedida. O veículo comporta apenas {veiculo.Lotacao}.");
                // Devolve o veículo para a origem (Desfaz o POP) pois a viagem falhou
                origem.Estacionar(veiculo);
                return false;
            }

            // Processa a viagem
            veiculo.RegistrarViagem(qtdePassageiros);

            // **IMPORTANTE**: O carro chega no destino (PUSH)
            destino.Estacionar(veiculo);

            // Registra no histórico
            int idViagem = Viagens.Count + 1;
            Viagens.Add(new Viagem(idViagem, origem, destino, veiculo, qtdePassageiros));

            Console.WriteLine($"Viagem registrada: Veículo {veiculo.Id} foi de {origem.Nome} para {destino.Nome}.");
            return true;
        }

        // --- MÉTODOS DE CONSULTA (Opções 6, 7, 8, 9) ---

        // Opção 6: Listar veículos em determinada garagem
        public void ListarVeiculosNaGaragem(Garagem g)
        {
            Console.WriteLine($"Garagem {g.Nome} - Total: {g.QtdeVeiculos()} | Potencial: {g.PotencialDeTransporte()}");
            var lista = g.ListarVeiculos();

            if (lista.Count == 0) Console.WriteLine("(Vazia)");

            foreach (var v in lista)
            {
                Console.WriteLine($" - Veículo {v.Id} (Cap: {v.Lotacao})");
            }
        }

        // Opção 7 e 9: Quantidade de viagens ou passageiros de origem X para destino Y
        // Se 'somarPassageiros' for true, retorna total de passageiros (Opção 9)
        // Se for false, retorna quantidade de viagens (Opção 7)
        public int InformarEstatisticasViagem(Garagem origem, Garagem destino, bool somarPassageiros)
        {
            // Usando LINQ para filtrar a lista de viagens
            var viagensFiltradas = Viagens.Where(v => v.Origem == origem && v.Destino == destino).ToList();

            if (somarPassageiros)
            {
                return viagensFiltradas.Sum(v => v.QtdePassageiros);
            }
            else
            {
                return viagensFiltradas.Count;
            }
        }

        // Opção 8: Listar detalhes das viagens de origem X para destino Y
        public void ListarViagensPorRota(Garagem origem, Garagem destino)
        {
            var viagensFiltradas = Viagens.Where(v => v.Origem == origem && v.Destino == destino).ToList();

            Console.WriteLine($"--- Viagens de {origem.Nome} para {destino.Nome} ---");
            if (viagensFiltradas.Count == 0) Console.WriteLine("Nenhuma viagem registrada nesta rota.");

            foreach (var v in viagensFiltradas)
            {
                Console.WriteLine(v.ToString());
            }
        }
    }
}
