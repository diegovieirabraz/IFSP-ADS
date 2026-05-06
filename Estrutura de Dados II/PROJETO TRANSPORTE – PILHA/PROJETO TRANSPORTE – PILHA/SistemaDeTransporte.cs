using PROJETO_TRANSPORTE___PILHA;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROJETO_TRANSPORTE___PILHA
{
    public class SistemaDeTransporte
    {
        private readonly List<Veiculo> _veiculos = new();
        private readonly List<Garagem> _garagens = new();
        private readonly List<Viagem> _viagens = new();

        private int _proximoIdVeiculo = 1;
        private int _proximoIdGaragem = 1;

        public bool JornadaIniciada { get; private set; }

        public IReadOnlyList<Veiculo> Veiculos => _veiculos;
        public IReadOnlyList<Garagem> Garagens => _garagens;
        public IReadOnlyList<Viagem> Viagens => _viagens;

        public Veiculo CadastrarVeiculo(int capacidade)
        {
            var veiculo = new Veiculo(_proximoIdVeiculo++, capacidade);
            _veiculos.Add(veiculo);
            return veiculo;
        }

        public Garagem CadastrarGaragem(string nome)
        {
            var garagem = new Garagem(_proximoIdGaragem++, nome);
            _garagens.Add(garagem);
            return garagem;
        }

        public bool IniciarJornada()
        {
            if (JornadaIniciada)
                return false;

            JornadaIniciada = true;
            return true;
        }

        public bool EncerrarJornada()
        {
            if (!JornadaIniciada)
                return false;

            JornadaIniciada = false;
            return true;
        }

        public bool AlocarVeiculoEmGaragem(int idVeiculo, int idGaragem, out string erro)
        {
            erro = string.Empty;

            var veiculo = _veiculos.FirstOrDefault(v => v.Id == idVeiculo);
            if (veiculo == null)
            {
                erro = "Veículo não encontrado.";
                return false;
            }

            var garagem = _garagens.FirstOrDefault(g => g.Id == idGaragem);
            if (garagem == null)
            {
                erro = "Garagem não encontrada.";
                return false;
            }

            // remove de qualquer outra garagem
            foreach (var g in _garagens)
                g.RemoverVeiculo(veiculo);

            garagem.AdicionarVeiculo(veiculo);
            return true;
        }

        public Viagem? LiberarViagem(int idGaragemOrigem, int idGaragemDestino, int passageiros, out string erro)
        {
            erro = string.Empty;

            if (!JornadaIniciada)
            {
                erro = "Jornada não iniciada.";
                return null;
            }

            var origem = _garagens.FirstOrDefault(g => g.Id == idGaragemOrigem);
            if (origem == null)
            {
                erro = "Garagem de origem não encontrada.";
                return null;
            }

            var destino = _garagens.FirstOrDefault(g => g.Id == idGaragemDestino);
            if (destino == null)
            {
                erro = "Garagem de destino não encontrada.";
                return null;
            }

            if (origem.QuantidadeVeiculos == 0)
            {
                erro = "Não há veículos disponíveis na garagem de origem.";
                return null;
            }

            // Pega o último veículo que entrou na garagem (Stack)
            var veiculo = origem.RemoverVeiculo();
            if (veiculo == null)
            {
                erro = "Falha ao obter veículo da garagem.";
                return null;
            }

            try
            {
                veiculo.IniciarViagem(passageiros);
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                // devolve o veículo para a garagem de origem
                origem.AdicionarVeiculo(veiculo);
                return null;
            }

            var viagem = new Viagem(origem, destino, veiculo, passageiros, DateTime.Now);
            _viagens.Add(viagem);

            // Para simplificar o modelo, consideramos a viagem "instantânea"
            veiculo.FinalizarViagem();
            destino.AdicionarVeiculo(veiculo);

            return viagem;
        }

        public List<Viagem> ListarViagens()
        {
            return _viagens.ToList();
        }

        public int QuantidadeDeViagens()
        {
            return _viagens.Count;
        }

        public int QuantidadeDePassageiros()
        {
            return _viagens.Sum(v => v.Passageiros);
        }

        public List<Veiculo> ListarVeiculosNaGaragem(int idGaragem)
        {
            var garagem = _garagens.FirstOrDefault(g => g.Id == idGaragem);
            return garagem?.ListarVeiculos().ToList() ?? new List<Veiculo>();
        }
    }
}
