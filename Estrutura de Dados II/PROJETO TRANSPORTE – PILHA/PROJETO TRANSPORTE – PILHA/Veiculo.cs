using System;

namespace PROJETO_TRANSPORTE___PILHA
{
    public class Veiculo
    {
        public int Id { get; }
        public int Capacidade { get; }
        public int QtdeTotalPassageiros { get; private set; }
        public bool EmViagem { get; private set; }

        public Veiculo(int id, int capacidade)
        {
            if (capacidade <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacidade), "Capacidade deve ser maior que zero.");

            Id = id;
            Capacidade = capacidade;
            QtdeTotalPassageiros = 0;
            EmViagem = false;
        }

        public void IniciarViagem(int passageiros)
        {
            if (EmViagem)
                throw new InvalidOperationException("Veículo já está em viagem.");

            if (passageiros <= 0)
                throw new ArgumentOutOfRangeException(nameof(passageiros), "Passageiros deve ser maior que zero.");

            if (passageiros > Capacidade)
                throw new InvalidOperationException("Quantidade de passageiros excede a capacidade do veículo.");

            EmViagem = true;
            QtdeTotalPassageiros += passageiros;
        }

        public void FinalizarViagem()
        {
            if (!EmViagem)
                return;

            EmViagem = false;
        }

        public override string ToString()
        {
            return $"Veículo {Id} - Capacidade: {Capacidade}, Total de passageiros transportados: {QtdeTotalPassageiros}";
        }
    }
}
