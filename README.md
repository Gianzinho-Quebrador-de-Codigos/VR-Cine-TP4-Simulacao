# VR Cine — simulação simples

Abra `VRCineSimulacao.sln` no Visual Studio e pressione **Ctrl+F5**. Requer .NET 10 e Razor Pages. O endereço é `http://localhost:5190`.

São cinco páginas, cada uma com seu próprio `.cshtml.cs`: Cinema, Conta, Pedido, Atendimento e Gerencia. O projeto mantém as 12 classes, com campos privados, construtores com parâmetros, propriedades e métodos curtos. `Program.cs` tem apenas a configuração básica do Razor Pages.

`DadosSimulacao.cs` prepara os objetos. Não há banco de dados, CSV, contas reais, senhas, e-mail, cobrança ou QR Code real. A simulação é compartilhada entre todos os visitantes enquanto o programa está aberto. Reiniciar o programa devolve os dados ao início.

## Roteiro de apresentação

1. **Conta:** preencha nome/e-mail e simule cadastro, login e recuperação. As mensagens não criam ou modificam contas.
2. **Cinema:** escolha uma das duas sessões futuras, assentos, inteira/meia e quantidades de pipocas e combos. O cupom `VRCINE10` aplica 10%. O botão simula aprovação do pagamento e cria um pedido em memória.
3. **Pedidos:** confira o total e os códigos dos ingressos. O pedido 2 é uma sessão passada para testar avaliações de 1 a 5. O cancelamento integral altera os ingressos e registra um estorno fictício.
4. **Atendimento / Portaria:** consulte `ING001` na sessão 2: deve avisar sem invalidar. Consulte na sessão 1: deve continuar válido. Confirme a entrada e tente novamente: a segunda entrada deve ser recusada. `ING002` continua independente.
5. **Atendimento / Balcão:** consulte o pedido 1 no cinema correto e confirme a retirada dos alimentos. Uma segunda retirada deve ser recusada. A consulta sozinha não altera o pedido.
6. **Gerência:** os formulários criam objetos de exemplo apenas para exibir a confirmação. Não alteram o catálogo nem guardam registros.

Os ingressos novos também aparecem em Pedidos e podem ser usados no Atendimento. Os alimentos de cada pedido pertencem ao mesmo cinema e são retirados juntos. Na simulação, cada unidade de alimento aparece na lista do pedido; não existe uma classe extra de item ou controle de estoque.

Esta é a versão reduzida aprovada: não reproduz todos os cenários e serviços do projeto completo. As páginas de gerência não validam conflitos de programação; o pagamento sempre é aprovado; a comprovação de meia-entrada é somente uma orientação; os códigos são digitados. As duas mudanças centrais do TP4 (uso único e retirada única) executam regras nas classes.

O projeto completo permanece separado na pasta VR-Cine-CSV. Esta solução não modifica seus dados.

Verificação: compilação com 0 erros e 0 avisos, 30 verificações de navegação e regras, conferência visual em computador e celular. Os testes temporários ficam fora desta solução.

## Documento de entrega

[TP4 - Projeto de Bloco: documento consolidado em PDF](docs/Gianlucca_Palma_PB_TP4.pdf). Inclui o modelo planejado, os diagramas de sequência da simulação, os cabeçalhos implementados e a justificativa do escopo reduzido.
