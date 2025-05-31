using Estacionamento.Core.Models;
using Estacionamento.Core.Services;
using Xunit;

namespace Estacionamento.Tests;

public class EstacionamentoTests
{
    private readonly EstacionamentoService _service;
    private readonly Veiculo _veiculoTeste;

    public EstacionamentoTests()
    {
        _service = new EstacionamentoService(5, 2, 1);
        _veiculoTeste = new Veiculo("ABC-1234", "Fusca");
    }

    [Fact]
    public void AdicionarVeiculo_DeveFuncionar()
    {
        _service.AdicionarVeiculo(_veiculoTeste);
        Assert.Single(_service.ListarVeiculos());
    }

    [Fact]
    public void AdicionarVeiculo_PlacaInvalida_DeveLancarExcecao()
    {
        Assert.Throws<ArgumentException>(() => new Veiculo(""));
    }

    [Fact]
    public void AdicionarVeiculo_EstacionamentoLotado_DeveLancarExcecao()
    {
        _service.AdicionarVeiculo(_veiculoTeste);
        Assert.Throws<InvalidOperationException>(() => 
            _service.AdicionarVeiculo(new Veiculo("XYZ-9876")));
    }

    [Fact]
    public void RemoverVeiculo_DeveCalcularValorCorretamente()
    {
        _service.AdicionarVeiculo(_veiculoTeste);
        var ticket = _service.RemoverVeiculo("ABC1234");
        
        Assert.True(ticket.ValorTotal >= 5);
        Assert.Equal(_veiculoTeste.Placa, ticket.Veiculo.Placa);
    }

    [Fact]
    public void ListarVeiculos_DeveRetornarListaImutavel()
    {
        _service.AdicionarVeiculo(_veiculoTeste);
        var veiculos = _service.ListarVeiculos();
        
        Assert.Throws<NotSupportedException>(() => 
            ((List<Veiculo>)veiculos).Remove(_veiculoTeste));
    }
}