using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VRCineSimulacao.Pages
{
    public class ContaModel : PageModel
    {
        [BindProperty] public string Nome { get; set; } = "";
        [BindProperty] public string Email { get; set; } = "";
        public string Mensagem { get; set; } = "";
        public void OnGet() { }
        public void OnPostCadastro() { Mensagem = "Simulação: cadastro de " + Nome + " realizado. Nenhuma conta foi criada."; }
        public void OnPostLogin() { Mensagem = "Simulação: acesso realizado com " + Email + ". Você pode navegar pelo menu."; }
        public void OnPostRecuperar() { Mensagem = "Simulação: instruções seriam enviadas para " + Email + ". Nenhum e-mail foi enviado."; }
    }
}
