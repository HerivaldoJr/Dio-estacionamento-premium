using System.Collections.Generic;
using Estacionamento.Core.Models;

namespace Estacionamento.Core.Services
{
    public interface IEstacionamentoService
    {
        void AdicionarVeiculo(Veiculo veiculo);
        Ticket RemoverVeiculo(string placa);
        IEnumerable<Veiculo> ListarVeiculos();
        int VagasDisponiveis();
        int TotalVagas { get; }
    }
}