using PROJETO_TRANSPORTE___PILHA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROJETO_TRANSPORTE___PILHA
{
    public class Garagem
    {
        private readonly Stack<Veiculo> _veiculos = new();

        public int Id { get; }
        public string Nome { get; }

        public int QuantidadeVeiculos => _veiculos.Count;

        public Garagem(int id, string nome)
        {
            Id = id;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            if (veiculo == null)
                throw new ArgumentNullException(nameof(veiculo));

            _veiculos.Push(veiculo);
        }

        // Remove veículo específico (caso esteja em alguma posição da pilha)
        public bool RemoverVeiculo(Veiculo veiculo)
        {
            if (veiculo == null)
                return false;

            if (_veiculos.Count == 0)
                return false;

            var temp = new Stack<Veiculo>();
            var removido = false;

            while (_veiculos.Count > 0)
            {
                var v = _veiculos.Pop();
                if (!removido && v == veiculo)
                {
                    removido = true;
                    continue;
                }
                temp.Push(v);
            }

            while (temp.Count > 0)
                _veiculos.Push(temp.Pop());

            return removido;
        }

        // Remove o "topo" da pilha (último que entrou)
        public Veiculo? RemoverVeiculo()
        {
            if (_veiculos.Count == 0)
                return null;

            return _veiculos.Pop();
        }

        public IEnumerable<Veiculo> ListarVeiculos()
        {
            return _veiculos.ToList();
        }

        public override string ToString()
        {
            return $"Garagem {Id} - {Nome} (Veículos: {QuantidadeVeiculos})";
        }
    }
}
