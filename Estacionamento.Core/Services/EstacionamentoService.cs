using System;
using System.Collections.Generic;
using System.Linq;
using Estacionamento.Core.Models;

namespace Estacionamento.Core.Services
{
    public class EstacionamentoService : IEstacionamentoService
    {
        private readonly decimal _precoInicial;
        private readonly decimal _precoPorHora;
        private readonly List<Veiculo> _veiculos;
        public int TotalVagas { get; }

        public EstacionamentoService(decimal precoInicial, decimal precoPorHora, int totalVagas = 50)
        {
            _precoInicial = precoInicial;
            _precoPorHora = precoPorHora;
            TotalVagas = totalVagas;
            _veiculos = new List<Veiculo>();
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            if (_veiculos.Count >= TotalVagas)
                throw new InvalidOperationException("Estacionamento lotado!");
                
            if (_veiculos.Any(v => v.Placa == veiculo.Placa))
                throw new InvalidOperationException("Veículo já está estacionado!");
            
            _veiculos.Add(veiculo);
        }

        public Ticket RemoverVeiculo(string placa)
        {
            var veiculo = _veiculos.FirstOrDefault(v => v.Placa == FormatarPlaca(placa));
            if (veiculo == null)
                throw new KeyNotFoundException("Veículo não encontrado!");

            _veiculos.Remove(veiculo);
            
            var tempoEstacionado = DateTime.Now - veiculo.HoraEntrada;
            var horasEstacionado = Math.Max(1, Math.Ceiling(tempoEstacionado.TotalHours));
            var valorTotal = _precoInicial + (decimal)horasEstacionado * _precoPorHora;
            
            return new Ticket(veiculo, valorTotal);
        }

        public IEnumerable<Veiculo> ListarVeiculos() => _veiculos.AsReadOnly();

        public int VagasDisponiveis() => TotalVagas - _veiculos.Count;
        
        private static string FormatarPlaca(string placa) => Veiculo.FormatarPlaca(placa);
    }
}