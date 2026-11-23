namespace VRCineSimulacao.Models
{
    public class Pagamento
    {
        private int _id;
        private int _metodo;
        private double _valor;
        private DateTime _dataSolicitacao;
        private int _status;
        private string _referenciaExterna;
        private int _statusEstorno;
        private double _valorEstornado;

        public Pagamento(int id, int metodo, double valor, DateTime dataSolicitacao, int status, string referenciaExterna, int statusEstorno, double valorEstornado)
        {
            _id = id;
            _metodo = metodo;
            _valor = valor;
            _dataSolicitacao = dataSolicitacao;
            _status = status;
            _referenciaExterna = referenciaExterna;
            _statusEstorno = statusEstorno;
            _valorEstornado = valorEstornado;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public int Metodo { get { return _metodo; } set { _metodo = value; } }
        public double Valor { get { return _valor; } set { _valor = value; } }
        public DateTime DataSolicitacao { get { return _dataSolicitacao; } set { _dataSolicitacao = value; } }
        public int Status { get { return _status; } set { _status = value; } }
        public string ReferenciaExterna { get { return _referenciaExterna; } set { _referenciaExterna = value; } }
        public int StatusEstorno { get { return _statusEstorno; } set { _statusEstorno = value; } }
        public double ValorEstornado { get { return _valorEstornado; } set { _valorEstornado = value; } }

        public void SimularEstorno()
        {
            StatusEstorno = 2;
            ValorEstornado = Valor;
        }
    }
}
