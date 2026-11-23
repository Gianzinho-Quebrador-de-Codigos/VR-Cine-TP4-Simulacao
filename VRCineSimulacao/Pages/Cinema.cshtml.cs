using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VRCineSimulacao.Models;

namespace VRCineSimulacao.Pages
{
    public class CinemaModel : PageModel
    {
        [BindProperty] public int SessaoId { get; set; } = 1;
        [BindProperty] public List<int> Lugares { get; set; } = new List<int>();
        [BindProperty] public int Tipo { get; set; } = 1;
        [BindProperty] public int Pipocas { get; set; }
        [BindProperty] public int Combos { get; set; }
        [BindProperty] public string CodigoCupom { get; set; } = "";
        [BindProperty] public string Necessidades { get; set; } = "";
        public string Mensagem { get; set; } = "";
        public Sessao? SessaoEscolhida { get; set; }

        public void OnGet(int sessaoId = 1) { SessaoId = sessaoId; CarregarSessao(); }
        private void CarregarSessao()
        {
            foreach (Sessao sessao in DadosSimulacao.Sessoes)
                if (sessao.Id == SessaoId && !sessao.EstaEncerrada() && !sessao.Cancelada) SessaoEscolhida = sessao;
        }
        public IActionResult OnPost()
        {
            CarregarSessao();
            if (SessaoEscolhida == null || Lugares.Count == 0 || Tipo < 1 || Tipo > 2 || Pipocas < 0 || Combos < 0 || Pipocas > 10 || Combos > 10)
            { Mensagem = "Escolha uma sessão, os assentos e quantidades de 0 a 10."; return Page(); }
            double percentual = 0;
            if (!string.IsNullOrWhiteSpace(CodigoCupom))
            {
                if (CodigoCupom.Trim().ToUpper() != DadosSimulacao.Cupom.Codigo || !DadosSimulacao.Cupom.EstaValido())
                { Mensagem = "Cupom inválido. Experimente VRCINE10 ou deixe vazio."; return Page(); }
                percentual = DadosSimulacao.Cupom.PercentualDesconto;
            }
            List<Assento> selecionados = new List<Assento>();
            foreach (int id in Lugares)
            {
                Assento? lugar = null;
                foreach (Assento assento in DadosSimulacao.Assentos) if (assento.Id == id) lugar = assento;
                if (lugar == null || selecionados.Contains(lugar) || !DadosSimulacao.AssentoDisponivel(SessaoEscolhida, lugar))
                { Mensagem = "Um assento está indisponível. Escolha novamente."; return Page(); }
                selecionados.Add(lugar);
            }
            Pedido pedido = new Pedido(DadosSimulacao.Pedidos.Count + 1, DateTime.Now, 2, 0, 0) { Cinema = SessaoEscolhida.Sala.Cinema };
            foreach (Assento lugar in selecionados) pedido.Ingressos.Add(DadosSimulacao.CriarIngresso(SessaoEscolhida, lugar, Tipo, Necessidades ?? ""));
            for (int i = 0; i < Pipocas; i++) pedido.Alimentos.Add(new ProdutoAlimenticio(1, "Pipoca", "Pipoca grande", 15, true) { Cinema = pedido.Cinema });
            for (int i = 0; i < Combos; i++) pedido.Alimentos.Add(new ProdutoAlimenticio(2, "Combo", "Pipoca e refrigerante", 25, true) { Cinema = pedido.Cinema });
            pedido.CalcularTotal(percentual);
            pedido.Pagamento = new Pagamento(pedido.Id, 1, pedido.ValorTotal, DateTime.Now, 1, "SIMULADO", 0, 0);
            DadosSimulacao.Pedidos.Add(pedido);
            return RedirectToPage("/Pedido");
        }
    }
}
