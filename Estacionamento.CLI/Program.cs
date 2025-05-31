using Estacionamento.Core.Models;
using Estacionamento.Core.Services;

var estacionamento = new EstacionamentoService(
    precoInicial: 5, 
    precoPorHora: 2,
    totalVagas: 10);

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.Clear();
    ExibirMenu(estacionamento.VagasDisponiveis());

    var opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                CadastrarVeiculo(estacionamento);
                break;
            case "2":
                RemoverVeiculo(estacionamento);
                break;
            case "3":
                ListarVeiculos(estacionamento);
                break;
            case "4":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }

    Console.WriteLine("\nPressione ENTER para continuar...");
    Console.ReadLine();
}

void ExibirMenu(int vagasDisponiveis)
{
    Console.WriteLine("=== 🅿️ SISTEMA DE ESTACIONAMENTO PREMIUM ===");
    Console.WriteLine($"Vagas disponíveis: {vagasDisponiveis}");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Sair");
    Console.Write("Opção: ");
}

void CadastrarVeiculo(EstacionamentoService service)
{
    Console.Write("Digite a placa do veículo: ");
    var placa = Console.ReadLine() ?? "";
    
    Console.Write("Digite o modelo do veículo (opcional): ");
    var modelo = Console.ReadLine();
    
    var veiculo = new Veiculo(placa, modelo);
    service.AdicionarVeiculo(veiculo);
    
    Console.WriteLine($"\nVeículo {veiculo.Placa} cadastrado com sucesso!");
    Console.WriteLine($"Entrada: {veiculo.HoraEntrada:HH:mm}");
}

void RemoverVeiculo(EstacionamentoService service)
{
    Console.Write("Digite a placa do veículo para remover: ");
    var placa = Console.ReadLine() ?? "";
    
    var ticket = service.RemoverVeiculo(placa);
    
    Console.WriteLine("\n=== TICKET DE SAÍDA ===");
    Console.WriteLine($"Placa: {ticket.Veiculo.Placa}");
    Console.WriteLine($"Modelo: {ticket.Veiculo.Modelo ?? "Não informado"}");
    Console.WriteLine($"Entrada: {ticket.Veiculo.HoraEntrada:HH:mm}");
    Console.WriteLine($"Saída: {ticket.HoraSaida:HH:mm}");
    Console.WriteLine($"Tempo: {ticket.TempoPermanencia:hh\\:mm}");
    Console.WriteLine($"Valor total: R$ {ticket.ValorTotal:F2}");
}

void ListarVeiculos(EstacionamentoService service)
{
    var veiculos = service.ListarVeiculos();
    
    if (!veiculos.Any())
    {
        Console.WriteLine("Nenhum veículo estacionado.");
        return;
    }
    
    Console.WriteLine("=== VEÍCULOS ESTACIONADOS ===");
    foreach (var veiculo in veiculos)
    {
        Console.WriteLine($"Placa: {veiculo.Placa}");
        Console.WriteLine($"Modelo: {veiculo.Modelo ?? "Não informado"}");
        Console.WriteLine($"Entrada: {veiculo.HoraEntrada:HH:mm}");
        Console.WriteLine("-------------------");
    }
    Console.WriteLine($"Total: {veiculos.Count()} veículo(s)");
}