namespace Estacionamento.Core.Models;

public class Veiculo
{
    public string Placa { get; }
    public DateTime HoraEntrada { get; }
    public string? Modelo { get; } // Adicionei modelo como melhoria
    
    public Veiculo(string placa, string? modelo = null)
    {
        if (string.IsNullOrWhiteSpace(placa))
            throw new ArgumentException("Placa é obrigatória");
            
        Placa = FormatarPlaca(placa);
        Modelo = modelo;
        HoraEntrada = DateTime.Now;
    }

    public static string FormatarPlaca(string placa)
    {
        return placa
            .Trim()
            .ToUpper()
            .Replace("-", "")
            .Replace(" ", "");
    }
}