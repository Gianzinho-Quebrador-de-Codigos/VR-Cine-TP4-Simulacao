namespace VRCineSimulacao.Models
{
    public class Cupom
    {
        private int _id;
        private string _codigo;
        private double _percentualDesconto;
        private DateTime _validade;
        private bool _ativo;

        public Cupom(int id, string codigo, double percentualDesconto, DateTime validade, bool ativo)
        {
            _id = id;
            _codigo = codigo;
            _percentualDesconto = percentualDesconto;
            _validade = validade;
            _ativo = ativo;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Codigo { get { return _codigo; } set { _codigo = value; } }
        public double PercentualDesconto { get { return _percentualDesconto; } set { _percentualDesconto = value; } }
        public DateTime Validade { get { return _validade; } set { _validade = value; } }
        public bool Ativo { get { return _ativo; } set { _ativo = value; } }

        public bool EstaValido()
        {
            return Ativo && Validade >= DateTime.Now && PercentualDesconto > 0 && PercentualDesconto <= 100;
        }
    }
}
