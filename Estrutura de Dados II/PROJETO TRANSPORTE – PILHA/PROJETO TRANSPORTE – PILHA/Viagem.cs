using System;

namespace PROJETO_TRANSPORTE___PILHA
{
    public class Viagem
    {
        public Garagem Origem { get; }
        public Garagem Destino { get; }
        public Veiculo Veiculo { get; }
        public int Passageiros { get; }
        public DateTime DataHora { get; }

        public Viagem(Garagem origem, Garagem destino, Veiculo veiculo, int passageiros, DateTime dataHora)
        {
            Origem = origem ?? throw new ArgumentNullException(nameof(origem));
            Destino = destino ?? throw new ArgumentNullException(nameof(destino));
            Veiculo = veiculo ?? throw new ArgumentNullException(nameof(veiculo));

            if (passageiros <= 0)
                throw new ArgumentOutOfRangeException(nameof(passageiros));

            Passageiros = passageiros;
            DataHora = dataHora;
        }

        public override string ToString()
        {
            return $"{DataHora:dd/MM/yyyy HH:mm} | Veículo {Veiculo.Id} | {Origem.Nome} -> {Destino.Nome} | Passageiros: {Passageiros}";
        }
    }
}
