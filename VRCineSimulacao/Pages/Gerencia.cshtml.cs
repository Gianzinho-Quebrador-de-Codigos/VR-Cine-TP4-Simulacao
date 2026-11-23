using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VRCineSimulacao.Models;

namespace VRCineSimulacao.Pages
{
    public class GerenciaModel : PageModel
    {
        [BindProperty] public string Titulo { get; set; } = "";
        [BindProperty] public int Duracao { get; set; } = 90;
        [BindProperty] public string Nome { get; set; } = "";
        [BindProperty] public string Endereco { get; set; } = "";
        [BindProperty] public DateTime Inicio { get; set; } = DateTime.Today.AddDays(1).AddHours(15);
        public string Mensagem { get; set; } = "";
        public void OnGet() { }
        public void OnPostFilme()
        {
            if (string.IsNullOrWhiteSpace(Titulo) || Duracao <= 0) { Mensagem = "Informe título e duração válida."; return; }
            Filme filme = new Filme(99, Titulo, "Exemplo de filme", Duracao);
            Mensagem = "Simulação: filme " + filme.Titulo + " cadastrado com " + filme.DuracaoMinutos + " minutos. O catálogo não foi alterado.";
        }
        public void OnPostCinema()
        {
            Cinema cinema = new Cinema(99, Nome ?? "", Endereco ?? "");
            Mensagem = "Simulação: cinema " + cinema.Nome + " cadastrado em " + cinema.Endereco + ". Nenhum registro foi salvo.";
        }
        public void OnPostSessao()
        {
            Sessao sessao = new Sessao(99, Inicio, Inicio.AddMinutes(90), 40, 20, false);
            Mensagem = "Simulação: sessão das " + sessao.Inicio.ToString("dd/MM HH:mm") + " às " + sessao.Fim.ToString("HH:mm") + ". A programação não foi alterada.";
        }
    }
}
