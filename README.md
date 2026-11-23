# VR Cine — simulação simples

Abra `VRCineSimulacao.sln` no Visual Studio e pressione **Ctrl+F5**. Requer .NET 10 e Razor Pages. O endereço é `http://localhost:5190`.

São cinco páginas, cada uma com seu próprio `.cshtml.cs`: Cinema, Conta, Pedido, Atendimento e Gerencia. O projeto mantém as 12 classes, com campos privados, construtores com parâmetros, propriedades e métodos curtos. `Program.cs` tem apenas a configuração básica do Razor Pages.

`DadosSimulacao.cs` prepara os objetos. Não há banco de dados, CSV, contas reais, senhas, e-mail, cobrança ou QR Code real. A simulação é compartilhada entre todos os visitantes enquanto o programa está aberto. Reiniciar o programa devolve os dados ao início.

## Documento de entrega

[TP4 - Projeto de Bloco: documento consolidado em PDF](docs/Gianlucca_Palma_PB_TP4.pdf). Apresenta a simplificação como mudança de escopo do TP4 e inclui dicionário, diagrama de classes da simulação, diagramas de sequência e cabeçalhos dos métodos implementados.
