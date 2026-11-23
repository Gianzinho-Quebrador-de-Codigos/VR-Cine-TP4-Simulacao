using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VRCineSimulacao.Models;

namespace VRCineSimulacao.Pages
{
    public class AtendimentoModel : PageModel
    {
        [BindProperty] public int SessaoId { get; set; } = 1;
        [BindProperty] public string Codigo { get; set; } = "";
        [BindProperty] public int NumeroPedido { get; set; } = 1;
        [BindProperty] public int CinemaId { get; set; } = 1;
        public string MensagemEntrada { get; set; } = "";
        public string MensagemRetirada { get; set; } = "";
        public Ingresso? IngressoEncontrado { get; set; }
        public Pedido? PedidoEncontrado { get; set; }
        public void OnGet() { }
        public void OnPostConsultarIngresso()
        {
            IngressoEncontrado = DadosSimulacao.BuscarIngresso(Codigo ?? "");
            if (IngressoEncontrado == null) MensagemEntrada = "Ingresso não encontrado.";
            else MensagemEntrada = IngressoEncontrado.ConsultarEntrada(SessaoId);
        }
        public void OnPostConfirmarEntrada()
        {
            OnPostConsultarIngresso();
            if (IngressoEncontrado != null && IngressoEncontrado.RegistrarEntrada(SessaoId)) MensagemEntrada = "Entrada confirmada! Este ingresso não pode ser usado novamente.";
        }
        public void OnPostConsultarPedido()
        {
            PedidoEncontrado = DadosSimulacao.BuscarPedido(NumeroPedido);
            if (PedidoEncontrado == null) MensagemRetirada = "Pedido não encontrado.";
            else if (PedidoEncontrado.Cinema.Id != CinemaId) { MensagemRetirada = "Este pedido pertence a outro cinema."; PedidoEncontrado = null; }
            else MensagemRetirada = PedidoEncontrado.ConsultarRetirada();
        }
        public void OnPostRetirar()
        {
            OnPostConsultarPedido();
            if (PedidoEncontrado != null && PedidoEncontrado.RetirarAlimentos(CinemaId)) MensagemRetirada = "Retirada de todos os alimentos confirmada!";
        }
    }
}
