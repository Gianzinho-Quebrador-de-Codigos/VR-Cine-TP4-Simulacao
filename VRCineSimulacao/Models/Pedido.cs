namespace VRCineSimulacao.Models
{
    public class Pedido
    {
        private int _id;
        private DateTime _dataCriacao;
        private int _status;
        private double _valorDesconto;
        private double _valorTotal;
        private bool _alimentosRetirados = false;
        private Cinema _cinema = null!;
        private List<Ingresso> _ingressos = new List<Ingresso>();
        private List<ProdutoAlimenticio> _alimentos = new List<ProdutoAlimenticio>();
        private Pagamento? _pagamento = null;

        public Pedido(int id, DateTime dataCriacao, int status, double valorDesconto, double valorTotal)
        {
            _id = id;
            _dataCriacao = dataCriacao;
            _status = status;
            _valorDesconto = valorDesconto;
            _valorTotal = valorTotal;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public DateTime DataCriacao { get { return _dataCriacao; } set { _dataCriacao = value; } }
        public int Status { get { return _status; } set { _status = value; } }
        public double ValorDesconto { get { return _valorDesconto; } set { _valorDesconto = value; } }
        public double ValorTotal { get { return _valorTotal; } set { _valorTotal = value; } }
        public bool AlimentosRetirados { get { return _alimentosRetirados; } set { _alimentosRetirados = value; } }
        public Cinema Cinema { get { return _cinema; } set { _cinema = value; } }
        public List<Ingresso> Ingressos { get { return _ingressos; } set { _ingressos = value; } }
        public List<ProdutoAlimenticio> Alimentos { get { return _alimentos; } set { _alimentos = value; } }
        public Pagamento? Pagamento { get { return _pagamento; } set { _pagamento = value; } }

        public void CalcularTotal(double percentual)
        {
            double subtotal = 0;
            foreach (Ingresso ingresso in Ingressos) subtotal += ingresso.Preco;
            foreach (ProdutoAlimenticio produto in Alimentos) subtotal += produto.Preco;
            ValorDesconto = Math.Round(subtotal * percentual / 100, 2);
            ValorTotal = Math.Round(subtotal - ValorDesconto, 2);
        }
        public string ConsultarRetirada()
        {
            if (Status != 2) return "Pedido não confirmado ou cancelado.";
            if (Alimentos.Count == 0) return "Este pedido não tem alimentos.";
            if (AlimentosRetirados) return "Os alimentos já foram retirados.";
            return "Alimentos aguardando retirada.";
        }
        public bool RetirarAlimentos(int cinemaId)
        {
            if (Cinema.Id != cinemaId || Status != 2 || Alimentos.Count == 0 || AlimentosRetirados) return false;
            AlimentosRetirados = true;
            return true;
        }
        public void Cancelar()
        {
            Status = 3;
            foreach (Ingresso ingresso in Ingressos) ingresso.Status = 2;
            if (Pagamento != null) Pagamento.SimularEstorno();
        }
    }
}
