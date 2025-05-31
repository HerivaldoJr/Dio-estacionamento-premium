🚗 Sistema de Estacionamento em C# 🚗
.NET
C#

Projeto desenvolvido como parte de um desafio de fundamentos da linguagem C#. Ele simula o funcionamento de um estacionamento com arquitetura em camadas.

✨ Funcionalidades
✅ Cadastro de veículos com validação de placa
✅ Remoção de veículos com cálculo automático de tarifa
✅ Listagem organizada de veículos estacionados
✅ Controle de vagas em tempo real
✅ Ticket de saída detalhado com valor calculado
✅ Validação de duplicidade de veículos
✅ Tratamento de erros robusto

🛠 Tecnologias Utilizadas
.NET Core / .NET 6+
C# 

🚀 Como Executar
Clone o repositório:

bash
git clone https://github.com/HerivaldoJr/estacionamento-premium.git
cd estacionamento-premium
Execute o projeto:

bash
dotnet run --project src/Estacionamento.CLI
📸 Demonstração
╔══════════════════════════════════════════════╗
║      SISTEMA DE ESTACIONAMENTO - MENU        ║
╠══════════════════════════════════════════════╣
║  1 - Cadastrar veículo                       ║
║  2 - Remover veículo                         ║
║  3 - Listar veículos                         ║
║  4 - Encerrar                                ║
╚══════════════════════════════════════════════╝
Escolha uma opção: 1

Digite a placa do veículo: ABC-1234
Digite o modelo (opcional): Onix 2022

✅ Veículo cadastrado com sucesso!
🏗️ Estrutura do Projeto
estacionamento-premium/
├── src/
│   ├── Estacionamento.Core/       ← Lógica principal
│   ├── Estacionamento.CLI/       ← Interface
│   └── Estacionamento.sln
├── tests/
│   └── Estacionamento.Tests/     ← Testes
└── .gitignore

📄 Licença
Este projeto está licenciado sob a MIT License.

Desenvolvido por Herivaldo Jr
GitHub
