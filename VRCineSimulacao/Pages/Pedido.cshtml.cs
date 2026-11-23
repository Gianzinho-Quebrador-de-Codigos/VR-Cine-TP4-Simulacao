using Microsoft.AspNetCore.Mvc.RazorPages;
using VRCineSimulacao.Models;

namespace VRCineSimulacao.Pages
{
    public class PedidoModel : PageModel
    {
        public string Mensagem { get; set; } = "";
        public void OnGet() { }
        public void OnPostCancelar(int id)
        {
            Pedido? pedido = DadosSimulacao.BuscarPedido(id);
            if (pedido == null || pedido.Status != 2) { Mensagem = "Pedido não disponível para cancelamento."; return; }
            pedido.Cancelar();
            Mensagem = "Simulação: pedido cancelado e estorno registrado. Não houve devolução de dinheiro real.";
        }
        public void OnPostAvaliar(int sessaoId, int notaFilme, int notaConforto, string comentario)
        {
            foreach (Pedido pedido in DadosSimulacao.Pedidos)
                foreach (Ingresso ingresso in pedido.Ingressos)
                    if (ingresso.Sessao.Id == sessaoId && pedido.Status == 2)
                    {
                        Avaliacao avaliacao = new Avaliacao(DadosSimulacao.Avaliacoes.Count + 1, notaFilme, notaConforto, comentario ?? "", DateTime.Now) { Sessao = ingresso.Sessao };
                        if (!ingresso.Sessao.EstaEncerrada() || !avaliacao.NotasValidas()) { Mensagem = "Avalie após o fim da sessão com notas de 1 a 5."; return; }
                        DadosSimulacao.Avaliacoes.Add(avaliacao);
                        Mensagem = "Avaliação simulada registrada. Obrigado!";
                        return;
                    }
            Mensagem = "Sessão não encontrada em um pedido confirmado.";
        }
    }
}
