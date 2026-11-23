using VRCineSimulacao.Models;

namespace VRCineSimulacao
{
    public static class DadosSimulacao
    {
        public static List<Cinema> Cinemas = new List<Cinema>();
        public static List<Sessao> Sessoes = new List<Sessao>();
        public static List<Assento> Assentos = new List<Assento>();
        public static List<Pedido> Pedidos = new List<Pedido>();
        public static List<Avaliacao> Avaliacoes = new List<Avaliacao>();
        public static Cupom Cupom = new Cupom(1, "VRCINE10", 10, DateTime.Today.AddYears(1), true);
        public static int ProximoIngresso = 1;

        static DadosSimulacao()
        {
            Cinema cinema1 = new Cinema(1, "VR Cine Centro", "Centro de Cuiabá");
            Cinema cinema2 = new Cinema(2, "VR Cine Shopping", "Shopping da cidade");
            Cinemas.Add(cinema1);
            Cinemas.Add(cinema2);
            Sala sala1 = new Sala(1, "Sala 1", true) { Cinema = cinema1 };
            Sala sala2 = new Sala(2, "Sala 2", true) { Cinema = cinema2 };
            Filme filme1 = new Filme(1, "Além da órbita", "Uma viagem de realidade virtual pelo espaço.", 90);
            Filme filme2 = new Filme(2, "Abismo azul", "Uma aventura nas profundezas do oceano.", 100);
            DateTime inicio = DateTime.Today.AddDays(1).AddHours(19);
            Sessoes.Add(new Sessao(1, inicio, inicio.AddMinutes(90), 40, 20, false) { Filme = filme1, Sala = sala1 });
            Sessoes.Add(new Sessao(2, inicio, inicio.AddMinutes(100), 40, 20, false) { Filme = filme2, Sala = sala2 });
            Sessoes.Add(new Sessao(3, inicio.AddDays(-2), inicio.AddDays(-2).AddMinutes(90), 40, 20, false) { Filme = filme1, Sala = sala1 });
            for (int numero = 1; numero <= 6; numero++)
            {
                Assentos.Add(new Assento(numero, "A0" + numero, true) { Sala = sala1 });
                Assentos.Add(new Assento(numero + 6, "A0" + numero, true) { Sala = sala2 });
            }
            Pedido pedido = new Pedido(1, DateTime.Now, 2, 0, 0) { Cinema = cinema1 };
            pedido.Ingressos.Add(CriarIngresso(Sessoes[0], Assentos[0], 1, ""));
            pedido.Ingressos.Add(CriarIngresso(Sessoes[0], Assentos[2], 1, ""));
            pedido.Alimentos.Add(new ProdutoAlimenticio(1, "Pipoca", "Pipoca grande", 15, true) { Cinema = cinema1 });
            pedido.CalcularTotal(0);
            pedido.Pagamento = new Pagamento(1, 1, pedido.ValorTotal, DateTime.Now, 1, "SIMULADO", 0, 0);
            Pedidos.Add(pedido);
            Pedido anterior = new Pedido(2, DateTime.Today.AddDays(-1), 2, 0, 40) { Cinema = cinema1 };
            anterior.Ingressos.Add(CriarIngresso(Sessoes[2], Assentos[0], 1, ""));
            anterior.Pagamento = new Pagamento(2, 1, 40, anterior.DataCriacao, 1, "SIMULADO", 0, 0);
            Pedidos.Add(anterior);
        }

        public static Ingresso CriarIngresso(Sessao sessao, Assento assento, int tipo, string necessidades)
        {
            double preco = sessao.PrecoInteira;
            if (tipo == 2) preco = sessao.PrecoMeia;
            int id = ProximoIngresso++;
            return new Ingresso(id, tipo, preco, 1, "ING" + id.ToString("000"), DateTime.Now, necessidades) { Sessao = sessao, Assento = assento };
        }
        public static bool AssentoDisponivel(Sessao sessao, Assento assento)
        {
            if (!assento.Ativo || assento.Sala.Id != sessao.Sala.Id) return false;
            foreach (Pedido pedido in Pedidos)
                foreach (Ingresso ingresso in pedido.Ingressos)
                    if (ingresso.Sessao.Id == sessao.Id && ingresso.Assento.Id == assento.Id && ingresso.Status != 2) return false;
            return true;
        }
        public static Pedido? BuscarPedido(int id)
        {
            foreach (Pedido pedido in Pedidos) if (pedido.Id == id) return pedido;
            return null;
        }
        public static Ingresso? BuscarIngresso(string codigo)
        {
            foreach (Pedido pedido in Pedidos)
                foreach (Ingresso ingresso in pedido.Ingressos)
                    if (ingresso.CodigoQR == codigo.Trim().ToUpper()) return ingresso;
            return null;
        }
    }
}
