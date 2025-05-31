namespace Estacionamento.Core.Models;

public class Ticket
{
    public Veiculo Veiculo { get; }
    public DateTime HoraSaida { get; }
    public decimal ValorTotal { get; }
    public TimeSpan TempoPermanencia { get; }
    
    public Ticket(Veiculo veiculo, decimal valorTotal)
    {
        Veiculo = veiculo;
        HoraSaida = DateTime.Now;
        ValorTotal = valorTotal;
        TempoPermanencia = HoraSaida - veiculo.HoraEntrada;
    }
}